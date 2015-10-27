
using System;
using DevExpress.XtraReports.UI;
using HCMIS.Shared.Helpers;

namespace HCMIS.Desktop.Reports
{
    public partial class CreditInvoice : DevExpress.XtraReports.UI.XtraReport
    {
        public CreditInvoice(string userFullName)
        {
            InitializeComponent();
            PrintUserDetailOnReport(userFullName);
        }

        private void PrintUserDetailOnReport(string userFullName)
        {
            xrLabelReportPrintedBy.Text = string.Format("Printed by {0} on {1}", userFullName,
                                                        BLL.DateTimeHelper.ServerDateTime);
        }

        private void PriceInWords_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
           
            if (e.Value != null)
                e.Text = NumberToEnglish.ConvertMoneyToWords(Convert.ToDouble(e.Value.ToString().Replace(",", "")));
        }

    }
}
