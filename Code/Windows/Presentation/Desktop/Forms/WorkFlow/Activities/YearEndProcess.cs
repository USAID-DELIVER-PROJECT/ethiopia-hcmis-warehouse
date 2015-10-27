using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using CalendarLib;
using BLL.Services;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using HCMIS.Desktop.Forms.Modals;
using HCMIS.Desktop.Helpers;
using HCMIS.Helpers;
using HCMIS.Desktop.Reports;
using HCMIS.Desktop.ViewHelpers;
using HCMIS.Reports.Reports;


namespace HCMIS.Desktop
{
    [FormIdentifier("IN-IN-MI-FR", "Inventory Screen", "")]
    public partial class YearEndProcess : XtraForm
    {
        Inventory inventory = new Inventory();
        StockStatusByPhysicalStore storeReport = new StockStatusByPhysicalStore(CurrentContext.LoggedInUserName);
        StockStatusByPhysicalStoreWithLocation storeReportWithLocation = new StockStatusByPhysicalStoreWithLocation(CurrentContext.LoggedInUserName);

       
        #region Initialization and Selection

        public YearEndProcess()
        {
            InitializeComponent();
        }

        private void YearEndProcess_Load(object sender, EventArgs e)
        {
           dtStartInventory.Value = DateTimeHelper.ServerDateTime;
           dtEndInventory.Value = DateTimeHelper.ServerDateTime.AddYears(1);
           LoadManageInventory(); 
           SetPermission();  
        }

        private void LoadManageInventory()
        { 
            lkAccountType.SetupActivityEditor().SetDefaultActivity();
            lkInventoryAccount.SetupActivityEditor().SetDefaultActivity();
            lkInventoryStore.SetupAllowedPhysicalStores().SetDefaultPhysicalStore();
            lkPhysicalStore.SetupAllowedPhysicalStores().SetDefaultPhysicalStore();
            gridManageInventory.DataSource = InventoryPeriod.GetInvetoryPeriods();
        }

        private void SetPermission()
        {
            if (BLL.Settings.UseNewUserManagement)
            {
                //btnSaveDraft.Enabled = btnConfirm.Enabled = this.HasPermission("Save");
            }
        }
        
        private void gridManageInvetoryView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridManageInvetoryView.GetFocusedDataRow();
            if (dr != null)
            {
                if (dr["StartDate"] != DBNull.Value)
                {
                    btnStartInventory.Enabled = false;
                }
                else
                {
                    btnStartInventory.Enabled = true;
                }
            }
        }

      
        #endregion

        #region StartInventory

        private void BtnOutstandingTransactions_Click(object sender, EventArgs e)
        {
            var xreport = new OutstandingTransactions(CurrentContext.LoggedInUserName);
            var ds = new DataSet();

            ds.Tables.Add(ReceiveDoc.GetOutstandingReceives());
            ds.Tables[0].TableName = "OutstandingReceives";
            ds.Tables.Add(IssueDoc.GetOutstandingIssues());
            ds.Tables[1].TableName = "OutstandingIssues";
            ds.Tables.Add(ReceiveDoc.GetOutstandingVoidRequestGRV());
            ds.Tables[2].TableName = "OutstandingGRVVoidRequest";
            ds.Tables.Add(IssueDoc.GetOutstandingRequestedVoidForInvoice());
            ds.Tables[3].TableName = "OutstandingInvoiceVoidRequest";
            ds.Tables.Add(IssueDoc.OutstandingIssuedDeliveryNote());
            ds.Tables[4].TableName = "OutstandingIssuedDeliveryNote";
            ds.Tables.Add(ReceiveDoc.GetOutstandingTransfer(ReceiptType.CONSTANTS.ACCOUNT_TO_ACCOUNT_TRANSFER));
            ds.Tables[5].TableName = "OutstandingAccountToAccountTransfer";
            ds.Tables.Add(ReceiveDoc.GetOutstandingTransfer(ReceiptType.CONSTANTS.STORE_TO_STORE_TRANSFER));
            ds.Tables[6].TableName = "OutstandingStoreToStoreTransfer";
            ds.Tables.Add(ReceiveDoc.GetOutstandingReceiveDeliveryNote());
            ds.Tables[7].TableName = "OutstandingReceivedDeliveryNote";
            xreport.DataSource = ds;
            xreport.ShowPreview();

        }

