
using HCMIS.Reports.Workflow;

namespace HCMIS.Desktop.Reports
{
    public partial class PickList : DevExpress.XtraReports.UI.XtraReport, IPicklist
    {
        
        public PickList()
        {
            InitializeComponent();
        }

        #region Implementation of IPicklist

        public string ToLabel { get { return To.Text; } set { To.Text = value; } }
        public string IDLabel { get { return ID.Text; } set { ID.Text = value; } }
        public string DateLabel { get { return Date.Text; } set { Date.Text = value; } }
        public string PreparedByLabel { get { return PreparedBy.Text; } set { PreparedBy.Text = value; } }
        public string ApprovedByLabel { get { return ApprovedBy.Text; } set { ApprovedBy.Text = value; } }
        public string ContactPersonNameLabel { get; set; }
        #endregion
    }
}
