using System;
using System.ComponentModel;
using System.Data;
using BLL;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraReports.UI;
using HCMIS.Desktop.Helpers;
using HCMIS.Helpers;
using HCMIS.Desktop.ViewHelpers;
using HCMIS.Desktop.Modals;
using HCMIS.Desktop.Reports;
using MyGeneration.dOOdads;
using ReceiptConfirmationPrintout = BLL.ReceiptConfirmationPrintout;

namespace HCMIS.Desktop.Forms.WorkFlow
{
    [FormIdentifier("RE-CO-GN-CN", "Receipt Confirmation", "")]
    public partial class PrintoutGRNF : XtraForm
    {
        public enum Modes
        {
            QuantityConfirmation = 1
        }

        Modes currentMode;
        DataSet ds = new DataSet();
        int ReceiptID;

        public PrintoutGRNF()
        {
            InitializeComponent();
            currentMode = Modes.QuantityConfirmation;
        }

        private void ReceiptConfirmation_Load(object sender, EventArgs e)
        {
            SetPermission();
            BindFormContents();

        }

        private void SetPermission()
        {
            if (BLL.Settings.UseNewUserManagement)
            {
                if (this.HasPermission("Confirm"))
                {
                    lcConfirm.Visibility = LayoutVisibility.Always;
                }
                if (this.HasPermission("Print"))
                {
                    lcPrint.Visibility = LayoutVisibility.Always;
                }
                if (this.HasPermission("Return"))
                {
                    lcReturnForEdit.Visibility = LayoutVisibility.Always;
                }
                if (this.HasPermission("Re-Print"))
                {
                }
            }
            else
            {
                lcConfirm.Visibility = LayoutVisibility.Always;
                lcPrint.Visibility = LayoutVisibility.Always;
                lcReturnForEdit.Visibility = LayoutVisibility.Always;
            }
        }

