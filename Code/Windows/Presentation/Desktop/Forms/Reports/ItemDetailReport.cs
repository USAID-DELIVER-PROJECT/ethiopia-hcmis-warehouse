using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using DAL;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using HCMIS.Desktop.Helpers;
using HCMIS.Desktop.Properties;
using HCMIS.Desktop.Forms.Modals;
using HCMIS.Desktop.Reports.Helpers;
using HCMIS.Desktop.Reports.Reports;
using HCMIS.Reports.Helpers;

namespace HCMIS.Desktop.Forms.Reports
{
    public partial class ItemDetailReport : XtraForm
    {
        int _ItemID = 0;
        int _StoreID = 1;
        int _Year = 0;
        private int? _UnitID = 0;
        DateTime dtCurrent = new DateTime();
        bool chartsDrawn = false;
        private BinCardReport binCardReport = null;

        public ItemDetailReport()
        {
            InitializeComponent();
        }

        public ItemDetailReport(int itmId, int? unitID, int storeid, int yr)
        {
            InitializeComponent();
            _ItemID = itmId;
            _StoreID = storeid;
            _UnitID = unitID;
            _Year = (yr < 1990) ? 2003 : yr;
          
        }

        private void BinCardTransactionLoad(object sender, EventArgs e)
        {
            Item itm = new Item();
            itm.LoadByPrimaryKey(_ItemID);
            txtItemName.Text = txtitmName.Text = itm.FullItemName;
            this.Text = string.Format("{0} Detail Report", itm.FullItemName);

            BLL.Warehouse clusters = new BLL.Warehouse();
            clusters.LoadUsersClustersContainingItem(CurrentContext.UserId, _ItemID, _UnitID.Value, _StoreID);
            lkWarehouses.Properties.DataSource = clusters.DefaultView;
            lkWarehouses.ItemIndex = 0;

            lkBinCardWarehouse.Properties.DataSource = clusters.DefaultView;
            lkBinCardWarehouse.ItemIndex = 0;

            lblItemID.Text = this._ItemID.ToString();
            lblItemSerialNumber.Text = itm.SerialNumber;

            lkYear.Properties.DataSource = itm.AllYears();
            lkYear.EditValue = _Year;

            lkWarehouses_EditValueChanged(null, null);

            ItemUnit iu = new ItemUnit();
            iu.LoadByPrimaryKey(_UnitID.Value);
            lblBUnit.Text = iu.Text;


            dtDate.Value = DateTimeHelper.ServerDateTime;
            dtDate.CustomFormat = "MM/dd/yyyy";
            dtCurrent = ConvertDate.DateConverter(dtDate.Text);
            


            


            Activity stor = new Activity();
            stor.LoadByPrimaryKey(_StoreID);

            BindLocationView();

            if (CurrentContext.LoggedInUser.UserType == UserType.Constants.FINANCE ||
                CurrentContext.LoggedInUser.UserType == UserType.Constants.FUND_OFFICER)
            {
                tbClassicBinCard.Text = "Stock Card";
            }
            else
            {
                colTotalCost.Visible = false;
                colUnitCost.Visible = false;
                tbSOHPriceSummary.Visible = false;
            }

            if (this.HasPermission("Show-Classic-Bin-Card"))
            {
                tbClassicBinCard.Visible = false;
            }
            if (this.HasPermission("Show-Bin-Card"))
            {
                tbBinCard.Visible = false;
            }
        }

        private void BindLocationView()
        {
            ReceiveDoc rec = new ReceiveDoc();
            DataTable dtbl = rec.GetRecievedItemsWithBalance(_ItemID, _StoreID, _UnitID);
            dtbl.DefaultView.Sort = "ExpiryDate";

            PalletLocation.PopulatePalletLocationFor(dtbl);
            gridView1.ExpandAllGroups();
            gridLocations.DataSource = dtbl.DefaultView;
            gridSOHSummary.DataSource = dtbl.DefaultView;
        }

        

