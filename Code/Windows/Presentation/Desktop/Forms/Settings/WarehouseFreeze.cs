using System;
using System.Data;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using HCMIS.Desktop.Helpers;
using HCMIS.Desktop.Reports.Helpers;
using HCMIS.Helpers;

namespace HCMIS.Desktop.Forms.Settings
{
    [FormIdentifier("IN-FR-FR-CN", "Freeze / Release Warehouse Transactions", "")]
    public partial class WarehouseFreezeForm : DevExpress.XtraEditors.XtraForm
    {
        public WarehouseFreezeForm()
        {
            InitializeComponent();
        }

        private void WarehouseFreezeForm_Load(object sender, EventArgs e)
        {
            var freezChoice = Convert.ToString(ComboBoxFreezChoice.Text);
            SetPermission();
            if (freezChoice == "Cluster")
            {
                grdWarehouseFreez.DataSource = BLL.Cluster.GetClusterStatus(); 
            }
            else if(freezChoice == "Warehouse")
            {
                grdWarehouseFreez.DataSource = BLL.Warehouse.GetWarehouseStatus(); 
            }
            else if (freezChoice == "Physical Store")
            {
                grdWarehouseFreez.DataSource = BLL.PhysicalStore.GetPhysicalStoreStatus(); 
            }

        }

    

        private void SetPermission()
        {
            if (BLL.Settings.UseNewUserManagement)
            {
                grdWarehouseFreez.Enabled = this.HasPermission("Save");
            }
        }

        private void ComboBoxFreezChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            WarehouseFreezeForm_Load(null, null);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Are you sure you would like to change the status of this store/warehouse?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            DataTable table = gridManageInvetoryView.GetFocusedDataRow().Table;
            foreach(DataRow dr in table.Rows)
            {
                if (dr != null && dr.RowState == DataRowState.Modified)
                {
                    var freezChoice = Convert.ToString(ComboBoxFreezChoice.Text);

                    if (freezChoice == "Cluster")
                    {
                        int selected = Convert.ToInt32(dr["LocationID"]);
                        Cluster cluster = new Cluster();
                        cluster.LoadByPrimaryKey(selected);
                        cluster.IsActive = Convert.ToBoolean(dr["Status"]);
                        cluster.Save();
                        this.LogActivity("Changed Status of Cluster");
                        BLL.Warehouse warehouse = new BLL.Warehouse();
                        warehouse.UpdateWarehouseStatusbyCluster(selected, Convert.ToBoolean(dr["Status"]));

                        BLL.PhysicalStore physicalStore = new PhysicalStore();
                        physicalStore.UpdatePhysicalStoreStatusbyCluster(selected, Convert.ToBoolean(dr["Status"]));
                    }

                    else if (freezChoice == "Warehouse")
                    {
                        int selected = Convert.ToInt32(dr["LocationID"]);
                        BLL.Warehouse warehouse = new BLL.Warehouse();
                        warehouse.LoadByPrimaryKey(selected);
                        warehouse.IsActive = Convert.ToBoolean(dr["Status"]);
                        warehouse.Save();
                        this.LogActivity("Changed Status of Warehouse");
                        BLL.PhysicalStore physicalStore = new PhysicalStore();
                        physicalStore.UpdatePhysicalStoreStatusbyWarehouse(selected, Convert.ToBoolean(dr["Status"]));
                    }
                    else if (freezChoice == "Physical Store")
                    {
                        int selected = Convert.ToInt32(dr["LocationID"]);
                        PhysicalStore physicalStore = new PhysicalStore();
                        physicalStore.LoadByPrimaryKey(selected);
                        physicalStore.IsActive = Convert.ToBoolean(dr["Status"]);
                        physicalStore.Save();
                        this.LogActivity("Changed Status of Store");
                    }

                }  
            }
            

            XtraMessageBox.Show("The freezing and unfreezing you have made have been saved.", "Successfully Saved",
                                MessageBoxButtons.OK);
        }

       
            
        

        

       

       

     
        

        
    }
}