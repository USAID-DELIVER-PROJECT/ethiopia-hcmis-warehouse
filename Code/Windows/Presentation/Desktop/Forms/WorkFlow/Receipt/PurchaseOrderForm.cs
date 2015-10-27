using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using BLL;
using BLL.WorkFlow.Receipt;
using DevExpress.XtraBars.ViewInfo;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraRichEdit.Layout.Export;
using HCMIS.Desktop.Helpers;
using HCMIS.Helpers;
using System.Data;


namespace HCMIS.Desktop.Forms.WorkFlow
{
    [FormIdentifier("OR-OR-OI-VW","Purchase Order","Purchase Order Form")]
    public partial class PurchaseOrderForm : DevExpress.XtraEditors.XtraForm
    {
        //Declare One PO for Selecting Data or Adding new Data
        PO Order = new PO();
        PurchaseOrderType PurchaseTypes;
        private enum AccessMode
        {
            Finance = 1,
            Distribution = 2,
        }

        AccessMode OrderAccessMode;
        public PurchaseOrderForm()
        {
            this.LogActivity("Open");
            SetPermission();

            InitializeComponent();
        }

        private void SetPermission()
        {
            //Set Access mode
            if (BLL.Settings.UseNewUserManagement)
            {
                
            }
            else
            {
                if (CurrentContext.LoggedInUser.UserType == UserType.Constants.FUND_OFFICER ||
                    CurrentContext.LoggedInUser.UserType == UserType.Constants.FINANCE ||
                    CurrentContext.LoggedInUser.UserType == UserType.Constants.INVOICER)
                    OrderAccessMode = AccessMode.Finance;
                else
                    OrderAccessMode = AccessMode.Distribution;
            }
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            
            LayoutAndBindingByAccess();
            gridOrder.DataSource = PO.GetOrderForSelection(CurrentContext.UserId,null);
            LoadDecimalFormatings();
            gridLkEditOrderType.Properties.DataSource = POType.GetAllPOTypes();
        }

        private void LayoutAndBindingByAccess()
        {
            if (BLL.Settings.UseNewUserManagement)
            {
                btnAddOrder.Enabled = (this.HasPermission("Add-Order"));
                btnEditOrder.Enabled = (this.HasPermission("Edit-Order"));
            }else if (OrderAccessMode == AccessMode.Distribution)
            {
                colInsurance.Visible = false;
                colNBE.Visible = false;
                colTotalValue.Visible = false;
                btnEditOrder.Enabled = false;
                btnAddOrder.Enabled = false;
            }
        }
        
        private void LoadDecimalFormatings()
        {
            string sharps = Helpers.FormattingHelpers.GetNumberFormatting();
            string displaySharpsBirr = Helpers.FormattingHelpers.GetBirrFormatting();
            string displaySharpsPercent = Helpers.FormattingHelpers.GetPercentFormatting();
            string displayExchangeRate = Helpers.FormattingHelpers.GetExchangeRateFormatting();
      
        }

