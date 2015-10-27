using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BLL;
using CalendarLib;
using DevExpress.Utils.StructuredStorage.Internal.Reader;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using HCMIS.Core.Distribution.Services;
using HCMIS.Desktop.Helpers;
using HCMIS.Desktop.ViewHelpers;
using HCMIS.Helpers;
using HCMIS.Desktop.Reports;
using Order = BLL.Order;
using HCMIS.Desktop.Helpers;
using HCMIS.Desktop.Forms.Modals;
using System.IO;
using PickList = BLL.PickList;
using DevExpress.XtraReports.UI;

namespace HCMIS.Desktop.Forms.WorkFlow
{
    /// <summary>
    /// 
    /// </summary>
    [FormIdentifier("IN-IN-IC-CN", "Invoice Form", "Invoice")]
    public partial class InvoiceForm : XtraForm
    {
        #region Member Variables

        // for showing proposed pick list
        DataView _dvOutstandingPickList = new DataView();
        // selected order ID, used on pick list and pick list confirmation screen only.
        int _orderID = 0;

        #endregion

        public InvoiceForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the OrderForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void OrderForm_Load(object sender, EventArgs e)
        {
            SetPermission();
            lkMode.SetupModeEditor().SetDefaultMode();
            BindOutstandingPicklists();
            //Display the check HCTS button based on the mode
            lcOutstandingPicklists.Text = BLL.Settings.IsCenter ? "Issue Order List" : "Outstanding Pick Lists";
        }

        private void SetPermission()
        {
            if (BLL.Settings.UseNewUserManagement)
            {
                btnCancelIssue.Enabled = this.HasPermission("Cancel-Pick-List");
                btnConfirmIssue1.Enabled = this.HasPermission("Print-Invoice");
                btnReturnToApprovalStep.Enabled = this.HasPermission("Return-To-Approval");
            }
        }

        /// <summary>
        /// Binds the outstanding picklists.
        /// </summary>
        private void BindOutstandingPicklists()
        {
            if (lkMode.EditValue != null)
            {
                BLL.Order ord = new BLL.Order();
                // Get orders which have a pick list generated
                gridOutstandingPickLists.DataSource = ord.GetPickListedOrders(CurrentContext.UserId, Convert.ToInt32(lkMode.EditValue));

                gridOutstandingPicklistDetail.DataSource = null;
                // Expand the groups
                gridOutstandingPickListView.ExpandAllGroups();
            }
        }

        #region STV

