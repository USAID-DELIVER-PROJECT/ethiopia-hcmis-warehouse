
using System;
namespace HCMIS.Desktop.Reports
{
    public partial class CostAnalysis : DevExpress.XtraReports.UI.XtraReport
    {
        public CostAnalysis()
        {
            InitializeComponent();
            pxLogo.ImageUrl = BLL.GeneralInfo.Current.LogoUrl;
        }
    }
}