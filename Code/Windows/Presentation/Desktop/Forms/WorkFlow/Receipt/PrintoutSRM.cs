using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using BLL;
using BLL.Finance;
using CalendarLib;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using HCMIS.Core.Finance.CostTier;
using HCMIS.Desktop.Helpers;
using HCMIS.Helpers;
using HCMIS.Desktop.ViewHelpers;
using HCMIS.Specification.Finance.CostTier;
using MyGeneration.dOOdads;
using HCMIS.Desktop.Forms.Modals.Finance;
using ReceiptConfirmationPrintout = BLL.ReceiptConfirmationPrintout;

namespace HCMIS.Desktop.Forms.WorkFlow
{
    [FormIdentifier("AR-SR-SR-VW", "SRM Printout", "")]
    public partial class PrintoutSRM : XtraForm
    {

        private DataSet ds = new DataSet();
        ICostCalculator GRV;
        private int ReceiptID;

        public PrintoutSRM()
        {
            InitializeComponent();
        }


        private void PutAwayListsLoad(object sender, EventArgs e)
        {
            SetUserPermissions();
            //Lookup For Accounts
            lkAccount.SetupActivityEditor().SetDefaultActivity();
            BindFormContents();
         
            gridReceiveView_FocusedRowChanged(null, null);
        }
         private void SetUserPermissions()
        {
            if (BLL.Settings.UseNewUserManagement)
            {
                btnPrint.Enabled = this.HasPermission("Print");
                btnConfirm.Enabled = this.HasPermission("Confirm");
                btnReturn.Enabled = this.HasPermission("Return");
            }
        }

        private void BindFormContents()
        {
            var pl = new PalletLocation();
            lkPalletLocations.DataSource = PalletLocation.GetAll();
            gridReceives.DataSource = pl.GetReceivesForGRVPrinting(CurrentContext.UserId, 2);
         

        }

        #region

        private void gridReceiveView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            // Bind the detail grid
            var pl = new PalletLocation();
            try
            {
                String reference = gridReceiveView.GetFocusedDataRow()["RefNo"].ToString();
               
                ReceiptID = Convert.ToInt32(gridReceiveView.GetFocusedDataRow()["ReceiptID"]);
                BLL.Receipt receiptDoc = new BLL.Receipt();
                receiptDoc.LoadByPrimaryKey(ReceiptID);
                DataTable GRNFDetail = receiptDoc.GetDetailsForGRNF();
                gridDetails.DataSource = GRNFDetail;
                gridShortage.DataSource = receiptDoc.GetDiscrepancyForGRNF();
                int status = Convert.ToInt32(gridReceiveView.GetFocusedDataRow()["Status"]);


                var receipt = new BLL.Receipt();
                receipt.LoadByPrimaryKey(ReceiptID);
            }

            catch
            {
                gridDetails.DataSource = null;
                gridShortage.DataSource = null;
            }
        }

        private void gridReceiveView_RowClick(object sender, RowClickEventArgs e)
        {
            gridReceiveView_FocusedRowChanged(null, null);
        }

        #endregion

        private void OnQueryPopup(object sender, CancelEventArgs e)
        {
            var pl = new PalletLocation();
            var lke = (LookUpEdit)gridDetailView.ActiveEditor;
            int itemID = Convert.ToInt32(gridDetailView.GetFocusedDataRow()["ItemID"]);
            lke.Properties.DataSource = PalletLocation.GetAllFreeFor(itemID);
        }

