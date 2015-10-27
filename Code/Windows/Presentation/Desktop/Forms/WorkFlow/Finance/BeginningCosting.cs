using System;
using System.ComponentModel;
using System.Data;
using BLL;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraReports.UI;
using HCMIS.Core.Finance.CostTier;
using HCMIS.Core.Finance.CostTier.Services;
using HCMIS.Desktop.Modals;
using System.Windows.Controls;
using HCMIS.Desktop.ViewHelpers;
using HCMIS.Helpers;
using CalendarLib;
using HCMIS.Specification.Finance.CostTier;

namespace HCMIS.Desktop.Forms.WorkFlow
{
    [FormIdentifier("IN-BI-BI-FR", "Beginning Balance By Warehouse", "")]
    public partial class BegginingCosting : XtraForm
    {
        BLL.Receipt receipt = new BLL.Receipt();


        //For Master and Detail we need to create a dataset that holds both tables
        DataSet ds = new DataSet();

        #region Initialization and Mode Settings

        public BegginingCosting()
        {
            InitializeComponent();

        }

        private void PutAwayListsLoad(object sender, EventArgs e)
        {
            
            //Load Cluster->Warehouse Selection
            //Lookup For Warehouse
            lkWarehouse.Properties.DataSource = BLL.Warehouse.GetWarehouseWithCluster(CurrentContext.UserId);
            
            lkAccount.SetupActivityEditor().SetDefaultActivity();
          
            lkCategories.Properties.DataSource = BLL.CommodityType.GetAllTypes();
            lkCategories.EditValue = 0;
            LayoutByAccessMode();
            
        }

        private void LayoutByAccessMode()
        {
            User user = new User();

            user.LoadByPrimaryKey(CurrentContext.UserId);
           
        }

        #endregion

        #region Lookup Changes Events

        private void lkAccount_EditValueChanged(object sender, EventArgs e)
        {
            if (lkWarehouse.EditValue != null)
            {
                lkWarehouse_EditValueChanged(null, null);
                
            }
        }

        private void lkWarehouse_EditValueChanged(object sender, EventArgs e)
        {
            if (lkAccount.EditValue != null && lkCategories.EditValue != null)
            {
                gridMain.DataSource = BLL.Receipt.GetInventoryListByAccountandWarehouse(Convert.ToInt32(lkAccount.EditValue), Convert.ToInt32(lkWarehouse.EditValue), Convert.ToInt32(lkCategories.EditValue));
                lkPeriod.Properties.DataSource = InventoryPeriod.GetInvetoryPeriodByWarehouse(Convert.ToInt32(lkWarehouse.EditValue));
            }
            
          
        }
   
        private void lkCategories_EditValueChanged(object sender, EventArgs e)
        {
            lkAccount_EditValueChanged(null, null);
        }
       
        #endregion

        private void gridMasterView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
          
            if (lkWarehouse.EditValue != null && lkAccount.EditValue != null)
            {
                double NewUnitCost;
                double Margin;
                string ReceiveDocIDs;
                DataRow Masterdr = gridMasterView.GetFocusedDataRow();
                if (gridMasterView.GetFocusedRow() != null)
                {
                    
                  
                    if (Masterdr["PricePerPack"] != DBNull.Value)
                    {
                        Masterdr.ClearErrors();
                        if (Convert.ToDouble(Masterdr["PricePerPack"]) < 0)
                        {
                            Masterdr.SetColumnError("PricePerPack","Negative value is not allowed");
                            Masterdr["PricePerPack"] = DBNull.Value;
                            return;
                        }

                        Masterdr["TotalReceived"] = Convert.ToDouble(Masterdr["NoOfPack"]) * Convert.ToDouble(Masterdr["PricePerPack"]);
                        NewUnitCost = Math.Round(Convert.ToDouble(Masterdr["PricePerPack"]),2);
                        ReceiveDocIDs = Masterdr["ReceiveDocIDs"].ToString();
                        Margin = Masterdr["Margin"] != DBNull.Value ? Math.Round(Convert.ToDouble(Masterdr["Margin"])/100, 4) : 0;
                        User user = new User();
                        user.LoadByPrimaryKey(CurrentContext.UserId);
                        BLL.ReceiveDoc.SetBegginingBalanceCostByReceiveDocIDs(NewUnitCost,Margin, ReceiveDocIDs, user.ID, "Beginning Inventory");
                        BLL.ReceiveDoc.SetUnitCostByReceivedocIDs(NewUnitCost,ReceiveDocIDs,user.ID,"Beginning Inventory");
                    }
                    else
                    {
                        Masterdr["TotalReceived"] = DBNull.Value;
                    }
                }
                
              
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            HCMIS.Desktop.Reports.BeginningBalanceCostingReport xreport = new HCMIS.Desktop.Reports.BeginningBalanceCostingReport();
            xreport.DataSource = gridMasterView.DataSource;
            xreport.ShowPreview();
            // +"/nWareHouse:" + lkAccount.
        }

