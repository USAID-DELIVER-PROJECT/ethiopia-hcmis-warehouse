using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common.CommandTrees;
using System.Drawing.Printing;
using System.Windows.Forms;
using BLL;
using CalendarLib;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraReports.UI;
using HCMIS.Desktop.Helpers;
using HCMIS.Desktop.ViewHelpers;
using HCMIS.Helpers;
using MyGeneration.dOOdads;
using HCMIS.Desktop.Forms.Modals.Finance;
using HCMIS.Desktop.Reports;
using ReceiptConfirmationPrintout = BLL.ReceiptConfirmationPrintout;

namespace HCMIS.Desktop.Forms.WorkFlow
{
    [FormIdentifier("CM-GR-GV-CN", "GRV Void", "")]
    public partial class PrintoutLogReceipt : XtraForm
    {
        public enum Modes
        {
            GRVConfirmation = 7
        }

        /// <summary>
        /// TO BE Splitted
        /// </summary>
        private readonly Modes currentMode;

        private DataSet ds = new DataSet();


        private int ReceiptID;
        private int StoreID;

        public PrintoutLogReceipt()
        {
            InitializeComponent();
            currentMode = Modes.GRVConfirmation;
        }


        private void PutAwayListsLoad(object sender, EventArgs e)
        {
            //Lookup For Accounts
            lkAccount.SetupActivityEditor().SetDefaultActivity();
            BindFormContents();

            if (currentMode == Modes.GRVConfirmation)
            {
                colReceivingCost.Visible = false;
                lcReprint.Visibility = LayoutVisibility.Always;

                SetPermission();
            }

            gridReceiveView_FocusedRowChanged(null, null);
        }

        private void SetPermission()
        {
            if (BLL.Settings.UseNewUserManagement)
            {
                lcVoid.Visibility = this.HasPermission("Confirm-Void") ? LayoutVisibility.Always : LayoutVisibility.Never;
                lcRequestVoid.Visibility = this.HasPermission("Request-Void") ? LayoutVisibility.Always : LayoutVisibility.Never;
                lcReprint.Visibility = this.HasPermission("Reprint") ? LayoutVisibility.Always : LayoutVisibility.Never;
                lcCancelVoidRequest.Visibility = this.HasPermission("Cancel") ? LayoutVisibility.Always : LayoutVisibility.Never;
                lcPrint.Visibility = this.HasPermission("Print") ? LayoutVisibility.Always : LayoutVisibility.Never;
            }
            else
            {
                if (CurrentContext.LoggedInUser.UserType == UserType.Constants.FINANCE)
                {
                    lcCancelVoidRequest.Visibility = LayoutVisibility.Always;
                    lcVoid.Visibility = LayoutVisibility.Always;
                }
                else if (CurrentContext.LoggedInUser.UserType == UserType.Constants.SUPER_ADMINISTRATOR)
                {
                    lcRequestVoid.Visibility = LayoutVisibility.Always;
                    lcCancelVoidRequest.Visibility = LayoutVisibility.Always;
                    lcVoid.Visibility = LayoutVisibility.Always;
                }
                else if (CurrentContext.LoggedInUser.UserType == UserType.Constants.FUND_OFFICER)
                {
                    lcRequestVoid.Visibility = LayoutVisibility.Always;
                }
            }
        }

        private void BindFormContents()
        {
            var pl = new PalletLocation();
            lkPalletLocations.DataSource = PalletLocation.GetAll();
            if (currentMode == Modes.GRVConfirmation)
            {
                gridReceives.DataSource = pl.GetReceivesForGRVConfirmation(CurrentContext.UserId);
                colLocation.Visible = false;
                colInsurance.Visible = false;
                colMargin.Visible = false;
                lcReprint.Visibility = LayoutVisibility.Always;
                lcRequestVoid.Visibility = LayoutVisibility.Always;
                lcVoid.Visibility = LayoutVisibility.Always;
            }
        }

        #region

        private void gridReceiveView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            // Bind the detail grid
            var pl = new PalletLocation();
            ReceiptID = Convert.ToInt32(gridReceiveView.GetFocusedDataRow()["ReceiptID"]);