        private void gridOrderView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
     {
         if (e != null && e.PrevFocusedRowHandle < -1)
             return;

            if (gridOrderView.GetFocusedDataRow() != null)
            {
                var dr = gridOrderView.GetFocusedDataRow();

                int OrderID = Convert.ToInt32(dr["ID"]);
                string sharps = Helpers.FormattingHelpers.GetNumberFormatting();
                Order = new PO(OrderID);
                RefreshInvoice();
                RefreshPoDetail();
                // Layout  ... Show the damn correct layout

                // Hide the empty layout
                LayoutEmptyDetails.Visibility = LayoutVisibility.Never;
                LayoutSelectedOrderDetail.Visibility = LayoutVisibility.Always;
               
                int Currency = 0x0409;
                if(!Order.IsColumnNull("LCID"))
                    Currency = Order.LCID;
                
                if(!string.IsNullOrEmpty(Order.s_PurchaseType))
                    PurchaseTypes = POType.GetAllPOTypes().Find(t => t.ID == Order.PurchaseType);
                string space = "";
                DataRow dar = gridInvoiceView.GetFocusedDataRow();
                HeaderGroup.Text = "PO No: " + dr["OrderNumber"].ToString();
               if (dar != null)
               {
                   HeaderGroup.Text = HeaderGroup.Text + space.PadRight(160) + "Invoice No: " + gridInvoiceView.GetFocusedDataRow()["STVOrInvoiceNo"];
               }
               
              // lblOrderType.Text = PurchaseTypes != null ?  string.Format("{0} : {1}" ,PurchaseTypes.Group , PurchaseTypes.Name) : "";
                lblPONumber.Text = Order.PONumber;
                lblTotalValue.Text = Order.TotalValue.ToString(Helpers.FormattingHelpers.GetCurrencyFormatByLCID(Currency));
                lblInsurance.Text = Order.Insurance.ToString(Helpers.FormattingHelpers.GetBirrFormatting());
                lblNBE.Text = Order.NBE.ToString(Helpers.FormattingHelpers.GetBirrFormatting());
                lblSupplier.Text = Order.Supplier.CompanyName;
                lblShipper.Text = String.IsNullOrEmpty(Order.ShippingSite) ? "-" : Order.ShippingSite;
                lblLetterNo.Text = String.IsNullOrEmpty(Order.LetterNo) ? "-" : Order.LetterNo;
                lblPOType.Text = dr["Name"].ToString();

                var PaymentType = new PaymentType();
                PaymentType.LoadByPrimaryKey(Order.PaymentTypeID);
                lblPaymentType.Text = String.IsNullOrEmpty(PaymentType.Name) ? "-" : PaymentType.Name ;

                var User = new User();
                User.LoadByPrimaryKey(Order.SavedbyUserID);
                lblPOBy.Text = String.IsNullOrEmpty(User.FullName) ? "-" : User.FullName;

                if (!Order.IsColumnNull("ModeID"))
                {
                    var Mode = new Mode();
                    Mode.LoadByPrimaryKey(Order.ModeID);
                    lblMode.Text = Mode.TypeName;
                }
                else lblMode.Text = "-";

               
  
                if (!Order.IsColumnNull("PurchaseOrderStatusID"))
                {
                    var poStatus = new PurchaseOrderStatus();
                    poStatus.LoadByPrimaryKey(Order.PurchaseOrderStatusID);
                    lblPOStatus.Text = poStatus.Name;
                }

               
                chkboxIsElectronic.Checked = Order.IsElectronic;
                lblOrderDate.Text = Order.PODate.ToShortDateString();
                lblSyncDate.Text = Order.ModifiedDate == DateTime.MinValue ? "NA" :  Order.ModifiedDate.ToString(CultureInfo.InvariantCulture);

                if (!Order.IsColumnNull("StoreID"))
                {
                    Activity act = new Activity();
                    act.LoadByPrimaryKey(Order.StoreID);
                    lblAccount.Text = act.AccountName;
                    lblSubAccount.Text = act.SubAccountName;
                    lblActivity.Text = act.Name;


                }
                else
                {
                    lblAccount.Text = lblSubAccount.Text = lblActivity.Text = "-";
                }

                lblRefNo.Text = String.IsNullOrEmpty(Order.RefNo) ? "-" : Order.RefNo;
              lblRemainingValue.Text = Order.Remaining.ToString(Helpers.FormattingHelpers.GetCurrencyFormatByLCID(Currency));
                if (BLL.Settings.UseNewUserManagement && this.HasPermission("Add-Invoice"))
                {
                    btnAddInvoice.Enabled = true;
                }
                else if (BLL.Settings.UseNewUserManagement)
                {
                    btnAddInvoice.Enabled = false;
                }

                btnAddInvoice.Enabled = btnEditOrder.Enabled =btnAddOrderDetail.Enabled = !Order.IsElectronic;

                if (Order.IsElectronic)
                {
                    grdPoDetail.Enabled = false;
                    gridInvoice.Enabled = false;
                }
                else
                {
                    grdPoDetail.Enabled = true ;
                    gridInvoice.Enabled = true;
                }

                //purchse order details
                grdPoDetail.DataSource = Order.PurchaseOrderDetail.DefaultView;
            }
            else
            {
                // Hide the empty layout
                LayoutEmptyDetails.Visibility = LayoutVisibility.Always;
                LayoutSelectedOrderDetail.Visibility = LayoutVisibility.Never;
            }
           
          
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            HCMIS.Desktop.Forms.WorkFlow.PODialog dialog = new HCMIS.Desktop.Forms.WorkFlow.PODialog(0);
            if (dialog.ShowDialog(this) == DialogResult.Yes)
            {
                // Reload the PO Grid.
                gridOrder.DataSource = PO.GetOrderForSelection(CurrentContext.UserId,null);
                
            }
        }

