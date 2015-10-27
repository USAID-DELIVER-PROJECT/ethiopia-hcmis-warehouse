
using System;
namespace HCMIS.Desktop.Reports
{
    public partial class CostReport: DevExpress.XtraReports.UI.XtraReport
    {
        public CostReport()
        {
            InitializeComponent();
            pxLogo.ImageUrl = BLL.GeneralInfo.Current.LogoUrl;
        }
    }
}