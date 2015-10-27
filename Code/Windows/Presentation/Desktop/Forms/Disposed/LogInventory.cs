using System;
using System.Data;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using HCMIS.Desktop.ViewHelpers;
using HCMIS.Helpers;

namespace HCMIS.Desktop
{
    [FormIdentifier("AL-IL-IL-RP","Inventory Log","")]
    public partial class LogInventory : XtraForm
    {
        public LogInventory()
        {
            InitializeComponent();
        }

        private void ManageItemsLoad(object sender, EventArgs e)
        {
            
            lkActivity.SetupActivityEditor().SetDefaultActivity();
        }

        private void PopulateTransactions(DataTable dtRec)
        {
            

            if (dtRec.Rows.Count == 0)
                txtEmpty.Visible = true;
            else
                txtEmpty.Visible = false;

            gridInventory.DataSource = dtRec;
        }

        private void PopulateDocument(DataTable dtRec)
        {
            lstRefNo.Items.Clear();
            
            for (int i = 0; i < dtRec.Rows.Count; i++)
            {
                string[] str = {dtRec.Rows[i]["Year"].ToString()};
                ListViewItem listItem = new ListViewItem(str);
                listItem.Tag = dtRec.Rows[i]["Year"];

                lstRefNo.Items.Add(listItem);
            }
        }

        private void LstTransactionsMouseDoubleClick(object sender, MouseEventArgs e)
        {
            string yr = lstRefNo.SelectedItems[0].Tag.ToString();
            if (yr != "")
            {
                YearEnd yEnd = new YearEnd();
                DataTable dtRec = yEnd.GetDocumentByYear(Convert.ToInt32(lkActivity.EditValue), yr);
                lblAdjDate.Text = yr;
                PopulateTransactions(dtRec);
            }
        }

        private void CboStoresSelectedValueChanged(object sender, EventArgs e)
        {
            if (lkActivity.EditValue != null)
            {
                YearEnd yEnd = new YearEnd();
                DataTable dtRec = yEnd.GetDistinctYear(Convert.ToInt32(lkActivity.EditValue));
                PopulateDocument(dtRec);

                dtRec = yEnd.GetDocumentAll(Convert.ToInt32(lkActivity.EditValue));
                lblAdjDate.Text = "All Years";
                PopulateTransactions(dtRec);
            }
        }

        private void BtnExportClick(object sender, EventArgs e)
        {
            string[] header = {GeneralInfo.Current.HospitalName, "Inventory Log of " + lblAdjDate.Text};
            gridInventory.ExportToXls("Exported_Inventory.xls");
        }

        private void BtnPrintClick(object sender, EventArgs e)
        {
            gridInventory.ShowPrintPreview();
        }
    }
}