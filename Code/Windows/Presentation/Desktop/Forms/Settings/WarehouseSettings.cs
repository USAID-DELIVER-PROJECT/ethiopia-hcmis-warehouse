using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using HCMIS.Desktop.Helpers;
using HCMIS.Helpers;

namespace HCMIS.Desktop
{
    [FormIdentifier("PF-WS-CL-FR","Warehouse Settings","")]
    public partial class WarehouseSettings : XtraForm
    {
        private Shelf CurrentShelf = new Shelf();
        private PopupContainerEdit CurrentPopup = null;
        ShelfRowColumn CShelfRowCol = new ShelfRowColumn();
       
        PhysicalStore ps = new PhysicalStore();
        BLL.Warehouse psType = new BLL.Warehouse();
        Cluster cluster = new Cluster();

        public WarehouseSettings()
        {
            InitializeComponent();
        }

        private void WarehouseSettings_Load(object sender, EventArgs e)
        {
            SetPermission();
            elementHost1.PerformLayout();
            elementHost2.PerformLayout();
            elementHost3.PerformLayout();

            xtraTabControl1.PerformLayout();
            
            PopulateLookups();
            labelControl11.Text = labelControl12.Text = labelControl13.Text = Settings.LongMeasurmentUnit;
            
        }

        private void SetPermission()
        {
            if (BLL.Settings.UseNewUserManagement)
            {
                grdClusters.Enabled = btnSaveCluster.Enabled = btnAddCluster.Enabled = this.HasPermission("Add-Edit-Cluster");
                gridWarehouse.Enabled= btnSavePhysicalStoreType.Enabled = btnAddWarehouse.Enabled = this.HasPermission("Add-Edit-Warehouse");
                gridPhysicalStore.Enabled = btnSavePhysicalStore.Enabled = btnAddStore.Enabled = this.HasPermission("Add-Edit-Store");
                gridShelves.Enabled = btnAddShelf.Enabled = btnSaveShelf.Enabled = this.HasPermission("Add-Edit-Rack");

            }
        }

        private void PopulateLookups()
        {
            // cmbFilterStorageTypes.DataSource = StorageType.GetDataTableWithAll;


            BLL.Shelf shelf = new BLL.Shelf();
            shelf.LoadForMergedView();
            gridShelfDetails.DataSource = shelf.DefaultView;

            lkStorageTypes.Properties.DataSource = StorageType.AllStorageTypes;
            cmbStorageTypeFilter.Properties.DataSource = StorageType.AllStorageTypes;
            cmbStorageTypeFilter.EditValue = StorageType.BulkStore;

            ps.LoadAll();
            gridPhysicalStore.DataSource = ps.DefaultView;

            psType.LoadAll();
            gridWarehouse.DataSource = psType.DefaultView;
            lkPhysicalStoreType.DataSource = psType.DefaultView;

            lkWarehouse.Properties.DataSource = ps.DefaultView;
            lkEditWarehouse.DataSource = ps.DefaultView;

            cluster.LoadAll();
            grdClusters.DataSource = cluster.DefaultView;
            lkCluster.DataSource = cluster.DefaultView;

            gridShelves.DataSource = Shelf.AllShelves;
            gridShelvesView.ExpandAllGroups();
        }


        private void OnEditShelfClicked(object sender, EventArgs e)
        {

           // CurrentPopup = (PopupContainerEdit)sender;
            DataRowView drv = (DataRowView)gridShelvesView.GetFocusedRow();
            lkStorageTypes.Visible = false;
            //lblStorageType.Visible = false;
            groupControl2.Text = "Rack Details: Edit";
            // clear all data bindings
            numColumns.DataBindings.Clear();
            numRows.DataBindings.Clear();

            numColumns.DataBindings.Add("Value", drv, "Columns");
            numRows.DataBindings.Add("Value", drv, "Rows");

            CurrentShelf.LoadByPrimaryKey(int.Parse(drv["ID"].ToString()));
            lkStorageTypes.EditValue = CurrentShelf.ShelfStorageType;
            txtShelfLabel.Text = CurrentShelf.ShelfCode;
            numColumns.Value = CurrentShelf.Columns;
            numRows.Value = CurrentShelf.Rows;
            lkWarehouse.EditValue = CurrentShelf.StoreID;
            numHeight.Value = Convert.ToDecimal(CurrentShelf.Height);
            numLength.Value = Convert.ToDecimal(CurrentShelf.Length);
            numDepth.Value = Convert.ToDecimal(CurrentShelf.Width);
            groupControl2.Enabled = true;
        }

