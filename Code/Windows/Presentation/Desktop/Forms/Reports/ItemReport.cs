using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using HCMIS.Helpers;
using HCMIS.Desktop.Forms.Utilities;
using HCMIS.Desktop.Reports;
using HCMIS.Desktop.ViewHelpers;

namespace  HCMIS.Desktop.Forms.Reports
{
    [FormIdentifier("RP-SS-RV-RP","Stock Status Report","")]
    public partial class ItemReport : XtraForm
    {
        DateTime _dtCur = new DateTime();
        bool IsReady = false;
        private string StockStatus;


        public ItemReport()
        {

            InitializeComponent();

            // Show all by default.
            this.StockStatus = "All";
        }

        public ItemReport(string status)
        {
            InitializeComponent();
            // TODO: Complete member initialization
            this.StockStatus = status;

        }

        private void PopulateGrid()
        {
            if (IsReady)
            {
               
                if ((cboYear.EditValue != null) && (cboMonth.EditValue != null) && (lkStore.EditValue != null))
                {
                    int storeId;
                    storeId = (lkStore.EditValue != null && lkStore.EditValue != "") ? Convert.ToInt32(lkStore.EditValue) : 1;
                    int month = Convert.ToInt32(cboMonth.EditValue);
                    int year = Convert.ToInt32(cboYear.EditValue);

                    // different criteri for different options like suply and drug
                    int programID = ((lkPrograms.EditValue != null) ? Convert.ToInt32(lkPrograms.EditValue) : 0);
                    int WarehouseID = ((lkWarehouse.EditValue != null) ? Convert.ToInt32(lkWarehouse.EditValue) : 0);
                    int commodityType = Convert.ToInt32(lkCategories.EditValue);

                    pbLoad.Visible = true;
                    if (!bw.IsBusy)
                    {
                        this.Enabled = false;
                        bw.RunWorkerAsync(new int[] { storeId, month, year, programID,WarehouseID,commodityType });
                    }
                }
            }
        }


        private void RefreshFilterCriteria(object sender, EventArgs e)
        {
            RefreshFilter();
        }

        private void gridItemsChoice_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = (gridDetailReport.MainView as GridView).GetFocusedDataRow();
                //gridReadinessView.GetFocusedDataRow();
            if (dr != null)
            {
                int itemId = Convert.ToInt32(dr["ID"]);
                int unitID = dr["UnitID"] != DBNull.Value ? Convert.ToInt32(dr["UnitID"]) : 0;
                dtDate.Value = DateTimeHelper.ServerDateTime;
                dtDate.CustomFormat = "MM/dd/yyyy";
                _dtCur = ConvertDate.DateConverter(dtDate.Text);
                int month = Convert.ToInt32(cboMonth.EditValue);
                int year = (month < 11) ? Convert.ToInt32(cboYear.EditValue) : Convert.ToInt32(cboYear.EditValue);
                ItemDetailReport con = new ItemDetailReport(itemId,unitID, Convert.ToInt32(lkStore.EditValue), year);
                con.ShowDialog();
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            int[] arr = (int[])e.Argument;

            int storeId = arr[0], month = arr[1], year = arr[2],WarehouseID = arr[4],commodityType=arr[5];
            if (WarehouseID == 0)
            {
                e.Result = Balance.GetSohForAllItems(storeId,commodityType, year, month);
            }
            else
            {
                e.Result = Balance.GetSohForAllItemsByWareHouse(storeId, year, month,WarehouseID);
            }
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                gridDetailReport.DataSource = (DataTable)e.Result;
                
                RefreshFilter();
            }
            layoutProgressBar.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            this.Enabled = true;

            // if there is a filter apply it.
            cboStatus.EditValue = "";
            if (this.StockStatus != "" && this.StockStatus != null)
            {
                cboStatus.EditValue = this.StockStatus;
            }
        }

