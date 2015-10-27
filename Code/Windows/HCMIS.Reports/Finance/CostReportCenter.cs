
using System;
namespace HCMIS.Desktop.Reports
{
    public partial class CostReportCenter: DevExpress.XtraReports.UI.XtraReport
    {
        public CostReportCenter()
        {
            InitializeComponent();
            pxLogo.ImageUrl = BLL.GeneralInfo.Current.LogoUrl;
        }
    }
}