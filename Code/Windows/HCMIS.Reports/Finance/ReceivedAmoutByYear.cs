using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace HCMIS.Desktop.Reports
{
    public partial class ReceivedAmoutByYear : DevExpress.XtraReports.UI.XtraReport
    {
        public ReceivedAmoutByYear(string userFullName)
        {
            InitializeComponent();
            PrintUserDetailOnReport(userFullName);
            pxLogo.ImageUrl = BLL.GeneralInfo.Current.LogoUrl;
        }

        private void PrintUserDetailOnReport(string userFullName)
        {
           PrintedBy.Text = string.Format("Printed by {0} on {1} , HCMIS {2}", userFullName,
                                                        BLL.DateTimeHelper.ServerDateTime,System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

    }
}
