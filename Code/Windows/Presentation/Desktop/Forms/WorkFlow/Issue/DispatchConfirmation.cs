using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BLL;
using BLL.WorkFlow.Issue;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using HCMIS.Desktop.Helpers;
using HCMIS.Helpers;
using HCMIS.Desktop.ViewHelpers;

using HCMIS.Desktop.Forms.Modals;

namespace HCMIS.Desktop.Forms.WorkFlow
{
    [FormIdentifier("DI-MA-DC-CN", "Dispatch Confirmation", "Dispatch Confirmation")]
    public partial class DispatchConfirmation : XtraForm
    {
        int _activeSTVID = 0;
        int _mode;
        private static string Value;
        private Dictionary<int, decimal> _discrepancyIssueDoc = new Dictionary<int, decimal>(); //issueDocID will be key, and the actual issued quantity will be stored in the value field.
        BLL.Order ord = new BLL.Order();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode">1-Invoicer Mode, 2-Store Mode, 3-Fund Mode</param>
        public DispatchConfirmation()
        {
            InitializeComponent();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            lkAccount.SetupActivityEditor().SetDefaultActivity();
            if (!BLL.Settings.UseNewUserManagement) return;
            if (this.HasPermission("Request-Void"))
            {
                lcRequestVoid.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }

            if (this.HasPermission("Confirm-Dispatch"))
            {
                lcDispatchConfirm.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }

            if (!this.HasPermission("Confirm-Void")) return;
            lcApproval.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lcApprovalCancel.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            dateFrom.Value = dateTo.Value = DateTime.Now;
        }

        private void filterandBindUnconfirmedIssues(string stvNo)
        {
            gridUndispatchedIssues.DataSource = ord.GetUndispatchedIssuesBySTV(CurrentContext.UserId, stvNo);
            gridUndispatchedIssuesView.ExpandAllGroups();
        }
        private void BindUnconfirmedIssues()
        {
            // Get orders which have a pick list generated
            if (lkAccount.EditValue != null)
            {
                var fromDate =Convert.ToDateTime(dateFrom.Value);
                var todate =Convert.ToDateTime(dateTo.Value);
                gridUndispatchedIssues.DataSource = ord.GetUndispatchedIssues(CurrentContext.UserId, _mode, Convert.ToInt32(lkAccount.EditValue), fromDate, todate);
            }
            // Expand the groups
            gridUndispatchedIssuesView.ExpandAllGroups();
        }

        #region STV

        private void OnUndispatchedIssueClicked(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            var dr = gridUndispatchedIssuesView.GetFocusedDataRow();
            _activeSTVID = Convert.ToInt32(dr["STVID"]);
            gridUndispatchedIssueDetails.DataSource = BLL.Issue.GetIssueDetails(_activeSTVID);

           
            User usr = new User();
            //usr.LoadByPrimaryKey(NewMainWindow.UserId);
            usr = CurrentContext.LoggedInUser;
            BLL.Issue stv = new BLL.Issue();
            stv.LoadByPrimaryKey(_activeSTVID);

            var activity = new Activity();
            activity.LoadByPrimaryKey(stv.StoreID);
            lblMode.Text = activity.ModeName ??"-" ;

            lblAccount.Text = activity.AccountName ?? "-";
           
            lblActivity.Text = activity.FullActivityName ?? "-";
            lblSubAccount.Text = activity.SubAccountName ?? "-";

            lblIssueStatus.Text = (string)dr["OrderStatus"] ?? "-";
            lblIssueType.Text = (string) dr["OrderType"] ?? "-";


            if (!stv.IsColumnNull("ReceivingUnitID"))
            {
                var institution = new Institution();
                institution.LoadByPrimaryKey(stv.ReceivingUnitID);

                var ownership = new BLL.OwnershipType();
                ownership.LoadByPrimaryKey(institution.Ownership);

                lblRegion.Text = institution.RegionName ?? "-";
                lblZone.Text = institution.ZoneName ?? "-";
                lblWoreda.Text = institution.WoredaName ?? "-";
                var space = "";
                int length =  (institution.Name).Length;
                if(stv.IsColumnNull("IsReprintOf"))
                    FacilityGroup.Text = institution.Name ?? "" +space.PadRight(180 - length) + "Invoice No: " + stv.IDPrinted.ToString("00000");
                
                lblInstitutionType.Text = institution.InstitutionTypeName;
                lblOwnership.Text = ownership.Name;
            }
            else
            {
                lblRegion.Text =
                    lblZone.Text = lblWoreda.Text  = "NA";
                lblInstitutionType.Text = lblOwnership.Text = "-";
                FacilityGroup.Text = "";
            }
    
            if (!stv.IsColumnNull("PaymentTypeID"))
            {
                var paymentType = new BLL.PaymentType();
                paymentType.LoadByPrimaryKey(stv.PaymentTypeID);
                lblPaymentType.Text = paymentType.Name;
            }
            else
            {
                lblPaymentType.Text = "-";
            }

            if (!stv.IsColumnNull("DocumentTypeID"))
            {
                lblDocumentedType.Text = DocumentType.GetDocumentType(stv.DocumentTypeID).Name;
            }
            else
                lblDocumentedType.Text = "-";

            lblRequistedDate.Text = dr["VoidRequestDateTime"] == DBNull.Value
                ? "NA"
                : DateTime.Parse(dr["VoidRequestDateTime"].ToString()).ToShortDateString();

            lblVoidRequestedBy.Text = dr["VoidRequestedBy"] == DBNull.Value ? "NA" : (string) dr["VoidRequestedBy"];

            


            var user = new BLL.User();
            if (dr["VoidApprovedByUserID"] != DBNull.Value)
            {
                user.LoadByPrimaryKey(Convert.ToInt32(dr["VoidApprovedByUserID"]));
                lblVoidConfirmedBy.Text = user.FullName;
            }
            else
            {
                lblVoidConfirmedBy.Text = "NA";
            }


            lblVoidConfirmedDate.Text = dr["VoidApprovalDateTime"] == DBNull.Value
                ? "NA"
                : DateTime.Parse(dr["VoidApprovalDateTime"].ToString()).ToShortDateString();

            


            stv.LoadLatestReprint();
            txtIssuedBy.Text = usr.FullName ?? "-";
            lblDispatchConfirmedBy.Text = usr.FullName ?? "-";
           
           // txtSTVInvoiceNo.Text = stv.IDPrinted.ToString("00000");
            lblSTVNo.Text = stv.IDPrinted.ToString("00000") ?? "-";
            lblSTVDate.Text = stv.PrintedDate.ToShortDateString() ?? "-";

      
            user.LoadByPrimaryKey(stv.UserID);
            lblSTVPrintedBy.Text = user.FullName ?? "-";

            txtPreprintedInvoiceNo.Text = stv.IsColumnNull("PrePrintedInvoiceNo") ? "" : stv.PrePrintedInvoiceNo.ToString();
        }

