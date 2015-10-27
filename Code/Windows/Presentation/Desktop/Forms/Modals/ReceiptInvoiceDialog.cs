using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.CodeParser;
using DevExpress.XtraEditors;
using BLL;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout.Converter;
using HCMIS.Desktop.Helpers;
using PO = BLL.PO;
using ReceiptInvoice = BLL.ReceiptInvoice;
using User = BLL.User;
using UserType = BLL.UserType;

namespace HCMIS.Desktop.Forms.WorkFlow
{
    public partial class ReceiptInvoiceDialog : XtraForm
    {
        private readonly int _orderID;
        private int _receiptInvoiceID;
        private int _currency;
        string space = "";
        private DataTable _dtReceiptInvoiceDetail = new DataTable();
        private enum AccessMode
        {
            Finance = 1,
            Distribution = 2,
        }

        private AccessMode InvoiceAccessMode;

        public ReceiptInvoiceDialog(int OrderID)
        {
            this._orderID = OrderID;
            InitializeComponent();
        }

        private void InitializeForm()
        {
            this.LogActivity("Open-Invoice-Detail", _orderID);

            SetPermission();


        }

        private void SetPermission()
        {
            if (BLL.Settings.UseNewUserManagement)
            {
                if (this.HasPermission("Edit-Financial"))
                {
                    InvoiceAccessMode = AccessMode.Finance;
                }
                else
                {
                    InvoiceAccessMode = AccessMode.Distribution;
                }
            }
            else
            {
                //Set Access mode
                if (User.GetUserType(CurrentContext.UserId) == UserType.Constants.FUND_OFFICER ||
                    User.GetUserType(CurrentContext.UserId) == UserType.Constants.FINANCE)
                    InvoiceAccessMode = AccessMode.Finance;
                else
                    InvoiceAccessMode = AccessMode.Distribution;
            }
        }

        public ReceiptInvoiceDialog(int OrderID, int InvoiceID)
        {
            _orderID = OrderID;
            _receiptInvoiceID = InvoiceID;
            InitializeComponent();
        }

