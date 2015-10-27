using System;
using System.Data;
using BLL;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using HCMIS.Desktop.Helpers;
using HCMIS.Helpers;
using HCMIS.Desktop.Forms.Modals.Finance;
using DevExpress.XtraLayout;
using DevExpress.XtraReports.UI;
using HCMIS.Desktop.ViewHelpers;

namespace HCMIS.Desktop.Forms.WorkFlow
{
    [FormIdentifier("CM-CM-FI-CN","Cost Confirmation","")]
    public partial class CostingConfirmationForm : XtraForm
    {
        
        private CostCalculator GRV;
        LayoutControlGroup selectTab;
        int ReceiptID;
        string PONumber;
        #region Initialization and Mode Settings

       
        public CostingConfirmationForm()
        {
            InitializeComponent();
            

        }

        private void PutAwayListsLoad(object sender, EventArgs e)
        {

            SetPermission();
            lkAccount.SetupActivityEditor().SetDefaultActivity();
            LoadGRVPendingCostingByUser();
            gridGRVsView.ActiveFilterString = string.Format("InvoiceNumber like '%{0}%'", textEdit1.Text);
            if (BLL.Settings.IsCenter)
            {
                XtraMessageBox.Show("This Costing Page is Only Applicable For Hub Costing", "User Management Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Enabled = false;
                return;
            }
        }

        private void SetPermission()
        {
            if (BLL.Settings.UseNewUserManagement)
            {
                btnSave.Enabled = this.HasPermission("Confirm");
                btnReturn.Enabled = this.HasPermission("Return");
            }
        }

       
        private void LoadGRVPendingCostingByUser()
        {
            gridGRVs.DataSource = BLL.Receipt.GetListOfGRVByUserIDForCostConfirmation(CurrentContext.UserId);
        }
        
        #endregion
        
        #region On Selection of GRV
        
        private void gridGRVs_MouseClick(object sender, MouseEventArgs e)
        {

            DataRow SelectGRV = gridGRVsView.GetFocusedDataRow();
            if (SelectGRV != null)
            {
                ReceiptID = Convert.ToInt32(SelectGRV["ReceiptID"]);
                PONumber = Convert.ToString(SelectGRV["PONumber"]);
                LoadSelectedGRVDetailForInvoiceEntry(ReceiptID);
                string s = "";

                HeaderSection.Text = "Invoice No: " + (string)SelectGRV["InvoiceNumber"] + s.PadRight(180) + "GRNF No: " + (string)SelectGRV["RefNo"].ToString();

                lblMode.Text = (string)SelectGRV["Mode"];
                lblAccount.Text = (string)SelectGRV["AccountName"];
                lblSubAccount.Text = (string)SelectGRV["SubAccountName"];
                lblActivity.Text = (string)SelectGRV["ActivityName"];
                lblWarehouse.Text = (string)SelectGRV["WarehouseName"];
                lblCluster.Text = (string)SelectGRV["ClusterName"];
                lblReceiptType.Text = (string)SelectGRV["ReceiveType"];
                lblRecieptStatus.Text = (string)SelectGRV["ReceiveStatus"];
                lblSupplier.Text = (string)SelectGRV["SupplierName"];
                lblOrderNo.Text = (string)SelectGRV["PONumber"];

                var logReceiptStatus = new LogReceiptStatus();
                var dtHistory = logReceiptStatus.GetLogHistory(ReceiptID, "PRC");

                if (dtHistory != null && dtHistory.Count > 0)
                {
                    lblCalculatedBy.Text = (string)dtHistory[0]["FullName"];
                    lblCalculatedDate.Text = ((DateTime)dtHistory[0]["Date"]).ToShortDateString();
                }
                else
                {
                    lblCalculatedDate.Text = lblCalculatedBy.Text = "-";
                }

                lblConfirmedBy.Text = SelectGRV["ConfirmedBy"] == DBNull.Value ? "-" : (string)SelectGRV["ConfirmedBy"];
                DateTime confirmedTime;

                if (DateTime.TryParse(SelectGRV["ConfirmedTime"] == DBNull.Value ? "-" : SelectGRV["ConfirmedTime"].ToString(), out confirmedTime))
                    lblConfirmedDate.Text = confirmedTime.ToShortDateString();
          
                    lblReceivedBy.Text = (string)SelectGRV["ReceivedBy"];
                    lblRecieptDate.Text = ((DateTime)SelectGRV["ReceivedTime"]).ToShortDateString();
                    lblInsurance.Text = SelectGRV["InsuranceNumber"] == DBNull.Value ? "" : (string)SelectGRV["InsuranceNumber"];

            }
            else
            {
                ResetForm();
            }
        }

        #endregion

        #region Step 1 Invoice
     
        private void LoadSelectedGRVDetailForInvoiceEntry(int ReceiptID)
        {
            //Display Correct Tab
            selectTab = grpTabInvoiceValue;
            FocusOnSelectedTab();
           
            // Load The GRV First
            GRV = new CostCalculator();
            GRV.LoadGRV(ReceiptID);
            // Display the GRV Detail for Data Entry(Price Per Pack)
            gridInvoiceDetail.DataSource = GRV.GRVDetail;
            
            //Load Summary
            txtSubTotal.EditValue = GRV.SubTotal;
            txtInsurance.EditValue = GRV.Insurance;
            txtGrandTotal.EditValue = GRV.GrandTotal;
        }

        private void gridInvoiceDetailView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e != null && e.Column.FieldName == "InvoiceCost")
            {
                DataRow drv = gridInvoiceDetailView.GetFocusedDataRow();
                // receipt.SaveFOBForEachReceiveDoc();


                if (drv["InvoiceCost"] != DBNull.Value)
                {
                    PricePerPackPage PricingForm = new PricePerPackPage(ReceiptID, Convert.ToInt32(drv["ItemID"]), Convert.ToInt32(drv["ItemUnitID"]), Convert.ToInt32(drv["ManufacturerID"]), Convert.ToInt32(drv["ActivityID"]), Convert.ToDouble(drv["InvoiceCost"]));
                    PricingForm.ShowDialog(this);
                    LoadSelectedGRVDetailForInvoiceEntry(ReceiptID);
                }

            }
            else if (e != null && e.Column.FieldName == "Margin")
            {
                DataRow drv = gridInvoiceDetailView.GetFocusedDataRow();
                // receipt.SaveFOBForEachReceiveDoc();


                if (drv["Margin"] != DBNull.Value)
                {
                    MarginPage MarginForm = new MarginPage(ReceiptID, Convert.ToInt32(drv["ItemID"]), Convert.ToInt32(drv["ItemUnitID"]), Convert.ToInt32(drv["ManufacturerID"]), Convert.ToInt32(drv["ActivityID"]), Convert.ToDouble(drv["Margin"]));
                    MarginForm.ShowDialog(this);
                    LoadSelectedGRVDetailForInvoiceEntry(ReceiptID);
                }
         
               
            }
        }

