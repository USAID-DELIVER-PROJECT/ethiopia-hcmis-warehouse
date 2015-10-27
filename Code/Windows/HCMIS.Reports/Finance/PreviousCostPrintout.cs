
using HCMIS.Shared.Helpers;
using System;
namespace HCMIS.Desktop.Reports
{
    public partial class PreviousCostPrintout : DevExpress.XtraReports.UI.XtraReport
    {
        public PreviousCostPrintout()
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

        private void xrTableCell5_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void PreviousCostPrintout_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

     
    }
}