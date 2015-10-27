using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;


namespace HCMIS.Desktop.Forms.Modals
{
    public partial class PurchaseOrderDetailForm : XtraForm
    {
        private int _poid = 0;
        private int _storeID = 0;
        private DataTable _dtselectedItemsTable = new DataTable();
        private DataTable _dtselectedTable = null;
        PurchaseOrderDetail _poDetail = new PurchaseOrderDetail();
        private bool _valid = true;
        private PO _po;

        public PurchaseOrderDetailForm(int poid, int storeID)
        {
            _poid = poid;
            _po = new PO(_poid);

            _storeID = storeID;
            InitializeComponent();
        }

        private void PurchaseOrderDetailForm_Load(object sender, EventArgs e)
        {
            var datasource = new DataTable();
            BindCategoryAndManufacturerLookup();
            var isDirectVendor = _po.PurchaseType == POType.DIRECT_VENDOR_TRANSFER;
            datasource = (isDirectVendor && !BLL.Settings.IsCenter)? BLL.Item.GetActiveItemsBySupplier(_po.SupplierID, _storeID): BLL.Item.GetActiveItemsByCommodityType(0, _storeID); //0 means all items
            ConstructTableColumns();
            EditPurchaseOrderDetail(datasource);
            //gridSelectedItemsView.ValidateRow += GridSelectedItemsViewOnValidateRow;
            if (!BLL.Settings.IsCenter)
            {
                colAmount.OptionsColumn.AllowEdit =colAmount.OptionsColumn.AllowFocus = false;
                colAmount.AppearanceCell.BackColor = Color.WhiteSmoke;
            }
        }

        private void GridSelectedItemsViewOnValidateRow(object sender, ValidateRowEventArgs e)
        {
            var view = sender as GridView;
            view.ClearColumnErrors();

            var manufacturerID = view.GetRowCellDisplayText(e.RowHandle, colManufacturer);
            var quantity = view.GetRowCellDisplayText(e.RowHandle, colQuantity);
            var amount = view.GetRowCellDisplayText(e.RowHandle, colAmount);

            if (string.IsNullOrEmpty(manufacturerID) || manufacturerID.Equals("Select Manufacturer"))
            {
                e.Valid = false;
                view.SetColumnError(colManufacturer, @"Manufacturer is empty");
            }

            if (string.IsNullOrEmpty(quantity))
            {
                e.Valid = false;
                view.SetColumnError(colQuantity, @"Quantity is empty");
            }
            else if (Convert.ToDecimal(quantity) < 0)
            {
                e.Valid = false;
                view.SetColumnError(colQuantity, @"Quantity is negative");
            }

            if (string.IsNullOrEmpty(amount))
            {
                e.Valid = false;
                view.SetColumnError(colAmount, @"Amount is empty");
            }
            else if (Convert.ToDecimal(amount) < 0)
            {
                e.Valid = false;
                view.SetColumnError(colAmount, @"Amount is negative");
            }

        }

        private void BindCategoryAndManufacturerLookup()
        {
            lkCategories.Properties.DataSource = BLL.CommodityType.GetAllTypes().Select("Name <> 'Medical Supplies DUPLICATE DO NOT USE'").CopyToDataTable();
            var manufacturer = new Manufacturer();
            manufacturer.LoadAll();
            lookUpManufacturer.DataSource = manufacturer.DefaultView;
        }