        private void btnStartInventory_Click(object sender, EventArgs e)
        {
            //Show a dialog box to confirm if they are sure to do this.

            if (XtraMessageBox.Show("Are you sure you would like to start inventory on this physical store?", "Confrim",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int physicalStoreID = Convert.ToInt32(gridManageInvetoryView.GetFocusedDataRow()["ID"]);

                if (!BLL.Inventory.CanInventoryBeStarted(physicalStoreID))
                {
                    XtraMessageBox.Show(
                        "Inventory cannot be started in the chosen warehouse because there are outstanding transactions.",
                        "Inventory Cannot Be Started");
                    return;
                }

                //Set The PhsyicalStore to The CurrentInventoryPeriod
                PhysicalStore physicalStore = new PhysicalStore();
                physicalStore.LoadByPrimaryKey(physicalStoreID);
                if (physicalStore.IsActive)
                {
                    XtraMessageBox.Show(
                       "Transaction on this warehouse should be blocked before starting inventory.The selected warehouse is still Active",
                       "Inventory Cannot Be Started");
                    return;
                }
                InitializeProgressBar();

                lblDescription.Text =
                    string.Format(
                        "HCMIS is starting inventory on <b>{1} - {0}</b>. Please do not close this window until this operation is complete.",
                        physicalStore.Name, physicalStore.WarehouseName);

                //TODO: this needs to be optimized. 
                // there is no need that this has to be loaded here.
                // or if it is loaded, dont load it in the background thread. 
                Activity activity = new Activity();
                activity.LoadAll();

                labelTotalActivity.Text =
                    string.Format("HCMIS is searching this physical store for stock under all <b>{0}</b> activities.",
                                  activity.RowCount);
                progressBarActivities.Properties.Maximum = activity.RowCount;

                startbgWorker.RunWorkerAsync();

                // post start inventory transaction
                // todo:
                // lock all items from issue from this phsical store.
            }
        }

        private void InitializeProgressBar()
        {
            layoutControl1.Enabled = false;
            InitiateInventoryProgressPanel.Visible = true;
            InitiateInventoryProgressPanel.Enabled = true;

            progressBarDetail.Visible = true;
            progressBarDetail.Properties.Maximum = 100;
            progressBarDetail.Properties.DisplayFormat.FormatString = "{0: #,##0}" +
                                                                      string.Format(" of {0}",
                                                                                    progressBarDetail.Properties.Maximum);
            progressBarDetail.EditValue = 0;
        }

        private void startbgWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            MyGeneration.dOOdads.TransactionMgr transactionMgr = MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgr();

            try
            {
                // Add the inventory details.
                // For each Activity, populate the inventory.
                //ToDO: this grid reading in a non ui thread is dangerous
                //please don't do it this way. 
                transactionMgr.BeginTransaction();
                int physicalStoreID = Convert.ToInt32(gridManageInvetoryView.GetFocusedDataRow()["ID"]);
                PhysicalStore physicalStore = new PhysicalStore();
                physicalStore.LoadByPrimaryKey(physicalStoreID);


                DateTime startDate = dtStartInventory.Value;
                if (!physicalStore.IsColumnNull("CurrentInventoryPeriodID"))
                {
                // create the inventory period
                InventoryPeriod oldPeriod = new InventoryPeriod();
                oldPeriod.LoadByPrimaryKey(physicalStore.CurrentInventoryPeriodID);
                oldPeriod.EndDate = dtStartInventory.Value;
                oldPeriod.Save();
                }
                InventoryPeriod period = new InventoryPeriod();
                period.AddNew();
                period.InventoryStatusID = InventoryPeriod.Constants.BEGIN_INVENTORY;
                period.PhysicalStoreID = physicalStoreID;
                period.StartDate = dtStartInventory.Value;
                period.EndDate = FiscalYear.Current.EndDate;
                period.StartedBy = CurrentContext.UserId;
                period.FiscalYearID = FiscalYear.Current.ID;
                if (memoEdit1.EditValue != null)
                {
                    period.Remark = memoEdit1.EditValue.ToString();
                }

                period.Save();
                //ChangePhysicalStoreToCurrentPeriod

                physicalStore = new PhysicalStore();
                physicalStore.LoadByPrimaryKey(physicalStoreID);
                physicalStore.CurrentInventoryPeriodID = period.ID;
                physicalStore.CurrentPeriodStartDate = period.StartDate;
                physicalStore.Save();

                Activity activity = new Activity();
                activity.LoadAll();
                int activityIndex = 1;
                while (!activity.EOF)
                {
                    // report that this activity is being processed. 
                    startbgWorker.ReportProgress(activityIndex++, "Activity: " + activity.FullActivityName);

                    DataTable dtbl = Balance.GetBalanceByPhysicalStore(physicalStoreID, activity.ID, false);
                    decimal total = dtbl.Rows.Count;
                    decimal i = 0;
                    foreach (DataRow dr in dtbl.Rows)
                    {

                        Inventory inv = new Inventory();
                        inv.AddNew();

                        inv.IsDraft = true;
                        inv.PhysicalStoreID = physicalStoreID;
                        inv.RecordedBy = CurrentContext.UserId;
                        inv.RecordedDate = BLL.DateTimeHelper.ServerDateTime;

                        inv.InventoryPeriodID = period.ID;
                        inv.ItemID = Convert.ToInt32(dr["ID"]);
                        inv.UnitID = Convert.ToInt32(dr["UnitID"]);
                        inv.ActivityID = activity.ID;
                        inv.ManufacturerID = Convert.ToInt32(dr["ManufacturerID"]);
                        inv.SetColumn("BatchNo", dr["BatchNo"]);
                        inv.SetColumn("ExpiryDate", dr["ExpDate"]);
                        if (!inv.IsColumnNull("ExpiryDate") && inv.ExpiryDate < BLL.DateTimeHelper.ServerDateTime)
                        {
                            inv.SystemExpiredQuantity = Convert.ToDecimal(dr["SoundSOH"]);
                        }
                        else
                        {
                            inv.SystemSoundQuantity = Convert.ToDecimal(dr["SoundSOH"]);
                        }

                        inv.SystemDamagedQuantity = Convert.ToDecimal(dr["DamagedSOH"]);
                        inv.SetColumn("Cost", dr["Cost"]);
                        inv.Margin = dr["Margin"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["Margin"]);
                        inv.SetColumn("PalletLocationID", dr["PalletLocationID"]);
                        inv.Save();


                        startbgWorker.ReportProgress(Convert.ToInt32((i / total) * 100), "Detail");
                        //inventory
                        i++;
                    }


                    activity.MoveNext();
                }
                transactionMgr.CommitTransaction();
                XtraMessageBox.Show("The new Inventory Period has been defined.");
            }
            catch (Exception exception)
            {
                transactionMgr.RollbackTransaction();
                XtraMessageBox.Show(exception.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void startbgWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            if (e.UserState.ToString() == "Detail")
            {
                progressBarDetail.EditValue = e.ProgressPercentage;
            }
            else
            {
                // restart the details
                progressBarActivities.EditValue = e.ProgressPercentage;
                progressBarDetail.EditValue = 0;
                labelActivity.Text = e.UserState.ToString();
            }

        }

        private void startbgWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

            InitiateInventoryProgressPanel.Visible = false;
            layoutControl1.Enabled = true;
            LoadManageInventory();
        }


        #endregion

        #region Inventory count Sheet And Stock Status

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (dxRequiredValidation.Validate())
            {
                storeReport = new StockStatusByPhysicalStore(CurrentContext.LoggedInUserName);
                storeReport.DataSource = BLL.Balance.GetStockStatusByPhysicalStore(Convert.ToInt32(lkPhysicalStore.EditValue), Convert.ToInt32(lkAccountType.EditValue), chkIncludeStockedOut.Checked);
                var activity = new Activity();
                activity.LoadByPrimaryKey(Convert.ToInt32(lkAccountType.EditValue));
                storeReport.AccountName.Text = activity.FullActivityName;
                BLL.PhysicalStore pstore = new BLL.PhysicalStore();
                pstore.LoadByPrimaryKey(Convert.ToInt32(lkPhysicalStore.EditValue));
                storeReport.WarehouseName.Text = pstore.Name;
                pcPrintout.PrintingSystem = storeReport.PrintingSystem;
                storeReport.CreateDocument();
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (chkShowLocations.Checked)
            {
                storeReportWithLocation.PrintDialog();
            }
            else
            {
                storeReport.PrintDialog();
            }
        }

        private void btnPrintCountSheet_Click(object sender, EventArgs e)
        {
            if (dxRequiredValidation.Validate())
            {
                DataTable tbl;
                var activity = new Activity();
                activity.LoadByPrimaryKey(Convert.ToInt32(lkAccountType.EditValue));
            
                if (chkIncludeBatchExpiry.Checked)
                {
                    tbl =
                        BLL.Balance.GetCountSheetByPhysicalStoreWithBatchExpiry(
                            Convert.ToInt32(lkPhysicalStore.EditValue), Convert.ToInt32(lkAccountType.EditValue),
                            chkIncludeStockedOut.Checked, chkShowLocations.Checked);

                }
                else
                {
                    tbl = BLL.Balance.GetCountSheetByPhysicalStore(Convert.ToInt32(lkPhysicalStore.EditValue),
                                                                   Convert.ToInt32(lkAccountType.EditValue),
                                                                   chkIncludeStockedOut.Checked);
                }

                if (chkShowLocations.Checked)
                {
                    storeReportWithLocation.DataSource = tbl;
                    storeReportWithLocation.AccountName.Text = activity.FullActivityName;
                    BLL.PhysicalStore pstore = new BLL.PhysicalStore();
                    pstore.LoadByPrimaryKey(Convert.ToInt32(lkPhysicalStore.EditValue));
                    storeReport.WarehouseName.Text = pstore.Name;
                    pcPrintout.PrintingSystem = storeReportWithLocation.PrintingSystem;
                    storeReportWithLocation.CreateDocument();
                }
                else
                {
                    storeReport.DataSource = tbl;
                    storeReport.AccountName.Text = activity.FullActivityName;
                    BLL.PhysicalStore pstore = new BLL.PhysicalStore();
                    pstore.LoadByPrimaryKey(Convert.ToInt32(lkPhysicalStore.EditValue));
                    storeReport.WarehouseName.Text = pstore.Name;
                    pcPrintout.PrintingSystem = storeReport.PrintingSystem;
                    storeReport.CreateDocument();
                }

            }
        }

        #endregion

        #region Save Draft and commit Inventory

        private void btnSaveLocationRelatedInformation_Click(object sender, EventArgs e)
        {

            MyGeneration.dOOdads.TransactionMgr transaction = MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgr();

            try
            {
                if (gridLocationRelatedInventory.DataSource != null && (gridLocationRelatedInventory.DataSource as DataTable).GetChanges() != null)
                {

                    transaction.BeginTransaction();
                    foreach (DataRow dataRow in (gridLocationRelatedInventory.DataSource as DataTable).GetChanges().Rows)
                    {
                        InventoryService.SaveInventoryRow(dataRow);
                    }


                    transaction.CommitTransaction();
                    XtraMessageBox.Show("Draft successfully saved!", "Success",
                                        System.Windows.Forms.MessageBoxButtons.OK,
                                        System.Windows.Forms.MessageBoxIcon.Information);
                    btnLoadInventory_Click(null, null);
                }
                else
                {
                    throw new Exception("No Record Was Change");
                }
            }
            catch (Exception ex)
            {
                transaction.RollbackTransaction();
                XtraMessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

        }

        private void btnInventoryAdd_Click(object sender, EventArgs e)
        {
            if (lkPeriod.EditValue != null && lkInventoryAccount.EditValue != null && lkInventoryStore.EditValue != null)
            {
                NewInventoryEntry inventoryEntry = new NewInventoryEntry(Convert.ToInt32(lkPeriod.EditValue), Convert.ToInt32(lkInventoryStore.EditValue), Convert.ToInt32(lkInventoryAccount.EditValue));
                inventoryEntry.ShowDialog(this);
                btnLoadInventory_Click(null, null);
            }
        }

        private void btnFinalPrintout_Click(object sender, EventArgs e)
        {

            int periodId = Convert.ToInt32(lkPeriod.EditValue);
            int activityID = Convert.ToInt32(lkInventoryAccount.EditValue);
            int physicalStoreID = Convert.ToInt32(lkInventoryStore.EditValue);
            PhysicalStore physicalStore = new PhysicalStore();
            physicalStore.LoadByPrimaryKey(physicalStoreID);
            try
            {
                if (InventoryPeriod.HasUnCommited(periodId, activityID))
                {
                    throw new Exception("This inventory has not been commited yet,you are not allow to print before");
                }
                
                DevExpress.XtraReports.UI.XtraReport xreport;
                DateTimePickerEx dtDate = new DateTimePickerEx();
                dtDate.Value = DateTimeHelper.ServerDateTime;
                if (Settings.LocalvsTender)
                {
                    xreport = new HCMIS.Desktop.Reports.InventoryCountSheetLocalTender(CurrentContext.LoggedInUserName);
                    (xreport as HCMIS.Desktop.Reports.InventoryCountSheetLocalTender).Date.Text = dtDate.Text;
                }
                else
                {
                    xreport = new HCMIS.Desktop.Reports.InventoryCountSheet(CurrentContext.LoggedInUserName);
                    (xreport as HCMIS.Desktop.Reports.InventoryCountSheet).Date.Text = dtDate.Text;
                }
                xreport.DataSource = BLL.Receipt.GetInventoryCountbyInventoryPeriodID(periodId, physicalStoreID, activityID);
                xreport.ShowPreview();
            }
            catch (Exception exp)
            {
                XtraMessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnDraftPrintout_Click(object sender, EventArgs e)
        {
            inventory.LoadByStoreAndActivity(Convert.ToInt32(lkInventoryAccount.EditValue),
                                                 Convert.ToInt32(lkInventoryStore.EditValue),
                                                 Convert.ToInt32(lkPeriod.EditValue));
            DraftInventoryPrintout draftPrintout = new DraftInventoryPrintout(CurrentContext.LoggedInUserName);
            draftPrintout.DataSource = inventory.DefaultView;
            draftPrintout.AccountName.Text = lkInventoryAccount.Text;
            draftPrintout.WarehouseName.Text = lkInventoryStore.Text;
            draftPrintout.ShowPreviewDialog();
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            if (!ValidateBeforeCommit(false)) return;
            if (gridLocationRelatedInventory.DataSource != null)
            {
                if ((gridLocationRelatedInventory.DataSource as DataTable).GetChanges() != null)
                {
                    XtraMessageBox.Show("Some Change have not been save,please save before commiting",
                        "Pending Changes...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (XtraMessageBox.Show("Are you sure you want to commit this change? You will not be able to undo this.",
                        "Confirmation...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                int physicalStoreID = Convert.ToInt32(lkInventoryStore.EditValue);
                int periodId = Convert.ToInt32(lkPeriod.EditValue);
                int activityID = Convert.ToInt32(lkInventoryAccount.EditValue);

                Inventory inventory = new Inventory();
                inventory.LoadByStoreAndActivity(activityID, physicalStoreID, periodId);
                InitializeProgressBar();
                
                lblDescription.Text =
                   string.Format(
                       "HCMIS is commiting inventory on <b>{0}-{1}</b>. Please do not close this window until this operation is complete.",
                       lkInventoryStore.Text, lkInventoryAccount.Text);

                labelTotalActivity.Text =
                       string.Format("HCMIS is processing Inventory for  <b>{0}</b> Entries.", inventory.RowCount);

                progressBarActivities.Properties.Maximum = inventory.RowCount;
                InventoryBgWorker.RunWorkerAsync();
            }
            else
            {
                XtraMessageBox.Show(
                        "No Record is available to commit,please Select a Warehouse and Activity to Continue",
                        "No Record...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void gridLocationRelatedInventoryView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRow dataRow = gridLocationRelatedInventoryView.GetFocusedDataRow();
            
            if (dataRow.IsNull("IsDraft") || Convert.ToBoolean(dataRow["IsDraft"]) || this.HasPermission("Edit-Commited"))
            {
                if (dataRow["ExpiryDate"] == DBNull.Value || dataRow.IsNull("ExpiryDate"))
                {
                    dataRow.ClearErrors();
                    return;
                }
                else if (Convert.ToDateTime(dataRow["ExpiryDate"]) <= DateTimeHelper.ServerDateTime &&
                         dataRow["InventorySoundQuantity"] != DBNull.Value &&
                         Convert.ToDecimal(dataRow["InventorySoundQuantity"]) > 0)
                {
                    dataRow.SetColumnError("InventorySoundQuantity", "This Item has Expired, you cannot set a value");
                    dataRow["InventorySoundQuantity"] = DBNull.Value;
                }
                else if (Convert.ToDateTime(dataRow["ExpiryDate"]) > DateTimeHelper.ServerDateTime &&
                         dataRow["InventoryExpiredQuantity"] != DBNull.Value &&
                         Convert.ToDecimal(dataRow["InventoryExpiredQuantity"]) > 0)
                {
                    dataRow.SetColumnError("InventoryExpiredQuantity",
                                           "This Item did not Expire, you cannot set a value");
                    dataRow["InventoryExpiredQuantity"] = DBNull.Value;
                }
                else
                {
                    dataRow.ClearErrors();
                }
            }
            else
            {
                dataRow.CancelEdit();
                dataRow.RejectChanges();
            }
        }

        private void InventorybBgWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //GetEthiopianDate() Why is it so difficult and Complicated we just need a fluent Api for EthiopianDate DateTime.ToEthiopianDate(),DateTime.ToShortEthiopianDate(),
            DateTime dtCurrent;
            using (var dtDate = ConvertDate.GetCurrentEthiopianDateText())
            {
                dtCurrent = ConvertDate.DateConverter(dtDate.Text);
            }
            // Do validation


            int userId = CurrentContext.UserId;
            int physicalStoreID = Convert.ToInt32(lkInventoryStore.EditValue);
            int periodId = Convert.ToInt32(lkPeriod.EditValue);
            int activityID = Convert.ToInt32(lkInventoryAccount.EditValue);

            TransferService transferService = new TransferService();
            try
            {
                InventoryService.CommitInventory(periodId, activityID, physicalStoreID, dtCurrent, userId, InventoryBgWorker);
                XtraMessageBox.Show("Your changes have been applied.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exp)
            {
                XtraMessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                InventoryBgWorker.CancelAsync();

            }
        }

        private void InventorybBgWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            if (e.UserState.ToString() == "Detail")
            {
                progressBarDetail.EditValue = e.ProgressPercentage;
            }
            else
            {
                // restart the details
                progressBarActivities.EditValue = e.ProgressPercentage;
                progressBarDetail.EditValue = 0;
                labelActivity.Text = e.UserState.ToString();
            }
        }

        private void InventorybBgWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {


            InitiateInventoryProgressPanel.Visible = false;
            layoutControl1.Enabled = true;
        }

        private void ckInventoryStockedOut_CheckedChanged(object sender, EventArgs e)
        {
            btnLoadInventory_Click(null, null);
        }

        private void btnLoadInventory_Click(object sender, EventArgs e)
        {
            if (lkInventoryAccount.EditValue != null && lkInventoryStore.EditValue != null && lkInventoryStore.EditValue != "")
            {
                inventory.LoadByStoreAndActivity(Convert.ToInt32(lkInventoryAccount.EditValue),
                                                 Convert.ToInt32(lkInventoryStore.EditValue),
                                                 Convert.ToInt32(lkPeriod.EditValue), ckInventoryStockedOut.Checked);
                repoLkPalletLocation.DataSource = PalletLocation.GetAllByPhisicalStore(Convert.ToInt32(lkInventoryStore.EditValue),true);
                repoDamagedPalletLocation.DataSource = PalletLocation.GetAllByPhisicalStore(Convert.ToInt32(lkInventoryStore.EditValue), false);

                gridLocationRelatedInventory.DataSource = inventory.DefaultView.Table;
            }
        }

        private void lkInventoryAccount_EditValueChanged(object sender, EventArgs e)
        {
            if (lkInventoryStore.EditValue != null && lkInventoryStore.EditValue != "" && lkInventoryAccount.EditValue != null)
            {
                lkPeriod.Properties.DataSource = InventoryPeriod.GetInvetoryPeriods(Convert.ToInt32(lkInventoryStore.EditValue),3);
            }
            else
            {
                lkPeriod.Properties.DataSource = null;
            }

            btnLoadInventory_Click(null,null);
        }

        #endregion

        private void chkIncludeBatchExpiry_CheckedChanged(object sender, EventArgs e)
        {
            chkShowLocations.Enabled = chkIncludeBatchExpiry.Checked;
        }

        private void btnRowSave_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow dataRow = gridLocationRelatedInventoryView.GetFocusedDataRow();
            MyGeneration.dOOdads.TransactionMgr transaction = MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgr();

            try
            {
                transaction.BeginTransaction();
                if (this.HasPermission("Edit-Commited"))
                {
                    if (dataRow.RowState == DataRowState.Unchanged &&
                        XtraMessageBox.Show("No Record Was Changeed! , Du you still want to proceed? ", "Confirmation",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
                    {
                        return;
                    }

                    InventoryService.SaveInventoryRow(dataRow);

                    transaction.CommitTransaction();
                    XtraMessageBox.Show("Draft successfully saved!", "Success",
                                        System.Windows.Forms.MessageBoxButtons.OK,
                                        System.Windows.Forms.MessageBoxIcon.Information);
                    btnLoadInventory_Click(null, null);
                }
                else
                {
                    throw new Exception("You have no permission, please contact Administrator!");
                }

            }
            catch (Exception exception)
            {
                transaction.RollbackTransaction();
                XtraMessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void btnRowCommit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (!ValidateBeforeCommit(true)) return;
            DataRow dr = gridLocationRelatedInventoryView.GetFocusedDataRow();

            DateTime dtCurrent;
            using (var dtDate = ConvertDate.GetCurrentEthiopianDateText())
            {
                dtCurrent = ConvertDate.DateConverter(dtDate.Text);
            }
            if (dr.RowState == DataRowState.Modified)
            {
                XtraMessageBox.Show("Your Change have not been saved,please save before commiting",
                          "Pending Changes...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                if (XtraMessageBox.Show("You are about To commit change For item: " + dr["FullItemName"].ToString(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    InventoryService.CommitSingle(Convert.ToInt32(dr["ID"]), dtCurrent, CurrentContext.UserId);
                    XtraMessageBox.Show("Your changes have been applied.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception exp)
            {
                XtraMessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            btnLoadInventory_Click(null, null);
        }

        private void gridLocationRelatedInventoryView_ShownEditor(object sender, EventArgs e)
        {
            var view = (GridView)sender;
            var activeEditorName = view.ActiveEditor.GetType().Name;

            if (activeEditorName.Equals("GridLookUpEdit"))
            {
                var lke = (GridLookUpEdit)view.ActiveEditor;
                if (view.FocusedColumn.FieldName == "DamagedPalletLocationID")
                {
                    DataRow dr = view.GetFocusedDataRow();

                    if ((dr["InventoryDamagedQuantity"] == DBNull.Value || !(Convert.ToDecimal(dr["InventoryDamagedQuantity"]) > 0)))
                    {
                       lke.Hide();
                        XtraMessageBox.Show(
                            Icons.
                                YearEndProcess_gridLocationRelatedInventoryView_ShownEditor_You_Can_t_Select_PalletLocation__There_is_no_Damaged_Quantity_for_this_Item,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (activeEditorName.Equals("GridLookUpEdit"))
            {
                var lke = (GridLookUpEdit)view.ActiveEditor;
                if (view.FocusedColumn.FieldName == "PalletLocationID")
                {
                    DataRow dr = view.GetFocusedDataRow();
                    if (((dr["InventorySoundQuantity"] == DBNull.Value ||!(Convert.ToDecimal(dr["InventorySoundQuantity"]) > 0))) 
                                                                       ||
                      ((dr["InventoryExpiredQuantity"] == DBNull.Value ||!(Convert.ToDecimal(dr["InventoryExpiredQuantity"]) > 0))))
                    {
                        if (dr["InventoryDamagedQuantity"] != DBNull.Value && Convert.ToDecimal(dr["InventoryDamagedQuantity"]) > 0 &&
                            (dr["InventorySoundQuantity"] == DBNull.Value || !(Convert.ToDecimal(dr["InventorySoundQuantity"]) > 0)) &&
                            (dr["InventoryExpiredQuantity"] == DBNull.Value || !(Convert.ToDecimal(dr["InventoryExpiredQuantity"]) > 0)))
                        {
                            XtraMessageBox.Show(
                                "This Item has Damaged, please use Damaged pallet location",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            lke.Hide();
                        }
                    }
                }
            }
        }

        private bool ValidateBeforeCommit(bool singleCommit)
        {
            var isValid = true;
            DataRow dr = gridLocationRelatedInventoryView.GetFocusedDataRow();
            dr.ClearErrors();

            if (singleCommit)
            {
                isValid = ISSingleRowValid(dr);
            }
            else
            {
                foreach (DataRow datarow in ((DataTable) gridLocationRelatedInventory.DataSource).Rows)
                {
                    if (isValid) isValid = ISSingleRowValid(datarow);
                }
            }

            return isValid;
        }

        private static bool ISSingleRowValid(DataRow dr)
        {
            dr.ClearErrors();
            bool isValid = true;
            if (dr["InventoryDamagedQuantity"] != DBNull.Value && ((Convert.ToDecimal(dr["InventoryDamagedQuantity"]) > 0) && (dr["DamagedPalletLocationID"] == DBNull.Value)))
            {
                dr.SetColumnError("DamagedPalletLocationID",
                                  Icons.YearEndProcess_ValidateBeforeCommit_DamagedPalletLocation_Can_not_be_left_empty_);
                isValid = false;
            }

            if (dr["InventorySoundQuantity"] != DBNull.Value && ((Convert.ToDecimal(dr["InventorySoundQuantity"]) > 0) && (dr["PalletLocationID"] == DBNull.Value)))
            {
                dr.SetColumnError("PalletLocationID",
                                  Icons.YearEndProcess_ValidateBeforeCommit_Normal_PalletLocation_Can_not_be_left_empty_);
                isValid = false;
            }

            return isValid;
        }

        private void gridLocationRelatedInventory_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridLocationRelatedInventoryView.GetFocusedDataRow();
            if (dr == null)
            {
                XtraMessageBox.Show("You can't update old inventory data ,you can only update new inventory!",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
           
          if (dr != null &&dr["Remarks"].ToString() == "New Entry")
            {
                var edit = new NewInventoryEntry(dr) {Text = "Update Inventory Entry"};
                edit.ShowDialog();

            }
            else 
            {
                XtraMessageBox.Show("You can't update old inventory data ,you can only update new inventory!",
                                    "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }
    }

}