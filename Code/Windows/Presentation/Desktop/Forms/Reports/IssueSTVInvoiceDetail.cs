using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;

namespace HCMIS.Desktop.Forms.Reports
{

    public partial class IssueSTVInvoiceDetail : Form
    {
        private int _stvID;
        private string _activityName;
        private BLL.Issue _issue=new Issue();

        public IssueSTVInvoiceDetail(int stvID, string activityName)
        {
            InitializeComponent();
            _stvID = stvID;
            _activityName = activityName;
        }

        private void IssueSTVInvoiceDetail_Load(object sender, EventArgs e)
        {
            _issue.LoadSTVDetails(_stvID);
            grdSTVInvoiceDetail.DataSource = _issue.DefaultView;

            BLL.Issue issue = new Issue();
            issue.LoadByPrimaryKey(_stvID);

            lblDescription.Text =
                string.Format("STV/Invoice No: {0}  Activity Name: {1}",
                              issue.IsColumnNull("IDPrinted")
                                  ? issue.IDPrinted.ToString()
                                  : issue.IDPrinted.ToString() + "(Reprinted)",
                              _activityName);
        }
    }
}
