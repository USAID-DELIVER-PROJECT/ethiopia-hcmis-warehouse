using System;
using BLL;
using DevExpress.XtraEditors;
using HCMIS.Desktop.Helpers;
using HCMIS.Desktop.ViewHelpers;

namespace HCMIS.Desktop.Modals
{
    public partial class EditReceived : XtraForm
    {
        ReceiveDoc rDoc = new ReceiveDoc();
        public EditReceived(int receieveDocId)
        {
            InitializeComponent();

            rDoc.LoadByPrimaryKey(receieveDocId);
        }

        private void EditReceived_Load(object sender, EventArgs e)
        {
            BLL.ItemManufacturer im = new BLL.ItemManufacturer();
            im.LoadManufacturersFor(rDoc.ItemID);
            lkManufacturer.Properties.DataSource = im.DefaultView;

            if (BLL.Settings.UseNewUserManagement && this.HasPermission("Edit-Quantity") && (rDoc.IsColumnNull("Confirmed") || (!rDoc.IsColumnNull("Confirmed") && !rDoc.Confirmed)))
            {
                txtQuanitity.Enabled = true;
            }
            else if ( (!rDoc.IsColumnNull("Confirmed") && !rDoc.Confirmed))
            {
                txtQuanitity.Enabled = true;
            }
            else
            {
                txtQuanitity.Enabled = false;
            }
            Supplier supplier = new Supplier();
            supplier.LoadAll();
            lkSupplier.Properties.DataSource = supplier.DefaultView;

            lkAccount.SetupActivityEditor().SetDefaultActivity();
            BLL.ItemUnit iu = new ItemUnit();
            iu.LoadAllForItem(rDoc.ItemID);
            lkUnit.Properties.DataSource = iu.DefaultView;

            // Bind the variables)
            if (rDoc.RowCount > 0)
            {
                this.txtRefNo.Text = rDoc.RefNo;
                this.txtQuanitity.Text =
                    Convert.ToInt32(Convert.ToDouble(rDoc.Quantity)/rDoc.QtyPerPack).ToString("#,##0");
                this.txtManufacturer.Text = Manufacturer.GetName(rDoc.ManufacturerId);
                this.txtItemName.Text = Item.GetName(rDoc.ItemID);
                this.txtGrvNo.Text = rDoc.RefNo;
                this.lkManufacturer.EditValue = rDoc.ManufacturerId;
                this.lkAccount.EditValue = rDoc.StoreID;
                this.lkUnit.EditValue = rDoc.UnitID;

                if (!rDoc.IsColumnNull("SupplierID"))
                    lkSupplier.EditValue = rDoc.SupplierID;
                // Editable controls
                txtPrice.Text = rDoc.IsColumnNull("Cost") ? "0" : rDoc.Cost.ToString();
                if (!rDoc.IsColumnNull("ExpDate"))
                {
                    dtExpiry.EditValue = rDoc.ExpDate;
                }
                if (!rDoc.IsColumnNull("BatchNo"))
                {
                    txtBatchNo.Text = rDoc.BatchNo;
                }

                BLL.Item itm = new Item();
                itm.LoadByPrimaryKey(rDoc.ItemID);
                if (BLL.Settings.UseNewUserManagement && this.HasPermission("Edit-Batch-Expiry"))
                {

                }
                else if (!itm.NeedExpiryBatch &&
                         (CurrentContext.LoggedInUser.UserType == UserType.Constants.ADMIN ||
                          CurrentContext.LoggedInUser.UserType == UserType.Constants.SUPER_ADMINISTRATOR))
                {
                    btnRemoveExpiry.Enabled = true;
                    txtBatchNo.Enabled = true;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            LogReceiptChange change = new LogReceiptChange(rDoc);

            if (txtBatchNo.EditValue != null)
            {
                rDoc.BatchNo = txtBatchNo.Text;
            }
            if (dtExpiry.EditValue != null)
            {
                rDoc.ExpDate = dtExpiry.DateTime;
            }
            else
            {
                rDoc.SetColumnNull("ExpDate");
            }
            if (txtPrice.EditValue != null)
            {
                rDoc.Cost = Convert.ToDouble(txtPrice.EditValue);
            }
            
            if(lkAccount.EditValue!=null)
            {
                rDoc.StoreID = Convert.ToInt32(lkAccount.EditValue);
                //TODO:Edit other tables as well.
            }

            if(lkUnit.EditValue!=null)
            {
                int unitID = Convert.ToInt32(lkUnit.EditValue);
                if (rDoc.UnitID != unitID)
                {

                    rDoc.UnitID = Convert.ToInt32(lkUnit.EditValue);
                    BLL.ItemUnit itemUnit = new ItemUnit();
                    itemUnit.LoadByPrimaryKey(rDoc.UnitID);
                    rDoc.QtyPerPack = itemUnit.QtyPerUnit;
                    rDoc.Quantity = rDoc.NoOfPack * rDoc.QtyPerPack;
                    rDoc.QuantityLeft = rDoc.Quantity;

                    BLL.ReceivePallet rp = new ReceivePallet();
                    rp.LoadByReceiveDocID(rDoc.ID);
                    rp.Balance = rDoc.QuantityLeft;
                    rp.ReceivedQuantity = rDoc.Quantity;

                    rDoc.Save();
                    rp.Save();
                }
            }


            // decide to save the quantity or not
            //Lord have mercy, this is not a proper way to do it,
            decimal quantity = Convert.ToDecimal(txtQuanitity.EditValue.ToString().Replace(",", ""));

            

            if (txtQuanitity.Enabled && !rDoc.HasTransactions() && rDoc.Quantity != rDoc.QtyPerPack * quantity)
            {
                // now find the receive pallets
                ReceivePallet receivePallet = new ReceivePallet();
                receivePallet.LoadNonZeroRPByReceiveID(rDoc.ID);
                if (receivePallet.RowCount > 1)
                {
                    // 
                    XtraMessageBox.Show(
                        "This Item is stored in more than one location and chaning the quanitity is not implemented. try to consolidate it and try again");
                }
                else
                {

                    rDoc.NoOfPack = quantity;
                    receivePallet.Balance = receivePallet.ReceivedQuantity = rDoc.QuantityLeft = rDoc.Quantity = quantity * rDoc.QtyPerPack;
                    rDoc.Save();
                    receivePallet.Save();
                }
            }
            else if (rDoc.Quantity != quantity * rDoc.QtyPerPack)
            {
                XtraMessageBox.Show("The Quantity was not edited because there was an issue transaction on it.");
            }

            rDoc.RefNo = txtGrvNo.EditValue.ToString();
            //rDoc.SupplierID = Convert.ToInt32(lkSupplier.EditValue);
            if (lkManufacturer.EditValue != null)
                rDoc.ManufacturerId = Convert.ToInt32(lkManufacturer.EditValue);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            rDoc.Save();
            change.SaveChangeLog(rDoc, CurrentContext.UserId);
            this.LogActivity("Save-Receipt-Change", rDoc.ID);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRemoveExpiry_Click(object sender, EventArgs e)
        {
            dtExpiry.EditValue = null;
        }
    }
}
