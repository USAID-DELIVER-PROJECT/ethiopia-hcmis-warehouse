using System;
using System.Data;
using System.Windows.Forms;
using BLL.Models;
using DevExpress.XtraEditors;
using BLL;
using DevExpress.XtraGrid.Views.Grid;
using HCMIS.Core.Finance.CostTier.Services;
using HCMIS.Desktop.Helpers;
using HCMIS.Helpers;
using HCMIS.Desktop.Forms.Modals;
using HCMIS.Core.Finance.CostTier;
using HCMIS.Specification.Finance.CostTier;

namespace HCMIS.Desktop.Forms.WorkFlow
{
    [Obsolete("Replace by PriceOveride Form")]
    [FormIdentifier("CM-CM-FV-FR-Center","Moving Average","")]
    public partial class PriceSettings : DevExpress.XtraEditors.XtraForm
    {
        
        
        bool isConfirmation;
        //True if the Finance Manager is has Open the Page, false if Fund Officer Opens Page
        ReceivedSummary rs = new ReceivedSummary();
        private CostElement costElement;
        
        public PriceSettings()
        {
            InitializeComponent();
        }
  
        private void PriceSettings_Load(object sender, EventArgs e)
        {
            SetPermission();
            LoadDecimalFormatings();
            var movingAverageGroup = new MovingAverageGroup();
            movingAverageGroup.LoadByUser(CurrentContext.UserId);
            lkAccount.Properties.DataSource = movingAverageGroup.DefaultView;
            ChangeLayoutByMode();
            ChangeLayoutByItemListedtype(); 
            if (!BLL.Settings.IsCenter)
            {
                XtraMessageBox.Show("This Costing Page is Only Applicable For Center Costing", "User Management Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Enabled = false;
                return;
            }
        }

        private void SetPermission()
        {
            if (BLL.Settings.UseNewUserManagement)
            {
                btnSetNewPrice.Enabled = this.HasPermission("Set-Price");
                btnPrintPriceList.Enabled = this.HasPermission("Print-Price-List");
                btnHistory.Enabled = this.HasPermission("See-History");
            }
        }

        #region Select Screen mode

        public void rgPricing_EditValueChanged(object sender, EventArgs e)
        {
            rs.StoreID = Convert.ToInt32(lkAccount.EditValue);
            ReceiveDoc rd = new ReceiveDoc();
          //Populate Left Grid depending on the 
            if (rgPricingMode.EditValue.ToString() == "Items")
                rd.LoadAllNonPricedItems(rs.StoreID, isConfirmation);
           else if (rgPricingMode.EditValue.ToString() == "AllItems")
               rd.LoadAllPricedReceives(rs.StoreID);
            
            gridMainLeft.MainView = gridItemView;
            gridMainLeft.DataSource = rd.DefaultView;
            (gridMainLeft.MainView as GridView).ExpandAllGroups();

            ChangeLayoutByMode();
        }   
   
        #endregion

        #region Select An item

        private void BindDetails(DataRow dr)
        {
           // txtAdditionalCost.EditValue = 0;
            //txtMargin.EditValue = 100;
            try 
            { 
                Convert.ToInt16(dr["ItemID"]); 
            }
            catch
            {
                ResetForm();
                return;
            }

            if (dr != null)
            {
                costElement = new CostElement(Convert.ToInt32(dr["ItemID"]), Convert.ToInt32(lkAccount.EditValue),Convert.ToInt32(dr["ManufacturerID"]), Convert.ToInt32(dr["UnitID"]));
                
                //ToDo Remove ReceivedSummary ItemId and Stuff with CostElement
                rs = new ReceivedSummary();
                ReceiveDoc rd = new ReceiveDoc();
                rs.ItemID = Convert.ToInt32(dr["ItemID"]);
                rs.SupplierID = Convert.ToInt32(dr["SupplierID"]);
                rs.ManufacturerID = Convert.ToInt32(dr["ManufacturerID"]);
                rs.UnitID= null;
                if (dr["UnitID"] != DBNull.Value)
                {
                    rs.UnitID = Convert.ToInt32(dr["UnitID"]);
                }
                rs.StoreID = Convert.ToInt32(lkAccount.EditValue);

                // TODO: fix this ( Remove ) try cache
                try
                {
                    txtUnit.Text = dr["Unit"].ToString();
                }
                catch
                {

                }

                txtItemName.Text = dr["FullItemName"].ToString();
                txtManufacturer.Text = dr["Manufacturer"].ToString();

                rd.LoadForPricing(rs.ItemID, rs.SupplierID,rs.StoreID, rs.ManufacturerID, rs.UnitID);
                gridAllSimilarItems.DataSource = rd.DefaultView;



                LoadDecimalFormatings();
                
                rs.MovingAverageTable(rs.ItemID, rs.StoreID,rs.SupplierID, rs.ManufacturerID, rs.UnitID);
                txtAverageCost.EditValue = rs.NewUnitCost;
                txtMargin.EditValue = rs.Margin;
                txtSellingPrice.EditValue = rs.NewSellingPrice;
                
            }
        }

        private void gridItemView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
          
        }

