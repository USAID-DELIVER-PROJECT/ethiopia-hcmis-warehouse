using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using HCMIS.Helpers;

namespace HCMIS.Desktop.Forms.Reports
{
    [FormIdentifier("RP-IR-IR-RP","Issue By Receiving Unit","")]
    public partial class IssuesByReceivingUnit : XtraForm
    {
        DataTable _issuesByReceivingUnit;

        public IssuesByReceivingUnit()
        {
            InitializeComponent();
        }
        int catID = 0;
        bool _IsReady = false;
        private void ManageItems_Load(object sender, EventArgs e)
        {

            lkCategories.Properties.DataSource = BLL.CommodityType.GetAllTypes();
            lkCategories.ItemIndex = 0;

            dtFrom.Value = DateTime.Today;
            dtTo.Value = DateTime.Today;
           
            Activity stor = new Activity();
            stor.LoadAll();
            DataView dv = stor.DefaultView;
            cboStores.Properties.DataSource = stor.DefaultView;
            cboStores.ItemIndex = 0;
            Route route = new Route();
            route.LoadAll();
            lkRoutes.Properties.DataSource = route.DefaultView;
            lkRoutes.EditValue = route.RouteID;
            _IsReady = true;
       //     PopulateItemList();
            
        }

       

        public void PopulateItemList()
        {

            gridView1.Columns.Clear();
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.RunWorkerAsync();
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _issuesByReceivingUnit = (DataTable)e.Result;
            gridDetailReport.DataSource = _issuesByReceivingUnit;
           // FilterByExclude();


            gridView1.Columns["ID"].Visible = false;
            gridView1.Columns["FullItemName"].Width = 300;
            gridView1.Columns["FullItemName"].Fixed = FixedStyle.Left;
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            Item itms = new Item();
            e.Result = itms.GetIssuesByReceivingUnit(Convert.ToInt32(cboStores.EditValue),Convert.ToInt32(lkRoutes.EditValue),Convert.ToInt32(lkCategories.EditValue) );
            //e.Result = itms.GetIssuesByReceivingUnitFaster(Convert.ToInt32(cboStores.EditValue), Convert.ToInt32(lkRoutes.EditValue), Convert.ToInt32(lkCategories.EditValue));
            
        }



        private void btnSearchByDate_Click(object sender, EventArgs e)
        {
            Item itm = new Item();
            DataTable dtItm  = new DataTable();
            if (dtFrom.Value <= dtTo.Value)
            {
               // PopulateItemListByDateRange();
              }            
        }
        private void btnfilter_Click(object sender, EventArgs e)
        {
            string x = cboStores.EditValue.ToString();
            Item itm = new Item();
            DataTable dtItm = new DataTable();
            if (dtFrom.Value <= dtTo.Value)
            {
                // PopulateItemListByDateRange();
                Item itms = new Item();
                _issuesByReceivingUnit = itms.GetIssuesByReceivingUnit(Convert.ToInt32(cboStores.EditValue), Convert.ToInt32(lkRoutes.EditValue), Convert.ToInt32(lkCategories.EditValue), dtFrom.Value, dtTo.Value,Convert.ToInt32( cboStores.EditValue));
                gridDetailReport.DataSource = _issuesByReceivingUnit;
                //FilterByExclude();

                gridView1.Columns["ID"].Visible = false;
                gridView1.Columns["FullItemName"].Width = 300;
                gridView1.Columns["FullItemName"].Fixed = FixedStyle.Left;

            }
        }
        private void PopulateItemListByDateRange()
        {
            //throw new NotImplementedException();
        }



        private void xpButton1_Click(object sender, EventArgs e)
        {
          
            dtDate.Value = DateTimeHelper.ServerDateTime;
            dtDate.CustomFormat = "MM/dd/yyyy";

            string header = GeneralInfo.Current.HospitalName + " Issues By Receiving Units " + cboStores.Text + " Date: " + dtDate.Text;
            gridDetailReport.ShowPrintPreview();
        }

        private void xpButton2_Click(object sender, EventArgs e)
        {
            
            dtDate.Value = DateTimeHelper.ServerDateTime;
            dtDate.CustomFormat = "MM/dd/yyyy";

            string[] header = { GeneralInfo.Current.HospitalName, " Issues By Receiving Units ", cboStores.Text, " Date: " + dtDate.Text };
            gridDetailReport.ShowPrintPreview();
        }


        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            gridView1.ActiveFilterString = "[FullItemName] Like '" + txtItemName.Text + "%'";  
        }


        private void lkRoutes_EditValueChanged(object sender, EventArgs e)
        {
            if (_IsReady)
            {
               // PopulateItemList();
            }
        }

        private void chkExclude_EditValueChanged(object sender, EventArgs e)
        {
            FilterByExclude();
        }

        private void FilterByExclude()
        {
            bool ExcludeNeverRecieved = chkExcludeNReceived.Checked;
            bool ExcludeNeverIssued = chkExcludeNIssued.Checked;

            if (_issuesByReceivingUnit != null)
            {
                DataTable dtbl = _issuesByReceivingUnit.Clone();

                Dictionary<int,int> issuedArray = Item.GetIssuedItems();
                Dictionary<int,int> receivedArray = Item.GetRecievedItems();

                // God, Please forgive me for all the try catch
                foreach (DataRow dr in _issuesByReceivingUnit.Rows)
                {
                    int itemId = Convert.ToInt32(dr["ID"]);
                    if (ExcludeNeverRecieved && ExcludeNeverIssued)
                    {
                        try
                        {
                            if (issuedArray[itemId] != 0 && receivedArray[itemId] != 0)
                            {
                                dtbl.ImportRow(dr);
                            }
                        }
                        catch { }
                    }
                    else if (ExcludeNeverRecieved)
                    {
                        try
                        {
                            if (receivedArray[itemId] != 0)
                            {
                                dtbl.ImportRow(dr);
                            }
                        }
                        catch { }
                    }
                    else if (ExcludeNeverIssued)
                    {
                        try
                        {
                            if (issuedArray[itemId] != 0)
                            {
                                dtbl.ImportRow(dr);
                            }
                        }
                        catch { }
                    }
                    else
                    {
                        dtbl.ImportRow(dr);
                    }
                }
                gridDetailReport.DataSource = dtbl;
            }

            gridView1.Columns["ID"].Visible = false;
            gridView1.Columns["FullItemName"].Width = 300;
            gridView1.Columns["FullItemName"].Fixed = FixedStyle.Left;
        }

        private void lkCategories_EditValueChanged(object sender, EventArgs e)
        {
            if ( _IsReady && cboStores.EditValue != null)
            {
                Item itm = new Item();
                int storeId = Convert.ToInt32(cboStores.EditValue);
                DataTable dtItem = new DataTable();

               // PopulateItemList();
                lblState.Text = "All Items";
             
            }
        }

        private void btnload_Click(object sender, EventArgs e)
        {
            PopulateItemList();
        }
        
        
    }
}