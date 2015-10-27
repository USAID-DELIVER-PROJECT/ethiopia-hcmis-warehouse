using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CalendarLib;
using DevExpress.XtraEditors;
using BLL;
using System.Collections;
using DevExpress.XtraReports.UI;
using HCMIS.Desktop.Helpers;
using HCMIS.Desktop.ViewHelpers;
using HCMIS.Helpers;

namespace HCMIS.Desktop.Forms.WorkFlow
{
    [FormIdentifier("TR-TR-HT-FR","Transfer Order","Transfer")]
    public partial class TransferOrder : DevExpress.XtraEditors.XtraForm
    {
        #region Member Variables
        // For the first tab (Drug selection)
        static Dictionary<int, DataTable> ItemChoices = new Dictionary<int, DataTable>();
      

        // where all the selected items are stored
        //DataTable _dtSelectedTable = null;
        int TransferTypeID = 1;
        // table that stores order for approval
        DataView _dvItemTable = null;
        DataTable dvPickList = null;
        private int? OrderID;

        bool _gridIsValid = true; //i'm thinking of using this to check if the grid is empty, didn't use it yet


        #endregion

        #region Load and Binding

        public TransferOrder()
        {
            InitializeComponent();
        }

        private void HubToHubTransfer_Load(object sender, EventArgs e)
        {
            SetPermissions();
            // Select the first comodity category
            lkCategoires.ItemIndex = 0;
            //PopulateItemsList();
            BindFormElements();
            ResetOrder();
            lkType.Properties.DataSource = TransferType();
            if(!BLL.Settings.IsCenter)
            lkType.ItemIndex = 1; //Hub to Hub
            else
                lkType.ItemIndex = 2; //Account to Account
            lkFromStore.Properties.DataSource = BLL.PhysicalStore.GetAllActive();
            lkToStore.Properties.DataSource = BLL.PhysicalStore.GetAllActive();
            lkAccountType_EditValueChanged(new object(), new EventArgs());
            //EnableDisableButtons();
        }

        private void SetPermissions()
        {
            if (BLL.Settings.UseNewUserManagement)
            {
                btnSaveAndForward.Enabled = this.HasPermission("Save-And-Print");
                btnCancelOne.Enabled = this.HasPermission("Cancel");
            }
        }

        private DataView TransferType()
        {
            DataView _TransferType = new DataView(new DataTable());
            _TransferType.Table.Columns.Add("ID");
            _TransferType.Table.Columns.Add("TransferName");
            _TransferType.Table.Columns.Add("Type");
            if (!BLL.Settings.IsCenter)
            {
            DataRow HubToHub = _TransferType.Table.NewRow();
            
                HubToHub["ID"] = 1;
                HubToHub["TransferName"] = "Hub To Hub";

                _TransferType.Table.Rows.Add(HubToHub);
            }

            DataRow AccountToAccount = _TransferType.Table.NewRow();

            AccountToAccount["ID"] = 2;
            AccountToAccount["TransferName"] = "Account To Account";
            _TransferType.Table.Rows.Add(AccountToAccount);
            
            DataRow StoreToStore = _TransferType.Table.NewRow();

            StoreToStore["ID"] = 3;
            StoreToStore["TransferName"] = "Store To Store";
            _TransferType.Table.Rows.Add(StoreToStore);
            return _TransferType;
        }

        private void PopulateItemsList()
        {
            if (lkFromActivity.EditValue == null || lkFromActivity.EditValue.ToString() == "")
            {
                return;
            }
            int category = 0;
            if (lkFromStore.EditValue != null && (Convert.ToInt32(lkType.EditValue) == 2 ||  Convert.ToInt32(lkType.EditValue) == 3)) //account to account or store to store
            {
                PopulateItemsListByPhysicalStore();
                return;
            }

            gridItemsChoice.DataSource = Item.GetItemsByCommodityTypeForTransferToHub(category, Convert.ToInt32(lkFromActivity.EditValue));
        }

