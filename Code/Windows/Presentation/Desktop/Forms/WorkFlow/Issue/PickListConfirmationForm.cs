using System;
using System.Data;
using System.Windows.Forms;
using BLL;
using CalendarLib;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using HCMIS.Desktop.Helpers;
using HCMIS.Desktop.ViewHelpers;
using HCMIS.Helpers;
using HCMIS.Desktop.Reports;
using Order = BLL.Order;
using System.Collections.Generic;
using PickList = BLL.PickList;

namespace HCMIS.Desktop.Forms.WorkFlow
{

    [FormIdentifier("AP-FI-AI-CN", "Confirm Issue Order", "Pick List Form")]
    public partial class PickListConfirmationForm : XtraForm
    {
        #region Member Variables
        // for proposed pick list
        DataView _dvPickListMakeup = null;

        // selected order ID, used on pick list and pick list confirmation screen only.
        int _orderID = 0;
        BLL.Order order = new BLL.Order();
        DateTimePickerEx dtDate = new DateTimePickerEx();
        int _pickListMode;

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_mode">1-Pick list review mode, 2 - Pick list confirmation mode</param>
        public PickListConfirmationForm()
        {
            InitializeComponent();
            _pickListMode = 2;
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            SetPermissions();
            BindApprovedOrders();
            if (_pickListMode == 2)
            {
                btnPrintAndSavePickList.Text = @"Confirm";
            }
            CheckPicklistExpiry();
        }

        private void CheckPicklistExpiry()
        {
            if (BLL.Settings.NoOfDaysPicklistStaysAfterPrinting > 0)
            {
                var expiredPicklists = BLL.PickList.TotalExpiredPicklists();
                if(expiredPicklists==0)
                {
                    return;
                }
                if (!BLL.Settings.AutoCancelExpiredPicklists) //Require user input.
                {
                    var message =
                        string.Format(
                            "There are {0} expired picklists (that have been reserved for more than {1} days.  Would you like to cancel them?",
                            expiredPicklists, BLL.Settings.NoOfDaysPicklistStaysAfterPrinting);
                    var cancellationConfirmation = XtraMessageBox.Show(message, "Cancel Expired Picklists",
                                                                       MessageBoxButtons.YesNo,
                                                                       MessageBoxIcon.Question);

                    if (cancellationConfirmation == DialogResult.Yes)
                    {
                        try
                        {
                            BLL.PickList.CancelExpiredPicklists();
                        }
                        catch (Exception exp)
                        {
                            XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "Error : "+ exp.Message , "Error : ", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                            throw;
                        }
                    }
                }
                else //Do it without user knowledge.
                {
                    BLL.PickList.CancelExpiredPicklists();
                }
            }
        }

        private void SetPermissions()
        {
            if (BLL.Settings.UseNewUserManagement)
            {
                btnCancelPickList.Enabled = this.HasPermission("Cancel-Pick-List");
                btnPrintAndSavePickList.Enabled = this.HasPermission("Print-And-Save");
                btnReturnToApprovalStep.Enabled = this.HasPermission("Return-To-Approval");
            }
        }

        private void BindApprovedOrders()
        {
            lkStoreType.SetupModeEditor().SetDefaultMode();
            lkStoreType_EditValueChanged(null,null);
        }

        #region Pick List Generation

        private void OnApprovedOrderRowClicked(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e != null && e.RowHandle < -1)
                return;

            var gv = (GridView)sender;
            var dr = gv.GetFocusedDataRow();
            _orderID = Convert.ToInt32(dr["ID"].ToString());

            order.LoadByPrimaryKey(_orderID);
            // populate the general order variables
            txtPickListFromStore.Text = order.GetFromStore();
            lblMode.Text = order.GetFromStore() ?? "-"; 

            txtPickListRequestedBy.Text = order.GetRequestedBy();
            labelControl9.Text = order.GetRequestedBy() ?? "-"; 

            var us = new BLL.User();

            us.LoadByPrimaryKey(order.FilledBy);
            lblFilledBy.Text = us.FullName ?? "-"; 
            string s = "";

