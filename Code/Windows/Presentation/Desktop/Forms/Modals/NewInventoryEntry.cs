using System;
using System.Data;
using System.Windows.Forms;
using BLL;

namespace HCMIS.Desktop.Forms.Modals
{
    public partial class NewInventoryEntry : Form
    {
        private int _inventoryPeriodID;
        private int _physicalStoreID;
        private int _activityID;
        private DataRow _dr;
        private int _categoryId;
        public NewInventoryEntry(int inventoryPeriodId, int physicalStoreId, int activityId)
        {
            _inventoryPeriodID = inventoryPeriodId;
            _physicalStoreID = physicalStoreId;
            _activityID = activityId;
            InitializeComponent();
        }

        public NewInventoryEntry(DataRow dr)
        {
            _dr = dr;
            InitializeComponent();
            LoadUpdateForm(dr); 
        }

        private void LoadUpdateForm(DataRow dr)
        {
            btnSave.Text = "Update";
            lkCategory.Enabled = false;
            lkItem.Enabled = false;
            Duplicate.Enabled = false;

            Activity activity = new Activity();
            activity.LoadByPrimaryKey(Convert.ToInt32(_dr["ActivityID"]));
            textActivity.Text = activity.FullActivityName;

            PhysicalStore physicalStore = new PhysicalStore();
            physicalStore.LoadByPrimaryKey(Convert.ToInt32(_dr["PhysicalStoreID"]));
            textStore.Text = string.Format("{0} - {1}", physicalStore.WarehouseName, physicalStore.Name);

            lkCategory.EditValue = Convert.ToInt32(dr["TypeID"]);
            lkItem.Properties.DataSource = Item.GetActiveItemsByCommodityTypeForReceiveScreen(Convert.ToInt32(dr["TypeID"]) ,Convert.ToInt32(dr["ActivityID"]));
            lkItem.EditValue = Convert.ToInt32(dr["ItemID"]);
            lkUnit.EditValue = Convert.ToInt32(dr["UnitID"]);

            lkManufacturer.EditValue = Convert.ToInt32(dr["ManufacturerID"]);
            dtExpiryDate.EditValue = Convert.ToDateTime(dr["ExpiryDate"]);
            txtBatchNo.Text = Convert.ToString(dr["BatchNo"]);

            txtSoundQty.Text = Convert.ToString(dr["InventorySoundQuantity"]);
            txtDamagedQty.Text = Convert.ToString(dr["InventoryDamagedQuantity"]);
            txtExpiredQty.Text = Convert.ToString(dr["InventoryExpiredQuantity"]);
            
        }

        private void NewInventoryEntry_Load(object sender, EventArgs e)
        {
            lkCategory.Properties.DataSource = CommodityType.GetAllTypes();

            // load the activity and the physical store names ... so the dialog box shows some context
            Activity activity = new Activity();
            activity.LoadByPrimaryKey(_activityID);
            textActivity.Text = activity.FullActivityName;

            PhysicalStore physicalStore = new PhysicalStore();
            physicalStore.LoadByPrimaryKey(_physicalStoreID);
            textStore.Text = string.Format("{0} - {1}", physicalStore.WarehouseName, physicalStore.Name);

        }

        private void lkCategory_EditValueChanged(object sender, EventArgs e)
        {
            if (lkCategory.EditValue != null)
            {
                _categoryId = Convert.ToInt32(lkCategory.EditValue);
                lkItem.Properties.DataSource = Item.GetActiveItemsByCommodityTypeForReceiveScreen(_categoryId, _activityID);
            }

        }

        private void lkItem_EditValueChanged(object sender, EventArgs e)
        {

            if (lkItem.EditValue != null)
            {
                ItemUnit itemUnit = new ItemUnit();
                itemUnit.LoadAllForItem(Convert.ToInt32(lkItem.EditValue));
                lkUnit.Properties.DataSource = itemUnit.DefaultView;

                Manufacturer itemManufacturer = new Manufacturer();
                itemManufacturer.LoadForItem(Convert.ToInt32(lkItem.EditValue));
                lkManufacturer.Properties.DataSource = itemManufacturer.DefaultView;
            }

        }