        private void ConstructTableColumns()
        {
            _dtReceiptInvoiceDetail.Columns.Add("ReceiptInvoiceDetailID", typeof(int));
            _dtReceiptInvoiceDetail.Columns.Add("ReceiptInvoiceID", typeof(int));
            _dtReceiptInvoiceDetail.Columns.Add("FullItemName");
            _dtReceiptInvoiceDetail.Columns.Add("Unit");
            _dtReceiptInvoiceDetail.Columns.Add("Manufacturer");
            _dtReceiptInvoiceDetail.Columns.Add("ItemID", typeof(int));
            _dtReceiptInvoiceDetail.Columns.Add("ManufacturerID", typeof(int));
            _dtReceiptInvoiceDetail.Columns.Add("UnitOfIssueID", typeof(int));
            _dtReceiptInvoiceDetail.Columns.Add("OrderedAmount", typeof(decimal));
            _dtReceiptInvoiceDetail.Columns.Add("OrderedQuantity", typeof(decimal));
            _dtReceiptInvoiceDetail.Columns.Add("InvoicedQty", typeof(decimal));
            _dtReceiptInvoiceDetail.Columns.Add("UnitPrice", typeof(decimal));
            _dtReceiptInvoiceDetail.Columns.Add("Margin", typeof(decimal));
            _dtReceiptInvoiceDetail.Columns.Add("ExpiryDate", typeof(DateTime));
            _dtReceiptInvoiceDetail.Columns.Add("BatchNumber");
            _dtReceiptInvoiceDetail.Columns.Add("IsSaved", typeof(bool));
            _dtReceiptInvoiceDetail.Columns.Add("GUID", typeof(Guid));

        }
        private void btnSaveInvoice_Click(object sender, EventArgs e)
        {
            PO po = new PO(_orderID);
            if (dxValidation.Validate())
            {
                ReceiptInvoice invoice = new ReceiptInvoice();
                if (_receiptInvoiceID != 0)
                {
                    invoice.LoadByPrimaryKey(_receiptInvoiceID);


                }
                else
                {
                    invoice.AddNew();
                }
                //TODO: save the Invoice Type Here.
                invoice.InvoiceTypeID = 1;
                invoice.InsurancePolicyNo = txtInsurance.Text;
                double TotalValue = 0;
                if (!invoice.IsColumnNull("TotalValue"))
                {
                    TotalValue = invoice.TotalValue;
                }
                if (_receiptInvoiceID != 0 && po.Remaining + TotalValue < Convert.ToDouble(txtTotalValue.EditValue)
                    && POType.GetModes(po.PurchaseType) == POType.STANDARD)
                {
                    XtraMessageBox.Show("Invoice value can't be be greater than Order value", "Invalid Value",
                        MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                invoice.TotalValue = Convert.ToDouble(txtTotalValue.EditValue);
                if (po.Remaining < invoice.TotalValue && POType.GetModes(po.PurchaseType) == POType.STANDARD &&
                    _receiptInvoiceID == 0)
                {
                    XtraMessageBox.Show("Invoice value can't be be greater than Order value", "Invalid Value",
                        MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }

                invoice.WayBillNo = txtWayBill.Text;
                invoice.TransitTransferNo = txtTransitNumber.Text;
                invoice.STVOrInvoiceNo = txtInvoiceNumber.Text;
                invoice.POID = _orderID;
                invoice.SavedByUserID = CurrentContext.UserId;
                invoice.AirFreight = Convert.ToDouble(txtInvoiceAirFreight.EditValue);
                invoice.SeaFreight = Convert.ToDouble(txtInvoiceSeaFreight.EditValue);
                invoice.InlandFreight = Convert.ToDouble(txtInvoiceInlandFreight.EditValue);
                invoice.CustomDutyTax = Convert.ToDouble(txtInvoiceCustomDutyTax.EditValue);
                invoice.CBE = Convert.ToDouble(txtInvoiceCBEServiceCharge.EditValue);
                invoice.InvoiceTypeID = Convert.ToInt32(lkInvoiceType.EditValue);
                invoice.DateOfEntry = Convert.ToDateTime(dtInvoiceDate.EditValue);
                invoice.ExchangeRate = Convert.ToDouble(txtExchangeRate.EditValue);
                invoice.LCID = Convert.ToInt32(lkCurrencyLCID.EditValue);
                invoice.ActivityID = po.StoreID;
                invoice.Rowguid = Guid.NewGuid();
                invoice.PrintedDate = dtInvoiceDate.DateTime;
                invoice.IsVoided = false ;
                invoice.ShippingSite = " ";
                invoice.IsConvertedFromDeliveryNote = false;
                invoice.IsDeliveryNote = Convert.ToInt32(lkDocumentType.EditValue) == DocumentType.CONSTANTS.DLVN;
                if (Convert.ToInt32(lkDocumentType.EditValue) != -1)
                    invoice.DocumentTypeID = Convert.ToInt32(lkDocumentType.EditValue);
                invoice.Save();
                this.LogActivity("Save-Invoice", invoice.ID);

                lblInvoiceNoDetail.Text = txtInvoiceNumber.EditValue.ToString();
                lblInvoiceTypeDetail.Text = lkInvoiceType.Text;

                BLL.Receipt receipt = new BLL.Receipt();
                receipt.UpdateInvoiceRelatedHeaders(invoice);
                _receiptInvoiceID = invoice.ID;
                MessageBox.Show("Invoice saved!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HeaderGroupDetail.Text = "Invoice No: " + txtInvoiceNumber.EditValue.ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReceiptInvoiceDialog_Load(object sender, EventArgs e)
        {
            InitializeForm();
            LayoutAndBindingByAccess();
            LoadDecimalFormatings();
            ConstructTableColumns();
            gridViewInvoiceDetail.RowStyle += new RowStyleEventHandler(gridInvoiceDetail_RowStyle);
            lkInvoiceType.Properties.DataSource = BLL.Settings.IsCenter
                ? ReceiptInvoiceType.GetAllInvoiceTypes()
                : ReceiptInvoiceType.GetAllInvoiceTypeByCode("INT"); //Internal for Hubs

            lkInvoiceType.EditValue = BLL.Settings.IsCenter ? -1 : ReceiptInvoiceType.InvoiceType.INTERNAL;
            lkCurrencyLCID.Properties.DataSource = Helpers.FormattingHelpers.GetCurrencyList();
            var etb = Convert.ToInt32(Helpers.FormattingHelpers.GetCurrencyList().ToTable().Select("Symbol = 'ETB'")[0]["ID"]);
            lkCurrencyLCID.EditValue = etb; //ETB is the default value

            PO Order = new PO(_orderID);

            if (_orderID != 0)
            {

                Activity act = new Activity();
                act.LoadByPrimaryKey(Order.StoreID);
                lblAccount.Text = act.AccountName;
                lblAccountDetail.Text = act.AccountName;
                lblSubAccount.Text = act.SubAccountName;
                lblSubAccountDetail.Text = act.SubAccountName;
                lblActivity.Text = act.Name;
                lblActivityDetail.Text = act.Name;

                lblPOType.Text = POType.GetPOTypeNameByID(Order.PurchaseType);
                lblPOTypeDetail.Text = POType.GetPOTypeNameByID(Order.PurchaseType);
                lblPONumberDetail.Text = Order.PONumber.ToString();


                //lblInvoiceNoDetail.Text =     

                var poStatus = new PurchaseOrderStatus();
                poStatus.LoadByPrimaryKey(Order.PurchaseOrderStatusID);
                lblOrderStatus.Text = poStatus.Name;

                var Mode = new Mode();
                Mode.LoadByPrimaryKey(Order.ModeID);
                lblMode.Text = Mode.TypeName;
                lblModeDetail.Text = Mode.TypeName;

                var receiptInvoice = new ReceiptInvoice();

                receiptInvoice.LoadForPO(_orderID);

                try
                {
                    lblInvoiceNoDetail.Text = !receiptInvoice.IsColumnNull("STVOrInvoiceNo") ? receiptInvoice.STVOrInvoiceNo : "-";
                }
                catch (Exception)
                {
                    lblInvoiceNoDetail.Text = "-";
                }
                var invoiceType = new ReceiptInvoiceType();
                HeaderGroup.Text = "PO No: " + Order.PONumber;
            }

            //documentType
            var po = new PO(_orderID);
            var documentTypes = BLL.DocumentType.GetDocumentTypesByPOType(po.PurchaseType);
            lkDocumentType.Properties.DataSource = documentTypes;

            lkDocumentType.EditValue = documentTypes.Rows.Count > 0 ? documentTypes.Rows[0]["DocumentTypeID"] : -1;

            if (_receiptInvoiceID != 0)
            {
                ReceiptInvoice rinvoice = new ReceiptInvoice(_receiptInvoiceID);
                //bind data to invoicedetail tab
                BindInvoiceDetail(rinvoice);

                lblOrderNumber.Text = rinvoice.PO.PONumber;

                lblSupplier.Text = rinvoice.PO.Supplier.IsActive ? rinvoice.PO.Supplier.CompanyName : "";
                lblRefNo.Text = rinvoice.PO.RefNo != "" ? rinvoice.PO.RefNo : "-";
                gridGrv.DataSource = rinvoice.Receipts.DefaultView;
                txtInsurance.Text = rinvoice.InsurancePolicyNo;
                txtInvoiceNumber.Text = rinvoice.STVOrInvoiceNo;
                txtTransitNumber.Text = rinvoice.TransitTransferNo;
                txtWayBill.Text = rinvoice.WayBillNo;
                dtInvoiceDate.EditValue = !rinvoice.IsColumnNull("DateofEntry")
                    ? rinvoice.DateOfEntry
                    : DateTimeHelper.ServerDateTime;
                txtTotalValue.EditValue = !rinvoice.IsColumnNull("TotalValue") ? rinvoice.TotalValue : 0;
                lkInvoiceType.EditValue = !rinvoice.IsColumnNull("InvoiceTypeID") ? rinvoice.InvoiceTypeID : 0;
                txtInvoiceAirFreight.EditValue = !rinvoice.IsColumnNull("AirFreight") ? rinvoice.AirFreight : 0;
                txtInvoiceSeaFreight.EditValue = !rinvoice.IsColumnNull("SeaFreight") ? rinvoice.SeaFreight : 0;
                txtInvoiceInlandFreight.EditValue = !rinvoice.IsColumnNull("InlandFreight") ? rinvoice.InlandFreight : 0;
                txtInvoiceCustomDutyTax.EditValue = !rinvoice.IsColumnNull("CustomDutyTax") ? rinvoice.CustomDutyTax : 0;
                txtInvoiceCBEServiceCharge.EditValue = !rinvoice.IsColumnNull("CBE") ? rinvoice.CBE : 0;
                txtExchangeRate.EditValue = !rinvoice.IsColumnNull("ExchangeRate") ? rinvoice.ExchangeRate : 1;
                lkCurrencyLCID.EditValue = _currency = !rinvoice.IsColumnNull("LCID") ? rinvoice.LCID : 0;
                lkDocumentType.EditValue = !rinvoice.IsColumnNull("DocumentTypeID") ? rinvoice.DocumentTypeID : -1;
                DisableEditDependingOnSetting();
                var activity = new Activity();
                activity.LoadByPrimaryKey(rinvoice.ActivityID);
                if (activity.IsHealthProgram())
                {
                    txtInvoiceCustomDutyTax.EditValue = 0;
                    txtInvoiceCustomDutyTax.Enabled = false;
                }

                // var receiptINvoice = new ReceiptInvoice();
                // receiptINvoice.LoadForPO(_orderID);
                lblInvoiceNoDetail.Text = rinvoice.STVOrInvoiceNo.ToString();
                lblInvoiceTypeDetail.Text = lkInvoiceType.Text;

            }
            else
            {
                PO PO = new PO(_orderID);
                lblOrderNumber.Text = PO.PONumber;

                BindInvoiceDetailByPO(PO.ID);

                lblSupplier.Text = PO.Supplier.IsActive ? PO.Supplier.CompanyName : "_";
                lkCurrencyLCID.EditValue = 1118; //ETB is the dafault
                lblRefNo.Text = PO.RefNo != "" ? PO.RefNo : "-";

                if (PO.StoreID != null)
                {
                    var activity = new Activity();
                    activity.LoadByPrimaryKey(po.StoreID);
                    if (activity.IsHealthProgram())
                    {
                        txtInvoiceCustomDutyTax.EditValue = 0;
                        txtInvoiceCustomDutyTax.Enabled = false;
                    }
                }
                layoutGoodsReceived.Enabled = false;
            }
            //gridViewInvoiceDetail.ValidateRow += GridViewInvoiceDetailOnValidateRow;
        }

        private bool ValidateReceiptInvoiceDetails()
        {
            bool valid = true;
            var receiptInvoiceDetails = ((DataView)gridViewInvoiceDetail.DataSource).ToTable();
            if (receiptInvoiceDetails == null || receiptInvoiceDetails.Rows.Count == 0)
            {
                XtraMessageBox.Show("Empty details! Please select fill order details first.", "Empty Details", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            gridViewInvoiceDetail.ClearColumnErrors();
            foreach (DataRow row in receiptInvoiceDetails.Rows)
            {
                if (row["InvoicedQty"] == DBNull.Value || Convert.ToDecimal(row["InvoicedQty"]) == 0)
                {
                    gridViewInvoiceDetail.SetColumnError(colInvoicedQty, @"Invoice quantity can not be empty or zero!");
                    valid = false; break;
                }
                else if (Convert.ToDecimal(row["InvoicedQty"]) > Convert.ToDecimal(row["OrderedQuantity"]))
                {
                    gridViewInvoiceDetail.SetColumnError(colInvoicedQty,
                        @"Invoice quantity is greater than ordered quantity");
                    valid = false; break;
                }
                else
                {
                    var guid = Convert.ToString(row["GUID"]);
                    var invoiceDetails = receiptInvoiceDetails.Select(string.Format("GUID = '{0}'", guid));
                    decimal invoiceQtySum = invoiceDetails.Sum(invoiceDetail => Convert.ToDecimal(invoiceDetail["InvoicedQty"]));

                    if (invoiceQtySum > Convert.ToDecimal(row["OrderedQuantity"]))
                    {
                        gridViewInvoiceDetail.SetColumnError(colInvoicedQty, @"Sum of invoice quantity is greater than ordered quantity");
                        valid = false; break;
                    }
                }

                if (row["UnitPrice"] == DBNull.Value)
                {
                    gridViewInvoiceDetail.SetColumnError(colUnitPrice, @"Unit price is empty");
                    valid = false;
                    break;
                }
                else if (Convert.ToDecimal(row["UnitPrice"]) > Convert.ToDecimal(row["OrderedAmount"]))
                {
                    gridViewInvoiceDetail.SetColumnError(colInvoicedQty, @"Unit price is greater than order total cost");
                    valid = false; break;
                }
            }

            return valid;

        }

        private void BindInvoiceDetailByPO(int POID)
        {
            _dtReceiptInvoiceDetail.Rows.Clear();
            var poDetail = new PurchaseOrderDetail();
            poDetail.LoadByPo(POID);
            foreach (DataRowView rowView in poDetail.DefaultView)
            {
                var newrow = _dtReceiptInvoiceDetail.NewRow();
                newrow["FullItemName"] = rowView["FullItemName"];
                newrow["Unit"] = rowView["Unit"];
                newrow["Manufacturer"] = rowView["Manufacturer"];
                newrow["OrderedQuantity"] = rowView["Quantity"];
                newrow["OrderedAmount"] = rowView["Amount"];
                newrow["ItemID"] = Convert.ToInt32(rowView["ItemID"]);
                newrow["UnitOfIssueID"] = Convert.ToInt32(rowView["UnitOfIssueID"]);
                newrow["ManufacturerID"] = Convert.ToInt32(rowView["PreferredManufacturerID"]);
                newrow["UnitPrice"] = 0;
                newrow["Margin"] = 0;
                newrow["IsSaved"] = false;
                newrow["GUID"] = Guid.NewGuid();
                _dtReceiptInvoiceDetail.Rows.Add(newrow);
            }

            _dtReceiptInvoiceDetail.DefaultView.Sort = "FullItemName, Unit, Manufacturer, ExpiryDate DESC, BatchNumber DESC";
            gridInvoiceDetail.DataSource = _dtReceiptInvoiceDetail;
        }

        private void BindInvoiceDetail(ReceiptInvoice receiptInvoice)
        {
            _dtReceiptInvoiceDetail.Rows.Clear();
            var receiptInvoiceDetail = new ReceiptInvoiceDetail();
            receiptInvoiceDetail.LoadByReceiptInvoice(receiptInvoice.ID);

            if (receiptInvoiceDetail.DefaultView.Count == 0)
            {
                BindInvoiceDetailByPO(receiptInvoice.POID);
            }
            else
            {
                receiptInvoiceDetail.LoadMergedPOAndInvoiceDetails(receiptInvoice.ID);
                foreach (DataRowView rowView in receiptInvoiceDetail.DefaultView)
                {
                    var newrow = _dtReceiptInvoiceDetail.NewRow();

                    newrow["FullItemName"] = rowView["FullItemName"];
                    newrow["Unit"] = rowView["Unit"];
                    newrow["Manufacturer"] = rowView["Manufacturer"];
                    newrow["OrderedQuantity"] = rowView["OrderedQuantity"];
                    newrow["OrderedAmount"] = rowView["Amount"];
                    newrow["ItemID"] = Convert.ToInt32(rowView["ItemID"]);
                    newrow["UnitOfIssueID"] = Convert.ToInt32(rowView["UnitOfIssueID"]);
                    newrow["ManufacturerID"] = Convert.ToInt32(rowView["ManufacturerID"]);
                    if (rowView["ExpiryDate"] != DBNull.Value)
                    {
                        newrow["ExpiryDate"] = Convert.ToDateTime(rowView["ExpiryDate"]);
                    }
                    newrow["IsSaved"] = false;
                    newrow["GUID"] = Guid.NewGuid();

                    if (rowView["InvoicedQuantity"] != DBNull.Value)
                    {
                        newrow["ReceiptInvoiceDetailID"] = Convert.ToInt32(rowView["ReceiptInvoiceDetailID"]);
                        newrow["ReceiptInvoiceID"] = Convert.ToInt32(rowView["ReceiptInvoiceID"]);

                        newrow["BatchNumber"] = rowView["BatchNumber"];
                        newrow["InvoicedQty"] = Convert.ToDecimal(rowView["InvoicedQuantity"]);
                        newrow["UnitPrice"] = Convert.ToDecimal(rowView["UnitPrice"]);
                        newrow["Margin"] = Convert.ToDecimal(rowView["Margin"]);
                        newrow["IsSaved"] = true;
                    }
                    else
                    {
                        newrow["UnitPrice"] = 0;
                        newrow["Margin"] = 0;
                    }


                    _dtReceiptInvoiceDetail.Rows.Add(newrow);
                }
                MergeReceiptInvoiceDetailGUID();
                _dtReceiptInvoiceDetail.DefaultView.Sort = "FullItemName, Unit, Manufacturer, ExpiryDate DESC, BatchNumber DESC";
                gridInvoiceDetail.DataSource = _dtReceiptInvoiceDetail;
                if (receiptInvoice.CheckIfThisInvoiceHasBeenReceived())
                {
                    gridInvoiceDetail.Enabled = btnSave.Enabled = false;
                    tabInvoice.SelectedTabPageIndex = 0;
                    XtraMessageBox.Show("This Invoice has a related Receive!,You can't edit in this case!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void DisableEditDependingOnSetting()
        {
            if (!ReceiptInvoice.IsInvoiceEditable(_receiptInvoiceID))
            {
                txtInsurance.Enabled = false;
                txtInvoiceNumber.Enabled = false;
                txtTransitNumber.Enabled = false;
                txtWayBill.Enabled = false;
            }

        }

        private void LoadDecimalFormatings()
        {
            string sharps = Helpers.FormattingHelpers.GetNumberFormatting();
            string displaySharpsBirr = Helpers.FormattingHelpers.GetBirrFormatting();
            string displayExchangeRate = Helpers.FormattingHelpers.GetExchangeRateFormatting();
            PO po = new PO(_orderID);
            string PoSharps = Helpers.FormattingHelpers.GetCurrencyFormatByLCID(po.LCID);

            //GRV Formating
            SetDisplayFormatAndEditMask(txtTotalValue, sharps,
                Helpers.FormattingHelpers.GetCurrencyFormatByLCID(Convert.ToInt32(_currency)));

            //Invoice Formating
            SetDisplayFormatAndEditMask(txtInvoiceAirFreight, sharps,
                Helpers.FormattingHelpers.GetCurrencyFormatByLCID(Convert.ToInt32(_currency)));
            SetDisplayFormatAndEditMask(txtInvoiceSeaFreight, sharps,
                Helpers.FormattingHelpers.GetCurrencyFormatByLCID(Convert.ToInt32(_currency)));
            SetDisplayFormatAndEditMask(txtInvoiceInlandFreight, sharps, displaySharpsBirr);
            SetDisplayFormatAndEditMask(txtInvoiceCBEServiceCharge, sharps, displaySharpsBirr);
            SetDisplayFormatAndEditMask(txtInvoiceCustomDutyTax, sharps, displaySharpsBirr);
        }

        private void SetDisplayFormatAndEditMask(TextEdit txtBox, string sharps, string displaySharps)
        {
            txtBox.Properties.DisplayFormat.FormatString = sharps;
            txtBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtBox.Properties.Mask.EditMask = sharps;
            txtBox.Properties.Mask.UseMaskAsDisplayFormat = false;
            txtBox.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtBox.Properties.DisplayFormat.FormatString = displaySharps;
            txtBox.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            txtBox.EditValue = 0.0;
            txtBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
        }

        private void lkInvoiceType_EditValueChanged(object sender, EventArgs e)
        {
            int InvoiceType = Convert.ToInt32(lkInvoiceType.EditValue);
            if (InvoiceType == ReceiptInvoiceType.InvoiceType.INVOICE_AIR)
            {

                txtTotalValue.Enabled = BLL.Settings.IsCenter;

                txtInvoiceAirFreight.Enabled = true;
                txtInvoiceSeaFreight.EditValue = 0;
                txtInvoiceSeaFreight.Enabled = false;
                txtInvoiceInlandFreight.EditValue = 0;
                txtInvoiceInlandFreight.Enabled = false;
                txtInvoiceCustomDutyTax.Enabled = true;
                txtInvoiceCBEServiceCharge.Enabled = true;
            }
            else if (InvoiceType == ReceiptInvoiceType.InvoiceType.INVOICE_SEA)
            {

                txtTotalValue.Enabled = BLL.Settings.IsCenter;

                txtInvoiceAirFreight.EditValue = 0;
                txtInvoiceAirFreight.Enabled = false;
                txtInvoiceSeaFreight.Enabled = true;
                txtInvoiceInlandFreight.Enabled = true;
                txtInvoiceCustomDutyTax.Enabled = true;
                txtInvoiceCBEServiceCharge.Enabled = true;

            }
            else if (InvoiceType == ReceiptInvoiceType.InvoiceType.CIP ||
                     InvoiceType == ReceiptInvoiceType.InvoiceType.LOCAL_PURCHASE)
            {

                txtTotalValue.Enabled = BLL.Settings.IsCenter;
                txtInvoiceAirFreight.EditValue = 0;
                txtInvoiceAirFreight.Enabled = false;

                txtInvoiceSeaFreight.EditValue = 0;
                txtInvoiceSeaFreight.Enabled = false;

                txtInvoiceInlandFreight.EditValue = 0;
                txtInvoiceInlandFreight.Enabled = false;

                txtInvoiceCustomDutyTax.EditValue = 0;
                txtInvoiceCustomDutyTax.Enabled = false;
                txtInvoiceCBEServiceCharge.EditValue = 0;
                txtInvoiceCBEServiceCharge.Enabled = false;

            }
            else if (InvoiceType == ReceiptInvoiceType.InvoiceType.INVENTORY)
            {

                txtTotalValue.EditValue = 0;
                txtTotalValue.Enabled = false;
                txtInvoiceAirFreight.EditValue = 0;
                txtInvoiceAirFreight.Enabled = false;

                txtInvoiceSeaFreight.EditValue = 0;
                txtInvoiceSeaFreight.Enabled = false;

                txtInvoiceInlandFreight.EditValue = 0;
                txtInvoiceInlandFreight.Enabled = false;

                txtInvoiceCustomDutyTax.EditValue = 0;
                txtInvoiceCustomDutyTax.Enabled = false;
                txtInvoiceCBEServiceCharge.EditValue = 0;
                txtInvoiceCBEServiceCharge.Enabled = false;


            }
            else if (InvoiceType == ReceiptInvoiceType.InvoiceType.STV)
            {
                txtTotalValue.Enabled = BLL.Settings.IsCenter;
                txtInvoiceAirFreight.EditValue = 0;
                txtInvoiceAirFreight.Enabled = false;

                txtInvoiceSeaFreight.EditValue = 0;
                txtInvoiceSeaFreight.Enabled = false;

                txtInvoiceInlandFreight.EditValue = 0;
                txtInvoiceInlandFreight.Enabled = false;

                txtInvoiceCustomDutyTax.EditValue = 0;
                txtInvoiceCustomDutyTax.Enabled = false;
                txtInvoiceCBEServiceCharge.EditValue = 0;
                txtInvoiceCBEServiceCharge.Enabled = false;


            }

            PO PO = new PO(_orderID);
            if (PO.StoreID != null)
            {
                var activity = new Activity();
                activity.LoadByPrimaryKey(PO.StoreID);
                if (activity.IsHealthProgram())
                {
                    txtInvoiceCustomDutyTax.EditValue = 0;
                    txtInvoiceCustomDutyTax.Enabled = false;
                }
            }
        }

        private void lkCurrencyLCID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                _currency = Convert.ToInt32(lkCurrencyLCID.EditValue);
                txtInvoiceAirFreight.Properties.DisplayFormat.FormatString =
                    Helpers.FormattingHelpers.GetCurrencyFormatByLCID(Convert.ToInt32(_currency));
                txtInvoiceSeaFreight.Properties.DisplayFormat.FormatString =
                    Helpers.FormattingHelpers.GetCurrencyFormatByLCID(Convert.ToInt32(_currency));
            }
            catch
            {


            }

        }

        private void LayoutAndBindingByAccess()
        {
            if (InvoiceAccessMode == AccessMode.Finance)
            {
                txtInvoiceNumber.Enabled = true;
                txtWayBill.Enabled = true;
                dtInvoiceDate.Enabled = true;
                txtTransitNumber.Enabled = true;
            }
            else
            {
                layoutFinancialInformation.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            if (!BLL.Settings.IsCenter)
            {
                txtWayBill.Enabled = txtInsurance.Enabled = txtTransitNumber.Enabled = txtTotalValue.Enabled = false;
                colMargin.OptionsColumn.AllowEdit =
                    colUnitPrice.OptionsColumn.AllowEdit = colTotalCost.OptionsColumn.AllowEdit = false;
                colMargin.AppearanceCell.BackColor =
                    colUnitPrice.AppearanceCell.BackColor =
                        colTotalCost.AppearanceCell.BackColor =
                            colMargin.AppearanceCell.BackColor = Color.WhiteSmoke;
            }
        }

        private void btnCancelInvoice_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isSaved = false;
            if (_receiptInvoiceID != 0)
            {
                if (!ValidateReceiptInvoiceDetails())
                {
                    return;
                }
                _dtReceiptInvoiceDetail = gridInvoiceDetail.DataSource as DataTable;
                var invoiceDetail = new ReceiptInvoiceDetail();

                foreach (DataRow dr in _dtReceiptInvoiceDetail.Rows)
                {
                    if (dr["InvoicedQty"] == DBNull.Value)
                    {
                        continue;
                    }

                    var itemID = Convert.ToInt32(dr["ItemID"]);

                    if (dr["ReceiptInvoiceDetailID"] == DBNull.Value)
                    {
                        invoiceDetail.AddNew();
                    }
                    else
                    {
                        invoiceDetail.LoadByPrimaryKey(Convert.ToInt32(dr["ReceiptInvoiceDetailID"]));
                    }

                    invoiceDetail.ItemID = itemID;
                    invoiceDetail.UnitOfIssueID = Convert.ToInt32(dr["UnitOfIssueID"]);
                    invoiceDetail.ManufacturerID = Convert.ToInt32(dr["ManufacturerID"]);
                    invoiceDetail.ReceiptInvoiceID = _receiptInvoiceID;

                    if (dr["ExpiryDate"] != DBNull.Value)
                    {
                        invoiceDetail.ExpiryDate = Convert.ToDateTime(dr["ExpiryDate"]);
                    }

                    invoiceDetail.BatchNumber = Convert.ToString(dr["BatchNumber"]);
                    invoiceDetail.UnitPrice = dr["UnitPrice"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["UnitPrice"]);
                    invoiceDetail.Quantity = Convert.ToDecimal(dr["InvoicedQty"]);
                    invoiceDetail.Margin = dr["Margin"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["Margin"]);
                    invoiceDetail.Rowguid = Guid.NewGuid();

                    invoiceDetail.Save();
                    dr["IsSaved"] = isSaved = true;
                }
                if (isSaved)
                {
                    MessageBox.Show("Invoice details saved!", "Confirmation", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(@"The invoice details are not attached to any invoice. Please first save the invoice.",
                    @"No Invoice", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridInvoiceDetail_RowStyle(object sender, RowStyleEventArgs e)
        {
            var view = sender as GridView;
            if (e.RowHandle >= 0 && view != null)
            {
                var isSaved = view.GetRowCellValue(e.RowHandle, view.Columns["IsSaved"]);
                e.Appearance.BackColor = (isSaved != null && (bool)isSaved) ? Color.White : Color.LightBlue;//for saved receiptInvoiceDetails use background color = White else CornflowerBlue
            }

        }

        private void gridViewInvoiceDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var view = sender as GridView;
            {
                if (view.FocusedColumn.FieldName == "Margin")
                {
                    DataRow dr = gridViewInvoiceDetail.GetDataRow(gridViewInvoiceDetail.GetSelectedRows()[0]);
                    decimal margin = Convert.ToDecimal(dr["Margin"]);
                    if (margin >= 1) dr["Margin"] = Convert.ToDecimal(Convert.ToDouble(margin) * 0.01);
                }
            }

        }

        private void plusMinusButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                DataRow dr = gridViewInvoiceDetail.GetDataRow(gridViewInvoiceDetail.GetSelectedRows()[0]);
                DataRow drNew = _dtReceiptInvoiceDetail.NewRow();
                drNew.ItemArray = dr.ItemArray;
                drNew["GUID"] = dr["GUID"];
                drNew["IsSaved"] = false;
                drNew["ReceiptInvoiceDetailID"] = DBNull.Value;
                drNew["BatchNumber"] = DBNull.Value;
                drNew["InvoicedQty"] = DBNull.Value;

                _dtReceiptInvoiceDetail.Rows.Add(drNew);
                _dtReceiptInvoiceDetail.DefaultView.Sort = "FullItemName, Unit, Manufacturer, ExpiryDate DESC, BatchNumber DESC";
            }
            else
            {
                DataRow dr = gridViewInvoiceDetail.GetDataRow(gridViewInvoiceDetail.GetSelectedRows()[0]);

                if (Convert.ToBoolean(dr["IsSaved"]))
                {
                    if (
                        XtraMessageBox.Show(@"Are you sure you want to delete the detail from the database?",
                            @"Confirmation", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        var receiptInvoiceDetail = new ReceiptInvoiceDetail();
                        receiptInvoiceDetail.DeleteReceiptInvoiceDetail(Convert.ToInt32(dr["ReceiptInvoiceDetailID"]));
                        _dtReceiptInvoiceDetail.Rows.Remove(dr);
                    }
                }
                else
                {
                    _dtReceiptInvoiceDetail.Rows.Remove(dr);
                }
            }
        }

        private void gridViewInvoiceDetail_CellMerge(object sender, CellMergeEventArgs e)
        {
            if (!(e.Column == colItemName || e.Column == colUnit || e.Column == colManufacturer || e.Column == colOrderdQuantity))
                return;
            var guid1 = gridViewInvoiceDetail.GetRowCellValue(e.RowHandle1, colguid).ToString();
            var guid2 = gridViewInvoiceDetail.GetRowCellValue(e.RowHandle2, colguid).ToString();
            e.Merge = guid1 == guid2;
            e.Handled = true;

        }

        private void MergeReceiptInvoiceDetailGUID()
        {
            var receiptInvoiceDetailDataView = new DataView(_dtReceiptInvoiceDetail);
            var distinctValues = receiptInvoiceDetailDataView.ToTable(true, "ItemID", "UnitOfIssueID", "ManufacturerID");
            foreach (DataRow row in distinctValues.Rows)
            {
                var guid =
                    _dtReceiptInvoiceDetail.Select(
                        string.Format("ItemID = {0} AND UnitOfIssueID = {1} AND ManufacturerID = {2}",
                            Convert.ToInt32(row["ItemID"]), Convert.ToInt32(row["UnitOfIssueID"]),
                            Convert.ToInt32(row["ManufacturerID"])))[0]["GUID"];
                _dtReceiptInvoiceDetail.Select(string.Format("ItemID = {0} AND UnitOfIssueID = {1} AND ManufacturerID = {2}",
                    Convert.ToInt32(row["ItemID"]), Convert.ToInt32(row["UnitOfIssueID"]), Convert.ToInt32(row["ManufacturerID"]))).ToList<DataRow>().ForEach(r => r["GUID"] = guid);

            }
        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void lblPONumber_Click(object sender, EventArgs e)
        {

        }

        private void lblAccount_Click(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click_1(object sender, EventArgs e)
        {

        }

        private void gridInvoiceDetail_Click(object sender, EventArgs e)
        {

        }

        private void lblPONumberDetail_Click(object sender, EventArgs e)
        {

        }

        private void lblPoType_Click(object sender, EventArgs e)
        {

        }

        private void txtInvoiceSeaFreight_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}

