using System;
using System.ComponentModel;
using System.Data;
using BLL;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using HCMIS.Desktop.Modals;
using HCMIS.Helpers;
using HCMIS.Desktop.ViewHelpers;

namespace HCMIS.Desktop.Forms.WorkFlow
{
    
    public partial class BeginningCostingByStore : XtraForm
    {
        BLL.Receipt receipt = new BLL.Receipt();


        //For Master and Detail we need to create a dataset that holds both tables
        DataSet ds = new DataSet();

        #region Initialization and Mode Settings

        public BeginningCostingByStore()
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
                gridMain.DataSource = BLL.Receipt.GetInventoryListByAccountandWarehouse(Convert.ToInt32(lkAccount.EditValue),Convert.ToInt32(lkWarehouse.EditValue),Convert.ToInt32(lkCategories.EditValue));
            }
        }

        private void gridMasterView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (lkWarehouse.EditValue != null && lkAccount.EditValue != null)
            {
                int ItemID;
                int ManufacturerID;
                int? UnitID;
                int StoreID;
                int WarehouseID;
                string Remark;
                double PricePerPack;
                DataRow Masterdr = gridMasterView.GetFocusedDataRow();
                if (gridMasterView.GetFocusedRow() != null)
                {
                    if (Masterdr["PricePerPack"] != DBNull.Value)
                        Masterdr["TotalReceived"] = Convert.ToInt32(Masterdr["NoOfPack"]) * Convert.ToDouble(Masterdr["PricePerPack"]);
                    else
                        Masterdr["TotalReceived"] = DBNull.Value;
                    ItemID = Convert.ToInt32(Masterdr["ItemID"]);
                    ManufacturerID = Convert.ToInt32(Masterdr["ManufacturerID"]);
                    UnitID = Convert.ToInt32(Masterdr["UnitID"]);
                    StoreID = Convert.ToInt32(lkAccount.EditValue);
                    WarehouseID = Convert.ToInt32(lkWarehouse.EditValue);
                    PricePerPack = Convert.ToDouble(Masterdr["PricePerPack"]);
                
                    Remark = Masterdr["Remark"].ToString();
                    
                }
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
                int StoreID;
                int WarehouseID;
                
                        StoreID = Convert.ToInt32(lkAccount.EditValue);
                        WarehouseID = Convert.ToInt32(lkWarehouse.EditValue);
                 XtraMessageBox.Show("Price has been successfully confirmed", "Success...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            HCMIS.Desktop.Reports.BeginningBalanceCostingReport xreport = new HCMIS.Desktop.Reports.BeginningBalanceCostingReport();
            xreport.DataSource = gridMasterView.DataSource;
            xreport.ShowPreview();
            // +"/nWareHouse:" + lkAccount.
        }

        private void txtFilter_EditValueChanged(object sender, EventArgs e)
        {
            gridMasterView.ActiveFilterString = "FullItemName like '" + txtFilter.EditValue + "%'";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }
    }
}