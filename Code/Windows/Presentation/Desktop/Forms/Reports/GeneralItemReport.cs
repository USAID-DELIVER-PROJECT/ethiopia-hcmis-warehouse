using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BLL;
using System.Collections;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraReports.UI;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraEditors.Controls;
using HCMIS.Desktop.Helpers;
using HCMIS.Helpers;
using HCMIS.Desktop.Reports.Helpers;
using HCMIS.Desktop.Reports.Reports;
using HCMIS.Reports.Helpers;

//using HCMIS.Reports.Views;

namespace HCMIS.Desktop.Forms.Reports
{
    [FormIdentifier("RP-CG-ID-ID", "Item Detail Report", "")]
    public partial class GeneralItemReport : DevExpress.XtraEditors.XtraForm
    {
        private BinCardReport binCardReport = null;
        private StockCardReport stockCardReport = null;
        
        #region Filter settings
        // Settings For the Filter Option where User select A Commodity 
        bool ShowOnlyReceivedItemUnit = true;
        bool ShowOnlyReceivedManufacturer = true;
        bool ShowOnlyReceivedActivity = true;
        bool ShowOnlyReceivedPhysicalStore = true;

        #endregion

        #region Loading And ItemSelection
        // Loading of the Form and the left Side Menu where the User 
        // Select the commodities
        // Once Selected the Filter Get Populated
        int ItemID;
        public GeneralItemReport()
        {
            InitializeComponent();
        }

        private void GeneralItemReport_Load(object sender, EventArgs e)
        {
            LoadLeftSideList();
            if (BLL.Settings.UseNewUserManagement)
            {
                if (this.HasPermission("Show-Bin-Card"))
                {
                    tabBinCard.Visibility = LayoutVisibility.Always;
                }
                if (this.HasPermission("Show-Stock-Card"))
                {
                    tabStockCard.Visibility = LayoutVisibility.Always;
                }
            }else
            {
                tabBinCard.Visibility = tabStockCard.Visibility = LayoutVisibility.Always;
            }
            
        }

        private void LoadLeftSideList()
        {
            var commodityTypes = BLL.CommodityType.GetAllTypes();
            lkCommodityType.Properties.DataSource = commodityTypes;
            
        }

        private void grdItemListView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            DataRow selectedItem = grdItemListView.GetFocusedDataRow();
            if (selectedItem != null)
            {
                ItemID = Convert.ToInt32(selectedItem["ID"]);
                ClearSelection();
                LoadUnitsForSelectedItem();
                LoadManufacturerForSelectedItem();
                LoadAccountForSelectedItem();
                LoadPhysicalStoreForSelectedItem();
                LoadReport();
                LoadGRNFReport();
            }
        }

        private void ClearSelection()
        {
            lkBinCardUnit.EditValue = null;
            lkBinCardActivity.EditValue = null;
            lkBinCardWarehouse.EditValue = null;
            lkBinCardUnit_EditValueChanged(null,null);
            lkStockCardActivity.EditValue = null;
            lkStockCardUnit.EditValue = null;
            lkStockCardWarehouse.EditValue = null;
            lkStockCardUnit_EditValueChanged(null,null);

        }

        #endregion

        #region Filter
        // Load Filter
        // Construct the General Filter String 

        private void LoadUnitsForSelectedItem()
        {
            ItemUnit itemUnit = new ItemUnit();
            if (ShowOnlyReceivedItemUnit)
                itemUnit.LoadReceivedByItemID(ItemID);
            chkUnits.DataSource = itemUnit.DefaultView;
            lkStockCardUnit.Properties.DataSource = itemUnit.DefaultView;
            lkBinCardUnit.Properties.DataSource = itemUnit.DefaultView;
       
            chkUnits.CheckAll();
        }

        private void LoadManufacturerForSelectedItem()
        {
            BLL.ItemManufacturer itemManufacturer = new BLL.ItemManufacturer();
            if (ShowOnlyReceivedManufacturer)
                itemManufacturer.LoadManufactuererByItemWithReceive(ItemID);
            chkManufacturer.DataSource = itemManufacturer.DefaultView;
            lkStockCardManufacturer.Properties.DataSource = itemManufacturer.DefaultView;
          
            chkManufacturer.CheckAll();
        }

        private void LoadAccountForSelectedItem()
        {

            DataView dtActivity = Activity.GetTreeByItem(ItemID, CurrentContext.UserId);
            treeListActivity.DataSource = dtActivity;
            
            treeListActivity.CheckAll();
        }

