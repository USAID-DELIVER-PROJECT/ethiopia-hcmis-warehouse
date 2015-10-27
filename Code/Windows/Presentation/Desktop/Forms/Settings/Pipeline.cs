using System;
using System.Data;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using HCMIS.Desktop.Helpers;
using HCMIS.Helpers;

namespace HCMIS.Desktop
{
    [FormIdentifier("AD-PL-PL-FR","Pipe Line","")]
    public partial class Pipeline : XtraForm
    {
        public Pipeline()
        {
            InitializeComponent();
        }
       
        int pipelineId = 0;
        private void Pipeline_Load(object sender, EventArgs e)
        {
            SetPermission();
            DataTable dtMonths = new DataTable();
            dtMonths.Columns.Add("Value");
            dtMonths.Columns.Add("Month");
            for (int i = 1; i <= 12; i++)
            {
                object[] obj = { i, (i + " Month")};
                dtMonths.Rows.Add(obj);
            }
            cboLeadTime.DataSource = dtMonths;

            DataTable dtMonths2 = new DataTable();
            dtMonths2.Columns.Add("Value");
            dtMonths2.Columns.Add("Month");
            for (int i = 1; i <= 12; i++)
            {
                object[] obj = { i, (i + " Month") };
                dtMonths2.Rows.Add(obj);
            }
               
                cboSafety.DataSource = dtMonths2;
            
                DataTable dtMonths3 = new DataTable();
                dtMonths3.Columns.Add("Value");
                dtMonths3.Columns.Add("Month");
                for (int i = 1; i <= 12; i++)
                {
                    object[] obj = { i, (i + " Month") };
                    dtMonths3.Rows.Add(obj);
                }

                cboReview.DataSource = dtMonths3;

                DataTable dtEOP = new DataTable();
                dtEOP.Columns.Add("Value");
                dtEOP.Columns.Add("Month");
                //object[] obj01 = { 0.25, "1 Weeks" };
                //dtEOP.Rows.Add(obj01);
                object[] obj0 = { 0.5, "2 Weeks" };
                dtEOP.Rows.Add(obj0);
            object[] obj1 = { 0.75, ("3 Weeks") };
            dtEOP.Rows.Add(obj1);
                    object[] obj2 = { 1, (1 + " Month") };
                    dtEOP.Rows.Add(obj2);
                    object[] obj3 = { 2, (2 + " Month") };
                    dtEOP.Rows.Add(obj3);
                    cboEOP.DataSource = dtEOP;

                    DataTable dtdumin = new DataTable();
                    dtdumin.Columns.Add("Value");
                    dtdumin.Columns.Add("Month");
                    object[] objdumin01 = { 0.25, "1 Weeks" };
                    dtdumin.Rows.Add(objdumin01);
                    object[] objdumin0 = { 0.5, "2 Weeks" };
                    dtdumin.Rows.Add(objdumin0);
                    object[] objdumin1 = { 0.75, ("3 Weeks") };
                    dtdumin.Rows.Add(objdumin1);
                    object[] objdumin2 = { 1, (1 + " Month") };
                    dtdumin.Rows.Add(objdumin2);
                    object[] objdumin3 = { 2, (2 + " Month") };
                    dtdumin.Rows.Add(objdumin3);
                    cboDUMin.DataSource = dtdumin;

                    DataTable dtdumax = new DataTable();
                    dtdumax.Columns.Add("Value");
                    dtdumax.Columns.Add("Month");
                    object[] objdumax01 = { 0.25, "1 Weeks" };
                    dtdumax.Rows.Add(objdumax01);
                    object[] objdumax010 = { 0.5, "2 Weeks" };
                    dtdumax.Rows.Add(objdumax010);
                    object[] objdumax011 = { 0.75, ("3 Weeks") };
                    dtdumax.Rows.Add(objdumax011);
                    object[] objdumax012 = { 1, (1 + " Month") };
                    dtdumax.Rows.Add(objdumax012);
                    object[] objdumax013 = { 2, (2 + " Month") };
                    dtdumax.Rows.Add(objdumax013);
                    cboDUMax.DataSource = dtdumax;

                    DataTable dtAmcRange = new DataTable();
                    dtAmcRange.Columns.Add("Value");
                    dtAmcRange.Columns.Add("Month");
                    object[] objamcR01 = { 3, (3 + " Month") };
                    dtAmcRange.Rows.Add(objamcR01);
                    object[] objamcR010 = { 6, (6 + " Month") };
                    dtAmcRange.Rows.Add(objamcR010);
                    object[] objamcR011 = { 12, (12 + " Month") };
                    dtAmcRange.Rows.Add(objamcR011);
                    cboAmcRange.DataSource = dtAmcRange;

            PopulateFields();
        }

