using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Nodes.Operations;
using HCMIS.Helpers;
using HCMIS.Desktop.Forms.Utilities;
using HCMIS.Desktop.Helpers;
using HCMIS.Desktop.Reports;


namespace  HCMIS.Desktop.Forms.Reports
{
    [FormIdentifier("RP-SSN-SS-RP", "Stock Status New", "")]
    public partial class StockStatusReport : XtraForm
    {
     
        private int storeId;
        private string type;
        private int categoryID;
        private bool isReady = false;

        public StockStatusReport()
        {
            InitializeComponent();
        }

        private void RefreshFilterCriteria(object sender, EventArgs e)
        {
            RefreshFilter();
        }

        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
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

        private void txtName_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            RefreshFilter();
        }


        private void lkPrograms_EditValueChanged(object sender, EventArgs e)
        {
            RefreshFilter();
        }

        private void StockReportLoad(object sender, EventArgs e)
        {

            DataView dataView = Activity.GetAccountTree(CurrentContext.UserId);
            accountTree.DataSource = dataView;
            
            lkCategories.Properties.DataSource = BLL.CommodityType.GetAllTypes();
            lkCategories.ItemIndex = 0;

            isReady = true;
        }

        private void lkCategories_EditValueChanged(object sender, EventArgs e)
        {
            lkAccounts_EditValueChanged(null, null);
            RefreshFilter();
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

        

        private void lkAccounts_EditValueChanged(object sender, EventArgs e)
        {
            
            DataRowView o = (DataRowView)accountTree.GetDataRecordByNode(accountTree.FocusedNode);
            if (isReady && o != null && lkCategories.EditValue != null)
            {
              
                storeId = Convert.ToInt32(o["ID"]);
                type = o["Type"].ToString();
               

                
                categoryID = Convert.ToInt32(lkCategories.EditValue);
                this.Enabled = false;
                if (!bw.IsBusy)
                {
                    bw.RunWorkerAsync();
                }
            }
           
        }

        private void accountTree_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {

            DataRowView o = (DataRowView)accountTree.GetDataRecordByNode(accountTree.FocusedNode);
          
            lkAccounts_EditValueChanged(null, null);
           
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            int month = EthiopianDate.EthiopianDate.Now.Month;
            int year = EthiopianDate.EthiopianDate.Now.FiscalYear;
            e.Result = Balance.GetSohForAllItemsByType(storeId,
                                                                              type,
                                                                              CurrentContext.UserId, year, month, categoryID);
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            gridDetailReport.DataSource = e.Result;
            gridDetailReport.MainView = gridReadinessView;
            RefreshFilter();
            this.Enabled = true;
        }





    }
}