using System;
using System.Data;
using System.Drawing.Printing;
using System.Windows.Forms;
using BLL;
using CalendarLib;
using DevExpress.XtraReports.UI;
using HCMIS.Reports.Reports;
using HCMIS.Reports.Workflow;

namespace HCMIS.Desktop.Reports
{
    public class WorkflowReportFactory
    {

        #region Receiving Reports


        public static XtraReport CreateGRNFPrintout(int receiptConfirmationPrintoutID)
        {
            BLL.ReceiptConfirmationPrintout receiptPrintout = new BLL.ReceiptConfirmationPrintout();
            receiptPrintout.LoadByPrimaryKey(receiptConfirmationPrintoutID);

            FiscalYear fiscalYear = new FiscalYear();
            fiscalYear.LoadByPrimaryKey(receiptPrintout.FiscalYearID);

            return CreateGRNFPrintout(receiptPrintout.ReceiptID, receiptPrintout.IDPrinted, true, fiscalYear);
        }

        /// <summary>
        /// Returns an extra report containing the GRNF.
        /// This function is used for creating the report for the first time as well (Not just export). Which is why we can't
        /// just use the overload with the ReceiptConfirmationPrintoutID as a parameter.
        /// </summary>
        /// <param name="receiptID"></param>
        /// <param name="IDPrinted">Use this if you're trying to get a GRNF printed previously using some ID</param>
        /// <param name="isDocumentBrowser">Use this For Docuement Browser </param>
        /// <returns></returns>
        public static XtraReport CreateGRNFPrintout(int receiptID, int? IDPrinted, bool isDocumentBrowser, FiscalYear fiscalYear)
        {
            ReceiptConfirmationPrintoutStore printout = new ReceiptConfirmationPrintoutStore(CurrentContext.LoggedInUserName);
            BLL.ReceiptConfirmationPrintout rc = new BLL.ReceiptConfirmationPrintout();

            printout.BranchName.Text = GeneralInfo.Current.HospitalName;
            printout.xrGRVLabel.Text = "GRNF No.";
            int printedID;

            BLL.ReceiveDoc rDoc = new ReceiveDoc();
            rDoc.LoadByReceiptID(receiptID);

            var activity = new Activity();
            activity.LoadByPrimaryKey(rDoc.StoreID);
            var supplier = new Supplier();
            supplier.LoadByPrimaryKey(rDoc.SupplierID);

            var hsup = new Supplier();
            DataTable homeOffice = hsup.GetHubHeadOffice();


           if (supplier.ID == (int) homeOffice.Rows[0]["SupplierID"] && !Settings.IsCenter)
            {
                printout.ReportType = ReceiptConfirmationPrintoutStore.GRNFReportType.IGRV;
            }
           else if (supplier.ID != (int)homeOffice.Rows[0]["SupplierID"])
           {
               printout.ReportType = ReceiptConfirmationPrintoutStore.GRNFReportType.GRV;
           }
            if (rDoc.RowCount == 0 && isDocumentBrowser)
            {
                rDoc.LoadDeletedByReceiptID(receiptID);
            }
            else if (rDoc.RowCount == 0)
            {
                throw new Exception("This Receipt Doesn't have corresponding Receipt Doc Entries.");
            }

            if (rDoc.ReturnedStock)
            {
                BLL.Institution ru = new Institution();
                BLL.IssueDoc issueDoc = new IssueDoc();
                if (!rDoc.IsColumnNull("ReturnedFromIssueDocID"))
                {
                    issueDoc.LoadByPrimaryKey(rDoc.ReturnedFromIssueDocID);
                    ru.LoadByPrimaryKey(issueDoc.ReceivingUnitID);
                }
                else
                {
                    BLL.PO po = new PO();
                    po.LoadByReceiptID(receiptID);
                    ru.LoadByPrimaryKey(Int32.Parse(po.RefNo));
                }

                printout.xrFromFacilityValue.Text = ru.Name;
                printout.ReportType = ReceiptConfirmationPrintoutStore.GRNFReportType.SRM;
            }
            
            // determine if this is a transfer? account to account or store to store

            Receipt receipt = new Receipt();
            receipt.LoadByPrimaryKey(receiptID);


            printedID = rc.PrepareDataForPrintout(receiptID, CurrentContext.UserId, false, 1 , IDPrinted, null, fiscalYear);
            DataTable dataTable = rc.DefaultView.ToTable();
            printout.DataSource = dataTable;
            printout.xrLabelStoreName.Text = activity.FullActivityName;

            ReceiveDocConfirmation receiveDocConfirmation = new ReceiveDocConfirmation();
            DataTable Users = receiveDocConfirmation.GetUserNamebyReceipt(receiptID);

            if (Users.Rows.Count > 0)
            {
                printout.PreparedBy.Text = Users.Rows[0]["ReceivedBy"].ToString();
                printout.CheckedBy.Text = Users.Rows[0]["ConfirmedBy"].ToString();
            }

            if (ReceiveDoc.IsThereShortageOrDamage(receiptID))
            {
                ReceiptConfirmationShortagePrintout printoutShortage =
                    new ReceiptConfirmationShortagePrintout();

                rc.PrepareDataForPrintout(receiptID, CurrentContext.UserId, true, 1, printedID, null, fiscalYear);
                printoutShortage.DataSource = rc.DefaultView.ToTable();
                printout.xrShortageReport.ReportSource = printoutShortage;
                printout.PrintingSystem.ContinuousPageNumbering = true;
            }
            else
            {
                printout.ReportFooter.Visible = false;
            }



            CalendarLib.DateTimePickerEx dtDate = new CalendarLib.DateTimePickerEx();
            //dtDate.CustomFormat = "dd/MM/yyyy";
            dtDate.Value = rDoc.EurDate;
            printout.Date.Text = dtDate.Text;
            if (InstitutionIType.IsVaccine(GeneralInfo.Current))
            {
                return CreateModel19Printout(dataTable.DefaultView.ToTable(), dtDate.Text);
            }
            return printout;
        }