        private void SaveShelfChanges(object sender, EventArgs e)
        {
            // do the validation logic here.
            if (txtShelfLabel.Text == "")
            {
                XtraMessageBox.Show("You cannot leave the Shelf Name empty. Please correct that and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CurrentShelf.ShelfCode = txtShelfLabel.Text;

            if (CurrentShelf.IsColumnNull("ID"))
            {
                CurrentShelf.ShelfStorageType = Convert.ToInt32(lkStorageTypes.GetColumnValue("ID"));
                CurrentShelf.CoordinateX = 0;
                CurrentShelf.CoordinateY = 0;
                CurrentShelf.Rotation = 0;
                CurrentShelf.Width = 0;
                CurrentShelf.Height = 0;
                CurrentShelf.Length = 0;
                CurrentShelf.Columns = 0;
                CurrentShelf.Rows = 0;
                CurrentShelf.Save();

            }
            else
            {
                // save if there is a storage type change
                CurrentShelf.SaveShelfStorageType(Convert.ToInt32(lkStorageTypes.EditValue));
            }
            CurrentShelf.StoreID = Convert.ToInt32(lkWarehouse.EditValue);
            CurrentShelf.Save();
            //check if number of columns and rows has changed.
            CurrentShelf.SavePalletLocationsInShelf(Convert.ToInt32(numRows.Value), Convert.ToInt32(numColumns.Value));
            //check if the width and height has changed.
            CurrentShelf.SaveDimentions(Convert.ToDouble(numDepth.Value), Convert.ToDouble(numHeight.Value), Convert.ToDouble(numLength.Value));
            DataRowView drv = (DataRowView)gridShelvesView.GetFocusedRow();
            if (drv != null)
            {
                drv["ShelfCode"] = CurrentShelf.ShelfCode;
            }
            //TODO: Update the grid,

            XtraMessageBox.Show("Rack detail saved!","Confirmation",MessageBoxButtons.OK,MessageBoxIcon.Information);
            gridShelves.DataSource = Shelf.AllShelves;
            gridShelvesView.ExpandAllGroups();
            if(CurrentPopup != null)
                CurrentPopup.ClosePopup();
            else
            {
                ImplementClosePopup();
            }
            //.OwnerEdit.ClosePopup();
            
        }

        private void OnRowLabelEditPopup(object sender, EventArgs e)
        {
            CurrentPopup = (PopupContainerEdit)sender;

            DataRowView drv = (DataRowView)gridShelvesView.GetFocusedRow();
            
            CShelfRowCol.LoadRowsForShelf(Convert.ToInt32(drv["ID"]));
            gridShelfRows.DataSource = CShelfRowCol.DefaultView;
        }

        private void SaveRowChanges(object sender, EventArgs e)
        {
            //TODO: the validation trick here
            CShelfRowCol.Save();

            //TODO: Refresh the grid here
            ImplementClosePopup();
        }

        private void ImplementClosePopup()
        {
            try
            {
                CurrentPopup.ClosePopup();
            }
            catch
            {
                
            }
           
        }

        private void ClosePopup(object sender, EventArgs e)
        {
            ImplementClosePopup(); 
        }

        private void gridShelves_Click(object sender, EventArgs e)
        {

        }

        private void OnColumnEditPopup(object sender, EventArgs e)
        {
            CurrentPopup = (PopupContainerEdit)sender;

            DataRowView drv = (DataRowView)gridShelvesView.GetFocusedRow();

            CShelfRowCol.LoadColumnsForShelf(Convert.ToInt32(drv["ID"]));
            gridShelfColumn.DataSource = CShelfRowCol.DefaultView;
        }

        private void ShowAddNewShelf(object sender, EventArgs e)
        {
            CurrentShelf.AddNew();
            groupControl2.Text = @"Rack Details: Add New Rack";
            // Show the storage type combo box
            lkStorageTypes.Visible = true;
            groupControl2.Enabled = true;
        }


        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle != -1)
            {
                if (e.Column.Name == "PalletLocationColumn")
                {
                    DataRow dr = detailView.GetDataRow(e.RowHandle);

                    if (!Convert.ToBoolean(dr["IsEnabled"]))
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                }
            }
        }

