
using HCMIS.Shared.Helpers;
using System;
namespace HCMIS.Desktop.Reports
{
    public partial class ReceiptConfirmationShortagePrintout : DevExpress.XtraReports.UI.XtraReport
    {
        public ReceiptConfirmationShortagePrintout()
        {
            InitializeComponent();
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

        private void GRVNO_PrintOnPage(object sender, DevExpress.XtraReports.UI.PrintOnPageEventArgs e)
        {

        }
    }
}