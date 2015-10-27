using System;
using System.Data;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using HCMIS.Helpers;
using HCMIS.Reports.Reports;

namespace HCMIS.Desktop.Forms.Reports
{
    [FormIdentifier("RP-RV-RV-RP", "Revenue", "")]
    public partial class AnnualRevenueReport : Form
    {
        readonly IssueDoc _dataSource = new IssueDoc();
        readonly AnnualRevenueExtraReport _report = new AnnualRevenueExtraReport();
        public AnnualRevenueReport()
        {
            InitializeComponent();
        }

        private void AnnualRevenueReport_Load(object sender, EventArgs e)
        {
            gridAnnualRevenue.DataSource = _dataSource.DefaultView;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
           _report.DataSource = gridViewAnnualRevenue.DataSource as DataView;
           _report.ShowPreviewDialog();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var sfd  = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                var from = (DateTime)dEFrom.EditValue;
                var to = (DateTime)dEditTo.EditValue;
                _dataSource.LoadAnnualIssuedAmountForInstitutionsByDateRange(from, to);
                _report.DataSource = _dataSource.DefaultView;

                _report.ExportToXlsx(sfd.FileName + ".xlsx");
                XtraMessageBox.Show("Finished Exporting");
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            var from =(DateTime) dEFrom.EditValue;
            var to =(DateTime) dEditTo.EditValue;
            _dataSource.LoadAnnualIssuedAmountForInstitutionsByDateRange(from,to);
            gridAnnualRevenue.DataSource = _dataSource.DefaultView;
        }
    }
}
