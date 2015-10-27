
namespace HCMIS.Desktop.Reports
{
    public partial class StockStatus : DevExpress.XtraReports.UI.XtraReport
    {
        public StockStatus()
        {
            InitializeComponent();

            pxLogo.ImageUrl = BLL.GeneralInfo.Current.LogoUrl;
        }

    }
}
