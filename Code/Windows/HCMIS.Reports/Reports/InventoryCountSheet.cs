
using System;
namespace HCMIS.Desktop.Reports
{
    public partial class InventoryCountSheet: DevExpress.XtraReports.UI.XtraReport
    {
        public InventoryCountSheet(string userFullName)
        {
            InitializeComponent();
            PrintUserDetailOnReport(userFullName);
            pxLogo.ImageUrl = BLL.GeneralInfo.Current.LogoUrl;
        }

        private void PrintUserDetailOnReport(string userFullName)
        {
            xrLabelReportPrintedBy.Text = string.Format("Printed by {0} on {1}", userFullName,
                                                        BLL.DateTimeHelper.ServerDateTime);
        }
    }
}