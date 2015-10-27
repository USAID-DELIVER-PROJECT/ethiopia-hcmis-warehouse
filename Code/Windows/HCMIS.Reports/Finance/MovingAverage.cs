using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using BLL;

namespace HCMIS.Desktop.Reports
{
    public partial class MovingAverage : DevExpress.XtraReports.UI.XtraReport
    {
        int ReceiptID;
        public MovingAverage()
        {
            InitializeComponent();
            pxLogo.ImageUrl = BLL.GeneralInfo.Current.LogoUrl;
        }
        public MovingAverage(int ReceiptID)
        {
            this.ReceiptID = ReceiptID;
            InitializeComponent();
            pxLogo.ImageUrl = BLL.GeneralInfo.Current.LogoUrl;
           }

        private void xrLabel1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
       
    }
}