        /// <summary>
        /// Called when [outstanding picklist selected].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DevExpress.XtraGrid.Views.Grid.RowClickEventArgs" /> instance containing the event data.</param>
        private void OnOutstandingPicklistSelected(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            var dr = gridOutstandingPickListView.GetFocusedDataRow();
            _orderID = Convert.ToInt32(dr["ID"]);

            var order = new BLL.Order();
            order.LoadByPrimaryKey(_orderID);
            
            
            // load payment type options
            int? requestedBy = null;

            var usr = new User();

            lblIssueStatus.Text = (string)dr["OrderStatus"];
            lblIssueTypes.Text = (string) dr["Description"];

            if (!order.IsColumnNull("RequestedBy"))
            {
                var ins = new Institution();
                requestedBy = order.RequestedBy;
                lkPaymentType.Properties.DataSource = PaymentType.GetAllowedTypes(order.FromStore, requestedBy);
                ins.LoadByPrimaryKey(order.RequestedBy);

                try
                { 
                    lblWoreda.Text = ins.WoredaName ?? "-";
                    lblRegion.Text = ins.RegionName ?? "-";
                    lblZone.Text = ins.ZoneName ?? "-";
                    lblInstitutionType.Text = ins.InstitutionTypeName ?? "-";

                    var ownership = new BLL.OwnershipType();
                    if (!ins.IsColumnNull("Ownership"))
                    {
                        ownership.LoadByPrimaryKey(ins.Ownership);
                        lblOwnership.Text = ownership.Name;
                    }
                    
                }
                catch (NullReferenceException ex)
                {
                    //when transfer, institution has no woreda, zone or region, ignore the error
                }
            }
            else
                lblWoreda.Text = lblRegion.Text = lblZone.Text = lblInstitutionType.Text = lblOwnership.Text = "NA";

               
            //usr.LoadByPrimaryKey(NewMainWindow.UserId);
            usr = CurrentContext.LoggedInUser;
            txtIssuedBy.Text = usr.FullName ?? "-";
            
            
            PickList pl = new PickList();
            _dvOutstandingPickList = pl.GetPickListDetailsForOrder(_orderID, CurrentContext.LoggedInUserName);
            gridOutstandingPicklistDetail.DataSource = _dvOutstandingPickList;
            
            

            if (order.FromStore != Mode.Constants.HEALTH_PROGRAM)
            {
                colSKUPicked.Visible = false;
            }
            else
            {
                colSKUPicked.Visible = true;
            }


            txtConfirmFromStore.Text = order.GetFromStore();
            txtConfirmRequestedBy.Text = order.GetRequestedBy();

            int length = order.GetRequestedBy().Length;
          

            string s = "";
            
            HeaderSection.Text = order.GetRequestedBy() + s.PadRight(150-length)+"Order Number: " + order.RefNo;
            
            txtConfirmOrderNumber.Text = order.RefNo;
            //txtConfirmApprovedBy.Text = order.GetApprovedBy() ?? "-";
            lblApprovedBy.Text = order.GetApprovedBy() ?? "-";

            lkPaymentType.EditValue = order.PaymentTypeID;
            // Temporarily copy the STV
            txtIssueRefNo.Text = order.RefNo; //"";
            lblRefNo.Text = order.RefNo ?? "-";

            var paymentType = new BLL.PaymentType();
            paymentType.LoadByPrimaryKey(order.PaymentTypeID);
            lblPaymentType.Text = paymentType.Name ?? "-";

            lblMode.Text = order.GetFromStore() ?? "-";
            lblissuedDate.Text = order.Date.ToShortDateString();
            lblIssuedBy.Text = order.GetFilledBy();
            lblPicklistPrintedDate.Text = pl.PickedDate.ToShortDateString()!="" ? pl.PickedDate.ToShortDateString() : "-";

            var us = new User();
            pl.LoadByOrderID(_orderID);
            if (!pl.IsColumnNull("PickedBy"))
            {
                us.LoadByPrimaryKey(pl.PickedBy);
                lblPicklistConfirmedBy.Text = us.FullName;
            }
            else lblPicklistConfirmedBy.Text = "-";
            
        }

