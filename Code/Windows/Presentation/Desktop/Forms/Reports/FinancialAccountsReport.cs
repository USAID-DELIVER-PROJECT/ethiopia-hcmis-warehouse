using System;
using System.ComponentModel;
using System.Data;
using BLL;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using HCMIS.Helpers;
using HCMIS.Desktop.Modals;
using HCMIS.Desktop.ViewHelpers;

namespace HCMIS.Desktop.Forms.WorkFlow
{
    [FormIdentifier("RP-AT-AT-RP","Financial Account Report","")]
    public partial class FinancialAccountReport : XtraForm
    {
        BLL.Receipt receipt = new BLL.Receipt();


        //For Master and Detail we need to create a dataset that holds both tables
        DataSet ds = new DataSet();

        #region Initialization and Mode Settings

        public FinancialAccountReport()
        {
            InitializeComponent();

        }

        private void PutAwayListsLoad(object sender, EventArgs e)
        {

            //Load Mode->Account->SubAccount Selection
            //Lookup For Accounts
            lkAccount.SetupActivityEditor().SetDefaultActivity();
         
        }
        #endregion

        
        private void btnGO_Click(object sender, EventArgs e)
        {
              if (lkAccount.EditValue != null)
            {
                gridMain.DataSource = BLL.IssueDoc.GetCostOfGoodSold(Convert.ToInt32(lkAccount.EditValue),dtFromDate.Value,dtToDate.Value);
            }
        }

    }
}