        private void BindFormContents()
        {
            if (!BLL.Settings.IsCenter)
            {

                lkAccount.SetupActivityEditor().SetDefaultActivity();
            }
            else
            {
                colLocation.Visible = false;
                layoutAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            //Warehouse 
            lkWarehouse.Properties.DataSource = BLL.Warehouse.GetWarehouseWithCluster(CurrentContext.UserId);

            PalletLocation pl = new PalletLocation();
            lkPalletLocations.DataSource = PalletLocation.GetAll();

            if (currentMode == Modes.QuantityConfirmation)
            {
                gridReceives.DataSource = pl.GetReceivesForQtyConfirmation(CurrentContext.UserId);
                if (CurrentContext.LoggedInUser.UserType == UserType.Constants.STORE)
                {
                    btnConfirm.Enabled = false;
                }
            }

        }

        private void gridReceiveView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            // Bind the detail grid
           PalletLocation pl = new PalletLocation();
            if (e != null && e.PrevFocusedRowHandle < -1)
                return;
            string warehouseName = string.Empty;
            try
            {
                var dr = gridReceiveView.GetFocusedDataRow();
                if (dr == null)
                    return;
                ReceiptID = Convert.ToInt32(dr["ReceiptID"]);
                var receiptDoc = new BLL.Receipt();

                var receipt = new BLL.Receipt();
                receipt.LoadByPrimaryKey(ReceiptID);

                receiptDoc.LoadByPrimaryKey(ReceiptID);
                var GRNFDetail = receiptDoc.GetDetailsForGRNF();
                if (GRNFDetail.Rows.Count > 0)
                {
                    txtOrderNo.EditValue = dr["PONumber"] == DBNull.Value ? "-" : dr["PONumber"];
                    lblPONo.Text =  (dr["PONumber"] == DBNull.Value ? "-" : dr["PONumber"].ToString());

                    lblCluster.Text = dr["ClusterName"] == DBNull.Value ? "-" : dr["ClusterName"].ToString();
                    txtWarehouse.EditValue = lblWarehouse.Text = warehouseName = dr["WarehouseName"] == DBNull.Value ? "-" : dr["WarehouseName"].ToString();
               
                    var receiptInvoice = new ReceiptInvoice(receiptDoc.ReceiptInvoiceID);
                    txtInvoiceNo.EditValue = lblInvoiceNo.Text =  String.IsNullOrEmpty(receiptInvoice.STVOrInvoiceNo) ? "-" : receiptInvoice.STVOrInvoiceNo;
                    txtInsurance.EditValue = lblInsurancePolicy.Text =  String.IsNullOrEmpty(receiptInvoice.InsurancePolicyNo) ? "-" : receiptInvoice.InsurancePolicyNo;
                    txtTransfer.EditValue = lblTransferVoucherNo.Text = String.IsNullOrEmpty(receipt.TransitTransferNo) ? "-" : receipt.TransitTransferNo;
                    txtWayBill.EditValue = lblWayBill.Text = String.IsNullOrEmpty(receiptInvoice.WayBillNo) ? "-" : receiptInvoice.WayBillNo;

                    var activity = new Activity();
                    activity.LoadByPrimaryKey(Convert.ToInt32(dr["StoreID"]));
                    txtActivity.EditValue = activity.FullActivityName;
                  
                    lblActivity.Text = String.IsNullOrEmpty(activity.Name) ? "-" : activity.Name;
                    lblSubAccount.Text = String.IsNullOrEmpty(activity.SubAccountName) ? "-" : activity.SubAccountName;
                    lblAccount.Text = String.IsNullOrEmpty(activity.AccountName) ? "-" : activity.AccountName;
                    lblMode.Text = String.IsNullOrEmpty(activity.ModeName) ? "-" : activity.ModeName;

                    lblReceiveType.Text = dr["ReceiptType"] == DBNull.Value ? "-" : dr["ReceiptType"].ToString();
                    lblReceiveStatus.Text = dr["Status"] == DBNull.Value ? "-" : dr["Status"].ToString();
                    lblDocumentType.Text = dr["DocumentType"] == DBNull.Value ? "-" : dr["DocumentType"].ToString();
                    lblPOType.Text = dr["POType"] == DBNull.Value ? "-" : dr["POType"].ToString();
                    lblPaymentType.Text = dr["PaymentType"] == DBNull.Value ? "-" : dr["PaymentType"].ToString();
                    lblReceiptNo.Text = dr["ReceiptNo"] == DBNull.Value ? "-" : dr["ReceiptNo"].ToString();

                    lblSupplier.Text = dr["Supplier"] == DBNull.Value ? "-" : dr["Supplier"].ToString();

                    var user = new User();
                    user.LoadByPrimaryKey(receiptDoc.SavedByUserID);
                    lblReceivedBy.Text = String.IsNullOrEmpty(user.FullName) ? "-" : user.FullName;

                    var receiveDoc = new ReceiveDoc();
                    receiveDoc.LoadByReceiptID(ReceiptID);
                    lblReceivedDate.Text = receiptDoc.IsColumnNull("DateOfEntry") ? "-" :receiveDoc.EurDate.ToShortDateString();
                    lblConfirmedDate.Text = receiveDoc.IsColumnNull("ConfirmedDateTime") ? "-" : receiveDoc.ConfirmedDateTime.ToShortDateString();

                    if (!receiveDoc.IsColumnNull("ConfirmedByUserID"))
                    {
                        user.LoadByPrimaryKey(receiveDoc.ConfirmedByUserID);
                        lblConfirmedBy.Text = String.IsNullOrEmpty(user.FullName) ? "-" : user.FullName;
                    }
                    else
                    {
                        lblConfirmedBy.Text = "-";
                    }
                    var space = string.Empty;
                    var length = warehouseName.Length;

                    HeaderGroup.Text = warehouseName + space.PadRight(180 - length) + "Invoice No: " + receiptInvoice.STVOrInvoiceNo;
                   
                }
                
                gridDetails.DataSource = GRNFDetail;
                gridShortage.DataSource = receiptDoc.GetDiscrepancyForGRNF();
            }

            catch
            {
                gridDetails.DataSource = null;
            }
        }

        private void OnQueryPopup(object sender, CancelEventArgs e)
        {
            PalletLocation pl = new PalletLocation();
            LookUpEdit lke = (LookUpEdit)gridDetailView.ActiveEditor;
            int itemID = Convert.ToInt32(gridDetailView.GetFocusedDataRow()["ItemID"]);
            lke.Properties.DataSource = PalletLocation.GetAllFreeFor(itemID);
        }

