using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace HCMIS.Reports.Workflow.Activities
{
    public partial class Disposal : DevExpress.XtraReports.UI.XtraReport
    {
         public Disposal(string Activity, string LicenseNo, DateTime Date, DataTable items)
        {
            InitializeComponent();
            xrActivity.Text = Activity;
            xrLicenseNo.Text = LicenseNo;
            xrDateOfDisposal.Text = Date.ToShortDateString();
            bindingSource1.DataSource = items;
        }

    }
}
