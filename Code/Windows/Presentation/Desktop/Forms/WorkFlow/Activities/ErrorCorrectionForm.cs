using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using BLL.Services;
using DevExpress.XtraEditors;
using BLL;
using DevExpress.XtraReports.UI;
using HCMIS.Desktop.Helpers;
using HCMIS.Desktop.Reports;
using HCMIS.Helpers;
using DevExpress.XtraGrid.Columns;
using MyGeneration.dOOdads;

//using HCMIS.Reports.Views;

namespace HCMIS.Desktop.WorkFlow.Activities
{

    [FormIdentifier("AC-EC-EC-FR", "Error Correction Form", "")]
    public partial class ErrorCorrectionForm : DevExpress.XtraEditors.XtraForm
    {


        #region Filter settings

        // Settings For the Filter Option where User select A Commodity 
        private bool ShowOnlyReceivedItemUnit = true;
        private bool ShowOnlyReceivedManufacturer = true;
        private bool ShowOnlyReceivedActivity = true;
        private bool ShowOnlyReceivedPhysicalStore = true;

        #endregion

        #region Loading And ItemSelection

        // Loading of the Form and the left Side Menu where the User 
        // Select the commodities
        // Once Selected the Filter Get Populated
        private int ItemID;
        private int ItemIDTo;
        private DataTable _allItemsToBeCorrected;

        public ErrorCorrectionForm()
        {
            InitializeComponent();
        }

        private void GeneralItemReport_Load(object sender, EventArgs e)
        {
            _allItemsToBeCorrected = new DataTable();
            LoadLeftSideList();
            SetPermissions();
        }

        private void SetPermissions()
        {
            if (BLL.Settings.UseNewUserManagement)
            {
                btnChangeTo.Enabled = this.HasPermission("Can-Correct-Errors");
            }
        }

        private void LoadLeftSideList()
        {
            var commodityTypes = BLL.CommodityType.GetAllTypes();
            lkCommodityType.Properties.DataSource = commodityTypes;
            lkCommodityTypeTo.Properties.DataSource = commodityTypes;
            layoutWarehouse.ContentVisible = lkWarehouse.Visible = false;
        }

        private void grdItemListView_FocusedRowChanged(object sender,
                                                       DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            DataRow selectedItem = grdItemListView.GetFocusedDataRow();

            if (selectedItem != null)
            {
                ItemID = Convert.ToInt32(selectedItem["ID"]);
                string itemName = selectedItem["FullItemName"].ToString();
                ClearSelection();
                grdItemListViewTo.Columns["FullItemName"].FilterInfo =
                    new ColumnFilterInfo("[FullItemName] LIKE '" + itemName + "%'");
                grdItemListViewTo_FocusedRowChanged(null, null);
                LoadUnitsForSelectedItem();
                LoadManufacturerForSelectedItem();
                LoadAccountForSelectedItem();

            }
        }

        private void ClearSelection()
        {
            lkActivity.EditValue = null;
            lkUnit.EditValue = null;
            lkManufacturer.EditValue = null;
            gridItemDetail.DataSource = null;
            btnChangeTo.Enabled = false;
            lkWarehouse.Properties.DataSource = null;
            layoutWarehouse.ContentVisible = false;
            lkWarehouse.Visible = false;

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
            lkUnit.Properties.DataSource = itemUnit.DefaultView;
        }

        private void LoadManufacturerForSelectedItem()
        {
            BLL.ItemManufacturer itemManufacturer = new BLL.ItemManufacturer();
            if (ShowOnlyReceivedManufacturer)
                itemManufacturer.LoadManufactuererByItemWithReceive(ItemID);
            lkManufacturer.Properties.DataSource = itemManufacturer.DefaultView;
        }

        private void LoadAccountForSelectedItem()
        {
            if (lkUnit.EditValue != null)
            {
                DataView dtActivity = Activity.GetActivitiesForItem(ItemID, Convert.ToInt32(lkUnit.EditValue),
                                                                    CurrentContext.UserId);
                lkActivity.Properties.DataSource = dtActivity;
            }
        }


