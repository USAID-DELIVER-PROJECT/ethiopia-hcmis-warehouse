
using System;
namespace HCMIS.Desktop.Reports
{
    public partial class BeginningBalanceCostingReport : DevExpress.XtraReports.UI.XtraReport
    {
        public BeginningBalanceCostingReport()
        {
            InitializeComponent();
            pxLogo.ImageUrl = BLL.GeneralInfo.Current.LogoUrl;
        }
    }
}