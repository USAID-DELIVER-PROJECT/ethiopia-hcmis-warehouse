using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace HCMIS.Reports.Reports
{
    public partial class Model20Report : DevExpress.XtraReports.UI.XtraReport
    {
        public Model20Report()
        {
            InitializeComponent();
        }

        public Model20Report(string HospitalName, string EthIssueDate,string sentTo ,Image logo)
        {
            InitializeComponent();
            hospitalName.Text = HospitalName;
            issuedDate.Text = EthIssueDate;
            IssuedTo.Text = sentTo;
            xrPictureBox1.Image = logo;
        }



    }
}
