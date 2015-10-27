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
using HCMIS.Helpers;
using HCMIS.Desktop.ViewHelpers;

namespace HCMIS.Desktop.Forms.WorkFlow
{
    [FormIdentifier("TR-CO-CO-FR", "Custom Issue Order", "Transfer")]
    public partial class HubToHubTransfer : DevExpress.XtraEditors.XtraForm
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

        public HubToHubTransfer()
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
          
            lkFromStore.Properties.DataSource = BLL.PhysicalStore.GetAllActive();
            //lkFromStore.EditValue = 1;
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

      
        private void PopulateItemsList()
        {
            if (lkAccountType.EditValue == null || lkAccountType.EditValue.ToString() == "")
            {
                return;
            }
            int category = 0;
            //if (TransferTypeID == 2)
            //{
            //    //if (lkForHub.EditValue != null && lkAccountType.EditValue != null)
            //    //    gridItemsChoice.DataSource = Items.GetItemsByCommodityTypeForTransferToAccount(Convert.ToInt32(lkAccountType.EditValue), Convert.ToInt32(lkForHub.EditValue));
            //    //else
            //    //    gridItemsChoice.DataSource = null;
            //}
            //else
                gridItemsChoice.DataSource = Item.GetItemsByCommodityTypeForTransferToHub(category, Convert.ToInt32(lkAccountType.EditValue));
        }

        private void BindFormElements()
        {
            // Find the next order number and write it on the order ID Field
            // The order ID is generated here in code

            DataTable tbl = BLL.CommodityType.GetAllTypes();
            tbl.Rows.Add(0, "All");
            lkCategoires.Properties.DataSource = tbl;

            lkCategoires.EditValue = 0;
            lkAccountType.SetupActivityEditor().SetDefaultActivity();

            LoadReceivingUnits();
            BindMainOrderGrid();
            boxSizedList.DataSource = BLL.ItemManufacturer.PackageLevelKeys;
        }

        private void LoadReceivingUnits()
        {
            
                Institution rUnit = new Institution();
                rUnit.LoadAll();
                lkForHub.Properties.DataSource = rUnit.DefaultView;
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
                // disable the buttons
                //btnCancelOne.Enabled = false;
                //btnSaveAndForward.Enabled = false;

            }
            else
            {
                // enable the buttons
                if (BLL.Settings.UseNewUserManagement)
                {
                    btnSaveAndForward.Enabled = this.HasPermission("Save-And-Print");
                    btnCancelOne.Enabled = this.HasPermission("Cancel");
                }else{
                    btnCancelOne.Enabled = true;
                    btnSaveAndForward.Enabled = true;
                }
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

            if (lkAccountType.EditValue == null)
            {
                gridItemChoiceView.ActiveFilterString = "StoreID is Null";
            }
            else if (lkCategoires.EditValue != null && lkCategoires.EditValue.ToString() == "0")
            {
                gridItemChoiceView.ActiveFilterString = String.Format("StoreID = {0}", lkAccountType.EditValue);
            }
            else
            {
                gridItemChoiceView.ActiveFilterString = String.Format("TypeID = {1} And StoreID = {0}", lkAccountType.EditValue, lkCategoires.EditValue);
            }
            lkType_EditValueChanged(new object(), new EventArgs());
            FilterAccountType();
        }

        private void lkType_EditValueChanged(object sender, EventArgs e)
        {
            if (lkAccountType.EditValue == null || lkAccountType.EditValue.ToString() == "")
            {
                return;
            }

            layoutForFacility.Text = "For Hub";
            layoutFromStore.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            
            Institution rUnits = new Institution();
            rUnits.LoadAll();
            lkForHub.Properties.DataSource = rUnits.DefaultView;
            
            lkForHub.Properties.NullText = "Select Hub to Transfer to";
            lkForHub.EditValue = null;
           
            ResetOrder();
            BindMainOrderGrid();
            PopulateItemsList();

        }

        private void lkForHub_EditValueChanged(object sender, EventArgs e)
        {
            //            PopulateItemsList();
        }

        private void txtItemName_EditValueChanged(object sender, EventArgs e)
        {
            // done when items are filtered.
            gridItemChoiceView.ActiveFilterString = String.Format("[FullItemName] Like '{0}%'", txtItemName.Text);

        }

        private void repositoryItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            DataRow dr = gridItemChoiceView.GetFocusedDataRow();
            bool b = (dr["IsSelected"] != DBNull.Value) ? Convert.ToBoolean(dr["IsSelected"]) : false;