        private void EditPurchaseOrderDetail(DataTable datasource)
        {

            var pdetail = new PurchaseOrderDetail();
            pdetail.LoadByPo(_poid);
            var iunit = new ItemUnitBase();
            if (_dtselectedItemsTable != null)
            {
                _dtselectedItemsTable.Clear();
            }

            pdetail.Rewind();
            while (!pdetail.EOF)
            {
                if (datasource != null)
                {

                    iunit.LoadUnit(pdetail.UnitOfIssueID, pdetail.ItemID);
                    DataRow[] dataRows = datasource.Select(String.Format("ItemID = {0} and UnitID = {1}", pdetail.ItemID, iunit.ID));
                    if (dataRows.Length > 0)
                    {
                        // _dtselectedItemsTable.ImportRow(dataRows[0]);
                        var selectedRow = _dtselectedItemsTable.NewRow();
                        selectedRow["FullItemName"] = dataRows[0]["FullItemName"];
                        selectedRow["StockCode"] = dataRows[0]["StockCode"];
                        selectedRow["Unit"] = dataRows[0]["Unit"];
                        selectedRow["UnitID"] = iunit.ID;
                        selectedRow["ItemID"] = pdetail.ItemID;
                        selectedRow["Quantity"] = pdetail.Quantity;
                        selectedRow["Amount"] = pdetail.Amount;
                        selectedRow["PreferredManufacturerID"] = pdetail.PreferredManufacturerID;
                        selectedRow["PurchaseOrderDetailID"] = pdetail.PurchaseOrderDetailID;
                        //Check all
                        dataRows[0]["IsSelected"] = true;

                        _dtselectedItemsTable.Rows.Add(selectedRow);
                    }
                }
                pdetail.MoveNext();
            }

            gridItemsList.DataSource = datasource.DefaultView;
            gridSelectedItems.DataSource = _dtselectedItemsTable.DefaultView;
        }

        private void ConstructTableColumns()
        {
            _dtselectedItemsTable.Columns.Add("FullItemName");
            _dtselectedItemsTable.Columns.Add("StockCode");
            _dtselectedItemsTable.Columns.Add("Unit");
            _dtselectedItemsTable.Columns.Add("ItemID", typeof(int));
            _dtselectedItemsTable.Columns.Add("UnitID", typeof(int));
            _dtselectedItemsTable.Columns.Add("Quantity", typeof(decimal));
            _dtselectedItemsTable.Columns.Add("Amount", typeof(decimal));
            _dtselectedItemsTable.Columns.Add("PreferredManufacturerID", typeof(int));
            _dtselectedItemsTable.Columns.Add("PurchaseOrderDetailID", typeof(int));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SavePoDetail();
        }

