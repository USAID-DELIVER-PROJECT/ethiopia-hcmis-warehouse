
using HCMIS.Reports.Workflow;

namespace HCMIS.Desktop.Reports
{
    public partial class IssueOrderList : DevExpress.XtraReports.UI.XtraReport,IPicklist
    {
        public string ToLabel { get { return To.Text; } set { To.Text = value; } }
        public string IDLabel { get { return ID.Text; } set { ID.Text = value; } }
        public string DateLabel { get { return Date.Text; } set { Date.Text = value; } }
        public string PreparedByLabel { get { return PreparedBy.Text; } set { PreparedBy.Text = value; } }
        public string ApprovedByLabel { get { return ApprovedBy.Text; } set { ApprovedBy.Text = value; } }
        public string ContactPersonNameLabel { get; set; }
        //public string ContactPersonNameLabel { get { return ContactPersonName.Text; } set { ContactPersonName.Text = value; } }
        
        public IssueOrderList()
        {
            InitializeComponent();
            xrInvoiceNoValue.Text = BLL.GeneralInfo.Current.HospitalName;
        }

    }
}
