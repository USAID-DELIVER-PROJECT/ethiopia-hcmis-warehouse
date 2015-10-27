using System;
using System.Data;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using HCMIS.Desktop.ViewHelpers;
using HCMIS.Helpers;
using HCMIS.Desktop.Reports;

namespace HCMIS.Desktop.Forms.Reports
{
    [FormIdentifier("RP-RES-RES-RP","Expired Product Report","")]
    public partial class ReservedProducts : XtraForm
    {
        DataTable ExpiredList = new DataTable();
        public ReservedProducts()
        {
            InitializeComponent();

            ExpiredList.Columns.Add("No", typeof(int));
            ExpiredList.Columns.Add("ID", typeof(int));
            ExpiredList.Columns.Add("StockCode");
            ExpiredList.Columns.Add("FullItemName");
            ExpiredList.Columns.Add("ExpiryDate");
            ExpiredList.Columns.Add("BatchNo");
            ExpiredList.Columns.Add("Quantity", typeof(int));
            ExpiredList.Columns.Add("Amount in Birr", typeof(float));
            ExpiredList.Columns.Add("MOS");
        }

        int catID = 0;

        private void ManageItems_Load(object sender, EventArgs e)
        {
            lkMode.SetupModeEditor().SetDefaultMode();
        }

        private void PopulateReservations()
        {
            if (lkMode.EditValue != null)
            {
                int modeID = Convert.ToInt32(lkMode.EditValue);
                gridDetailReport.DataSource = BLL.Balance.GetReservedItemsWithAmount(modeID);
                lblState.Text = "Reservations";
            }
        }

        

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ExpiryReport nexreport = new ExpiryReport();
            nexreport.HubName.Text = GeneralInfo.Current.HospitalName;
            nexreport.TitleTwo.Text = "Reservations";

            DataSet ds = new DataSet();
            (gridDetailReport.DataSource as DataTable).TableName = "NearExpiry";
            ds.Tables.Add((gridDetailReport.DataSource as DataTable));

            nexreport.DataSource = ds;
            nexreport.ShowPreviewDialog();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if(sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK){
                gridDetailReport.ExportToXlsx(sfd.FileName + ".xlsx");
                XtraMessageBox.Show("The file has been exported.");
            }

            
        }

        private void lkMode_EditValueChanged(object sender, EventArgs e)
        {
            PopulateReservations();
        }

        private void grpByItems_CheckedChanged(object sender, EventArgs e)
        {
            PopulateReservations();
        }
        
    }
}