        public void SavePoDetail()
        {
            if (!ValidateOrderDetails())
            {
                return;
            }

            var itemData = (DataView)gridSelectedItemsView.DataSource;
            foreach (DataRowView row in itemData)
            {
                if (row["PurchaseOrderDetailID"] == DBNull.Value)
                {
                    _poDetail.AddNew();
                }
                else
                {
                    _poDetail.LoadByPrimaryKey(Convert.ToInt32(row["PurchaseOrderDetailID"]));
                }
                var itemUnit = new ItemUnitBase();
                var unitID = Convert.ToInt32(row["UnitID"]);
                itemUnit.LoadByPrimaryKey(unitID);

                _poDetail.PurchaseOrderID = _poid;
                _poDetail.ItemID = Convert.ToInt32(row["ItemID"]);
                _poDetail.Quantity = Convert.ToDecimal(row["Quantity"]);
                _poDetail.Remark = string.Empty;
                _poDetail.UnitOfIssueID = itemUnit.UnitOfIssueID;
                _poDetail.Rowguid = Guid.NewGuid();
                _poDetail.ApprovedQuantity = 0;
                _poDetail.Amount = Convert.ToDecimal(row["Amount"]);
                if (row["PreferredManufacturerID"] != DBNull.Value)
                {
                    _poDetail.PreferredManufacturerID = Convert.ToInt32(row["PreferredManufacturerID"]);
                }
                _poDetail.Save();
            }
            MessageBox.Show("Order detail saved!", "Confirmation", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
            Close();
        }

        private bool ValidateOrderDetails()
        {
            bool valid = true;

            var itemData = ((DataView)gridSelectedItemsView.DataSource).ToTable();
            if (itemData == null || itemData.Rows.Count == 0)
            {
                XtraMessageBox.Show("Empty details! Please select items first.", "Empty Details", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            gridSelectedItemsView.ClearColumnErrors();

            foreach (DataRow itm in itemData.Rows)
            {
                if (itm["Quantity"] == DBNull.Value)
                {
                    gridSelectedItemsView.SetColumnError(colQuantity, @"Quantity is empty");
                    valid = false;
                }
                if (itm["Amount"] == DBNull.Value)
                {
                    gridSelectedItemsView.SetColumnError(colAmount, @"Amount is empty");
                    valid = false;
                }
                if (itm["Quantity"] == DBNull.Value || itm["Amount"] == DBNull.Value) continue;

                if (Convert.ToDecimal(itm["Quantity"]) < 0)
                {
                    gridSelectedItemsView.SetColumnError(colQuantity, @"Quantity is negative");
                    valid = false;
                }
                if (Convert.ToDecimal(itm["Amount"]) < 0)
                {
                    gridSelectedItemsView.SetColumnError(colAmount, @"Amount is negative");
                    valid = false;
                }
            }

            return valid;
        }

        private void lkCategories_EditValueChanged(object sender, EventArgs e)
        {
            LoadFilteredItems();
        }

        public void LoadFilteredItems()
        {
            if (lkCategories.EditValue == null || lkCategories.EditValue == "")
            {
                gridItemsList.DataSource = null;
                return;
            }
            var category = Convert.ToInt32(lkCategories.EditValue);
            // Get all items by category
            DataTable filteredItems = BLL.Item.GetActiveItemsByCommodityType(category, _storeID);
            gridItemsList.DataSource = filteredItems;
        }

        private void gridItemsList_Click(object sender, EventArgs e)
        {

            var datarow = gridItemsView.GetFocusedDataRow();
            if (datarow == null)
                return;

            SendSelectedItem(datarow);

        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            gridItemsView.ActiveFilterString = string.Format("[FullItemName] Like '{0}%' or StockCode like '%{0}%'", txtItemName.Text);
        }

        public void SendSelectedItem(DataRow dr)
        {
            bool b = (dr["IsSelected"] == DBNull.Value) || !Convert.ToBoolean(dr["IsSelected"]);

            dr["IsSelected"] = b;
            if (b)
            {
                AddItem(dr);
            }
            else
            {
                RemoveItem(dr);
            }
        }

        private void RemoveItem(DataRow dr)
        {
            var rows = dr.Table.Columns.Contains("ID") ? _dtselectedItemsTable.Select(String.Format("ItemID = {0} and UnitID = {1}", dr["ID"], dr["UnitID"])) : new[] { dr };

            foreach (var rw in rows)
            {


                if (rw != null && rw["PurchaseOrderDetailID"] != DBNull.Value)
                {
                    if (XtraMessageBox.Show(@"Are you sure you want to delete the detail from the database?",
                        @"Confirmation", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        var purchaseorderdetail = new PurchaseOrderDetail();
                        purchaseorderdetail.LoadByPrimaryKey(Convert.ToInt32((rw["PurchaseOrderDetailID"])));
                        purchaseorderdetail.MarkAsDeleted();
                        purchaseorderdetail.Save();
                        _dtselectedItemsTable.Rows.Remove(rw);
                    }
                    continue;
                }
                _dtselectedItemsTable.Rows.Remove(rw);
            }
        }

        private void AddItem(DataRow dr)
        {

            var newrow = _dtselectedItemsTable.NewRow();
            newrow["FullItemName"] = dr["FullItemName"];
            newrow["StockCode"] = dr["StockCode"];
            newrow["Unit"] = dr["Unit"];
            newrow["UnitID"] = dr["UnitID"];
            newrow["ItemID"] = dr.Table.Columns.Contains("ItemID") ? dr["ItemID"] : dr["ID"];
            newrow["Amount"] = 0;
            _dtselectedItemsTable.Rows.Add(newrow);
        }

        private void gridSelectedItemsView_ShownEditor(object sender, EventArgs e)
        {
            var view = sender as GridView;

            if (view != null && view.FocusedColumn.FieldName == "PreferredManufacturerID")
            {
                var lke = (LookUpEdit)view.ActiveEditor;
                lke.EditValue = null;
                DataRow dr = gridSelectedItemsView.GetDataRow(gridSelectedItemsView.GetSelectedRows()[0]);
                int id = Convert.ToInt32(dr["ItemID"]);
                var mfs = new Manufacturer();
                mfs.LoadForItem(id);
                lke.Properties.DataSource = mfs.DefaultView;
            }
        }

        private void PlusMinusButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow dr = gridSelectedItemsView.GetFocusedDataRow();
            if (e.Button.Kind == ButtonPredefines.Plus)
            {
                AddItem(dr);
            }
            else
            {
                RemoveItem(dr);
            }
        }

        private void txtItemName_EditValueChanged(object sender, EventArgs e)
        {

        }


    }

}