            try
            {
                //B1A data
                var SelectGRV = gridReceiveView.GetFocusedDataRow();
                String reference = gridReceiveView.GetFocusedDataRow()["RefNo"].ToString();
                lblGRVNo.Text = reference;
                lblMode.Text = (string)SelectGRV["ModeName"];
                lblAccount.Text = (string)SelectGRV["AccountName"];
                lblSubAccount.Text = (string)SelectGRV["SubAccountName"];
                lblActivity.Text = (string)SelectGRV["ActivityName"];
                lblSupplier.Text = (string)SelectGRV["SupplierName"];
                lblPoNumber.Text = (string)SelectGRV["PONo"];
                lblCluster.Text = (string)SelectGRV["ClusterName"];
                lblWarehouse.Text = (string)SelectGRV["WarehouseName"];
                lblStore.Text = (string)SelectGRV["PhysicalStoreName"];
                lblType.Text = (string)SelectGRV["ReceiptType"];
                lblStatus.Text = (string)SelectGRV["ReceiptStatus"];

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

                var receiveDoc = new ReceiveDoc();
                receiveDoc.LoadByReceiptID(Convert.ToInt32(SelectGRV["ReceiptID"]));
                lblConfirmedDate.Text = receiveDoc.ConfirmedDateTime.ToString() != "" ? receiveDoc.ConfirmedDateTime.ToShortDateString() : "-";


                lblConfirmedBy.Text = SelectGRV["confirmedBy"] != DBNull.Value ? SelectGRV["confirmedBy"].ToString() : "-";
                lblGRVNumber.Text = reference;
                lblRecivedDate.Text = ((DateTime)SelectGRV["Date"]).ToShortDateString();

                
               // lblConfirmedDate.Text =SelectGRV["confirmedDate"] != DBNull.Value ? Convert.ToDateTime(SelectGRV["confirmedDate"]).ToShortDateString() : "-";

                ds = new DataSet();
                DataTable dvMaster = pl.GetDetailsOfByReceiptID(ReceiptID);
                dvMaster.TableName = "Master";
                ds.Tables.Add(dvMaster);
                gridDetails.DataSource = ds.Tables[dvMaster.TableName];


                int status = Convert.ToInt32(gridReceiveView.GetFocusedDataRow()["Status"]);
                try
                {
                    StoreID = Convert.ToInt32(gridReceiveView.GetFocusedDataRow()["StoreID"]);
                }
                catch
                {
                }
                
                var receipt = new BLL.Receipt();
                receipt.LoadByPrimaryKey(ReceiptID);
                int receiptTypeID = receipt.ReceiptTypeID;
            }

            catch
            {
                gridDetails.DataSource = null;
            }

            //reset
            btnCancelVoidRequest.Enabled = true;
            btnVoidRequest.Enabled = true;
            btnVoid.Enabled = true;
            btnReprintGRV.Enabled = true;

            if (Convert.ToBoolean(gridReceiveView.GetFocusedDataRow()["isreprint"].ToString()))
            {
                btnReprintGRV.Enabled = false;
            }

            if (Convert.ToBoolean(gridReceiveView.GetFocusedDataRow()["hasreprint"].ToString()))
            {
                btnCancelVoidRequest.Enabled = false;
                btnVoidRequest.Enabled = false;
                btnVoid.Enabled = false;
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
            var lke = (LookUpEdit) gridDetailView.ActiveEditor;
            int itemID = Convert.ToInt32(gridDetailView.GetFocusedDataRow()["ItemID"]);
            lke.Properties.DataSource = PalletLocation.GetAllFreeFor(itemID);
        }

