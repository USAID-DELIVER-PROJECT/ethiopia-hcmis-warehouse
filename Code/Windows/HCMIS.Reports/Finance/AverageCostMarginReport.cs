
using System;
namespace HCMIS.Desktop.Reports
{
    public partial class AverageCostMarginReport : DevExpress.XtraReports.UI.XtraReport
    {
        public AverageCostMarginReport()
        {
            InitializeComponent();
            pxLogo.ImageUrl = BLL.GeneralInfo.Current.LogoUrl;
        }
    }
}