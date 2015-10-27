
using System;
namespace HCMIS.Desktop.Reports
{
    public partial class InventoryOverageShortageReport: DevExpress.XtraReports.UI.XtraReport
    {
        public InventoryOverageShortageReport(string userFullName)
        {
            InitializeComponent();
            PrintUserDetailOnReport(userFullName);
        }

        private void PrintUserDetailOnReport(string userFullName)
        {
            xrLabelReportPrintedBy.Text = string.Format("Printed by {0} on {1}", userFullName,
                                                        BLL.DateTimeHelper.ServerDateTime);
        }
    }
}