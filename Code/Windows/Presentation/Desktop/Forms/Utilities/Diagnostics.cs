using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;
using HCMIS.Core.Distribution.Services;
using HCMIS.Desktop.Helpers;
using HCMIS.Helpers;
using HCMIS.Shared.Connection;

namespace HCMIS.Desktop.Forms.Utilities
{
    [FormIdentifier("AD-DI-DI-UT","Diagnostics","")]
    public partial class Diagnostics : XtraForm
    {
        BLL.ReceiveDoc rd = new BLL.ReceiveDoc();
        BLL.IssueDoc id = new BLL.IssueDoc();
        BLL.PickListDetail pld = new BLL.PickListDetail();
        BLL.OrderDetail ordDetail = new BLL.OrderDetail();
        BLL.ReceivePallet recPallet = new BLL.ReceivePallet();
        BLL.LossAndAdjustment _lossAndAdjustment = new BLL.LossAndAdjustment();
        BLL.YearEnd yearEnd = new BLL.YearEnd();
        int _itemID = 0;

        public Diagnostics()
        {
            InitializeComponent();
        }

        public Diagnostics(int itemID)
        {
            InitializeComponent();
            _itemID = itemID;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                int itemID;
                if (!string.IsNullOrEmpty(txtItemID.Text))
                    _itemID = int.Parse(txtItemID.Text);
                itemID = _itemID;
                BLL.Item itm = new BLL.Item();
                itm.LoadByPrimaryKey(itemID);
                lblFullItemName.Text = itm.FullItemName;

                rd.LoadByItemID(itemID);
                grdReceiveDoc.DataSource = rd.DefaultView;

                recPallet.LoadByItemID(itemID);
                grdReceivePallet.DataSource = recPallet.DefaultView;

                id.LoadByItemID(itemID);
                grdIssueDoc.DataSource = id.DefaultView;
              
                ordDetail.LoadByItemID(itemID);
                grdOrderDetail.DataSource = ordDetail.DefaultView;

                pld.LoadByItemID(itemID);
                grdPickListDetail.DataSource = pld.DefaultView;

                _lossAndAdjustment.LoadByItemID(itemID);
                grdDisposal.DataSource = _lossAndAdjustment.DefaultView;

                yearEnd.LoadByItemID(itemID);
                grdYearEnd.DataSource = yearEnd.DefaultView;

                BLL.ItemUnit iu = new BLL.ItemUnit();
                iu.LoadAllForItem(int.Parse(txtItemID.Text));
              
                grdItemManufacturerItemUnit.DataSource = iu.DefaultView;

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grdViewReceiveDoc_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
        }

        private void btnRunSQLScript_Click(object sender, EventArgs e)
        {
            grdViewCustomOutput.Columns.Clear();
            if(!Sanitized(txtSQLScript.Text))
            {
                MessageBox.Show("Please use a safe query");
                txtSQLScript.SelectAll();
                return;
            }

            try
            {
                grdCustomOutput.DataSource = Helpers.QueryHelper.RunQuery(txtSQLScript.Text);                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Checks whether the query is sanitized and stuff we consider unsafe is not run.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        private bool Sanitized(string query)
        {
            if(query.Contains("update")) // && !query.Contains("where"))
                return false;
            if (query.Contains("drop") || query.Contains("alter") || query.Contains("create"))
                return false;
            if(query.Contains("delete"))
                return false;
            if (query.Contains("exec"))
                return false;
            return true;
        }

        private void DatabaseInteractivityUtility_Load(object sender, EventArgs e)
        {
            SetPermission();
            PreparePrintLog();
            var activity = new Activity();
            activity.LoadAll();
            lkStoreLocation.Properties.DataSource = activity.DefaultView;
            
            txtEditVersion.Text = Program.HCMISVersionStringShort;

            try
            {
                txtItemID.Text = _itemID == 0 ? "" : _itemID.ToString();
                if (txtItemID.Text != "")
                    btnGo_Click(null, null);
            }
            catch
            {
            }
        }

        private void PreparePrintLog()
        {
            dtPrintLogFrom.EditValue = dtPrintLogTo.EditValue = BLL.DateTimeHelper.ServerDateTime;
            lkPrintLogDocumentType.Properties.DataSource =
                HCMIS.Core.Distribution.Services.PrintLogService.GetDocumentTypes();
        }

        private void SetPermission()
        {
            // crazy code to prevent Menfese from seeing the shit.
            if ((!System.Diagnostics.Debugger.IsAttached || !ConnectionHelper.IsLiveInstallation) && (Control.ModifierKeys & Keys.Shift) == 0)
            {
                tbPDFLog.Visibility = LayoutVisibility.Never;
                tbInvoice.Visibility = LayoutVisibility.Never;
                tbQuantity.Visibility = LayoutVisibility.Never;
                tbEssentials.Visibility = LayoutVisibility.Never;
                tbTemp.Visibility = LayoutVisibility.Never;
            }

            if (BLL.Settings.UseNewUserManagement)
            {
                btnRunSQLScript.Enabled = this.HasPermission("Run");
                btnGo.Enabled = this.HasPermission("View-Item-Detail");
                btnRelocatePallet.Enabled = this.HasPermission("Relocate-Pallet-Location");
                btnFixLocationStuff.Enabled = this.HasPermission("Fix-Location-Problems");
                btnLoadErrors.Enabled = this.HasPermission("Load-Error");
            }
        }

        private void txtItemID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGo_Click(null, null);
            }
        }