        /// <summary>
        /// Prints GRV, SRM or Delivery Note
        /// </summary>
        private void PrintConfirmation(int? reprintOfReceiptConfirmationPrintoutID)
        {
            String reference = gridReceiveView.GetFocusedDataRow()["RefNo"].ToString();
            int receiptID = Convert.ToInt32(gridReceiveView.GetFocusedDataRow()["ReceiptID"].ToString());
            XtraReport report = WorkflowReportFactory.PrintReceiptConfirmation(CurrentContext.LoggedInUserName, receiptID, reprintOfReceiptConfirmationPrintoutID, false,FiscalYear.Current);
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

        private void ReturnToStoreForQuantityEdit()
        {
            //TODO: finish updating the changed locations
            TransactionMgr transaction = TransactionMgr.ThreadTransactionMgr();
            transaction.BeginTransaction();
            try
            {
                var pl = new PalletLocation();
                String reference = gridReceiveView.GetFocusedDataRow()["RefNo"].ToString();
                //           pl.ConfirmAllReceived(reference);
                if (gridDetailView.DataSource == null)
                    return;

                foreach (DataRowView drv in gridDetailView.DataSource as DataView)
                {
                    int PalletLocationID = Convert.ToInt32(drv["PalletLocationID"]);
                    int ProposedPalletLocationID = Convert.ToInt32(drv["ProposedPalletLocationID"]);

                    if (PalletLocationID != ProposedPalletLocationID)
                    {
                        pl.LoadByPrimaryKey(PalletLocationID);
                        if (pl.IsColumnNull("PalletID"))
                        {
                            pl.Confirmed = false;
                            pl.Save();
                        }
                    }
                    else
                    {
                        pl.LoadByPrimaryKey(PalletLocationID);
                        pl.Confirmed = false;
                        pl.Save();
                    }
                }


                var recDoc = new ReceiveDoc();
                recDoc.LoadByReferenceNo(reference);
                recDoc.SetStatusAsReceived(null);
                transaction.CommitTransaction();
                XtraMessageBox.Show("Receipt Returned!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        #region Formating

        private void SetDisplayFormatAndEditMask(GridColumn colBox, bool hasSummary, string displaySharps)
        {
            colBox.DisplayFormat.FormatType = FormatType.Numeric;
            colBox.DisplayFormat.FormatString = displaySharps;
        }

        #endregion

        //TODO: Definitly going to BLL but i don't have time to do a clean job here.

        #region Void Process

        private void btnVoid_Click(object sender, EventArgs e)
        {
            int receiptID = Convert.ToInt32(gridReceiveView.GetFocusedDataRow()["ReceiptID"].ToString());

            if (BLL.Receipt.AreThereIssues(receiptID))
            {
                XtraMessageBox.Show("There are issues with this GRV.  You can't void it.");
                return;
            }

            var grv = new ReceiptConfirmationPrintout();
            grv.Where.ReceiptID.Value = receiptID;
            grv.Query.Load();

            if (grv.IsColumnNull("VoidRequest") || !grv.VoidRequest)
            {
                XtraMessageBox.Show("Void needs to be first requested.", "Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                return;
            }

            if (
                XtraMessageBox.Show(UserLookAndFeel.Default, "Are you sure, you want to Void the Document?",
                                    "Are you sure:", MessageBoxButtons.YesNo, MessageBoxIcon.Information) ==
                DialogResult.Yes)
            {
                while (!grv.EOF)
                {
                    grv.IsVoided = true;
                    grv.VoidApprovedByUserID = CurrentContext.UserId;
                    grv.VoidApprovalDateTime = DateTimeHelper.ServerDateTime;
                    grv.MoveNext();
                }

                grv.Save();
                ReturnToStoreForQuantityEdit();
                BLL.Receipt receiptStatus = new BLL.Receipt();
                receiptStatus.LoadByPrimaryKey(ReceiptID);
                receiptStatus.ChangeStatus(ReceiptConfirmationStatus.Constants.DRAFT_RECEIPT, null, this.GetFormIdentifier(), CurrentContext.UserId, "GRV Voided");
          
                this.LogActivity("Approve-Receipt-Void", ReceiptID);
            }
        }

        private void btnVoidRequest_Click(object sender, EventArgs e)
        {
            if (
                XtraMessageBox.Show(UserLookAndFeel.Default, "Are you sure, you want to request void for this Document?",
                                    "Are you sure:", MessageBoxButtons.YesNo, MessageBoxIcon.Information) ==
                DialogResult.Yes)
            {
                int receiptID = Convert.ToInt32(gridReceiveView.GetFocusedDataRow()["ReceiptID"].ToString());

                var grv = new ReceiptConfirmationPrintout();
                grv.Where.ReceiptID.Value = receiptID;
                grv.Query.Load();

                while (!grv.EOF)
                {
                    grv.VoidRequestUserID = CurrentContext.UserId;
                    grv.VoidRequest = true;
                    grv.VoidRequestDateTime = DateTimeHelper.ServerDateTime;
                    grv.MoveNext();
                }

                grv.Save();
                this.LogActivity("Request-Receipt-Void", ReceiptID);
                XtraMessageBox.Show("Void requested.", "Success");
            }
        }

        private void btnCancelVoidRequest_Click(object sender, EventArgs e)
        {
            if (
                XtraMessageBox.Show(UserLookAndFeel.Default, "Are you sure, you want to request void for this Document?",
                                    "Are you sure:", MessageBoxButtons.YesNo, MessageBoxIcon.Information) ==
                DialogResult.Yes)
            {
                int receiptID = Convert.ToInt32(gridReceiveView.GetFocusedDataRow()["ReceiptID"].ToString());

                var grv = new ReceiptConfirmationPrintout();
                grv.Where.ReceiptID.Value = receiptID;
                grv.Query.Load();

                while (!grv.EOF)
                {
                    grv.VoidRequest = false;
                    grv.MoveNext();
                }

                grv.Save();
                this.LogActivity("Cancel-Void-Request", ReceiptID);
                XtraMessageBox.Show("Void request cancelled.", "Success");
            }
        }

        #endregion

        private void btnReprintGRV_Click(object sender, EventArgs e)
        {
            TransactionMgr transaction = TransactionMgr.ThreadTransactionMgr();
            try
            {
                transaction.BeginTransaction();
                DataRow dr = gridReceiveView.GetFocusedDataRow();
                int? receiptConfirmationPrintoutID = Convert.ToInt32(dr["ID"]);
                PrintConfirmation(receiptConfirmationPrintoutID);
                transaction.CommitTransaction();
                this.LogActivity("Reprint", ReceiptID);
            }
            catch (Exception ex)
            {
                transaction.RollbackTransaction();
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void gridDetails_Click(object sender, EventArgs e)
        {

        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            gridReceiveView.ActiveFilterString = string.Format("PGRV like '%{0}%' or Date like '%{0}%'", textEdit1.Text);
        }
    }
}
