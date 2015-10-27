
using System;
namespace HCMIS.Desktop.Reports
{    
    public partial class DeliveryNoteForIssue : DevExpress.XtraReports.UI.XtraReport
    {
        public int _orderID;
        public double totalWithoutInsurance;
        public double insuranceValue;
        public bool _includeInsurance;

        public DeliveryNoteForIssue(int orderID, bool includeInsurance, string userFullName)
        {
            InitializeComponent();
            _includeInsurance = includeInsurance;
            _orderID = orderID;
            PrintUserDetailOnReport(userFullName);
            pxLogo.ImageUrl = BLL.GeneralInfo.Current.LogoUrl;
        }

        private void PrintUserDetailOnReport(string userFullName)
        {
            xrLabelReportPrintedBy.Text = string.Format("Printed by {0} on {1}", userFullName,
                                                        BLL.DateTimeHelper.ServerDateTime);
        }

        private void PriceInWords_SummaryCalculated(object sender, DevExpress.XtraReports.UI.TextFormatEventArgs e)
        {
            
        }

        private void xrInsuranceValue_SummaryCalculated(object sender, DevExpress.XtraReports.UI.TextFormatEventArgs e)
        {
            
        }

        private void xrInsuranceValue_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void xrTotalPrice_SummaryCalculated(object sender, DevExpress.XtraReports.UI.TextFormatEventArgs e)
        {

        }
    }
}