        #endregion

        #region Report

        private void LoadDetail()
        {
            try
            {
                int ManufacturerID = Convert.ToInt32(lkManufacturer.EditValue);
                int UnitID = Convert.ToInt32(lkUnit.EditValue);
                int ActivityID = Convert.ToInt32(lkActivity.EditValue);
                DataTable data = Item.GetItemDetailForItemChanger(ItemID, ManufacturerID, UnitID, ActivityID);
                _allItemsToBeCorrected = data;
                gridItemDetail.DataSource = data;
                if (data != null && data.Rows.Count != 0)
                {
                    btnChangeTo.Enabled = (BLL.Settings.UseNewUserManagement)
                                              ? this.HasPermission("Apply-Change")
                                              : false;
                    LoadWareouses();
                }
                btnChangeTo.Enabled = true;
            }
            catch
            {
            }
        }

        private string GetFilterString()
        {
            return "";
        }

        #endregion

        private void lkCommodityType_EditValueChanged(object sender, EventArgs e)
        {
            if (lkCommodityType.EditValue != null)
            {
                Item itemList = new Item();
                grdItemList.DataSource =
                    Item.GetDistinctActiveItemsByCommodityType(Convert.ToInt32(lkCommodityType.EditValue),
                                                               CurrentContext.UserId);
                lkCommodityTypeTo.EditValue = lkCommodityType.EditValue;
            }
        }


        public int ActivityID { get; set; }

        private void grdItemListViewTo_FocusedRowChanged(object sender,
                                                         DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow selectedItem = grdItemListViewTo.GetFocusedDataRow();

            if (selectedItem != null)
            {
                ItemIDTo = Convert.ToInt32(selectedItem["ID"]);
                ClearSelectionForChange();
                LoadUnitsForChange();
                LoadManufacturerForChange();
            }
        }

        private void ClearSelectionForChange()
        {
            lkManufacturerTo.EditValue = null;
            lkUnitTo.EditValue = null;
            layoutWarehouse.ContentVisible = false;
            lkWarehouse.Visible = false;
        }

        private void LoadManufacturerForChange()
        {
            BLL.ItemManufacturer itemManufacturer = new BLL.ItemManufacturer();
            itemManufacturer.LoadAllManufacturersByItem(ItemIDTo);
            lkManufacturerTo.Properties.DataSource = itemManufacturer.DefaultView;
        }

        private void LoadUnitsForChange()
        {
            ItemUnit itemUnit = new ItemUnit();
            itemUnit.LoadAllForItem(ItemIDTo);
            lkUnitTo.Properties.DataSource = itemUnit.DefaultView;

        }

        private void lkCommodityTypeTo_EditValueChanged(object sender, EventArgs e)
        {
            if (lkCommodityTypeTo.EditValue != null)
            {
                grdItemListTo.DataSource =
                    Item.GetDistinctActiveItemsByCommodityType(Convert.ToInt32(lkCommodityType.EditValue),
                                                               CurrentContext.UserId, false);
            }
        }

        private void LoadWareouses()
        {
            layoutWarehouse.ContentVisible = true;
            lkWarehouse.Visible = true;
            var listOfWarehouse = new List<BLL.Warehouse>();
            var listofWsData = new DataTable();
            foreach (DataRow row in _allItemsToBeCorrected.Rows)
            {
                if (!listOfWarehouse.Exists(w => w.ID == Convert.ToInt32(row["WearehouseID"])))
                {
                    var newWarehouse = new BLL.Warehouse();
                    newWarehouse.LoadByPrimaryKey(Convert.ToInt32(row["WearehouseID"]));
                    listOfWarehouse.Add(newWarehouse);
                }
            }
            if (listOfWarehouse.Count > 1)
            {
                listofWsData = ToDataTable(listOfWarehouse);
                listofWsData.Rows.Add(-1, "All");
                lkWarehouse.EditValue = -1; //select All
            }
            if (listofWsData.Rows.Count == 0) listofWsData = ToDataTable(listOfWarehouse);
            lkWarehouse.Properties.DataSource = listofWsData;
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            LoadDetail();
        }