        private void txtSQLScript_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnRunSQLScript_Click(null, null); 
            }
        }

        private void btnFixLocationStuff_Click(object sender, EventArgs e)
        {
            int storeID = Convert.ToInt32(lkStoreLocation.EditValue);
            BLL.ReceiveDoc rd = new BLL.ReceiveDoc();
            rd.LoadReceivesForStores(storeID);
            while(!rd.EOF)
            {
                BLL.ReceivePallet rp = new BLL.ReceivePallet();
                rp.LoadByReceiveDocID(rd.ID);
                decimal receivedQuantity = 0, balance = 0;
                if (rp.RowCount==1)// rp.RowCount > 0)
                {
                    while (!rp.EOF)
                    {
                        receivedQuantity += rp.IsColumnNull("ReceivedQuantity") ? 0 : rp.ReceivedQuantity;
                        balance += rp.IsColumnNull("Balance") ? 0 : rp.Balance;
                        rp.MoveNext();
                    }
                    rp.Rewind();

                    while (!rp.EOF && rp.IsColumnNull("ReceivedQuantity"))
                    {
                        rp.MoveNext();
                    }

                    if (rd.Quantity != receivedQuantity && rd.Quantity > receivedQuantity)
                    {
                        rp.ReceivedQuantity += (rd.Quantity - receivedQuantity);
                    }
                    if (rd.QuantityLeft != balance && rd.QuantityLeft > 0)//rd.QuantityLeft > balance)
                    {
                        rp.Balance += (rd.QuantityLeft - balance);
                    }
                    rp.Save();
                }
                rd.MoveNext();
            }
            XtraMessageBox.Show("Completed!");
        }

        private void lkStoreLocation_EditValueChanged(object sender, EventArgs e)
        {
            int storeID = Convert.ToInt16(lkStoreLocation.EditValue);
            BLL.PhysicalStore phyStores = new BLL.PhysicalStore();
            phyStores.LoadAll();
            lkPhysicalStores.Properties.DataSource = phyStores.DefaultView;
            LoadMisplacedItems(storeID);
        }

        private void LoadMisplacedItems(int storeID)
        {
            BLL.ReceivePallet rp = new BLL.ReceivePallet();
            rp.LoadMisplacedItems(storeID);
            grdMisplacedItems.DataSource = rp.DefaultView;
        }

        private void lkStorageType_EditValueChanged(object sender, EventArgs e)
        {
            lkAvailablePalletLocation.Properties.DataSource = BLL.PalletLocation.GetAllFree(lkStorageType.EditValue.ToString());
        }
        
        private void btnRelocatePallet_Click(object sender, EventArgs e)
        {
            //Get the chosen pallet Location
            BLL.PalletLocation palletLocation = new BLL.PalletLocation();
            palletLocation.LoadByPrimaryKey(Convert.ToInt16(lkAvailablePalletLocation.EditValue));

            //Get the chosen misplaced receivepallet entry
            DataRow dr = grdViewMisplacedItems.GetFocusedDataRow();
            int receivePalletID = Convert.ToInt32(dr["ID"]);

            BLL.ReceivePallet rp = new BLL.ReceivePallet();
            rp.LoadByPrimaryKey(receivePalletID);
            if (palletLocation.IsColumnNull("PalletID"))
            {
                palletLocation.PalletID = rp.PalletID;
                palletLocation.Save();
            }
            else
            {
                rp.PalletID = palletLocation.PalletID;
                rp.Save();
            }
            
            int storeID = Convert.ToInt16(lkStoreLocation.EditValue);
            LoadMisplacedItems(storeID);

            XtraMessageBox.Show("Placed!!");

        }

        private void btnReservedStockProblemFix_Click(object sender, EventArgs e)
        {
            BLL.ReceivePallet.FixReservedStockProblems();
            XtraMessageBox.Show("Reserved Stock Problem Fixed");
        }

        private void btnFixQuantityLeftProblem_Click(object sender, EventArgs e)
        {
            try
            {
                BLL.ReceiveDoc.FixQuantityLeftProblem(int.Parse(txtItemID.Text));
                XtraMessageBox.Show("Quantity Left Problem Fixed");
            }
            catch
            {

            }
        }

     

        private void btnFixQtyPerUnitInconsistencies_Click(object sender, EventArgs e)
        {
            BLL.ItemUnit.CorrectUnitQtyPerUnitInconsistencies();
            XtraMessageBox.Show("Quantity/Pack Problems Corrected");
        }

        private void lkPhysicalStores_EditValueChanged(object sender, EventArgs e)
        {
            BLL.StorageType storageType=new BLL.StorageType();
            storageType.LoadByPhysicalStoreID(int.Parse(lkPhysicalStores.EditValue.ToString()));
            lkStorageType.Properties.DataSource = storageType.DefaultView;
        }

       

        private void btnLoadErrors_Click(object sender, EventArgs e)
        {
            BLL.LogAppError errorLog = new BLL.LogAppError();
            errorLog.LoadAll();
            gridError.DataSource = errorLog.DefaultView;
        }

        private void btnQtyPerPackInconsistenciesForAnItem_Click(object sender, EventArgs e)
        {
            BLL.ItemUnit.CorrectUnitQtyPerUnitInconsistencies(_itemID);
            XtraMessageBox.Show("Quantity/Pack Problems Corrected");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BLL.ReceiptInvoice rI = new ReceiptInvoice();
            rI.GetStatusOfInvoice(txtInvoiceNo.Text);
            grdInvoiceSearchDetails.DataSource = rI.DefaultView;
        }

        private void btnSearchReceiptID_Click(object sender, EventArgs e)
        {
            BLL.Receipt receipt = new Receipt();
            receipt.LoadSearchDetailsForReceipt(int.Parse(txtReceiptID.Text));
            grdReceiptSearchDetails.DataSource = receipt.DefaultView;
            gridPrintout.DataSource = BLL.Receipt.GetlistOfPrints(int.Parse(txtReceiptID.Text));
            lkReceiptConfirmationStatus.Properties.DataSource = BLL.ReceiptConfirmationStatus.GetAll();
        }

        private void btnChangeReceiptConfirmationStatus_Click(object sender, EventArgs e)
        {
            int newReceiptConfirmationStatus = int.Parse(lkReceiptConfirmationStatus.EditValue.ToString());
            BLL.ReceiveDoc rd = new ReceiveDoc();
            rd.LoadByReceiptID(int.Parse(txtReceiptID.Text));
            while (!rd.EOF)
            {
                ReceiveDocConfirmation rdc = new ReceiveDocConfirmation();
                rdc.LoadByReceiveDocID(rd.ID);
                rdc.ReceiptConfirmationStatusID = newReceiptConfirmationStatus;
                rdc.Save();
                rd.MoveNext();
            }
            XtraMessageBox.Show("Successful!");

        }

        private void btnReceiveDocQuantityFix_Click(object sender, EventArgs e)
        {
            int i = BLL.ReceiveDoc.FixQuantityProblem(_itemID);
            if(i>0)
            {
                XtraMessageBox.Show(string.Format("Fixed {0} entries.", i));
            }
        }

        private void gridPrintoutView_DoubleClick(object sender, EventArgs e)
        {


            PrintLogMeta printLogMeta = (PrintLogMeta) gridView5.GetFocusedRow();

            int ID = printLogMeta.ID;
            
            HCMIS.Core.Distribution.Services.PrintLogService printout = new HCMIS.Core.Distribution.Services.PrintLogService();

           using  (SaveFileDialog SaveDialog = new SaveFileDialog())
           {
               SaveDialog.DefaultExt = ".pdf";
               if (SaveDialog.ShowDialog() != DialogResult.Cancel)
               {
                   printout.ToFile(ID, SaveDialog.FileName);
                   XtraMessageBox.Show("Your PDF is Exported", "Thanks");
               }
                   
           }
          
        }

        private void btnPrintLogGo_Click(object sender, EventArgs e)
        {
            // 
            gridPrintLog.DataSource =
                HCMIS.Core.Distribution.Services.PrintLogService.GetDocumentMeta(
                    lkPrintLogDocumentType.EditValue.ToString(), Convert.ToDateTime(dtPrintLogFrom.EditValue),
                    Convert.ToDateTime(dtPrintLogTo.EditValue));
        }

        private static string MakeValidFileName(string name)
        {
            string invalidChars = System.Text.RegularExpressions.Regex.Escape(new string(System.IO.Path.GetInvalidFileNameChars()));
            string invalidReStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);try
            {
                return System.Text.RegularExpressions.Regex.Replace(name, invalidReStr, "_");
            }
            catch
            {
                return "";
            }
            
        }

        private void btnPrintLogSaveAll_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog SaveDialog = new SaveFileDialog())
            {
                
                if (SaveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    HCMIS.Core.Distribution.Services.PrintLogService printout = new HCMIS.Core.Distribution.Services.PrintLogService();
                    IEnumerable<HCMIS.Core.Distribution.Services.PrintLogMeta> logs =
                        (IEnumerable<HCMIS.Core.Distribution.Services.PrintLogMeta>) gridPrintLog.DataSource;
                    if (logs != null)
                    {
                        foreach (var log in logs)
                        {
                            string fileName = SaveDialog.FileName + "_" + ((log.PrintedID != null) ?log.PrintedID : log.Reference) + "_" + MakeValidFileName(log.Description) + ".pdf";
                            printout.ToFile(log.ID, fileName);
                        }
                        XtraMessageBox.Show("All PDFs Exported","Thanks");
                    }
                    

                }
                   
            }
        }

        private void btnFixExpirySettings_Click(object sender, EventArgs e)
        {
            Item.FixExpirySettings();
        }

        private void btnFinance_Click(object sender, EventArgs e)
        {
            using(Finance finance = new Finance())
            {
                finance.ShowDialog(this);
            }
        }

        private void btnFindInconsistencies_Click(object sender, EventArgs e)
        {
            //grdInconsistencyList.DataSource = BLL.Balance.GetItemsWithQuantityInconsistency();
        }

        private void btnStockAvailabilityStats_Click(object sender, EventArgs e)
        {
            grdTemp.DataSource = ConstructStockAvailabilityStat(Convert.ToInt32(txtYear.EditValue),
                                                                 Convert.ToInt32(txtMonth.EditValue));   
        }

        private DataTable ConstructStockAvailabilityStat(int year, int month)
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add(new DataColumn("Year", typeof(int)));
            tbl.Columns.Add(new DataColumn("Month", typeof(int)));
            tbl.Columns.Add(new DataColumn("OverStocked", typeof(int)));
            tbl.Columns.Add(new DataColumn("Normal", typeof(int)));
            tbl.Columns.Add(new DataColumn("NearEOP", typeof(int)));
            tbl.Columns.Add(new DataColumn("BelowEOP", typeof(int)));
            tbl.Columns.Add(new DataColumn("StockedOut", typeof(int)));

            BLL.Models.StockAvailabilityStatistics statistics = BLL.Balance.GetStockAvailabilityStats(month, year);

            DataRow dataRow = tbl.NewRow();
            dataRow["Year"] = year;
            dataRow["Month"] = month;
            dataRow["OverStocked"] = statistics.OverStocked;
            dataRow["Normal"] = statistics.Normal;
            dataRow["NearEOP"] = statistics.NearEOP;
            dataRow["BelowEOP"] = statistics.BelowEOP;
            dataRow["StockedOut"] = statistics.Stockout;

            tbl.Rows.Add(dataRow);
            return tbl;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "Microsoft Excel Files (*.xlsx)|*.xlsx";
            file.ShowDialog();
            if (String.IsNullOrEmpty(file.FileName))
            {
                return;
            }
            grdViewTemp.ExportToXlsx(file.FileName);
        }

        private void txtItemSerialNumber_EditValueChanged(object sender, EventArgs e)
        {
            int serialNumber = Convert.ToInt32(txtItemSerialNumber.Text);
            BLL.Item itm = new Item();
            txtItemID.Text = itm.GetIDFromSerialNumber(serialNumber).ToString();
        }

        private void txtItemID_EditValueChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtItemID.Text);
            BLL.Item itm = new Item();
            txtItemSerialNumber.Text = itm.GetSerialNumberFromItemID(id).ToString();
        }



    }
}