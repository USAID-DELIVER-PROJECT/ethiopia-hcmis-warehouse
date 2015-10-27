
namespace HCMIS.Reports.Reports
{
    public partial class OutstandingTransactions : DevExpress.XtraReports.UI.XtraReport
    {
 

        public OutstandingTransactions(string printedBy)
        {
            InitializeComponent();
            xrPrintedBy.Text = string.Format("Printed By: {0}", printedBy);
            pxLogo.ImageUrl = BLL.GeneralInfo.Current.LogoUrl;
        }

    }
}
