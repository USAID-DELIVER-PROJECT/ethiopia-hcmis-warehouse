using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BLL;

namespace HCMIS.Desktop.Forms.Modals.Finance
{
    public partial class SellingPriceValidation : DevExpress.XtraEditors.XtraForm
    {

        public PreviousCostPricingDetails PreviousStockDetails;
        
        
        public SellingPriceValidation()
        {
            InitializeComponent();
        }

        public SellingPriceValidation(PreviousCostPricingDetails Details)
        {
            InitializeComponent();
            this.PreviousStockDetails = Details;
        }

      
        private void PricePerPackPage_Load(object sender, EventArgs e)
        {
            LoadAndBind();
            //Incase the user Closes the form in other Method Than the 2 available but
            //the Default Dialog Result return should be Cancel
              
        }
        /// <summary>
        /// Load All Neccessary Data and Bind To DataSource
        /// </summary>
        void LoadAndBind()
        {
            //Bind
        
            //Load Detail Table To Grid
            gridStock.DataSource = PreviousStockDetails.PreviousStock;
            gridIssueOrder.DataSource = PreviousStockDetails.Picklist;
            gridDeliveryNote.DataSource = PreviousStockDetails.DeliveryNote;
            //Load Header Information From first row to be displayed
                txtStockCode.EditValue = PreviousStockDetails.StockCode;
                txtItemName.EditValue = PreviousStockDetails.ItemName;
                txtItemUnit.EditValue = PreviousStockDetails.ItemUnit;
                txtManufacturerName.EditValue = PreviousStockDetails.ManufacturerName;
                txtActivityName.EditValue = PreviousStockDetails.ActivityName;
        }

        private bool ValidateMovingAverage()
        {
            return true;
        }
        private void DisplayErrorIfAverageHasChanged()
        {
            if (PreviousStockDetails.HasAverageCostChanged)
                lblErrorMessage.Text = @"Since the Last Average Cost Calculation, the Stock On Hand has changed which will result in a different Average Cost.
                                            It recommended that you return back to Costing and recalculate the average Cost.Continuing With the current Average Cost may lead to Loss";

        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (ValidateMovingAverage())//Check Moving Average change in between
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        
    }
}