        private void lkOrderType_EditValueChanged(object sender, EventArgs e)
        {
            
            RefeshPOGrid();
        }

        private void gridOrderView_DoubleClick(object sender, EventArgs e)
        {
            //if (BLL.Settings.UseNewUserManagement && !this.HasPermission("Edit-Order"))
            //{
            //    return;
            //}

            //if (gridOrderView.GetFocusedDataRow() != null && !Convert.ToBoolean(gridOrderView.GetFocusedDataRow()["IsElectronic"]))
            //{
            //    int OrderID = Convert.ToInt32(gridOrderView.GetFocusedDataRow()["ID"]);

            //    var po = new PO();
            //    po.LoadByPrimaryKey(OrderID);

            //    if (po.ReceiveStarted)
            //    {
            //        MessageBox.Show("Editing is not allowed because this order has already been received.", "Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
           
            //    var dialog = new PODialog(OrderID);
            //    if (dialog.ShowDialog(this) == DialogResult.Yes)
            //    {
            //        // Reload the PO Grid.
            //        RefeshPOGrid();
            //    }
            //}
            
        }

        private void RefeshPOGrid()
        {
            if (gridLkEditOrderType.EditValue == null || gridLkEditOrderType.EditValue == "")
            {
                gridOrder.DataSource = PO.GetOrderForSelection(CurrentContext.UserId,null);
            }
            else
            {
                gridOrder.DataSource = PO.GetOrderForSelection(CurrentContext.UserId,Convert.ToInt32(gridLkEditOrderType.EditValue));
            }
        }

        private void btnAddNewInvoice_Click(object sender, EventArgs e)
        {
            if (gridOrderView.GetFocusedDataRow() != null)
            {
                
                int OrderID = Convert.ToInt32(gridOrderView.GetFocusedDataRow()["ID"]);
                ShowEditFormForInvoice(OrderID);
            }
        }

        private void ShowEditFormForInvoice(int OrderID)
        {
            var dialog = new ReceiptInvoiceDialog(OrderID);
            dialog.ShowDialog(this);
            RefreshInvoice();
        }

        private void ShowEditFormForInvoice(int OrderID, int InvoiceID)
        {
            if (BLL.Settings.UseNewUserManagement && !this.HasPermission("Edit-Invoice"))
            {
                return;
            }
            var dialog = new ReceiptInvoiceDialog(OrderID, InvoiceID);
            dialog.ShowDialog(this);
            RefreshInvoice();
        }

        private void RefreshInvoice()
        {
           if(gridOrderView.GetFocusedDataRow() != null){
               Order.Invoices.LoadForPO(Order.ID);
                gridInvoice.DataSource = Order.Invoices.DefaultView;
           }
            
        }

        public void RefreshPoDetail()
        {
            if (gridOrderView.GetFocusedDataRow() != null)
            {
              Order.LoadPurchaseOrderDetail();
              grdPoDetail.DataSource = Order.PurchaseOrderDetail.DefaultView;
              
            }
        }

