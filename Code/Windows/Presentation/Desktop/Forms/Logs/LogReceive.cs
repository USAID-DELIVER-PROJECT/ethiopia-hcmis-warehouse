using System;
using System.Data;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using HCMIS.Desktop.Helpers;
using HCMIS.Helpers;
using HCMIS.Desktop.ViewHelpers;
using HCMIS.Desktop.Forms.Reports;
using HCMIS.Desktop.Modals;
 


namespace HCMIS.Desktop.Forms.Logs
{
    [FormIdentifier("AL-RT-RT-RP", "Receive Transaction Log", "Transaction Log")]
    public partial class LogReceive : XtraForm
    {
        public LogReceive()
        {
            InitializeComponent();
        }

        private bool _isReady;

        private void ManageItems_Load(object sender, EventArgs e)
        {
            SetPermission();
            // Bind the supplier combo
            Supplier sup = new Supplier();
            DataTable dtSup = sup.GetSuppliersWithTransaction();
            cboSuppliers.Properties.DataSource = dtSup;
            cboSuppliers.ItemIndex = -1;
            cboSuppliers.Text = @"Select Supplier";

            cboStores.SetupActivityEditor().SetDefaultActivity();
            // Set the default dates on the filter as the current date
            // TODO: the from date should be fixed.
            dtFrom.Value = DateTimeHelper.ServerDateTime;
            dtTo.Value = DateTimeHelper.ServerDateTime;
            _isReady = true;
        }

        private void SetPermission()
        {
            // add the entries for issues
            if (BLL.Settings.UseNewUserManagement)
            {
                this.HasPermission("Delete");
                this.HasPermission("Edit");
                this.HasPermission("View-Item-Detail");
            }
        }

        private void PopulateDocuments(DataTable dtRec)
        {
            gridControl1.DataSource = dtRec;
        }

        private void PopulateTransactions(DataTable dtRec)
        {
            gridTransactions.DataSource = dtRec;
        }

