
using System;
namespace HCMIS.Desktop.Reports
{
    public partial class PickListCostValidationReport: DevExpress.XtraReports.UI.XtraReport
    {
        public PickListCostValidationReport()
        {
            InitializeComponent();
            pxLogo.ImageUrl = BLL.GeneralInfo.Current.LogoUrl;
        }
    }
}