        private void BindPalletLocationForEdit(object sender, EventArgs e)
        {
            // Keep the reference of the current popup control so that the cancel logic works just fine.
            CurrentPopup = (PopupContainerEdit)sender;
            //Get the selected row
            DataRow dr = detailView.GetFocusedDataRow();
            int palletLocationID = Convert.ToInt32(dr["PalletLocationID"]); 
            // Enable and disable optional fields
            String SType = dr["STI"].ToString();
            if (SType == "")
            {
                SType = dr["ShelfStorageType"].ToString();
            }
            cmbFixedPrefered.Enabled = true;

            if (SType == StorageType.BulkStore)
            {
                //lstPreferedItems.Visible = true;
                //lblPreferredItem.Visible = true;
                //cmbFixedPrefered.Enabled = false;
                lblFixedPickItem.Visible = false;
                cmbFixedPrefered.Visible = false;
            }
                
            else if (SType == StorageType.PickFace)
            {
                lblFixedPickItem.Text = "Pick Item";

                lstPreferedItems.Visible = false;
                lblPreferredItem.Visible = false;

                cmbFixedPrefered.Properties.DataSource = Item.GetItems(StorageType.BulkStore);
                PickFace pf = new PickFace();
                pf.LoadByPalletLocation(palletLocationID);
                if (pf.RowCount >0 && !pf.IsColumnNull("DesignatedItem"))
                {
                    cmbFixedPrefered.EditValue = pf.DesignatedItem;
                }
                else
                {
                    cmbFixedPrefered.EditValue = null;
                }
                lblFixedPickItem.Visible = true;
                cmbFixedPrefered.Visible = true;
            }
            else
            {

                cmbFixedPrefered.Properties.DataSource = Item.GetItems(dr["STI"].ToString());

                BLL.ItemPrefferedLocation ipl = new ItemPrefferedLocation();
                ipl.LoadByRackID( palletLocationID );
                if (ipl.RowCount > 0)
                {
                    cmbFixedPrefered.EditValue = ipl.ItemID;
                }
                else
                {
                    cmbFixedPrefered.EditValue = null;
                }
                lblFixedPickItem.Text = "Fixed Item";
                lblFixedPickItem.Visible = true;
                cmbFixedPrefered.Visible = true;
                lstPreferedItems.Visible = false;
                lblPreferredItem.Visible = false;
            }
          
            // Bind the available variables
            txtPalletLocationLabel.Text = dr["Label"].ToString();
            chkEnabled.Checked = Convert.ToBoolean(dr["IsEnabled"]);
            
            
        }

        private void OnFilterStorageTypeChanged(object sender, EventArgs e)
        {
            // populate the shelf grid
            
            Shelf s = new Shelf();
            if ( cmbStorageTypeFilter.EditValue != null && cmbStorageTypeFilter.EditValue.ToString() != "")
            {
                s.LoadForMergedView(cmbStorageTypeFilter.EditValue.ToString());
                gridShelfDetails.DataSource = s.DefaultView;
                s.LoadShelvesByStorageType(cmbStorageTypeFilter.EditValue.ToString());
            }
            else
            {
                s.LoadForMergedView();
                s.LoadAllShelves();
            }
            
            // populate the shelf combo box.
            cmbShelfCodes.Properties.DataSource = s.DefaultView;
            cmbShelfCodes.EditValue = null;
        }

        private void OnFilterByShelfChanged(object sender, EventArgs e)
        {
            Shelf s = new Shelf();
            if (cmbShelfCodes.EditValue != null && cmbShelfCodes.EditValue.ToString() != "")
            {
                s.LoadForMergedViewByShelfID(Convert.ToInt32(cmbShelfCodes.EditValue));
                gridShelfDetails.DataSource = s.DefaultView;
            }
            else
            {
                OnFilterStorageTypeChanged(new object(), new EventArgs());
            }
               
        }

