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
    [FormIdentifier("RP-EP-EP-RP","Expired Product Report","")]
    public partial class ExpiredProducts : XtraForm
    {
        DataTable ExpiredList = new DataTable();
        public ExpiredProducts()
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
            lkWarehouse.Properties.DataSource = BLL.Warehouse.GetWarehouseWithCluster(CurrentContext.UserId);
            lkWarehouse.ItemIndex = 0;
            var modes = new Mode();
            lkMode.SetupModeEditor().SetDefaultMode();
        }

        private void PopulateExpiredItems()
        {
            if (lkMode.EditValue != null)
            {
                int modeID = Convert.ToInt32(lkMode.EditValue);
                int warehouseID = Convert.ToInt32(lkWarehouse.EditValue);
                Item itm = new Item();
                if (grpByItems.Checked)
                {
                    gridDetailReport.DataSource = itm.GetExpiredItems(modeID ,warehouseID);
                    colAccount.Visible = false;
                    colDayDifference.Visible = false;
                    colReceivedDate.Visible = false;
                    colReceivedQuantity.Visible = false;
                }
                else
                {
                    gridDetailReport.DataSource = itm.GetExpiredItemsByBatch(modeID ,warehouseID);
                    colAccount.Visible = true;
                    colDayDifference.Visible = true;
                    colReceivedDate.Visible = true;
                    colReceivedQuantity.Visible = true;
                }
                lblState.Text = "Expired Items";
            }
        }

        

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ExpiryReport nexreport = new ExpiryReport();
            nexreport.HubName.Text = GeneralInfo.Current.HospitalName;
            nexreport.TitleTwo.Text = "Expired Products";

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
            PopulateExpiredItems();
        }

        private void grpByItems_CheckedChanged(object sender, EventArgs e)
        {
            PopulateExpiredItems();
        }

        
        private void btnGo_Click(object sender, EventArgs e)
        {
            var itm = new Item();
            if (!grpByItems.Checked)
                gridDetailReport.DataSource = itm.GetExpiredItemsByReceivedDate(Convert.ToInt32(lkMode.EditValue), Convert.ToDateTime(dateFrom.Text), Convert.ToDateTime(dateTo.Text), Convert.ToInt32(lkWarehouse.EditValue));
        }

        private void dateFrom_EditValueChanged(object sender, EventArgs e)
        {
            btnGo.Enabled = dateFrom.EditValue != null;
        }

        private void lkWarehouse_EditValueChanged(object sender, EventArgs e)
        {
            PopulateExpiredItems();
        }

        
        
    }
}