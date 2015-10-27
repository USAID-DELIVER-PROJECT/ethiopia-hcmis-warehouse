namespace HCMIS.Desktop.Reports.Reports
{
    public partial class StockCardReport : DevExpress.XtraReports.UI.XtraReport
    {
        public StockCardReport()
        {
            InitializeComponent();

            pxLogo.ImageUrl = BLL.GeneralInfo.Current.LogoUrl;
        }
     
    }
}
