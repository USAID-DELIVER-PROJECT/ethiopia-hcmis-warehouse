using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BLL;
using System.Threading;

namespace HCMIS.Desktop.Forms.Modals
{
    public partial class CostSheet : DevExpress.XtraEditors.XtraForm
    {
        ReceivedSummary rs;
        private int ItemID;
        private int ManufacturerID;
        private int UnitID;
        private int SupplierID;
        private int StoreID;
        private bool confirmation;
        public CostSheet()
        {
            InitializeComponent();
        }
        //Load Item Depending on the ManufacturerID
        public CostSheet(int ItemID, int ManufacturerID,int SupplierID, int UnitID, int StoreID,bool confirmation)
        {
            //Load The neccessary Information
            this.ItemID = ItemID;
            this.ManufacturerID = ManufacturerID;
            this.UnitID = UnitID;
            this.StoreID = StoreID;
            this.SupplierID = SupplierID;
            this.confirmation = confirmation;
            InitializeComponent();
        }
        public void SetID(int ItemID, int ManufacturerID, int UnitID, int StoreID)
        {
            //Load The neccessary Information
            this.ItemID = ItemID;
            this.ManufacturerID = ManufacturerID;
            this.UnitID = UnitID;
            this.StoreID = StoreID;

            InitializeComponent();
        }
        private void CostSheet_Load(object sender, EventArgs e)
        {
            bandSellingPrice.Visible = !BLL.Settings.IsCenter;

            LoadMaster();
            LoadDetail();
        }
       
        private void LoadMaster()
        {
            //Populate Item Name
            Item item = new Item();
            item.LoadByPrimaryKey(ItemID);
            txtitem.Text = item.FullItemName;
            
            //Populate Manufacturer
            Manufacturer mf = new Manufacturer();
            mf.LoadByPrimaryKey(ManufacturerID);
            txtManufacturer.Text = mf.Name;

            //Populate Unit
            ItemUnit unit = new ItemUnit();
            unit.LoadByPrimaryKey(UnitID);
            txtUnit.Text = unit.Text;

            //Populate Account
            Account Account = new Account();
            Account.LoadByPrimaryKey(StoreID);
            txtAccount.Text = Account.Name;
            if(BLL.Settings.IsCenter)
            layoutSellingPrice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }
        private void LoadDetail()
        {
            LoadDecimalFormatings();
            rs = new ReceivedSummary();

            gridCostSheet.DataSource = rs.MovingAverageTable(ItemID,StoreID,SupplierID, ManufacturerID, UnitID);
            txtAverageCost.EditValue = rs.NewUnitCost;
            txtMargin.EditValue = rs.Margin;
            txtSellingPrice.EditValue = rs.NewSellingPrice;
         //   .EditValue = rs.NewSellingPrice;
        }

        private void LoadDecimalFormatings()
        {
            string sharps = Helpers.FormattingHelpers.GetNumberFormatting();
            colCost.DisplayFormat.FormatString = "ETB " + sharps;
            colCQty.DisplayFormat.FormatString = sharps;
            colCTotal.DisplayFormat.FormatString = "ETB " + sharps;
            colInsurance.DisplayFormat.FormatString = "ETB " + sharps;

        }


        private void btnSave_Click(object sender, EventArgs e)
        {    ReceiveDoc rd = new ReceiveDoc();
            if (!confirmation)
            {
                rs.NewUnitCost = Convert.ToDouble(txtAverageCost.EditValue);
                rs.Margin = Convert.ToDouble(txtMargin.EditValue);
                rs.NewSellingPrice = Convert.ToDouble(txtSellingPrice.EditValue);
                rs.NewPrice = rs.NewSellingPrice;
            
                // set the item as  weighted average item
                Item itm = new Item();
                itm.LoadByPrimaryKey(ItemID);
                itm.IsFree = false;

                itm.Save();

                rd.SavePrice(rs, CurrentContext.UserId);

                //if (!StoreType.IsFreeStore(StoreID))
                //{
                //    //Change the cost
                //    rs.NewCost = rs.NewUnitCost;
                //    rd.SaveNewCost(rs, NewMainWindow.UserId);
                //}

                //-----------
                XtraMessageBox.Show("New Price setting has been saved.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                rd.ConfirmMovingAverage(rs, CurrentContext.UserId);

            }
            this.Close();
        }

        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtSellingPrice.EditValue) != (Convert.ToDouble(txtAverageCost.EditValue) * (1 + Convert.ToDouble(txtMargin.EditValue))))
            {
                txtMargin.EditValue = (Convert.ToDouble(txtSellingPrice.EditValue) / Convert.ToDouble(txtAverageCost.EditValue) ) - 1;
             
            }
            else if (Convert.ToDouble(txtSellingPrice.EditValue) == (Convert.ToDouble(txtAverageCost.EditValue) * (1 + Convert.ToDouble(txtMargin.EditValue))))
            {
                RePrice_Click(null, null);
            }
        }

        private void RePrice_Click(object sender, EventArgs e)
        {

         
            DataView dv = (DataView) gridCostSheet.DataSource;
          foreach(DataRowView drv in dv )
          {
              drv["NUnitCost"] = Convert.ToDouble(txtAverageCost.EditValue);
              drv["MarginETB"] = Convert.ToDouble(txtAverageCost.EditValue) * Convert.ToDouble(txtMargin.EditValue);
              drv["Margin"] = Convert.ToDouble(txtMargin.EditValue);
              drv["NUnitPrice"] = Convert.ToDouble(txtSellingPrice.EditValue);
              drv["NTotalPrice"] = Convert.ToDouble(txtSellingPrice.EditValue) * Convert.ToInt32(drv["NQuantity"]);
              drv["NTotalCost"] = Convert.ToDouble(txtAverageCost.EditValue) * Convert.ToInt32(drv["NQuantity"]);
          
          }

        }

        private void txtAverageCost_EditValueChanged(object sender, EventArgs e)
        {
            txtSellingPrice.EditValue = Convert.ToDouble(txtAverageCost.EditValue) * (1 + Convert.ToDouble(txtMargin.EditValue));
         
        }

        private void Margin_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtSellingPrice.EditValue) != (Convert.ToDouble(txtAverageCost.EditValue) * (1 + Convert.ToDouble(txtMargin.EditValue))))
            {
                txtSellingPrice.EditValue = Convert.ToDouble(txtAverageCost.EditValue) * (1 + Convert.ToDouble(txtMargin.EditValue));
              
            }
        
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.EditValue == "All")
            {
                bandCostCalculation.Visible = true;
                bandMovingAverage.Visible = true;
                bandSellingPrice.Visible = !BLL.Settings.IsCenter;
            }
            else if (radioGroup1.EditValue == "Moving Average")
            {
                bandCostCalculation.Visible = false;
                bandMovingAverage.Visible = true;
                bandSellingPrice.Visible = !BLL.Settings.IsCenter;
            }
            else
            {
                bandCostCalculation.Visible = true;
                bandMovingAverage.Visible = false;
                bandSellingPrice.Visible = false;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printableComponentLink1.ShowPreview();
           
          
        }
    }
}