using System;
using System.Data;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using HCMIS.Desktop.Helpers;
using HCMIS.Helpers;

namespace HCMIS.Desktop.Forms.Settings
{
    [FormIdentifier("PF-CD-CD-VW","Customize Drug List","")]
    public partial class CustomizeDrugList : XtraForm
    {
        Item itm = new Item();
        public CustomizeDrugList()
        {
            InitializeComponent();
        }


        private void ManageItems_Load(object sender, EventArgs e)
        {
            SetPermissions();
            lkCategories.Properties.DataSource = BLL.CommodityType.GetAllTypes();
            lkCategories.ItemIndex = 0;
        }

        private void SetPermissions()
        {
            if (BLL.Settings.UseNewUserManagement)
            {
                btnPrint.Enabled = (this.HasPermission("Can-Print"));
                btnExport.Enabled = (this.HasPermission("Can-Export"));
                btnEdit.Enabled = (this.HasPermission("Can-Edit"));
                btnItemManufacturer.Enabled = (this.HasPermission("Can-Change-Item-Manufacturer"));
            }

        }




        private void FilterItemNames()
        {
            gridView1.ActiveFilterString = string.Format("FullItemName like '{0}%'", txtItemName.Text);
        }

        private void LoadCommodities()
        {
            gridControl1.DataSource = Item.GetAllItemsByCommodityType(Convert.ToInt32(lkCategories.EditValue));
            FilterItemNames();
        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            FilterItemNames();
        }

       
        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataRow drv = gridView1.GetFocusedDataRow();
            if (drv != null)
            {
                int itemID = Convert.ToInt32(drv["ID"]);
                BasicItemSettings basicItemSettings = new BasicItemSettings(itemID, true);
                basicItemSettings.ShowDialog();
                LoadCommodities();
            }
        }

        private void btnItemManufacturer_Click(object sender, EventArgs e)
        {
            DataRow drv = gridView1.GetFocusedDataRow();
            if (drv != null)
            {
                int itemID = Convert.ToInt32(drv["ID"]);
                HCMIS.Desktop.ItemManufacturer itemManuf = new HCMIS.Desktop.ItemManufacturer(itemID);
                itemManuf.ShowDialog();
            }
        }

        private void btnPrint_Click_1(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }

        private void lkCategories_EditValueChanged(object sender, EventArgs e)
        {
            LoadCommodities();
        }

       

      

    }
}