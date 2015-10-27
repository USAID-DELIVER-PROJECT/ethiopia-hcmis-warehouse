using System;
using System.Data;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace HCMIS.Desktop.Forms.Settings
{
    public partial class BasicItemSettings : XtraForm
    {
        public BasicItemSettings()
        {
            InitializeComponent();
        }

        int itemId = 0;
        int categoryId = 0;
        Boolean isStorageTypeChanged = false;
        PickFace pf = new PickFace();

        public BasicItemSettings(int id, bool ItemID)
        {
            InitializeComponent();
            if (ItemID)
                itemId = id;
            else
                categoryId = id;
        }

        private void PopulateFields()
        {            
            // Bind the lookups first
            ABC abc = new ABC();
            abc.LoadAll();

            radioGroupABC.Properties.Items.Clear();
            while(!abc.EOF){
                radioGroupABC.Properties.Items.Add(new RadioGroupItem(abc.ID, abc.Description));
                abc.MoveNext();
            }

            radioGroupVEN.Properties.Items.Clear();
            VEN ven = new VEN();
            ven.LoadAll();
            while (!ven.EOF)
            {
                radioGroupVEN.Properties.Items.Add(new RadioGroupItem(ven.ID, ven.Description));
                ven.MoveNext();
            }

            if(itemId != 0)
            {
                Item itm = new Item();
                
                //itm.LoadByPrimaryKey(itemId);
                DataTable dtItem = itm.GetItemById(itemId);
                txtItemName.Text = itm.FullItemName;//String.Format("{0} - {1} - {2}", dtItem.Rows[0]["ItemName"], dtItem.Rows[0]["DosageForm"], dtItem.Rows[0]["Strength"]);
                ckExculed.Checked = (!itm.IsColumnNull("IsInHospitalList"))?itm.IsInHospitalList:false;
               
                chkProcessDecimal.Checked = (!itm.IsColumnNull("ProcessInDecimal")) ? itm.ProcessInDecimal : false;
               
                if (!itm.IsColumnNull("ABCID"))
                {
                    radioGroupABC.EditValue = itm.GetColumn("ABCID");
                }
                if (!itm.IsColumnNull("VENID"))
                {
                    radioGroupVEN.EditValue = itm.GetColumn("VENID");
                }

                Supplier sup = new Supplier();
                sup.LoadAll();
                ItemSupplier itmSup = new ItemSupplier();
                itmSup.GetSuppliersAndMarkThoseUsed(itemId);
                
                while(!itmSup.EOF)
                {
                    lstSuppliers.Items.Add(itmSup.GetColumn("CompanyName"),Convert.ToBoolean(itmSup.GetColumn("IsUsed")));
                    itmSup.MoveNext();
                }

                BLL.Program prog = new BLL.Program();
                prog.GetSubPrograms();
                ItemProgram progItem = new ItemProgram();
                lstPrograms.Items.Clear();
                foreach (DataRowView dv in prog.DefaultView)
                {
                    bool check = false;
                    check = progItem.CheckIfExists(itemId,Convert.ToInt32(dv["ID"]));
                    lstPrograms.Items.Add(dv["Name"],check);
                }
            }
        }



        private void AddItem_Load(object sender, EventArgs e)
        {

            Shelf slf = new Shelf();
            DataTable dtSlf = slf.GetShelves();
           
            BLL.Program prog = new BLL.Program();
            prog.GetParentPrograms();
            cboPrograms.DataSource = prog.DefaultView;
            cboPrograms.SelectedIndex = -1;

            PopulateFields();            

           
                ResetForHub();
            
        }

        private void ResetForHub()
        {
            grpStorageSettings.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            // Bind the Storage Types

            cmbStorageType.DataSource = StorageType.PrimaryStorageTypes;

            Item itm = new Item();
            itm.LoadByPrimaryKey(itemId);
            if (!itm.IsColumnNull("StorageTypeID"))
            {
                cmbStorageType.SelectedValue = itm.StorageTypeID.ToString();
                if (itm.StorageTypeID.ToString() == StorageType.BulkStore)
                {
                    gridPickfaceLocationsContainer.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    if (itm.IsColumnNull("IsStackStored"))
                    {
                        chkIsStackStored.Checked = false;
                    }
                    else
                    {
                        chkIsStackStored.Checked = itm.IsStackStored;
                    }
                }

            }
            else
            {
                cmbStorageType.SelectedIndex = 0;
            }
            numNearExpiryTrigger.Visible = true;

            if (!itm.IsColumnNull("NearExpiryTrigger"))
                numNearExpiryTrigger.Value = Convert.ToDecimal(itm.NearExpiryTrigger);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!AccountTypeSelectionValid())
            {
                XtraMessageBox.Show("Please choose to which account types this item applies to.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                gridViewStoreItemMatrix.SetColumnError(gridColAcctType, "At least one account type needs to be selected");
                return;
            }
            Item itm = new Item();
            ItemSupplier itmSup = new ItemSupplier();
            if (itemId != 0)
                itm.LoadByPrimaryKey(itemId);
            else
            {
                itm.AddNew();
                ItemCategory prodCate = new ItemCategory();
                prodCate.AddNew();
                prodCate.ItemId = itm.ID;
                prodCate.SubCategoryID = Convert.ToInt32(categoryId);
                prodCate.Save();
            }
            if(radioGroupABC.EditValue != null){
                itm.ABC = Convert.ToInt32(radioGroupABC.EditValue);
            }

            if (radioGroupVEN.EditValue != null)
            {
                itm.VEN = Convert.ToInt32(radioGroupVEN.EditValue);
            }
            itm.IsInHospitalList = ckExculed.Checked;
            itm.ProcessInDecimal = chkProcessDecimal.Checked;
            itm.Save();


            if (itm.IsInHospitalList)
            {
                SaveHubDetails();
            }
            else
            {
                // clear out the prefered locations
                // clear out the pick face locations
                // make sure that this item could be made not in the list

            }

            itmSup.DeleteAllSupForItem(itm.ID);
            Supplier sup = new Supplier();
            for (int i = 0; i < lstSuppliers.CheckedItems.Count;i++ )
            {
                sup.GetSupplierByName(lstSuppliers.CheckedItems[i].ToString());
                itmSup.AddNew();
                itmSup.ItemID = itm.ID;
                itmSup.SupplierID = sup.ID;
                itmSup.Save();
            }
            
            ItemProgram progItm = new ItemProgram();
            progItm.DeleteAllProgramsForItem(itemId);
            BLL.Program prog = new BLL.Program();
            for (int i = 0; i < lstPrograms.CheckedItems.Count; i++)
            {
                prog.GetProgramByName(lstPrograms.CheckedItems[i].ToString());
                progItm.AddNew();
                progItm.ItemID = itm.ID;
                progItm.ProgramID = prog.ID;
                progItm.Save();
            }
           
                XtraMessageBox.Show("Item Detail is Saved Successfully!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
            
        }

        private bool AccountTypeSelectionValid()
        {
            return BLL.ItemActivity.IsAccountTypeMatrixEntered(itemId);
        }

        private void SaveHubDetails()
        {
            if (isStorageTypeChanged)
            {
                
                isStorageTypeChanged = false;
                BLL.ItemPrefferedLocation ipl = new ItemPrefferedLocation();
                ipl.LoadByItemID(itemId);
                while (!ipl.EOF)
                {
                    ipl.MarkAsDeleted();
                    ipl.MoveNext();
                }
                ipl.Save();

            }


            Item itm = new Item();

            if (cmbStorageType.SelectedValue != null)
            {
                if (cmbStorageType.SelectedValue.ToString() == StorageType.BulkStore)
                {
                    // store the stacked storage settings
                    itm.LoadByPrimaryKey(itemId);
                    itm.IsStackStored = chkIsStackStored.Checked;
                    itm.Save();

                    if (lstPreferredPalletLocation.ItemCount > 0)
                    {
                        //Items itm = new Items();

                        // save near expiry trigger point

                        ItemPrefferedLocation ipr = new ItemPrefferedLocation();
                        DataView dv = (DataView)lstPreferredPalletLocation.DataSource;
                        foreach (DataRowView drv in dv)
                        {
                            ipr.SaveNewItemPreferredRack(itemId, Convert.ToInt32(drv["ID"]),false);
                        }
                       
                    }
                    // store pickface settings
                    pf.Rewind();
                    PickFace pfc = new PickFace();
                    while (!pf.EOF)
                    {
                        pf.AcceptChanges();
                        if (!pf.IsColumnNull("PalletLocationID"))
                        {
                            pfc.SavePickFaceLocation(itemId, pf.PalletLocationID, pf.LogicalStore);
                        }
                        else
                        {
                            
                            pfc.LoadPickFaceFor(itemId, pf.LogicalStore);
                            if (pfc.RowCount> 0 && (pfc.IsColumnNull("Balance") || pfc.Balance == 0))
                            {
                                pfc.ClearPickFaceFor(itemId, pfc.LogicalStore);
                            }
                            else
                            {
                                //TODO: show the error message for the user
                            }

                        }
                        pf.MoveNext();
                    }

                }
                else
                {
                    // Save the fixed locations
                    var ipr = new ItemPrefferedLocation();
                    DataView dv = (DataView)lstPreferredPalletLocation.DataSource;
                    if (dv != null)
                    {
                        foreach (DataRowView drv in dv)
                        {
                            ipr.SaveNewItemPreferredRack(itemId, Convert.ToInt32(drv["ID"]), true);
                        }
                    }
                }

                itm.LoadByPrimaryKey(itemId);
                itm.StorageTypeID = int.Parse(cmbStorageType.SelectedValue.ToString());
                itm.NearExpiryTrigger = Convert.ToDouble(numNearExpiryTrigger.Value);
                itm.Save();

            }
        }

        

        


        private void cboStores_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataTable dtSlf = new DataTable();
            //Shelf slf = new Shelf();
            //dtSlf = slf.GetShelvesByStore(Convert.ToInt32(cboStores.SelectedValue));
            
            //PopulateShelfs(dtSlf);
        }

       


        private void cboPrograms_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstPrograms.Items.Clear();
                BLL.Program prog = new BLL.Program();
                ItemProgram progItem = new ItemProgram();
            if (cboPrograms.SelectedValue != null)
            {
                
                prog.GetSubProgramsByParentId(Convert.ToInt32(cboPrograms.SelectedValue));
                
            }
            else
            {
                prog.GetSubPrograms();
            }
            foreach (DataRowView dv in prog.DefaultView)
            {
                bool check = false;
                check = progItem.CheckIfExists(itemId, Convert.ToInt32(dv["ID"]));
                lstPrograms.Items.Add(dv["Name"],check);
            }
        }

        private void lstBinList_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            //for (int i = 0; i < lstBinList.Items.Count; i++)
            //{
            //    if (lstBinList.Items[i].Checked)
            //    {
            //        lstBinList.Items[i].Selected = true;
            //    }
            //}
        }
        
        private void cmbStorageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            layoutStackStored.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            gridPickfaceLocationsContainer.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            isStorageTypeChanged = true;
            if (cmbStorageType.SelectedValue.ToString() == StorageType.BulkStore)
            {
                layoutStackStored.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                gridPickfaceLocationsContainer.Text = "Preffered Pallet Locations";
                // Bind it if possible.
                if (itemId != 0)
                {
                    PalletLocation pl = new PalletLocation();
                    pl.LoadPreferredLocationsFor(itemId);
                    lstPreferredPalletLocation.DataSource = pl.DefaultView;
                    
                   // lstPreferredPalletLocation.DataSource = ipr.DefaultView;
                    gridPickfaceLocationsContainer.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    grpPrefferedLocation.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                    // Bind Pickface Location
                   
                    DataTable dt = pf.GetPalletLocationsForItemLookup(itemId);
                    DataRow drw = dt.NewRow();
                    //drw["ID"] = null;
                    drw["Label"] = "No Pick Face Location Set";
                    dt.Rows.Add(drw);
                    lkRepositoryPickFaces.DataSource = dt;
                    
                    //pf.PalletLocationForItem(itemId);
                    pf.LoadPalletLocationForItemGrid(itemId);
                    gridPickfaceLocations.DataSource = pf.DefaultView;
                }
                layoutControlItem10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            }
            else
            {

                grpPrefferedLocation.Text = @"Fixed Locations";
                grpPrefferedLocation.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                gridPickfaceLocationsContainer.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            Shelf slf = new Shelf();
            slf.LoadShelvesByStorageType(cmbStorageType.SelectedValue.ToString());
            cmbRack.DataSource = slf.DefaultView;
        }

        private void btnAddPreferredLocation_Click(object sender, EventArgs e)
        {
            grpPalletLocation.Visible = true;
            //TODO: populate the applicable shelves;


            //TODO: clear existing selections if any.
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbColumn.SelectedValue != null && cmbRow.SelectedValue != null)
            {
                // TODO: add the saving logic here.
                PalletLocation pl = new PalletLocation();
                pl.LoadPalletLocationFor(cmbRack.SelectedValue.ToString(), cmbColumn.SelectedValue.ToString(), cmbRow.SelectedValue.ToString());
                //Console.WriteLine(cmbRack.SelectedValue);
                //Console.WriteLine(cmbColumn.SelectedValue);
                //pl.LoadPreferredLocationsFor(itemId);
                //lstPreferredPalletLocation.DataSource = pl.DefaultView;
                (lstPreferredPalletLocation.DataSource as DataView).Table.Merge(pl.DefaultView.Table, true, MissingSchemaAction.Add);
                
            }
            grpPalletLocation.Visible = false;
        }

        private void cmbRack_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShelfRowColumn src = new ShelfRowColumn();
            if (cmbRack.SelectedValue != null)
            {
                int shelfID = int.Parse(cmbRack.SelectedValue.ToString());
                src.LoadColumnsForShelf(shelfID);
                cmbColumn.DataSource = src.DefaultView;
                cmbColumn.Enabled = true;

                src.LoadRowsForShelf(shelfID);
                cmbRow.DataSource = src.DefaultView;
                cmbRow.Enabled = true;
            }

        }

        private void btnCancelPalletLocation_Click(object sender, EventArgs e)
        {
            grpPalletLocation.Visible = false;
        }

        private void btnRemovePreferredLocation_Click(object sender, EventArgs e)
        {

            for (int i = lstPreferredPalletLocation.SelectedItems.Count - 1; i >= 0; i-- )
            {
                DataRowView lbi = (DataRowView) lstPreferredPalletLocation.SelectedItems[i];
                (lstPreferredPalletLocation.DataSource as DataView).Table.Rows.Remove((lbi).Row);

            }
        }

        private void chkUsedInThisAccountType_CheckedChanged(object sender, EventArgs e)
        {
            DataRow dr = gridViewStoreItemMatrix.GetFocusedDataRow();
            int ID = int.Parse(dr["ID"].ToString());
            BLL.ItemActivity itemActivity = new ItemActivity();
            itemActivity.LoadByPrimaryKey(ID);
            itemActivity.UsedInThisStore = !itemActivity.UsedInThisStore;
            itemActivity.Save();
        }

    }
}