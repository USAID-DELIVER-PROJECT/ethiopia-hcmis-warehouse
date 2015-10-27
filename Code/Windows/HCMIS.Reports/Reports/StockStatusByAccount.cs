
namespace HCMIS.Desktop.Reports
{
    public partial class StockStatusByAccount : DevExpress.XtraReports.UI.XtraReport
    {
        public StockStatusByAccount(string printedBy)
        {
            InitializeComponent();
            xrPrintedBy.Text = string.Format("Printed By: {0}", printedBy);
            pxLogo.ImageUrl = BLL.GeneralInfo.Current.LogoUrl;
        }

    }
}
