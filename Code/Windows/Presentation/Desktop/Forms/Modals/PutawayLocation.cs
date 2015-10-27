using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HCMIS.Desktop.Forms.Modals
{
    public partial class PutawayLocation : DevExpress.XtraEditors.XtraForm
    {
        private int _itemID;

        public int PalletLocationID { get; set; }
        public PutawayLocation(int itemID)
        {
            InitializeComponent();
            _itemID = itemID;
        }

        private void PutawayLocation_Load(object sender, EventArgs e)
        {
            lkNewLocation.Properties.DataSource = BLL.PalletLocation.GetAllFreeFor(_itemID);
            labelItemName.Text = BLL.Item.GetName(_itemID);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            PalletLocationID = Convert.ToInt32(lkNewLocation.EditValue);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.None;
            Close();
        }
    }
}