using System;
using System.Data;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;
using HCMIS.Desktop;

namespace HCMIS.Desktop
{
    public partial class ItemManufacturer : XtraForm
    {
        private  int _itemID = 0;
        private Boolean _isSaving = false;
        public ItemManufacturer(int itemID)
        {
            InitializeComponent();
            _itemID = itemID;
        }
        BLL.ItemManufacturer im = new BLL.ItemManufacturer();
        ItemUnit itemUnit = new ItemUnit();

        private void ItemManufacturer_Load(object sender, EventArgs e)
        {
            PopulateItems();
            //if(BLL.Settings.IsRdfMode)
            //{
            //    groupPackageLevels.Visibility = LayoutVisibility.Never;
            //    groupPackageLevels.Expanded = false;
            //}else
            //{
            //    groupPackageLevels.Expanded = true;
            //}
        }

        private void PopulateItems()
        {
            Item itm = new Item();
            itm.GetItemByPrimaryKey(this._itemID);
            if (itm.IsColumnNull("StorageTypeID"))
            {
                itm.StorageTypeID = 1;
                itm.Save();
            }
            if (itm.StorageTypeID.ToString() == StorageType.BulkStore && !itm.IsColumnNull("IsStackStored") && itm.IsStackStored)
            {
                layoutStackedView.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;                
            }
            else
                layoutStackedView.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            
            lblItemName.Text = itm.FullItemName;
            BLL.ItemManufacturer imfr = new BLL.ItemManufacturer();
            imfr.LoadManufacturersFor(this._itemID);
            lstManufacturers.DataSource = imfr.DefaultView;
            itemUnit.LoadAllForItem(_itemID);
            gridUnits.DataSource = itemUnit.DefaultView;
        }

