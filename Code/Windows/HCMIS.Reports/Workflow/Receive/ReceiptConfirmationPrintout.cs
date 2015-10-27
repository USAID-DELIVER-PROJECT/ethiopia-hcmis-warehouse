
using BLL;
using HCMIS.Shared.Helpers;
using System;
namespace HCMIS.Desktop.Reports
{
    public partial class ReceiptConfirmationPrintout : DevExpress.XtraReports.UI.XtraReport
    {
        public ReceiptConfirmationPrintout(string userFullName)
        {
            InitializeComponent();
            PrintUserDetailOnReport(userFullName);
        }

        private void PrintUserDetailOnReport(string userFullName)
        {
            xrLabelReportPrintedBy.Text = string.Format("Printed by {0} on {1}", userFullName,
                                                        BLL.DateTimeHelper.ServerDateTime);
        }

        private void PriceInWords_SummaryCalculated(object sender, DevExpress.XtraReports.UI.TextFormatEventArgs e)
        {
            try
            {
                if (e.Value != null)
                    e.Text = NumberToEnglish.ConvertMoneyToWords(Convert.ToDouble(e.Value.ToString().Replace(",", "")));
            }
            catch
            {
            }
        }

     
    }
}