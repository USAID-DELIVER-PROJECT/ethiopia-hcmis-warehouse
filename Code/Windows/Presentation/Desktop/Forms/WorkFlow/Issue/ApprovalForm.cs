using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraReports.UI;
using HCMIS.Desktop.Helpers;
using HCMIS.Desktop.ViewHelpers;
using HCMIS.Helpers;
using Helpers;
using Order = BLL.Order;
using OrderDetail = BLL.OrderDetail;
using DevExpress.XtraGrid.Views.Grid;

namespace HCMIS.Desktop.Forms.WorkFlow
{
    [FormIdentifier("AP-AQ-AQ-FR", "Approval Form", "Approval")]
    public partial class ApprovalForm : XtraForm
    {
        #region Member Variables

        // these properties are for selected orders
        private BLL.Order ApprovalOrder = new BLL.Order();
        private bool _isFirstTimeLoad;
        private int _orderID = 0;

        #endregion

        public ApprovalForm()
        {
            InitializeComponent();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {

            SetPermissions();
            uxApproval.Initialize();
            lkMode.SetupModeEditor().SetDefaultMode();
            tabFacility.Visible = uxApproval.ShowAMCandMOS = !BLL.Settings.IsCenter;
            uxApproval.ShowPipeline = false;
            //uxApproval.ShowPipeline = !BLL.Settings.IsCenter;


            BindOutstandingOrders();
        }

        private void SetPermissions()
        {
            if (BLL.Settings.UseNewUserManagement)
            {
                btnApproveOrder.Enabled = this.HasPermission("Approve");
                btnCancelApproval.Enabled = this.HasPermission("Cancel-Order");
                btnReturnToEdit.Enabled = this.HasPermission("Return-To-Requisition");
                btnSaveDraft.Enabled = this.HasPermission("Save-Draft");
            }
        }


        private void BindOutstandingOrders()
        {
            BLL.Order or = new BLL.Order();
            this.tabControlOrderDetail.SelectedTabPage = this.tabGeneral;
            bool clearSelection = (gridOrder.DataSource == null);
            // Bind the orders that have not been Approved. 
            if (lkMode.EditValue != null)
            {
                gridOrder.DataSource = or.GetAllOutstandingOrders(CurrentContext.UserId,
                                                                  int.Parse(lkMode.EditValue.ToString()));
            }

            if (clearSelection)
            {
                gridViewOrder.OptionsSelection.EnableAppearanceFocusedRow = false;
            }

            gridViewOrder.ExpandAllGroups();
        }

        private void OnOutstandingOrdersRowClicked(object sender, RowClickEventArgs e)
        {

            gridViewOrder.OptionsSelection.EnableAppearanceFocusedRow = true;
            _orderID = Convert.ToInt32(gridViewOrder.GetFocusedDataRow()["ID"].ToString());

            ApprovalOrder.LoadByPrimaryKey(_orderID);
            gridOrderDetailForFacility.DataSource = null;

            tabFacility.Text = String.Format("{0} History", ApprovalOrder.GetRequestedBy());
            
            uxApproval.LoadOrder(_orderID, BLL.Settings.IsCenter);
            _isFirstTimeLoad = true;
            tabControlOrderDetail.SelectedTabPage = tabGeneral;
            tabControlOrderDetail_SelectedPageChanged(null, null);
        }


        private void OnSaveApproval(object sender, EventArgs e)
        {
            if (
                XtraMessageBox.Show("Are you sure you would like to save this approval?", "Confirm Approval",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (uxApproval.ApproveOrder(CurrentContext.UserId))
                {

                    var order = new BLL.Order();
                    order.LoadByPrimaryKey(_orderID);

                    if (!BLL.Settings.IsCenter && uxApproval.HasStockOut() &&
                        XtraMessageBox.Show("Would you like to print the stockout report?",
                                            "Stockout Report Confirmation",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                        System.Windows.Forms.DialogResult.Yes)
                    {
                        StockOutReport(_orderID).ShowPreviewDialog();
                    }


                    gridViewOrder.OptionsSelection.EnableAppearanceFocusedRow = false;
                    BindOutstandingOrders();
                    uxApproval.Flush();
                    this.LogActivity("Approve-Order", ApprovalOrder.ID);
                    XtraMessageBox.Show("Approval Confirmed for User","Confirmation",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
        }

        private void btnSaveDraft_Click(object sender, EventArgs e)
        {
            uxApproval.SaveDraftOrder(CurrentContext.UserId);
            this.LogActivity("Save-Draft", ApprovalOrder.ID);
        }


        private void BtnCancelClicked(object sender, EventArgs e)
        {
            // cancel order from the approve order screen
            DataRow dr = gridViewOrder.GetFocusedDataRow();
            if (dr != null)
            {
                if (DialogResult.Yes ==
                    XtraMessageBox.Show(
                        String.Format("Are you sure you want to cancel the Request: {0}?", dr["RefNo"]),
                        "Confirm Cancelation!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {

                    //TOFIX: this could have been written in the business Logic
                    int ordID = Convert.ToInt32(dr["ID"]);
                    BLL.Order ord = new BLL.Order();
                    ord.LoadByPrimaryKey(ordID);
                    ord.ChangeStatus(OrderStatus.Constant.CANCELED,CurrentContext.UserId);
                    this.LogActivity("Cancel-Approval", ord.ID);
                    XtraMessageBox.Show("Request canceled", "Confirmation", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    BindOutstandingOrders();
                }
            }
        }

        private bool IsApprovalValid()
        {
            //Let's see if there are rows with identical preferrence
            BLL.OrderDetail validatedOrder = new OrderDetail();
            validatedOrder.ValidateOrderDetailForIdenticalPreference(_orderID);
            if (validatedOrder.RowCount > 0)
            {
                XtraMessageBox.Show(
                    string.Format(
                        "The item {0} has a split entries with the same preference.  Please correct that to approve the order.",
                        validatedOrder.GetColumn("FullItemName").ToString()));
                return false;
            }
            return true;

        }


        private void btnPrintStockOutReport_Click(object sender, EventArgs e)
        {
            
            StockOutReport(_orderID).ShowPreviewDialog();
        }

        private HCMIS.Desktop.Reports.StockOut  StockOutReport(int orderID)
        {
            var stockedOutReport = new HCMIS.Desktop.Reports.StockOut();
            stockedOutReport.HubName.Text = GeneralInfo.Current.HospitalName;
            stockedOutReport.StockOutExplanation.Text = string.Format("The item/s listed below were stocked-out at the time the request (letter {2} by {1}) was made on {0}", EthiopianDate.EthiopianDate.GregorianToEthiopian(ApprovalOrder.Date), ApprovalOrder.GetRequestedBy(), ApprovalOrder.LetterNo);
            stockedOutReport.PreparedBy.Text = CurrentContext.LoggedInUserName;
            stockedOutReport.PrintedOn.Text = EthiopianDate.EthiopianDate.Now.ToDateString();
            stockedOutReport.DataSource = OrderDetail.GetStockOutReport(orderID);
            return stockedOutReport;
        }

    private void txtFacilityName_EditValueChanged(object sender, EventArgs e)
        {
            gridViewOrder.ActiveFilterString = string.Format("RequestedBy LIKE '{0}%' or RefNo like '{0}%'", txtFacilityName.Text);
        }


      


        private void btnReturnToEdit_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Are you sure you would like to return this Order to the SDO?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                ApprovalOrder.ChangeStatus(OrderStatus.Constant.DRAFT_WISHLIST,CurrentContext.UserId);
                ApprovalOrder.ApprovedBy = CurrentContext.UserId;
                //ApprovalOrder.Remark = NewMainWindow.LoggedInUserName;
                //gridOrderDetailForApproval.DataSource = null;
                ApprovalOrder.Save();
                this.LogActivity("Return-To-Edit", ApprovalOrder.ID);
                XtraMessageBox.Show("The requisition you selected has been sent back to the SDO", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindOutstandingOrders();
            }
        }

        private void gridViewOrderDetailForFacility_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridViewOrderDetailForFacility_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "LastRequestedDate")
                e.DisplayText = !DBNull.Value.Equals(e.Value) ? (Convert.ToDateTime(e.Value)).TimeAgo() : "Not Requested Before";
        }


        private void lkStoreType_EditValueChanged(object sender, EventArgs e)
        {
            BindOutstandingOrders();
        }

        private void tabControlOrderDetail_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if(tabControlOrderDetail.SelectedTabPage == tabFacility && _isFirstTimeLoad)
            {

                var facilityId = ApprovalOrder.RequestedBy;
                var orderdetail = new OrderDetail();
                orderdetail.LoadAllByOrderID(_orderID);
                var facilityhistory = orderdetail.GetLastOrderDetailByFacility(_orderID, facilityId);
                gridOrderDetailForFacility.DataSource = facilityhistory;
                _isFirstTimeLoad = false;
            }
            
           btnApproveOrder.Enabled = tabControlOrderDetail.SelectedTabPage == tabGeneral && this.HasPermission("Approve");
           
        }

        private void tabControlOrderDetail_Click(object sender, EventArgs e)
        {

        }
    }
}