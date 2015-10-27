using System;
using BLL;
using HCMIS.Helpers;

namespace HCMIS.Desktop.Forms.Reports
{
    [FormIdentifier("RP-LV-LV-RP","Location List View","")]
    public partial class LocationListView : DevExpress.XtraEditors.XtraForm
    {
        public LocationListView()
        {
            InitializeComponent();
        }

        private void LocationListView_Load(object sender, EventArgs e)
        {
            // Bind the storage types
            StorageType storageType = new StorageType();
            storageType.LoadAll();
    
            lkStorageType.Properties.DataSource = storageType.DefaultView;

            lkStorageType.ItemIndex = 0;
        }

        private void lkStorageType_EditValueChanged(object sender, EventArgs e)
        {
            Shelf shlf = new Shelf();
            shlf.LoadShelvesByStorageType(lkStorageType.EditValue.ToString());
            lkRacks.Properties.DataSource = shlf.DefaultView;

            lkRacks.ItemIndex = 0;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printableComponentLink1.PrintingSystem = new DevExpress.XtraPrinting.PrintingSystem();
            printableComponentLink1.ShowPreviewDialog();
        }

        private void lkRacks_EditValueChanged(object sender, EventArgs e)
        {
            PalletLocation pl = new PalletLocation();
            gridControl1. DataSource = pl.GetLocationListView(lkRacks.EditValue.ToString());
        }
    }
}