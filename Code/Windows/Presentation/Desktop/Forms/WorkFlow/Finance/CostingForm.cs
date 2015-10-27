using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using BLL;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using HCMIS.Desktop.Helpers;
using HCMIS.Desktop.ViewHelpers;
using HCMIS.Helpers;
using HCMIS.Desktop.Modals;
using HCMIS.Desktop.Forms.Modals.Finance;
using DevExpress.XtraLayout;
using System.IO;

namespace HCMIS.Desktop.Forms.WorkFlow
{
    [FormIdentifier("CM-CM-UC-FR", "Cost / Margin", "")]
    public partial class CostingForm : XtraForm
    {
        
        private CostCalculator GRV;
        LayoutControlGroup selectTab;
        int ReceiptID;
        string PONumber;
        
        
        #region Initialization and Mode Settings

       
        public CostingForm()
        {
            InitializeComponent();
        }

        private void PutAwayListsLoad(object sender, EventArgs e)
        {
            SetPermission();
            lkAccount.SetupActivityEditor().SetDefaultActivity();
 
            LoadGRVPendingCostingByUser();
            ResetForm();
            tabContralGRVDetail.SelectedTabPage = grpTabInvoiceValue;
            
            if(BLL.Settings.IsCenter)
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
                btnSave.Enabled = this.HasPermission("Save");
                btnReturn.Enabled = this.HasPermission("Return");
            }
        }


       
        private void LoadGRVPendingCostingByUser()
        {
            gridGRVs.DataSource = BLL.Receipt.GetListOfGRVByUserIDForCosting(CurrentContext.UserId);
        }
        
        #endregion
        
        #region On Selection of GRV
       
        private void gridGRVs_Click(object sender, EventArgs e)
        {
            gridGRVs_MouseClick(null, null);
        }
        
