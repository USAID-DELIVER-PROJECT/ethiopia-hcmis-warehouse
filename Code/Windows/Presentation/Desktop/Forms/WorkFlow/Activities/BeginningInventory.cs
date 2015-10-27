using System;
using System.ComponentModel;
using System.Data;
using BLL;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using HCMIS.Desktop.Modals;
using CalendarLib;
using HCMIS.Desktop.ViewHelpers;
using HCMIS.Helpers;

namespace HCMIS.Desktop.Forms.WorkFlow
{
    [FormIdentifier("IN-BI-BI-CN", "Beginning Inventory Confirmation", "")]
    public partial class BegginingInventoryCount : XtraForm
    {
        BLL.Receipt receipt = new BLL.Receipt();


        //For Master and Detail we need to create a dataset that holds both tables
        DataSet ds = new DataSet();

        #region Initialization and Mode Settings

        public BegginingInventoryCount()
        {
            InitializeComponent();

        }

        private void PutAwayListsLoad(object sender, EventArgs e)
        {
            
            //Load Cluster->Warehouse Selection
            //Lookup For Warehouse
            lkWarehouse.Properties.DataSource = BLL.Warehouse.GetWarehouseWithCluster(CurrentContext.UserId);
            //Load Mode->Account->SubAccount Selection
            //Lookup For Accounts
            lkAccount.SetupActivityEditor().SetDefaultActivity();
            //Load Mode->Account->SubAccount Selection
            //Lookup For Accounts
            //lkAccount.Properties.DataSource = Stores.GetStoresWithStoreGroupsAndStoreTypes(NewMainWindow.UserId);
            lkCategories.Properties.DataSource = BLL.CommodityType.GetAllTypes();
            lkCategories.EditValue = 0;
            
        }
        #endregion

        private void lkAccount_EditValueChanged(object sender, EventArgs e)
        {
            if (lkWarehouse.EditValue != null)
            {
                lkWarehouse_EditValueChanged(null, null);
            }
        }

        private void lkWarehouse_EditValueChanged(object sender, EventArgs e)
        {
            if (lkAccount.EditValue != null && lkCategories.EditValue != null)
            {
                gridMain.DataSource = BLL.Receipt.GetInventoryCountbyAccountandWarehouse(Convert.ToInt32(lkAccount.EditValue), Convert.ToInt32(lkWarehouse.EditValue), Convert.ToInt32(lkCategories.EditValue),ReceiptConfirmationStatus.Constants.RECEIVE_ENTERED);
            }
        }

     
        private void lkCategories_EditValueChanged(object sender, EventArgs e)
        {
            lkAccount_EditValueChanged(null, null);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(XtraMessageBox.Show("Are you sure you want to comfirm the Beginning Balance, once confirm you cannot undo", "Are you sure...", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
            if (lkWarehouse.EditValue != null && lkAccount.EditValue != null)
                {
                    int StoreID = Convert.ToInt32(lkAccount.EditValue);
                    int WarehouseID = Convert.ToInt32(lkWarehouse.EditValue);


                    BLL.Receipt.Confirm(StoreID, WarehouseID);
                  
                    XtraMessageBox.Show("Quantity has been successfully confirmed, Please Print the additional Inventory Count", "Success...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HCMIS.Desktop.Reports.InventoryCountSheet xreport = new HCMIS.Desktop.Reports.InventoryCountSheet(CurrentContext.LoggedInUserName);
                    xreport.DataSource = BLL.Receipt.GetInventoryCountbyAccountandWarehouse(Convert.ToInt32(lkAccount.EditValue), Convert.ToInt32(lkWarehouse.EditValue), Convert.ToInt32(lkCategories.EditValue), ReceiptConfirmationStatus.Constants.RECEIVE_ENTERED);
                    DateTimePickerEx dtDate = new DateTimePickerEx();
                    dtDate.Value = DateTimeHelper.ServerDateTime;
                    xreport.Date.Text = dtDate.Text;
                    xreport.ShowPreview();
                }
                else
                {
                    XtraMessageBox.Show("Select Activity and Warehouse first", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }  
                
                   
            } 
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            HCMIS.Desktop.Reports.InventoryCountSheet xreport = new HCMIS.Desktop.Reports.InventoryCountSheet(CurrentContext.LoggedInUserName);
            xreport.DataSource = BLL.Receipt.GetInventoryCountbyAccountandWarehouse(Convert.ToInt32(lkAccount.EditValue), Convert.ToInt32(lkWarehouse.EditValue), Convert.ToInt32(lkCategories.EditValue), ReceiptConfirmationStatus.Constants.RECEIVE_ENTERED);
            DateTimePickerEx dtDate = new DateTimePickerEx();
            dtDate.Value = DateTimeHelper.ServerDateTime;
            xreport.Date.Text = dtDate.Text;
            xreport.ShowPreview();
        }

        private void gridMasterView_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridMasterView.GetFocusedDataRow();
            
            if (dr != null)
            {
                
                    RelatedReceipts er = new RelatedReceipts(Convert.ToInt32(lkAccount.EditValue),
                                                             Convert.ToInt32(lkWarehouse.EditValue),
                                                             Convert.ToInt32(dr["ID"]), 1);
                    er.ShowDialog(this);
                
            }
        }

        private void txtFilter_EditValueChanged(object sender, EventArgs e)
        {
            gridMasterView.ActiveFilterString = "FullItemName like '" + txtFilter.EditValue + "%'";
        }

       
    }
}