        private void cboStores_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboStores.EditValue != null)
            {
                ReceiveDoc rec = new ReceiveDoc();
                DataTable dtRec = new DataTable();

                dtRec = rec.GetDistinctRecDocments(Convert.ToInt32(cboStores.EditValue));
                PopulateDocuments(dtRec);

                DateTime dt1 = new DateTime();
                DateTime dt2 = new DateTime();
                dtDate.Value = DateTimeHelper.ServerDateTime;
                DateTime dtCurrent = ConvertDate.DateConverter(dtDate.Text);
                int yr = ((dtCurrent.Month > 10) ? dtCurrent.Year : dtCurrent.Year - 1);
                dt1 = new DateTime(yr, 11, 1);
                dt2 = new DateTime(dtCurrent.Year, dtCurrent.Month, dtCurrent.Day);
                dtRec = rec.GetTransactionByDateRange(Convert.ToInt32(cboStores.EditValue), dt1, dt2);
                PopulateTransactions(dtRec);
            }
        }

        private void cboSuppliers_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboSuppliers.EditValue != null)
            {
                ReceiveDoc rec = new ReceiveDoc();
                DataTable dtRec = new DataTable();
                dtRec = rec.GetTransactionBySupplierId(Convert.ToInt32(cboStores.EditValue),
                    Convert.ToInt32(cboSuppliers.EditValue));
                PopulateTransactions(dtRec);
            }
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            if (_isReady)
            {
                ReceiveDoc rec = new ReceiveDoc();
                dtFrom.CustomFormat = "MM/dd/yyyy";
                dtTo.CustomFormat = "MM/dd/yyyy";
                DateTime dteFrom = new DateTime();
                DateTime dteTo = new DateTime();

                dteFrom = ConvertDate.DateConverter(dtFrom.Text);
                dteTo = ConvertDate.DateConverter(dtTo.Text);

                DataTable dtRec = new DataTable();
                if (dteFrom < dteTo)
                {

                    dtRec = rec.GetTransactionByDateRange(Convert.ToInt32(cboStores.EditValue), dteFrom, dteTo);

                }
                else
                {
                    dtRec = rec.GetAllTransaction(Convert.ToInt32(cboStores.EditValue));
                }
                PopulateTransactions(dtRec);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // This could be put in someother utilty class and be reused.
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "Microsoft Excel | *.xls";

            if (DialogResult.OK == saveDlg.ShowDialog())
            {
                gridTransactions.MainView.ExportToXls(saveDlg.FileName);
                XtraMessageBox.Show("The receive transaction log has been exported", "Exported", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            gridTransactions.ShowPrintPreview();

        }


        private void detailItemStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!BLL.Settings.UseNewUserManagement ||
                (BLL.Settings.UseNewUserManagement && this.HasPermission("View-Item-Detail")))
            {



                DataRow dr = gridViewTransaction.GetFocusedDataRow();
                if (dr != null)
                {
                    int? unitID = null;
                    if (dr["UnitID"] != DBNull.Value)
                    {
                        unitID = Convert.ToInt32(dr["UnitID"]);
                    }
                    ItemDetailReport con = new ItemDetailReport(Convert.ToInt32(dr["ItemID"]), unitID,
                        Convert.ToInt32(dr["StoreID"]), 0);
                    con.ShowDialog();
                }
            }
        }

        private void gridViewRefNo_FocusedRowChanged(object sender,
            DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            DataRow dr = gridViewRefNo.GetFocusedDataRow();
            DateTime dt1 = new DateTime();
            DateTime dt2 = new DateTime();
            dtDate.Value = DateTimeHelper.ServerDateTime;
            DateTime dtCurrent = ConvertDate.DateConverter(dtDate.Text);

            if (dr == null) return;
            lblMode.Text = dr["Mode"] == DBNull.Value ? "-" : Convert.ToString(dr["Mode"]);
            lblAccount.Text = dr["Account"] == DBNull.Value ? "-" : Convert.ToString(dr["Account"]);
            lblSubAccount.Text = dr["SubAccount"] == DBNull.Value ? "-" : Convert.ToString(dr["SubAccount"]); 
            lblActivity.Text = dr["Activity"] == DBNull.Value ? "-" : Convert.ToString(dr["Activity"]);
            lblSupplier.Text = dr["Supplier"] == DBNull.Value ? "-" : Convert.ToString(dr["Supplier"]);
            lblInvoiceNo.Text = dr["STVOrInvoiceNo"] == DBNull.Value ? "-" : Convert.ToString(dr["STVOrInvoiceNo"]);
            lblPaymentType.Text = dr["PaymentType"] == DBNull.Value ? "-" : Convert.ToString(dr["PaymentType"]);
            lblPONumber.Text = dr["PONumber"] == DBNull.Value ? "-" : Convert.ToString(dr["PONumber"]);
            lblPOType.Text = dr["POType"] == DBNull.Value ? "-" : Convert.ToString(dr["POType"]);
            lblDocumentType.Text = dr["DocumentType"] == DBNull.Value ? "-" : Convert.ToString(dr["DocumentType"]);
            lblCluster.Text = dr["Cluster"] == DBNull.Value ? "-" : Convert.ToString(dr["Cluster"]);
            lblWarehouse.Text = dr["Warehouse"] == DBNull.Value ? "-" : Convert.ToString(dr["Warehouse"]);
            lblPhysicalStore.Text = dr["PhysicalStore"] == DBNull.Value ? "-" : Convert.ToString(dr["PhysicalStore"]);
            lblReceiveType.Text = dr["ReceiptType"] == DBNull.Value ? "-" : Convert.ToString(dr["ReceiptType"]);
            lblReceiveStatus.Text = dr["ReceiptStatus"] == DBNull.Value ? "-" : Convert.ToString(dr["ReceiptStatus"]);
            lblReceivedDate.Text = dr["ReceivedDate"] == DBNull.Value ? "-" : Convert.ToDateTime(dr["ReceivedDate"]).ToShortDateString();
            lblReceivedBy.Text = dr["ReceivedBy"] == DBNull.Value ? "-" : Convert.ToString(dr["ReceivedBy"]);

            var receiptConfirmationPrintout = new ReceiptConfirmationPrintout();
            var grnfDetail = receiptConfirmationPrintout.GetReceivePrintoutDetail(Convert.ToInt32(dr["ReceiptID"]),"PGRV");
            var grvDetail = receiptConfirmationPrintout.GetReceivePrintoutDetail(Convert.ToInt32(dr["ReceiptID"]), "GRV");

            if (grnfDetail != null)
            {
                lblGRNFNo.Text = grnfDetail["IDPrinted"] == DBNull.Value ? "-" : Convert.ToString(grnfDetail["IDPrinted"]);
                lblGRNFDate.Text = grnfDetail["PrintedDate"] == DBNull.Value ? "-" : Convert.ToDateTime(grnfDetail["PrintedDate"]).ToShortDateString();
                lblGRNFBy.Text = grnfDetail["FullName"] == DBNull.Value ? "-" : Convert.ToString(grnfDetail["FullName"]);
            }

            if (grvDetail != null)
            {
                lblGRVDate.Text = grvDetail["PrintedDate"] == DBNull.Value ? "-" : Convert.ToDateTime(grvDetail["PrintedDate"]).ToShortDateString();
                lblGRVBy.Text = grvDetail["FullName"] == DBNull.Value ? "-" : Convert.ToString(grvDetail["FullName"]);
            }

            string ReferenceNo = dr["RefNo"].ToString();
            if (ReferenceNo != "")
            {
                gridTransactions.DataSource = null;
                ReceiveDoc rec = new ReceiveDoc();
                DataTable dtRec = new DataTable();
                if (ReferenceNo == "0")
                {
                    int yr = ((dtCurrent.Month > 10) ? dtCurrent.Year : dtCurrent.Year - 1);
                    dt1 = new DateTime(yr, 11, 1);
                    dt2 = new DateTime(dtCurrent.Year, dtCurrent.Month, dtCurrent.Day);
                    dtRec = rec.GetTransactionByDateRange(Convert.ToInt32(cboStores.EditValue), dt1, dt2);
                    //lblRecDate.Text = "Current Year";// ( " + dtCurrent.Year + " )";
                }
                else if (ReferenceNo == "1")
                {
                    int yr = ((dtCurrent.Month > 10) ? dtCurrent.Year : dtCurrent.Year - 1);
                    dt1 = new DateTime(1980, 11, 1);
                    dt2 = new DateTime(yr, 10, 30);
                    dtRec = rec.GetTransactionByDateRange(Convert.ToInt32(cboStores.EditValue), dt1, dt2);
                    //lblRecDate.Text = "Past Year(s)";
                }
                else
                {
                    dtRec = rec.GetTransactionByRefNo(ReferenceNo, Convert.ToInt32(cboStores.EditValue),
                        dr["Date"].ToString());
                    //lblRecDate.Text = Convert.ToDateTime(ReferenceNo[1]).ToString("MM dd,yyyy");
                }
                PopulateTransactions(dtRec);

            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if ((!BLL.Settings.UseNewUserManagement &&
                 CurrentContext.LoggedInUser.UserType == UserType.Constants.DISTRIBUTION_MANAGER_WITH_DELETE) ||
                (BLL.Settings.UseNewUserManagement && this.HasPermission("Delete")))
            {
                try
                {
                    DataRow dr = gridViewTransaction.GetFocusedDataRow();
                    if (dr != null)
                    {
                        int receiveDocID = Convert.ToInt32(dr["ID"]);
                        if (XtraMessageBox.Show(
                            "Are you sure you would like to delete this transaction? You will not be able to undo this.",
                            "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                            System.Windows.Forms.DialogResult.Yes)
                        {
                            BLL.ReceiveDoc.DeleteAReceiveDocEntry(receiveDocID, CurrentContext.UserId);
                            gridViewRefNo_FocusedRowChanged(null, null);
                            XtraMessageBox.Show("Successfully Deleted!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                }
            }
            else
            {
                XtraMessageBox.Show(
                    "You don't have privilage to delete this transaction. Please contact administrator to have this option enabled.");
            }

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void txtFilter_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {

        }

        private void txtFilter_EditValueChanged(object sender, EventArgs e)
        {
            gridViewRefNo.ActiveFilterString = string.Format("RefNo like '{0}%' or Date like '{0}%'", txtFilter.Text);

        }

    }
}