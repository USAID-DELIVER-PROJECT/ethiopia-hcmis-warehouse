using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using DevExpress.Data.Filtering;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraLayout.Utils;
using HCMIS.Desktop.Forms.Modals;
using HCMIS.Desktop.Helpers;
using HCMIS.Desktop.ImitationHCTS;
using HCMIS.Warehouse;
using Order = BLL.Order;
using OrderDetail = BLL.OrderDetail;
using HCMIS.Desktop.Helpers;
using HCMIS.Helpers;
using HCMIS.Desktop.Views;
using DevExpress.XtraGrid.Views.Grid;
using BinaryOperatorType = DevExpress.CodeParser.BinaryOperatorType;

namespace HCMIS.Desktop.Forms.WorkFlow
{
    [FormIdentifier("RQ-MA-MR-VW", "Manage Requisitions", "Manage Requisitions")]
    public partial class ManageRequisitionForm : XtraForm
    {
        #region Member Variables
        // For the first tab (Drug selection)
        Dictionary<int, DataTable> ItemChoices = new Dictionary<int, DataTable>();

        // where all the selected items are stored
        DataTable _dtSelectedTable = null;

        // table that stores order for approval
        DataView _dvOrderTable = null;
        private int? OrderID;

        bool _gridIsValid = true;

        #endregion

        public ManageRequisitionForm()
        {
            InitializeComponent();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            // Select the first comodity category
            LoadRequisitions();
            SetPermissions();
            HideUnhideColumn();
        }

        private void HideUnhideColumn()
        {
            layoutCenterRequisition.Visibility = BLL.Settings.IsCenter ? LayoutVisibility.Never : LayoutVisibility.Never;
            colDamaged.Visible = colExpired.Visible = colSOH.Visible = InstitutionIType.IsVaccine(GeneralInfo.Current);
        }

        private void SetPermissions()
        {
            if (BLL.Settings.UseNewUserManagement)
            {
                btnDeleteRequisition.Enabled = (this.HasPermission("Cancel-Requisition"));
                btnNewRequisition.Enabled = (this.HasPermission("Create-New-Requisition"));
                btnEditRequistion.Enabled = (this.HasPermission("Edit-Requisition"));
                btnSubmitWishlist.Enabled = (this.HasPermission("Submit-Requisition"));
            }
        }

        private void chkShowSubmitted_CheckedChanged(object sender, EventArgs e)
        {
            btnDeleteRequisition.Enabled = !chkShowSubmitted.Checked;
            btnEditRequistion.Enabled = !chkShowSubmitted.Checked;
            btnSubmitWishlist.Enabled = !chkShowSubmitted.Checked;
            LoadRequisitions();
        }

        private void LoadRequisitions()
        {
            gridRequisitions.DataSource = Order.GetRequisitions((chkShowSubmitted.Checked) ? "ORFI" : "DRFT", CurrentContext.UserId);
            // default to the loaded element and ... show the details appropriately.
           // gridRequisitionListView_FocusedRowChanged(null, null);
        }