        private void PopulateItemsListByPhysicalStore()
        {
            if (lkFromActivity.EditValue == null || lkFromActivity.EditValue.ToString() == "")
            {
                return;
            }
            int category = 0;
            gridItemsChoice.DataSource = Item.GetItemsByCommodityTypeForTransferByPhysicalStore(category, Convert.ToInt32(lkFromActivity.EditValue), Convert.ToInt32(lkFromStore.EditValue));
        }
        private void BindFormElements()
        {
            // Find the next order number and write it on the order ID Field
            // The order ID is generated here in code

            DataTable tbl = BLL.CommodityType.GetAllTypes();
            tbl.Rows.Add(0, "All");
            lkCategoires.Properties.DataSource = tbl;

            lkCategoires.EditValue = 0;

            lkFromActivity.SetupActivityEditor();
            lkToActivity.SetupActivityEditor().SetDefaultActivity();

            LoadReceivingUnits();
            BindMainOrderGrid();
            boxSizedList.DataSource = BLL.ItemManufacturer.PackageLevelKeys;
        }

        private void LoadReceivingUnits()
        {
                lkForHub.Properties.DataSource = Institution.LoadHubs();
        }

        private void ResetOrder()
        {
            BindMainOrderGrid();
            //PopulateItemsList();
            txtContactPerson.EditValue = null;
            txtRefNo.Text = "New Order";
            foreach (var x in ItemChoices.Values)
            {
                foreach (DataRowView v in x.DefaultView)
                {
                    v["IsSelected"] = false;
                }
            }
            OrderID = null;
            _dvItemTable.Table.Clear();
            txtItemName.Text = "";
            EnableDisableButtons();
            lkForHub.EditValue = null;
        }

        private void EnableDisableButtons()
        {
            if (_dvItemTable == null || _dvItemTable.Count == 0)
            {
                

            }
            else
            {
                // enable the buttons

                btnCancelOne.Enabled = true;
                btnSaveAndForward.Enabled = true;

            }
        }

        private void BindMainOrderGrid()
        {
            // Given some items are already selected on the first step of the order process (CDR Request) // I doubt that 
            // Bind the second grid with the selected items for the quantity to be filled by the HCMIS Operator

            if (OrderID == null)
            {
                BLL.OrderDetail or = new BLL.OrderDetail();
                or.LoadByPrimaryKey(-1);
                _dvItemTable = new DataView(new DataTable());

                _dvItemTable.Table.Columns.Add("LocationID");
                _dvItemTable.Table.Columns.Add("Packs");
                _dvItemTable.Table.Columns.Add("QtyPerPack");
                _dvItemTable.Table.Columns.Add("UnitPrice");
                _dvItemTable.Table.Columns.Add("ReceiveDocID");
                _dvItemTable.Table.Columns.Add("Cost");
                _dvItemTable.Table.Columns.Add("FullItemName");
                _dvItemTable.Table.Columns.Add("Manufacturer");
                _dvItemTable.Table.Columns.Add("ManufacturerID");
                _dvItemTable.Table.Columns.Add("Unit");
                _dvItemTable.Table.Columns.Add("Balance");
                _dvItemTable.Table.Columns.Add("Location");
                _dvItemTable.Table.Columns.Add("Supplier");
                _dvItemTable.Table.Columns.Add("account");
                _dvItemTable.Table.Columns.Add("BatchNo");
                _dvItemTable.Table.Columns.Add("ExpDate");
                _dvItemTable.Table.Columns.Add("ItemID");
                _dvItemTable.Table.Columns.Add("UnitID");
                _dvItemTable.Table.Columns.Add("ID");
                _dvItemTable.Table.Columns.Add("StockCode");
                _dvItemTable.Table.Columns.Add("StoreID");
                _dvItemTable.Table.Columns.Add("ApprovedPacks");
                _dvItemTable.Table.Columns.Add("ReceivingLocationID");

            }
            
            orderGrid.DataSource = _dvItemTable;
            
            dvPickList = new DataTable();
            dvPickList.Columns.Add("BatchNo");
            dvPickList.Columns.Add("CalculatedCost");
            dvPickList.Columns.Add("ExpDate");
            dvPickList.Columns.Add("AccountName");
            dvPickList.Columns.Add("FullItemName");
            dvPickList.Columns.Add("ManufacturerName");
            dvPickList.Columns.Add("Pack");
            dvPickList.Columns.Add("QtyInSKU");
            dvPickList.Columns.Add("PalletLocation");
            dvPickList.Columns.Add("PalletNo");
            dvPickList.Columns.Add("UnitPrice");
            dvPickList.Columns.Add("LineNum");
            dvPickList.Columns.Add("Unit");
            dvPickList.Columns.Add("WarehouseName");
            dvPickList.Columns.Add("PrintedSTVNumber");
            dvPickList.Columns.Add("PhysicalStoreName");
            dvPickList.Columns.Add("PhysicalStoreTypeName");
            dvPickList.Columns.Add("ActivityConcat");
            dvPickList.Columns.Add("StockCode");


        }
        #endregion

