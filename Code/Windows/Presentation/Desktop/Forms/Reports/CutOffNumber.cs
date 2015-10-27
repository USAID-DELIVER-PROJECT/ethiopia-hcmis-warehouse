using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraReports.UI;
using HCMIS.Desktop.Reports.Finance;
using HCMIS.Desktop.ViewHelpers;
using HCMIS.Helpers;
using HCMIS.Desktop.Reports;

namespace HCMIS.Desktop.Forms.Reports
{
    [FormIdentifier("AL-CO-CO-RP", "Cut Off Number", "")]
    public partial class CutOffNumber : DevExpress.XtraEditors.XtraForm
    {
        private CutOffNumberReport cutOffNumberReport;
       
        public CutOffNumber()
        {
            InitializeComponent();
        }

        private void lkAccount_EditValueChanged(object sender, EventArgs e)
        {
            var ed = new EthiopianDate.EthiopianDate();
            if (lkFiscalYear.EditValue != null && lkAccount.EditValue != null)
            {
                FiscalYear fYear = new FiscalYear();
                fYear.LoadByPrimaryKey(Convert.ToInt32(lkFiscalYear.EditValue));
                //TODO: this has to be re-implemented. 
                cutOffNumberReport = new CutOffNumberReport(CurrentContext.LoggedInUserName);
                cutOffNumberReport.DataSource = ReceiveDoc.GetCutOffNumber(Convert.ToInt32(lkFiscalYear.EditValue), Convert.ToInt32(lkAccount.EditValue));
                cutOffNumberReport.xrMonth.Text = string.Format("{0}", ed.GetMonthName());
                cutOffNumberReport.xrAccount.Text = string.Format("{0}", lkAccount.Text);
                cutOffNumberReport.xrYear.Text = string.Format("{0}", fYear.Name );
                printControl1.PrintingSystem = cutOffNumberReport.PrintingSystem;
                cutOffNumberReport.CreateDocument();
            }
  
                
        }

        private void CutOffNumber_Load(object sender, EventArgs e)
        {
            lkAccount.SetupAccountEditor().SetDefaultAccount();
            FiscalYear year = new FiscalYear();
            year.LoadAll();
            lkFiscalYear.Properties.DataSource = year.DefaultView;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(cutOffNumberReport != null)
            {
                cutOffNumberReport.PrintDialog();
            }
           
        }

       
 

    }
}
