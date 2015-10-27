using System;
using System.Data;
using System.Windows.Forms;
using BLL;
using CalendarLib;
using DAL;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Order = BLL.Order;
using HCMIS.Desktop.Helpers;
using System.Collections.Generic;
using DevExpress.Utils;

namespace HCMIS.Desktop.Forms.WorkFlow
{
    public partial class BatchSelection : XtraForm
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
        public BatchSelection()
        {
            InitializeComponent();
            _pickListMode = 1;
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            BindApprovedOrders();
            if (_pickListMode == 1)
            {
                lcUnconfirmedPicklists.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                if (BLL.Settings.IsCenter)
                {
                    btnPrintAndSavePickList.Text = @"Print Issue Order List and Forward";
                }else
                {
                    btnPrintAndSavePickList.Text = @"Print Pick list and Forward";
                }
                
            }
            //else if (_pickListMode == 2)
            //{
            //    lcReviewPickList.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //    btnPrintAndSavePickList.Text = @"Confirm";
            //}
        }

        private void BindApprovedOrders()
        {
            BLL.Order ord = new BLL.Order();
            //Get orders which have a pick list generated
            
            // get orders that are yet to be pick listed
            gridApprovedOrders.DataSource = ord.GetAllApprovedOrdersInPhyiscalStore(CurrentContext.UserId);
            gridApprovedOrdersView.ExpandAllGroups();
        }

        #region Pick List Generation

        private void OnApprovedOrderRowClicked(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            GridView gv = (GridView)sender;
            BLL.Order or = new BLL.Order();
            _orderID = Convert.ToInt32(gv.GetFocusedDataRow()["ID"].ToString());

            order.LoadByPrimaryKey(_orderID);
            // populate the general order variables
            txtPickListFromStore.Text = order.GetFromStore();
            txtPickListRequestedBy.Text = order.GetRequestedBy();
            txtPickListOrderNumber.Text = order.RefNo;
            txtPickListApprovedBy.Text = order.GetApprovedBy();

            if (order.OrderStatusID == OrderStatus.Constant.ORDER_APPROVED)
            {
                progressBarControl.Properties.Maximum = order.CountOfDetailItems();
                progressBarControl.Properties.DisplayFormat.FormatString = "{0: #,##0}" + string.Format(" of {0}", progressBarControl.Properties.Maximum);
                progressBarControl.Properties.DisplayFormat.FormatType = FormatType.Custom;
                progressBarControl.EditValue = 0;
                this.Enabled = false;
                progressBarControl.Visible = true;
                bgWorker.RunWorkerAsync(_orderID);
            }
            
        }

        private void bgWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            int orderID = Convert.ToInt32(e.Argument);
            Order or = new Order();
            _dvPickListMakeup = or.GetBatchConfirmationChoice(orderID, CurrentContext.UserId, bgWorker);
            _dvPickListMakeup.Sort = "StorageTypeID, ShelfID, Column, Row";
            // dvPickListMakeup = dvPickListMakeup.Table.DefaultView;
            List<DataView> list = new List<DataView>();
            list.Add(_dvPickListMakeup);
            list.Add(or._replenishmentList.DefaultView);
            e.Result = list;
            
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

            var ord = new BLL.Order();
            ord.LoadByPrimaryKey(_orderID);
            
            var rus = new Institution();
            rus.LoadByPrimaryKey(ord.RequestedBy);
            