            if (b && lkAccountType.EditValue !=null && !string.IsNullOrEmpty(lkAccountType.EditValue.ToString()))
            {
                DataTable dtSelectedItem = Item.GetItemByIdForCustomIssue(Convert.ToInt32(dr["Id"]), Convert.ToInt32(dr["UnitID"]), Convert.ToInt32(lkAccountType.EditValue));
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

        private void repositoryItemPacks_EditValueChanged(object sender, EventArgs e)
        {



        }

        private void FilterAccountType()
        {
            if (TransferTypeID == 3 && lkFromStore.EditValue != null)
            {
                DataView filteredDataView = new DataView(lkForHub.Properties.DataSource as DataTable);
                filteredDataView.RowFilter = string.Format("ID <> {0}", Convert.ToInt32(lkFromStore.EditValue));
            }
            else if (TransferTypeID == 2 && lkAccountType.EditValue != null)
            {
                DataView filteredDataView = (DataView)lkForHub.Properties.DataSource;
                filteredDataView.RowFilter = string.Format("ID <> {0}", Convert.ToInt32(lkAccountType.EditValue));
            }
        }

        private void lkCategoires_EditValueChanged(object sender, EventArgs e)
        {
            if (lkAccountType.EditValue == null)
            {
                gridItemChoiceView.ActiveFilterString = "StoreID is Null";
            }
            else if (lkCategoires.EditValue != null && lkCategoires.EditValue.ToString() == "0")
            {
                gridItemChoiceView.ActiveFilterString = String.Format("StoreID = {0}", lkAccountType.EditValue);
            }
            else
            {
                gridItemChoiceView.ActiveFilterString = String.Format("TypeID = {1} And StoreID = {0}", lkAccountType.EditValue, lkCategoires.EditValue);
            }
           }

        #endregion

        #region Save

        private void btnSaveAndForward_Click(object sender, EventArgs e)
        {
            if (ValidateForm() && XtraMessageBox.Show(String.Format("Are you sure,you want to Transfer Items To {0}", lkForHub.Text), "Are you Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                DataView dv = orderGrid.DataSource as DataView;
                if (dxValidation1stTab.Validate())
                {
                    if (dv != null && Convert.ToInt32(lkForHub.EditValue) != -1 && dv.Count != 0)
                    {
                        MyGeneration.dOOdads.TransactionMgr transactionMgr = MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgr();
                                                
                        try
                        {
                            transactionMgr.BeginTransaction();
                            SaveOrder();
                            ResetOrder();
                            BindMainOrderGrid();
                            transactionMgr.CommitTransaction();
                        }
                        catch(Exception exp)
                        {
                            transactionMgr.RollbackTransaction();
                            XtraMessageBox.Show(exp.Message.ToString());
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Please select item");
                    }
                }
                else
                {
                    XtraMessageBox.Show("Please change invalid value ");
                }
            }
        }




        private bool ValidateForm()
        {
            _gridIsValid = true;

            if (gridOrderView.RowCount == 0)
            {
                XtraMessageBox.Show("You cannot save an Empty list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!dxValidation1stTab.Validate())
            {
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
                        dtr.SetColumnError("ApprovedPacks", @"Quantity is greater than Available");
                    }
                }
            }

            return _gridIsValid;
        }

        #region Generate PickList Detail

        private Order GenerateOrder()
        {
            var or = new Order();
            if (OrderID == null)
                or.AddNew();
            else
                or.LoadByPrimaryKey(OrderID.Value);

            or.RefNo = Order.GetNextOrderReference();
            txtRefNo.Text = or.RefNo;

            var oldOrderStatus = or.IsColumnNull("OrderStatusID") ? (int?)null : or.OrderStatusID;
            or.OrderStatusID = OrderStatus.Constant.PICK_LIST_GENERATED;
            //or.Remark = txtRemark.Text;

            or.EurDate = or.Date = DateTimeHelper.ServerDateTime; //Both fields are assigned dates.
            if (TransferTypeID == 1)
                or.RequestedBy = Convert.ToInt32(lkForHub.EditValue);

            or.FilledBy = CurrentContext.UserId;

            or.ContactPerson = txtContactPerson.Text;
            var activity = new Activity();
            activity.LoadByPrimaryKey(Convert.ToInt32(lkAccountType.EditValue));

            or.FromStore = activity.ModeID;
           
            if (BLL.Settings.IsCenter)
            { 
                //What the Hell is this?
                or.PaymentTypeID = PaymentType.Constants.STV;
            }
            else
            {
                or.PaymentTypeID = PaymentType.Constants.STV;
            }
            or.FiscalYearID = FiscalYear.Current.ID;
            or.Save();
            or.LogRequisitionStatus(or.ID, oldOrderStatus, OrderStatus.Constant.PICK_LIST_GENERATED,CurrentContext.UserId);
            return or;
        }

        private void SaveOrder()
        {
            var order = GenerateOrder();
            var picklist = PickList.GeneratePickList(order.ID);
           
            int lineNo = 0;
         
            // This is a kind of initializing the data table.
            OrderDetail ord = new OrderDetail();
            PickListDetail pkDetail = new PickListDetail();
            DataView dv = orderGrid.DataSource as DataView;

            foreach (DataRowView r in dv)
            {
                if (r["ApprovedPacks"] != null && r["ApprovedPacks"] != DBNull.Value && r["ApprovedPacks"].ToString()!= "")
                    if (Convert.ToInt32(r["ApprovedPacks"]) != 0)
                    {
                        lineNo = lineNo + 1;
                        int itemID = Convert.ToInt32(r["ItemID"]);
                        int unitID = Convert.ToInt32(r["UnitID"]);
                        ord.AddNew();
                        ord.OrderID = order.ID;
                        ord.ItemID = itemID;
                        if (r["ApprovedPacks"] != DBNull.Value)
                        {
                            ord.Pack = Convert.ToInt32(r["ApprovedPacks"]);
                        }
                        if (r["QtyPerPack"] != DBNull.Value)
                        {
                            ord.QtyPerPack = Convert.ToInt32(r["QtyPerPack"]);
                        }
                        ord.Quantity = Convert.ToInt32(r["ApprovedPacks"]) * Convert.ToInt32(r["QtyPerPack"]);
                        ord.ApprovedQuantity = Convert.ToInt32(r["ApprovedPacks"]) * Convert.ToInt32(r["QtyPerPack"]);
                        ord.UnitID = unitID;
                        ord.StoreID = Convert.ToInt32(lkAccountType.EditValue);


                        ord.Save();
                        pkDetail.AddNew();
                        pkDetail.PickListID = picklist.ID;
                        pkDetail.ItemID = itemID;
                        pkDetail.PalletLocationID = Convert.ToInt32(r["LocationID"]);
                        pkDetail.BatchNumber = r["BatchNo"].ToString();
                        if (r["ExpDate"] != DBNull.Value)
                            pkDetail.ExpireDate = DateTime.Parse(r["ExpDate"].ToString());

                        pkDetail.StoreID = Convert.ToInt32(r["StoreID"]);
                        pkDetail.UnitID = unitID;
                        pkDetail.ReceiveDocID = Convert.ToInt32(r["ReceiveDocID"]);
                        if (r["UnitPrice"] != DBNull.Value)
                        {
                            pkDetail.Cost = Convert.ToInt32(r["ApprovedPacks"]) * Convert.ToDouble(r["UnitPrice"]);
                            pkDetail.UnitPrice = Convert.ToDouble(r["UnitPrice"]);
                        }
                        pkDetail.Packs = Convert.ToInt32(r["ApprovedPacks"]);
                        pkDetail.QtyPerPack = Convert.ToInt32(r["QtyPerPack"]);
                        pkDetail.QuantityInBU = Convert.ToInt32(r["ApprovedPacks"]) * Convert.ToInt32(r["QtyPerPack"]);
                        pkDetail.StoreID = Convert.ToInt32(r["StoreID"]);
                        pkDetail.ReceivePalletID = Convert.ToInt32(r["ReceivingLocationID"]);
                        pkDetail.ManufacturerID = Convert.ToInt32(r["ManufacturerID"]);
                        pkDetail.BoxLevel = 0;
                        pkDetail.DeliveryNote = true;
                        pkDetail.Save();
                        //To Print The Picklist
                      //Then reserve Items
                        ReceivePallet receivepallet = new ReceivePallet();
                        receivepallet.LoadByPrimaryKey(Convert.ToInt32(r["ReceivingLocationID"]));
                        receivepallet.ReservedStock = receivepallet.ReservedStock + Convert.ToInt32(r["ApprovedPacks"]);
                        receivepallet.Save();
                       

                        DataRow drvpl = dvPickList.NewRow();
                        drvpl["FullItemName"] = r["FullItemName"];
                        drvpl["StockCode"] = r["StockCode"];
                        drvpl["BatchNo"] = r["BatchNo"];
                        if (r["ExpDate"] != DBNull.Value)
                            drvpl["ExpDate"] = Convert.ToDateTime(r["ExpDate"]).ToString("MMM/yyyy");
                        else
                            drvpl["ExpDate"] = DBNull.Value;
                        drvpl["LineNum"] = lineNo + 1;
                        drvpl["ManufacturerName"] = r["Manufacturer"];
                        drvpl["Pack"] = r["ApprovedPacks"];
                        drvpl["UnitPrice"] = r["UnitPrice"];
                        
                        drvpl["Unit"] = r["Unit"];
                        drvpl["PalletLocation"] = r["Location"];
                        drvpl["QtyInSKU"] = Convert.ToInt32(r["ApprovedPacks"]);
                        if (r["UnitPrice"] != DBNull.Value)
                        drvpl["CalculatedCost"] = Convert.ToInt32(r["ApprovedPacks"]) * Convert.ToDouble(r["UnitPrice"]);

                        PalletLocation palletLocation = new PalletLocation();
                        palletLocation.LoadByPrimaryKey(pkDetail.PalletLocationID);
                        drvpl["WarehouseName"] = palletLocation.WarehouseName;
                        drvpl["PhysicalStoreName"] = palletLocation.PhysicalStoreName;
                        var activity = new Activity();
                        activity.LoadByPrimaryKey(pkDetail.StoreID);
                        drvpl["ActivityConcat"] = activity.FullActivityName;
                        drvpl["AccountName"] = activity.AccountName;
                        dvPickList.Rows.Add(drvpl);
                        
                       
                    }
                
            }
            if (lineNo == 0)
                throw new System.ArgumentException("Please review your list,you haven't approved any Quantity");
            
            var plr = HCMIS.Desktop.Reports.WorkflowReportFactory.CreatePicklistReport(order, lkForHub.Text,
                                                                                       dvPickList.DefaultView);
           

            plr.PrintDialog();

            if (!BLL.Settings.IsCenter)
            {
                if (TransferTypeID == 3)
                {

                    XtraMessageBox.Show("Your Store To Store Transfer will be Printed now", "Store To Store Transfer");
                    Transfer.Move(picklist.ID);
                    HCMIS.Desktop.Reports.StoreTransferPrintOut STM =
                        new HCMIS.Desktop.Reports.StoreTransferPrintOut();
                    STM.LoadByPickListID(picklist.ID);
                    STM.PrintDialog();

                }
                else if (TransferTypeID == 2)
                {
                    XtraMessageBox.Show(ReceiveDoc.ReceiveFromAccountTransfer(picklist.ID,
                                                                              Convert.ToInt32(lkForHub.EditValue),
                                                                              CurrentContext.LoggedInUserName,
                                                                              CurrentContext.UserId));
                }
            }
            else
            {
                XtraMessageBox.Show("Picklist Prepared!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private int GeneratePickList(int OrderID)
        {
            PickList pklist = new PickList();
            pklist.AddNew();
            pklist.OrderID = OrderID;
            pklist.PickType = "Pick";
            pklist.IssuedDate = DateTimeHelper.ServerDateTime;
            pklist.IsConfirmed = true;
            pklist.SavedDate = DateTimeHelper.ServerDateTime;
            pklist.PickedDate = DateTimeHelper.ServerDateTime;
            pklist.IsWarehouseConfirmed = 0;
            pklist.Save();
            return pklist.ID;
        }

        private void GenerateTransfer(int OrderID)
        {

            Transfer transfer = new Transfer();
            transfer.AddNew();
            transfer.OrderID = OrderID;
            transfer.FromStoreID = Convert.ToInt32(lkAccountType.EditValue);
            transfer.SetColumn("TransferTypeID",TransferTypeID);
            transfer.FromPhysicalStoreID = Convert.ToInt32(lkFromStore.EditValue);
           
            if (TransferTypeID == 2)
            {
                transfer.ToStoreID = Convert.ToInt32(lkForHub.EditValue);
            }
            else if (TransferTypeID == 3)
            {
                transfer.ToStoreID = Convert.ToInt32(lkAccountType.EditValue);
                transfer.ToPhysicalStoreID = Convert.ToInt32(lkForHub.EditValue);
            }

            transfer.Save();
        }
        #endregion

        private void orderGrid_Click(object sender, EventArgs e)
        {

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
    }
}