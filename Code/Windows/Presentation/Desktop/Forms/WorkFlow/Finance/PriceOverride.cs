using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using BLL.Finance;
using BLL.Models;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraReports.UI;
using HCMIS.Concrete.Models;
using HCMIS.Core.Finance.CostTier;
using HCMIS.Core.Finance.CostTier.Services;
using HCMIS.Desktop.Helpers;
using HCMIS.Desktop.Reports.Finance;
using HCMIS.Desktop.Reports.Helpers;
using HCMIS.Helpers;
using HCMIS.Specification.Finance.CostTier;

namespace HCMIS.Desktop.Forms.WorkFlow.Finance
{
    [FormIdentifier("PR-CO-PO-FR", "Price List", "")]
    public partial class PriceOverride : Form
    {
        public PriceOverride()
        {
            InitializeComponent();
        }

        private void PriceOverride_Load(object sender, EventArgs e)
        {
            if (!BLL.Settings.UseCostTier)
            {
                XtraMessageBox.Show("This Costing Page is Only Applicable when cost Tier is on", "User Management Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Enabled = false;
            }
            BindLookUps();
            AdjustLayoutAndVisibility();
        }
    
        #region Layout and Initialization
        
        private void BindLookUps()
        {
            var movingAverageGroup = new MovingAverageGroup();
            movingAverageGroup.LoadByUser(CurrentContext.UserId);
            lkAccount.Properties.DataSource = movingAverageGroup.DefaultView;
            lkCategory.Properties.DataSource = CommodityType.GetAllTypes();
        }

        private void AdjustLayoutAndVisibility()
        {
            if (BLL.Settings.UseNewUserManagement)
            {
                layoutBtnLoad.Visibility = this.HasPermission("Set-Price")
                                               ? LayoutVisibility.Always
                                               : LayoutVisibility.Never;
            }
        }

        
        #endregion

        #region Binding Events

        private void BindDataSet()
        {
            if(lkAccount.EditValue != null)
            {
                int movingAverageID = Convert.ToInt32(((System.Data.DataRowView)lkAccount.EditValue)["MovingAverageID"]);
                gridPriceList.DataSource = BLL.Receipt.GetPriceListFromCostTier(movingAverageID,chkShowAll.Checked);
            }
            else
            {
                XtraMessageBox.Show("Select an Account before loading the price list", "Select Account...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            BindDataSet();
            txtfilter_EditValueChanged(null, null);
        }
        
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            MyGeneration.dOOdads.TransactionMgr transaction = MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgr();


            if (gridPriceList.DataSource != null && (gridPriceList.DataSource as DataTable).GetChanges() != null)
            {
                DataTable dtChangedPricelist = (gridPriceList.DataSource as DataTable).GetChanges();
                if (dtChangedPricelist != null)
                {
                    foreach (DataRowView drw in dtChangedPricelist.DefaultView)
                    {
                        var dialogResult =
                            XtraMessageBox.Show(
                                String.Format("Are you Sure you want to Change Price for {0}", drw["ItemName"]),
                                "Are you sure", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Cancel)
                        {
                            return;
                        }

                        if (dialogResult == DialogResult.Yes)
                        {
                            try
                            {
                                transaction.BeginTransaction();
                                // This is where we set the Price
                                JournalService journalService = new JournalService();
                                journalService.StartRecordingSession();
                                CostElement costElement = new CostElement(Convert.ToInt32(drw["ItemID"])
                                                                          , Convert.ToInt32(drw["MovingAverageGroupID"])
                                                                          , Convert.ToInt32(drw["ManufacturerID"])
                                                                          , Convert.ToInt32(drw["UnitID"]));

                                costElement.AverageCost = Math.Round(Convert.ToDouble(drw["UnitCost"]),
                                                                     BLL.Settings.NoOfDigitsAfterTheDecimalPoint,
                                                                     MidpointRounding.AwayFromZero);
                                costElement.Margin = Math.Round(Convert.ToDouble(drw["Margin"]),
                                                                BLL.Settings.NoOfDigitsAfterTheDecimalPoint+2,
                                                                MidpointRounding.AwayFromZero);
                                if(BLL.Settings.IsCenter)
                                {
                                    costElement.SellingPrice = costElement.AverageCost;
                                }
                                else 
                                { 
                                    costElement.SellingPrice = Math.Round(Convert.ToDouble(drw["SellingPrice"]),
                                                                      BLL.Settings.NoOfDigitsAfterTheDecimalPoint,
                                                                      MidpointRounding.AwayFromZero);
                                }


                                costElement.SavePrice(CurrentContext.UserId, "", journalService, ChangeMode.PriceOverride);
                                
                                PriceOverridePrintout report = new PriceOverridePrintout();
                                report.xrCostedBy.Text = CurrentContext.LoggedInUserName;
                                report.lblDate.Text = DateTimeHelper.ServerDateTime.ToString();
                                report.DataSource = getPriceChangeReport(costElement);
                                
                                journalService.CommitRecordingSession();
                                transaction.CommitTransaction();
                               
                                report.ShowPreviewDialog();
                            }
                            catch (Exception exception)
                            {
                                transaction.RollbackTransaction();
                                XtraMessageBox.Show("Error : " + exception.Message, "Error...", MessageBoxButtons.OK,
                                                    MessageBoxIcon.Error);
                                throw exception;
                            }
                        }

                    }
                    BindDataSet();
                    XtraMessageBox.Show("Change was Successfull", "Success...", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    return;
                }
            }

            XtraMessageBox.Show("No Changes have been made", "No Changes...", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void gridPriceList_Click(object sender, EventArgs e)
        {

        }
     
        public DataView getPriceChangeReport(CostElement costElement)
        {
            TheDataSet dataSet = new TheDataSet();
            DataRow dr = dataSet.PriceOveride.NewRow();
           
            dataSet.PriceOveride.Rows.Add(costElement.priceChangeReport(dr));
            return dataSet.PriceOveride.DefaultView;
        }        
        
        private void gridViewPriceList_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
          if(e.Column == colUnitCost)
          {
              DataRow dr = gridViewPriceList.GetDataRow(e.RowHandle);
              dr["SellingPrice"] = Math.Round((Convert.ToDecimal(dr["Margin"]) +1)*Convert.ToDecimal(dr["UnitCost"]),BLL.Settings.NoOfDigitsAfterTheDecimalPoint,MidpointRounding.AwayFromZero);
          }
          else if(e.Column == colMargin)
          {
              DataRow dr = gridViewPriceList.GetDataRow(e.RowHandle);
              dr["SellingPrice"] = Math.Round((Convert.ToDecimal(dr["Margin"]) +1) * Convert.ToDecimal(dr["UnitCost"]), BLL.Settings.NoOfDigitsAfterTheDecimalPoint, MidpointRounding.AwayFromZero);
       
          }
          else if(e.Column == colSellingPrice)
          {
              DataRow dr = gridViewPriceList.GetDataRow(e.RowHandle);
              dr["Margin"] = Math.Round(Convert.ToDecimal(dr["SellingPrice"])/Convert.ToDecimal(dr["UnitCost"]) - 1,BLL.Settings.NoOfDigitsAfterTheDecimalPoint+2,MidpointRounding.AwayFromZero);
       
          }

        }

        private void txtfilter_EditValueChanged(object sender, EventArgs e)
        {
            if (lkCategory.EditValue != null)
            {


                string filter = txtfilter.EditValue != null? txtfilter.EditValue.ToString():"";
                gridViewPriceList.ActiveFilterString = String.Format("(ItemName like '{0}%' Or  Manufacturer like '{0}%' Or StockCode like '{0}%') and TypeID = {1}",
                                                                     filter,lkCategory.EditValue);
            }
            else
            {
                string filter = txtfilter.EditValue != null ? txtfilter.EditValue.ToString() : "";
                gridViewPriceList.ActiveFilterString = String.Format("ItemName like '{0}%' Or StockCode like '{0}%' or Manufacturer like '{0}%'", filter);

            }
        }

        private void lkCategory_EditValueChanged(object sender, EventArgs e)
        {
            txtfilter_EditValueChanged(null,null);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if((gridPriceList.DataSource as DataTable).GetChanges() == null)
            {
         
                CostTierPriceList priceList = new CostTierPriceList(CurrentContext.LoggedInUserName);

                int movingAverageID = Convert.ToInt32(((System.Data.DataRowView)lkAccount.EditValue)["MovingAverageID"]);
               
                priceList.DataSource = BLL.Receipt.GetPriceListFromCostTier(movingAverageID,chkShowAll.Checked);
                priceList.ShowPreview();
               
            }
            else
            {
                XtraMessageBox.Show("Please Save Changes First.");
            }
        }

        private void chkShowAll_CheckedChanged(object sender, EventArgs e)
        {
            BindDataSet();
            txtfilter_EditValueChanged(null, null);
        }

        private void btnItemPriceHistory_Click(object sender, EventArgs e)
        {
            var datarow = gridViewPriceList.GetFocusedDataRow();
            int itemID = 0, unitID = 0, manufacturerID = 0;
            if (datarow != null)
            {
                itemID =Convert.ToInt32(datarow["ItemID"]);
                unitID = Convert.ToInt32(datarow["UnitID"]);
                manufacturerID = Convert.ToInt32(datarow["ManufacturerID"]);

            }
            var dialog = new HCMIS.Desktop.Forms.Reports.ItemPriceHistoryReport();
            dialog.ShowDialog();
        }

        private void lkAccount_EditValueChanged(object sender, EventArgs e)
        {


            lblMode.Text = (string)(((System.Data.DataRowView)lkAccount.EditValue)["StoreType"]);
        }
    }
}