        private bool validateBatchandExpiryDate()
        {
            int itemId = Convert.ToInt32(lkItem.EditValue);
            Item item = new Item();
            item.LoadByPrimaryKey(itemId);
            if(item.NeedExpiryBatch)
            {
                if((string) txtBatchNo.EditValue == "")
                {
                    txtBatchNo.ErrorText = "BatchNo is Required";
                    return false;
                }
                if(dtExpiryDate.EditValue == null)
                {
                    dtExpiryDate.ErrorText = "Expiry Date is required";
                    return false;
                }
            }
            return true;

        }
        private bool validateExpiryQuantity()
        {
            if (dtExpiryDate.EditValue != null && Convert.ToDateTime(dtExpiryDate.EditValue) < DateTimeHelper.ServerDateTime && Convert.ToDecimal(txtSoundQty.EditValue) > 0)
            {
                txtSoundQty.ErrorText = "Expired Items can't be Entered as Sound";
                return false;
            }
            if ((Convert.ToDateTime(dtExpiryDate.EditValue) > DateTimeHelper.ServerDateTime || dtExpiryDate.EditValue == null) && Convert.ToDecimal(txtExpiredQty.EditValue) > 0)
            {
                txtExpiredQty.ErrorText = "Sound Items can't be register as Expired ";
                return false;
            }
            return true;
        }
        private bool ValidateQuantity()
        {
            if (Convert.ToDecimal(txtSoundQty.EditValue) + Convert.ToDecimal(txtExpiredQty.EditValue) + Convert.ToDecimal(txtDamagedQty.EditValue) <= 0)
            {
                txtSoundQty.ErrorText = "Quantity can't be zero.";
                return false;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Update")
            {
                var inventory = new Inventory();
                inventory.LoadByPrimaryKey(Convert.ToInt32(_dr["ID"]));
                inventory.UnitID = Convert.ToInt32(lkUnit.EditValue);
                inventory.ManufacturerID = Convert.ToInt32(lkManufacturer.EditValue);
                inventory.ExpiryDate = Convert.ToDateTime(dtExpiryDate.EditValue);
                inventory.BatchNo = txtBatchNo.Text;
                inventory.InventorySoundQuantity = Convert.ToDecimal(txtSoundQty.EditValue);
                inventory.InventoryDamagedQuantity = Convert.ToDecimal(txtDamagedQty.EditValue);
                inventory.InventoryExpiredQuantity = Convert.ToDecimal(txtExpiredQty.EditValue);
                inventory.Save();
                this.Close();
            }
            else
            {
                if (dxValidationProvider1.Validate() && validateBatchandExpiryDate() && validateExpiryQuantity() &&
                    ValidateQuantity())
                {
                    var inventory = new Inventory();
                    inventory.AddNew();
                    inventory.InventoryPeriodID = _inventoryPeriodID;
                    inventory.PhysicalStoreID = _physicalStoreID;
                    inventory.ActivityID = _activityID;
                    inventory.ItemID = Convert.ToInt32(lkItem.EditValue);
                    inventory.UnitID = Convert.ToInt32(lkUnit.EditValue);
                    inventory.ManufacturerID = Convert.ToInt32(lkManufacturer.EditValue);
                    if (txtBatchNo.EditValue != null)
                    {
                        inventory.BatchNo = txtBatchNo.EditValue.ToString();
                    }
                    if (dtExpiryDate.EditValue != null)
                    {
                        inventory.ExpiryDate = Convert.ToDateTime(dtExpiryDate.EditValue);
                    }
                    inventory.InventorySoundQuantity = Convert.ToDecimal(txtSoundQty.EditValue);
                    inventory.InventoryDamagedQuantity = Convert.ToDecimal(txtDamagedQty.EditValue);
                    inventory.InventoryExpiredQuantity = Convert.ToDecimal(txtExpiredQty.EditValue);
                    inventory.RecordedDate = DateTimeHelper.ServerDateTime;
                    inventory.RecordedBy = CurrentContext.UserId;
                    inventory.IsDraft = true;
                    inventory.Remarks = "New Entry";
                    inventory.Save();
                    if (Duplicate.CheckState == CheckState.Checked)
                    {
                        ClearValues();
                    }
                    else
                    {
                        this.Close();
                    }
                }
            }


        }

        private void ClearValues()
        {
            txtBatchNo.EditValue =null;
            txtSoundQty.EditValue = 0;
            txtDamagedQty.EditValue = 0;
            txtExpiredQty.EditValue = 0;
            dtExpiryDate.EditValue = null;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
