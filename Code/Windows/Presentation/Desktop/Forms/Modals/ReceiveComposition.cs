using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCMIS.Desktop.Forms.WorkFlow;

namespace HCMIS.Desktop
{
    public partial class ReceiveComposition : XtraForm
    {
        public ReceiveComposition()
        {
            InitializeComponent();
        }
        DataTable suggestion = null;
        Receipt instance = null;
        decimal totalSKU = 0;
        private void ReceiveComposition_Load(object sender, EventArgs e)
        {

        }

        public void ShowFor(Receipt par, String ItemName, decimal SKU, DataTable SuggestedComposition, String Batch)
        {
            lblItemName.Text = ItemName;
            lblTotalSKUs.Text = SKU.ToString();
            lblBatchNumber.Text = Batch;
            suggestion = SuggestedComposition.Clone();
            totalSKU = SKU;
            foreach (DataRow d in SuggestedComposition.Rows)
            {
                suggestion.ImportRow(d);
            }

            gridControl1.DataSource = suggestion;
            instance = par;
            this.ShowDialog(par);
        }
        DataRow dr;


        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            dr = gridView1.GetFocusedDataRow();
            if (Convert.ToInt32(dr["Qty"]) < 0)
            {
                dr["Qty"] = 0;
            }
            dr["SKU"] = Convert.ToInt32(dr["SKUM"]) * Convert.ToInt32(dr["Qty"]);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            bool isvalid = ValidateSuggestion();
            if (isvalid)
            {
                instance.UpdateComposition(this.suggestion);
                this.Close();
            }
            else
            {
                 XtraMessageBox.Show(String.Format("Please revise your Packages to total {0} SKUs",totalSKU), "Invalid Packages", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateSuggestion()
        {
            int sum = GetTotalSKUInTable();
            
            return (sum == totalSKU);
        }

        private int GetTotalSKUInTable()
        {
            int sum = 0;
            foreach (DataRow r in suggestion.Rows)
            {
                sum += Convert.ToInt32(r["SKU"]);
            }
            return sum;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