        public static XtraReport CreateModel19Printout(DataTable dataTable, string date)
        {
            var generalinfo = new GeneralInfo();
            generalinfo.LoadAll();

            var model19report = new Model19Report(generalinfo.HospitalName, date, generalinfo.GetLogo()) { DataSource = dataTable };
            return model19report;
        }


        public static XtraReport CreateCostAnalysis(int receiptConfirmationPrintoutID)
        {
            BLL.ReceiptConfirmationPrintout receiptPrintout = new BLL.ReceiptConfirmationPrintout();
            receiptPrintout.LoadByPrimaryKey(receiptConfirmationPrintoutID);
            if (BLL.Settings.IsCenter)
            {
                return GetCostBuildUpPrintout(receiptPrintout.IDPrinted.ToString("00000"), receiptPrintout.ReceiptID);
            }
            return GetCostAnalysisPrintout(receiptPrintout.IDPrinted.ToString("00000"), receiptPrintout.ReceiptID);
        }



        /// <summary>
        /// Only for the exporting of Receipt Printouts (GRV, iGRV, SRM, Delivery Note)
        /// </summary>
        /// <param name="receiptConfirmationPrintoutID"></param>
        /// <returns></returns>

        public static XtraReport CreateReceiptPrintout(string printedBy, int receiptConfirmationPrintoutID)
        {
            BLL.ReceiptConfirmationPrintout rcp = new BLL.ReceiptConfirmationPrintout();
            rcp.LoadByPrimaryKey(receiptConfirmationPrintoutID);
            FiscalYear fiscalYear = new FiscalYear();
            fiscalYear.LoadByPrimaryKey(rcp.FiscalYearID);
            if (rcp.RowCount > 0 && !rcp.IsColumnNull("ReceiptID"))
            {
                return PrintReceiptConfirmation(printedBy, rcp.ReceiptID, rcp.ID, true, fiscalYear);
            }
            return null;
        }

        public static XtraReport PrintReceiptConfirmation(string printedBy, int receiptID, int? previousReceiptConfirmationPrintoutID, bool forExporting, FiscalYear fiscalYear)
        {
            var rcPrevious = new BLL.ReceiptConfirmationPrintout();
            int? idToBePrintedOut = null;

            if (forExporting && previousReceiptConfirmationPrintoutID.HasValue)
            {
                rcPrevious.LoadByPrimaryKey(previousReceiptConfirmationPrintoutID.Value);
                idToBePrintedOut = rcPrevious.IDPrinted;
            }

            var rc = new BLL.ReceiptConfirmationPrintout();
            var printout =
                new HCMIS.Desktop.Reports.ReceiptConfirmationPrintout(printedBy);

            var srmPrintout = new HCMIS.Desktop.Reports.SRMPrintout(printedBy);

            var receiveDoc = new ReceiveDoc();
            var receipt = new BLL.Receipt();

            receipt.LoadByPrimaryKey(receiptID);
            receiveDoc.LoadByReceiptID(receiptID);

            var referenceNumber = receiveDoc.RefNo;
            var activity = new Activity();
            activity.LoadByPrimaryKey(receiveDoc.StoreID);
            var supplier = new Supplier();

            supplier.LoadByPrimaryKey(receiveDoc.SupplierID);
            int printedID = 0;

            string GRNFNo = fiscalYear.GetCode(BLL.ReceiptConfirmationPrintout.GetGRNFNo(receiptID));

            if (receipt.ReceiptTypeID == ReceiptType.CONSTANTS.STANDARD_RECEIPT || receipt.ReceiptTypeID == ReceiptType.CONSTANTS.DELIVERY_NOTE || receipt.ReceiptTypeID == ReceiptType.CONSTANTS.ACCOUNT_TO_ACCOUNT_TRANSFER)
            {
                if (!String.IsNullOrEmpty(GeneralInfo.Current.HospitalName))
                {
                    printout.BranchName.Text = GeneralInfo.Current.HospitalName;
                }
                else
                {
                    throw new Exception("Branch name could not be read from the database.");
                }

                PrepareGRVPrintout(printout);
                //  String reference = gridReceiveView.GetFocusedDataRow()["RefNo"].ToString();

                if (supplier.SupplierTypeID == SupplierType.CONSTANTS.HOME_OFFICE ||
                    supplier.SupplierTypeID == SupplierType.CONSTANTS.HUBS ||
                    supplier.SupplierTypeID == SupplierType.CONSTANTS.ACCOUNTS ||
                    supplier.SupplierTypeID == SupplierType.CONSTANTS.STORES)
                {
                    printout.xrGRVLabel.Text = "iGRV No.";
                    printout.xrAir.Visible = false;
                    printout.xrAirValue.Visible = false;
                    printout.xrTransit.Visible = false;
                    printout.xrTransitValue.Visible = false;
                    printout.xrInsurance.Visible = false;
                    printout.xrInsuranceValue.Visible = false;
                    printout.xrNumberOfCases.Visible = false;
                    printout.xrNumberOfCasesValue.Visible = false;
                    printout.xrInvoiceNo.Text = "STV No.";
                    printout.xrPurchaseOrderNo.Visible = false;
                    printout.xrPurchaseOrderNoValue.Visible = false;

                    printout.xrLabelGRNF.Text = GRNFNo;
                    printout.xrSTV.Visible = false;
                    printout.xrSTVNoValue.Visible = false;
                    printedID = rc.PrepareDataForPrintout(receiptID, CurrentContext.UserId, false, 4,
                                                          idToBePrintedOut, previousReceiptConfirmationPrintoutID, fiscalYear);
                    printout.DataSource = rc.DefaultView.ToTable();
                    var dtDate = new DateTimePickerEx();
                    //dtDate.CustomFormat = "dd/MM/yyyy";
                    dtDate.Value = receiveDoc.EurDate;

                    printout.Date.Text = dtDate.Text;
                }
                else
                {
                    printout.xrGRVLabel.Text = "GRV No.";
                    printout.xrSTV.Visible = false;
                    printout.xrSTVNoValue.Visible = false;
                    printedID = rc.PrepareDataForPrintout(receiptID, CurrentContext.UserId, false, 2,
                                                          idToBePrintedOut, previousReceiptConfirmationPrintoutID, fiscalYear);
                    printout.xrLabelGRNF.Text = GRNFNo;
                    printout.DataSource = rc.DefaultView.ToTable();

                    var dtDate = new DateTimePickerEx();
                    //dtDate.CustomFormat = "dd/MM/yyyy";
                    dtDate.Value = receiveDoc.EurDate;

                    printout.Date.Text = dtDate.Text;
                }


                printout.xrLabelStoreName.Text = activity.FullActivityName;

                if (ReceiveDoc.IsThereShortageOrDamage(receiptID))
                {
                    ReceiptConfirmationShortagePrintout printoutShortage =
                        PrintReceiptConfirmationForShortage(receiptID, printedID, fiscalYear);

                    PrepareGRVPrintout(printoutShortage);
                    printout.xrShortageReport.ReportSource = printoutShortage;

                    printout.PrintingSystem.ContinuousPageNumbering = true;
                }
                else
                {
                    printout.ReportFooter.Visible = false;
                }
                if (!forExporting) //If this is not for exporting, we print on paper.
                {
                    if (printout.PrintDialog() != DialogResult.OK)
                    {
                        throw new Exception("Print cancelled by user!");
                    }
                }

                return printout;
            }

            else if (receipt.ReceiptTypeID == ReceiptType.CONSTANTS.STOCK_RETURN)
            {
                if (!String.IsNullOrEmpty(GeneralInfo.Current.HospitalName))
                {
                    srmPrintout.BranchName.Text = GeneralInfo.Current.HospitalName;
                }

                rc.PrepareDataForPrintout(receiptID, CurrentContext.UserId, false, 3, idToBePrintedOut,
                                                     previousReceiptConfirmationPrintoutID, fiscalYear);
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
                    var stvLog = new Issue();
                    stvLog.LoadByPrimaryKey(idoc.STVID);
                    var issuedActivity = new Activity();
                    issuedActivity.LoadByPrimaryKey(idoc.StoreId);
                    srmPrintout.xrAccountName.Text = issuedActivity.FullActivityName;
                    srmPrintout.xrSTVNoValue.Text = stvLog.IDPrinted.ToString("00000");
                }
                else
                {

                    srmPrintout.xrAccountName.Text = activity.FullActivityName; ;
                    srmPrintout.xrSTVNoValue.Text = receiveDoc.RefNo;
                }

                var dtDate = new DateTimePickerEx();
                dtDate.Value = receiveDoc.EurDate;
                srmPrintout.Date.Text = dtDate.Text;

                if (!forExporting)
                {
                    if (srmPrintout.PrintDialog() != DialogResult.OK)
                    {
                        throw new Exception("Print cancelled by user!");
                    }
                }
                return srmPrintout;
            }