        private void RefreshFilter()
        {
            string filterString = string.Format("[TypeID] = '{0}'", lkCategories.EditValue);
            if (lkPrograms.EditValue != null)
            {
                //filterString += string.Format(" AND [Program] = {0}", lkPrograms.EditValue);
            }
            if (ckExclude.Checked)
            {
                filterString += " AND [EverReceived] != 0";
            }

            if (ckExcNeverIssued.Checked)
            {
                filterString += " AND [Issued] != 0";
            }

            if (txtName.EditValue != null)
            {
                filterString += " AND [FullItemName] Like '" + txtName.Text + "%'";
            }

            if (cboStatus.SelectedItem.ToString() != "All" && cboStatus.SelectedItem.ToString() != "")
            {
                filterString += " AND [Status] Like '" + cboStatus.SelectedItem.ToString() + "'";
            }
            // TOO BAD We don't have any better way than to check Existence of 'all'
            // This shall be changed.
            if (lkPrograms.EditValue != null && lkPrograms.Text.IndexOf("All") < 0)
            {
                filterString += string.Format(" AND [ProgramID] = '{0}'", lkPrograms.EditValue.ToString());
            }

            if (chkOnlyVital.Checked)
            {
                filterString += string.Format(" AND [VENID] = {0}", VEN.Constants.VITAL);
            }

            try
            {
                
                (gridDetailReport.MainView as GridView).ActiveFilterString = filterString;
            }
            catch {
                (gridDetailReport.MainView as GridView).ActiveFilterString = "";
            }
        }

    

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbLoad.EditValue = e.ProgressPercentage;
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {            
            string statusFilter=cboStatus.SelectedItem.ToString();
            
            DataView dvw = (gridDetailReport.DataSource as DataTable).AsDataView();
            string filterString = "";

            if (statusFilter != "All")
                filterString = "[Status] = '" + statusFilter + "'";
            
            if (ckExclude.Checked)
            {
                filterString += (filterString == "") ? "" : " AND";
                filterString += " [Received] <> 0";
            }

            if (ckExcNeverIssued.Checked)
            {
                filterString += (filterString == "") ? "" : " AND";
                filterString += " [Issued] <> 0";
            }

            if (chkOnlyVital.Checked)
            {
                filterString += filterString == "" ? string.Format("[VENID]={0}", VEN.Constants.VITAL) : string.Format(" AND [VENID] = {0}", VEN.Constants.VITAL);
            }
            try
            {
                dvw.RowFilter = filterString;
            }
            catch
            {

            }
            
            dvw.Sort = "Type";
            DataTable dtbl = dvw.ToTable();
            //Add a row number
            dtbl.Columns.Add("LineNo", typeof(int));
            int i = 1;
            foreach (DataRow dRow in dtbl.Rows)
            {
                dRow["LineNo"]=i;
                i++;
            }
            
            if (dtbl != null)
            {
                HCMIS.Desktop.Reports.StockStatus ss = new HCMIS.Desktop.Reports.StockStatus();
                
                ss.HubName.Text = GeneralInfo.Current.HospitalName;
                if (statusFilter != "Normal" && statusFilter != "All")
                    ss.ItemFilter.Text = statusFilter;
                else if (statusFilter == "Normal")
                    ss.ItemFilter.Text = "Normal Stock Items";
                else if (statusFilter == "All")
                    ss.ItemFilter.Text = "All Items";

                if (chkOnlyVital.Checked)
                    ss.ItemFilter.Text = "Vital Items";

                ss.DataSource = dtbl;
                ss.ShowPreviewDialog();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                gridDetailReport.ExportToXlsx(sfd.FileName + ".xlsx");
                XtraMessageBox.Show("Stock Status was exported!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BeforeLayout(object sender, LayoutEventArgs e)
        {
            if (this.IsReady)
            {
                return;
            }
            // Do this only the first time, when the page loaded.
            //PopulateCatTree(SelectedType);
            DataTable dtMonths = new DataTable();
            dtMonths.Columns.Add("Value");
            dtMonths.Columns.Add("Month");
            dtDate.Value = DateTimeHelper.ServerDateTime;
            dtDate.CustomFormat = "MM/dd/yyyy";
            _dtCur = ConvertDate.DateConverter(dtDate.Text);
            int currentMont = _dtCur.Month;

            int year = _dtCur.Year;// ((currentMont < 11) ? _dtCur.Year : _dtCur.Year + 1);

            Item itm = new Item();
            DataTable dtyears = itm.AllYears();

            cboYear.Properties.DataSource = dtyears;
            cboYear.EditValue = year;
            BLL.Program prog = new BLL.Program();
            new DataTable();

            DataTable dtProg = prog.GetSubPrograms();
            object[] objProg = { 0, "All Programs", "", 0, "" };
            dtProg.Rows.Add(objProg);
            lkPrograms.Properties.DataSource = dtProg;
            lkPrograms.EditValue = 0;


            lkStore.SetupActivityEditor().SetDefaultActivity();

            //lkStore.EditValue = (BLL.Settings.IsRdfMode)? 9: 1;    
            this.IsReady = true;
            layoutProgressBar.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            PopulateGrid();
        }

        private void txtName_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            RefreshFilter();
        }


        private void lkPrograms_EditValueChanged(object sender, EventArgs e)
        {
            RefreshFilter();
            //PopulateGrid();
        }

        private void cboYear_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dtMonths = new DataTable();
            dtMonths.Columns.Add("Value");
            dtMonths.Columns.Add("Month");
            dtDate.Value = DateTimeHelper.ServerDateTime;
            dtDate.CustomFormat = "MM/dd/yyyy";
            _dtCur = ConvertDate.DateConverter(dtDate.Text);
            int currentMont = _dtCur.Month;
            int currentYear = _dtCur.Year;
            int[] val = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            string[] mon = { "Meskerem", "Tikemt", "Hedar", "Tahsas", "Tir", "Yekatit", "Megabit", "Miziya", "Genbot", "Sene", "Hamle", "Nehase"};
            int i = 0; //currentMont;
            if (Convert.ToInt32(cboYear.EditValue) == currentYear)
            {
                for (i = 0; i < val.Length; i++)
                {
                    if (val[i] == currentMont)
                    {
                        break;
                    }
                }
            }
            else
            {
                i = val.Length - 1;
            }
            for (int j = i; j >= 0; j--)
            {
                object[] obj = { val[j], mon[j] };
                dtMonths.Rows.Add(obj);
            }
            cboMonth.Properties.DataSource = dtMonths;
            cboMonth.EditValue = dtMonths.Rows[0]["Value"];
            PopulateGrid();
        }

        private void CboMonthEditValueChanged(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void RadioViewSelectorSelectedIndexChanged(object sender, EventArgs e)
        {
            if (lkStore.EditValue != "")
            {


                // Prapare parameters for SOH Stored Proc
                
                // different criteria for different options like supply and drug
                int programId = ((lkPrograms.EditValue != null) ? Convert.ToInt32(lkPrograms.EditValue) : 0);
                GetReportData();
                RefreshFilter();
            }
        }

        private void GetReportData()
        {
            int storeId = (lkStore.EditValue != null) ? Convert.ToInt32(lkStore.EditValue) : 1;
            int month = Convert.ToInt32(cboMonth.EditValue);
            int year = Convert.ToInt32(cboYear.EditValue);
            int commodityType = Convert.ToInt32(lkCategories.EditValue);

            if (radioViewSelector.EditValue.ToString() == "Readiness View")
            {
                gridDetailReport.DataSource = Balance.GetSohForAllItems(storeId, commodityType, year, month);

                gridDetailReport.MainView = gridReadinessView;
            }
            else if (radioViewSelector.EditValue.ToString() == "Consumption View")
            {
                gridDetailReport.DataSource = Balance.GetSohForAllItems(storeId, commodityType, year, month);
                gridDetailReport.MainView = gridConsumptionView;
            }
            else if (radioViewSelector.EditValue.ToString() == "Price View")
            {
                gridDetailReport.DataSource = Balance.PriceOfAllItems(storeId, year, month);

                gridDetailReport.MainView = gridPriceView;
                gridPriceView.ExpandAllGroups();
            }
            else if (radioViewSelector.EditValue.ToString() == "Supplier View")
            {
                gridDetailReport.DataSource = Balance.GetBalanceBySupplierId(storeId, year, month);
                gridDetailReport.MainView = gridSupplierView;
            }
            else if (radioViewSelector.EditValue.ToString() == "Expiry View")
            {
                Balance bal = new Balance();
                gridDetailReport.DataSource = bal.GetBalanceByExpiryDate(storeId, year, month, commodityType);
                gridDetailReport.MainView = gridExpView;
            }
            else if (radioViewSelector.EditValue.ToString() == "Batch View")
            {
                Balance bal = new Balance();
                gridDetailReport.DataSource = bal.GetBalanceByBatch(storeId, year, month, commodityType);
                gridDetailReport.MainView = gridBatchView;
            }
        }

        private void StockReportLoad(object sender, EventArgs e)
        {
            lkWarehouse.Properties.DataSource = BLL.Warehouse.GetWarehouseWithCluster(CurrentContext.UserId);
            lkCategories.Properties.DataSource = BLL.CommodityType.GetAllTypes();
            lkCategories.ItemIndex = 0;
        }

        private void lkCategories_EditValueChanged(object sender, EventArgs e)
        {
            if (lkStore.EditValue != null)
            {
                GetReportData();
                RefreshFilter();
            }
            
        }

        private void lkStore_EditValueChanged(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void chkOnlyVital_CheckedChanged(object sender, EventArgs e)
        {
            RefreshFilter();
        }

        private void gridDetailReport_KeyDown(object sender, KeyEventArgs e)
        {
            // this has to be removed after development
            BLL.User user = new User();
            //user.LoadByPrimaryKey(NewMainWindow.UserId);
            user = CurrentContext.LoggedInUser;

            if (e.Control && e.Alt && user.UserType == UserType.Constants.SUPER_ADMINISTRATOR)
            {
                DataRow dr = (gridDetailReport.MainView as GridView).GetFocusedDataRow();
                //gridReadinessView.GetFocusedDataRow();
                if (dr != null)
                {
                    int itemId = Convert.ToInt32(dr["ID"]);
                    Diagnostics diagnostics = new Diagnostics(itemId);
                    diagnostics.WindowState = FormWindowState.Maximized;
                    diagnostics.Show();
                }
            }
        }

        private void btnPrintForAllActivites_Click(object sender, EventArgs e)
        {
            int month = Convert.ToInt32(cboMonth.EditValue);
            int year = Convert.ToInt32(cboYear.EditValue);
            
            SOHReport report = new SOHReport();
            report.DataSource = Balance.GetAllSOHForPrintOut(CurrentContext.UserId,year, month);
            report.ShowPreviewDialog();
        }

    }
}