        private void BtnPrintClicked(object sender, EventArgs e)
        {
            if (transactionGrid.DataSource == null)
            {
                XtraMessageBox.Show("Select the BinCard to Print", "Select Bincard", MessageBoxButtons.OK,
                                    MessageBoxIcon.Asterisk);
                return;
            }
            if (tabControl1.SelectedTabPage == tbSOHLocation)
            {
                PrintableComponentLink pcl = new PrintableComponentLink(new PrintingSystem());
                pcl.Component = gridLocations;
                pcl.Landscape = true;

                Item itm = new Item();
                itm.GetItemById(_ItemID);

                pcl.RtfReportHeader = "Locations For: " + itm.FullItemName + "\n";
                pcl.RtfReportFooter = DateTimeHelper.ServerDateTime.ToShortDateString();
                pcl.PrintDlg();

            }
            else if (tabControl1.SelectedTabPage == tbSOHPriceSummary)
            {
                PrintableComponentLink pcl = new PrintableComponentLink(new PrintingSystem());
                pcl.Component = gridSOHSummary;
                pcl.Landscape = true;

                Item itm = new Item();
                itm.GetItemById(_ItemID);

                pcl.RtfReportHeader = "Price Summary For: " + itm.FullItemName + "\n";
                pcl.RtfReportFooter = DateTimeHelper.ServerDateTime.ToShortDateString();
                pcl.PrintDlg();
            }
            else
            {
                PrintableComponentLink pcl = new PrintableComponentLink(new PrintingSystem());
                pcl.Component = transactionGrid;
                pcl.Landscape = true;

                Item itm = new Item();
                itm.GetItemById(_ItemID);

                pcl.RtfReportHeader = "Transactions For: " + itm.FullItemName + "\n";
                pcl.RtfReportFooter = DateTimeHelper.ServerDateTime.ToShortDateString();
                pcl.PrintDlg();
            }
        }

        private void LkShowTableLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            groupSohDetail.Visible = !groupSohDetail.Visible;
            lkShowTable.Text = ((groupSohDetail.Visible) ? "Hide Detail" : "Show Detail");
            if (groupSohDetail.Visible)
                DetailSoh();

        }

        private void DetailSoh()
        {
            dtDate.Value = DateTimeHelper.ServerDateTime;
            dtDate.CustomFormat = "MM/dd/yyyy";
            DateTime dtCurrent = new DateTime();// Convert.ToDateTime(dtDate.Text);
            try
            {
                dtCurrent = Convert.ToDateTime(dtDate.Text);
            }
            catch
            {
                string dtValid = "";
                string yer = "";
                if (Convert.ToInt32(dtDate.Text.Substring(0, 2)) == 13)
                {
                    dtValid = dtDate.Text;
                    yer = dtValid.Substring(dtValid.Length - 4, 4);
                    dtCurrent = Convert.ToDateTime("12/30/" + yer);
                }
                else if (Convert.ToInt32(dtDate.Text.Substring(0, 2)) == 2)
                {
                    dtValid = dtDate.Text;
                    yer = dtValid.Substring(dtValid.Length - 4, 4);
                    dtCurrent = Convert.ToDateTime("2/28/" + yer);
                }
            }
        }

