
using DevExpress.XtraReports.UI;

namespace HCMIS.Desktop.Reports
{
    public partial class StockStatusByPhysicalStore : DevExpress.XtraReports.UI.XtraReport
    {
        private int currentLine;

        public StockStatusByPhysicalStore(string printedBy)
        {
            InitializeComponent();
            xrPrintedBy.Text = string.Format("Printed By: {0}", printedBy);
            pxLogo.ImageUrl = BLL.GeneralInfo.Current.LogoUrl;
        }

        private void cellLineNo_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            (sender as XRLabel).Text = (++currentLine).ToString();

        }

        private void StockStatusByPhysicalStore_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            currentLine = 0;
        }

    }
}