        #region Filter and Selection

        private void lkAccountType_EditValueChanged(object sender, EventArgs e)
        {
            ResetOrder();

            if (lkFromActivity.EditValue == null)
            {
                gridItemChoiceView.ActiveFilterString = "StoreID is Null";
            }
            else if (lkCategoires.EditValue != null && lkCategoires.EditValue.ToString() == "0")
            {
                gridItemChoiceView.ActiveFilterString = String.Format("StoreID = {0}", lkFromActivity.EditValue);
            }
            else
            {
                gridItemChoiceView.ActiveFilterString = String.Format("TypeID = {1} And StoreID = {0}", lkFromActivity.EditValue, lkCategoires.EditValue);
            }
            lkType_EditValueChanged(new object(), new EventArgs());
            FilterAccountType();
        }

        private void lkType_EditValueChanged(object sender, EventArgs e)
        {
           

            TransferTypeID = Convert.ToInt32(lkType.EditValue);
            if (TransferTypeID == 1)
            {
                layoutForFacility.Text = "Hub";
                //layoutFromStore.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutToStore.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutToAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutForFacility.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lkFromStore.Enabled = false;
                //lkToStore.Enabled = false;
                //lkToActivity.Enabled = false;
               // lkFromActivity.Enabled = true;
                lkForHub.Enabled = true;
               
           
                lkForHub.Properties.DataSource = Institution.LoadHubs();
                
                
                lkForHub.Properties.NullText = "Select Hub to Transfer to";
                lkForHub.EditValue = null;
            }
            else if (TransferTypeID == 2)
            {

                layoutForFacility.Text = "For Account";
                layoutFromStore.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutToStore.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutToAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutForFacility.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                lkFromStore.Enabled = true;
                lkToStore.Enabled = true;
                lkToActivity.Enabled = true;
                lkForHub.Enabled = false;

                lkForHub.Properties.DataSource = null;
                if (lkFromActivity.EditValue != null)
                {
                    FilterAccountType();
                }
                lkForHub.EditValue = null;

                lkToActivity.Enabled = true;
            }

            else if (TransferTypeID == 3)
            {
                layoutForFacility.Text = "For Store";
                layoutFromStore.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutToStore.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                //lkToActivity.Enabled = false;
                //layoutForFacility.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                lkFromStore.Enabled = true;
                lkToStore.Enabled = true;
                lkToActivity.Enabled = false;
                lkForHub.Enabled = false;


                lkForHub.Properties.DataSource = null;
                if (lkFromActivity.EditValue != null)
                {
             
                    FilterAccountType();
                }
                lkForHub.EditValue = null;
            }
            ResetOrder();
            BindMainOrderGrid();
            PopulateItemsList();

        }

        private void txtItemName_EditValueChanged(object sender, EventArgs e)
        {
           gridItemChoiceView.ActiveFilterString = String.Format("[FullItemName] Like '{0}%'", txtItemName.Text);

        }