        private void gridInvoiceView_DoubleClick(object sender, EventArgs e)
        {
            // On Invoice Edit
            if (gridInvoiceView.GetFocusedDataRow() != null)
            {
                if (!Order.IsElectronic)
                {
                    int orderID = Convert.ToInt32(gridOrderView.GetFocusedDataRow()["ID"]);
                    int invoiceID = Convert.ToInt32(gridInvoiceView.GetFocusedDataRow()["ID"]);
                    ShowEditFormForInvoice(orderID, invoiceID);
                }
            }
        }

        private void btnEditOrder_Click(object sender, EventArgs e)
        {
            if (BLL.Settings.UseNewUserManagement && !this.HasPermission("Edit-Order"))
            {
                return;
            }

            if (gridOrderView.GetFocusedDataRow() != null && !Convert.ToBoolean(gridOrderView.GetFocusedDataRow()["IsElectronic"]))
            {
                int OrderID = Convert.ToInt32(gridOrderView.GetFocusedDataRow()["ID"]);

                var po = new PO();
                po.LoadByPrimaryKey(OrderID);

                if (po.ReceiveStarted)
                {
                    MessageBox.Show("Editing is not allowed because this order has already been received.", "Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var dialog = new PODialog(OrderID);
                if (dialog.ShowDialog(this) == DialogResult.Yes)
                {
                    // Reload the PO Grid.
                    RefeshPOGrid();
                }
            }
        }

        private void btnEditInvoice_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            gridInvoiceView_DoubleClick(null, null);
        }

        private void btnAddOrderDetail_Click(object sender, EventArgs e)
        {
            GetPurchaseOrderDetailForm();
        }

        private void GetPurchaseOrderDetailForm()
        {

            var dialog = new Modals.PurchaseOrderDetailForm(Order.ID, Order.StoreID);
            dialog.ShowDialog(this);
            RefreshPoDetail();
        }

        private void grdPoDetailView_Click(object sender, EventArgs e)
        {
            GetPurchaseOrderDetailForm();
        }

        private void gridLkEditOrderType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                gridOrder.DataSource = PO.GetOrderAll(CurrentContext.UserId);
            }
        }

        private void gridLkEditOrderType_DoubleClick(object sender, EventArgs e)
        {
            gridOrder.DataSource = PO.GetOrderAll(CurrentContext.UserId);
        }

        private void txtFilter_EditValueChanged(object sender, EventArgs e)
        {
            gridOrderView.ActiveFilterString = string.Format("OrderNumber like '{0}%' or Supplier like '{0}%' or IsElectronicString like '{0}%' or Name like '{0}%'", txtFilter.Text);

           
            gridOrderView_FocusedRowChanged(null,null);

        }

        private void gridOrder_Click(object sender, EventArgs e)
        {

        }

        private void lblOrderDate_Click(object sender, EventArgs e)
        {

        }

        private void lblMode_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalValue_Click(object sender, EventArgs e)
        {

        }

        private void lblNBE_Click(object sender, EventArgs e)
        {

        }

        private void lblSyncDate_Click(object sender, EventArgs e)
        {

        }

        private void gridInvoice_FocusedViewChanged(object sender, DevExpress.XtraGrid.ViewFocusEventArgs e)
        {

        }

        private void gridInvoiceView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridOrderView.GetFocusedDataRow();
            DataRow dar = gridInvoiceView.GetFocusedDataRow();
            string space = "";
           
                if(dr!=null && dar!=null)
                {
                   HeaderGroup.Text = "PO No: " + dr["OrderNumber"] + space.PadRight(160) + "Invoice No: " + dar["STVOrInvoiceNo"];
                }
                else
                {
                    return;
                }
            
        }

        private void lblInsurance_Click(object sender, EventArgs e)
        {

        }
        
    }
}