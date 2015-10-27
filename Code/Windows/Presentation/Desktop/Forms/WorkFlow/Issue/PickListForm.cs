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
using DevExpress.Utils;
using PickList = BLL.PickList;

namespace HCMIS.Desktop.Forms.WorkFlow
{
    
    [FormIdentifier("AP-RE-IO-CN","Review Issue Order","Pick List Form")]
    public partial class PickListForm : XtraForm
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
        /// 
        public PickListForm()
        {
            InitializeComponent();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            
            SetPermissions();
            lkStoreType.SetupModeEditor().SetDefaultMode();
            BindApprovedOrders();
            if (BLL.Settings.IsCenter)
            {
                btnPrintAndSavePickList.Text = @"Print Issue Order Forward";
            }else
            {
                btnPrintAndSavePickList.Text = @"Print Pick list Forward";
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
           
            lkStoreType_EditValueChanged(null, null);
            gridPickListDetail.DataSource = null;
        }

        #region Pick List Generation

        private void OnApprovedOrderRowClicked(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            var gv = (GridView)sender;
            var dr = gv.GetFocusedDataRow();
            var or = new BLL.Order();
            _orderID = Convert.ToInt32(gv.GetFocusedDataRow()["ID"].ToString());

            order.LoadByPrimaryKey(_orderID);
            // populate the general order variables
            txtPickListFromStore.Text = order.GetFromStore();
            lblMode.Text = order.GetFromStore();

            txtPickListRequestedBy.Text = order.GetFilledBy();

            if (!order.IsColumnNull("RequestedBy"))
            {
                var ins = new Institution();
                ins.LoadByPrimaryKey(order.RequestedBy);

                var ownership = new BLL.OwnershipType();
                ownership.LoadByPrimaryKey(ins.Ownership);

                lblOwnership.Text = ownership.Name;
                lblInstitutionType.Text = ins.InstitutionTypeName;
                lblFacility.Text = ins.Name;
                lblWoreda.Text = ins.WoredaName;
                lblZone.Text = ins.ZoneName;
                lblRegion.Text = ins.RegionName;
                lblLetterNum.Text = String.IsNullOrEmpty(order.LetterNo) ? "-" : order.LetterNo;

                

            }
            else
            {
                lblFacility.Text = lblWoreda.Text = lblZone.Text = lblRegion.Text = lblOwnership.Text = "";// lblType.Text = "";
            }

            int length = order.GetRequestedBy().Length;


            string s = "";

            HeaderLayoutGroup.Text = order.GetRequestedBy() + s.PadRight(150 - length) + "Order Number:" + order.RefNo;
          
            txtPickListOrderNumber.Text = order.RefNo;
            lblOrderNum.Text = order.RefNo;

            txtPickListApprovedBy.Text = order.GetApprovedBy();
            lblApprovedBy.Text = order.GetApprovedBy();

            var orderDetail = new OrderDetail();
            orderDetail.LoadAllByOrderID(order.ID);

            if (!orderDetail.IsColumnNull("StoreID"))
            {
                var activity = new Activity();     
                activity.LoadByPrimaryKey(orderDetail.StoreID);
                lblMode.Text = activity.ModeName;                
            }
      
            lblOrderDate.Text = order.Date.ToShortDateString();

            var us = new BLL.User();
            us.LoadByPrimaryKey(order.FilledBy);
            lblFilledBy.Text = us.FirstName;

            
            lblIssueStatus.Text = (string)dr["OrderStatus"] ?? "-";
            lblIssueType.Text = (string)dr["Description"] ?? "-"; 

            var paymentType = new BLL.PaymentType();
            paymentType.LoadByPrimaryKey(order.PaymentTypeID);
            lblPaymentType.Text = paymentType.Name;

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

        private void SavePickListItems(object sender, EventArgs e)
        {
            var ord = new Order();
            var rus = new Institution();
            ord.LoadByPrimaryKey(_orderID);
            rus.LoadByPrimaryKey(ord.RequestedBy);
                
            if (_dvPickListMakeup == null || ValidatePickList())
            {
              return;
            }
            
            // First of all .. print the pick list
                var pls = new PickList();
                PrintPickList(ord, rus);

                MyGeneration.dOOdads.TransactionMgr mgr = MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgr();
                try
                {
                    mgr.BeginTransaction();
                        pls.SavePickList(_orderID, _dvPickListMakeup, CurrentContext.UserId);
                    mgr.CommitTransaction();
                       
                    BindApprovedOrders();
                    this.LogActivity("Print-Pick-List", ord.ID);
                    XtraMessageBox.Show("Your pick list has been saved! please continue to the next step or prepare another Picklist here.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exp)
                {
                    mgr.RollbackTransaction();
                        ViewHelper.ShowErrorMessage("System couldn't save the Pick List, Please contact administrator for additional help", exp);
                    ErrorHandler.Handle(exp);
                }
            
        }

        private bool ValidatePickList()
        {
            foreach (DataRowView drv in _dvPickListMakeup)
            {
                var itemID = Convert.ToInt32(drv["ItemID"]);
                var storeID = Convert.ToInt32(drv["StoreID"]);
                var unitID = Convert.ToInt32(drv["UnitID"]);
                var manufacturerID = Convert.ToInt32(drv["ManufacturerID"]);

                if (BLL.Settings.BlockWhenExpectingPriceChange 
                    && ReceiveDoc.DoesPriceNeedToBeChanged(storeID, itemID, unitID,manufacturerID))
                {
                    XtraMessageBox.Show(
                        string.Format("The item {0}({1},{2}) cannot be issued because it is waiting for price change.",drv["FullItemName"],drv["Unit"],drv["ManufacturerName"]),
                        "Price Pending", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
            }
            return false;
        }

        private void PrintPickList(Order ord, Institution rus)
        {
            var pickList = WorkflowReportFactory.CreatePicklistReport(ord, rus.Name, _dvPickListMakeup);
            
            if (pickList != null)
            {
                pickList.PrintDialog();
                // Log the pick list
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
                    ord.ChangeStatus(OrderStatus.Constant.CANCELED,CurrentContext.UserId);
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
                    ord.ChangeStatus(OrderStatus.Constant.ORDER_FILLED,CurrentContext.UserId);;
                    BindApprovedOrders();
                }
                
                transaction.CommitTransaction();

                this.LogActivity("Return-Pick-List-To-Approval", ord.ID);
            }
            catch(Exception exp)
            {
                transaction.RollbackTransaction();
                throw exp;
            }
            gridPickListDetail.DataSource = null;
            
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
            gridApprovedOrdersView.ActiveFilterString = String.Format("RequestedBy LIKE '{0}%' or [RefNo] like '{0}%'", txtFacilityNameFilter.Text);
           
        }

        private void lkStoreType_EditValueChanged(object sender, EventArgs e)
        {
            BLL.Order ord = new BLL.Order();
            
            // get orders that are yet to be pick listed
            gridApprovedOrders.DataSource = ord.GetAllApprovedOrders(CurrentContext.UserId, Convert.ToInt32(lkStoreType.EditValue));
            gridApprovedOrdersView.ExpandAllGroups();
        }

        private void gridPickListDetail_Click(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void labelControl9_Click(object sender, EventArgs e)
        {

        }
    }
}