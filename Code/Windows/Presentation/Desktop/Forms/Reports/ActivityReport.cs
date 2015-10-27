using System;
using System.Data;
using DevExpress.XtraEditors;
using HCMIS.Helpers;

namespace HCMIS.Desktop.Forms.Reports
{
    [FormIdentifier("RP-AR-AR-RP","Activity Report","")]
    public partial class ActivityReport : XtraForm
    {
        public ActivityReport()
        {
            InitializeComponent();
        }

        private void ActivityReport_Load(object sender, EventArgs e)
        {
            radioGroup1_EditValueChanged(null, null);
        }

        private void radioGroup1_EditValueChanged(object sender, EventArgs e)
        {
            BLL.IssueDoc id = new BLL.IssueDoc();

            DataSet ds = null;
            if (radioGroup1.EditValue.ToString() == "RefNo")
            {
                ds = id.GetActivityDataSet();
            }
            else if (radioGroup1.EditValue.ToString() == "ItemTypes")
            {
                ds = id.GetActivityDataSetByItemType();
            }
            else
            {
                ds = id.GetActivityDataSetByPack();
            }
            chartControl1.Series[0].DataSource = ds.Tables[0];
            chartControl1.Series[1].DataSource = ds.Tables[1];


        }
    }
}