            lblLetterNum.Text = String.IsNullOrEmpty(order.LetterNo) ? "-" : order.LetterNo;
            
            var orderDetail = new OrderDetail();
            orderDetail.LoadAllByOrderID(order.ID);

            var paymentType = new BLL.PaymentType();
            paymentType.LoadByPrimaryKey(order.PaymentTypeID);

            if (!orderDetail.IsColumnNull("StoreID"))
            {
                var activity = new Activity();
                activity.LoadByPrimaryKey(orderDetail.StoreID);
                lblMode.Text = activity.ModeName ?? "-"; 
            }

            lblIssueStatus.Text = (string)dr["OrderStatus"] ?? "-";
            lblIssueType.Text = (string)dr["Description"] ?? "-"; 

            if (!order.IsColumnNull("RequestedBy"))
            {
                var ins = new Institution();
                ins.LoadByPrimaryKey(order.RequestedBy);

                var ownership = new BLL.OwnershipType();
                ownership.LoadByPrimaryKey(ins.Ownership);

                int length = ins.Name.Length;
                HeaderSection.Text = ins.Name + s.PadRight(150 - length) + "Order Number: " + order.RefNo;
                lblOwnership.Text = ownership.Name ?? "-";
                lblZone.Text = ins.ZoneName ?? "-";
                lblWoreda.Text = ins.WoredaName ?? "-";
                lblRegion.Text = ins.RegionName ?? "-";
                lblInstitutionType.Text = ins.InstitutionTypeName ?? "-"; 
            }
            else
            {
                HeaderSection.Text =lblOwnership.Text = lblZone.Text =lblWoreda.Text =lblRegion.Text = lblInstitutionType.Text = "-";
            }
            
        
            lblPaymentType.Text = paymentType.Name;
            lblOrderDate.Text = order.Date.ToShortDateString();
            
            txtPickListOrderNumber.Text = order.RefNo;
            labelControl12.Text = order.RefNo;

            txtPickListApprovedBy.Text = order.GetApprovedBy();
            labelControl13.Text = order.GetApprovedBy();

            if (order.OrderStatusID == OrderStatus.Constant.PICK_LIST_GENERATED)
            {
                PickList pl = new PickList();
                gridPickListDetail.DataSource = pl.GetPickListDetailsForOrder(_orderID);
               
                btnPrintAndSavePickList.Text = @"Confirm";
                colPrice.FieldName = "Cost";
                colSKU.FieldName = "Packs";
                btnCancelPickList.Enabled = (BLL.Settings.UseNewUserManagement)? this.HasPermission("Cancel-Pick-List"):true;

                pl.LoadByOrderID(_orderID);
                if (!pl.IsColumnNull("PickedBy"))
                {
                    us.LoadByPrimaryKey(pl.PickedBy);
                    lblPicklistPrintedBy.Text = us.FullName;
                }
                else lblPicklistPrintedBy.Text = "-";

                lblPicklistPrintedDate.Text = !pl.IsColumnNull("SavedDate") ? pl.SavedDate.ToShortDateString() : "-";
                lblPicklistNo.Text = !pl.IsColumnNull("PrintedID") ? pl.PrintedID.ToString() : "-";

            }
            //gridPickListView.EndSummaryUpdate();

        }