            else //TODO: Implement Delivery notes.
            {
                return null;
            }

        }

        public static XtraReport GetCostAnalysisPrintout(string GRNString, int ReceiptID)
        {

            BLL.Receipt receipt = new BLL.Receipt(ReceiptID);
            CostCalculator GRV = new CostCalculator();
            GRV.LoadGRV(ReceiptID);
            GRV.LoadGRVForCostAnalysis(ReceiptID);
            HCMIS.Desktop.Reports.PreviousCostPrintout xReportCostBuildUp = new HCMIS.Desktop.Reports.PreviousCostPrintout();
            xReportCostBuildUp.DataSource = GRV.PreviousStock;

            HCMIS.Desktop.Reports.CostAnalysisSubReport xReportCostAnalysis = new HCMIS.Desktop.Reports.CostAnalysisSubReport();
            xReportCostAnalysis.DataSource = GRV.CostAnalysis(GRNString);

            HCMIS.Desktop.Reports.CostCalculationPrintout xReportCostCalculationPrintOut = new HCMIS.Desktop.Reports.CostCalculationPrintout();
            xReportCostCalculationPrintOut.DataSource = GRV.GRVDetail;

            HCMIS.Desktop.Reports.CostReport xReportCostReport = new HCMIS.Desktop.Reports.CostReport();
            xReportCostReport.DataSource = GRV.CostAnalysis(GRNString);
            xReportCostReport.xrDate.Text = EthiopianDate.EthiopianDate.GregorianToEthiopian(BLL.DateTimeHelper.ServerDateTime);
            ReceiveDocConfirmation receiveDocConfirmation = new ReceiveDocConfirmation();
            DataTable Users = receiveDocConfirmation.GetUserNamebyReceipt(ReceiptID);
            if (Users.Rows.Count > 0)
            {
                xReportCostReport.xrCostedBy.Text = Users.Rows[0]["CostedBy"].ToString();
                xReportCostReport.xrCheckedBy.Text = Users.Rows[0]["CheckedBy"].ToString();

            }

            xReportCostReport.xrWarehouse.Text = receipt.GetWarehouse();
            xReportCostReport.subReportCostCalculation.ReportSource = xReportCostCalculationPrintOut;
            xReportCostReport.xrSubreportCostBuildup.ReportSource = xReportCostBuildUp;
            xReportCostReport.xrSubreportCostAnalysis.ReportSource = xReportCostAnalysis;
            xReportCostReport.ShowPrintStatusDialog = true;
            xReportCostReport.CreateDocument();
            xReportCostReport.PrintingSystem.Document.AutoFitToPagesWidth = 1;

            return xReportCostReport;
        }