        private void OnConfirmClicked(object sender, EventArgs e)
        {
            if (currentMode == Modes.QuantityConfirmation)
            {
                if (XtraMessageBox.Show("Are you sure you would like to confirm the GRNF and pass it on to the next stage?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }

                ConfirmQuantityAndLocation();
            }


        }



        /// <summary>
        /// Prints GRV, SRM or Delivery Note
        /// </summary>

        private void PrintConfirmation()
        {
            String reference = gridReceiveView.GetFocusedDataRow()["RefNo"].ToString();
            int ReceiptID = Convert.ToInt32(gridReceiveView.GetFocusedDataRow()["ReceiptID"]);
            PrintReceiptConfirmation(ReceiptID);
        }



        private void ConfirmQuantityAndLocation()
        {
            MyGeneration.dOOdads.TransactionMgr transaction = MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgr();
            transaction.BeginTransaction();
            try
            {
                PalletLocation pl = new PalletLocation();
                DataRow dr = gridReceiveView.GetFocusedDataRow();
                if (dr == null)
                {
                    throw new Exception("Nothing to confirm!");
                }

                int ReceiptID = Convert.ToInt32(gridReceiveView.GetFocusedDataRow()["ReceiptID"]);

                if (gridDetailView.DataSource == null)
                    return;

                BLL.ReceiveDoc receiveDoc = new ReceiveDoc();
                receiveDoc.LoadByReceiptIDWithReceivePallet(ReceiptID);

                while (!receiveDoc.EOF)
                {
                    int palletLocationID = Convert.ToInt32(receiveDoc.GetColumn("PalletLocationID"));
                    pl.LoadByPrimaryKey(palletLocationID);
                    pl.Confirmed = true;
                    pl.Save();

                    receiveDoc.MoveNext();
                }
                BLL.ReceiveDoc recDoc = new ReceiveDoc();
                recDoc.LoadByReceiptID(ReceiptID);

                recDoc.ConfirmQuantityAndLocation(CurrentContext.UserId);
                BLL.Receipt receiptStatus = new BLL.Receipt();
                receiptStatus.LoadByPrimaryKey(ReceiptID);
                receiptStatus.ChangeStatus(ReceiptConfirmationStatus.Constants.RECEIVE_QUANTITY_CONFIRMED, null, this.GetFormIdentifier(), CurrentContext.UserId, "Receive Confirmed");

                transaction.CommitTransaction();
                XtraMessageBox.Show("Receipt Confirmed!", "Success", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                BindFormContents();

            }
            catch (Exception exp)
            {
                transaction.RollbackTransaction();
                XtraMessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="receiptID"></param>
        /// <param name="referenceNumber"></param>
        /// <param name="preGRVorGRV">1-Pre-GRV, 2-GRV</param>
        private void PrintReceiptConfirmation(int receiptID)
        {
            var printout = WorkflowReportFactory.CreateGRNFPrintout(receiptID, null, false, FiscalYear.Current);

            if (printout.PrintDialog() != System.Windows.Forms.DialogResult.OK)
            {
                throw new Exception("Print cancelled by user!");
            }
        }



        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataRow dataRow = gridReceiveView.GetFocusedDataRow();
            if (dataRow != null)
            {
                if (Convert.ToInt32(dataRow["ReceiptConfirmationStatusID"]) == ReceiptConfirmationStatus.Constants.RECEIVE_QUANTITY_CONFIRMED)
                {
                    ReceiptID = Convert.ToInt32(dataRow["ReceiptID"]);
                    PrintDialog printDialog = new PrintDialog();
                    printDialog.PrinterSettings.Copies = BLL.Settings.GRNFCopies;
                   
                      DialogResult dialogResult = printDialog.ShowDialog();

                    if (dialogResult != DialogResult.OK)
                    {
                        MessageBox.Show("Printing Canceled by user", "Cancel Printint...", MessageBoxButtons.OK,
                                        MessageBoxIcon.Asterisk);
                        return;
                    }

                    TransactionMgr transaction = TransactionMgr.ThreadTransactionMgr();
                    XtraReport printout;
                    try
                    {
                       transaction.BeginTransaction();
                        printout = WorkflowReportFactory.CreateGRNFPrintout(ReceiptID, null, false, FiscalYear.Current);
                        var receipt = new BLL.Receipt(ReceiptID);

                        var recDoc = new ReceiveDoc();
                        recDoc.LoadByReceiptID(ReceiptID);


                        if (receipt.ReceiptInvoice.PO.PurchaseType == BLL.POType.STORE_TO_STORE_TRANSFER || !BLL.Settings.HandleGRV)
                        {
                            recDoc.ConfirmGRVPrinted(CurrentContext.UserId);
                            BLL.Receipt receiptStatus = new BLL.Receipt();
                            receiptStatus.LoadByPrimaryKey(ReceiptID);
                            receiptStatus.ChangeStatus(ReceiptConfirmationStatus.Constants.GRV_PRINTED, null, this.GetFormIdentifier(), CurrentContext.UserId, "Transfer Confirmed");

                        }
                        else
                        {

                            recDoc.ConfirmGRNFPrinted(CurrentContext.UserId);

                            BLL.Receipt receiptStatus = new BLL.Receipt();
                            receiptStatus.LoadByPrimaryKey(ReceiptID);
                            receiptStatus.ChangeStatus(ReceiptConfirmationStatus.Constants.GRNF_PRINTED, null, this.GetFormIdentifier(), CurrentContext.UserId, "GRNF Printed");

                        }
                        transaction.CommitTransaction();
                        
                    }
                    catch (Exception exception)
                    {
                        transaction.RollbackTransaction();
                        
                        XtraMessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw;
                    }
                     
                    
                    for (int i = 0; i < printDialog.PrinterSettings.Copies; i++)
                    {
                        printout.Print( printDialog.PrinterSettings.PrinterName);
                    }
                    
                    ReceiptConfirmation_Load(null, null);
                   
                }
                else
                {
                    XtraMessageBox.Show("The selected receipt has to be confirmed before GRNF is printed!", "ERROR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
        }

        private void gridReceiveView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            gridReceiveView_FocusedRowChanged(null, null);
        }

        private void lkAccount_EditValueChanged(object sender, EventArgs e)
        {
            if (lkAccount.EditValue != null && lkWarehouse.EditValue != null)
            {
                gridReceiveView.ActiveFilterString = String.Format("StoreID = {0} and WarehouseID = {1}", lkAccount.EditValue, lkWarehouse.EditValue);
            }
            else if (lkWarehouse.EditValue != null)
            {
                gridReceiveView.ActiveFilterString = String.Format("WarehouseID = {0}", lkWarehouse.EditValue);
            }
            else if (lkAccount.EditValue != null)
            {
                gridReceiveView.ActiveFilterString = String.Format("StoreID = {0}", lkAccount.EditValue);
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (currentMode == Modes.QuantityConfirmation)
            {
                ReturnToStoreForQuantityEdit();

            }
        }


        private void ReturnToStoreForQuantityEdit()
        {
            //TODO: finish updating the changed locations
            MyGeneration.dOOdads.TransactionMgr transaction = MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgr();
            transaction.BeginTransaction();
            try
            {
                PalletLocation pl = new PalletLocation();
                String reference = gridReceiveView.GetFocusedDataRow()["RefNo"].ToString();

                int ReceiptID = Convert.ToInt32(gridReceiveView.GetFocusedDataRow()["ReceiptID"]);

                if (gridDetailView.DataSource == null)
                    return;

                BLL.ReceiveDoc recDoc = new ReceiveDoc();
                recDoc.LoadByReceiptID(ReceiptID);
                recDoc.SetStatusAsDraft(CurrentContext.UserId);

                BLL.Receipt receiptStatus = new BLL.Receipt();
                receiptStatus.LoadByPrimaryKey(ReceiptID);
                receiptStatus.ChangeStatus(ReceiptConfirmationStatus.Constants.DRAFT_RECEIPT, null, this.GetFormIdentifier(), CurrentContext.UserId, "Returned To Draft");

                transaction.CommitTransaction();
                XtraMessageBox.Show("Receipt Returned!", "Success", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                BindFormContents();

            }
            catch (Exception exp)
            {
                transaction.RollbackTransaction();
                XtraMessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridDetailView_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridDetailView.GetFocusedDataRow();

        }

        private void btnVoid_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "Are you sure, you want to Void the Document?", "Are you sure:", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                ReceiptConfirmationPrintout receiptVoidlog = new ReceiptConfirmationPrintout();
                receiptVoidlog.AddNew();
                receiptVoidlog.VoidRequestUserID = CurrentContext.UserId;
                receiptVoidlog.VoidRequest = true;
                receiptVoidlog.VoidApprovedByUserID = CurrentContext.UserId;
                receiptVoidlog.VoidRequestDateTime = DateTimeHelper.ServerDateTime;
                receiptVoidlog.VoidApprovalDateTime = DateTimeHelper.ServerDateTime;
                receiptVoidlog.UserID = CurrentContext.UserId;
                int receiptID = Convert.ToInt32(gridReceiveView.GetFocusedDataRow()["ReceiptID"].ToString());
                receiptVoidlog.ReceiptID = receiptID;

                ReturnToStoreForQuantityEdit();
            }
        }

        #region Center

        private void LoadDecimalFormatings()
        {
            string sharps = Helpers.FormattingHelpers.GetNumberFormatting();
            string displaySharpsBirr = Helpers.FormattingHelpers.GetBirrFormatting();
            string displaySharpsPercent = Helpers.FormattingHelpers.GetPercentFormatting();
            string displayExchangeRate = Helpers.FormattingHelpers.GetExchangeRateFormatting();
        }

        private void SetDisplayFormatAndEditMask(TextEdit txtBox, string sharps, string displaySharps)
        {
            txtBox.Properties.DisplayFormat.FormatString = sharps;
            txtBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtBox.Properties.Mask.EditMask = sharps;
            txtBox.Properties.Mask.UseMaskAsDisplayFormat = false;
            txtBox.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtBox.Properties.DisplayFormat.FormatString = displaySharps;
            txtBox.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            txtBox.EditValue = 0.0;
            txtBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
        }

        private void SetDisplayFormatAndEditMask(DevExpress.XtraGrid.Columns.GridColumn colBox, bool hasSummary, string displaySharps)
        {
            colBox.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colBox.DisplayFormat.FormatString = displaySharps;
        }

        private double InsuranceClaim(int damagedQty, int TotalQty, double PricePerPack, double InsuranceRate)
        {
            double insuredsum = PricePerPack * 1.1 * InsuranceRate;
            return Math.Round((insuredsum / TotalQty) * damagedQty, BLL.Settings.NoOfDigitsAfterTheDecimalPoint);
        }

        private double SupplierClaim(int ShortageQty, double PricePerPack)
        {

            return ShortageQty * PricePerPack;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void lkWarehouse_EditValueChanged(object sender, EventArgs e)
        {
            lkAccount_EditValueChanged(null, null);
        }

        private void gridReceives_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelReceive_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "Are you sure, you want to Cancel the Receipt Document?", "Are you sure:", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
               try
                {
                    int receiptID = Convert.ToInt32(gridReceiveView.GetFocusedDataRow()["ReceiptID"].ToString());
                    BLL.ReceiveDoc receiveDoc = new ReceiveDoc();
                    receiveDoc.LoadByReceiptID(receiptID);

                    while (!receiveDoc.EOF)
                    {
                        BLL.ReceiveDoc.DeleteAReceiveDocEntry(receiveDoc.ID, CurrentContext.UserId);
                        receiveDoc.MoveNext();
                    }
                    XtraMessageBox.Show("You have successfully canceled the draft receipt.", "Confirmation");
                    BindFormContents();
                }
                catch (Exception exception)
                {
                    XtraMessageBox.Show(exception.Message);
                }


            }
        }

        private void gridDetailView_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            if (e.Column == colStore || e.Column == Packs) return;

            e.Merge = (gridDetailView.GetRowCellValue(e.RowHandle1, colStockCode).ToString().Equals(gridDetailView.GetRowCellValue(e.RowHandle2, colStockCode).ToString()) &&
                        gridDetailView.GetRowCellValue(e.RowHandle1, colItemName).ToString().Equals(gridDetailView.GetRowCellValue(e.RowHandle2, colItemName).ToString()) &&
                        gridDetailView.GetRowCellValue(e.RowHandle1, colUnit).ToString().Equals(gridDetailView.GetRowCellValue(e.RowHandle2, colUnit).ToString()) &&
                        gridDetailView.GetRowCellValue(e.RowHandle1, colManufacturer).ToString().Equals(gridDetailView.GetRowCellValue(e.RowHandle2, colManufacturer).ToString()) &&
                        gridDetailView.GetRowCellValue(e.RowHandle1, colBatch).ToString().Equals(gridDetailView.GetRowCellValue(e.RowHandle2, colBatch).ToString()) &&
                        gridDetailView.GetRowCellValue(e.RowHandle1, colExpiryDate).ToString().Equals(gridDetailView.GetRowCellValue(e.RowHandle2, colExpiryDate).ToString()));
            
            e.Handled = true;

        }

        private void lblTransferVoucherNo_Click(object sender, EventArgs e)
        {

        }

        private void txtFilter_EditValueChanged(object sender, EventArgs e)
        {
          

            gridReceiveView.ActiveFilterString = String.Format("[STVOrInvoiceNo] LIKE '{0}%'  or Date like '%{0}%'  or ReceiptType like '{0}%'", txtFilter.Text);

        }

        private void lblConfirmedBy_Click(object sender, EventArgs e)
        {

        }
    }
}