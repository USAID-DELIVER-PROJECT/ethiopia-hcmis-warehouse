using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using HCMIS.Desktop.ViewHelpers;
using HCMIS.Helpers;

namespace HCMIS.Desktop.Forms.Reports
{
    [FormIdentifier("RP-IA-IA-RP", "&Item Distribution By Account Report", "")]
    public partial class ItemDistributionByAccount : DevExpress.XtraEditors.XtraForm
    {
        public ItemDistributionByAccount()
        {
            InitializeComponent();
        }

        private void ItemDistributionByAccount_Load(object sender, EventArgs e)
        {
            btnGo.Enabled = false;
            lkAccount.SetupAccountEditor().SetDefaultAccount();
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (lkAccount.EditValue != null && fromDate.EditValue != null && toDate.EditValue != null)
            {
                var itm = new Item();
                var distributeditems = itm.GetItemsDistributedByAccount(Convert.ToInt32(lkAccount.EditValue),Convert.ToDateTime(fromDate.EditValue),Convert.ToDateTime(toDate.EditValue));
                gridControl1.DataSource = distributeditems;
            }
            else
            {
                XtraMessageBox.Show("Please select all the filters before clicking the button!", "Error");
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            if (sfd.ShowDialog() != DialogResult.OK) return;
            gridView1.ExportToXlsx(sfd.FileName + ".xlsx");
            XtraMessageBox.Show("The file has been exported.");
        }

        private void lkAccount_EditValueChanged(object sender, EventArgs e)
        {
            btnGo.Enabled = true;
        }

    }
}