        public static XtraReport GetCostBuildUpPrintout(string GRNString, int ReceiptID)
        {
            BLL.Receipt receipt = new BLL.Receipt(ReceiptID);
            CenterCostCalculator GRV = new CenterCostCalculator();
            GRV.LoadGRV(ReceiptID);
            GRV.LoadCostBuilUp(false, GRNString);
            HCMIS.Desktop.Reports.CostAnalysisSubReport xReportCostAnalysis = new HCMIS.Desktop.Reports.CostAnalysisSubReport();
            xReportCostAnalysis.DataSource = GRV.CostAnalysis(GRNString);

            HCMIS.Desktop.Reports.CostBuildUp xReportCostBuildUp = new HCMIS.Desktop.Reports.CostBuildUp();
            xReportCostBuildUp.DataSource = GRV.CostBuildUp.DataTable.DefaultView;
            xReportCostBuildUp.xrDate.Text = EthiopianDate.EthiopianDate.GregorianToEthiopian(BLL.DateTimeHelper.ServerDateTime);
            xReportCostBuildUp.xrSubreport1.ReportSource = xReportCostAnalysis;
            xReportCostBuildUp.xrCostedBy.Text = CurrentContext.LoggedInUserName;
            ReceiveDocConfirmation receiveDocConfirmation = new ReceiveDocConfirmation();
            DataTable Users = receiveDocConfirmation.GetUserNamebyReceipt(ReceiptID);

            if (Users.Rows.Count > 0)
            {
                xReportCostBuildUp.xrCostedBy.Text = Users.Rows[0]["CostedBy"].ToString();
                xReportCostBuildUp.xrCheckedBy.Text = Users.Rows[0]["CheckedBy"].ToString();

            }
            return xReportCostBuildUp;
        }

        private static ReceiptConfirmationShortagePrintout PrintReceiptConfirmationForShortage(int receiptID, int printedID, FiscalYear fiscalYear)
        {
            var printout = new ReceiptConfirmationShortagePrintout();
            var rc = new BLL.ReceiptConfirmationPrintout();

            var receiveDoc = new ReceiveDoc();
            var receipt = new BLL.Receipt();

            receiveDoc.LoadByReceiptID(receiptID);
            receipt.LoadByPrimaryKey(receiptID);

            var referenceNumber = receiveDoc.RefNo;

            if (receipt.ReceiptTypeID == ReceiptType.CONSTANTS.STANDARD_RECEIPT)
            {

                rc.PrepareDataForPrintout(receiptID, CurrentContext.UserId, true, 2, printedID, null, fiscalYear);
                printout.DataSource = rc.DefaultView.ToTable();
            }
            return printout;
        }

        private static void PrepareGRVPrintout(XtraReport printout)
        {
            var rpt = new ReportPrintout();

            if (rpt.IsReportSizeCustom("GOODS_RECEIPT_VOUCHER"))
            {
                printout.ReportUnit = ReportUnit.TenthsOfAMillimeter;
                printout.PaperKind = PaperKind.Custom;
                printout.PageHeight = rpt.HeightInMM / 10; //Convert.ToInt32(BLL.Settings.PaperHeightCredit);
                printout.PageWidth = rpt.WidthInMM / 10; //Convert.ToInt32(BLL.Settings.PaperWidthCredit);
            }
        }

        #endregion

        public static XtraReport CreatePicklistReport(Order ord, string rus, DataView _dvPickListMakeup)
        {

            if (Settings.IsCenter)
            {
                return CreatePicklist<IssueOrderList>(ord, rus, _dvPickListMakeup);
            }

            if (ord.PaymentTypeID == PaymentType.Constants.CASH || ord.PaymentTypeID == PaymentType.Constants.CREDIT)
            {
                return CreatePicklist<PricedPickList>(ord, rus, _dvPickListMakeup);
            }

            return CreatePicklist<PickList>(ord, rus, _dvPickListMakeup);
        }



        public static R CreatePicklist<R>(Order ord,string receivingUnit, DataView _dvPickListMakeup) where R : XtraReport, IPicklist, new()
        {

            var report = new R
                             {
                                 ToLabel = receivingUnit,
                                 IDLabel = ord.RefNo,
                                 DateLabel = DateTimeHelper.EthiopianDateString,
                                 PreparedByLabel = ord.GetFilledBy(),
                                 ApprovedByLabel = ord.GetApprovedBy(),
                                 DataSource = _dvPickListMakeup.Table,
                                 ContactPersonNameLabel = ord.ContactPerson
                             };
            return report;
        }
        #region Sales

        public static XtraReport CreateInvoice(int stvLogID)
        {
            BLL.Issue stvLog = new Issue();
            BLL.PickList pl = new BLL.PickList();
            BLL.Order order = new Order();
            BLL.Institution rus = new Institution();

            stvLog.LoadByPrimaryKey(stvLogID);
            if (stvLog.IsColumnNull("IsDeliveryNote"))
            {
                stvLog.IsDeliveryNote = false;
            }

            //this makes the assumption that the Insurance is not calculated
            if (stvLog.IsColumnNull("HasInsurance"))
            {
                stvLog.HasInsurance = false;
            }
            if (stvLog.IsColumnNull("IsVoided"))
            {
                stvLog.IsVoided = false;
            }


            pl.LoadByPrimaryKey(stvLog.PickListID);
            order.LoadByPrimaryKey(pl.OrderID);
            if (!order.IsColumnNull("RequestedBy"))
            {
                rus.LoadByPrimaryKey(order.RequestedBy);
            }


            var mode = new Mode();
            mode.LoadByPrimaryKey(order.FromStore);

            DataView dv = pl.GetPickedOrderDetailForOrder(stvLogID, stvLog.IsVoided);
            if (dv.Count == 0 && !stvLog.IsColumnNull("IsRePrintOf"))
            {
                dv = pl.GetPickedOrderDetailForOrder(stvLog.IsReprintOf, stvLog.IsVoided);
            }

            XtraReport report = null;

            if (order.PaymentTypeID == PaymentType.Constants.CASH)
            {
                report = CreateCashInvoice(order, dv.Table, rus, pl, stvLog.IsDeliveryNote, stvLog.HasInsurance,
                                           mode.TypeName, false, stvLogID);
            }
            if (order.PaymentTypeID == PaymentType.Constants.CREDIT)
            {
                report = CreateCreditInvoice(dv.Table, order, pl, rus, stvLog.IsDeliveryNote, stvLog.HasInsurance, mode.TypeName, false, stvLogID);
            }

            if (order.PaymentTypeID == PaymentType.Constants.STV)
            {
                //TODO: Fix this sent to.
                string sentTo = "";
                if (rus.RowCount > 0)
                {
                    sentTo = rus.Name;
                }

                if (!stvLog.IsDeliveryNote)
                {
                    report = CreateSTVonHeadedPaper(order, dv.Table, sentTo, stvLog.PickListID, stvLog.ID, false, false,
                                                    stvLog.HasInsurance, null);
                }
                else
                {
                    report = CreateDeliveryNote(order, dv.Table, sentTo, stvLog.PickListID, stvLog.ID, false, false,
                                                stvLog.HasInsurance, null);
                }

            }

            return report;

        }

