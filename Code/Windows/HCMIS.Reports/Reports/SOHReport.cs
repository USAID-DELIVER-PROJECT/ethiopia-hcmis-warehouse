
using System;
namespace HCMIS.Desktop.Reports
{
    public partial class SOHReport: DevExpress.XtraReports.UI.XtraReport
    {
        public SOHReport()
        {
            InitializeComponent();
            pxLogo.ImageUrl = BLL.GeneralInfo.Current.LogoUrl;
        }
    }
}