        private void SetPermission()
        {
            if (BLL.Settings.UseNewUserManagement)
            {
                btnSave.Enabled = this.HasPermission("Save");
            }
        }

        private void PopulateFields()
        {

            cboLeadTime.SelectedValue = GeneralInfo.Current.LeadTime.ToString();
            cboSafety.SelectedValue = GeneralInfo.Current.SafteyStock.ToString();
            cboReview.SelectedValue = GeneralInfo.Current.ReviewPeriod.ToString();
            cboEOP.SelectedValue = GeneralInfo.Current.EOP.ToString();
            txtMin.Text = GeneralInfo.Current.Min.ToString() + " Month";
            txtmax.Text = GeneralInfo.Current.Max.ToString() + " Month";
            cboDUMax.SelectedValue = GeneralInfo.Current.DUMax.ToString();
            cboDUMin.SelectedValue = GeneralInfo.Current.DUMin.ToString();
            cboAmcRange.SelectedValue = GeneralInfo.Current.AMCRange.ToString();
            rdEven.Checked = GeneralInfo.Current.IsEven;
            rdOdd.Checked = !GeneralInfo.Current.IsEven;
            pipelineId = GeneralInfo.Current.ID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure you want to apply these Settings?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (pipelineId != 0)
                {
                    GeneralInfo.Current.LoadByPrimaryKey(pipelineId);
                    GeneralInfo.Current.SafteyStock = Convert.ToInt32(cboSafety.SelectedValue);
                    GeneralInfo.Current.LeadTime = Convert.ToInt32(cboLeadTime.SelectedValue);
                    GeneralInfo.Current.ReviewPeriod = Convert.ToInt32(cboReview.SelectedValue);
                    GeneralInfo.Current.Max = Convert.ToInt32(cboLeadTime.SelectedValue) + Convert.ToInt32(cboSafety.SelectedValue) + Convert.ToInt32(cboReview.SelectedValue);
                    GeneralInfo.Current.Min = Convert.ToInt32(cboLeadTime.SelectedValue) + Convert.ToInt32(cboSafety.SelectedValue);
                    GeneralInfo.Current.EOP = Convert.ToDouble(cboEOP.SelectedValue);
                    GeneralInfo.Current.IsEven = rdEven.Checked;
                    GeneralInfo.Current.DUMin = Convert.ToDouble(cboDUMin.SelectedValue);
                    GeneralInfo.Current.DUMax = Convert.ToDouble(cboDUMax.SelectedValue);
                    GeneralInfo.Current.AMCRange = Convert.ToInt32(cboAmcRange.SelectedValue);
                    GeneralInfo.Current.Save();
                    PopulateFields();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            PopulateFields();
        }

        private void cboReview_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CalculateMinMax();
        }

        private void CalculateMinMax()
        {
            if (cboLeadTime.SelectedValue != null && cboSafety.SelectedValue != null)
            {
                int min = Convert.ToInt32(cboLeadTime.SelectedValue) + Convert.ToInt32(cboSafety.SelectedValue) ;
                txtMin.Text = min.ToString() + " Month";
                if(cboReview.SelectedValue != null)
                {
                    int max = Convert.ToInt32(cboReview.SelectedValue) + min;
                    txtmax.Text = max.ToString() + " Month";
                }
            }
        }


    }
}