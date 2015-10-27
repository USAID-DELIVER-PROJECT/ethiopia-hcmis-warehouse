using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace HCMIS.Desktop.Reports.Finance
{
    public partial class PriceOverridePrintout : DevExpress.XtraReports.UI.XtraReport
    {
        public PriceOverridePrintout()
        {
            InitializeComponent();
            pxLogo.ImageUrl = BLL.GeneralInfo.Current.LogoUrl;
        }

    }
}