            var pl = Desktop.Reports.WorkflowReportFactory.CreatePicklistReport(ord, rus, _dvPickListMakeup);
            pl.ShowPreviewDialog();
            
        }

        private void SavePickListItems(object sender, EventArgs e)
        {


            BLL.Order ord = new BLL.Order();
            BLL.Institution rus = new Institution();
            ord.LoadByPrimaryKey(_orderID);


            // if the pick list has already been printed ... go ahead and pass it to the next level
            if (ord.OrderStatusID == OrderStatus.Constant.PICK_LIST_GENERATED)
            {
                ord.OrderStatusID = OrderStatus.Constant.PICK_LIST_CONFIRMED;
                ord.Save();
                BindApprovedOrders();
                gridPickListDetail.DataSource = null;
                XtraMessageBox.Show("The Pick List has been Confirmed", "Confirmation", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                return;
            }

            if (_dvPickListMakeup != null)
            {

                MyGeneration.dOOdads.TransactionMgr mgr = MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgr();
                try
                {
                    mgr.BeginTransaction();
                    // First of all .. print the pick list

                    rus.LoadByPrimaryKey(ord.RequestedBy);

                    var pl = HCMIS.Desktop.Reports.WorkflowReportFactory.CreatePicklistReport(ord, rus,
                                                                                              _dvPickListMakeup);
                    pl.PrintDialog();
                    var pls = new PickList();

                    pls.SavePickList(_orderID, _dvPickListMakeup, CurrentContext.UserId);

                    // Refresh the current window
                    BindApprovedOrders();
                    // clear the working grid
                    gridPickListDetail.DataSource = null;
                    mgr.CommitTransaction();
                    XtraMessageBox.Show("Your pick list has been saved! please continue to the next step or prepare another Picklist here.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exp)
                {
                    mgr.RollbackTransaction();
                    BLL.User user = new User();
                    //user.LoadByPrimaryKey(NewMainWindow.UserId);
                    user = CurrentContext.LoggedInUser;
                    if (user.UserType == UserType.Constants.ADMIN || user.UserType == UserType.Constants.SUPER_ADMINISTRATOR)
                    {
                        XtraMessageBox.Show(exp.Message);
                    }
                    else
                    {
                        XtraMessageBox.Show("System couldn't save the Pick List, Please contact administrator for additional help", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    ErrorHandler.Handle(exp);
                }
            }
        }

        #endregion

        private void btnCancelPickList_Click(object sender, EventArgs e)
        {
            DataRow dr = gridApprovedOrdersView.GetFocusedDataRow();
            if (dr != null)
            {
                if (DialogResult.Yes == XtraMessageBox.Show(String.Format("Are you sure you want to cancel the Request: {0}?", dr["RefNo"]), "Confirm Cancelation!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    int ordID = Convert.ToInt32(dr["ID"]);
                    BLL.Order ord = new BLL.Order();
                    ord.LoadByPrimaryKey(ordID);
                    ord.OrderStatusID = OrderStatus.Constant.CANCELED;
                    ord.Save();
                    if (BLL.Settings.IsCenter)
                    {
                        XtraMessageBox.Show("Issue Order List canceled", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }else
                    {
                        XtraMessageBox.Show("Pick List canceled", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                    BindApprovedOrders();
                    gridPickListDetail.DataSource = null;
                }
            }
        }

        private void btnReturnToApprovalStep_Click(object sender, EventArgs e)
        {
            //int ordId = Convert.ToInt32(gridApprovedOrdersView.GetFocusedDataRow()["ID"].ToString());
            MyGeneration.dOOdads.TransactionMgr transaction =  MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgr();
            
            try
            {
                transaction.BeginTransaction();
                Order ord = new Order();
                ord.LoadByPrimaryKey(_orderID);
                if (ord.RowCount > 0 && ord.OrderStatusID == OrderStatus.Constant.ORDER_APPROVED)
                {
                    ord.OrderStatusID = OrderStatus.Constant.ORDER_FILLED;
                    ord.Save();
                    BindApprovedOrders();
                }
                else if (ord.RowCount > 0 && ord.OrderStatusID == OrderStatus.Constant.PICK_LIST_GENERATED)
                {
                    ord.ReleaseReservation();
                    ord.OrderStatusID = OrderStatus.Constant.ORDER_FILLED;
                    ord.Save();
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
            gridApprovedOrdersView.ActiveFilterString = String.Format("RequestedBy LIKE '{0}%'", txtFacilityNameFilter.Text);
            gridUnconfirmedView.ActiveFilterString = String.Format("RequestedBy LIKE '{0}%'", txtFacilityNameFilter.Text);
        }

       



    }
}
