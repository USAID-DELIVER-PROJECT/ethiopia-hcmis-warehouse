using System.Drawing.Printing;
using BLL;

namespace HCMIS.Reports.Reports
{
    public partial class AnnualRevenueExtraReport : DevExpress.XtraReports.UI.XtraReport
    {
        public AnnualRevenueExtraReport()
        {
            InitializeComponent();
            xrPboxPFSALogo.ImageUrl = GeneralInfo.Current.LogoUrl;
            xrlblPrintedBy.Text = CurrentContext.LoggedInUser.FullName;
            
            xrlblHubName.Text = GeneralInfo.Current.HospitalName;
        }

    }
}
