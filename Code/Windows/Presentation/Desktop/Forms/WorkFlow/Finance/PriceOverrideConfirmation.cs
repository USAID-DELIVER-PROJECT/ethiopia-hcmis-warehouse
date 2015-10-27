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
using HCMIS.Core.Finance.CostTier;
using HCMIS.Core.Finance.CostTier.Services;
using HCMIS.Desktop.Helpers;
using HCMIS.Helpers;
using HCMIS.Specification.Finance.CostTier;

namespace HCMIS.Desktop.Forms.WorkFlow.Finance
{
   [FormIdentifier("PR-CO-PC-FR", "Price Confirmation", "")]
    public partial class PriceOverrideConfirmation : Form
    {
        public PriceOverrideConfirmation()
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
        }

        private void AdjustLayoutAndVisibility()
        {
            if (BLL.Settings.UseNewUserManagement)
            {
               // layoutBtnLoad.Visibility = this.HasPermission("Set-Price")
                                               //? LayoutVisibility.Always
                                               //: LayoutVisibility.Never;
            }
        }

        
        #endregion

        #region Binding Events

        private void BindDataSet()
        {
            if(lkAccount.EditValue != null)
            {
                int movingAverageID = Convert.ToInt32(((System.Data.DataRowView)lkAccount.EditValue)["MovingAverageID"]);
                gridPriceList.DataSource = BLL.Receipt.GetPriceConfirmationListFromCostTier(movingAverageID);
            }
            else
            {
                XtraMessageBox.Show("Select an Account before loading the price list", "Select Account...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            BindDataSet();
        }
        
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            MyGeneration.dOOdads.TransactionMgr transaction = MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgr();

            DataView dtChangedPricelist = gridViewPriceList.DataSource as DataView;
            if (dtChangedPricelist != null)
            {

                dtChangedPricelist.RowFilter = "IsConfirmed = 1";
           
                foreach (DataRowView drw in dtChangedPricelist)
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
                            costElement.SellingPrice = Math.Round(Convert.ToDouble(drw["SellingPrice"]),
                                                                  BLL.Settings.NoOfDigitsAfterTheDecimalPoint,
                                                                  MidpointRounding.AwayFromZero);


                            costElement.ConfirmPrice(CurrentContext.UserId,"", journalService,ChangeMode.PriceOverride);
                            ReceiveDoc receiveDoc = new ReceiveDoc();
                            receiveDoc.SavePrice(costElement, CurrentContext.UserId);
                            journalService.CommitRecordingSession();
                            transaction.CommitTransaction();
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

            XtraMessageBox.Show("No Changes have been made", "No Changes...", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtfilter_EditValueChanged(object sender, EventArgs e)
        {
                string filter = txtfilter.EditValue != null ? txtfilter.EditValue.ToString() : "";
                gridViewPriceList.ActiveFilterString = String.Format("ItemName like '{0}%' Or StockCode like '{0}%'", filter);

            
        }
    }
}
