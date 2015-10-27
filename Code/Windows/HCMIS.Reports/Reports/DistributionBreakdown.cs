using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace HCMIS.Desktop.Reports
{
    public partial class DistributionBreakdown : DevExpress.XtraReports.UI.XtraReport
    {
        public DistributionBreakdown()
        {
            InitializeComponent();
            pxLogo.ImageUrl = BLL.GeneralInfo.Current.LogoUrl;
        }

    }
}
