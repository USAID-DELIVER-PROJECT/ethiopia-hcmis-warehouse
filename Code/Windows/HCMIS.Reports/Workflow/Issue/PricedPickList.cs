
using HCMIS.Reports.Workflow;

namespace HCMIS.Desktop.Reports
{
    public partial class PricedPickList : DevExpress.XtraReports.UI.XtraReport,IPicklist
    {
        public string ToLabel { get { return To.Text; } set { To.Text = value; } }
        public string IDLabel { get { return ID.Text; } set { ID.Text = value; } }
        public string DateLabel { get { return Date.Text; } set { Date.Text = value; } }
        public string PreparedByLabel { get { return PreparedBy.Text; } set { PreparedBy.Text = value; } }
        public string ApprovedByLabel { get { return ApprovedBy.Text; } set { ApprovedBy.Text = value; } }
        public string ContactPersonNameLabel { get { return ContactPersonName.Text; } set { ContactPersonName.Text = value; } }
          
        private DevExpress.XtraReports.UI.TopMarginBand topMarginBand1;
        private DevExpress.XtraReports.UI.DetailBand detailBand1;
        private DevExpress.XtraReports.UI.BottomMarginBand bottomMarginBand1;
    
        public PricedPickList()
        {
            InitializeComponent();
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.detailBand1 = new DevExpress.XtraReports.UI.DetailBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // topMarginBand1
            // 
            this.topMarginBand1.Name = "topMarginBand1";
            // 
            // detailBand1
            // 
            this.detailBand1.Name = "detailBand1";
            // 
            // bottomMarginBand1
            // 
            this.bottomMarginBand1.Name = "bottomMarginBand1";
            // 
            // PricedPickList
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.topMarginBand1,
            this.detailBand1,
            this.bottomMarginBand1});
            this.Version = "11.2";

            xrInvoiceNoValue.Text = BLL.GeneralInfo.Current.HospitalName;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }

        private void xrLabel3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void ID_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void xrLabel7_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void Date_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

    }
}
