
namespace HCMIS.Desktop.Reports
{
    public partial class StockStatusByCommodity : DevExpress.XtraReports.UI.XtraReport
    {
        public StockStatusByCommodity(string printedBy)
        {
            InitializeComponent();
            xrPrintedBy.Text = string.Format("Printed By: {0}", printedBy);
            pxLogo.ImageUrl = BLL.GeneralInfo.Current.LogoUrl;
        }

    }
}