        private void LoadPhysicalStoreForSelectedItem()
        {
            DataView dtPhyicalStore = PhysicalStore.LoadByItemID(ItemID, CurrentContext.UserId);
            treeListCluster.DataSource = dtPhyicalStore;
            dtPhyicalStore.RowFilter = "[Type] = 'Warehouse'";
            lkBinCardWarehouse.Properties.DataSource = dtPhyicalStore ;
            if (dtPhyicalStore.Count == 1)
            {
                lkBinCardWarehouse.ItemIndex = 0;
            }
            treeListCluster.CheckAll();
        }

        private string GenerateSelectionFilterStringbyNode(TreeListNodes Nodes,DevExpress.XtraTreeList.TreeList treeList)
        {
            string Filter = "";
            foreach (TreeListNode tn in Nodes)
            {       
                DataRowView dr = (treeList.GetDataRecordByNode(tn) as DataRowView);
                if (Convert.ToInt32(dr["Ordering"]) == 3 && tn.Checked)
                    Filter = Filter + dr["Value"] + ",";
                else
                    Filter = Filter + GenerateSelectionFilterStringbyNode(tn.Nodes, treeList);

            }
            return Filter;
        }

        private string GenerateSelectionFilterStringbyNodeNoLevel(TreeListNodes Nodes, DevExpress.XtraTreeList.TreeList treeList)
        {
            string Filter = "";
            foreach (TreeListNode tn in Nodes)
            {
                DataRowView dr = (treeList.GetDataRecordByNode(tn) as DataRowView);
                if (tn.Checked)
                    Filter = Filter + dr["Value"] + ",";
                else
                    Filter = Filter + GenerateSelectionFilterStringbyNode(tn.Nodes, treeList);

            }
            return Filter;
        }

        private string GenerateSelectionFilterForCheckList(CheckedListBoxControl chkList)
        {

            string Filter = "";
            foreach (DataRowView item in chkList.CheckedItems)
            {
               if(item != null)
                Filter = Filter + item["ID"] + ",";
            }

            return Filter;
        }

        private string GetFilterString()
        {
            string UnitFilter = GenerateSelectionFilterForCheckList(chkUnits);
            string ManufacturerFilter = GenerateSelectionFilterForCheckList(chkManufacturer);
            string ActivityFilter = GenerateSelectionFilterStringbyNode(treeListActivity.Nodes, treeListActivity);
            string PhysicalStoreFilter = GenerateSelectionFilterStringbyNodeNoLevel(treeListCluster.Nodes, treeListCluster);
           
            if (UnitFilter.Length != 0 && ManufacturerFilter.Length != 0 && ActivityFilter.Length != 0 && PhysicalStoreFilter.Length != 0)
             {
                 UnitFilter = UnitFilter.Substring(0, UnitFilter.Length - 1);
                 ManufacturerFilter = ManufacturerFilter.Substring(0, ManufacturerFilter.Length - 1);
                 ActivityFilter = ActivityFilter.Substring(0, ActivityFilter.Length - 1);
                 PhysicalStoreFilter = PhysicalStoreFilter.Substring(0, PhysicalStoreFilter.Length - 1);
                 return "rd.UnitID in (" + UnitFilter + ") And "
                   + "rd.ManufacturerID in (" + ManufacturerFilter + ") And "
                   + "ActivityID in (" + ActivityFilter + ") And "
                   + "PhyicalStoreID in (select ID from PhysicalStore where PhysicalStoreTypeID in  (" + PhysicalStoreFilter + "))"; ;
             }
             else
                 return "";
               
        }

        //When A check box is clicked: Load Report