        private void repositoryItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            DataRow dr = gridItemChoiceView.GetFocusedDataRow();
            bool b = (dr["IsSelected"] != DBNull.Value) ? Convert.ToBoolean(dr["IsSelected"]) : false;
            if ( TransferTypeID == 1 && b  && lkFromActivity.EditValue != null && !string.IsNullOrEmpty(lkFromActivity.EditValue.ToString()))
            {
                DataTable dtSelectedItem = Item.GetItemByIdForTransferToHub(Convert.ToInt32(dr["Id"]), Convert.ToInt32(dr["UnitID"]), Convert.ToInt32(lkFromActivity.EditValue));
                foreach (DataRow drSelectedItem in dtSelectedItem.Rows)
                {

                    if (_dvItemTable == null)
                    {
                        BindMainOrderGrid();
                    }
                    _dvItemTable.Table.ImportRow(drSelectedItem);
                    //_dvItemTable.Table.Rows[_dvItemTable.Table.Rows.Count - 1]["ID"] = DBNull.Value;
                    //_dvItemTable.Table.Rows[_dvItemTable.Table.Rows.Count - 1]["ItemID"] = dr["ID"];

                }
                if (dtSelectedItem.Rows.Count == 0)
                {
                    dr["IsSelected"] = false;
                }
            }
            else if (b && lkFromActivity.EditValue != null && lkFromStore.EditValue != null && !string.IsNullOrEmpty(lkFromStore.EditValue.ToString()) && !string.IsNullOrEmpty(lkFromActivity.EditValue.ToString()))
            {
                DataTable dtSelectedItem = Item.GetItemByIdForTransfer(Convert.ToInt32(dr["Id"]), Convert.ToInt32(dr["UnitID"]), Convert.ToInt32(lkFromActivity.EditValue),Convert.ToInt32(lkFromStore.EditValue));
                foreach (DataRow drSelectedItem in dtSelectedItem.Rows)
                {

                    if (_dvItemTable == null)
                    {
                        BindMainOrderGrid();
                    }
                    _dvItemTable.Table.ImportRow(drSelectedItem);
                    //_dvItemTable.Table.Rows[_dvItemTable.Table.Rows.Count - 1]["ID"] = DBNull.Value;
                    //_dvItemTable.Table.Rows[_dvItemTable.Table.Rows.Count - 1]["ItemID"] = dr["ID"];

                }
                if (dtSelectedItem.Rows.Count == 0)
                {
                    dr["IsSelected"] = false;
                }
            }
            else
            {
                for (int i = 0; i < _dvItemTable.Table.Rows.Count; )
                {
                    DataRow drToDelete = _dvItemTable.Table.Rows[i];
                    if (Convert.ToInt32(drToDelete["ItemID"]) == Convert.ToInt32(dr["ID"]) && Convert.ToInt32(drToDelete["UnitID"]) == Convert.ToInt32(dr["UnitID"]) && Convert.ToInt32(drToDelete["StoreID"]) == Convert.ToInt32(dr["StoreID"]))
                        _dvItemTable.Table.Rows.Remove(drToDelete);
                    else
                        i++;
                }
                dr["IsSelected"] = false;
           
           
            }
        }