        /// <summary>
        /// Prepares the report credit.
        /// </summary>
        /// <param name="stvReport">The STV report.</param>
        private static void PrepareTheReportCredit(XtraReport stvReport)
        {
            if (Settings.UseCustomSizedPaperForPrintingCredit)
            {
                stvReport.ReportUnit = ReportUnit.TenthsOfAMillimeter;
                stvReport.PaperKind = PaperKind.Custom;
                stvReport.PageHeight = Convert.ToInt32(Settings.PaperHeightCredit);
                stvReport.PageWidth = Convert.ToInt32(Settings.PaperWidthCredit);
            }
        }

        /// <summary>
        /// Prepares the report cash.
        /// </summary>
        /// <param name="stvReport">The Cash report.</param>
        private static void PrepareTheReportCash(XtraReport stvReport)
        {
            if (Settings.UseCustomSizedPaperForPrintingCash)
            {
                stvReport.ReportUnit = ReportUnit.TenthsOfAMillimeter;
                stvReport.PaperKind = PaperKind.Custom;
                stvReport.PageHeight = Convert.ToInt32(Settings.PaperHeightCash);
                stvReport.PageWidth = Convert.ToInt32(Settings.PaperWidthCash);
            }
        }

        /// <summary>
        /// Prepares the report.
        /// </summary>
        /// <param name="stvReport">The STV report.</param>
        private static void PrepareTheReport(XtraReport stvReport)
        {
            if (Settings.UseCustomSizedPaperForPrinting)
            {
                stvReport.ReportUnit = ReportUnit.TenthsOfAMillimeter;
                stvReport.PaperKind = PaperKind.Custom;
                stvReport.PageHeight = Convert.ToInt32(Settings.PaperHeight);
                stvReport.PageWidth = Convert.ToInt32(Settings.PaperWidth);
            }
        }

