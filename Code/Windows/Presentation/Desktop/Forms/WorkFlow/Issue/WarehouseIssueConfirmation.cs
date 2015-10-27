using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using HCMIS.Desktop.Forms.Reports;
using HCMIS.Helpers;


namespace HCMIS.Desktop.Forms.WorkFlow.Issue
{
    [FormIdentifier("DI-MA-IC-CN", "Warehouse Issue Confirmation", "Warehouse Issue Confirmation")]
    public partial class WarehouseIssueConfirmation : Form
    {
        private BLL.Issue issue = new BLL.Issue();

        public WarehouseIssueConfirmation()
        {
            InitializeComponent();
        }

        private void InvoiceCheck_Load(object sender, EventArgs e)
        {
            issue.LoadAllNotChecked(CurrentContext.UserId);
            grdSTVs.DataSource = issue.DefaultView;

            double total = BLL.Issue.GetTotalInvoices();
            double unconfirmed = BLL.Issue.GetUnconfirmedInvoices();
            double confirmed = BLL.Issue.GetConfirmedInvoices();
            
            //Let's do the percentage calculations.
            double pcUnconfirmed = Math.Round((unconfirmed/total)*100, 2);
            double pcConfirmed = Math.Round(100 - pcUnconfirmed, 2);

            lblStatistics.Text = string.Format("Total: {0},     Unconfirmed: {1} ({2}%),    Confirmed: {3} ({4}%)",
                                               total, unconfirmed, pcUnconfirmed, confirmed, pcConfirmed);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            issue.SaveInvoiceChecked();
            XtraMessageBox.Show("Save Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void repositoryItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            var row = grdViewSTVForChecking.GetFocusedDataRow();
            var chk = (DevExpress.XtraEditors.CheckEdit) sender;

            row["IsChanged"] = true;
        }

        private void grdViewSTVForChecking_DoubleClick(object sender, EventArgs e)
        {
            var row = grdViewSTVForChecking.GetFocusedDataRow();
            var stvID = Convert.ToInt32(row["ID"]);
            var activityName = row["ActivityName"].ToString();

            var detail = new IssueSTVInvoiceDetail(stvID, activityName);
            detail.ShowDialog();
        }

        private void txtSTVNoFilter_EditValueChanged(object sender, EventArgs e)
        {
            grdViewSTVForChecking.ActiveFilterString = string.Format("IDPrinted LIKE '%{0}%'", txtSTVInvoiceFilter.Text);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog {Filter = "Excel Document (*.xlsx) | *.xlsx"};
            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                grdSTVs.ExportToXlsx(dialog.FileName);
            }
        }
    }
}