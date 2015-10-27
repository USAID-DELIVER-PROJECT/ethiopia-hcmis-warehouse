using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HCMIS.Desktop.Forms.Utilities
{
    public partial class Finance : DevExpress.XtraEditors.XtraForm
    {
        public Finance()
        {
            InitializeComponent();
        }

        private void Finance_Load(object sender, EventArgs e)
        {
            
            
        }

        private void gridMainView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                BLL.Item items = new BLL.Item();
                DataRow MainRow = gridMainView.GetFocusedDataRow();
                int ItemID = Convert.ToInt32(MainRow["ItemID"]);
                int ManufacturerID = Convert.ToInt32(MainRow["ManufacturerID"]);
                int ItemUnitID = Convert.ToInt32(MainRow["ItemUnitID"]);
                int AccountID = Convert.ToInt32(MainRow["AccountID"]);

                gridDetail.DataSource = items.GetReceiveDocByItemAndManufactuerAndUnit(ItemID, ManufacturerID, ItemUnitID, AccountID);
                gridPicklist.DataSource = items.GetPicklistByItemAndManufactuerAndUnit(ItemID, ManufacturerID, ItemUnitID, AccountID);
                gridMovingAverage.DataSource = items.GetIssueDocByItemAndManufactuerAndUnit(ItemID, ManufacturerID, ItemUnitID, AccountID);
            }
            catch { }


        }

        private void btnLoadReceipt_Click(object sender, EventArgs e)
        {
            BLL.Item items = new BLL.Item();
            gridMain.DataSource = items.GetItemByManufactuerAndUnit();
        }

        private void btnLoadCostTier_Click(object sender, EventArgs e)
        {
            BLL.Item items = new BLL.Item();
            gridCostTier.DataSource = items.GetCostTierComparision();
        }

        private void chkCostTier_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCostTier.Checked)
            {
                gridViewCostTier.ActiveFilterString = @"  [CostTierMargin] !=[CurrentMargin] Or
                                                                [CostTierSellingPrice]!=[CurrentSellingPrice] Or
                                                                [CostTierUnitCost]!=[CurrentUnitCost]";

            }
            else
            {
                gridViewCostTier.ActiveFilterString = "";
            }
                

        }

        private void gridCostTier_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridViewCostTier.GetFocusedDataRow();
            using( FinanceDiagnosticDetail financeDiagnosticDetail = new FinanceDiagnosticDetail())
            {
                financeDiagnosticDetail.ItemId = Convert.ToInt32(dr["ItemID"]);
                financeDiagnosticDetail.UnitId = Convert.ToInt32(dr["UnitID"]);
                financeDiagnosticDetail.ManufacturerId = Convert.ToInt32(dr["ManufacturerID"]);
                financeDiagnosticDetail.MovingAverageId = Convert.ToInt32(dr["MovingAverageID"]);
                financeDiagnosticDetail.Item = dr["Item"].ToString();
                financeDiagnosticDetail.Unit = dr["Unit"].ToString();
                financeDiagnosticDetail.Manufacturer = dr["Manufacturer"].ToString();
                financeDiagnosticDetail.MovingAverage = dr["MovingAverage"].ToString();
                financeDiagnosticDetail.AffectedLedgerID = Convert.ToInt32(dr["LedgerID"]);
                financeDiagnosticDetail.UnitCost =Convert.ToDecimal(dr["CostTierUnitCost"]);
                financeDiagnosticDetail.Margin = Convert.ToDecimal(dr["CostTierMargin"]);
                financeDiagnosticDetail.SellingPrice = Convert.ToDecimal(dr["CostTierSellingPrice"]);
                financeDiagnosticDetail.ShowDialog();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FileDialog fileDialog = new SaveFileDialog();
            if(fileDialog.ShowDialog() != DialogResult.Cancel)
            {
                gridViewCostTier.ExportToXls(fileDialog.FileName+".xls");
            }
        }
    }
}