        public static CreditInvoice_Smaller CreateCreditInvoiceSmaller(DataTable dvPriced, Order ord, BLL.PickList pl,
                                                                       Institution rus, bool deliveryNote,
                                                                       bool hasInsurnance, string activityName)
        {
            CreditInvoice_Smaller stvReport = new CreditInvoice_Smaller(CurrentContext.LoggedInUserName);
            PrepareTheReportCredit(stvReport);


            stvReport.DataSource = Order.ReorganizeDataViewForSTVPrint_Program(dvPriced.AsDataView(), ord.ID, pl.ID,
                                                                               CurrentContext.UserId, null, false, true,
                                                                               hasInsurnance);

            stvReport.From.Text = GeneralInfo.Current.HospitalName;

            if (rus.RowCount != 0)
            {
                stvReport.To.Text = rus.Name;
                stvReport.Town.Text = rus.Town;
                stvReport.Woreda.Text = rus.WoredaText;
                stvReport.Zone.Text = rus.ZoneText;
                stvReport.Region.Text = rus.Region;
            }

            stvReport.Letter.Text = ord.LetterNo;
            stvReport.Program.Text = activityName;

            DateTimePickerEx dtDate = new DateTimePickerEx();
            dtDate.Value = DateTimeHelper.ServerDateTime;

            stvReport.Date.Text = dtDate.Text;

            if (deliveryNote)
            {
                stvReport.TopMargin.HeightF = stvReport.TopMargin.HeightF / 2;
                stvReport.xrSTVOrInvoiceLabel.Text = "Delivery Note No.";
                stvReport.GroupFooter1.Visible = false;

                //stvReport.GroupFooter2.Visible = false;
            }
            return stvReport;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ord"></param>
        /// <param name="dvPriced"></param>
        /// <param name="rus"></param>
        /// <param name="pl"></param>
        /// <param name="deliveryNote"></param>
        /// <param name="hasInsurnance"></param>
        /// <param name="activityName"></param>
        /// <param name="generateNewID"></param>
        /// <param name="oldStvLogIDToPrint">If generate New ID is set to false, there needs to be something here</param>
        /// <returns></returns>
        public static CashInvoice CreateCashInvoice(Order ord, DataTable dvPriced, Institution rus, BLL.PickList pl,
                                                    bool deliveryNote, bool hasInsurnance, string activityName, bool generateNewID, int? oldStvLogIDToPrint)
        {
            CashInvoice stvReport = new CashInvoice(CurrentContext.LoggedInUserName);
            PrepareTheReportCash(stvReport);
            stvReport.DataSource = Order.ReorganizeDataViewForSTVPrint_Program(dvPriced.AsDataView(), ord.ID, pl.ID,
                                                                               CurrentContext.UserId, oldStvLogIDToPrint, false, generateNewID,
                                                                               hasInsurnance);
            //stvReport.DataSource = Order.ReorganizeDataViewForSTVPrint(dvPriced.AsDataView(), ord.ID, pl.ID, NewMainWindow.UserId,null);
            stvReport.From.Text = GeneralInfo.Current.HospitalName;

            stvReport.To.Text = rus.Name;
            stvReport.TIN.Text = rus.TinNo;
            stvReport.VAT.Text = rus.VATNo;
            stvReport.Town.Text = rus.Town;
            stvReport.Woreda.Text = rus.WoredaText;
            stvReport.Zone.Text = rus.ZoneText;
            stvReport.Region.Text = rus.Region;
            stvReport.License.Text = (!rus.IsColumnNull("Ownership") && rus.IsPrivatelyOwned)
                                         ? rus.LicenseNo
                                         : (!ord.IsColumnNull("LetterNo")) ? ord.LetterNo : "";


            stvReport.Program.Text = activityName;

            DateTimePickerEx dtDate = new DateTimePickerEx();
            dtDate.Value = DateTimeHelper.ServerDateTime;
            stvReport.Date.Text = dtDate.Text;

            if (deliveryNote)
            {
                stvReport.TopMargin.HeightF = stvReport.TopMargin.HeightF / 2;
                stvReport.xrSTVOrInvoiceLabel.Text = "Delivery Note No.";
                stvReport.GroupFooter1.Visible = false;
                stvReport.GroupFooter2.Visible = false;
            }
            return stvReport;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dvPriced"></param>
        /// <param name="ord"></param>
        /// <param name="pl"></param>
        /// <param name="rus"></param>
        /// <param name="deliveryNote"></param>
        /// <param name="hasInsurance"></param>
        /// <param name="activityName"></param>
        /// <param name="generateNewID"></param>
        /// <param name="oldStvLogIDToPrint">If generateNewID is set to false, there needs to be a value here.</param>
        /// <returns></returns>
        public static CreditInvoice CreateCreditInvoice(DataTable dvPriced, Order ord, BLL.PickList pl, Institution rus, bool deliveryNote, bool hasInsurance,
                                                         string activityName, bool generateNewID, int? oldStvLogIDToPrint)
        {
            CreditInvoice stvReport = new CreditInvoice(CurrentContext.LoggedInUserName);

            PrepareTheReportCredit(stvReport);
            stvReport.DataSource = Order.ReorganizeDataViewForSTVPrint_Program(dvPriced.AsDataView(), ord.ID, pl.ID,
                                                                               CurrentContext.UserId, oldStvLogIDToPrint, false, generateNewID,
                                                                               hasInsurance);

            stvReport.From.Text = GeneralInfo.Current.HospitalName;

            if (!Settings.ShowMultipleStoresOnSTV)
            {
                stvReport.xrTableCellStore.Visible = false;
                stvReport.xrTableCellStoreValue.Visible = false;
            }

            if (rus.RowCount != 0)
            {
                stvReport.To.Text = rus.Name;
                stvReport.Town.Text = rus.Town;
                stvReport.Woreda.Text = rus.WoredaText;
                stvReport.Zone.Text = rus.ZoneText;
                stvReport.Region.Text = rus.Region;
            }

            stvReport.Letter.Text = ord.LetterNo;
            stvReport.Program.Text = activityName;

            DateTimePickerEx dtDate = new DateTimePickerEx();
            dtDate.Value = DateTimeHelper.ServerDateTime;

            stvReport.Date.Text = dtDate.Text;

            if (deliveryNote)
            {
                stvReport.TopMargin.HeightF = stvReport.TopMargin.HeightF / 2;
                stvReport.xrSTVOrInvoiceLabel.Text = "Delivery Note No.";
                stvReport.GroupFooter1.Visible = false;

                //stvReport.GroupFooter2.Visible = false;
            }

            return stvReport;
        }

        public static CashInvoice_Smaller CreateCashInvoiceSmaller(Order ord, DataTable dvPriced, Institution rus, BLL.PickList pl, bool deliveryNote, bool hasInsurnance, string activityName)
        {
            CashInvoice_Smaller stvReport = new CashInvoice_Smaller(CurrentContext.LoggedInUserName);
            PrepareTheReportCash(stvReport);
            stvReport.DataSource = Order.ReorganizeDataViewForSTVPrint_Program(dvPriced.AsDataView(), ord.ID, pl.ID,
                                                                               CurrentContext.UserId, null, false, true,
                                                                               hasInsurnance);
            //stvReport.DataSource = Order.ReorganizeDataViewForSTVPrint(dvPriced.AsDataView(), ord.ID, pl.ID, NewMainWindow.UserId,null);
            stvReport.From.Text = GeneralInfo.Current.HospitalName;

            stvReport.To.Text = rus.Name;
            stvReport.Town.Text = rus.Town;
            stvReport.Woreda.Text = rus.WoredaText;
            stvReport.Zone.Text = rus.ZoneText;
            stvReport.Region.Text = rus.Region;
            stvReport.TIN.Text = rus.TinNo;
            stvReport.VAT.Text = rus.VATNo;
            stvReport.License.Text = (!rus.IsColumnNull("Ownership") && rus.IsPrivatelyOwned)
                                          ? rus.LicenseNo
                                          : (!ord.IsColumnNull("LetterNo")) ? ord.LetterNo : "";
            stvReport.Program.Text = activityName;

            DateTimePickerEx dtDate = new DateTimePickerEx();
            dtDate.Value = DateTimeHelper.ServerDateTime;
            stvReport.Date.Text = dtDate.Text;

            if (deliveryNote)
            {
                stvReport.TopMargin.HeightF = stvReport.TopMargin.HeightF / 2;
                stvReport.xrSTVOrInvoiceLabel.Text = "Delivery Note No.";
                stvReport.GroupFooter1.Visible = false;
                stvReport.GroupFooter2.Visible = false;
            }
            return stvReport;
        }

        public static STVonHeadedPaper CreateSTVonHeadedPaper(Order ord, DataTable dvPriced, string stvSentTo, int pickListID, int? stvLogID, bool convertDN, bool generateNewID,
                                                               bool hasInsurance, string transferType)
        {
            var iss = new Issue();
            var stvReport = new STVonHeadedPaper(ord.ID, hasInsurance, CurrentContext.LoggedInUserName);
            PrepareTheReport(stvReport);
            stvReport.DataSource = Order.ReorganizeDataViewForSTVPrint_Program(dvPriced.AsDataView(), ord.ID, pickListID,
                                                                               CurrentContext.UserId, stvLogID, convertDN, generateNewID,
                                                                               hasInsurance);
           
            stvReport.From.Text = GeneralInfo.Current.HospitalName;
            //if (rus.RowCount != 0)
            //    stvReport.To.Text = rus.Name;
            stvReport.To.Text = stvSentTo;

            if (!string.IsNullOrEmpty(transferType)) //If this is store to store transfer
            {
                stvReport.xrTransferType.Visible = true;
                stvReport.xrTransferType.Text = transferType;
            }
            

            DateTimePickerEx dtDate = new DateTimePickerEx();
            dtDate.Value = DateTimeHelper.ServerDateTime;

            if (stvLogID == null)
            {
                iss.LoadByPicklist(pickListID);
            }

            iss.LoadByPicklist(pickListID);
            stvReport.lblORiginalPrintedDate.Text = iss.PrintedDate.ToString();
            stvReport.Date.Text = dtDate.Text;
            return stvReport;
        }

        public static STVonA4 CreateSTVonA4(Order ord, DataTable dvPriced, string stvSentTo, int pickListID, int? stvLogID, bool convertDN, bool generateNewID,
                                                             bool hasInsurance, string transferType)
        {
            var stvReport = new STVonA4(ord.ID, hasInsurance, CurrentContext.LoggedInUserName);
            PrepareTheReport(stvReport);
            stvReport.DataSource = Order.ReorganizeDataViewForSTVPrint_Program(dvPriced.AsDataView(), ord.ID, pickListID,
                                                                               CurrentContext.UserId, stvLogID, convertDN, generateNewID,
                                                                               hasInsurance);
            stvReport.From.Text = GeneralInfo.Current.HospitalName;
            stvReport.To.Text = stvSentTo;
            var dtDate = new DateTimePickerEx();
            stvReport.Date.Text = dtDate.Text;
            dtDate.Value = DateTimeHelper.ServerDateTime;
            return stvReport;
        }

        public static DeliveryNoteForIssue CreateDeliveryNote(Order ord, DataTable dvPriced, string stvSentTo, int pickListID, int? stvLogID, bool convertDN, bool generateNewID,
                                                               bool hasInsurance, string toStoreName)
        {
            var iss = new Issue();
           DeliveryNoteForIssue stvReport = new DeliveryNoteForIssue(ord.ID, hasInsurance, CurrentContext.LoggedInUserName);
            PrepareTheReport(stvReport);
            stvReport.DataSource = Order.ReorganizeDataViewForSTVPrint_Program(dvPriced.AsDataView(), ord.ID, pickListID,
                                                                               CurrentContext.UserId, stvLogID, convertDN, generateNewID,
                                                                               hasInsurance);
            stvReport.From.Text = GeneralInfo.Current.HospitalName;
            //if (rus.RowCount != 0)
            //    stvReport.To.Text = rus.Name;
            stvReport.To.Text = stvSentTo;

            DateTimePickerEx dtDate = new DateTimePickerEx();
            dtDate.Value = DateTimeHelper.ServerDateTime;

            if (stvLogID == null)
            {
                iss.LoadByPicklist(pickListID);
            }

            stvReport.lblOriginalPrintedDate.Text = iss.PrintedDate.ToShortDateString();
            stvReport.Date.Text = dtDate.Text;

            return stvReport;
        }


        #endregion

        public static XtraReport CreateModel22(Order ord, DataTable dvPriced, string stvSentTo, int pickListID, int? stvLogID, bool convertDN, bool generateNewID,
                                                             bool hasInsurance, string transferType)
        {
            DateTimePickerEx dtDate = new DateTimePickerEx();
            dtDate.Value = DateTimeHelper.ServerDateTime;

            var dataSource = Order.ReorganizeDataViewForSTVPrint_Program(dvPriced.AsDataView(), ord.ID, pickListID,
                                                                   CurrentContext.UserId, stvLogID, convertDN, generateNewID,
                                                                   hasInsurance);


            return new Model20Report(GeneralInfo.Current.HospitalName, dtDate.Text, stvSentTo, GeneralInfo.Current.GetLogo()) { DataSource = dataSource };
        }

        public static XtraReport CreateCashReprintInvoiceSmaller(Order ord, DataTable dvPriced, Institution rus, BLL.PickList pl, bool deliveryNote, bool hasInsurnance, string activityName, int? _stvLogIdChosen)
        {
            CashInvoice_Smaller stvReport = new CashInvoice_Smaller(CurrentContext.LoggedInUserName);
            PrepareTheReportCash(stvReport);
            stvReport.DataSource = Order.ReorganizeDataViewForSTVPrint_Program(dvPriced.AsDataView(), ord.ID, pl.ID, CurrentContext.UserId, _stvLogIdChosen, false, true, hasInsurnance);
            //stvReport.DataSource = Order.ReorganizeDataViewForSTVPrint(dvPriced.AsDataView(), ord.ID, pl.ID, NewMainWindow.UserId,null);
            stvReport.From.Text = GeneralInfo.Current.HospitalName;

            stvReport.To.Text = rus.Name;
            stvReport.Town.Text = rus.Town;
            stvReport.Woreda.Text = rus.WoredaText;
            stvReport.Zone.Text = rus.ZoneText;
            stvReport.Region.Text = rus.Region;
            stvReport.TIN.Text = rus.TinNo;
            stvReport.VAT.Text = rus.VATNo;
            stvReport.License.Text = (!rus.IsColumnNull("Ownership") && rus.IsPrivatelyOwned)
                                          ? rus.LicenseNo
                                          : (!ord.IsColumnNull("LetterNo")) ? ord.LetterNo : "";
            stvReport.Program.Text = activityName;

            DateTimePickerEx dtDate = new DateTimePickerEx();
            dtDate.Value = DateTimeHelper.ServerDateTime;
            stvReport.Date.Text = dtDate.Text;

            if (deliveryNote)
            {
                stvReport.TopMargin.HeightF = stvReport.TopMargin.HeightF / 2;
                stvReport.xrSTVOrInvoiceLabel.Text = "Delivery Note No.";
                stvReport.GroupFooter1.Visible = false;
                stvReport.GroupFooter2.Visible = false;
            }
            return stvReport;
        }

        public static XtraReport CreateCashRePrintInvoiceLarger(Order ord, DataTable dvPriced, Institution rus, BLL.PickList pl, bool deliveryNote, bool hasInsurnance, string activityName, bool p, int? _stvLogIdChosen)
        {
            CashInvoice stvReport = new CashInvoice(CurrentContext.LoggedInUserName);
            PrepareTheReportCash(stvReport);
            stvReport.DataSource = Order.ReorganizeDataViewForSTVPrint_Program(dvPriced.AsDataView(), ord.ID, pl.ID, CurrentContext.UserId, _stvLogIdChosen, false, true, hasInsurnance);
            //stvReport.DataSource = Order.ReorganizeDataViewForSTVPrint(dvPriced.AsDataView(), ord.ID, pl.ID, NewMainWindow.UserId,null);
            stvReport.From.Text = GeneralInfo.Current.HospitalName;

            stvReport.To.Text = rus.Name;
            stvReport.TIN.Text = rus.TinNo;
            stvReport.VAT.Text = rus.VATNo;
            stvReport.Town.Text = rus.Town;
            stvReport.Woreda.Text = rus.WoredaText;
            stvReport.Zone.Text = rus.ZoneText;
            stvReport.Region.Text = rus.Region;
            stvReport.License.Text = (!rus.IsColumnNull("Ownership") && rus.IsPrivatelyOwned)
                                         ? rus.LicenseNo
                                         : (!ord.IsColumnNull("LetterNo")) ? ord.LetterNo : "";


            stvReport.Program.Text = activityName;

            DateTimePickerEx dtDate = new DateTimePickerEx();
            dtDate.Value = DateTimeHelper.ServerDateTime;
            stvReport.Date.Text = dtDate.Text;

            if (deliveryNote)
            {
                stvReport.TopMargin.HeightF = stvReport.TopMargin.HeightF / 2;
                stvReport.xrSTVOrInvoiceLabel.Text = "Delivery Note No.";
                stvReport.GroupFooter1.Visible = false;
                stvReport.GroupFooter2.Visible = false;
            }
            return stvReport;
        }

        public static XtraReport CreateCreditRePrintInvoiceSmaller(DataTable dvPriced, Order ord, BLL.PickList pl, Institution rus, bool deliveryNote, bool hasInsurnance, string activityName, int? _stvLogIdChosen)
        {
            CreditInvoice_Smaller stvReport = new CreditInvoice_Smaller(CurrentContext.LoggedInUserName);
            PrepareTheReportCredit(stvReport);


            stvReport.DataSource = Order.ReorganizeDataViewForSTVPrint_Program(dvPriced.AsDataView(), ord.ID, pl.ID, CurrentContext.UserId, _stvLogIdChosen, false, true,
                                                                               hasInsurnance);

            stvReport.From.Text = GeneralInfo.Current.HospitalName;

            if (rus.RowCount != 0)
            {
                stvReport.To.Text = rus.Name;
                stvReport.Town.Text = rus.Town;
                stvReport.Woreda.Text = rus.WoredaText;
                stvReport.Zone.Text = rus.ZoneText;
                stvReport.Region.Text = rus.Region;
            }

            stvReport.Letter.Text = ord.LetterNo;
            stvReport.Program.Text = activityName;

            DateTimePickerEx dtDate = new DateTimePickerEx();
            dtDate.Value = DateTimeHelper.ServerDateTime;

            stvReport.Date.Text = dtDate.Text;

            if (deliveryNote)
            {
                stvReport.TopMargin.HeightF = stvReport.TopMargin.HeightF / 2;
                stvReport.xrSTVOrInvoiceLabel.Text = "Delivery Note No.";
                stvReport.GroupFooter1.Visible = false;

                //stvReport.GroupFooter2.Visible = false;
            }
            return stvReport;
        }

        public static XtraReport CreateCreditRePrintInvoiceLarger(DataTable dvPriced, Order ord, BLL.PickList pl, Institution rus, bool deliveryNote, bool hasInsurance, string activityName, bool p, int? _stvLogIdChosen)
        {
            CashInvoice_Smaller stvReport = new CashInvoice_Smaller(CurrentContext.LoggedInUserName);
            PrepareTheReportCash(stvReport);
            stvReport.DataSource = Order.ReorganizeDataViewForSTVPrint_Program(dvPriced.AsDataView(), ord.ID, pl.ID, CurrentContext.UserId, _stvLogIdChosen, false, true, hasInsurance);
            //stvReport.DataSource = Order.ReorganizeDataViewForSTVPrint(dvPriced.AsDataView(), ord.ID, pl.ID, NewMainWindow.UserId,null);
            stvReport.From.Text = GeneralInfo.Current.HospitalName;

            stvReport.To.Text = rus.Name;
            stvReport.Town.Text = rus.Town;
            stvReport.Woreda.Text = rus.WoredaText;
            stvReport.Zone.Text = rus.ZoneText;
            stvReport.Region.Text = rus.Region;
            stvReport.TIN.Text = rus.TinNo;
            stvReport.VAT.Text = rus.VATNo;
            stvReport.License.Text = (!rus.IsColumnNull("Ownership") && rus.IsPrivatelyOwned)
                                          ? rus.LicenseNo
                                          : (!ord.IsColumnNull("LetterNo")) ? ord.LetterNo : "";
            stvReport.Program.Text = activityName;

            DateTimePickerEx dtDate = new DateTimePickerEx();
            dtDate.Value = DateTimeHelper.ServerDateTime;
            stvReport.Date.Text = dtDate.Text;

            if (deliveryNote)
            {
                stvReport.TopMargin.HeightF = stvReport.TopMargin.HeightF / 2;
                stvReport.xrSTVOrInvoiceLabel.Text = "Delivery Note No.";
                stvReport.GroupFooter1.Visible = false;
                stvReport.GroupFooter2.Visible = false;
            }
            return stvReport;
        }
    }
}