        private void lkUnit_EditValueChanged(object sender, EventArgs e)
        {
            if (ItemID == ItemIDTo)
            {
                lkUnitTo.EditValue = lkUnit.EditValue;
                LoadAccountForSelectedItem();
            }
        }

        private void lkManufacturer_EditValueChanged(object sender, EventArgs e)
        {
            if (ItemID == ItemIDTo)
            {
                lkManufacturerTo.EditValue = lkManufacturer.EditValue;
            }
        }

        private void btnChangeTo_Click(object sender, EventArgs e)
        {
           
            // Do validation
            if (dxErrorCorrectionValidator.Validate() && IsItemDetailValid())
            {
                if (
                  XtraMessageBox.Show("Are you sure you want to commit this change? You will not be able to undo this.",
                                      "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }

                var unitIdTo = Convert.ToInt32(lkUnitTo.EditValue);
                var manufacturerIdTo = Convert.ToInt32(lkManufacturerTo.EditValue);
                var conversionFactor = Convert.ToDecimal(txtFactor.EditValue);
                var changeExpiryDate = ckExpiryDate.Checked;
                var changeBatchNo = ckBatchNo.Checked;
                var batchNo = txtBatchNo.Text;
                var expiryDate = (DateTime?) dtExpiryDate.EditValue;
                DateTime dtCurrent;

                using (var dtDate = ConvertDate.GetCurrentEthiopianDateText())
                {
                    dtCurrent = ConvertDate.DateConverter(dtDate.Text);
                }
                TransactionMgr transactionMgr = TransactionMgr.ThreadTransactionMgr();

                int userId = CurrentContext.UserId;
                TransferService transferService = new TransferService();

                if (conversionFactor == 0 &&
                    XtraMessageBox.Show(
                        "This change is a factor of Zero make the Quantity Zero,Are you sure you want to commit this change? You will not be able to undo this.",
                        "Confirmation", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }

                try
                {
                    transactionMgr.BeginTransaction();
                    var dataView = (DataView) gridItemDetailView.DataSource;
                    int IDPRinted = transferService.CreateTransactionForErrorCorrection(dataView, ItemIDTo, unitIdTo,
                                                                                        manufacturerIdTo,
                                                                                        conversionFactor,
                                                                                        "Error Correction",
                                                                                        dtCurrent, userId,
                                                                                        changeExpiryDate, expiryDate,
                                                                                        changeBatchNo, batchNo);

                    transactionMgr.CommitTransaction();

                    var xtraReport = ReturnErrorCorrectionReport(unitIdTo, manufacturerIdTo, dataView, conversionFactor,
                                                                 IDPRinted, changeExpiryDate, expiryDate, changeBatchNo,
                                                                 batchNo);
                    xtraReport.PrintDialog();

                    XtraMessageBox.Show("Your changes have been applied, thanks.", "Confirmation");
                    // refresh
                    btnDisplay_Click(null, null);
                    lkWarehouse_EditValueChanged(null, null);
                    layoutWarehouse.ContentVisible = false;
                    lkWarehouse.Visible = false;
                }
                catch (Exception exp)
                {
                    XtraMessageBox.Show("There was an error applying your changes", "Error");
                    transactionMgr.RollbackTransaction();
                    XtraMessageBox.Show(exp.Message.ToString());
                }
                finally
                {
                    TransactionMgr.ThreadTransactionMgrReset();
                }

            }
            else
            {
                XtraMessageBox.Show("Please correct the errors marked in red", "Error");
            }
        }

        private XtraReport ReturnErrorCorrectionReport(int unitIdTo, int manufacturerIdTo, DataView dataView,
                                                       decimal conversionFactor, int IDPRinted,
                                                       bool changeExpiryDate = false, DateTime? expiryDate = null,
                                                       bool changeBatchNo = false, string batchNo = null)
        {
            Item item = new Item();
            item.LoadByPrimaryKey(ItemIDTo);
            ItemUnit itemUnit = new ItemUnit();
            itemUnit.LoadByPrimaryKey(unitIdTo);
            Manufacturer manufacturer = new Manufacturer();
            manufacturer.LoadByPrimaryKey(manufacturerIdTo);

            Item itemFrom = new Item();
            itemFrom.LoadByPrimaryKey(ItemID);
            ItemUnit ItemUnitFrom = new ItemUnit();
            ItemUnitFrom.LoadByPrimaryKey(Convert.ToInt32(lkUnit.EditValue));
            Manufacturer manufacturerFrom = new Manufacturer();
            manufacturerFrom.LoadByPrimaryKey(Convert.ToInt32(lkManufacturer.EditValue));
            dataView.RowFilter = "pickedQty > 0";
            foreach (DataRowView dataRowView in dataView)
            {
                decimal pack = Convert.ToDecimal(dataRowView["PickedQty"]);
                dataRowView["ChangedQty"] = Convert.ToDecimal(pack*Convert.ToDecimal(conversionFactor));

            }
            XtraReport xtraReport = new ErrorCorrection(IDPRinted, item.StockCode, item.FullItemName, itemUnit.Text,
                                                        manufacturer.Name, item.StockCode,
                                                        itemFrom.FullItemName, ItemUnitFrom.Text, manufacturerFrom.Name,
                                                        changeExpiryDate, expiryDate, changeBatchNo, batchNo);
            xtraReport.DataSource = dataView;
            return xtraReport;
        }

        private void ckBatchNo_CheckedChanged(object sender, EventArgs e)
        {
            txtBatchNo.Enabled = ckBatchNo.Checked;

        }

        private void ckExpiryDate_CheckedChanged(object sender, EventArgs e)
        {
            dtExpiryDate.Enabled = ckExpiryDate.Checked;
        }

        private void lkWarehouse_EditValueChanged(object sender, EventArgs e)
        {
            if ((int) lkWarehouse.EditValue == -1)
            {
                gridItemDetail.DataSource = _allItemsToBeCorrected;
                return;
            }
            var currentDataview = new DataView(_allItemsToBeCorrected);
            currentDataview.RowFilter = String.Format("WearehouseID = {0}", lkWarehouse.EditValue);
            gridItemDetail.DataSource = currentDataview.ToTable();
        }

        public static DataTable ToDataTable<T>(List<T> iList)
        {
            DataTable dataTable = new DataTable();
            PropertyDescriptorCollection propertyDescriptorCollection =
                TypeDescriptor.GetProperties(typeof (T));
            for (int i = 0; i < propertyDescriptorCollection.Count; i++)
            {
                PropertyDescriptor propertyDescriptor = propertyDescriptorCollection[i];
                Type type = propertyDescriptor.PropertyType;

                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof (Nullable<>))
                    type = Nullable.GetUnderlyingType(type);


                dataTable.Columns.Add(propertyDescriptor.Name, type);
            }
            object[] values = new object[propertyDescriptorCollection.Count];
            foreach (T iListItem in iList)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = propertyDescriptorCollection[i].GetValue(iListItem);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }

        private void gridItemDetailView_CellValueChanged(object sender,
                                                         DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRow dr = gridItemDetailView.GetDataRow(gridItemDetailView.GetSelectedRows()[0]);
            dr.ClearErrors();
            if (Convert.ToDecimal(dr["PickedQty"]) > Convert.ToDecimal(dr["CurrentQty"]))
                dr.SetColumnError("PickedQty", string.Format("Picked Quantity can not be greater than Current Quantity"));
        }

        private bool IsItemDetailValid()
        {
            for (int i = 0; i < gridItemDetailView.RowCount; i++)
            {
                DataRow dr = gridItemDetailView.GetDataRow(i);
                if (Convert.ToDecimal(dr["PickedQty"]) > Convert.ToDecimal(dr["CurrentQty"]))
                {
                    dr.SetColumnError("PickedQty",
                                         string.Format("Picked Quantity can not be greater than Current Quantity"));
                    return false;
                }
            }
            return true;
        }
    }
}