        private void txtFilter_EditValueChanged(object sender, EventArgs e)
        {
            gridMasterView.ActiveFilterString = "FullItemName like '" + txtFilter.EditValue + "%'";
        }

        private void btnConfirmAll_Click(object sender, EventArgs e)
        {
            if (lkWarehouse.EditValue != null && lkAccount.EditValue != null &&
                XtraMessageBox.Show(String.Format("Are you sure you want to  Confirm?"), "Are you sure...",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int StoreID = Convert.ToInt32(lkAccount.EditValue);
                int WarehouseID = Convert.ToInt32(lkWarehouse.EditValue);
                ReceiveDocConfirmation receiveDocConfirmation = new ReceiveDocConfirmation();
                string ReceiveDocs = "";
                foreach (DataRowView drv in (gridMain.DataSource as DataView))
                {
                    ReceiveDocs = ReceiveDocs != ""
                                      ? ReceiveDocs + ',' + drv["ReceiveDocIDs"].ToString()
                                      : ReceiveDocs + drv["ReceiveDocIDs"].ToString();

                }
                receiveDocConfirmation.ChangeStatusByAccountReceiveDocs(ReceiveDocs,
                                                                        ReceiptConfirmationStatus.Constants.
                                                                            GRNF_PRINTED);
                XtraMessageBox.Show("Price has been successfully confirmed", "Success...", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                lkWarehouse_EditValueChanged(null, null);

            }
        }

        private void repIsConfirmed_CheckedChanged(object sender, EventArgs e)
        {
            DataRow Masterdr = gridMasterView.GetFocusedDataRow();
            Masterdr["IsConfirmed"] =(sender as CheckEdit).Checked;
            bool IsConfirmed = Convert.ToBoolean(Masterdr["IsConfirmed"]);
            if(XtraMessageBox.Show(String.Format("Are you sure you want to {0}",IsConfirmed?"Confirm":"UnConfirm"),"Are you sure...",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ReceiveDocConfirmation  receiveDocConfirmation = new ReceiveDocConfirmation();
                string ReceiveDocs = Masterdr["ReceiveDocIds"].ToString();
                receiveDocConfirmation.ChangeStatusByAccountReceiveDocs(ReceiveDocs,IsConfirmed?ReceiptConfirmationStatus.Constants.GRNF_PRINTED:ReceiptConfirmationStatus.Constants.RECEIVE_QUANTITY_CONFIRMED);
            }
            

        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            //dxCostingValidation.RemoveControlError(lkPeriod);
            if (!dxCostingValidation.Validate()) return;   
         if (lkWarehouse.EditValue != null && lkAccount.EditValue != null && XtraMessageBox.Show(String.Format("Are you sure you want to Approve All Items, Once Approved the item will be available for release"), "Are you sure...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
         {
             try
             {

             ReceiveDocConfirmation receiveDocConfirmation = new ReceiveDocConfirmation();
             string receiveDocs = "";
             string rdPendingAverages = "";
             var ledgerService = new LedgerService();
             DataView dataView = (gridMain.DataSource as DataView);
             dataView.RowFilter = "PricePerPack <>0 and isConfirmed = 1";
             foreach (DataRowView drv in dataView)
             {
                 var costElement = new CostElement
                                       {
                                           ItemID = Convert.ToInt32(drv["ItemID"]),
                                           ItemUnitID = Convert.ToInt32(drv["UnitID"]),
                                           ManufacturerID = Convert.ToInt32(drv["ManufacturerID"]),
                                           MovingAverageID = Convert.ToInt32(drv["MovingAverageID"])
                                       };

                 var ledgerObject = ledgerService.GetLedger(costElement.ItemID, costElement.ItemUnitID,
                                                            costElement.ManufacturerID, costElement.MovingAverageID);

                 costElement.UnitCost = Math.Round(Convert.ToDouble(ledgerObject.UnitCost),
                                                   BLL.Settings.NoOfDigitsAfterTheDecimalPoint,
                                                   MidpointRounding.AwayFromZero);
                 costElement.AverageCost = Math.Round(Convert.ToDouble(drv["PricePerPack"]),
                                                      BLL.Settings.NoOfDigitsAfterTheDecimalPoint,
                                                      MidpointRounding.AwayFromZero);
                 costElement.Margin = Convert.ToDouble(drv["Margin"])/100;
                 costElement.SellingPrice = costElement.AverageCost*(1 + costElement.Margin);
                 var isSound = drv["Remark"].Equals("Sound");
                 if ((Math.Abs(costElement.UnitCost - costElement.AverageCost) == 0) || !isSound)
                 {

                     receiveDocs = receiveDocs != ""
                                       ? receiveDocs + ',' + drv["ReceiveDocIDs"].ToString()
                                       : receiveDocs + drv["ReceiveDocIDs"].ToString();
                 }
                 else if (ReceiveDoc.GetSoundStock(costElement) > 0)
                 {
                     rdPendingAverages = rdPendingAverages != ""
                                             ? rdPendingAverages + ',' + drv["ReceiveDocIDs"].ToString()
                                             : rdPendingAverages + drv["ReceiveDocIDs"].ToString();

                 }
                 else 
                 {

                     IJournalService journal = new JournalService();
                     journal.StartRecordingSession();
                     costElement.SavePrice(CurrentContext.UserId, "", journal, ChangeMode.BeginningBalance);
                     journal.CommitRecordingSession();

                     journal.StartRecordingSession();
                     costElement.ConfirmPrice(CurrentContext.UserId, "", journal, ChangeMode.BeginningBalance);
                     journal.CommitRecordingSession();

                     receiveDocs = receiveDocs != ""
                                       ? receiveDocs + ',' + drv["ReceiveDocIDs"].ToString()
                                       : receiveDocs + drv["ReceiveDocIDs"].ToString();
                 }


             }

             receiveDocConfirmation.ChangeStatusByAccountReceiveDocs(receiveDocs,
                                                                     ReceiptConfirmationStatus.Constants.GRV_PRINTED,
                                                                     ReceiptConfirmationStatus.Constants.GRNF_PRINTED);
             receiveDocConfirmation.ChangeStatusByAccountReceiveDocs(rdPendingAverages,
                                                                     ReceiptConfirmationStatus.Constants.
                                                                         PRICE_CALCULATED,
                                                                     ReceiptConfirmationStatus.Constants.GRNF_PRINTED);
             XtraMessageBox.Show("Price has been successfully confirmed", "Success...", MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
             }
             catch (Exception exception)
             {
                 XtraMessageBox.Show(exception.Message, "Success...", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                 throw;
             }
                      lkWarehouse_EditValueChanged(null, null);
             }
        }

      
        private void btnShortageOverage_Click(object sender, EventArgs e)
        {
            if (lkPeriod.EditValue != null && lkWarehouse.EditValue != null)
            {
                var periodIds = lkPeriod.EditValue.ToString();
                var xreport = new Desktop.Reports.InventoryOverageShortageReport(CurrentContext.LoggedInUserName);
                xreport.DataSource = Inventory.GetOverageShortageReport(Convert.ToInt32(lkAccount.EditValue), Convert.ToInt32(lkWarehouse.EditValue), periodIds);

                var dtDate = new DateTimePickerEx();
                dtDate.Value = DateTimeHelper.ServerDateTime;
                xreport.Date.Text = dtDate.Text;
                xreport.ShowPreview();
            }
        }

        private void gridMasterView_DoubleClick(object sender, EventArgs e)
        {
           
            if (gridMasterView.GetFocusedRow() != null)
            {
                DataRow drv = gridMasterView.GetFocusedDataRow();
                if (Convert.ToBoolean(drv["pendingAverage"]))
                {
                    CostElement costElement = new CostElement (Convert.ToInt32(drv["ItemID"]),Convert.ToInt32(drv["MovingAverageID"]),Convert.ToInt32(drv["ManufacturerID"]),Convert.ToInt32(drv["UnitID"]));
                    costElement.Qty = Convert.ToDouble(drv["NoOfPack"]);
                    costElement.UnitCost = Math.Round(Convert.ToDouble(drv["PricePerPack"]),
                                                      BLL.Settings.NoOfDigitsAfterTheDecimalPoint,
                                                      MidpointRounding.AwayFromZero);
                     
                    costElement.Margin = Convert.ToDouble(drv["Margin"])/100;
                    MovingAverage movingAverage = new MovingAverage(costElement, drv["ReceiveDocIDs"].ToString());
                    movingAverage.ShowDialog(this);
                    lkWarehouse_EditValueChanged(null, null);
                }
            }
        }

        private void gridMasterView_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
        }

        private void btnShortageOverageAggregate_Click_1(object sender, EventArgs e)
        {
                if (lkPeriod.EditValue != null && lkWarehouse.EditValue != null)
                {
                    var periodIds = lkPeriod.EditValue.ToString();
                    var xreport = new Desktop.Reports.InventoryOverageShortageReport(CurrentContext.LoggedInUserName);
                    xreport.DataSource = Inventory.GetOverageShortageAggregateReport(Convert.ToInt32(lkAccount.EditValue), Convert.ToInt32(lkWarehouse.EditValue), periodIds);

                    var dtDate = new DateTimePickerEx();
                    dtDate.Value = DateTimeHelper.ServerDateTime;
                    xreport.Date.Text = dtDate.Text;
                    xreport.ShowPreview();
                }
        }
        
    }
}