using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace HCMIS.Desktop.Reports
{
    public partial class GoodsReceivingNote : DevExpress.XtraReports.UI.XtraReport
    {
        public GoodsReceivingNote()
        {
            InitializeComponent();
            pxLogo.ImageUrl = BLL.GeneralInfo.Current.LogoUrl;
        }

    }
}
