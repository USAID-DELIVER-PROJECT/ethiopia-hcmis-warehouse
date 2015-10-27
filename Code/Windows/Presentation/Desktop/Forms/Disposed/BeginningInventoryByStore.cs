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
    public partial class BegginingInventoryCountbyStore : XtraForm
    {
        BLL.Receipt receipt = new BLL.Receipt();


        //For Master and Detail we need to create a dataset that holds both tables
        DataSet ds = new DataSet();

        #region Initialization and Mode Settings

        public BegginingInventoryCountbyStore()
        {
            InitializeComponent();

        }

        private void PutAwayListsLoad(object sender, EventArgs e)
        {
            
            //Load Cluster->Warehouse Selection
            //Lookup For Warehouse
            lkWarehouse.Properties.DataSource = PhysicalStore.GetStoresWithWarehouseAndCluster();
            //Load Mode->Account->SubAccount Selection
            //Lookup For Accounts
            lkAccount.SetupActivityEditor().SetDefaultActivity();  //Load Mode->Account->SubAccount Selection
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
                gridMain.DataSource = BLL.Receipt.GetInventoryCountbyAccountandPhysicalStore(Convert.ToInt32(lkAccount.EditValue), Convert.ToInt32(lkWarehouse.EditValue), Convert.ToInt32(lkCategories.EditValue));
            }
        }

     
        private void lkCategories_EditValueChanged(object sender, EventArgs e)
        {
            lkAccount_EditValueChanged(null, null);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        { 
                if (lkWarehouse.EditValue != null && lkAccount.EditValue != null)
                {
                    int StoreID = Convert.ToInt32(lkAccount.EditValue);
                    int WarehouseID = Convert.ToInt32(lkWarehouse.EditValue);


                    BLL.Receipt.ConfirmbyStore(StoreID, WarehouseID);

                    XtraMessageBox.Show("Quantity has been successfully confirmed", "Success...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Select Activity and Warehouse first", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
           
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            HCMIS.Desktop.Reports.InventoryCountSheet xreport = new HCMIS.Desktop.Reports.InventoryCountSheet(CurrentContext.LoggedInUserName);
            xreport.DataSource = BLL.Receipt.GetInventoryCountbyAccountandPhysicalStore(Convert.ToInt32(lkAccount.EditValue),Convert.ToInt32(lkWarehouse.EditValue),Convert.ToInt32(lkCategories.EditValue));
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
                bool Priceset = Convert.ToBoolean(dr["IsPriceConfirmed"]);
                if (!Priceset)
                {
                    RelatedReceipts er = new RelatedReceipts(Convert.ToInt32(lkAccount.EditValue),
                                                         Convert.ToInt32(lkWarehouse.EditValue),
                                                         Convert.ToInt32(dr["ID"]), 2);
                    er.ShowDialog(this);
                }
                else
                {
                    XtraMessageBox.Show("Price has Been confirmed for this Item, you cannot Change the Quantity", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void txtFilter_EditValueChanged(object sender, EventArgs e)
        {
            gridMasterView.ActiveFilterString = "FullItemName like '" + txtFilter.EditValue + "%'";
        }
    }
}