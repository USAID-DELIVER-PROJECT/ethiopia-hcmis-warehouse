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
    [FormIdentifier("RP-NE-ED-RP","Nearly Expired Products","")]
    public partial class NearlyExpired : XtraForm
    {
        public NearlyExpired()
        {
            InitializeComponent();
        }
        int catID = 0;
        DataTable NearExpiryList = new DataTable();

        private void ManageItems_Load(object sender, EventArgs e)
        {

            // initalize the near expiry list
            lkCategories1.Properties.DataSource = lkCategories.Properties.DataSource = BLL.CommodityType.GetAllTypes();
            lkCategories.ItemIndex = 0;
            lkCategories1.ItemIndex = 0;
            
            lkCategories.Properties.DataSource = BLL.CommodityType.GetAllTypes();
            lkCategories.ItemIndex = 0;

            lkWarehouse.Properties.DataSource =BLL.Warehouse.GetWarehouseWithCluster(CurrentContext.UserId);
            lkWarehouse.ItemIndex = 0;
            
            lkWarehouse1.Properties.DataSource = BLL.Warehouse.GetWarehouseWithCluster(CurrentContext.UserId);
            lkWarehouse1.ItemIndex = 0;

            lkWarehouse1.Properties.DataSource = BLL.Warehouse.GetWarehouseWithCluster(CurrentContext.UserId);
            lkWarehouse1.ItemIndex = 0;

            PopulateItemList();
            lkModeTab1.SetupModeEditor().SetDefaultMode();
            lkMode.SetupModeEditor();
               
        }

        

        public void PopulateItemList()
        {
            gridDetailReport.Enabled = false;
            // detach the datasource binding for thread safty.
            //gridDetailReport.DataSource = null;
            //bw.RunWorkerAsync(dtItem);
            int category = Convert.ToInt32(lkCategories.EditValue);
            int warehouseID = Convert.ToInt32(lkWarehouse1.EditValue);
            int months = Convert.ToInt32(cboMonths.EditValue.ToString().Substring(0, cboMonths.EditValue.ToString().IndexOf(' ')));
            if (!chkGroup.Checked)
            {
                gridDetailReport.DataSource = Item.GetNearlyExpiredItemsByBatch(Convert.ToInt32(lkMode.EditValue), months, category, warehouseID);
            }
            else
            {
                gridDetailReport.DataSource = Item.GetNearlyExpiredItems(Convert.ToInt32(lkMode.EditValue), months, category ,warehouseID);
            }
            gridDetailReport.Enabled = true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            (gridDetailReport.DataSource as DataView).Table.TableName = "NearExpiry";
            ds.Tables.Add((gridDetailReport.DataSource as DataView).Table);


            ExpiryReport nexReport = new ExpiryReport();
            nexReport.DataSource = ds;

            nexReport.HubName.Text = GeneralInfo.Current.HospitalName;
            nexReport.ShowPreviewDialog();

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                gridDetailReport.ExportToXlsx(sfd.FileName + ".xlsx");
                XtraMessageBox.Show("The Near expiry list has been exported.");
            }
        }



        private void PopulateItems(object sender, EventArgs e)
        {
            PopulateItemList();
        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            if (lkMode.EditValue != null)
            {
                gridItemChoiceView.ActiveFilterString = "[FullItemName] Like '" + txtItemName.Text + "%'";
            }
        }

        private void lkCategories_EditValueChanged(object sender, EventArgs e)
        {
            PopulateItemList();
        }

        private void lkCategories1_EditValueChanged(object sender, EventArgs e)
        {
            gridNearExpiryBreakdown.DataSource = Item.GetNearExpiryBreakdown(Convert.ToInt32(lkCategories1.EditValue),
                                                                              Convert.ToInt32(lkModeTab1.EditValue));
        }

        private void btnExport_Click_1(object sender, EventArgs e)
        {
            gridNearExpiryBreakdown.ShowPrintPreview();
        }

        private void lkMode_EditValueChanged(object sender, EventArgs e)
        {
            PopulateItemList();
        }

        private void lkModeTab1_EditValueChanged(object sender, EventArgs e)
        {
            gridNearExpiryBreakdown.DataSource = Item.GetNearExpiryBreakdown(Convert.ToInt32(lkCategories1.EditValue),
                                                                              Convert.ToInt32(lkModeTab1.EditValue));
        }

        private void lkWarehouse_EditValueChanged(object sender, EventArgs e)
        {
            gridNearExpiryBreakdown.DataSource = Item.GetNearExpiryBreakdown(Convert.ToInt32(lkCategories1.EditValue),Convert.ToInt32(lkModeTab1.EditValue) ,Convert.ToInt32(lkWarehouse.EditValue));
        }

    }

}