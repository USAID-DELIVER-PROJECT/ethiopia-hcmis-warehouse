using System.Drawing;
using BLL;
using DevExpress.XtraReports.UI;

namespace HCMIS.Desktop.Reports.Reports
{
    public partial class BinCardReport : XtraReport
    {
        public BinCardReport()
        {
            InitializeComponent();
            pxLogo.ImageUrl = GeneralInfo.Current.LogoUrl;
        }
    }
}
