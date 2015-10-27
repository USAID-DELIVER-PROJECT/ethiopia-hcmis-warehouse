using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BLL;
using DevExpress.XtraGrid.Views.Grid;
using HCMIS.Concrete.Models;
using HCMIS.Core.Distribution.Services;
using Item = BLL.Item;

namespace HCMIS.Desktop.Forms.Utilities
{
    public partial class FinanceDiagnosticDetail : DevExpress.XtraEditors.XtraForm
    {
        public string Item, Manufacturer, Unit, MovingAverage;
        public int ItemId, UnitId, ManufacturerId, MovingAverageId;
        public decimal UnitCost, Margin, SellingPrice;
        public int AffectedLedgerID;
        
        public FinanceDiagnosticDetail()
        {
            InitializeComponent();
        }
      
        private void PricePerPackPage_Load(object sender, EventArgs e)
        {
            LoadAndBind();
            //Incase the user Closes the form in other Method Than the 2 available but
            //the Default Dialog Result return should be Cancel
              
        }
        /// <summary>
        /// Load All Neccessary Data and Bind To DataSource
        /// </summary>
        void LoadAndBind()
        {
            //Bind
        
            //Load Detail Table To Grid
            Item item = new Item();
            gridReceiveDoc.DataSource = item.GetReceiveDocDetailForDiagnostics(ItemId, ManufacturerId, UnitId,
                                                                               MovingAverageId);

            gridJournalEntries.DataSource = item.GetJournalEntriesForDiagnostics(AffectedLedgerID);

            MovingAverageHistory history = new MovingAverageHistory();
            CostElement costElement = new CostElement(ItemId, MovingAverageId, ManufacturerId, UnitId, ManufacturerId);
            gridAllSimilarItems.DataSource = history.GetHistory(costElement);
           
            //Load Header Information From first row to be displayed
         
                txtItemName.EditValue = Item;
                txtItemUnit.EditValue = Unit;
                txtManufacturerName.EditValue = Manufacturer;
                txtActivityName.EditValue = MovingAverage;
                txtUnitCost.EditValue = UnitCost;
                txtMargin.EditValue = Margin;
                txtSellingPrice.EditValue = SellingPrice;
            
        }

        
            
       
        private void btnConfirm_Click(object sender, EventArgs e)
        {
           
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void gridIssueOrderView_DoubleClick(object sender, EventArgs e)
        {
            DataRow dataRow = gridIssueOrderView.GetFocusedDataRow();
            if (dataRow != null && dataRow["Identifier"] != DBNull.Value)
            {

            gridPrintLog.DataSource = HCMIS.Core.Distribution.Services.PrintLogService.GetDocumentMeta(Convert.ToInt32(dataRow["Identifier"]));
            }
        }
        
        private void gridPrintLogView_DoubleClick(object sender, EventArgs e)
        {

            PrintLogMeta printLog = (PrintLogMeta)gridPrintLogView.GetFocusedRow();
            if (printLog != null)
            {
                int ID = printLog.ID;
           
            HCMIS.Core.Distribution.Services.PrintLogService printout = new HCMIS.Core.Distribution.Services.PrintLogService();

                using (SaveFileDialog SaveDialog = new SaveFileDialog())
                {
                    SaveDialog.DefaultExt = ".pdf";
                    if (SaveDialog.ShowDialog() != DialogResult.Cancel)
                    {
                        printout.ToFile(ID, SaveDialog.FileName);
                        XtraMessageBox.Show("Your PDF is Exported", "Thanks");
                    }

                }
            }
        }
        
    }
}