        private void OnSavePalletLocationDetails(object sender, EventArgs e)
        {
            // save the label and isEnabled first
            // these are the common properties
            DataRow dr = detailView.GetFocusedDataRow();
            PalletLocation pl = new PalletLocation();
            pl.LoadByPrimaryKey(Convert.ToInt32(dr["PalletLocationID"]));

            pl.Label = txtPalletLocationLabel.Text;
            pl.IsEnabled = chkEnabled.Checked;

            // set this to refresh the grid
            dr["PalletLocationLabel"] = txtPalletLocationLabel.Text;
            dr["IsEnabled"] = chkEnabled.Checked;


            pl.Save();
            gridShelfDetails.RefreshDataSource();
            CurrentPopup.ClosePopup();
        }

        private void CancelEditAddShelf(object sender, EventArgs e)
        {
            // clear all form items
        }


        private void OnAddNewWarehouse(object sender, EventArgs e)
        {
            ps.AddNew();
        }

        private void OnSaveWarehouse(object sender, EventArgs e)
        {
            ps.DoBeforeSave();
            // do the validation here
            ps.Rewind();
            while (!ps.EOF)
            {

                if (ps.IsColumnNull("Name"))
                {
                    XtraMessageBox.Show("You cannot leave the Name field as Empty, Please fix that and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ps.MoveNext();
            }
            
            ps.Save();

            ps.Rewind();
            while (!ps.EOF)
            {
                if (ps.IsColumnNull("CurrentInventoryPeriodID"))
                {
                    var inventoryPeriod = ps.AddInventoryPeriod();
                    ps.CurrentPeriodStartDate = inventoryPeriod.StartDate;
                    ps.CurrentInventoryPeriodID = inventoryPeriod.ID;
                    ps.IsActive = true;
                    ps.Save();
                }
              ps.MoveNext();
            }
            
            XtraMessageBox.Show("Your changes have been saved!","Confirmation",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void xtraTabControl1_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {

            if (e.PrevPage == tbWarehouseSetup)
            {
                elementHost1.Visible = false;
            }
            if (e.PrevPage == tbFloorView)
            {
                elementHost2.Visible = false;
            }
            if (e.PrevPage == tbRackSetup)
            {
                elementHost3.Visible = false;
            }


            if (e.Page == tbWarehouseSetup)
            {
                elementHost1.Visible = true;
            }
            if (e.Page == tbFloorView)
            {
                elementHost2.Visible = true;
            }
            if (e.Page == tbRackSetup)
            {
                elementHost3.Visible = true;
            }
        }

        private void lkStorageTypes_EditValueChanged(object sender, EventArgs e)
        {
            DataRow dr = gridViewPhysicalStores.GetFocusedDataRow();
            int id = Convert.ToInt32(dr["ID"]);
            BLL.Shelf shelf = new Shelf();
            shelf.LoadByPrimaryKey(id);
            if (shelf.RowCount > 0)
            {
                shelf.ShelfStorageType = Convert.ToInt32(lkStorageTypes.EditValue);
                shelf.Save();
            }
            //BLL.PhysicalStore phStore = new PhysicalStore();
            //phStore.LoadByPrimaryKey(id);
            //phStore.PhysicalStoreTypeID = Convert.ToInt32(lkStorageTypes.EditValue);
            //phStore.Save();
            PopulateLookups();
        }

        private void btnAddNewPhysicalStoreType_Click(object sender, EventArgs e)
        {
            psType.AddNew();
            psType.IsActive = true;
        }

        private void btnSavePhysicalStoreType_Click(object sender, EventArgs e)
        {
            psType.Rewind();
            while (!psType.EOF)
            {

                if (psType.IsColumnNull("Name"))
                {
                    XtraMessageBox.Show("You cannot leave the Name field as Empty, Please fix that and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                psType.MoveNext();
            }
            psType.Save();
            XtraMessageBox.Show("Your changes have been saved!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnAddCluster_Click(object sender, EventArgs e)
        {
            cluster.AddNew();
            cluster.IsActive = true;
        }

        private void btnSaveCluster_Click(object sender, EventArgs e)
        {
            cluster.Rewind();
            while (!cluster.EOF)
            {

                if (cluster.IsColumnNull("Name"))
                {
                    XtraMessageBox.Show("You cannot leave the Name field as Empty, Please fix that and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                cluster.MoveNext();
            }
            cluster.Save();
            XtraMessageBox.Show("Your changes have been saved!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


       
    }
}