        private void btnConfirmIssue_Click(object sender, EventArgs e)
        {
            var Instance = new SoftwareSettings();
            Instance.GetValue("IsCenter");
            dxValidationProvider1.Validate();
            BLL.Issue stv = new BLL.Issue();
            stv.LoadByPrimaryKey(_activeSTVID);
            // bool isValid = dxValidationProvider1.Validate();
            var activity = new Activity();
            activity.LoadByPrimaryKey(stv.StoreID);
           
            if (activity.IsHealthProgram()) // if (!isValid && Mode.IsFreeStore(stv.StoreID))
            {
                dxValidationProvider1.RemoveControlError(txtPreprintedInvoiceNo);
            }

            if (Convert.ToBoolean(Instance.Value)) // When IsCenter is true. txtPreprintedInvoiceNo should be disabled as a requirment
            {
                dxValidationProvider1.RemoveControlError(txtPreprintedInvoiceNo);
            }

            if (Convert.ToBoolean(Instance.Value) && !activity.IsHealthProgram())
            {
                dxValidationProvider1.RemoveControlError(txtPreprintedInvoiceNo);
            }
            if (!Convert.ToBoolean(Instance.Value) && !activity.IsHealthProgram())  //   if (!isValid && !Mode.IsFreeStore(stv.StoreID))
            {
                if (!dxValidationProvider1.Validate())
                    return;
                //XtraMessageBox.Show("Please input the required fields.", "Required Fields Missing", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                //return;
            }
            if (XtraMessageBox.Show("Are you sure you want to confirm this dispatch?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MyGeneration.dOOdads.TransactionMgr mgr = MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgr();
                try
                {
                    mgr.BeginTransaction();
                    //Mark the dispatch as confirmed. (Store the differences in the dispatched values somewhere)
                    int? preprintedID;
                    if (txtPreprintedInvoiceNo.Text == "")
                        preprintedID = null;
                    else
                        preprintedID = int.Parse(txtPreprintedInvoiceNo.Text);

                    if (!stv.MarkAsDispatched(CurrentContext.UserId, preprintedID))
                    {
                        XtraMessageBox.Show("Void request has been sent for this STV, you can't dispatch it!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        throw new Exception("Void request sent on this STV number");
                    }
                    if (_discrepancyIssueDoc.Count > 0)
                    {
                        //Save the discrepancies.
                        BLL.IssueDoc.RecordDiscrepancy(_discrepancyIssueDoc);
                    }
                    this.LogActivity("Confirm-Dispatch", _activeSTVID);
                    mgr.CommitTransaction();
                    XtraMessageBox.Show("STV marked as dispatched!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exp)
                {
                    mgr.RollbackTransaction();
                    XtraMessageBox.Show("System couldn't save the dispatch, Please contact administrator", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ErrorHandler.Handle(exp);
                }
                BindUnconfirmedIssues();
                gridUndispatchedIssueDetails.DataSource = null;
            }

        }

        #endregion

        private void gridView2_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            //What's issued is not the same as what's been printed on the STV
            DataRow dr = gridViewUndispatchedIssueDetails.GetDataRow(e.RowHandle);

            if (e.Column == colActuallyIssuedNoOfPack)
            {
                if (e.Value.ToString() != "" && Convert.ToInt32(e.Value) >= 0)
                {
                    int actuallyIssued = Convert.ToInt32(dr["ActuallyIssuedNoOfPack"]);
                    int noOfPackPrinted = Convert.ToInt32(dr["NoOfPack"]);
                    int issueDocID = Convert.ToInt32(dr["IssueDocID"]);
                    if (actuallyIssued != noOfPackPrinted)
                    {
                        _discrepancyIssueDoc.Add(issueDocID, actuallyIssued);
                    }
                    else
                    {
                        if (_discrepancyIssueDoc.ContainsKey(issueDocID))
                        {
                            _discrepancyIssueDoc.Remove(issueDocID);
                        }
                    }
                }
            }
            dr.EndEdit();
        }

        private void txtFacilityNameFilter_EditValueChanged(object sender, EventArgs e)
        {
            gridUndispatchedIssuesView.ActiveFilterString = string.Format("IDPrinted like '{0}%' or RequestedBy like '{0}%'", txtFacilityNameFilter.Text);
        
        }

        private void btnMarkAsVoid_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Are you sure you want to request a void?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MyGeneration.dOOdads.TransactionMgr mgr = MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgr();
                try
                {
                    mgr.BeginTransaction();
                    BLL.Issue stv = new BLL.Issue();
                    stv.LoadByPrimaryKey(_activeSTVID);
                    stv.SendAVoidRequest(CurrentContext.UserId);
                    this.LogActivity("Request-Void", _activeSTVID);
                    mgr.CommitTransaction();
                    XtraMessageBox.Show("A void request sent!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exp)
                {
                    mgr.RollbackTransaction();
                    XtraMessageBox.Show("System couldn't request a void, Please contact administrator", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ErrorHandler.Handle(exp);
                }

                BindUnconfirmedIssues();
                gridUndispatchedIssueDetails.DataSource = null;
            }
        }

        private void btnCancelVoidRequest_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Are you sure you want to cancel the void request?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MyGeneration.dOOdads.TransactionMgr mgr = MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgr();
                try
                {
                    mgr.BeginTransaction();
                    BLL.Issue stv = new BLL.Issue();
                    stv.LoadByPrimaryKey(_activeSTVID);
                    stv.CancelVoidRequest(CurrentContext.UserId);
                    mgr.CommitTransaction();
                    this.LogActivity("Cancel-Void", _activeSTVID);
                    XtraMessageBox.Show("Void request cancelled!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exp)
                {
                    mgr.RollbackTransaction();
                    XtraMessageBox.Show("System couldn't perform the requested action, Please contact administrator", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ErrorHandler.Handle(exp);
                }

                BindUnconfirmedIssues();
                gridUndispatchedIssueDetails.DataSource = null;
            }
        }

        public void MarkSTVAsVoid(int userID)
        {
            VoidIssueBasesdOnSTVID();
            BLL.Issue stv = new BLL.Issue();
            stv.LoadByPrimaryKey(_activeSTVID);
            stv.IsVoided = true;
            stv.VoidApprovedByUserID = userID;
            stv.VoidApprovalDateTime = DateTimeHelper.ServerDateTime;
            stv.Save();
        }



        private void btnApproveVoidRequest_Click(object sender, EventArgs e)
        {
            BLL.Issue stv = new BLL.Issue();
            stv.LoadByPrimaryKey(_activeSTVID);

            if (!stv.IsColumnNull("VoidRequest") && !stv.VoidRequest)
            {
                XtraMessageBox.Show("There is no void request for this STV", "No Void Request",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                return;
            }

            if (XtraMessageBox.Show("Are you sure you want to void this STV/Invoice?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                MyGeneration.dOOdads.TransactionMgr mgr = MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgr();
                try
                {
                    mgr.BeginTransaction();
                    MarkSTVAsVoid(CurrentContext.UserId);
                    mgr.CommitTransaction();
                    this.LogActivity("Approve-Void", _activeSTVID);
                    XtraMessageBox.Show("STV/Invoice Voided!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exp)
                {
                    mgr.RollbackTransaction();
                    XtraMessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //XtraMessageBox.Show("System couldn't perform the requested action, Please contact administrator", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ErrorHandler.Handle(exp);
                }

                BindUnconfirmedIssues();
                gridUndispatchedIssueDetails.DataSource = null;
            }
        }

        internal void VoidIssueBasesdOnSTVID()
        {
            BLL.IssueDoc issDoc = new IssueDoc();
            issDoc.LoadBySTVID(_activeSTVID);

            while (!issDoc.EOF)
            {
                DeleteAnIssue(issDoc.ID);
                issDoc.MoveNext();
            }
        }

        public void DeleteAnIssue(int issueDociD)
        {
            ReceiveDoc rdoc = new ReceiveDoc();
            ReceivePallet rp = new ReceivePallet();
            IssueDoc idoc = new IssueDoc();
            idoc.LoadByPrimaryKey(issueDociD);

            if (idoc.IsThereSRM)
            {
                throw new Exception("There is an SRM for this issue.  You can't void it.");
            }

            PickListDetail pld = new PickListDetail();
            //pld.LoadByOrderAndItem(idoc.OrderID, idoc.ItemID, idoc.NoOfPack);
            pld.LoadByPrimaryKey(idoc.PLDetailID);

            string RefNo = idoc.RefNo;

            rdoc.LoadByPrimaryKey(idoc.RecievDocID);

            //if (pld.RowCount == 0)
            //{
            //    pld.LoadByOrderAndItem(idoc.OrderID, idoc.ItemID);
            //}

            rp.LoadByReceiveDocID(idoc.RecievDocID);
            PalletLocation pl = new PalletLocation();
            pl.loadByPalletID(rp.PalletID);

            if (pl.RowCount == 0)
            {
                pl.LoadByPrimaryKey(pld.PalletLocationID);
                if (pl.IsColumnNull("PalletID"))
                {
                    pl.PalletID = rp.PalletID;
                    pl.Save();
                }

            }


            if (rp.RowCount == 0)
            {
                XtraMessageBox.Show("You cannot delete this item, please contact the administrator", "Error");
                return;
            }
            if (rp.RowCount > 0)
            {
                rdoc.QuantityLeft += idoc.Quantity;
                rp.Balance += idoc.Quantity;

                //Delete from picklistDetail and add to pickListDetailDeleted
                PickListDetailDeleted.AddNewLog(pld, BLL.CurrentContext.UserId);
                pld.MarkAsDeleted();

                // are we adding it the pick face?
                // if so add it to the balance of the pick face also
                pl.loadByPalletID(rp.PalletID);

                if (pl.RowCount == 0)
                {
                    PutawayLocation plocation = new PutawayLocation(rdoc.ItemID);

                    // we don't have a location for this yet,
                    // select a new location
                    //PutawayLocataion pl = new PutawayLocataion();
                    if (plocation.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        pl.LoadByPrimaryKey(plocation.PalletLocationID);
                        if (pl.RowCount > 0)
                        {
                            pl.PalletID = rp.PalletID;
                            pl.Save();
                        }
                    }
                }

                if (pl.RowCount > 0)
                {

                    PickFace pf = new PickFace();
                    pf.LoadByPalletLocation(pl.ID);
                    if (pf.RowCount > 0)
                    {
                        pf.Balance += Convert.ToInt32(idoc.Quantity);
                        pf.Save();
                    }


                    IssueDocDeleted.AddNewLog(idoc, CurrentContext.UserId);
                    idoc.MarkAsDeleted();
                    rdoc.Save();
                    rp.Save();
                    idoc.Save();
                    pld.Save();
                }
                else
                {
                    XtraMessageBox.Show(
                        "This delete is not successful because a free pick face location was not selected. please select a free location and try again.", "Error Deleteing issue transaction", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

        }

        private void lkAccount_EditValueChanged(object sender, EventArgs e)
        {
            //BindUnconfirmedIssues();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (lkAccount.EditValue != null && dateFrom.Text != null)
            {
                BindUnconfirmedIssues();
            }

            else
            {
                XtraMessageBox.Show("Please Select All Filters!");
            }
        }

        private void btnGoSTV_Click(object sender, EventArgs e)
        {
            if (tEditSTVNo.EditValue == null || Equals(tEditSTVNo.EditValue, ""))
            {
                XtraMessageBox.Show("Please enter STV or Invoice number!", "Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            else
            {
                var stv = tEditSTVNo.EditValue.ToString();
                filterandBindUnconfirmedIssues(stv);
               
            }
            //tEditSTVNo.Text = "";
        }

        private void txtPreprintedInvoiceNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (!char.IsNumber((char) e.KeyValue) && !e.Control && !e.Shift && e.KeyCode != Keys.Back  && e.KeyCode != Keys.Delete)
                e.SuppressKeyPress = true;
        }
    }
}