        private void gridItemChoiceView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow dr = gridItemChoiceView.GetFocusedDataRow();
            bool b = (dr["IsSelected"] != DBNull.Value) ? Convert.ToBoolean(dr["IsSelected"]) : false;
            dr["IsSelected"] = !b;
            repositoryItemCheckEdit1_CheckedChanged(new object(), new EventArgs());
            txtItemName.SelectAll();
            txtItemName.Focus();
        }

        private void FilterAccountType()
        {
            if(TransferTypeID == 3 &&  lkFromActivity.EditValue != null)
            {
                lkToActivity.EditValue = lkFromActivity.EditValue;
                
            }
            if (TransferTypeID == 3 && lkFromStore.EditValue != null)
            {
                DataView filteredDataView = new DataView(lkToStore.Properties.DataSource as DataTable);
                filteredDataView.RowFilter = string.Format("ID <> {0}", Convert.ToInt32(lkFromStore.EditValue));
                
            }
            else if (TransferTypeID == 2 && lkFromActivity.EditValue != null)
            {
                DataView filteredDataView = (DataView)lkToActivity.Properties.DataSource;
            //    filteredDataView.RowFilter = string.Format("ID <> {0}", Convert.ToInt32(lkAccountType.EditValue));
            }
        }

        private void lkCategoires_EditValueChanged(object sender, EventArgs e)
        {
            if (lkFromActivity.EditValue == null)
            {
                gridItemChoiceView.ActiveFilterString = "StoreID is Null";
            }
            else if (lkCategoires.EditValue != null && lkCategoires.EditValue.ToString() == "0")
            {
                gridItemChoiceView.ActiveFilterString = String.Format("StoreID = {0}", lkFromActivity.EditValue);
            }
            else
            {
                gridItemChoiceView.ActiveFilterString = String.Format("TypeID = {1} And StoreID = {0}", lkFromActivity.EditValue, lkCategoires.EditValue);
            }
           }

        #endregion

        #region Save

        private void btnSaveAndForward_Click(object sender, EventArgs e)
        {
            if (ValidateForm() && XtraMessageBox.Show(String.Format("Are you sure,you want to Transfer Items To {0}", TransferTypeID !=2?lkForHub.Text:lkToActivity.Text), "Are you Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                DataView dv = orderGrid.DataSource as DataView;
                
                    if (dv != null && dv.Count != 0)
                    {
                        MyGeneration.dOOdads.TransactionMgr transactionMgr = MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgr();
                                                
                        try
                        {
                             
                            transactionMgr.BeginTransaction();
                            SaveOrder();

                            transactionMgr.CommitTransaction();
                        }
                        catch(Exception exp)
                        {
                            transactionMgr.RollbackTransaction();
                            XtraMessageBox.Show(exp.Message.ToString());
                        }
                        ResetOrder();
                        BindMainOrderGrid();
                    }
                    else
                    {
                        XtraMessageBox.Show("Please select item");
                    }
                
               
            }
        
        }



    

        private bool ValidateForm()
        {
            _gridIsValid = true;

            if (gridOrderView.RowCount == 0)
            {
                XtraMessageBox.Show("You cannot transfer an Empty list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if ( TransferTypeID == 1 && !dxValidation1stTab.Validate())
            {
                XtraMessageBox.Show("Please correct the errors on screen and try again.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (TransferTypeID == 2 && (!dxValidationAccount.Validate() || !dxValidateFromToAccounts.Validate()))
            {
                XtraMessageBox.Show("Please correct the errors on screen and try again.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (TransferTypeID == 3 && !dxValidateFromToStore.Validate())
            {
                XtraMessageBox.Show("Please correct the errors on screen and try again.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            DataView dv = orderGrid.DataSource as DataView;
            foreach (DataRowView dr in dv)
            {

                if (dr["ApprovedPacks"] != DBNull.Value && dr["ApprovedPacks"].ToString() != "")
                {
                    if (Convert.ToDecimal(dr["ApprovedPacks"]) > Convert.ToDecimal(dr["Packs"]))
                    {
                        _gridIsValid = false;
                        DataRow dtr = dr.Row;
                        dtr.SetColumnError("ApprovedPacks", @"Transfer quantity cannot be greater than available stock");
                    }

                    if(Convert.ToDecimal(dr["ApprovedPacks"]) < 0)
                    {
                        _gridIsValid = false;
                        DataRow dtr = dr.Row;
                        dtr.SetColumnError("ApprovedPacks", @"Transfer quantity cannot be less than 0");
                    }
                }
            }

            return _gridIsValid;
        
        }

        #endregion

        #region Generate PickList Detail

        private Order GenerateOrder()
        {
            int transerTypeID = (TransferTypeID == 1) ? OrderType.CONSTANTS.HUB_TO_HUB_TRANSFER : (TransferTypeID == 2) ? OrderType.CONSTANTS.ACCOUNT_TO_ACCOUNT_TRANSFER : OrderType.CONSTANTS.STORE_TO_STORE_TRANSFER;

            int? requestedBy= null;
            if (TransferTypeID == 1)
                requestedBy = Convert.ToInt32(lkForHub.EditValue);
            else if(TransferTypeID == 2)
            {
                var activity = new Activity();
                activity.LoadByPrimaryKey(Convert.ToInt32(lkToActivity.EditValue));
                requestedBy = activity.InstitutionID;

            }
            else 
            {
                var ps = new PhysicalStore();
                ps.LoadByPrimaryKey(Convert.ToInt32(lkToStore.EditValue));
                requestedBy = ps.InstitutionID;

            }
            Order order = Order.GenerateOrder(OrderID, transerTypeID ,BLL.OrderStatus.Constant.PICK_LIST_CONFIRMED,
                      Convert.ToInt32(lkFromActivity.EditValue), PaymentType.Constants.STV,txtContactPerson.Text, requestedBy, CurrentContext.UserId);
            return order;
        }

       

        private int SaveOrder()
        {

            int warehouseID;
            var order = GenerateOrder();
            PickList pickList = PickList.GeneratePickList(order.ID);
            int picklistId = pickList.ID;
            if (TransferTypeID != Transfer.Constants.HUB_TO_HUB)
            {
                warehouseID = GenerateTransfer(order.ID);
            }

            // Log
            this.LogActivity("Transfer", order.ID);

          
            int LineNo = 0;
         
            // This is a kind of initializing the data table.
         
          
            DataView dv = orderGrid.DataSource as DataView;

            foreach (DataRowView r in dv)
            {
                if (r["ApprovedPacks"] != null && r["ApprovedPacks"] != DBNull.Value && r["ApprovedPacks"].ToString()!= "")
                    if (Convert.ToDecimal(r["ApprovedPacks"]) != 0)
                    {
                        LineNo = LineNo + 1;
                        int itemId = Convert.ToInt32(r["ItemID"]);
                        int unitId = Convert.ToInt32(r["UnitID"]);
                        decimal pack = Convert.ToDecimal(r["ApprovedPacks"]);
                        int qtyPerPack = Convert.ToInt32(r["QtyPerPack"]);
                        int activityId = Convert.ToInt32(lkFromActivity.EditValue);
                        int manufacturerId = Convert.ToInt32(Convert.ToInt32(r["ManufacturerID"]));
                        int receivePalletId = Convert.ToInt32(r["ReceivingLocationID"]);
                        int palletLocationId = Convert.ToInt32(r["LocationID"]);
                        double? unitPrice;
                        string batchNumber = r["BatchNo"].ToString();
                        string expireDate ="" ;
                        int receiveDocId = Convert.ToInt32(r["ReceiveDocID"]);
                        if((r["UnitPrice"] != DBNull.Value))
                        {
                            unitPrice = Convert.ToDouble(r["UnitPrice"]);
                        }
                        else
                        {
                            unitPrice = null;
                        }
                       
                        if (r["ExpDate"] != DBNull.Value)
                             expireDate= r["ExpDate"].ToString();

                        OrderDetail ord = OrderDetail.GenerateOrderDetail(unitId, activityId, pack, order.ID, qtyPerPack, itemId);
                        PalletLocation palletLocation = new PalletLocation();
                        palletLocation.LoadByPrimaryKey(palletLocationId);
                        int palletID = palletLocation.PalletID;
                        PickListDetail pkDetail = PickListDetail.GeneratePickListDetail(pack, unitPrice, receiveDocId, manufacturerId, receivePalletId, qtyPerPack, activityId, unitId, itemId, picklistId, palletID, expireDate, batchNumber);
                        ReceivePallet.ReserveQty(pack, receivePalletId);
                        //To Print The Picklist
                        //Then reserve Items
                       

                       Item item = new Item();
                        item.LoadByPrimaryKey(itemId);
                        DataRow drvpl = dvPickList.NewRow();
                        drvpl["FullItemName"] = item.FullItemName;
                        drvpl["StockCode"] = item.StockCode;
                        drvpl["BatchNo"] = batchNumber;
                        if (expireDate != "" )
                            drvpl["ExpDate"] = Convert.ToDateTime(expireDate).ToString("MMM/yyyy");
                        else
                            drvpl["ExpDate"] = DBNull.Value;
                        drvpl["LineNum"] = LineNo + 1;
                        var manufacturer = new Manufacturer();
                        manufacturer.LoadByPrimaryKey(manufacturerId);
                        drvpl["ManufacturerName"] = manufacturer.Name;
                        
                        drvpl["Pack"] = pack;
                        drvpl["UnitPrice"] = unitPrice;
                        var unit = new ItemUnit();
                        unit.LoadByPrimaryKey(unitId);

                        drvpl["Unit"] = unit.Text;

                        drvpl["QtyInSKU"] = pack;
                        if (unitPrice != null)
                             drvpl["CalculatedCost"] = pack *Convert.ToDecimal(unitPrice);
                        
                        
                         palletLocation.LoadByPrimaryKey(pkDetail.PalletLocationID);
                         drvpl["PalletLocation"] = palletLocation.Label;
                         drvpl["WarehouseName"] = palletLocation.WarehouseName;
                        drvpl["PhysicalStoreName"] = palletLocation.PhysicalStoreName;
                        var activity = new Activity();
                        activity.LoadByPrimaryKey(pkDetail.StoreID);
                        drvpl["ActivityConcat"] = activity.FullActivityName;
                        drvpl["AccountName"] = activity.AccountName;
                        dvPickList.Rows.Add(drvpl);
                    }
                
            }
            if (LineNo == 0)
                throw new System.ArgumentException("Please review your list,you haven't approved any Quantity");
            string receivingUnit;
                Transfer transfer = new Transfer();
                transfer.LoadByOrderID(order.ID);
                if (TransferTypeID == Transfer.Constants.ACCOUNT_TO_ACCOUNT)
                {
                    var fromActivity = new Activity();
                    fromActivity.LoadByPrimaryKey(transfer.FromStoreID);
                    var toActivity = new Activity();
                    toActivity.LoadByPrimaryKey(transfer.ToStoreID);

                    receivingUnit = String.Format("Account to Account from {0} to {1}", fromActivity.FullActivityName,
                                                toActivity.FullActivityName);
                }
                else if (TransferTypeID == Transfer.Constants.STORE_TO_STORE)
                {

                    var toStore = new PhysicalStore();

                    toStore.LoadByPrimaryKey(transfer.ToPhysicalStoreID);
                    receivingUnit = string.Format("Store to Store transfer to: {0}", toStore.WarehouseName);
                }
                else
                {
                    receivingUnit = lkForHub.Text;
                }
            var plr = HCMIS.Desktop.Reports.WorkflowReportFactory.CreatePicklistReport(order, receivingUnit,
                                                                                       dvPickList.DefaultView);
            plr.PrintDialog();

                XtraMessageBox.Show("Picklist Prepared!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return order.ID;
        }

        

        
    

        private int GenerateTransfer(int OrderID)
        {
            Transfer transfer = new Transfer();
            transfer.AddNew();
            transfer.OrderID = OrderID;
            transfer.FromStoreID = Convert.ToInt32(lkFromActivity.EditValue);
            transfer.SetColumn("TransferTypeID",TransferTypeID);
            transfer.FromPhysicalStoreID = Convert.ToInt32(lkFromStore.EditValue);
           
            if (TransferTypeID != 1)
            {
                transfer.ToPhysicalStoreID = Convert.ToInt32(lkToStore.EditValue);
                transfer.ToStoreID = Convert.ToInt32(lkToActivity.EditValue);
            }

            transfer.Save();
            var physicalStore = new PhysicalStore();
            physicalStore.LoadByPrimaryKey(transfer.ToPhysicalStoreID);
            return physicalStore.PhysicalStoreTypeID;
        }
        #endregion

        

        private void btnCancelOne_Click(object sender, EventArgs e)
        {
            ResetOrder();
            BindMainOrderGrid();
            PopulateItemsList();
        }

        private void gridOrderView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRow dr = gridOrderView.GetFocusedDataRow();
            if (dr["ApprovedPacks"] != DBNull.Value && dr["ApprovedPacks"].ToString() != "" && Convert.ToDecimal(dr["ApprovedPacks"]) > Convert.ToDecimal(dr["Packs"]))
            {
                dr.SetColumnError("ApprovedPacks", @"Quantity is greater than Available");
            }
            else
            {
                dr.ClearErrors();
            }
        }

        private void lkFromStore_EditValueChanged(object sender, EventArgs e)
        {
            PopulateItemsListByPhysicalStore();   FilterAccountType();
        }

        private void gridItemsChoice_Click(object sender, EventArgs e)
        {

        }
    }
}