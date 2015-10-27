using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace HCMIS.Reports.Reports
{
    public partial class Model19Report : DevExpress.XtraReports.UI.XtraReport
    {
        public Model19Report()
        {
            InitializeComponent();
        }

        public Model19Report(string HospitalName ,string Date ,Image logo)
        {
            InitializeComponent();
            hospitalName.Text = HospitalName;
            receiveDate.Text = Date;
            xrPictureBox1.Image = logo;

        }


    }
}