        private void gridGRVs_MouseClick(object sender, MouseEventArgs e)
        {

            DataRow SelectGRV = gridGRVsView.GetFocusedDataRow();
            if (SelectGRV != null)
            {
                ReceiptID = Convert.ToInt32(SelectGRV["ReceiptID"]);
                PONumber = Convert.ToString(SelectGRV["PONumber"]);
                LoadSelectedGRVDetailForInvoiceEntry(ReceiptID);
                BLL.Receipt receipt = new BLL.Receipt();
                string s = "";

                int length = ((string) SelectGRV["InvoiceNumber"]).Length;
                headerSection.Text = "Invoice No: " + (string)SelectGRV["InvoiceNumber"] + s.PadRight(180-length) + "GRNF No: " + (string)SelectGRV["RefNo"].ToString();

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


                lblConfirmedBy.Text = SelectGRV["ConfirmedBy"] == DBNull.Value ? "-" : (string)SelectGRV["ConfirmedBy"];

               
                lblConfirmedDate.Text = SelectGRV["ConfirmedTime"] != DBNull.Value ? Convert.ToDateTime(SelectGRV["ConfirmedTime"]).ToShortDateString() : "-";

                lblReceivedBy.Text = (string)SelectGRV["ReceivedBy"];
                lblRecieptDate.Text = ((DateTime)SelectGRV["ReceivedTime"]).ToShortDateString();
                lblInsurance.Text = SelectGRV["InsuranceNumber"] == DBNull.Value ? "" : (string)SelectGRV["InsuranceNumber"];
                //to handle STVNumber entry
                receipt.LoadByPrimaryKey(ReceiptID);
                NoSelection.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                Selection.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutSTVNo.Enabled = true;
                if (receipt.ReceiptTypeID == ReceiptType.CONSTANTS.DELIVERY_NOTE)
                {
                    var newInvoiceNo = receipt.GetNewInvoiceNoForConvertedDeliveryNote();
                    txtSTVNo.EditValue = newInvoiceNo != string.Empty ? newInvoiceNo : string.Empty;
                    layoutSTVNo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layoutSTVNo.Enabled = false;
                }
                else
                {
                    layoutSTVNo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
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
            lblSubTotal.Text = GRV.SubTotal.ToString("C");
            txtInsurance.EditValue = GRV.Insurance;
            txtOtherExpense.EditValue = GRV.OtherExpense;
            txtGrandTotal.EditValue = GRV.GrandTotal;
            lblGrandTotal.Text = GRV.GrandTotal.ToString("C");
        }

        private void gridInvoiceDetailView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e != null && e.Column.FieldName == "InvoiceCost")
            {
                DataRow drv = gridInvoiceDetailView.GetFocusedDataRow();
                // receipt.SaveFOBForEachReceiveDoc();

                var receipt = new BLL.Receipt(Convert.ToInt32(drv["ReceiptID"]));
                var receiptInvoice = new ReceiptInvoice(receipt.ReceiptInvoiceID);
                var po = new BLL.PO(receiptInvoice.POID);

                if (po.IsElectronic)
                {
                    var originalInvoiceCost = Convert.ToDecimal(drv["OriginalInvoiceCost"]);
                    var newInvoiceCost = Convert.ToDecimal(drv["InvoiceCost"]);
                    if (newInvoiceCost != originalInvoiceCost)
                    {
                        drv["InvoiceCost"] = originalInvoiceCost;
                        XtraMessageBox.Show("You are trying to change the Invoice Cost set by Center. Please enter the correct cost!","Invoice Cost Not Similar",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }
                }
                else if (drv["InvoiceCost"] != DBNull.Value)
                {
                    PricePerPackPage PricingForm = new PricePerPackPage(ReceiptID, Convert.ToInt32(drv["ItemID"]),
                        Convert.ToInt32(drv["ItemUnitID"]), Convert.ToInt32(drv["ManufacturerID"]),
                        Convert.ToInt32(drv["ActivityID"]), Convert.ToDouble(drv["InvoiceCost"]));
                    PricingForm.ShowDialog(this);
                    LoadSelectedGRVDetailForInvoiceEntry(ReceiptID);
                }

            }
            else if (e != null && e.Column.FieldName == "Margin")
            {
                DataRow drv = gridInvoiceDetailView.GetFocusedDataRow();
                // receipt.SaveFOBForEachReceiveDoc();
                var receipt = new BLL.Receipt(Convert.ToInt32(drv["ReceiptID"]));
                var receiptInvoice = new ReceiptInvoice(receipt.ReceiptInvoiceID);
                var po = new BLL.PO(receiptInvoice.POID);
                var item = new Item();
                item.LoadByPrimaryKey(Convert.ToInt32(drv["ItemID"]));

                if (po.IsElectronic && !item.IsVariableMargin)
                {
                    var originalMargin = Convert.ToDecimal(drv["OriginalMargin"]);
                    var newMargin = Convert.ToDecimal(drv["Margin"]);
                    if (newMargin != originalMargin)
                    {
                        drv["Margin"] = originalMargin;
                        XtraMessageBox.Show("You are trying to change the Margin set by Center. Please enter the correct Margin!", "Margin Not Similar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                else if (drv["Margin"] != DBNull.Value)
                {
                    MarginPage MarginForm = new MarginPage(ReceiptID, Convert.ToInt32(drv["ItemID"]), Convert.ToInt32(drv["ItemUnitID"]), Convert.ToInt32(drv["ManufacturerID"]), Convert.ToInt32(drv["ActivityID"]), Convert.ToDouble(drv["Margin"]));
                    MarginForm.ShowDialog(this);
                    LoadSelectedGRVDetailForInvoiceEntry(ReceiptID);
                }
         
               
            }
        }

        private void btnSTV_Click(object sender, EventArgs e)
        {
            BLL.Receipt receipt = new BLL.Receipt();
            receipt.LoadByPrimaryKey(ReceiptID);
            receipt.STVOrInvoiceNo = txtSTVNo.EditValue.ToString();
            receipt.Save();
            ReceiptInvoice invoice = new ReceiptInvoice();
            invoice.LoadByPrimaryKey(receipt.ReceiptInvoiceID);
            invoice.STVOrInvoiceNo = txtSTVNo.EditValue.ToString();
            invoice.Save();
            this.LogActivity("Set-New-STV-No", ReceiptID);
            XtraMessageBox.Show("STV Number has been saved");
        }

        private void txtInsurance_EditValueChanged(object sender, EventArgs e)
        {
            GRV.Insurance = Convert.ToDouble(txtInsurance.EditValue);
            GRV.OtherExpense = Convert.ToDouble(txtOtherExpense.EditValue);
            txtGrandTotal.EditValue =
                GRV.GrandTotal = GRV.Insurance + GRV.OtherExpense + GRV.SubTotal;
            lblGrandTotal.Text = GRV.GrandTotal.ToString("C");

        }

        private void txtOtherExpense_EditValueChanged(object sender, EventArgs e)
        {
            GRV.Insurance = Convert.ToDouble(txtInsurance.EditValue);
            GRV.OtherExpense = Convert.ToDouble(txtOtherExpense.EditValue);
            txtGrandTotal.EditValue =
                GRV.GrandTotal = GRV.Insurance + GRV.OtherExpense + GRV.SubTotal;
            lblGrandTotal.Text = GRV.GrandTotal.ToString("C");
        }
        #endregion

        #region Step 2 Unit Cost
        
        private void LoadSelectedGRVDetailForUnitCostCalculation(int ReceiptID)
        { 
                  
            //This Might Be taking time to load
            DataRow dr = GRV.IsItemBeingPricedElsewhere();
            if (dr != null)
            {
                MessageBox.Show(string.Format(
@"The Item {0} - with Unit: {1} - and Manufacturer: {2} is {3}.
Please finalize the receive process For {4} under the Activity {5} before continuing"
                                    , dr["FullItemName"], dr["ItemUnitName"], dr["ManufacturerName"], dr["Description"], dr["GRVNo"], dr["ActivityFullName"]
                                    )
                               , string.Format(@"Pending Receipt()...{0}", dr["ReceiptID"].ToString()), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            selectTab = grpTabUnitCost;
            FocusOnSelectedTab();

            GRV.CalculateCostCoefficient();
            gridCostBuild.DataSource = GRV.GetCostBuildUp();

            //Display Correct Tab
        
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
            gridPreviousBalance.DataSource = BLL.Receipt.GetPreviousStockforCostAnalysisPrintout(ReceiptID);
        }
        #endregion

        #region Step 4 Final Result

        private void LoadSelectedGRVDetailForFinalization()
        {
            //Display Correct Tab  
            if (!GRV.CalculateFinalCost())
            {
                    XtraMessageBox.Show("Some Items On the GRV are waiting to be Average,you cannot continue without average them","Averaging Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            selectTab = grpTabFinalize;
            FocusOnSelectedTab();
        
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
            bool canproceed = (gridInvoiceDetailView.DataSource as DataView).Cast<DataRowView>().All(rows => rows["InvoiceCost"]!= DBNull.Value && Convert.ToDecimal(rows["InvoiceCost"]) != 0);

 
            if (canproceed)
            {

                NextTab();
                FocusOnSelectedTab();
            }
            else
            {
                XtraMessageBox.Show("Please provide invoice Cost for all items", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }

        private void CommitUnitCostForElectronicDeliveryNotes()
        {
            var dtInvoiceDetail = gridInvoiceDetail.DataSource as DataTable;
            if (dtInvoiceDetail != null)
                foreach (var pricingForm in from DataRow dr in dtInvoiceDetail.Rows
                    let receipt = new BLL.Receipt(Convert.ToInt32(dr["ReceiptID"]))
                    let po = receipt.ReceiptInvoice.PO
                    where dr["InvoiceCost"] != DBNull.Value
                    select new PricePerPackPage(ReceiptID, Convert.ToInt32(dr["ItemID"]),
                        Convert.ToInt32(dr["ItemUnitID"]), Convert.ToInt32(dr["ManufacturerID"]),
                        Convert.ToInt32(dr["ActivityID"]), Convert.ToDouble(dr["InvoiceCost"])))
                {
                    pricingForm.ShowDialog(this);
                }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            PreviousTab();
            FocusOnSelectedTab();
        }

        private void NextTab()
        {
            if (selectTab == grpTabInvoiceValue)
            {
                var receipt = new BLL.Receipt(ReceiptID);
                if (receipt.ReceiptTypeID == ReceiptType.CONSTANTS.DELIVERY_NOTE
                    && receipt.ReceiptInvoice.PO.IsElectronic)
                    CommitUnitCostForElectronicDeliveryNotes();

                LoadSelectedGRVDetailForUnitCostCalculation(ReceiptID);
            }
            else if (selectTab == grpTabUnitCost)
                LoadSelectedGRVDetailForMovingAverage(ReceiptID);
            else
                LoadSelectedGRVDetailForFinalization();
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
            NoSelection.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            Selection.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        public Boolean SetFinalCost()
        {
            foreach (DataRowView drv in gridFinalView.DataSource as DataView)
            {

                double NewUnitCost, NewSellingPrice;
                NewUnitCost = Math.Round(Convert.ToDouble(drv["AverageCost"]), BLL.Settings.NoOfDigitsAfterTheDecimalPoint);
                NewSellingPrice = Math.Round(Convert.ToDouble(drv["SellingPrice"]), BLL.Settings.NoOfDigitsAfterTheDecimalPoint);
                SellingPricePage sellingPriceForm = new SellingPricePage(ReceiptID, Convert.ToInt32(drv["ItemID"]), Convert.ToInt32(drv["ManufacturerID"]), Convert.ToInt32(drv["ItemUnitID"]), Convert.ToInt32(drv["MovingAverageID"]), NewUnitCost, NewSellingPrice);
                if (sellingPriceForm.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
                {
                    return false;
                }
            }

            return true;
        }

        
        private void btnSave_Click(object sender, EventArgs e)
        {
            GRV.SaveInsurance();
            GRV.SaveCostCoefficientAndTotalValue(CurrentContext.UserId);
           //ToDo: Remove this When it is safe and Ready for deployement.
            GRV.RecordAverageCostAndSellingPrice(CurrentContext.UserId);
            print();
            BLL.ReceiveDoc recDoc = new ReceiveDoc();
            recDoc.LoadByReceiptID(ReceiptID);
            BLL.Receipt receiptStatus = new BLL.Receipt();
            if (!BLL.Settings.UseReceiveCostConfirmation && PONumber.StartsWith("S2S-"))
            {
                if (SetFinalCost())
                {  recDoc.ConfirmGRVPrinted(CurrentContext.UserId);
                
                receiptStatus.LoadByPrimaryKey(ReceiptID);
                receiptStatus.ChangeStatus(ReceiptConfirmationStatus.Constants.GRV_PRINTED, null, this.GetFormIdentifier(), CurrentContext.UserId, "StoreToStore Confirmed");
                }     
                
            }
            else if (BLL.Settings.UseReceiveCostConfirmation)
            {
                recDoc.SetPrice(CurrentContext.UserId);
                receiptStatus.LoadByPrimaryKey(ReceiptID);
                receiptStatus.ChangeStatus(ReceiptConfirmationStatus.Constants.PRICE_CALCULATED, null,
                                           this.GetFormIdentifier(), CurrentContext.UserId, "Price Set");
            }
            else
            {   recDoc.ConfirmPrice(CurrentContext.UserId);
                
                receiptStatus.LoadByPrimaryKey(ReceiptID);
                receiptStatus.ChangeStatus(ReceiptConfirmationStatus.Constants.PRICE_CONFIRMED, null, this.GetFormIdentifier(), CurrentContext.UserId, "Price Set");
            }
        
            XtraMessageBox.Show("Received Cost and Margin Set successfully!", "Success", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            
            PutAwayListsLoad(null, null);
            this.LogActivity("Print-Cost-Analysis", ReceiptID);
        }
        private void print()
        {


            DataRow dr = gridGRVsView.GetFocusedDataRow();
            String GRNString = dr["RefNo"].ToString();

            BLL.Receipt receipt = new BLL.Receipt(ReceiptID);


            HCMIS.Desktop.Reports.PreviousCostPrintout xReportCostBuildUp =
                new HCMIS.Desktop.Reports.PreviousCostPrintout();
            xReportCostBuildUp.DataSource = BLL.Receipt.GetPreviousStockforCostAnalysisPrintout(ReceiptID);

            HCMIS.Desktop.Reports.CostAnalysisSubReport xReportCostAnalysis =
                new HCMIS.Desktop.Reports.CostAnalysisSubReport();
            xReportCostAnalysis.DataSource = GRV.CostAnalysis(GRNString);

            HCMIS.Desktop.Reports.CostCalculationPrintout xReportCostCalculationPrintOut =
                new HCMIS.Desktop.Reports.CostCalculationPrintout();
            xReportCostCalculationPrintOut.DataSource = GRV.GRVSoundDetail;

            HCMIS.Desktop.Reports.CostReport xReportCostReport = new HCMIS.Desktop.Reports.CostReport();
            xReportCostReport.DataSource = receipt.CostAnalysis(GRNString);
            xReportCostReport.xrDate.Text = EthiopianDate.EthiopianDate.GregorianToEthiopian(BLL.DateTimeHelper.ServerDateTime);
            xReportCostReport.xrCostedBy.Text = CurrentContext.LoggedInUserName;
            xReportCostReport.xrWarehouse.Text = receipt.GetWarehouse();
            xReportCostReport.subReportCostCalculation.ReportSource = xReportCostCalculationPrintOut;
            xReportCostReport.xrSubreportCostBuildup.ReportSource = xReportCostBuildUp;
            xReportCostReport.xrSubreportCostAnalysis.ReportSource = xReportCostAnalysis;
            xReportCostReport.ShowPrintStatusDialog = true;
            xReportCostReport.CreateDocument();
            xReportCostReport.PrintingSystem.Document.AutoFitToPagesWidth = 1;
            xReportCostReport.ShowPreviewDialog();
            // LOG Cost Analysis printout in PDF Log
            MemoryStream stream = new MemoryStream();
            xReportCostReport.ExportToPdf(stream);
            HCMIS.Core.Distribution.Services.PrintLogService.SavePrintLogNoWait(stream, "CostAnalysis", true, ReceiptID,
                                                                                CurrentContext.UserId,
                                                                                BLL.DateTimeHelper.ServerDateTime);




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
                recDoc.SetStatusAsReceived(null);
                BLL.Receipt receiptStatus = new BLL.Receipt();
                receiptStatus.LoadByPrimaryKey(ReceiptID);
                receiptStatus.ChangeStatus(ReceiptConfirmationStatus.Constants.RECEIVE_ENTERED, null, this.GetFormIdentifier(), CurrentContext.UserId, "Return For Quantity Editing");
          
                transaction.CommitTransaction();
                this.LogActivity("Return-Receipt-To-Quantity-Confirmation", ReceiptID);
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
     
        #endregion

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            gridGRVsView.ActiveFilterString = string.Format("InvoiceNumber like '%{0}%' AND StoreID = {1}", textEdit1.Text, lkAccount.EditValue);
        }

     


       

    }
}