        private void BtnExportClick(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if(transactionGrid.DataSource ==null)
            {
                XtraMessageBox.Show("Select the BinCard to Export", "Select Bincard", MessageBoxButtons.OK,
                                    MessageBoxIcon.Asterisk);
                return;
            }
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                transactionGrid.ExportToXlsx(sfd.FileName + ".xlsx");
                XtraMessageBox.Show("The bin card has been exported.");

            }
        }

        private void LkProgramFilterEditValueChanged(object sender, EventArgs e)
        {
            int supplierId = Convert.ToInt32(lkProgramFilter.EditValue);
            if (supplierId != 0)
            {
                transactionGrid.DataSource = Balance.GetBinCard(_StoreID, _ItemID, _UnitID, _Year, supplierId);
            }
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lkYear_EditValueChanged(object sender, EventArgs e)
        {
            lkWarehouses_EditValueChanged(null, null);
        }

        private void tabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            int idx = tabControl1.SelectedTabPageIndex;
            if (idx >= 2 && idx <= 10 && !chartsDrawn) ;
                //GenerateCharts();
        }

        private void lkWarehouses_EditValueChanged(object sender, EventArgs e)
        {
            if (lkWarehouses.EditValue != null && Convert.ToInt32(lkYear.EditValue) != 0)
            {
                transactionGrid.DataSource = Balance.GetBinCardByWarehouse(_StoreID, _ItemID, _UnitID, Convert.ToInt32(lkYear.EditValue), Convert.ToInt32(lkWarehouses.EditValue));    
            }
            
        }

        private void tpDelete_Click(object sender, EventArgs e)
        {
         
         DataRow dr = gridViewBinCard.GetFocusedDataRow();
         if (Convert.ToInt32(dr["Precedance"]) != 3)
         {
             XtraMessageBox.Show("You cannot delete this");
             return;
         }
         if (CurrentContext.LoggedInUser.UserType == UserType.Constants.DISTRIBUTION_MANAGER_WITH_DELETE)
         {

             if (
                 XtraMessageBox.Show(
                     "Are you sure you want to delete this transaction? You will not be able to undo this.",
                     "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
             {
                 MyGeneration.dOOdads.TransactionMgr tranMgr =
                     MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgr();

                 try
                 {
                     tranMgr.BeginTransaction();

                     ReceiveDoc rdoc = new ReceiveDoc();
                     ReceivePallet rp = new ReceivePallet();
                     IssueDoc idoc = new IssueDoc();

                     PickListDetail pld = new PickListDetail();
                     int issueID = Convert.ToInt32(dr["ID"]);
                     //pld.LoadByOrderAndItem(Convert.ToInt32(dr["OrderID"]), Convert.ToInt32(dr["ItemID"]),
                     //                       Convert.ToInt32(dr["Quantity"]));
                     idoc.LoadByPrimaryKey(issueID);
                     pld.LoadByPrimaryKey(idoc.PLDetailID);

                     string RefNo = idoc.RefNo;

                     rdoc.LoadByPrimaryKey(idoc.RecievDocID);


                     //if (pld.RowCount == 0)
                     //{
                     //    pld.LoadByOrderAndItem(Convert.ToInt32(dr["OrderID"]), Convert.ToInt32(dr["ItemID"]));
                     //}

                     rp.LoadByPrimaryKey(pld.ReceivePalletID);
                     PalletLocation pl = new PalletLocation();
                     pl.loadByPalletID(rp.PalletID);

                     if (pl.RowCount == 0)
                     {
                         pl.LoadByPrimaryKey(pld.PalletLocationID);
                         if (pl.IsColumnNull("PalletID"))
                         {
                             pl.PalletID = rp.PalletID;
                             pl.Save();
                         }
                         //rp.LoadNonZeroRPByReceiveID(rdoc.ID);
                     }


                     if (rp.RowCount == 0)
                     {
                         XtraMessageBox.Show("You cannot delete this item, please contact the administrator", "Error");
                         return;
                     }
                     if (rp.RowCount > 0)
                     {
                         rdoc.QuantityLeft += idoc.Quantity;
                         rp.Balance += idoc.Quantity;
                         pld.QuantityInBU = 0;


                         // are we adding it the pick face?
                         // if so add it to the balance of the pick face also
                         pl.loadByPalletID(rp.PalletID);

                         if (pl.RowCount == 0)
                         {
                             PutawayLocation plocation = new PutawayLocation(rdoc.ItemID);

                             // we don't have a location for this yet,
                             // select a new location
                             //PutawayLocataion pl = new PutawayLocataion();
                             if (plocation.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                             {
                                 pl.LoadByPrimaryKey(plocation.PalletLocationID);
                                 if (pl.RowCount > 0)
                                 {
                                     pl.PalletID = rp.PalletID;
                                     pl.Save();
                                 }
                             }
                         }

                         if (pl.RowCount > 0)
                         {

                             PickFace pf = new PickFace();
                             pf.LoadByPalletLocation(pl.ID);
                             if (pf.RowCount > 0)
                             {
                                 pf.Balance += Convert.ToInt32(idoc.Quantity);
                                 pf.Save();
                             }


                             IssueDocDeleted.AddNewLog(idoc, CurrentContext.UserId);
                             idoc.MarkAsDeleted();
                             rdoc.Save();
                             rp.Save();
                             idoc.Save();


                             // now refresh the window
                             XtraMessageBox.Show("Issue Deleted!", "Confirmation", MessageBoxButtons.OK,
                                                 MessageBoxIcon.Information);
                             tranMgr.CommitTransaction();
                             //TODO: refresh the list
                             // gridViewReferences_FocusedRowChanged(null, null);
                         }


                     }
                     else
                     {
                         XtraMessageBox.Show(
                             "This delete is not successfull because a free pick face location was not selected. please select a free location and try again.",
                             "Error Deleteing issue transaction", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         tranMgr.RollbackTransaction();
                     }
                 }
                 catch
                 {
                     XtraMessageBox.Show("This delete is not successfull", "Warning ...", MessageBoxButtons.OK,
                                         MessageBoxIcon.Warning);
                     tranMgr.RollbackTransaction();
                 }
             }
         }
         else
         {
             XtraMessageBox.Show(
                 "You cannot delete this transaction because you don't have previlage. Please contact the administrator if you thing this is an error.",
                 "Delete is not allowed");
         }
        }

        private void lkBinCardWarehouse_EditValueChanged(object sender, EventArgs e)
        {
            if(_UnitID.HasValue && lkBinCardWarehouse.EditValue != null)
            {
                BinCardReport report = ReportingReportFactory.CreateBinCard(_StoreID, _ItemID, _UnitID.Value,
                                                                            Convert.ToInt32(lkBinCardWarehouse.EditValue));
                printBinCard.PrintingSystem = report.PrintingSystem;

                report.PrintingSystem.ExecCommand(DevExpress.XtraPrinting.PrintingSystemCommand.ZoomToPageWidth, null);
                binCardReport = report;
                // Generate the report's print document. 
                report.CreateDocument(); 
            }
        }

    }
}