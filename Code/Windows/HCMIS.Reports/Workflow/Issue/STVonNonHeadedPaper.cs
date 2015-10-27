
namespace HCMIS.Desktop.Reports
{
    public partial class STVonNonHeadedPaper : DevExpress.XtraReports.UI.XtraReport
    {
        public STVonNonHeadedPaper()
        {
            InitializeComponent();
            pxLogo.ImageUrl = BLL.GeneralInfo.Current.LogoUrl;
        }

    }
}