        #endregion

        #region Step 2 Unit Cost
        
        private void LoadSelectedGRVDetailForUnitCostCalculation(int ReceiptID)
        {
            // if The Flow is correct Calculate the Cost Coeff and all information on the Previous Tab
             
            gridCostBuild.DataSource = GRV.GetCostBuildUp();

            //Display Correct Tab
            selectTab = grpTabUnitCost;
            FocusOnSelectedTab();

            // Load the GRV First
            GRV = new CostCalculator();
            GRV.LoadGRV(ReceiptID);
            GRV.SuspendFromIssuing();
            gridUnitCost.DataSource = GRV.GRVDetail;
        }

        #endregion

        #region Step 3 Moving Average Cost

        private void LoadSelectedGRVDetailForMovingAverage(int ReceiptID)
        {
            
           //Display Correct Tab
            selectTab = grpTabMovingAverage;
            FocusOnSelectedTab();
            GRV.LoadGRVPreviousStock();
            gridMovingAverage.DataSource = GRV.GRVSoundDetail;
            gridPreviousBalance.DataSource = BLL.Receipt.GetPreviousStockforCostAnalysisPrintout(ReceiptID); ;
        }
        #endregion

        #region Step 4 Final Result

        private void LoadSelectedGRVDetailForFinalization(int ReceiptID)
        {
            //Display Correct Tab
            
            selectTab = grpTabFinalize;
            FocusOnSelectedTab();
            GRV.CalculateFinalCost();
            gridFinal.DataSource = GRV.GRVSoundDetail;
        }

        #endregion

        #region Navigation

