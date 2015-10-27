using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HCMIS.Desktop.Dialogs
{
    public partial class AddManufacturerForItem : XtraForm
    {
        private int _ItemID;
        private int _Manufacturer = 0;
        public int SelectedManufacturer
        {
            get
            {
                return _Manufacturer;
            }
        }
        public AddManufacturerForItem(int itemID)
        {
            InitializeComponent();
            _ItemID = itemID;
            
        }
        public AddManufacturerForItem()
        {
            
        }
         

        private void btnActualAddManufacturer_Click(object sender, EventArgs e)
        {
            _Manufacturer = Convert.ToInt32(lstAddManufacturers.SelectedValue);
            this.DialogResult = DialogResult.Yes;
            this.Close();
            //this.Close();
        }

        private void AddManufacturerForItem_Load(object sender, EventArgs e)
        {

            BLL.Manufacturer m = new BLL.Manufacturer();
            lstAddManufacturers.DataSource = m.GetNewManufacturersFor(this._ItemID);
            
        }

        private void lstAddManufacturers_SelectedValueChanged(object sender, EventArgs e)
        {
            _Manufacturer = Convert.ToInt32(lstAddManufacturers.SelectedValue);
        }
    }
}