        /// <summary>
        /// Handles the Click event of the btnConfirmIssue control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        /// <exception cref="System.Exception"></exception>
        private void btnConfirmIssue_Click(object sender, EventArgs e)
        {
            // This is where the Issue is actually recorded and the stv is printed.
            // Do all kinds of validations.
            XtraReport STVReport = null; XtraReport DeliveryNoteReport = null;
            btnConfirmIssue1.Enabled = false;
            if (!IssueValid())
            {
                XtraMessageBox.Show("Please Correct the Items Marked in Red before Proceeding with Issue", "Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnConfirmIssue1.Enabled = (BLL.Settings.UseNewUserManagement && this.HasPermission("Print-Invoice")) ? true : (!BLL.Settings.UseNewUserManagement);
                return;
            }

            if (XtraMessageBox.Show("Are You Sure, You want to save this Transaction?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DateTimePickerEx dtDate = ConvertDate.GetCurrentEthiopianDateText();

                DateTime dtCurrent = ConvertDate.DateConverter(dtDate.Text);
                // The User is now sure that the STV has to be printed and that 
                // the order is also good to save.
                // This is the section that does the saving.

                BLL.Order order = new Order();
                order.LoadByPrimaryKey(_orderID);

                // what are the pick lists, do we have devliery notes too?
                DataView dv = _dvOutstandingPickList;
                DataTable dvUnpriced = new DataTable();
                DataTable dvPriced = dv.ToTable();

                if (BLL.Settings.HandleGRV)
                {
                    if (BLL.Settings.IsCenter)
                        dv.RowFilter = "(Cost is null or Cost=0)";
                    else
                        dv.RowFilter = "DeliveryNote = true and (Cost is null or Cost=0)";
                    dvUnpriced = dv.ToTable();

                    dv.RowFilter = "Cost is not null and Cost <> 0";
                    dvPriced = dv.ToTable();
                }
                else
                {
                    dvPriced = dv.ToTable();
                }

                string stvPrinterName = "";
                string deliveryNotePrinter = "";

                if (!ConfirmPrinterSettings(dvPriced, dvUnpriced, out stvPrinterName, out deliveryNotePrinter)) return;
                bool saveSuccessful = false;

                MyGeneration.dOOdads.TransactionMgr mgr = MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgr();
                try
                {
                    if (dvPriced.Rows.Count == 0 && dvUnpriced.Rows.Count == 0) throw new Exception("The Items doesn’t meet the requirement: please check the price status for non-delivery notes!");
                    
                    mgr.BeginTransaction();

                    if (dvPriced.Rows.Count > 0)
                    {
                        STVReport = SaveAndPrintSTV(dvPriced.DefaultView, false, stvPrinterName, dtDate, dtCurrent);
                    }


                    if (dvUnpriced.Rows.Count > 0)
                    {
                        DeliveryNoteReport = SaveAndPrintSTV(dvUnpriced.DefaultView, true, deliveryNotePrinter, dtDate,
                                                         dtCurrent);
                    }
                    var ordr = new Order();
                    ordr.LoadByPrimaryKey(_orderID);
                    
                    if (!ordr.IsColumnNull("OrderTypeID") &&
               
                        (ordr.OrderTypeID == BLL.OrderType.CONSTANTS.ACCOUNT_TO_ACCOUNT_TRANSFER || ordr.OrderTypeID == BLL.OrderType.CONSTANTS.STORE_TO_STORE_TRANSFER))
                    {
                        var transfer = new Transfer();
                        DateTime convertedEthDate = ConvertDate.DateConverter(dtDate.Text);
                        transfer.CommitAccountToAccountTransfer(ordr.ID, CurrentContext.UserId, convertedEthDate);
                    }

                    mgr.CommitTransaction();

                    saveSuccessful = true;

                }
                catch (Exception exp)
                {
                    mgr.RollbackTransaction();
                    //Removed the reset logic
                    //MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgrReset();
                    XtraMessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ErrorHandler.Handle(exp);
                    saveSuccessful = false;
                }

                if (saveSuccessful)
                {
                    if (STVReport != null)
                    {
                        if (InstitutionIType.IsVaccine(GeneralInfo.Current))
                        {
                            for (int i = 0; i < BLL.Settings.STVCopies; i++)
                            {
                                STVReport.Print(stvPrinterName);
                            }
                        }
                        else
                        {
                            STVReport.Print(stvPrinterName);
                        }
                    }

                    if (DeliveryNoteReport != null)
                    { DeliveryNoteReport.Print(deliveryNotePrinter); }

                    XtraMessageBox.Show("Transaction Successfully Saved!", "Success", MessageBoxButtons.OK,
                                                            MessageBoxIcon.Information);
                }

                btnConfirmIssue1.Enabled = (BLL.Settings.UseNewUserManagement && this.HasPermission("Print-Invoice")) ? true : (!BLL.Settings.UseNewUserManagement);
                BindOutstandingPicklists();
                gridOutstandingPicklistDetail.DataSource = null;
                PalletLocation.GarbageCollection();

                if (BLL.Settings.AllowOnlineOrders)
                {
                    Helpers.RRFServiceIntegration.SubmitOnlineIssue(_orderID);
                }

            }
        }

        /// <summary>
        /// Confirms the printer settings.
        /// </summary>
        /// <param name="dvPriced">The dv priced.</param>
        /// <param name="dvUnpriced">The dv unpriced.</param>
        /// <param name="stvPrinterName">Name of the STV printer.</param>
        /// <param name="deliveryNotePrinter">The delivery note printer.</param>
        /// <returns></returns>
        private static bool ConfirmPrinterSettings(DataTable dvPriced, DataTable dvUnpriced, out string stvPrinterName,
                                           out string deliveryNotePrinter)
        {
            // get the printer for the stv.
            PrintDialog dialog = new PrintDialog();
            stvPrinterName = deliveryNotePrinter = "";
            if (dvPriced.Rows.Count > 0 && dialog.ShowDialog() == DialogResult.Cancel)
            {
                return false;
            }

            if (dvPriced.Rows.Count > 0)
            {
                stvPrinterName = dialog.PrinterSettings.PrinterName;
            }

            if (dvUnpriced.Rows.Count > 0)
            {
                if (dvPriced.Rows.Count > 0 &&
                    XtraMessageBox.Show(
                        "This transaction contains both priced items and unpriced items (delivery note). Are you sure you want to proceed?",
                        "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                {
                    return false;
                }

                if (dialog.ShowDialog() == DialogResult.Cancel)
                {
                    return false;
                }
                deliveryNotePrinter = dialog.PrinterSettings.PrinterName;
            }
            return true;
        }

        /// <summary>
        /// Saves the and print STV.
        /// </summary>
        /// <param name="pickListDetail">The pick list detail.</param>
        /// <param name="deliveryNotePrinter">The delivery note printer.</param>
        /// <param name="stvPrinterName">Name of the STV printer.</param>
        /// <param name="dtDate">The dt date.</param>
        /// <param name="dtCurrent">The dt current.</param>
        /// <exception cref="System.Exception"></exception>
        private XtraReport SaveAndPrintSTV(DataView pickListDetail, bool isDeliveryNote, string printerName, DateTimePickerEx dtDate, DateTime dtCurrent)
        {
            HCMIS.Core.Distribution.Services.PrintLogService pLogService = new HCMIS.Core.Distribution.Services.PrintLogService();

            pLogService.StartPrintingSession();

            Order ord = IssueDoc.SaveIssueTransaction(_orderID, ref pickListDetail, txtRemarks.Text,
                                                      CurrentContext.LoggedInUserName, dtCurrent);




            if (pickListDetail.Count == 0)
                throw new Exception("An error occurred during saving the issue.  Please contact your administrator.");

            string sendToString = "";
            BLL.Order ordr = new BLL.Order();
            ordr.LoadByPrimaryKey(_orderID);
            BLL.Institution rus = new Institution();
            if (!ordr.IsColumnNull("RequestedBy"))
            {
                rus.LoadByPrimaryKey(ordr.RequestedBy);
                sendToString = rus.Name;
            }

            else if (!ordr.IsColumnNull("OrderTypeID") &&
                     ordr.OrderTypeID == BLL.OrderType.CONSTANTS.ACCOUNT_TO_ACCOUNT_TRANSFER)
            {
                BLL.Transfer transfer = new Transfer();
                transfer.LoadByOrderID(_orderID);
                var activity = new Activity();
                activity.LoadByPrimaryKey(transfer.ToStoreID);
                sendToString = activity.FullActivityName;
            }

            PickList pl = new PickList();
            pl.LoadByOrderID(ord.ID);

            var xtraReport = new XtraReport();

            if (ord.PaymentTypeID == PaymentType.Constants.CASH)
            {
                xtraReport = FormatCashInvoice(ord, pickListDetail.Table, rus, pl, isDeliveryNote,
                                  printerName, pLogService);
            }
            else if (ord.PaymentTypeID == PaymentType.Constants.CREDIT)
            {
                xtraReport = FormatCreditInvoice(ord, pickListDetail.Table, rus, pl, isDeliveryNote,
                                    printerName, pLogService);
            }
            else if (ord.PaymentTypeID == PaymentType.Constants.STV)
            {
                xtraReport = FormatSTV(ord, pickListDetail.Table, sendToString, pl, isDeliveryNote,
                          printerName,
                          pLogService, _orderID);
            }

            

            SavePdfReport(pLogService, xtraReport);
            pLogService.CommitPrintLog();
            return xtraReport;

        }


        /// <summary>
        /// Formats the STV.
        /// </summary>
        /// <param name="ord">The ord.</param>
        /// <param name="dvPriced">The dv priced.</param>
        /// <param name="stvSentTo">The STV sent to.</param>
        /// <param name="pl">The pl.</param>
        /// <param name="deliveryNote">if set to <c>true</c> [delivery note].</param>
        /// <param name="allowCancelByUser">if set to <c>true</c> [allow cancel by user].</param>
        /// <exception cref="System.Exception"></exception>
        private XtraReport FormatSTV(Order ord, DataTable dvPriced, string stvSentTo, PickList pl, bool deliveryNote, string printerName, HCMIS.Core.Distribution.Services.PrintLogService pLogService, int orderID)
        {
            bool hasInsurance = chkIncludeInsurance.Checked;
            string accountName = txtConfirmFromStore.Text;
            string transferType = null;

            int? orderTypeID = null;
            BLL.Order order = new Order();
            order.LoadByPrimaryKey(orderID);

            if (!order.IsColumnNull("OrderTypeID"))
                orderTypeID = Convert.ToInt32(ord.GetColumn("OrderTypeID"));
            string transferDetail = "";
            if (orderTypeID.HasValue)
            {
                BLL.Transfer transfer = new Transfer();

                if (orderTypeID == OrderType.CONSTANTS.STORE_TO_STORE_TRANSFER)
                {
                    transfer.LoadByOrderID(orderID);
                    PhysicalStore toStore = new PhysicalStore();
                    toStore.LoadByPrimaryKey(transfer.ToPhysicalStoreID);
                    BLL.Warehouse toWarehouse = new BLL.Warehouse();
                    toWarehouse.LoadByPrimaryKey(toStore.PhysicalStoreTypeID);
                    transferType = "Store to Store Transfer";
                    stvSentTo = toWarehouse.Name;
                }

                if (orderTypeID == OrderType.CONSTANTS.ACCOUNT_TO_ACCOUNT_TRANSFER)
                {
                    transfer.LoadByOrderID(orderID);
                    Activity fromActivity = new Activity();
                    fromActivity.LoadByPrimaryKey(transfer.FromStoreID);
                    Activity toActivity = new Activity();
                    toActivity.LoadByPrimaryKey(transfer.ToStoreID);
                    transferType = "Account to Account Transfer";
                    transferDetail = string.Format("From: {0} To: {1}", fromActivity.FullActivityName, toActivity.FullActivityName);
                }
            }


            if (!deliveryNote)
            {
                if(InstitutionIType.IsVaccine(GeneralInfo.Current))
                {
                    return WorkflowReportFactory.CreateModel22(ord, dvPriced, stvSentTo, pl.ID, null, false, true, hasInsurance, transferType);
                }
                var stvReport = WorkflowReportFactory.CreateSTVonHeadedPaper(ord, dvPriced, stvSentTo, pl.ID, null, false, true, hasInsurance, transferType);
                if (transferDetail != "")
                {
                    stvReport.TransferDetails.Text = transferDetail;
                    stvReport.TransferDetails.Visible = true;
                }
                else
                {
                    stvReport.TransferDetails.Visible = false;
                }

                return stvReport;
            }
            else
            {
                return WorkflowReportFactory.CreateDeliveryNote(ord, dvPriced, stvSentTo, pl.ID, null, false, true, hasInsurance, transferType);
             
            }

        }



        private static void SavePdfReport(PrintLogService pLogService, XtraReport stvReport)
        {
            // This STV Log is Highly experimental, 
            // TODO: remove this try catch when the method is stable.
            try
            {
                DataTable dtbl = (DataTable)stvReport.DataSource;
                var refNumber = (from v in dtbl.AsEnumerable()
                                 select Convert.ToInt32(v["STVNumber"])).Distinct().ToList();
                int i = 0;
                foreach (DevExpress.XtraPrinting.Page page in stvReport.Pages)
                {
                    HCMIS.Desktop.Reports.STVonHeadedPaper xReport = new HCMIS.Desktop.Reports.STVonHeadedPaper();
                    xReport.Pages.Add(page);
                    MemoryStream stream = new MemoryStream();
                    xReport.ExportToPdf(stream);
                    pLogService.SaveLog(stream, "STV", true, refNumber[i], CurrentContext.UserId,
                                        BLL.DateTimeHelper.ServerDateTime);
                    i++;
                }
            }
            catch
            {
                //
            }
        }

        /// <summary>
        /// Formats the credit invoice.
        /// </summary>
        /// <param name="ord">The ord.</param>
        /// <param name="dvPriced">The dv priced.</param>
        /// <param name="rus">The rus.</param>
        /// <param name="pl">The pl.</param>
        /// <param name="deliveryNote">if set to <c>true</c> [delivery note].</param>
        /// <param name="allowCancelByUser">if set to <c>true</c> [allow cancel by user].</param>
        /// <exception cref="System.Exception"></exception>
        private XtraReport FormatCreditInvoice(Order ord, DataTable dvPriced, BLL.Institution rus, PickList pl, bool deliveryNote, string printerName, HCMIS.Core.Distribution.Services.PrintLogService pLogService)
        {
            if (BLL.Settings.UseSmallerCreditPrintout)
            {
                return FormatCreditInvoice_Smaller(dvPriced, ord, pl, rus, deliveryNote, printerName, pLogService);
            }
            
                return FormatCreditInvoice_Larger(dvPriced, ord, pl, rus, deliveryNote, printerName, pLogService);
           
        }

        private XtraReport FormatCreditInvoice_Larger(DataTable dvPriced, Order ord, PickList pl, Institution rus, bool deliveryNote, string printerName, HCMIS.Core.Distribution.Services.PrintLogService pLogService)
        {
            bool hasInsurance = chkIncludeInsurance.Checked;
            string activityName = txtConfirmFromStore.Text;
           return WorkflowReportFactory.CreateCreditInvoice(dvPriced, ord, pl, rus, deliveryNote, hasInsurance,
                                                                      activityName, true, null);
        }



        /// <summary>
        /// Formats the credit invoice.
        /// </summary>
        /// <param name="ord">The ord.</param>
        /// <param name="dvPriced">The dv priced.</param>
        /// <param name="rus">The rus.</param>
        /// <param name="pl">The pl.</param>
        /// <param name="deliveryNote">if set to <c>true</c> [delivery note].</param>
        /// <param name="allowCancelByUser">if set to <c>true</c> [allow cancel by user].</param>
        /// <exception cref="System.Exception"></exception>
        private XtraReport FormatCreditInvoice_Smaller(DataTable dvPriced, Order ord, PickList pl, Institution rus, bool deliveryNote, string printerName, HCMIS.Core.Distribution.Services.PrintLogService pLogService)
        {
            string activityName = txtConfirmFromStore.Text;
            bool hasInsurnance = chkIncludeInsurance.Checked;
            return WorkflowReportFactory.CreateCreditInvoiceSmaller(dvPriced, ord, pl, rus, deliveryNote, hasInsurnance, activityName);

        }

        /// <summary>
        /// Formats the cash invoice.
        /// </summary>
        /// <param name="ord">The ord.</param>
        /// <param name="dvPriced">The dv priced.</param>
        /// <param name="rus">The rus.</param>
        /// <param name="pl">The pl.</param>
        /// <param name="deliveryNote">if set to <c>true</c> [delivery note].</param>
        /// <param name="allowCancelByUser">if set to <c>true</c> [allow cancel by user].</param>
        /// <exception cref="System.Exception"></exception>
        private XtraReport FormatCashInvoice(Order ord, DataTable dvPriced, BLL.Institution rus, PickList pl, bool deliveryNote, string printerName, HCMIS.Core.Distribution.Services.PrintLogService pLogService)
        {
            if (BLL.Settings.UseSmallerCashPrintout)
            {
                return FormatCashInvoice_Smaller(ord, dvPriced, rus, pl, deliveryNote, printerName, pLogService);
            }
            
                return FormatCashInvoice_Larger(ord, dvPriced, rus, pl, deliveryNote, printerName, pLogService);
            
        }


        /// <summary>
        /// Formats the cash invoice.
        /// </summary>
        /// <param name="ord">The ord.</param>
        /// <param name="dvPriced">The dv priced.</param>
        /// <param name="rus">The rus.</param>
        /// <param name="pl">The pl.</param>
        /// <param name="deliveryNote">if set to <c>true</c> [delivery note].</param>
        /// <param name="allowCancelByUser">if set to <c>true</c> [allow cancel by user].</param>
        /// <exception cref="System.Exception"></exception>
        private XtraReport FormatCashInvoice_Larger(Order ord, DataTable dvPriced, BLL.Institution rus, PickList pl, bool deliveryNote, string printerName, HCMIS.Core.Distribution.Services.PrintLogService pLogService)
        {
            string activityName = txtConfirmFromStore.Text;
            bool hasInsurnance = chkIncludeInsurance.Checked;
            return WorkflowReportFactory.CreateCashInvoice(ord, dvPriced, rus, pl, deliveryNote, hasInsurnance,
                                                                    activityName, true, null);
          
        }

        /// <summary>
        /// Formats the cash invoice.
        /// </summary>
        /// <param name="ord">The ord.</param>
        /// <param name="dvPriced">The dv priced.</param>
        /// <param name="rus">The rus.</param>
        /// <param name="pl">The pl.</param>
        /// <param name="deliveryNote">if set to <c>true</c> [delivery note].</param>
        /// <param name="allowCancelByUser">if set to <c>true</c> [allow cancel by user].</param>
        /// <exception cref="System.Exception"></exception>
        private XtraReport FormatCashInvoice_Smaller(Order ord, DataTable dvPriced, BLL.Institution rus, PickList pl, bool deliveryNote, string printerName, HCMIS.Core.Distribution.Services.PrintLogService pLogService)
        {
            string activityName = txtConfirmFromStore.Text;
            bool hasInsurnance = chkIncludeInsurance.Checked;
            return WorkflowReportFactory.CreateCashInvoiceSmaller(ord, dvPriced, rus, pl, deliveryNote, hasInsurnance, activityName);          
        }



        /// <summary>
        /// Issues the valid.
        /// </summary>
        /// <returns></returns>
        private bool IssueValid()
        {
            //check approved against 
            // check if the order has not alrady been printed
            Order Order = new Order();
            Order.LoadByPrimaryKey(_orderID);

            if (Order.OrderStatusID < OrderStatus.Constant.PICK_LIST_CONFIRMED)
            {
                XtraMessageBox.Show("Order is not yet ready for printing Invoice");
                return false;
            }
            else if (Order.OrderStatusID == OrderStatus.Constant.ISSUED)
            {
                XtraMessageBox.Show("This Order has already been printed. Please select another one.");
                return false;
            }
            else if (Order.OrderStatusID == OrderStatus.Constant.CANCELED)
            {
                XtraMessageBox.Show("This Order has been canceled. Please select another one.");
                return false;
            }

            bool valid = true;
            DataView pl = gridOutstandingPicklistDetail.DataSource as DataView;
            foreach (DataRowView drv in pl)
            {
                ReceiveDoc rd = new ReceiveDoc();
                drv.Row.ClearErrors();
                if (drv["SKUPICKED"] == null || drv["SKUPICKED"] == DBNull.Value)
                {
                    drv.Row.SetColumnError("SKUPICKED", @"Field cannot be left empty");
                    valid = false;
                }
                else if (Convert.ToInt32(drv["SKUPICKED"]) > Convert.ToInt32(drv["SKUTOPICK"]))
                {
                    drv.Row.SetColumnError("SKUPICKED", @"You cannot issue more amount than the Approved Quantity");
                    valid = false;
                }

                else if (BLL.Settings.BlockWhenExpectingPriceChange && BLL.ReceiveDoc.DoesPriceNeedToBeChanged(int.Parse(drv["StoreID"].ToString()), int.Parse(drv["ItemID"].ToString()), int.Parse(drv["UnitID"].ToString()), int.Parse(drv["ManufacturerID"].ToString())) && Convert.ToInt32(drv["SKUPICKED"]) > 0) //rd.IsInNonPricedItemsList(int.Parse(drv["ItemID"].ToString())) && Convert.ToInt32(drv["SKUPICKED"]) > 0)
                {
                    drv.Row.SetColumnError("FullItemName", @"Price Pending!");
                    Item itm = new Item();
                    itm.LoadByPrimaryKey(int.Parse(drv["ItemID"].ToString()));
                    XtraMessageBox.Show(string.Format("The item {0} cannot be issued because it is waiting for price change.", itm.FullItemName), "Price Pending", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    valid = false;
                }
            }

            if (Order.PaymentTypeID != PaymentType.Constants.CASH && Order.PaymentTypeID != PaymentType.Constants.CREDIT && Order.PaymentTypeID != PaymentType.Constants.STV)
            {
                //TODO: This needs to be handled well.
                XtraMessageBox.Show(
                    string.Format("PaymentTypeID has a problem.  The order has a payment type id of {0}",
                                  Order.PaymentTypeID.ToString()), "Payment Type ID Problem");
                btnConfirmIssue1.Enabled = (BLL.Settings.UseNewUserManagement && this.HasPermission("Print-Invoice")) ? true : (!BLL.Settings.UseNewUserManagement);
                valid = false;
            }

            if (valid)
            {
                valid = dxValidationProvider1.Validate();
            }

            return valid;
        }

        #endregion

        private void gridView2_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            // SKU or BU unit value in confirm pick list was changed.
            DataRow dr = gridViewConfirmation.GetDataRow(e.RowHandle);
            if (e.Column == colBUPicked)
            {
                // convert the 
                if (e.Value.ToString() != "" && Convert.ToInt32(e.Value) >= 0)
                {
                    int skubu = Convert.ToInt32(dr["SKUBU"]);
                    dr["SKUPICKED"] = Convert.ToDecimal(e.Value) / skubu;
                    dr["BUPICKED"] = Convert.ToDecimal(dr["SKUPICKED"]) * skubu;
                }
            }
            else if (e.Column == colSKUPicked)
            {
                if (e.Value.ToString() != "" && Convert.ToInt32(e.Value) >= 0)
                {
                    int skubu = Convert.ToInt32(dr["SKUBU"]);
                    dr["BUPICKED"] = skubu * Convert.ToDecimal(e.Value);
                }
            }
            dr.EndEdit();
            // what the hell.
        }

        /// <summary>
        /// Handles the Click event of the btnCancelIssue control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnCancelIssue_Click(object sender, EventArgs e)
        {
            DataRow dr = gridOutstandingPickListView.GetFocusedDataRow();
            if (dr != null)
            {
                if (DialogResult.Yes == XtraMessageBox.Show("Are you sure you want to cancel this Issue? you will not be able to undo cancelation!", "Confirm cancelation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    _orderID = Convert.ToInt32(dr["ID"]);
                    PickList pl = new PickList();
                    pl.CancelOrderWithPickList(_orderID);
                    BindOutstandingPicklists();
                    gridOutstandingPicklistDetail.DataSource = null;
                    XtraMessageBox.Show("The Pick List has been Canceled", "Pick List has been Canceled!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// Handles the EditValueChanging event of the cboCashCredit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraEditors.Controls.ChangingEventArgs" /> instance containing the event data.</param>
        private void cboCashCredit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (!lkPaymentType.EditorContainsFocus)
            {
                return;
            }
            if (XtraMessageBox.Show("Are you sure to change the payment method?", "HCMIS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                e.Cancel = true;
        }

        /// <summary>
        /// Handles the EditValueChanged event of the txtFacilityNameFilter control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void txtFacilityNameFilter_EditValueChanged(object sender, EventArgs e)
        {
            gridOutstandingPickListView.ActiveFilterString = string.Format("RefNo like '%{0}%' or RequestedBy like '%{0}%' or RouteName like '%{0}%'", txtFacilityNameFilter.Text);
        }

        /// <summary>
        /// Handles the Click event of the btnReturnToApprovalStep control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnReturnToApprovalStep_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Are you sure you would like to return this order to the picklist?", "Confirmation", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                BLL.Order order = new Order();
                order.LoadByPrimaryKey(_orderID);
                order.ReturnBacktoPicklistConfirmation();
                BindOutstandingPicklists();
                gridOutstandingPicklistDetail.DataSource = null;
            }
        }

        /// <summary>
        /// Handles the DoubleClick event of the gridOutstandingPicklistDetail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void gridOutstandingPicklistDetail_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridViewConfirmation.GetFocusedDataRow();
            if (dr != null)
            {
                OrderDetailForm orderDetailForm = new OrderDetailForm(Convert.ToInt32(dr["ItemID"]), Convert.ToInt32(dr["UnitID"]));
                orderDetailForm.StartPosition = FormStartPosition.CenterParent;
                this.Enabled = false;
                orderDetailForm.ShowDialog();
                this.Enabled = true;
            }
        }

        /// <summary>
        /// Handles the EditValueChanged event of the lkMode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void lkMode_EditValueChanged(object sender, EventArgs e)
        {
            BindOutstandingPicklists();
        }

        private void lkPaymentType_EditValueChanged(object sender, EventArgs e)
        {
            //Dangerous Code That enable to change order PayementType
        }
    }
}