        private void FocusOnSelectedTab()
        {
            if (tabContralGRVDetail.SelectedTabPage != selectTab)
                tabContralGRVDetail.SelectedTabPage = selectTab;
            if (selectTab == grpTabFinalize)
            {
                btnNext.Enabled = false;
                btnBack.Enabled = true;
            }
            else if (selectTab == grpTabInvoiceValue)
            {
                btnBack.Enabled = false;
                btnNext.Enabled = true;
            }
            else
            {
                btnBack.Enabled = true;
                btnNext.Enabled = true;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            NextTab();
            FocusOnSelectedTab();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            PreviousTab();
            FocusOnSelectedTab();
        }

        private void NextTab()
        {
            if (selectTab == grpTabInvoiceValue)
                LoadSelectedGRVDetailForUnitCostCalculation(ReceiptID);
            else if (selectTab == grpTabUnitCost)
                LoadSelectedGRVDetailForMovingAverage(ReceiptID);
            else
                LoadSelectedGRVDetailForFinalization(ReceiptID);
        }

        private void PreviousTab()
        {
            if (selectTab == grpTabUnitCost)
                LoadSelectedGRVDetailForInvoiceEntry(ReceiptID);
            else if (selectTab == grpTabMovingAverage)
                LoadSelectedGRVDetailForUnitCostCalculation(ReceiptID);
            else
                LoadSelectedGRVDetailForMovingAverage(ReceiptID);
        }

        private void tabContralGRVDetail_SelectedPageChanged(object sender, LayoutTabPageChangedEventArgs e)
        {
            FocusOnSelectedTab();
        }

        #endregion

        #region Finalize and Reset

        private void ResetForm()
        {

        }

        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            
                BLL.ReceiveDoc recDoc = new ReceiveDoc();
               
                recDoc.LoadByReceiptID(ReceiptID);
                if (PONumber.StartsWith("S2S-")) //for store to store transfer
                {
                    if (SetFinalCost())
                    {
                        recDoc.ConfirmGRVPrinted(CurrentContext.UserId);
                        BLL.Receipt receiptStatus = new BLL.Receipt();
                        receiptStatus.LoadByPrimaryKey(ReceiptID);
                        receiptStatus.ChangeStatus(ReceiptConfirmationStatus.Constants.GRV_PRINTED, null, this.GetFormIdentifier(), CurrentContext.UserId, "Store To Store Confirmed");
          
                    }
                }
                else
                {
                    recDoc.ConfirmPrice(CurrentContext.UserId);
                    BLL.Receipt receiptStatus = new BLL.Receipt();
                    receiptStatus.LoadByPrimaryKey(ReceiptID);
                    receiptStatus.ChangeStatus(ReceiptConfirmationStatus.Constants.PRICE_CONFIRMED, null, this.GetFormIdentifier(), CurrentContext.UserId, "Price Confirmed");
          
                }
               
                this.LogActivity("Confirm-Price", ReceiptID);
                XtraMessageBox.Show("Received Cost and Margin Set successfully!", "Success", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                PutAwayListsLoad(null, null);
            
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            //TODO: finish updating the changed locations
            MyGeneration.dOOdads.TransactionMgr transaction = MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgr();
            if (gridGRVs.DataSource == null)
                return;
            transaction.BeginTransaction();
            try
            {
                PalletLocation pl = new PalletLocation();
                BLL.ReceiveDoc recDoc = new ReceiveDoc();
                recDoc.LoadByReceiptID(ReceiptID);
                recDoc.ConfirmGRNFPrinted(null);
                BLL.Receipt receiptStatus = new BLL.Receipt();
                receiptStatus.LoadByPrimaryKey(ReceiptID);
                receiptStatus.ChangeStatus(ReceiptConfirmationStatus.Constants.GRNF_PRINTED, null, this.GetFormIdentifier(), CurrentContext.UserId, "Return For Price Change");

                transaction.CommitTransaction();
                this.LogActivity("Return-For-Costing", ReceiptID);
                XtraMessageBox.Show("Receipt Returned!", "Success", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                

            }
            catch (Exception exp)
            {
                transaction.RollbackTransaction();
                throw exp;
            }
            PutAwayListsLoad(null, null);
        }

        private void lkAccount_EditValueChanged(object sender, EventArgs e)
        {
            gridGRVsView.ActiveFilterString = String.Format("StoreID = {0}", lkAccount.EditValue);
        }
 
        public Boolean SetFinalCost()
        {
            foreach (DataRowView drv in gridFinalView.DataSource as DataView)
            {
                
                double NewUnitCost, NewSellingPrice;
                NewUnitCost = Math.Round(Convert.ToDouble(drv["AverageCost"]), BLL.Settings.NoOfDigitsAfterTheDecimalPoint);
                NewSellingPrice = Math.Round(Convert.ToDouble(drv["SellingPrice"]), BLL.Settings.NoOfDigitsAfterTheDecimalPoint);
                SellingPricePage sellingPriceForm =  new SellingPricePage(ReceiptID,Convert.ToInt32(drv["ItemID"]), Convert.ToInt32(drv["ManufacturerID"]), Convert.ToInt32(drv["ItemUnitID"]), Convert.ToInt32(drv["MovingAverageID"]),NewUnitCost,NewSellingPrice);
                if (sellingPriceForm.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
                {
                    return false;
                }
            }

            return true;
        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void gridGRVs_Click(object sender, EventArgs e)
        {

        }

        private void textEdit1_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
           
        }

        private void textEdit1_TextChanged(object sender, EventArgs e)
        {
           
        }
      
      
    }
}