        private void bgWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                int orderID = Convert.ToInt32(e.Argument);
                Order or = new Order();
                _dvPickListMakeup = or.GetPalletLocationChoice(CurrentContext.UserId, orderID, bgWorker);
                _dvPickListMakeup.Sort = "StorageTypeID, ShelfID, Column, Row";
                // dvPickListMakeup = dvPickListMakeup.Table.DefaultView;
                List<DataView> list = new List<DataView>();
                list.Add(_dvPickListMakeup);
                list.Add(or._replenishmentList.DefaultView);
                e.Result = list;
            }
            catch(Exception exception)
            {
                XtraMessageBox.Show(exception.Message);
                throw exception;
            }
        }

        private void bgWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBarControl.EditValue = e.ProgressPercentage;
        }

        private void bgWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            // get the results of the pick list from the other thread that calculated it,
            List<DataView> list = (List<DataView>)e.Result;
            _dvPickListMakeup = list[0];
            DataView replenismentView = list[1];
            int i = 1;
            foreach (DataRowView drv in _dvPickListMakeup)
            {
                drv["LineNum"] = i++;
            }
            if (replenismentView.Count > 0)
            {
                string str = "";
                Item itm = new Item();
                Activity stor = new Activity();
                foreach (DataRowView dr in replenismentView)
                {
                    itm.GetItemById(Convert.ToInt32(dr["ItemID"]));
                    stor.LoadByPrimaryKey(Convert.ToInt32(dr["StoreID"]));
                    str += string.Format("\n{0} in {1}", itm.FullItemName, stor.Name);
                }

                XtraMessageBox.Show(
                    String.Format(
                        "Please replenish the corresponding pick faces for the following Items before processing this pick list. \n{0}",
                        str), "Replenish Pick Face", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnPrintAndSavePickList.Enabled = false;

                // Adjust the columns that had to change to show old Items

            }
            else
            {
                btnPrintAndSavePickList.Enabled = true;
            }
            colPrice.FieldName = "CalculatedCost";
            colSKU.FieldName = "QtyInSKU";

            btnCancelPickList.Enabled = true;
            btnPrintAndSavePickList.Text = @"Print Save";
            gridPickListDetail.DataSource = _dvPickListMakeup;

            progressBarControl.Visible = false;
            this.Enabled = true;
        }

        private void PrintPicklistItems(object sender, EventArgs e)
        {
            BLL.Order ord = new BLL.Order();
            ord.LoadByPrimaryKey(_orderID);
            BLL.Institution rus = new Institution();
            rus.LoadByPrimaryKey(ord.RequestedBy);
            XtraReport pickList;
            pickList = WorkflowReportFactory.CreatePicklistReport(ord, rus.Name,_dvPickListMakeup);
            pickList.ShowPreviewDialog();
        }

        private void SavePickListItems(object sender, EventArgs e)
        {

            BLL.Order ord = new BLL.Order();
            BLL.Institution rus = new Institution();
            ord.LoadByPrimaryKey(_orderID);

            if (_dvPickListMakeup != null)
            {
                if (ValidatePickList()) return;
            }

            // if the pick list has already been printed ... go ahead and pass it to the next level
            if (ord.OrderStatusID == OrderStatus.Constant.PICK_LIST_GENERATED)
            {
                OrderDetail oDetail = new OrderDetail();
                oDetail.Where.OrderID.Value = ord.ID;
                oDetail.Query.Load();

                ord.ChangeStatus(OrderStatus.Constant.PICK_LIST_CONFIRMED,CurrentContext.UserId);
                this.LogActivity("Confirm-Pick-List", ord.ID);
                BindApprovedOrders();
                gridPickListDetail.DataSource = null;
                XtraMessageBox.Show("The Pick List has been Confirmed", "Confirmation", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                return;
            }

            
        }

        private bool ValidatePickList()
        {
            foreach (DataRowView drv in _dvPickListMakeup)
            {
                int itemID = Convert.ToInt32(drv["ItemID"]);
                int storeID = Convert.ToInt32(drv["StoreID"]);
                int unitID = Convert.ToInt32(drv["UnitID"]);
                int manufacturerID = Convert.ToInt32(drv["ManufacturerID"]);

                ReceiveDoc rd = new ReceiveDoc();

                if (BLL.Settings.BlockWhenExpectingPriceChange && BLL.ReceiveDoc.DoesPriceNeedToBeChanged(storeID, itemID, unitID, manufacturerID) )
                {
                    OrderDetail odetail = new OrderDetail();
                    odetail.Where.ItemID.Value = itemID;
                    odetail.Where.OrderID.Value = _orderID;
                    odetail.Query.Load();
                    if (odetail.RowCount > 0)
                    {
                        if (odetail.ApprovedQuantity == 0)
                            continue;
                    }

                    Item itm = new Item();
                    itm.LoadByPrimaryKey(itemID);
                    XtraMessageBox.Show(
                        string.Format("The item {0} cannot be issued because it is waiting for price change.", itm.FullItemName),
                        "Price Pending", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
            }
            return false;
        }

        #endregion

        private void btnCancelPickList_Click(object sender, EventArgs e)
        {
            DataRow dr = gridUnconfirmedView.GetFocusedDataRow();
            if (dr != null)
            {
                if (DialogResult.Yes == XtraMessageBox.Show(String.Format("Are you sure you want to cancel the Request: {0}?", dr["RefNo"]), "Confirm Cancelation!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    int ordID = Convert.ToInt32(dr["ID"]);
                    var result = BLL.PickList.ReleaseReservation(ordID, false);
                    if(result)
                    {
                        this.LogActivity("Cancel-Pick-List", ordID);
                        BindApprovedOrders();
                        XtraMessageBox.Show("Issue Order List canceled", "Confirmation", MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                    }
                    gridPickListDetail.DataSource = null;
                }
            }
        }

        

        private void btnReturnToApprovalStep_Click(object sender, EventArgs e)
        {
            //int ordId = Convert.ToInt32(gridApprovedOrdersView.GetFocusedDataRow()["ID"].ToString());

            Order ord = new Order();
            ord.LoadByPrimaryKey(_orderID);
            if (ord.RowCount == 0)
            {
                XtraMessageBox.Show("You have to select an Order to return to approval, ", "Error - Select Order");
                return;
            }
            if(!ord.IsColumnNull("OrderTypeID") && ord.OrderTypeID != OrderType.CONSTANTS.STANDARD_ORDER)
            {
                XtraMessageBox.Show("You cannot return this order to approval, you can either cancel or confirm this order", "Error - You cannot return this order");
                return;
            }

            MyGeneration.dOOdads.TransactionMgr transaction =  MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgr();
            
            try
            {
                transaction.BeginTransaction();
              
                if (ord.RowCount > 0 && ord.OrderStatusID == OrderStatus.Constant.ORDER_APPROVED)
                {
                    ord.ChangeStatus(OrderStatus.Constant.ORDER_FILLED,CurrentContext.UserId);
                    BindApprovedOrders();
                }
                else if (ord.RowCount > 0 && ord.OrderStatusID == OrderStatus.Constant.PICK_LIST_GENERATED)
                {
                    ord.ReleaseReservation();
                    ord.ChangeStatus(OrderStatus.Constant.ORDER_FILLED,CurrentContext.UserId);
                    BindApprovedOrders();
                }
                transaction.CommitTransaction();
            }
            catch(Exception exp)
            {
                transaction.RollbackTransaction();
                throw exp;
            }
            gridPickListDetail.DataSource = null;
            //HCMISLoader.MarkAsDirtyUsingOrderID(_orderID, NewMainWindow.UserId, true);
            if (BLL.Settings.IsCenter)
            {
                XtraMessageBox.Show("The Issue Order List has been returned to approval stage", "Confirmation",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.Show("The Pick list has been returned to approval stage", "Confirmation",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtFacilityNameFilter_EditValueChanged(object sender, EventArgs e)
        {
            gridUnconfirmedView.ActiveFilterString = String.Format("RequestedBy LIKE '{0}%' or [RefNo] like '{0}%'", txtFacilityNameFilter.Text);
        }

        private void lkStoreType_EditValueChanged(object sender, EventArgs e)
        {
            BLL.Order ord = new BLL.Order();
            //Get orders which have a pick list generated
            gridUnConfirmed.DataSource = ord.GetUnconfirmedPickLists(CurrentContext.UserId,Convert.ToInt32(lkStoreType.EditValue));
            gridUnconfirmedView.ExpandAllGroups();

            if (gridUnConfirmed.DataSource != null && ((DataView)gridUnConfirmed.DataSource).Count > 0)
            {
                gridUnconfirmedView.FocusedRowHandle = 0;
                OnApprovedOrderRowClicked(gridUnconfirmedView, null);
            }
        }

        private void gridPickListDetail_Click(object sender, EventArgs e)
        {

        }

        private void gridUnConfirmed_Click(object sender, EventArgs e)
        {

        }
    }
}