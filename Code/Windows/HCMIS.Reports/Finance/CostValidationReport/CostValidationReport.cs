
using System;
namespace HCMIS.Desktop.Reports
{
    public partial class CostingValidationReport: DevExpress.XtraReports.UI.XtraReport
    {
        public CostingValidationReport()
        {
            InitializeComponent();
            pxLogo.ImageUrl = BLL.GeneralInfo.Current.LogoUrl;
        }
    }
}