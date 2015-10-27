
namespace HCMIS.Desktop.Reports
{
    public partial class StockStatusByAccountWithUnitPrice : DevExpress.XtraReports.UI.XtraReport
    {
        public StockStatusByAccountWithUnitPrice(string printedBy)
        {
            InitializeComponent();
            xrPrintedBy.Text = string.Format("Printed By: {0}", printedBy);
            pxLogo.ImageUrl = BLL.GeneralInfo.Current.LogoUrl;
        }

    }
}