        private void lstManufacturers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstManufacturers.SelectedItems.Count > 0)
            {
                DataRowView drv =(DataRowView) lstManufacturers.SelectedItems[0];
                int manufacturerID = Convert.ToInt32(drv["ManufacturerID"]);

                Item itm = new Item();
                txtStackedHeight.EditValue = itm.GetStackHeight(_itemID, manufacturerID);

                im.LoadManufacturerItemRelationsFor(this._itemID, manufacturerID);
                lstLevel.DataSource = im.DefaultView;
                lstLevel.DisplayMember = "PLevel";
                lstLevel.ValueMember = "ID";
                lstLevel.SelectedIndex = 0;
                OnPackageLevelSelected(new object(), new EventArgs());
            }
        }

        private void btnAddManufacturer_Click(object sender, EventArgs e)
        {
            Dialogs.AddManufacturerForItem amfi = new HCMIS.Desktop.Dialogs.AddManufacturerForItem(_itemID);
            DialogResult dr = amfi.ShowDialog();
            if (DialogResult.Yes ==dr)
            {
                int manufID = amfi.SelectedManufacturer;
                Manufacturer manufacturer = new Manufacturer();
                manufacturer.LoadByPrimaryKey(manufID);
              
                BLL.ItemManufacturer imm = new BLL.ItemManufacturer();
                imm.LoadManufacturerItemRelationsFor(_itemID, manufID);
                if (imm.RowCount > 0)
                {

                }
                else
                {
                    imm.AddNew();
                    imm.ItemID = _itemID;
                    imm.ManufacturerID = manufID;
                    imm.BoxHeight = 1;
                    imm.BoxLength = 1;
                    imm.BoxWidth = 1;
                    imm.PackageLevel = 0;
                    imm.RecevingDefault = false;
                    imm.QuantityPerLevel = 1;
                    imm.Save();
                }
                im.LoadManufacturersFor(_itemID);
                this.lstManufacturers.DataSource = im.DefaultView;
            }

        }

        private void OnPackageLevelSelected(object sender, EventArgs e)
        {
            if (!_isSaving)
            {
                if (lstLevel.SelectedItems.Count > 0)
                {
                    DataRowView drv = (DataRowView)lstLevel.SelectedItems[0];
                    
                    String SelectedID = drv["ID"].ToString();
                   
                    double divider = GetDivider();

                    im.Rewind();
                    int basicQ = 1;
                    for (int i = 0; i < lstLevel.SelectedIndex; i++)
                    {
                        if (im.QuantityPerLevel > 0)
                            basicQ *= im.QuantityPerLevel;
                        im.MoveNext();
                    }

                   

                    if (!im.IsColumnNull("QuantityPerLevel"))
                    {
                        basicQ *= im.QuantityPerLevel;
                    }
                    txtHeight.Text = (!im.IsColumnNull("BoxHeight")) ? (im.BoxHeight * divider).ToString() : "0";
                    txtWidth.Text = (!im.IsColumnNull("BoxWidth")) ? (im.BoxWidth * divider).ToString() : "0";
                    txtLength.Text = (!im.IsColumnNull("BoxLength")) ? (im.BoxLength * divider).ToString() : "0";
                    txtQuantity.Text = (!im.IsColumnNull("QuantityPerLevel")) ? im.QuantityPerLevel.ToString() : "0";
                    lblQuantityInBasicUnit.Text = String.Format("Basic Unit = {0}", basicQ);
                    chkDefault.Checked = im.RecevingDefault;

                    switch (im.PackageLevel)
                    {
                        case 0:
                            picLevel.Image = Properties.Resources.OnePack;
                            break;
                        case 1:
                            picLevel.Image = Properties.Resources.SecondLevel;
                            break;
                        case 2:
                            picLevel.Image = Properties.Resources.ThirdLevel;
                            break;
                        case 3:
                            picLevel.Image = Properties.Resources.FourthLevel;
                            break;
                    }

                    try
                    {
                        lblVolume.Text = "Volume = " + (im.BoxHeight * im.BoxLength * im.BoxWidth).ToString();
                    }
                    catch { }
                }
            }
        }
        
        private void AddNewPackageLevelToManufItem(object sender, EventArgs e)
        {
            //if(lstLevel.SelectedItems.Count > 0)
                //OnSaveItemManufacturerClick(new object(),new EventArgs());
            if (im.RowCount > 0)
            {
                int ItemID = im.ItemID;
                int ManufID = im.ManufacturerID;
                im.AddNew();
                im.ItemID = ItemID;
                im.ManufacturerID = ManufID;
                im.PackageLevel = im.RowCount - 1;
                im.QuantityPerLevel = 1;
                im.RecevingDefault = false;
                im.BoxHeight = 1;
                im.BoxWidth = 1;
                im.BoxLength = 1;
                lstLevel.DataSource = im.DefaultView;
                im.Save();

                lstManufacturers_SelectedIndexChanged(new object(), new EventArgs());
                lstLevel.SelectedIndex = lstLevel.Items.Count - 1;
                OnPackageLevelSelected(new object(), new EventArgs());
            }
        }

        private void OnSaveItemManufacturerClick(object sender, EventArgs e)
        {
            _isSaving = true;

            BLL.Item itm = new Item();
            
            if (im.RowCount > 0)
            {
                double divider = GetDivider();

                // Save the metric data
                im.BoxHeight = Convert.ToDouble(txtHeight.Text) / divider;
                im.BoxLength = Convert.ToDouble(txtLength.Text) / divider;
                im.BoxWidth = Convert.ToDouble(txtWidth.Text) / divider;
                // validate if someone is attempting to change the SKU after it has been used.
                // 
                if (im.PackageLevel == 0)
                {
                    BLL.ItemManufacturer imff = new BLL.ItemManufacturer();
                    imff.LoadIMbyLevel(im.ItemID, im.ManufacturerID, 0);
                    if (imff.HasReceives() && !Settings.IsRdfMode)
                    {
                        if(!Settings.IsRdfMode)
                        {
                           if(XtraMessageBox.Show("Are you sure you want change this level and all the received data along with it?","Confirmation",MessageBoxButtons.YesNo) == DialogResult.Yes)
                           {
                               // Do the logic that changes the SKU.
                               BLL.ItemManufacturer.ChangeSKU(im.ItemID, im.ManufacturerID,0,
                                                              Convert.ToInt32(txtQuantity.Text));
                           }
                        }
                        else
                        {
                            XtraMessageBox.Show("You cannot change an SKU for an Item that has already been Received using this quantity. Please contact the administrator for such changes.","Changing a used SKU not allowed");
                            return;
                        }
                    }
                }

                im.QuantityPerLevel = Convert.ToInt32(txtQuantity.Text);

                if (im.QuantityPerLevel <= 0)
                {
                    im.QuantityPerLevel = 1;
                }

                im.Save();
                if (chkDefault.Checked)
                {
                    im.SaveReceivingDefault();
                }

                itm.LoadByPrimaryKey( _itemID );
                if (itm.StorageTypeID.ToString() == StorageType.BulkStore && !itm.IsColumnNull("IsStackStored") && itm.IsStackStored)
                {
                    BLL.ItemManufacturer imf = new BLL.ItemManufacturer();
                    imf.SaveStackStored( _itemID, im.ManufacturerID, Convert.ToDouble(txtStackedHeight.EditValue));
                }
                SaveItemUnits();
                XtraMessageBox.Show("Your changes have been saved.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            _isSaving = false;
           OnPackageLevelSelected(new object(), new EventArgs());
        }

        private void SaveItemUnits()
        {
            // TODO: some validation
            // TOFIX: remove the try cache
            itemUnit.Rewind();            
            while(!itemUnit.EOF)
            {
                if(itemUnit.IsColumnNull("ItemID"))
                {
                    itemUnit.ItemID = _itemID;
                }
                itemUnit.MoveNext();
            }
            try
            {
                itemUnit.Save();
            }catch
            {
                XtraMessageBox.Show("There is error saving the Unit");
            }
        }

        private double GetDivider()
        {
            if (radioUnits.EditValue.ToString() == "M")
            {
                return 1;
            }
            else if (radioUnits.EditValue.ToString() == "CM")
            {
                return 100;
            }
            else
            {
                return 1000;
            }
        }

        private void OnCancelClicked(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioUnits.EditValue.ToString() == "M")
            {
                lblLengthUnit.Text = lblHeightUnit.Text = lblWidthUnit.Text = @"M";
            }
            else if (radioUnits.EditValue.ToString() == "CM")
            {
                lblLengthUnit.Text = lblHeightUnit.Text = lblWidthUnit.Text = @"CM";
            }
            else
            {
                lblLengthUnit.Text = lblHeightUnit.Text = lblWidthUnit.Text = @"MM";
                
            }
            double divider = GetDivider();
            if (im.RowCount > 0)
            {
                txtHeight.Text = (im.BoxHeight * divider).ToString();
                txtLength.Text = (im.BoxLength * divider).ToString();
                txtWidth.Text = (im.BoxWidth * divider).ToString();
            }
        }

        private void btnRemoveLevel_Click(object sender, EventArgs e)
        {

            if (XtraMessageBox.Show("Are you sure you want to delete this Package Level?", "Confirmation", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {

                BLL.ItemManufacturer imf = new BLL.ItemManufacturer();
                DataRowView drv = (DataRowView)lstLevel.SelectedItems[0];
                String SelectedID = drv["ID"].ToString();

                imf.LoadByPrimaryKey(Convert.ToInt32(SelectedID));

                if (imf.HasDependants())
                {
                    XtraMessageBox.Show("This Item Manufacturer cannot be deleted because there are other box levels that depend on it.", "Deleting is not allowed.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (imf.HasReceives())
                {
                    XtraMessageBox.Show("This Item Manufacturer Cannot be Deleted because there are items that were received with this manufacturer item composition.", "Deleting is not allowed.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                imf.MarkAsDeleted();

                imf.Save();

                //refresh the window
                imf.LoadManufacturersFor(this._itemID);
                lstManufacturers.DataSource = imf.DefaultView;

                lstManufacturers_SelectedIndexChanged(null, null);
            }
        }

        private void btnAddUnit_Click(object sender, EventArgs e)
        {
            gridView1.AddNewRow();
            //QuantityPerUnit.OptionsColumn.AllowEdit = true;
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
           //QuantityPerUnit.OptionsColumn.AllowEdit = false;
        }

        private void repositoryItemTextEdit1_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            bool isNewRow = gridView1.IsNewItemRow(gridView1.FocusedRowHandle);
            if (e.OldValue != null && !isNewRow)
            {
                XtraMessageBox.Show("Unit editing not allowed!", "Editing Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
        }
    }
}