        private bool SetSellingPrice(ICostCalculator CostCalculator)
        {

            foreach (CostElement costElement in CostCalculator.CostElements)
            {
                costElement.CheckMovingAverageCost();
                if (costElement.PreviousCostDetials.PreviousStock.Rows.Count > 0)
                {
                    using (SellingPriceValidation pricePerPackPage = new SellingPriceValidation(costElement.PreviousCostDetials))
                    {
                        if (pricePerPackPage.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
                            return false;
                    }
                }
            }
            return true;
        }
        private void OnConfirmClicked(object sender, EventArgs e)
        {
            
                if (BLL.Settings.IsCenter)
                {
                    GRV = new CenterCostCalculator();
                    GRV.LoadGRV(ReceiptID);
                    GRV.CalculateFinalCost();
                }
                else
                {
                    GRV = new CostCalculator();
                    GRV.LoadGRV(ReceiptID);
                    (GRV as CostCalculator).LoadGRVPreviousStock();
                    GRV.CalculateFinalCost();
                }
                if(!SetSellingPrice(GRV))
                {
                    return;
                }

            TransactionMgr transaction = TransactionMgr.ThreadTransactionMgr();
            try
            {
                transaction.BeginTransaction();
                // This is where we set the Price for the previous Stock
                foreach (CostElement costElement in GRV.CostElements)
                {
                    costElement.PreviousCostDetials.Confirm(CurrentContext.UserId);
                }
               
                PrintConfirmation(null);
                try
                {
                    CostingService.ConfirmPriceChange(GRV.CostElements, CurrentContext.UserId, ChangeMode.Recieve, ReceiptID.ToString());
              
                }
                catch (Exception exception)
                {
                    XtraMessageBox.Show(exception.Message);
                    throw exception;
                }
                transaction.CommitTransaction();
                this.LogActivity("Print-SRM", ReceiptID);
            }
            catch (Exception ex)
            {
                transaction.RollbackTransaction();
                XtraMessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Final Cost Settings
        /// </summary>
        /// <returns></returns>
        public Boolean SetFinalCost()
        {
            var GRV = new CostCalculator();
            GRV.LoadGRV(ReceiptID);
            GRV.CalculateFinalCost();
            foreach (DataRowView drv in GRV.GRVSoundDetail.DefaultView)
            {
                double NewUnitCost, NewSellingPrice;
                NewUnitCost = Math.Round(Convert.ToDouble(drv["AverageCost"]),
                                         BLL.Settings.NoOfDigitsAfterTheDecimalPoint);
                NewSellingPrice = Math.Round(Convert.ToDouble(drv["SellingPrice"]),
                                             BLL.Settings.NoOfDigitsAfterTheDecimalPoint);
                var sellingPriceForm = new SellingPricePage(ReceiptID, Convert.ToInt32(drv["ItemID"]),
                                                            Convert.ToInt32(drv["ManufacturerID"]),
                                                            Convert.ToInt32(drv["ItemUnitID"]),
                                                            Convert.ToInt32(drv["AccountID"]), NewUnitCost,
                                                            NewSellingPrice);
                if (sellingPriceForm.ShowDialog(this) == DialogResult.Cancel)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Prints GRV, SRM or Delivery Note
        /// </summary>
        private void PrintConfirmation(int? reprintOfReceiptConfirmationPrintoutID)
        {
            String reference = gridReceiveView.GetFocusedDataRow()["RefNo"].ToString();
            PrintReceiptConfirmation(reference, reprintOfReceiptConfirmationPrintoutID);
        }

        private void PrintReceiptConfirmation(string referenceNumber, int? reprintOfReceiptConfirmationPrintoutID)
        {
            var rc = new ReceiptConfirmationPrintout();
            var srmPrintout = new HCMIS.Desktop.Reports.SRMPrintout(CurrentContext.LoggedInUserName);

            int ReceiptID = Convert.ToInt32(gridReceiveView.GetFocusedDataRow()["ReceiptID"]);
            var receiveDoc = new ReceiveDoc();
            receiveDoc.LoadByReceiptID(ReceiptID);
            ReceiptConfirmationPrintout.GetGRNFNo(ReceiptID);
            srmPrintout.BranchName.Text = GeneralInfo.Current.HospitalName;
            rc.PrepareDataForPrintout(ReceiptID, CurrentContext.UserId, false, 3, null,
                                                  reprintOfReceiptConfirmationPrintoutID,FiscalYear.Current);
            srmPrintout.DataSource = rc.DefaultView.ToTable();

            var rUnit = new Institution();
            var idoc = new IssueDoc();
            if (!receiveDoc.IsColumnNull("ReturnedFromIssueDocID"))
            {
                idoc.LoadByPrimaryKey(receiveDoc.ReturnedFromIssueDocID);
                rUnit.LoadByPrimaryKey(idoc.ReceivingUnitID);
            }
            else
            {
                var po = new PO();
                po.LoadByReceiptID(receiveDoc.ReceiptID);
                rUnit.LoadByPrimaryKey(int.Parse(po.RefNo));
            }

            srmPrintout.xrFromValue.Text = rUnit.Name;
            srmPrintout.xrWoredaValue.Text = rUnit.WoredaText;
            srmPrintout.xrRegionValue.Text = rUnit.Region;
            srmPrintout.xrZoneValue.Text = rUnit.ZoneText;


            if (!receiveDoc.IsColumnNull("ReturnedFromIssueDocID"))
            {
                var stvLog = new BLL.Issue();
                stvLog.LoadByPrimaryKey(idoc.STVID);
                
                srmPrintout.xrIssueDateValue.Text = idoc.Date.ToString("M/d/yyyy");
                var activity = new Activity();
                activity.LoadByPrimaryKey(idoc.StoreId);
                 srmPrintout.xrAccountName.Text = activity.FullActivityName;
                var rct = new BLL.Receipt();
                rct.LoadByPrimaryKey(ReceiptID);
                var rctInvoice = new ReceiptInvoice();
                rctInvoice.LoadByPrimaryKey(rct.ReceiptInvoiceID);
                srmPrintout.xrSTVNoValue.Text = rctInvoice.STVOrInvoiceNo;
            }
            else
            {
                var activity = new Activity();
                activity.LoadByPrimaryKey(receiveDoc.StoreID);
                srmPrintout.xrAccountName.Text = activity.FullActivityName; 
                srmPrintout.xrSTVNoValue.Text = receiveDoc.RefNo;
            }

            var dtDate = new DateTimePickerEx();
            dtDate.Value = receiveDoc.EurDate;
            srmPrintout.Date.Text = dtDate.Text;
            if (srmPrintout.PrintDialog() != DialogResult.OK)
            {
                throw new Exception("Print cancelled by user!");
            }


            //Successfully printed

            //Release Product 
            var GRV = new CostCalculator();
            GRV.LoadGRV(ReceiptID);
            GRV.ReleaseForIssue();

            String reference = gridReceiveView.GetFocusedDataRow()["RefNo"].ToString();
            var recDoc = new ReceiveDoc();
            recDoc.LoadByReferenceNo(reference);
            recDoc.ConfirmGRVPrinted(CurrentContext.UserId);
            BLL.Receipt receiptStatus = new BLL.Receipt();
            receiptStatus.LoadByPrimaryKey(ReceiptID);
            receiptStatus.ChangeStatus(ReceiptConfirmationStatus.Constants.GRV_PRINTED, null, this.GetFormIdentifier(), CurrentContext.UserId, "GRV Printed");
            BindFormContents();
        }

        #region

        private void btnPrint_Click(object sender, EventArgs e)
        {
            gridDetails.ShowPrintPreview();
        }

        #endregion

        private void lkAccount_EditValueChanged(object sender, EventArgs e)
        {
            gridReceiveView.ActiveFilterString = String.Format("StoreID = {0}", lkAccount.EditValue);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            ReturnFromGRVPrinting();
        }

        private void ReturnFromGRVPrinting()
        {
            int ReceiptID = Convert.ToInt32(gridReceiveView.GetFocusedDataRow()["ReceiptID"]); var receiveDoc = new ReceiveDoc();
            receiveDoc.LoadByReceiptID(ReceiptID);
            receiveDoc.ConfirmGRNFPrinted(null);
            BLL.Receipt receiptStatus = new BLL.Receipt();
            receiptStatus.LoadByPrimaryKey(ReceiptID);
            receiptStatus.ChangeStatus(ReceiptConfirmationStatus.Constants.PRICE_CALCULATED, null, this.GetFormIdentifier(), CurrentContext.UserId, "Return For Price Change");
            BindFormContents();
            this.LogActivity("Return-SRM-To-Costing", ReceiptID);
        }

        private void gridDetailView_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridDetailView.GetFocusedDataRow();
        }
    }
}
