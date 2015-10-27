using System;
using System.Data;
using System.Windows.Forms;
using BLL;
using BLL.WorkFlow.Issue;
using CalendarLib;
using DAL;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraReports.UI;
using HCMIS.Desktop.Helpers;
using HCMIS.Desktop.Reports;
using HCMIS.Desktop.ViewHelpers;
using HCMIS.Helpers;
using HCMIS.Desktop.Forms.Modals;
using PickList = BLL.PickList;

namespace HCMIS.Desktop.Forms.Logs
{
    /// <summary>
    /// 
    /// </summary>
    [FormIdentifier("AL-IT-IT-RP", "Issue Transaction Log", "")]
    public partial class LogIssues : XtraForm
    {
        public LogIssues()
        {
            InitializeComponent();
        }
        #region Private members

        private bool includeInsurance = true;
        #endregion
        #region Helpers
        #endregion

        private int? _stvLogIdChosen;
        private int? _reprintId;
        private bool _isConvertedDn;

        /// <summary>
        /// Handles the Load event of the ManageItems control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void ManageItems_Load(object sender, EventArgs e)
        {
            btnPrint.Enabled = this.HasPermission("Print");
            btnReprint.Enabled = this.HasPermission("Re-Print");
            btnExport.Enabled = this.HasPermission("Export");

            if (BLL.Settings.ShowMissingSTVsOnIssueLog)
            {
                grpOrdersWithMissingSTVs.Visibility = LayoutVisibility.Always;
                // DO the binding
                gridMissingOrders.DataSource = Order.GetMissingSTVs(CurrentContext.UserId);
            }
            else
            {
                grpOrdersWithMissingSTVs.Visibility = LayoutVisibility.Never;
            }


            lkAccount.SetupAccountEditor().SetDefaultAccount();


            var paymentType = new PaymentType();
            paymentType.LoadAll();
            lkPaymentTypeFilter.Properties.DataSource = paymentType.DefaultView;
            // Bind the routes
            var route = new Route();
            route.LoadAll();
            lkRoute.Properties.DataSource = route.DefaultView;

            // make the date defaults the current date
            dtFrom.Value = DateTimeHelper.ServerDateTime;
            dtTo.Value = DateTimeHelper.ServerDateTime;
        }


        /// <summary>
        /// Handles the Click event of the btnExport control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            dtDate.Value = DateTimeHelper.ServerDateTime;
            dtDate.CustomFormat = "MM/dd/yyyy";