        private void gridRequisitionListView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (e != null && e.PrevFocusedRowHandle < -1)
                return;
            
            
            try
            {
                DataRow dr = gridRequisitionListView.GetFocusedDataRow();
                if (dr == null)
                    return;
                int orderID = Convert.ToInt32(dr["ID"]);
                gridRequisitionDetails.DataSource = Order.GetRequisitionDetails(orderID);
                //lblOrderStatus.Text = Order.GetOrderStatus(orderID);

                BLL.Order order = new BLL.Order();
                order.LoadByPrimaryKey(orderID);


                Institution ins = new Institution();

                ins.LoadByPrimaryKey(order.RequestedBy);

                lblWoreda.Text = ins.WoredaName;
                lblZone.Text = ins.ZoneName;
                lblRegion.Text = ins.RegionName;
                lblRequestedDate.Text = order.EurDate.ToShortDateString();
                lblRequestedBy.Text = order.GetFilledBy();

                
                OrderStatus os = new OrderStatus();
                os.LoadByPrimaryKey(order.OrderStatusID);

                lblStatus.Text = os.OrderStatus;

                int length = order.GetRequestedBy().Length;

                string s = "";

                headerSection.Text = order.GetRequestedBy() + s.PadRight(200 - length) + "Order Number: " + order.RefNo;

                var ownership = new BLL.OwnershipType();
                ownership.LoadByPrimaryKey(ins.Ownership);
                lblOwnership.Text = ownership.Name;

                var paymentType = new BLL.PaymentType();
                paymentType.LoadByPrimaryKey(order.PaymentTypeID);
                lblPaymentType.Text = paymentType.Name;
                lblMode.Text = order.GetFromStore();
                DataRow facilityHis = BLL.Issue.GetVisitHistoryForFacility(Convert.ToInt32(dr["InstitutionID"]));

                if (facilityHis != null)
                {
                    lblLastVisit.Text = Convert.ToDateTime(facilityHis["LastVisit"]).TimeAgo() ?? "-";
                    lblNoOfReq.Text = Convert.ToString(facilityHis["VisitCount"]) ?? "-";
                    lblIssueType.Text = Convert.ToString(facilityHis["Description"]) ?? "-";
                }

                else
                {
                    lblLastVisit.Text = lblNoOfReq.Text = lblIssueType.Text = "-";

                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void btnSubmitWishlist_Click(object sender, EventArgs e)
        {

            DataRow dr = gridRequisitionListView.GetFocusedDataRow();
            if (dr != null)
            {
                int orderID = Convert.ToInt32(dr["ID"]);
                Order ord = new Order();
                ord.LoadByPrimaryKey(orderID);
                if (ord.OrderStatusID == OrderStatus.Constant.DRAFT_WISHLIST)
                {
                    ord.ChangeStatus(OrderStatus.Constant.ORDER_FILLED,CurrentContext.UserId);
                    LoadRequisitions();
                    XtraMessageBox.Show("Your requisisition has been submitted.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("This requisition has already been submitted, you cannot resubmit it.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }



        private void btnDeleteRequisition_Click(object sender, EventArgs e)
        {

            DataRow dr = gridRequisitionListView.GetFocusedDataRow();
            if (dr != null)
            {
                int orderID = Convert.ToInt32(dr["ID"]);
                Order ord = new Order();
                ord.LoadByPrimaryKey(orderID);
                if (ord.OrderStatusID == OrderStatus.Constant.DRAFT_WISHLIST)
                {
                    if (XtraMessageBox.Show("Are you sure you would like to cancel this requisition?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        if (ord.OrderStatusID == OrderStatus.Constant.DRAFT_WISHLIST)
                        {
                            ord.ChangeStatus(OrderStatus.Constant.CANCELED,CurrentContext.UserId);
                            LoadRequisitions();
                            XtraMessageBox.Show("Your requisisition has been canceled.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {

                        }
                        LoadRequisitions();
                    }
                }
                else
                {
                    XtraMessageBox.Show("This requisition has already been submitted, you cannot resubmit/cancel it.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void btnNewRequisition_Click(object sender, EventArgs e)
        {
            if (BLL.Settings.UseNewUserManagement)
            {
                WishListForm wlf = new WishListForm();
                //wlf.Parent = this;
                this.ReplaceMe(wlf);
            }

        }

        private void gridRequisitionListView_Click(object sender, EventArgs e)
        {
            gridRequisitionListView_FocusedRowChanged(null, null);
        }

        private void btnEditRequistion_Click(object sender, EventArgs e)
        {
            DataRow dr = gridRequisitionListView.GetFocusedDataRow();


            WishListForm wlf = new WishListForm(); ;
            if (BLL.Settings.UseNewUserManagement)
            {
                this.ReplaceMe(wlf);
            }

            if (dr != null)
            {
                int orderID = Convert.ToInt32(dr["ID"]);

                wlf.EditRequisition(orderID);
            }
        }

        private void gridListView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var requisitionCenter = new RequisitionCenter();
            requisitionCenter.ShowDialog(this);
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            btnDeleteRequisition.Enabled = !chkShowSubmitted.Checked;
            btnEditRequistion.Enabled = !chkShowSubmitted.Checked;
            btnSubmitWishlist.Enabled = !chkShowSubmitted.Checked;
            LoadRequisitions();
        }

        private void gridRequisitionDetails_Click(object sender, EventArgs e)
        {

        }

        
        private void textEdit1_TextChanged(object sender, EventArgs e)
        
        {
            gridRequisitionListView.ActiveFilterString = string.Format("Name like '%{0}%' or RefNo like '%{0}%' or Status like '%{0}%' or DateRequested like '%{0}%'", textEdit1.Text);
        }


    }
}
