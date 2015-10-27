using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace HCMIS.Desktop.Reports
{
    public partial class PriceList : DevExpress.XtraReports.UI.XtraReport
    {
        public PriceList()
        {
            InitializeComponent();
            pxLogo.ImageUrl = BLL.GeneralInfo.Current.LogoUrl;
        }

        private void PriceList_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
        }

    }
}