        private void checkBox_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            LoadReport();
            LoadGRNFReport();
        }
        //When a Tree list is clicked: Load Report
        private void treeList_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            LoadReport();
            LoadGRNFReport();
        }

        #endregion

        #region Report

        private void LoadReport()
        {
            string Filter = GetFilterString();
            if (Filter == "")
                gridItemDetail.DataSource = null;
            else
            gridItemDetail.DataSource = Item.GetItemsDetailByFilter(Filter);
            // do the column formatting here
            for (int i =0; i < gridItemDetailView.Columns.Count;i++)
            {
                var col = gridItemDetailView.Columns[i];
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                col.DisplayFormat.FormatString = "#,##0.##";
                
            }
        }

        private void LoadGRNFReport()
        {
            string Filter = GetFilterString();
            if (Filter == "")
                gridGrnf.DataSource = null;
            else
                gridGrnf.DataSource = Item.GetGRNFDetailByFilter(Filter);
            // do the column formatting here
            for (int i = 0; i < gridItemDetailView.Columns.Count; i++)
            {
                var col = gridItemDetailView.Columns[i];
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                col.DisplayFormat.FormatString = "#,##0.##";
            }
        }
        #endregion

        private void lkCommodityType_EditValueChanged(object sender, EventArgs e)
        {
            if (lkCommodityType.EditValue != null)
            {
                Item itemList = new Item();
                grdItemList.DataSource = Item.GetDistinctActiveItemsByCommodityType(Convert.ToInt32(lkCommodityType.EditValue), CurrentContext.UserId);
            }
        }

        private void btnRefreshBinCard_Click(object sender, EventArgs e)
        {
            if (dxBinCardValidation.Validate())
            {
                // Do bind the bin card
                //int WarehouseID = lkBinCardWarehouse.
                 var dataRow = (DataRowView)lkBinArchivePeriod.GetSelectedDataRow();
                BinCardReport report;
                if (ckBinCardArchive.Checked && dataRow != null)
                 {


                     // Do bind the bin card
                     //int WarehouseID = lkBinCardWarehouse.
                      report =
                         ReportingReportFactory.CreateBinCard(Convert.ToInt32(lkBinCardActivity.EditValue), ItemID,
                                                              Convert.ToInt32(lkBinCardUnit.EditValue),
                                                              Convert.ToInt32(lkBinCardWarehouse.EditValue),
                                                              Convert.ToDateTime(dataRow["StartDate"]),
                                                              Convert.ToDateTime(dataRow["EndDate"]));

                 }
                 else
                 {
                     report = ReportingReportFactory.CreateBinCard(Convert.ToInt32(lkBinCardActivity.EditValue), ItemID,
                                                                                                Convert.ToInt32(lkBinCardUnit.EditValue),
                                                                                                Convert.ToInt32(lkBinCardWarehouse.EditValue));
           
                 }
                    printBinCard.PrintingSystem = report.PrintingSystem;

                report.PrintingSystem.ExecCommand(DevExpress.XtraPrinting.PrintingSystemCommand.ZoomToPageWidth, null);
                binCardReport = report;
                // Generate the report's print document. 
                report.CreateDocument(); 
            }
        }

        private void btnRefreshStockCard_Click(object sender, EventArgs e)
        {
            if (dxStockCardValiation.Validate())
            {
                // Bind the stock card.
                 var dataRow = (DataRowView)lkStockArchivePeriod.GetSelectedDataRow();
                StockCardReport report;
                if (chkStockCardArchive.Checked && dataRow != null)
                {
                      report = ReportingReportFactory.CreateStockCard(Convert.ToInt32(lkStockCardActivity.EditValue), ItemID,
                                                                           Convert.ToInt32(lkStockCardUnit.EditValue),
                                                                           Convert.ToInt32(lkStockCardWarehouse.EditValue),
                                                                           Convert.ToInt32(lkStockCardManufacturer.EditValue),
                                                                           Convert.ToDateTime(dataRow["StartDate"]),
                                                                           Convert.ToDateTime(dataRow["EndDate"]));
              
               
                }
                else
                {
                    report = ReportingReportFactory.CreateStockCard(Convert.ToInt32(lkStockCardActivity.EditValue), ItemID,
                                                                           Convert.ToInt32(lkStockCardUnit.EditValue),
                                                                           Convert.ToInt32(lkStockCardWarehouse.EditValue), Convert.ToInt32(lkStockCardManufacturer.EditValue));
              
                }
                 stockCardReport = report;
                printStockCard.PrintingSystem = report.PrintingSystem;
                report.PrintingSystem.ExecCommand(DevExpress.XtraPrinting.PrintingSystemCommand.ZoomToPageWidth, null);
                // Generate the report's print document. 
                report.CreateDocument(); 
            }
        }

        private void lkBinCardUnit_EditValueChanged(object sender, EventArgs e)
        {
            if (lkBinCardUnit.EditValue != null)
            {
                lkBinCardActivity.Properties.DataSource = Activity.GetActivitiesForItem(ItemID,
                                                                                  Convert.ToInt32(
                                                                                      lkBinCardUnit.EditValue),
                                                                                  CurrentContext.UserId);
                lkBinCardActivity.Enabled = true;

            }else
            {
                lkBinCardWarehouse.EditValue = null;
                lkBinCardActivity.Enabled = false;
                lkBinCardWarehouse.Enabled = false;
                btnRefreshBinCard.Enabled = false;
                printBinCard.PrintingSystem = null;
                printBinCard.Refresh();
            }
            
        }

        private void lkBinCardActivity_EditValueChanged(object sender, EventArgs e)
        {
            if (lkBinCardActivity.EditValue != null)
            {
                //Bind the warehouse now
                lkBinCardWarehouse.EditValue = null;
                var dv = PhysicalStore.GetWarehousesFor(ItemID,
                                                                                         Convert.ToInt32(
                                                                                             lkBinCardUnit.EditValue),
                                                                                         Convert.ToInt32(
                                                                                             lkBinCardActivity.EditValue),CurrentContext.UserId);
                lkBinCardWarehouse.Properties.DataSource = dv;

                // bind the default value
                if (dv.Count == 1)
                {
                    lkBinCardWarehouse.ItemIndex = 0;
                }

                lkBinCardWarehouse.Enabled = true;
                btnRefreshBinCard.Enabled = true;
            }else
            {
                lkBinCardWarehouse.Enabled = false;
                btnRefreshBinCard.Enabled = false;
            }
        }

        private void btnBinCardPrint_Click(object sender, EventArgs e)
        {

            if (printBinCard.PrintingSystem != null)
            {
                if (ModifierKeys == Keys.Control)
                {
                    ExportBinCardReport();
                }
                else
                {
                    binCardReport.PrintDialog();
                }
                
            }
        }

        private void ExportBinCardReport()
        {
            var saveFileTo = new SaveFileDialog();
            if (saveFileTo.ShowDialog() != DialogResult.Cancel)
            {
                binCardReport.ExportToXlsx(saveFileTo.FileName + ".xlsx");
                XtraMessageBox.Show("Finished Exporting!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lkStockCardUnit_EditValueChanged(object sender, EventArgs e)
        {
            if (lkStockCardUnit.EditValue != null)
            {
                lkStockCardActivity.Properties.DataSource = Activity.GetActivitiesForItem(ItemID,
                                                                                  Convert.ToInt32(
                                                                                      lkStockCardUnit.EditValue),
                                                                                  CurrentContext.UserId);
                lkStockCardActivity.Enabled = true;
            }
            else
            {
                lkStockCardWarehouse.EditValue = null;
                lkStockCardActivity.Enabled = false;
                lkStockCardWarehouse.Enabled = false;
                btnRefreshStockCard.Enabled = false;
                printStockCard.PrintingSystem = null;
                printStockCard.Refresh();
            }
        }

        private void lkStockCardActivity_EditValueChanged(object sender, EventArgs e)
        {
            if (lkStockCardActivity.EditValue != null)
            {
                //Stockd the warehouse now
                lkStockCardWarehouse.EditValue = null;
                var dv = PhysicalStore.GetWarehousesFor(ItemID,
                                                                                         Convert.ToInt32(
                                                                                             lkStockCardUnit.EditValue),
                                                                                         Convert.ToInt32(
                                                                                             lkStockCardActivity.EditValue), CurrentContext.UserId);
                lkStockCardWarehouse.Properties.DataSource = dv;
                if (dv.Count == 1)
                {
                    // Select the default warehouse.
                    lkStockCardWarehouse.ItemIndex = 0;
                }


                lkStockCardWarehouse.Enabled = true;
                btnRefreshStockCard.Enabled = true;
            }
            else
            {
                lkStockCardWarehouse.Enabled = false;
                btnRefreshStockCard.Enabled = false;
            }
        }

        private void btnStockCardPrint_Click(object sender, EventArgs e)
        {
            if (printStockCard.PrintingSystem != null)
            {
                if (ModifierKeys == Keys.Control)
                {
                    ExportStockCardReport();
                }
                else
                {
                    stockCardReport.PrintDialog();
                }
               
            }
        }

        private void ExportStockCardReport()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            if (saveFile.ShowDialog() != DialogResult.Cancel)
            {
                stockCardReport.ExportToXlsx(saveFile.FileName + ".xlsx");
                XtraMessageBox.Show("Finished Exporting!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void lkBinCardWarehouse_EditValueChanged(object sender, EventArgs e)
       {

           if (lkBinCardWarehouse.EditValue != null)
           {
                   int warehouse = Convert.ToInt32(lkBinCardWarehouse.EditValue);
                   lkBinArchivePeriod.Properties.DataSource = InventoryPeriod.GetInventoryPeriodDatesByWareHouse(warehouse);
               
           }
       }

       private void ckBinCardArchive_CheckedChanged(object sender, EventArgs e)
       {
           layoutBinCardPeriod.Visibility = ckBinCardArchive.Checked ? LayoutVisibility.Always : LayoutVisibility.Never;
       }

       private void chkStockCardArchive_CheckedChanged(object sender, EventArgs e)
       {
           layoutStockCardPeriod.Visibility = chkStockCardArchive.Checked ? LayoutVisibility.Always : LayoutVisibility.Never;

       }

       private void lkStockCardWarehouse_EditValueChanged(object sender, EventArgs e)
       {
           if (lkStockCardWarehouse.EditValue != null)
           {
               int warehouse = Convert.ToInt32(lkStockCardWarehouse.EditValue);
               lkStockArchivePeriod.Properties.DataSource = InventoryPeriod.GetInventoryPeriodDatesByWareHouse(warehouse);

           }
       }

       private void btnExport_Click(object sender, EventArgs e)
       {
           ExportBinCardReport();
       }

       private void btnExportStockCard_Click(object sender, EventArgs e)
       {
           ExportStockCardReport();
       }
    }

}