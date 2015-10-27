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
using HCMIS.Desktop.ViewHelpers;
using HCMIS.Helpers;


namespace HCMIS.Desktop.Forms.WorkFlow.Issue
{
    [FormIdentifier("RP-ID-ID-RP", "Invoice Description", "Invoice Description")]
    public partial class InvoiceDescription : Form
    {
        private BLL.Issue issue = new BLL.Issue();

        public InvoiceDescription()
        {
            InitializeComponent();
        }

        private void InvoiceCheck_Load(object sender, EventArgs e)
        {
            LoadAccounts();
        }

        private void lkAccount_EditValueChanged(object sender, EventArgs e)
        {
            issue.GetIssueDescriptions(Convert.ToInt32(lkAccount.EditValue));
            grdSTVs.DataSource = issue.DefaultView;
        }

        private void LoadAccounts()
        {
            lkAccount.SetupAccountEditor().SetDefaultAccount();
        }
       

    }
}