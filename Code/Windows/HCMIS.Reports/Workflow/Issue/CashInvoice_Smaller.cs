
using System;
using DevExpress.XtraReports.UI;
using HCMIS.Shared.Helpers;

namespace HCMIS.Desktop.Reports
{
    public partial class CashInvoice_Smaller : DevExpress.XtraReports.UI.XtraReport
    {
        public CashInvoice_Smaller(string userFullName)
        {
            InitializeComponent();
            PrintUserDetailOnReport(userFullName);
        }

        private void PrintUserDetailOnReport(string userFullName)
        {
            xrLabelReportPrintedBy.Text = string.Format("Printed by {0} on {1}", userFullName,
                                                        BLL.DateTimeHelper.ServerDateTime);
        }

        private void SummaryNumber_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            //NumberToEnglish converter = new NumberToEnglish();
            //PriceInWords.Text = converter.changeCurrencyToWords(Convert.ToDouble(e.Result));
        }

        private void SummaryNumber_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
           
        }

        private void PriceInWords_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
            
            if (e.Value != null)
                e.Text = NumberToEnglish.ConvertMoneyToWords(Convert.ToDouble(e.Value.ToString().Replace(",", "")));
        }
    }
}