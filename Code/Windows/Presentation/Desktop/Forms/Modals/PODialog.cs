using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BLL;
using DevExpress.DataAccess.Native.DB;
using DevExpress.XtraEditors;
using HCMIS.Desktop.Helpers;
using HCMIS.Desktop.ViewHelpers;

namespace HCMIS.Desktop.Forms.WorkFlow
{
    public partial class PODialog : XtraForm
    {
        private int PoID = 0;
        int LCID = 0x0409;

        public PODialog(int poid)
        {
            PoID = poid;
            InitializeComponent();
            this.LogActivity("Open-Purchase-Order-Dialog", poid);
        }

        private void btnSaveOrder_Click(object sender, EventArgs e)
        {
            if (dxValidation.Validate())
            {
                var po = new PO();
                if (PoID != 0)
                {
                    po.LoadByPrimaryKey(PoID);
                }
                else
                {
                    po.AddNew();
                }
                if (PoID == 0 && po.DoesPONumberExists(txtOrderInformation.Text))
                {
                    XtraMessageBox.Show(string.Format(@"There is an existing Order with the same OrderNo as {0}. Please try to use another OrderNo!",txtOrderInformation.Text), "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (PoID == 0) po.PONumber = txtOrderInformation.Text;
                po.TotalValue = Convert.ToDouble(txtTotalValue.EditValue);
                po.Insurance = Convert.ToDouble(txtInsurance.EditValue);
                po.OtherExpense = Convert.ToDouble(txtInsuredSum.EditValue);
                po.NBE = Convert.ToDouble(txtNBEServiceCharge.EditValue);
                po.SupplierID = Convert.ToInt32(lkSupplier.EditValue);
                po.SavedbyUserID = CurrentContext.LoggedInUser.ID;
                //Make PurchaseType Default Value to Internale ID = 8
                //po.PurchaseType = Convert.ToInt32(gridLkEditOrderType.EditValue) == 0 || Convert.ToInt32(gridLkEditOrderType.EditValue) == null ? POType.GetAllPOTypes().Find(pot=>pot.ID == POType.INTERNAL).ID : Convert.ToInt32(gridLkEditOrderType.EditValue);
                po.PurchaseType =  Convert.ToInt32(gridLkEditOrderType.EditValue);
                po.StoreID = Convert.ToInt32(grdLkEditAccounts.EditValue);
                po.ExhangeRate =Convert.ToDouble(txtExchangeRate.EditValue);
                po.RefNo = txtRefNo.EditValue.ToString();
                
                po.Delivery = txtDelivery.EditValue != null ? txtDelivery.EditValue.ToString() : "";
                if (txtFreight.EditValue != null)
                {
                    po.AirFreight = Convert.ToDouble(txtFreight.EditValue);
                }
                po.Description = txtDescription.EditValue != null ? txtDescription.EditValue.ToString() : "";

                var serverDateTime = DateTimeHelper.ServerDateTime;
                po.PODate = serverDateTime;
                po.DateOfEntry = serverDateTime;
                po.LCID = Convert.ToInt32(lkCurrencyLCID.EditValue);
                //Make TermOfPayment Default to Internal , ID = 7, 
                //po.TermOfPayement = Convert.ToInt32(lkTermOfPayement.EditValue) == 0 || Convert.ToInt32(lkTermOfPayement.EditValue) == null ? TermOfPayment.List[6].ID : Convert.ToInt32(lkTermOfPayement.EditValue);
                po.TermOfPayement = Convert.ToInt32(lkTermOfPayement.EditValue) == 0 || Convert.ToInt32(lkTermOfPayement.EditValue) == null ? PaymentTerm.Internal : Convert.ToInt32(lkTermOfPayement.EditValue);
                po.PaymentTypeID = PaymentType.Constants.STV;
                po.PurchaseOrderStatusID = PurchaseOrderStatus.Processed; //PurchaseOrderStatus ==> Processed
               
                po.IsElectronic = false;
                po.POFinalized = false;
                po.Rowguid = Guid.NewGuid();
                po.Identifier = "00000";
               
                var acc = new Activity();
                acc.LoadByPrimaryKey(po.StoreID);
                po.ModeID = acc.ModeID;
                po.Save();
               
                this.LogActivity("Save-PO", po.ID);
                this.DialogResult = DialogResult.Yes;
                this.Close();
               
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PODialog_Load(object sender, EventArgs e)
        {
            //lookups         
            var poTypes = BLL.Settings.IsCenter ? POType.GetAllPOTypes() : POType.GetAllPOTypesForHub();
            var defaultPOTypeID = poTypes!=null && poTypes.Count > 0 ? poTypes.FirstOrDefault().ID:-1;
            //lookups          

            gridLkEditOrderType.Properties.DataSource = poTypes;

            var suppliers = Supplier.GetSuppliersByPOType(defaultPOTypeID);
            lkSupplier.Properties.DataSource = suppliers.DefaultView;
            lkSupplier.EditValue = suppliers.Rows.Count > 0? Convert.ToInt32(suppliers.Rows[0]["ID"]):-1;

            if (!BLL.Settings.IsCenter)
            {
                lkTermOfPayement.Enabled =
                    txtFreight.Enabled =
                    txtTotalValue.Enabled =
                    txtInsurance.Enabled = txtInsuredSum.Enabled = txtNBEServiceCharge.Enabled = false;
                gridLkEditOrderType.EditValue = POType.MANUAL_DELIVERYNOTE;
            }
            
            lkCurrencyLCID.Properties.DataSource = Helpers.FormattingHelpers.GetCurrencyList();
            var etb =Convert.ToInt32(Helpers.FormattingHelpers.GetCurrencyList().ToTable().Select("Symbol = 'ETB'")[0]["ID"]);

            lkCurrencyLCID.EditValue = etb; //ETB is the default value
            grdLkEditAccounts.SetupActivityEditor().SetDefaultActivity();
            lkTermOfPayement.Properties.DataSource = TermOfPayment.List;
            LoadDecimalFormatings();
            txtExchangeRate.EditValue = 1;
            if (PoID != 0)
            {
                LoadPurchaseOrderForEdit();
            }
        }

        private void LoadPurchaseOrderForEdit()
        {
            
            PO po = new PO();
            po.LoadByPrimaryKey(PoID);

            //TODO: Populate the data 
            if (!po.IsColumnNull("Insurance"))
                 txtInsurance.EditValue = po.Insurance;
        
            txtOrderInformation.EditValue = po.PONumber;
            if (!po.IsColumnNull("TotalValue"))
                txtTotalValue.EditValue = po.TotalValue;
            if (!po.IsColumnNull("SupplierID"))
                lkSupplier.EditValue = po.SupplierID;
            if (!po.IsColumnNull("PurchaseType"))
                gridLkEditOrderType.EditValue = po.PurchaseType;
            if (!po.IsColumnNull("StoreID"))
                grdLkEditAccounts.EditValue = po.StoreID;
            
            if (!po.IsColumnNull("LCID"))
                LCID = po.LCID;
            //Currency and Formating 
            lkCurrencyLCID.EditValue = LCID;
                txtTotalValue.Properties.DisplayFormat.FormatString = Helpers.FormattingHelpers.GetCurrencyFormatByLCID(Convert.ToInt32(LCID));

            if(!po.IsColumnNull("NBE"))
                txtNBEServiceCharge.EditValue = po.NBE;
            if (!po.IsColumnNull("ExhangeRate"))
                txtExchangeRate.EditValue = po.ExhangeRate;
            if (po.s_OtherExpense != "")
                txtInsuredSum.EditValue = po.OtherExpense;
            if (!po.IsColumnNull("RefNo"))
                txtRefNo.EditValue = po.RefNo;
            if (!po.IsColumnNull("Delivery"))
                txtDelivery.EditValue = po.Delivery;
            if (!po.IsColumnNull("Description"))
                txtDescription.EditValue = po.Description;
            if (!po.IsColumnNull("TermOfPayement"))
                lkTermOfPayement.EditValue = po.TermOfPayement;
            if (!po.IsColumnNull("AirFreight"))
                txtFreight.EditValue = po.AirFreight;
            DisableEditDependingOnSetting();
        }

        private void DisableEditDependingOnSetting()
        {
            if (!PO.IsPOEditable(PoID))
            {
                 txtOrderInformation.Enabled = false;
                 lkSupplier.Enabled = false;
                 grdLkEditAccounts.Enabled = false;
            }

        }

        private void LoadDecimalFormatings()
        {
            string sharps = Helpers.FormattingHelpers.GetNumberFormatting();
            string displaySharpsBirr = Helpers.FormattingHelpers.GetBirrFormatting();
            string displaySharpsPercent = Helpers.FormattingHelpers.GetPercentFormatting();
            string displayExchangeRate = Helpers.FormattingHelpers.GetExchangeRateFormatting();

            SetDisplayFormatAndEditMask(txtNBEServiceCharge,sharps,displaySharpsBirr);
            SetDisplayFormatAndEditMask(txtInsurance, sharps, displaySharpsBirr);
            SetDisplayFormatAndEditMask(txtInsuredSum, sharps, displaySharpsBirr);
            SetDisplayFormatAndEditMask(txtTotalValue, sharps, sharps);
            SetDisplayFormatAndEditMask(txtFreight, sharps, displaySharpsBirr);
            SetDisplayFormatAndEditMask(txtExchangeRate, Helpers.FormattingHelpers.GetExchangeRateFormatting(), Helpers.FormattingHelpers.GetExchangeRateFormatting());
          
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

        private void lkCurrency_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                LCID = Convert.ToInt32(lkCurrencyLCID.EditValue);
            }
            catch
            {

            }
                txtTotalValue.Properties.DisplayFormat.FormatString = Helpers.FormattingHelpers.GetCurrencyFormatByLCID(Convert.ToInt32(LCID));
            
        }

        private void gridLkEditOrderType_EditValueChanged(object sender, EventArgs e)
        {
            if (gridLkEditOrderType.EditValue == null) return;

            var poTypeID = Convert.ToInt32(gridLkEditOrderType.EditValue);

            var suppliers = Supplier.GetSuppliersByPOType(poTypeID);
                lkSupplier.Properties.DataSource = suppliers.DefaultView;

            if (poTypeID == POType.MANUAL_DELIVERYNOTE)
            {

                if (InstitutionIType.IsVaccine(GeneralInfo.Current))
                {
                    var centerCold = suppliers.AsEnumerable().FirstOrDefault(t => t.Field<int>("SN") == 400034);
                    lkSupplier.EditValue = centerCold != null ? centerCold.Field<int>("ID") : -1;
                }
                else
                {
                    var centerCold = suppliers.AsEnumerable().FirstOrDefault(t => t.Field<int>("SN") == 400006);
                    lkSupplier.EditValue = centerCold != null ? centerCold.Field<int>("ID") : -1;
                }
            }
            else
            {
                var directVendorSuppliers = Supplier.GetDirectVendorSuppliers();
                lkSupplier.Properties.DataSource = directVendorSuppliers.DefaultView;
                lkSupplier.EditValue = directVendorSuppliers.Rows.Count > 0 ? Convert.ToInt32(directVendorSuppliers.Rows[0]["ID"]) : -1;
            
            }
            
            txtInsurance.Enabled = txtNBEServiceCharge.Enabled = poTypeID != POType.CIP;
        }
    }
}
