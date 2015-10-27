
using BLL;
using HCMIS.Shared.Helpers;
using System;
namespace HCMIS.Desktop.Reports
{
    public partial class ReceiptConfirmationPrintoutStore : DevExpress.XtraReports.UI.XtraReport
    {
        
        public enum GRNFReportType
        {
            SRM = 1,
            IGRV = 2, 
            GRV = 3
        }

        private GRNFReportType _reportType = GRNFReportType.GRV;

        public GRNFReportType ReportType
        {
            get { return _reportType; }
            set
            {
                _reportType = value;
                PrepareReport();
            }
        }

     
        public ReceiptConfirmationPrintoutStore(string userFullName)
        {
            InitializeComponent();
            PrintUserDetailOnReport(userFullName);
            pxLogo.ImageUrl = BLL.GeneralInfo.Current.LogoUrl;
            PrepareReport();
        }

        private void PrintUserDetailOnReport(string userFullName)
        {
            xrLabelReportPrintedBy.Text = string.Format("Printed by {0} on {1}", userFullName,
                                                        BLL.DateTimeHelper.ServerDateTime);
        }

        private void PrepareReport()
        {
            BranchName.Text = GeneralInfo.Current.HospitalName;
            xrGRVLabel.Text = "GRNF No.";
            if(ReportType == GRNFReportType.SRM)
            {
                
                xrFromFacility.Visible = true;
                xrFromFacilityValue.Visible = true;
            }
            if (ReportType == GRNFReportType.IGRV)
            {
                xrAir.Visible = false;
                xrAirValue.Visible = false;
                xrTransit.Visible = false;
                xrTransitValue.Visible = false;
                xrInsurance.Visible = false;
                xrInsuranceValue.Visible = false;
                xrNumberOfCases.Visible = false;
                xrNumberOfCasesValue.Visible = false;
                xrInvoiceNo.Text = "STV No.";
                xrPurchaseOrderNo.Visible = false;
                xrPurchaseOrderNoValue.Visible = false;

                xrSTV.Visible = false;
                xrSTVNoValue.Visible = false;
            }
        }
        
        private void PriceInWords_SummaryCalculated(object sender, DevExpress.XtraReports.UI.TextFormatEventArgs e)
        {
            try
            {
                
                e.Text = NumberToEnglish.ConvertMoneyToWords(Convert.ToDouble(e.Value.ToString().Replace(",", "")));
            }
            catch
            {

            }
        }

     
    }
}