        private void btnSetNewPrice_Click(object sender, EventArgs e)
        {
            bool validated = false;
            ReceiveDoc rd = new ReceiveDoc();

            validated = dxValidationProviderPrice.Validate();


            if (!validated)
            {
                XtraMessageBox.Show("Please fill in all required fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!isConfirmation)
            {
                if (XtraMessageBox.Show("Are u sure, you want to save the new price change?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    MyGeneration.dOOdads.TransactionMgr transactionMgr = MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgr();
                    transactionMgr.BeginTransaction();
                    try
                    {
                       
                       
                    
                        rs.NewUnitCost = Convert.ToDouble(txtAverageCost.EditValue);
                        rs.Margin = Convert.ToDouble(txtMargin.EditValue);
                        rs.NewSellingPrice = Convert.ToDouble(txtAverageCost.EditValue);
                        rs.NewPrice = Convert.ToDouble(txtAverageCost.EditValue);
                        rs.Remark = txtRemark.Text;
                        // set the item as  weighted average item
                        costElement.AverageCost = rs.NewUnitCost;
                        costElement.Margin = rs.Margin;
                        costElement.SellingPrice = rs.NewSellingPrice;
                        try
                        {
                            IJournalService journal = new JournalService();
                            journal.StartRecordingSession();
                            costElement.SavePrice(CurrentContext.UserId, "", journal, ChangeMode.PriceOverride);
                            journal.CommitRecordingSession();
                            journal.StartRecordingSession();
                            costElement.ConfirmPrice(CurrentContext.UserId, "", journal, ChangeMode.PriceOverride);
                            journal.CommitRecordingSession();
                        }
                        catch(Exception exception)
                        {
                          // since Cost tier is not Full Started   
                        }
                        Item itm = new Item();
                        itm.LoadByPrimaryKey(rs.ItemID);
                        itm.IsFree = false;

                        itm.Save();

                        rd.SavePrice(rs, CurrentContext.UserId);
                  
                       transactionMgr.CommitTransaction();
                   
                    
                    }
                    catch (Exception ex)
                    {
                        transactionMgr.RollbackTransaction();
                        XtraMessageBox.Show("Price setting failed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw ex;

                    }
                    XtraMessageBox.Show("Price setting successful", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetForm();
                    ChangeLayoutByMode();
                    ChangeLayoutByItemListedtype();
                }
            }
            else
            {
                if (XtraMessageBox.Show("Are you sure you want to approve the new price change.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {                    
                    rd.ConfirmMovingAverage(rs, CurrentContext.UserId);
                    XtraMessageBox.Show("Price setting successful", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            ResetForm();
        }

        private void gridMainLeft_DataSourceChanged(object sender, EventArgs e)
        {
             gridItemView_FocusedRowChanged(new object(), new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(-1, 0));
        }

        private void lkStores_EditValueChanged(object sender, EventArgs e)
        {
            rgPricing_EditValueChanged(new object(), new EventArgs());
        }

        private void txtFilterByItemName_EditValueChanged(object sender, EventArgs e)
        {
            gridItemView.ActiveFilterString = string.Format("FullItemName like '{0}%'", txtFilterByItemName.Text);
        }

        private void btnPrintPriceList_Click(object sender, EventArgs e)
        {
            PriceListPrintDialog priceListPrinting = new PriceListPrintDialog();
            priceListPrinting.ShowDialog();
        }

        private void gridMainLeft_DoubleClick(object sender, EventArgs e)
        {

        }

        #region For Hub Only
        private void txtSellingPrice_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtSellingPrice.EditValue) != (Convert.ToDouble(txtAverageCost.EditValue) * (1 + Convert.ToDouble(txtMargin.EditValue))))
            {
                txtMargin.EditValue = (Convert.ToDouble(txtSellingPrice.EditValue) / Convert.ToDouble(txtAverageCost.EditValue)) - 1;

            }
            else if (Convert.ToDouble(txtSellingPrice.EditValue) == (Convert.ToDouble(txtAverageCost.EditValue) * (1 + Convert.ToDouble(txtMargin.EditValue))))
            {
                return;
            }
        }
        //Hub Only
        private void txtAverageCost_EditValueChanged(object sender, EventArgs e)
        {
            txtSellingPrice.EditValue = Convert.ToDouble(txtAverageCost.EditValue) * (1 + Convert.ToDouble(txtMargin.EditValue));

        }

        private void spinEdit1_EditValueChanged(object sender, EventArgs e)
        {
             Account sg = new Account();
            sg.LoadByPrimaryKey(rs.StoreID);
            if (Convert.ToDouble(txtMargin.EditValue) > 0 && sg.ModeID == Mode.Constants.HEALTH_PROGRAM)
            {
                txtMargin.EditValue = 0;
            }
            if (Convert.ToDouble(txtSellingPrice.EditValue) != (Convert.ToDouble(txtAverageCost.EditValue) * (1 + Convert.ToDouble(txtMargin.EditValue))))
            {
                txtSellingPrice.EditValue = Convert.ToDouble(txtAverageCost.EditValue) * (1 + Convert.ToDouble(txtMargin.EditValue));

            }

        }


        #endregion

        // Dialog Box
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DataRow dr = gridItemView.GetFocusedDataRow();
            int itemID = Convert.ToInt32(dr["ItemID"]);
            int manufactureID = Convert.ToInt32(dr["ManufacturerID"]);
            int storeId = Convert.ToInt32(lkAccount.EditValue);
            int unitID = Convert.ToInt32(dr["UnitID"]);
            int Supplierid = 0;
            if (!BLL.Settings.IsCenter)
            {
                Supplierid = Convert.ToInt32(dr["SupplierID"]);

            }
            using (Modals.CostSheet costSheet = new Modals.CostSheet(itemID, manufactureID, Supplierid, unitID, storeId, isConfirmation))
            {
                costSheet.ShowDialog(this.Owner);
            }
            rgPricing_EditValueChanged(null, null);
        }
        #endregion
 
        #region Layout and Formating
        /// <summary>
        /// Change the Layout and Button Change Depending on the Mode
        /// </summary>
        public void ChangeLayoutByItemListedtype()
        {
            
                if (rgPricingMode.EditValue.ToString() == "Items")
                {
                    if (isConfirmation)
                        btnSetNewPrice.Text = "Confirm";
                    else if (BLL.Settings.HandleGRV)
                        btnSetNewPrice.Text = "Average Cost";
                    else
                        btnSetNewPrice.Text = "Set Price";

                }
                else if (rgPricingMode.EditValue.ToString() == "AllItems")
                {
                    // TODO: implement this.
                    if (isConfirmation)
                        btnSetNewPrice.Text = "Confirm";
                    else if (BLL.Settings.IsCenter)
                        btnSetNewPrice.Text = "Set Unit Cost/Margin";
                    else
                        btnSetNewPrice.Text = "Set Price";
                }
               
        }

        public void ChangeLayoutByMode()
        {
            BLL.User user = new User();
            user.LoadByPrimaryKey(CurrentContext.UserId);
            isConfirmation = false;
            if (isConfirmation)
            {
                layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                rgPricingMode.EditValue = "Items";
                btnSetNewPrice.Text = "Confirm";
            }
            else if (BLL.Settings.HandleGRV)
            {
                btnSetNewPrice.Text = "Calculate";
            }
            else
            {
                btnSetNewPrice.Text = "Set";
            }

            if (!BLL.Settings.IsCenter)
            {
                colSellingPrice.Visible = true;
                layoutSellingPrice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                colSellingPrice.Visible = false;
                layoutSellingPrice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
  
            }
            
        }
          private void LoadDecimalFormatings()
        {
            string sharps = Helpers.FormattingHelpers.GetBirrFormatting();
           
            colUnitCost.DisplayFormat.FormatString = sharps;
            colSellingPrice.DisplayFormat.FormatString = "{0:" + sharps + "}";// sharps;
            colSellingPrice.SummaryItem.DisplayFormat = "{0:" + sharps + "}";// sharps;
            colCost.SummaryItem.DisplayFormat = "{0:" +sharps+"}";
            colCost.DisplayFormat.FormatString = "{0:" + sharps + "}";
            
           

        }

        private void SetDisplayFormatAndEditMask(TextEdit txtBox, string sharps)
        {
            txtBox.Properties.DisplayFormat.FormatString = sharps;
            txtBox.Properties.Mask.EditMask = sharps;
        }
      private void ResetForm()
        {
            rs = new ReceivedSummary();
             rgPricing_EditValueChanged(null, null);
            //txtUnpricedCost.EditValue = rs.UnPricedCost;
            //txtUnPricedQty.EditValue = rs.UnPricedQuantity;
            //txtPricedQty.EditValue = rs.PricedQuantity;
            //txtPricedCost.EditValue = rs.PricedTotalCost;
            //txtCurrentSellingValue.EditValue = rs.PricedSellingPrice;
            //txtPricePerPackage.EditValue = rs.SellingPricePerPackage;
            //txtTotalQuantity.EditValue = rs.TotalQuantity;
            //txtTotalCost.EditValue = rs.TotalCost;

            //txtUnitCost.EditValue = rs.TotalCost / rs.TotalQuantity;

            //txtMargin.EditValue = rs.Margin;
            //txtNewPrice.EditValue = rs.NewPrice;
            //txtNewPricePerPack.EditValue = rs.NewPricePerPack;
          
        }
       
    
        #endregion
     
        private void gridMainLeft_MouseClick(object sender, MouseEventArgs e)
      {
          DataRow dr = gridItemView.GetFocusedDataRow();
          if (dr == null)
              return;
          BindDetails(dr);
      }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            DataRow dr = gridItemView.GetFocusedDataRow();
            if (dr == null)
                return;
            int itemID = Convert.ToInt32(dr["ItemID"]);
            // rs.SupplierID = Convert.ToInt32(dr["SupplierID"]);
            int activityID = Convert.ToInt32(lkAccount.EditValue);
            int unitID = Convert.ToInt32(dr["UnitID"]);
            

            WeightedAverageHistory form = new WeightedAverageHistory(costElement);

            form.ShowDialog(this);
        }

    }
}