            var sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                gridTransactions.ExportToXlsx(sfd.FileName);
            }
        }

        /// <summary>
        /// Handles the ShowGridMenu event of the gridView1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see>
        ///                       <cref>GridMenuEventArgs</cref>
        ///                     </see> instance containing the event data.</param>
        private void gridView1_ShowGridMenu(object sender, GridMenuEventArgs e)
        {
            var view = sender as GridView;
            if (view != null && e != null)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);
                if (hitInfo.InRow)
                {
                    view.FocusedRowHandle = hitInfo.RowHandle;
                    contextMenuStrip2.Show(view.GridControl, e.Point);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the tspDelete control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void tspDelete_Click(object sender, EventArgs e)
        {

            if ((!BLL.Settings.UseNewUserManagement && CurrentContext.LoggedInUser.UserType == UserType.Constants.DISTRIBUTION_MANAGER_WITH_DELETE) || (BLL.Settings.UseNewUserManagement && this.HasPermission("Delete")))
            {
                //This is Strange i think this is why most of the bug for inconsistancy happens because we didn't use a Transaction
                //On The PicklistDetail ReceivepalletI 
                if (
                    XtraMessageBox.Show(
                        "Are you sure you want to delete this transaction? You will not be able to undo this.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataRow dr = gridViewTransaction.GetFocusedDataRow();
                    int issueID = Convert.ToInt32(dr["ID"]);
                    DeleteIssueDoc(issueID);
                    gridViewReferences_FocusedRowChanged(null, null);
                }

            }
            else
            {
                XtraMessageBox.Show(
                    "You don't have privilages to delete this transaction. Please contact Administrator to enable this.",
                    "No privilage to delete");
            }
        }

        public static void DeleteIssueDoc(int issueID)
        {
            MyGeneration.dOOdads.TransactionMgr tranMgr =
                MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgr();

            try
            {
                tranMgr.BeginTransaction();


                var pld = new PickListDetail();
                var rdoc = new ReceiveDoc();
                var rp = new ReceivePallet();
                var idoc = new IssueDoc();

                idoc.LoadByPrimaryKey(issueID);
                pld.LoadByPrimaryKey(idoc.PLDetailID);
                rdoc.LoadByPrimaryKey(idoc.RecievDocID);

                rp.LoadByPrimaryKey(pld.ReceivePalletID);
                var pl = new PalletLocation();
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
                    // in error cases this could lead to a number greater than the received quantity
                    // instead of being an error, it should just delete the respective issue and 
                    // adjust the remaining quantity to the received quantity.
                    if (rdoc.QuantityLeft + idoc.Quantity > rdoc.Quantity)
                    {
                        rdoc.QuantityLeft = rp.Balance = rdoc.Quantity;
                    }
                    else
                    {
                        rdoc.QuantityLeft += idoc.Quantity;
                        rp.Balance += idoc.Quantity;
                    }

                    //Delete from picklistDetail and add to pickListDetailDeleted
                    PickListDetailDeleted.AddNewLog(pld, BLL.CurrentContext.UserId);
                    pld.MarkAsDeleted();

                    // are we adding it the pick face?
                    // if so add it to the balance of the pick face also
                    pl.loadByPalletID(rp.PalletID);

                    if (pl.RowCount == 0)
                    {
                        var plocation = new PutawayLocation(rdoc.ItemID);

                        // we don't have a location for this yet,
                        // select a new location
                        //PutawayLocataion pl = new PutawayLocataion();
                        if (plocation.ShowDialog() == DialogResult.OK)
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
                        var pf = new PickFace();
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


                        // now refresh the window
                        XtraMessageBox.Show("Issue Deleted!", "Confirmation", MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                        tranMgr.CommitTransaction();


                    }
                }
                else
                {
                    XtraMessageBox.Show(
                        "This delete is not successfull because a free pick face location was not selected. please select a free location and try again.",
                        "Error Deleteing issue transaction", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tranMgr.RollbackTransaction();
                }
            }
            catch
            {
                XtraMessageBox.Show("This delete is not successfull", "Warning ...", MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                tranMgr.RollbackTransaction();
            }
        }

        /// <summary>
        /// Handles the EditValueChanged event of the lkAccounts control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void lkAccounts_EditValueChanged(object sender, EventArgs e)
        {
            FilterStvLog();
        }

        /// <summary>
        /// Filters the STV log.
        /// </summary>
        private void FilterStvLog()
        {
            if (lkAccount.EditValue != null)
            {
                var iss = new IssueDoc();
                gridReferences.DataSource = lkRoute.EditValue == null ? iss.GetDistinctIssueDocmentsForAccount(Convert.ToInt32(lkAccount.EditValue), chkDeliveryNotes.Checked) : iss.GetDistinctIssueDocmentsForAccountAndRoute(Convert.ToInt32(lkAccount.EditValue), Convert.ToInt32(lkRoute.EditValue), chkDeliveryNotes.Checked);

                // apply the filter
                txtFilterFacilityName_EditValueChanged(null, null);
                // show details of the first entry in the table
               // gridViewReferences_FocusedRowChanged(null, null);

            }
        }

        /// <summary>
        /// Handles the Click event of the btnReprint control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnReprint_Click(object sender, EventArgs e)
        {
            var issue = new Issue();
            issue.LoadByPrimaryKey(_stvLogIdChosen.Value);
            if (!Validate(issue))
                return;

            var orderId = Convert.ToInt32(gridViewTransaction.GetFocusedDataRow()["OrderID"]);
            var pl = new PickList();
            var dv = pl.GetPickedOrderDetailForOrder(_stvLogIdChosen.Value, false);
            MyGeneration.dOOdads.TransactionMgr mgr = MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgr();

            XtraReport xtraReport;
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }


            try
            {
                mgr.BeginTransaction();

                xtraReport = RePrintSTV(dv, orderId, pl, _stvLogIdChosen, _isConvertedDn);

                mgr.CommitTransaction();
            }
            catch (Exception exception)
            {
                mgr.RollbackTransaction();
                XtraMessageBox.Show("Print Problem:" + exception.Message, "Print Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            if (xtraReport != null)
            {
                xtraReport.Print(printDialog.PrinterSettings.PrinterName);
            }

            FilterStvLog();
        }

        private bool Validate(Issue issue)
        {
            string whatToPrint = BLL.Settings.IsRdfMode ? "Invoice" : "STV";


            if (!issue.IsColumnNull("IsVoided") && issue.IsVoided)
            {
                XtraMessageBox.Show("You cannot print an STV that has been voided.", "Can't reprint this.", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                return false;
            }
            if (!issue.IsColumnNull("IsDeliveryNote") && issue.IsDeliveryNote && !_isConvertedDn &&
                !issue.IsColumnNull("HasDeliveryNoteBeenConverted") && issue.HasDeliveryNoteBeenConverted)
            {
                XtraMessageBox.Show("You cannot print an Delivery Note that has been Converted.", "Can't reprint this.",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (
                XtraMessageBox.Show(string.Format("Are you sure you want to reprint an {0}?", whatToPrint),
                                    "Confirmation Needed", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                System.Windows.Forms.DialogResult.No)
            {
                return false;
            }

            if (
                XtraMessageBox.Show(
                    string.Format(
                        "Warning: You are about to print an {0} which is going to be given a new {0} number.  Are you sure you want to continue?",
                        whatToPrint), "Confirmation Needed", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==
                System.Windows.Forms.DialogResult.No)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Handles the Click event of the btnPrint control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataRow dr = gridViewTransaction.GetFocusedDataRow();
            PickList pl = new PickList();
            PickListDetail pld = new PickListDetail();
            int orderId = Convert.ToInt32(dr["OrderID"]);
            DataView dv = pl.GetPickedOrderDetailForOrder(_stvLogIdChosen.Value, false);

            XtraReport xtraReport = RePrintSTV(dv, orderId, pl, _stvLogIdChosen, false, false);
            if (xtraReport != null)
            {
                xtraReport.PrintDialog();
            }

        }

        /// <summary>
        /// Re print STV.
        /// </summary>
        /// <param name="dv">The dv.</param>
        /// <param name="orderId">The order id.</param>
        /// <param name="pl">The pl.</param>
        /// <param name="stvLogID">The STV log ID.</param>
        /// <param name="isConversion">if set to <c>true</c> [is conversion].</param>
        /// <param name="generateNewPrintID">if set to <c>true</c> [generate new print ID].</param>
        //public XtraReport RePrintSTV(DataView dv,int orderId, PickList pl,int? stvLogID, bool isConversion, bool generateNewPrintID = true)
        //{
        //     var includeInsurance =XtraMessageBox.Show("Include insurance?", "Insurance",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes;
        //     var ord = new Order();
        //    ord.LoadByPrimaryKey(orderId);
	//    var order = new Order();
        //    order.LoadByPrimaryKey(orderId);

        //    if (!order.IsPaymentTypeValid())
        //    {

        //        //TODO: This needs to be handled well.
        //        throw new Exception(
        //            string.Format("PaymentTypeID has a problem.  The order has a payment type id of {0}",
        //                          ord.PaymentTypeID));

        //    }

        //    var stores = new Activity();

        //    stores.LoadByPrimaryKey(order.FromStore);
        //    var textDeliveryNote = "";
        //    var sendToString = GetReceivingUnitName(order);
        //    if (stvLogID != null)
        //    {
        //        var stvLog = new Issue();
        //        stvLog.LoadByPrimaryKey(stvLogID.Value);
        //        if (!stvLog.IsColumnNull("IsDeliveryNote") && stvLog.IsDeliveryNote && isConversion)
        //        {
        //            textDeliveryNote = stvLog.IDPrinted.ToString("00000");
        //        }
        //    }

        //    if (PaymentType.Constants.CASH == ord.PaymentTypeID)
        //    {
        //        var rus = new Institution();
        //        rus.LoadByPrimaryKey(order.RequestedBy);
        //        var stvReport = new HCMIS.Desktop.Reports.CashInvoice(CurrentContext.LoggedInUserName);
        //        pl.LoadByOrderID(orderId);
        //        PrepareTheReport(stvReport);
        //        stvReport.DeliveryNoteNo.Text = textDeliveryNote;
        //        stvReport.DataSource = Order.ReorganizeDataViewForSTVPrint_Program(dv, ord.ID, pl.ID, CurrentContext.UserId, stvLogID, isConversion, generateNewPrintID, includeInsurance);
        //        stvReport.From.Text = GeneralInfo.Current.HospitalName;
        //        stvReport.To.Text = sendToString;
        //        stvReport.TIN.Text = rus.TinNo;
        //        stvReport.VAT.Text = rus.VATNo;
        //        stvReport.Town.Text = rus.Town;
        //        stvReport.Woreda.Text = rus.WoredaText;
        //        stvReport.Zone.Text = rus.ZoneText;
        //        stvReport.Region.Text = rus.Region;
       //        stvReport.License.Text = (!rus.IsColumnNull("Ownership") && rus.IsPrivatelyOwned) ? rus.LicenseNo : (!ord.IsColumnNull("LetterNo")) ? ord.LetterNo : "";
        //        //stvReport.Program.Text = stores.StoreName;
        //        DateTimePickerEx dtDate = new DateTimePickerEx();
        //        dtDate.Value = DateTimeHelper.ServerDateTime;
        //        stvReport.Date.Text = dtDate.Text;

        //        return stvReport;
        //    }
        //    else if (PaymentType.Constants.CREDIT == ord.PaymentTypeID)
        //    {
        //        var rus = new Institution();
        //        rus.LoadByPrimaryKey(order.RequestedBy);
        //        HCMIS.Desktop.Reports.CreditInvoice stvReport =
        //            new HCMIS.Desktop.Reports.CreditInvoice(CurrentContext.LoggedInUserName);
        //        pl.LoadByOrderID(orderId);
        //        PrepareTheReport(stvReport);
        //        stvReport.DeliveryNoteNo.Text = textDeliveryNote;
        //        stvReport.DataSource = Order.ReorganizeDataViewForSTVPrint_Program(dv, ord.ID, pl.ID,
        //            CurrentContext.UserId, stvLogID, isConversion, generateNewPrintID, includeInsurance);
        //        stvReport.From.Text = GeneralInfo.Current.HospitalName;
        //        stvReport.To.Text = sendToString;

        //        //stvReport.Region.Text = rus.Woreda;
        //        stvReport.Zone.Text = rus.Town;
        //        stvReport.Letter.Text = ord.LetterNo;
        //        //stvReport.Program.Text = stores.StoreName;
        //        DateTimePickerEx dtDate = new DateTimePickerEx();
        //        dtDate.Value = DateTimeHelper.ServerDateTime;
        //        stvReport.Date.Text = dtDate.Text;
        //    }
        //}

        /// <summary>
        /// Re print STV.
        /// </summary>
        /// <param name="dv">The dv.</param>
        /// <param name="orderId">The order id.</param>
        /// <param name="pl">The pl.</param>
        /// <param name="stvLogID">The STV log ID.</param>
        /// <param name="isConversion">if set to <c>true</c> [is conversion].</param>
        /// <param name="generateNewPrintID">if set to <c>true</c> [generate new print ID].</param>
        public XtraReport RePrintSTV(DataView dv, int orderId, PickList pl, int? stvLogID, bool isConversion, bool generateNewPrintID = true)
        {
            HCMIS.Core.Distribution.Services.PrintLogService pLogService = new HCMIS.Core.Distribution.Services.PrintLogService();

            pLogService.StartPrintingSession();

            includeInsurance = XtraMessageBox.Show("Include insurance?", "Insurance", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
            var ord = new Order();
            ord.LoadByPrimaryKey(orderId);
            //loading two times
            var order = new Order();
            order.LoadByPrimaryKey(orderId);

            if (!order.IsPaymentTypeValid())
            {

                //TODO: This needs to be handled well.
                throw new Exception(
                    string.Format("PaymentTypeID has a problem.  The order has a payment type id of {0}", ord.PaymentTypeID));
            }

            var rus = new Institution();
            if (ord.PaymentTypeID == PaymentType.Constants.CASH || ord.PaymentTypeID == PaymentType.Constants.CREDIT)
            {
                rus.LoadByPrimaryKey(order.RequestedBy);
            }

            var stores = new Activity();

            stores.LoadByPrimaryKey(order.FromStore);
            var textDeliveryNote = "";
            var sendToString = GetReceivingUnitName(order);
            if (stvLogID != null)
            {
                var stvLog = new Issue();
                stvLog.LoadByPrimaryKey(stvLogID.Value);
                if (!stvLog.IsColumnNull("IsDeliveryNote") && stvLog.IsDeliveryNote && isConversion)
                {
                    textDeliveryNote = stvLog.IDPrinted.ToString("00000");
                }
            }
            var xtraReport = new XtraReport();
            string stvPrinterName = "";
            if (PaymentType.Constants.CASH == ord.PaymentTypeID && !chkDeliveryNotes.Checked)
            {
                xtraReport = FormatCashRePrintInvoice(ord, dv.Table, rus, pl, false, stvPrinterName, pLogService, _stvLogIdChosen);
                pLogService.CommitPrintLog();
                return xtraReport;
            }

            else if (PaymentType.Constants.CASH == ord.PaymentTypeID && chkDeliveryNotes.Checked)
            {
                xtraReport = FormatCashRePrintInvoice(ord, pl.DefaultView.ToTable(), rus, pl, true, stvPrinterName, pLogService, _stvLogIdChosen);
                pLogService.CommitPrintLog();
                return xtraReport;
            }

            else if (PaymentType.Constants.CREDIT == ord.PaymentTypeID && !chkDeliveryNotes.Checked)
            {
                xtraReport = FormatCreditRePrintInvoice(ord, pl.DefaultView.ToTable(), rus, pl, false, stvPrinterName, pLogService, _stvLogIdChosen);
                pLogService.CommitPrintLog();
                return xtraReport;
            }

            else if (PaymentType.Constants.CREDIT == ord.PaymentTypeID && chkDeliveryNotes.Checked)
            {
                xtraReport = FormatCreditRePrintInvoice(ord, pl.DefaultView.ToTable(), rus, pl, true, stvPrinterName, pLogService, _stvLogIdChosen);
                pLogService.CommitPrintLog();
                return xtraReport;
            }
            //if (PaymentType.Constants.CASH == ord.PaymentTypeID)
            //{
            //    var stvReport = new HCMIS.Desktop.Reports.CashInvoice(CurrentContext.LoggedInUserName);
            //    pl.LoadByOrderID(orderId);
            //    PrepareTheReport(stvReport);
            //    stvReport.DeliveryNoteNo.Text = textDeliveryNote;
            //    stvReport.DataSource = Order.ReorganizeDataViewForSTVPrint_Program(dv, ord.ID, pl.ID, CurrentContext.UserId, stvLogID, isConversion, generateNewPrintID, includeInsurance);
            //    stvReport.From.Text = GeneralInfo.Current.HospitalName;
            //    stvReport.To.Text = sendToString;
            //    stvReport.TIN.Text = rus.TinNo;
            //    stvReport.VAT.Text = rus.VATNo;
            //    stvReport.Town.Text = rus.Town;
            //    stvReport.Woreda.Text = rus.WoredaText;
            //    stvReport.Zone.Text = rus.ZoneText;
            //    stvReport.Region.Text = rus.Region;

            //    stvReport.License.Text = (!rus.IsColumnNull("Ownership") && rus.IsPrivatelyOwned) ? rus.LicenseNo : (!ord.IsColumnNull("LetterNo")) ? ord.LetterNo : "";
            //    //stvReport.Program.Text = stores.StoreName;
            //    DateTimePickerEx dtDate = new DateTimePickerEx();
            //    dtDate.Value = DateTimeHelper.ServerDateTime;
            //    stvReport.Date.Text = dtDate.Text;

            //    return stvReport;
            //}
            //else if (PaymentType.Constants.CREDIT == ord.PaymentTypeID)
            //{
            //    HCMIS.Desktop.Reports.CreditInvoice stvReport = new HCMIS.Desktop.Reports.CreditInvoice(CurrentContext.LoggedInUserName);
            //    pl.LoadByOrderID(orderId);
            //    PrepareTheReport(stvReport);
            //    stvReport.DeliveryNoteNo.Text = textDeliveryNote;
            //    stvReport.DataSource = Order.ReorganizeDataViewForSTVPrint_Program(dv, ord.ID, pl.ID, CurrentContext.UserId, stvLogID, isConversion, generateNewPrintID, includeInsurance);
            //    stvReport.From.Text = GeneralInfo.Current.HospitalName;
            //    stvReport.To.Text = sendToString;

            //    //stvReport.Region.Text = rus.Woreda;
            //    stvReport.Zone.Text = rus.Town;
            //    stvReport.Letter.Text = ord.LetterNo;
            //    //stvReport.Program.Text = stores.StoreName;
            //    DateTimePickerEx dtDate = new DateTimePickerEx();
            //    dtDate.Value = DateTimeHelper.ServerDateTime;
            //    stvReport.Date.Text = dtDate.Text;


            //    return stvReport;
            //}
            else if (PaymentType.Constants.STV == ord.PaymentTypeID && generateNewPrintID)
            {
                pl.LoadByOrderID(orderId);

                // check if this is a delivery note
                Issue sl = new Issue();
                sl.LoadByPrimaryKey(stvLogID.Value);
                if (!sl.IsColumnNull("IsDeliveryNote") && sl.IsDeliveryNote && !isConversion)
                {
                    var stvReport = new HCMIS.Desktop.Reports.DeliveryNoteForIssue(ord.ID, includeInsurance, CurrentContext.LoggedInUserName);


                    PrepareTheReport(stvReport);
                    stvReport.DataSource = Order.ReorganizeDataViewForSTVPrint_Program(dv, ord.ID, pl.ID, CurrentContext.UserId, stvLogID, isConversion, generateNewPrintID, includeInsurance);
                    stvReport.From.Text = GeneralInfo.Current.HospitalName;
                    stvReport.To.Text = sendToString;
                    stvReport.STVNO.Text = Issue.GetLogFor(ord.RefNo);
                    //stvReport.Date.Text = @"(Reprint) " + Convert.ToDateTime(dv[0]["IssueDate"]).ToString("MM/dd/yyyy");
                    DateTimePickerEx dtDate = new DateTimePickerEx();
                    dtDate.Value = DateTimeHelper.ServerDateTime;
                    stvReport.Date.Text = dtDate.Text;
                    //stvReport.ShowPreview();

                    return stvReport;
                }
                else
                {
                    var stvReport = new HCMIS.Desktop.Reports.STVonHeadedPaper(ord.ID, includeInsurance, CurrentContext.LoggedInUserName);
                    stvReport.DeliveryNoteNo.Text = textDeliveryNote;

                    PrepareTheReport(stvReport);
                    stvReport.DataSource = Order.ReorganizeDataViewForSTVPrint_Program(dv, ord.ID, pl.ID, CurrentContext.UserId, stvLogID, isConversion, generateNewPrintID, includeInsurance);
                    stvReport.From.Text = GeneralInfo.Current.HospitalName;
                    stvReport.To.Text = sendToString;
                    stvReport.STVNO.Text = Issue.GetLogFor(ord.RefNo);
                    //stvReport.Date.Text = @"(Reprint) " + Convert.ToDateTime(dv[0]["IssueDate"]).ToString("MM/dd/yyyy");
                    DateTimePickerEx dtDate = new DateTimePickerEx();
                    dtDate.Value = DateTimeHelper.ServerDateTime;
                    stvReport.Date.Text = dtDate.Text;
                    //stvReport.ShowPreview();

                    return stvReport;
                }
            }
            else if (PaymentType.Constants.STV == ord.PaymentTypeID && !generateNewPrintID)
            {
                pl.LoadByOrderID(orderId);
                //System.Windows.Forms.DialogResult result = XtraMessageBox.Show("Include insurance?", "Insurance",
                //MessageBoxButtons.YesNo,
                //MessageBoxIcon.Question);
                Issue log = new Issue();
                log.LoadByPrimaryKey((_reprintId != null) ? _reprintId.Value : stvLogID.Value);


                if (log.IsColumnNull("HasInsurance") || BLL.Settings.IsCenter) //If it is null, we have no idea about what the insurance status was.  So let's ask the user.
                {
                    System.Windows.Forms.DialogResult result = XtraMessageBox.Show("Include insurance?", "Insurance",
                                                                                   MessageBoxButtons.YesNo,
                                                                                   MessageBoxIcon.Question);
                    includeInsurance = result == DialogResult.Yes ? true : false;
                    log.HasInsurance = includeInsurance;
                    log.Save();
                }
                else
                {
                    includeInsurance = log.HasInsurance;
                }

                //bool includeInsurance = (!log.IsColumnNull("HasInsurance"))? log.HasInsurance : false;
                var stvReport = new HCMIS.Desktop.Reports.STVonA4(ord.ID, includeInsurance,
                                                                  CurrentContext.LoggedInUserName);
                stvReport.DeliveryNoteNo.Text = textDeliveryNote;

                PrepareTheReport(stvReport);
                stvReport.DataSource = Order.ReorganizeDataViewForSTVPrint_Program(dv, ord.ID, pl.ID, CurrentContext.UserId, (_reprintId != null) ? _reprintId : stvLogID, isConversion, generateNewPrintID, includeInsurance);
                stvReport.From.Text = GeneralInfo.Current.HospitalName;
                stvReport.To.Text = sendToString;
                //stvReport.STVNO.Text =  //STVLog.GetLogFor(ord.RefNo);
                //stvReport.Date.Text = @"(Reprint) " + Convert.ToDateTime(dv[0]["IssueDate"]).ToString("MM/dd/yyyy");
                DateTimePickerEx dtDate = new DateTimePickerEx();
                dtDate.Value = DateTimeHelper.ServerDateTime;
                stvReport.Date.Text = dtDate.Text;
                return stvReport;
            }
            return null;
        }

        private XtraReport FormatCashRePrintInvoice(Order ord, DataTable dvPriced, BLL.Institution rus, PickList pl, bool deliveryNote, string printerName, HCMIS.Core.Distribution.Services.PrintLogService pLogService, int? stvLogID)
        {
            if (BLL.Settings.UseSmallerCashPrintout)
            {
                return FormatCashRePrintInvoice_Smaller(ord, dvPriced, rus, pl, deliveryNote, printerName, pLogService, _stvLogIdChosen);
            }

            return FormatCashRePrintInvoice_Larger(ord, dvPriced, rus, pl, deliveryNote, printerName, pLogService, _stvLogIdChosen);

        }

        private XtraReport FormatCashRePrintInvoice_Smaller(Order ord, DataTable dvPriced, BLL.Institution rus, PickList pl, bool deliveryNote, string printerName, HCMIS.Core.Distribution.Services.PrintLogService pLogService, int? stvLogID)
        {
            string activityName = "";
            bool hasInsurnance = includeInsurance;
            return WorkflowReportFactory.CreateCashReprintInvoiceSmaller(ord, dvPriced, rus, pl, deliveryNote, hasInsurnance, activityName, _stvLogIdChosen);

        }

        private XtraReport FormatCashRePrintInvoice_Larger(Order ord, DataTable dvPriced, BLL.Institution rus, PickList pl, bool deliveryNote, string printerName, HCMIS.Core.Distribution.Services.PrintLogService pLogService, int? stvLogID)
        {
            string activityName = "";
            bool hasInsurnance = includeInsurance;
            return WorkflowReportFactory.CreateCashRePrintInvoiceLarger(ord, dvPriced, rus, pl, deliveryNote, hasInsurnance, activityName, true, _stvLogIdChosen);

        }

        private XtraReport FormatCreditRePrintInvoice(Order ord, DataTable dvPriced, BLL.Institution rus, PickList pl, bool deliveryNote, string printerName, HCMIS.Core.Distribution.Services.PrintLogService pLogService, int? stvLogID)
        {
            if (BLL.Settings.UseSmallerCreditPrintout)
            {
                return FormatCreditRePrintInvoice_Smaller(dvPriced, ord, pl, rus, deliveryNote, printerName, pLogService, _stvLogIdChosen);
            }

            return FormatCreditRePrintInvoice_Larger(dvPriced, ord, pl, rus, deliveryNote, printerName, pLogService, _stvLogIdChosen);

        }

        private XtraReport FormatCreditRePrintInvoice_Smaller(DataTable dvPriced, Order ord, PickList pl, Institution rus, bool deliveryNote, string printerName, HCMIS.Core.Distribution.Services.PrintLogService pLogService, int? stvLogID)
        {
            string activityName = "";
            bool hasInsurnance = includeInsurance;
            return WorkflowReportFactory.CreateCreditRePrintInvoiceSmaller(dvPriced, ord, pl, rus, deliveryNote, hasInsurnance, activityName, _stvLogIdChosen);

        }

        private XtraReport FormatCreditRePrintInvoice_Larger(DataTable dvPriced, Order ord, PickList pl, Institution rus, bool deliveryNote, string printerName, HCMIS.Core.Distribution.Services.PrintLogService pLogService, int? stvLogID)
        {
            string activityName = "";
            bool hasInsurance = includeInsurance;
            return WorkflowReportFactory.CreateCreditRePrintInvoiceLarger(dvPriced, ord, pl, rus, deliveryNote, hasInsurance,
                                                                       activityName, true, _stvLogIdChosen);
        }




        private static string GetReceivingUnitName(Order order)
        {

            if (!order.IsColumnNull("RequestedBy"))
            {
                var rus = new Institution();
                rus.LoadByPrimaryKey(order.RequestedBy);
                return rus.Name;
            }

            if (!order.IsColumnNull("OrderTypeID") && order.OrderTypeID == OrderType.CONSTANTS.ACCOUNT_TO_ACCOUNT_TRANSFER)
            {
                var transfer = new Transfer();
                transfer.LoadByOrderID(order.ID);

                var activity = new Activity();
                activity.LoadByPrimaryKey(transfer.ToStoreID);
                return activity.FullActivityName;
            }
            return "";
        }

        /// <summary>
        /// Prepares the report.
        /// </summary>
        /// <param name="stvReport">The STV report.</param>
        private static void PrepareTheReport(DevExpress.XtraReports.UI.XtraReport stvReport)
        {
            if (BLL.Settings.UseCustomSizedPaperForPrinting)
            {
                stvReport.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
                stvReport.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                stvReport.PageHeight = Convert.ToInt32(BLL.Settings.PaperHeight);
                stvReport.PageWidth = Convert.ToInt32(BLL.Settings.PaperWidth);
            }
        }

        /// <summary>
        /// Handles the EditValueChanged event of the lkRoute control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void lkRoute_EditValueChanged(object sender, EventArgs e)
        {
            FilterStvLog();
        }

        /// <summary>
        /// Handles the FocusedRowChanged event of the gridViewReferences control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs" /> instance containing the event data.</param>
        private void gridViewReferences_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e != null && e.PrevFocusedRowHandle < -1)
                return;

            dtDate.Value = DateTimeHelper.ServerDateTime;
            _reprintId = null;
            DataRow dr = gridViewReferences.GetFocusedDataRow();
            if (dr == null)
            {
                return;
            }

            string[] referenceNo = new string[2];
            referenceNo[0] = dr["RefNo"].ToString();

            if (Convert.ToBoolean(dr["isConvertedDN"]))
            {
                _isConvertedDn = true;
                _stvLogIdChosen = (int?)dr["IsReprintOf"];
            }
            else if (dr != null && dr["ID"] != DBNull.Value)
            {
                _isConvertedDn = false;
                _stvLogIdChosen = (int?)dr["ID"];
            }

            UpdateReprintedNumbers(dr);

            // Enable and disable STV reprint
            // STV SHouldn't be reprinted off a reprint.
            if (dr["IsReprintOf"] != DBNull.Value && !Convert.ToBoolean(dr["isConvertedDN"]))
            {
                btnExport.Enabled = btnReprint.Enabled = false;
                var permission = (BLL.Settings.UseNewUserManagement) ? this.HasPermission("Print") : true;
                btnPrint.Enabled = permission;
                _reprintId = _stvLogIdChosen;
                _stvLogIdChosen = Convert.ToInt32(dr["IsReprintOf"]);
            }
            else if (dr["IsDeliveryNote"] != DBNull.Value && Convert.ToBoolean(dr["IsDeliveryNote"]))
            {
                btnExport.Enabled = false;
                btnReprint.Enabled = (BLL.Settings.UseNewUserManagement) ? this.HasPermission("Re-Print") : true;
                btnPrint.Enabled = false;
            }
            else
            {
                btnPrint.Enabled = this.HasPermission("Print");
                btnReprint.Enabled = this.HasPermission("Re-Print");
                btnExport.Enabled = this.HasPermission("Export");
            }

            if (_stvLogIdChosen != null)
            {
                Issue log = new Issue();
                log.LoadByPrimaryKey(_stvLogIdChosen.Value);


                Institution rus = new Institution();
                IssueDoc iss = new IssueDoc();
                if (!log.IsColumnNull("ReceivingUnitID"))
                {
                    rus.LoadByPrimaryKey(log.ReceivingUnitID);
                    //FacilityName.Text = rus.Name;

                    HeaderSection.Text = rus.Name;


                    var activity = new Activity();
                    activity.LoadByPrimaryKey(log.StoreID);
                    lblActivity.Text = activity.Name;
                    lblSubAccount.Text = activity.SubAccountName;
                    lblMode.Text = activity.ModeName;
                    lblAccount.Text = activity.AccountName;

                    lblRegion.Text = rus.RegionName;
                    lblWoreda.Text = rus.WoredaName;
                    lblZone.Text = rus.ZoneName;
                    lblInstType.Text = rus.InstitutionTypeName;
                    
                    var ownership = new OwnershipType();
                    ownership.LoadByPrimaryKey(rus.Ownership);
                    lblOwnership.Text = ownership.Name;

                    lblVoidConDate.Text = (dr["approvalDate"]) != DBNull.Value ? Convert.ToDateTime(dr["approvalDate"]).ToShortDateString(): "-";
                    lblIssueType.Text = (string)dr["OrderType"];
                    User user = new User();

                    if (dr["approvedBy"] != DBNull.Value)
                    {
                        user.LoadByPrimaryKey(Convert.ToInt32(dr["approvedBy"]));
                        lblConfirmedBy.Text = user.FullName;
                    }
                    else 
                    {
                        lblConfirmedBy.Text = "-";
                    }

                    var doc = new DocumentType();
                    doc.LoadByPrimaryKey(log.DocumentTypeID);
                    lblDocType.Text = doc.Name;


                    lblPrintedDate.Text = log.PrintedDate.ToShortDateString();
                    
                    

                    var pt = new PaymentType();

                    if (!rus.IsColumnNull("PaymentTypeID"))
                    {
                        pt.LoadByPrimaryKey(rus.PaymentTypeID);
                        lblPaymentType.Text = pt.Name;
                    }

                    else
                    {
                        lblPaymentType.Text = "-";
                    }

                    
                    // Show user name
                    
                    user.LoadByPrimaryKey(log.UserID);
                    lblPrintedBy.Text = (user.FullName == "") ? user.UserName : user.FullName;

                    // show contact person
                    PickList pl = new PickList();
                    pl.LoadByPrimaryKey(log.PickListID);
                    Order order = new Order();
                    order.LoadByPrimaryKey(pl.OrderID);

                    var os = new OrderStatus();
                    os.LoadByPrimaryKey(order.OrderStatusID);
                    lblIssueStatus.Text = os.OrderStatus;


                    if (!order.IsColumnNull("ContactPerson"))
                    {
                        lblRecivedBy.Text = order.ContactPerson;
                    }
                    else
                    {
                        lblRecivedBy.Text = @"-";
                    }

                    lblReceivedDate.Text = order.EurDate.ToShortDateString();


                }

                dtDate.Value = log.PrintedDate;
                //PrintedDate.Text = dtDate.Text;
                lblPrintedDate.Text = dtDate.Text;

                gridTransactions.DataSource = iss.GetIssueBySTV(_stvLogIdChosen.Value);

                layoutUnconfirmedSTVs.Visibility = LayoutVisibility.Never;
                if (BLL.Settings.ShowMissingSTVsOnIssueLog)
                {
                    DataView view = iss.GetPossibleUnconfirmedIssues(_stvLogIdChosen.Value);
                    if (view.Count > 0)
                    {
                        gridUnconfirmed.DataSource = view;
                        layoutUnconfirmedSTVs.Visibility = LayoutVisibility.Always;
                    }
                    else
                    {
                        layoutUnconfirmedSTVs.Visibility = LayoutVisibility.Never;
                    }
                }


            }



        }

        private void UpdateReprintedNumbers(DataRow dr)
        {
            // Show the reprinted STVs .. if any
            if (Convert.ToInt32(dr["HasRePrints"]) > 0)
            {
                Issue log = new Issue();
                log.LoadAllReprints(Convert.ToInt32(dr["ID"]));
               
                lblReprintInfo.Text = "Was reprinted in : ";
                int i = 0;
                while (!log.EOF)
                {
                    lblReprintInfo.Text += ((i++ == 0) ? "" : ", ") + log.IDPrinted.ToString("00000");
                    log.MoveNext();
                }
            }
            else
            {
                lblReprintInfo.Text = " ";
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the chkDeliveryNotes control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void chkDeliveryNotes_CheckedChanged(object sender, EventArgs e)
        {
            FilterStvLog();
        }

        /// <summary>
        /// Handles the EditValueChanged event of the txtFilterFacilityName control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void txtFilterFacilityName_EditValueChanged(object sender, EventArgs e)
        {
            ApplySearchAndFilter();

        }

        /// <summary>
        /// Handles the EditValueChanged event of the lkPaymentTypeFilter control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void lkPaymentTypeFilter_EditValueChanged(object sender, EventArgs e)
        {
            ApplySearchAndFilter();
        }

        /// <summary>
        /// Applies the search and filter.
        /// </summary>
        private void ApplySearchAndFilter()
        {

            string filterString = string.Format("ReceivingUnit like '{0}%' or RefNo like '%{0}%' or STV like '%{0}%'", txtFilterFacilityName.Text);
            if (lkPaymentTypeFilter.EditValue != null)
            {
                filterString += string.Format(" and paymenttypeid = {0}", lkPaymentTypeFilter.EditValue);
            }
            gridViewReferences.ActiveFilterString = filterString;
        }

        private void gridViewMissingOrders_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            // disable all the buttons.
            DataRow dataRow = gridViewMissingOrders.GetFocusedDataRow();
            if (dataRow != null)
            {
                btnExport.Enabled = btnPrint.Enabled = btnReprint.Enabled = false;

                // now just show the details of the order
                IssueDoc issueDoc = new IssueDoc();
                issueDoc.LoadMissingByOrderID(Convert.ToInt32(dataRow["ID"]));
                gridTransactions.DataSource = issueDoc.DefaultView;
            }
        }

        private void printSTVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRow dataRow = gridViewMissingOrders.GetFocusedDataRow();
            if (dataRow != null)
            {
                if (XtraMessageBox.Show("Are you sure you would like to print this Order?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                }
            }
        }

        private void gridViewMissingOrders_RowClick(object sender, RowClickEventArgs e)
        {
            gridViewMissingOrders_FocusedRowChanged(null, null);
        }



        private void unconfirmedContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // check if this user can delete stuff
            //if (NewMainWindow.LoggedInUser.UserType != UserType.Constants.DISTRIBUTION_MANAGER_WITH_DELETE)
            {
                // e.Cancel = true;
            }

        }

        private void unconfirmedMenuClicked_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            DataRow dataRow = gridUnconfirmedView.GetFocusedDataRow();
            if (dataRow != null)
            {
                if (e.ClickedItem.Text == "Delete")
                {
                    if (DialogResult.Yes ==
                        XtraMessageBox.Show("Are you sure you would like to delete this?", "Confirmation",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        DeleteIssueDoc(Convert.ToInt32(dataRow["ID"]));
                        // Refresh it
                        gridViewReferences_FocusedRowChanged(null, null);
                        //XtraMessageBox.Show("Issue has been deleted");
                    }
                }
                else if (e.ClickedItem.Text == "Confirm")
                {

                    IssueDoc doc = new IssueDoc();
                    doc.LoadByPrimaryKey(Convert.ToInt32(dataRow["ID"]));

                    // do some validations
                    if (doc.IsColumnNull("STVID"))
                    {
                        doc.STVID = _stvLogIdChosen.Value;
                        doc.Save();
                    }

                    // refresh
                    XtraMessageBox.Show("You have confirmed the STV", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gridViewReferences_FocusedRowChanged(null, null);
                }
            }
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void labelControl1_Click_1(object sender, EventArgs e)
        {

        }
    }
}