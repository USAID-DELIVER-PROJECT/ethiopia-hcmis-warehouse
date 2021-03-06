﻿using System;
using System.ComponentModel;
using System.Data;
using BLL;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using HCMIS.Desktop.Forms.Reports;
using HCMIS.Desktop.Helpers;
using HCMIS.Desktop.ViewHelpers;
using HCMIS.Helpers;
using HCMIS.Desktop.Modals;
using HCMIS.Desktop.Forms.Modals.Finance;
using DevExpress.XtraLayout;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;
using HCMIS.Reports;
using HCMIS.Reports.Reports;

namespace HCMIS.Desktop.Forms.WorkFlow
{
    [FormIdentifier("CM-CM-CB-PO", "Cost / Margin", "")]
    public partial class CostingFormCenter : XtraForm
    {
        
        private CenterCostCalculator GRV;
        LayoutControlGroup selectTab;
        int ReceiptID;
        string PONumber;
        #region Initialization and Mode Settings

       
        public CostingFormCenter()
        {
            InitializeComponent();
        }

        private void PutAwayListsLoad(object sender, EventArgs e)
        {
            SetPermission();
            lkAccount.SetupActivityEditor().SetDefaultActivity();
            LoadGRVPendingCostingByUser();
            ResetForm();
            if (!BLL.Settings.IsCenter)
            {
                XtraMessageBox.Show("This Costing Page is Only Applicable For Center Costing", "User Management Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Enabled = false;
                return;
            }
        }
        private void SetPermission()
        {
            if (BLL.Settings.UseNewUserManagement)
            {
                btnSave.Enabled = this.HasPermission("Save");
                btnReturn.Enabled = this.HasPermission("Return");
                btnPO.Enabled = this.HasPermission("Edit-Order-Information");
                btnInvoice.Enabled = this.HasPermission("Edit-Invoice");
            }
        }

        private void LoadGRVPendingCostingByUser()
        {
            gridGRVs.DataSource = BLL.Receipt.GetListOfGRVByUserIDForCosting(CurrentContext.UserId);
        }
        
        #endregion
        
        #region On Selection of GRV
        
        private void gridGRVs_MouseClick(object sender, MouseEventArgs e)
        {

            DataRow SelectGRV = gridGRVsView.GetFocusedDataRow();
            if (SelectGRV != null)
            {
                ReceiptID = Convert.ToInt32(SelectGRV["ReceiptID"]);
                PONumber = Convert.ToString(SelectGRV["PONumber"]);
                LoadSelectedGRVDetailForInvoiceEntry(ReceiptID);
                NoSelection.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                Selection.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
             
                     txtOrderNo.EditValue = SelectGRV["PONumber"];
                   
                    txtInvoiceNo.EditValue = SelectGRV["InvoiceNumber"];
                   string space = "";
               
                
                 int length = ((string) SelectGRV["InvoiceNumber"]).Length;
                 lcgInvoiceNo.Text = "Invoice No: " + (string)SelectGRV["InvoiceNumber"] + space.PadRight(180 - length) + "GRNF No: " + (string)SelectGRV["RefNo"].ToString();



                 lblMode.Text = (string)SelectGRV["Mode"] ?? "-";
                 lblAccount.Text = (string)SelectGRV["AccountName"] ?? "-";
                 lblSubAccount.Text = (string)SelectGRV["SubAccountName"] ?? "-";
                 lblActivity.Text = (string)SelectGRV["ActivityName"] ?? "-";
                 lblWarehouse.Text = (string)SelectGRV["WarehouseName"] ?? "-";
                 lblCluster.Text = (string)SelectGRV["ClusterName"] ?? "-";
                 lblReceiptType.Text = (string)SelectGRV["ReceiveType"] ?? "-";
                 lblReceiptStatus.Text = (string)SelectGRV["ReceiveStatus"] ?? "-";
                 lblSupplier.Text = (string)SelectGRV["SupplierName"] ?? "-";
                 lblOrderNo.Text = (string)SelectGRV["PONumber"] ?? "-";
                
                lblConfirmedBy.Text = SelectGRV["ConfirmedBy"] == DBNull.Value ? "-" : (string)SelectGRV["ConfirmedBy"];


                //DateTime confirmedTime;
                //if (DateTime.TryParse(SelectGRV["ConfirmedTime"] == null ? "" : (string)SelectGRV["ConfirmedTime"], out confirmedTime))
                //    lblConfimredDate.Text = confirmedTime.ToShortDateString();
               lblConfimredDate.Text = SelectGRV["ConfirmedTime"] != DBNull.Value  ? Convert.ToDateTime(SelectGRV["ConfirmedTime"]).ToShortDateString() : "-";

                lblReceivedBy.Text = (string)SelectGRV["ReceivedBy"] ?? "-";
                lblReceiptDate.Text = ((DateTime)SelectGRV["ReceivedTime"]).ToShortDateString() ?? "-";
                lblInsurance.Text = SelectGRV["InsuranceNumber"] == DBNull.Value ? "-" : (string)SelectGRV["InsuranceNumber"];


                    txtInsuranceNo.EditValue = SelectGRV["InsuranceNumber"]?? "-";
                    lblInsurancePolicyNo.Text = SelectGRV["InsuranceNumber"].ToString() ?? "-";
                    txtTransfer.EditValue = SelectGRV["TransitNumber"];
                    lblTransferNo.Text = SelectGRV["TransitNumber"].ToString() ?? "-";
                    txtWayBill.EditValue = SelectGRV["WayBillNumber"];
                    lblWayBillNo.Text = SelectGRV["WayBillNumber"].ToString() ?? "-";

                     

                     //Activity Activity = new Activity();
                     //Activity.LoadByPrimaryKey(Convert.ToInt32(SelectGRV["StoreID"]));
                     //txtActivity.EditValue = Activity.FullActivityName;
                     //lblActivity.Text = Activity.FullActivityName;
                    
            
            
            }
            else
            {
                ResetForm();
            }
        }

        #endregion

        #region Step 1 Invoice
     
        private void LoadSelectedGRVDetailForInvoiceEntry(int ReceiptID)
        {
            //Display Correct Tab
            selectTab = grpTabInvoiceValue;
            FocusOnSelectedTab();
           
            // Load The GRV First
            GRV = new CenterCostCalculator();
            GRV.LoadGRV(ReceiptID);
            // Display the GRV Detail for Data Entry(Price Per Pack)

            //Please Make-up ur mind solution
            if(BLL.Settings.IsDamageIncludedOnTotalFOB)
                 gridInvoiceDetail.DataSource = GRV.GRVDetail;
            else
                  gridInvoiceDetail.DataSource = GRV.GRVSoundDetail;
            gridDiscrenpancy.DataSource = GRV.GRVDiscrepancyDetail;

            BLL.Receipt receipt = new BLL.Receipt();
            receipt.LoadByPrimaryKey(ReceiptID);

        }

        private void gridInvoiceDetailView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e != null && e.Column.FieldName == "InvoiceCost")
            {
                DataRow drv = gridInvoiceDetailView.GetFocusedDataRow();
                // receipt.SaveFOBForEachReceiveDoc();


                if (drv["InvoiceCost"] != DBNull.Value)
                {

                    using (PricePerPackPage pricePerPackPage = new PricePerPackPage(ReceiptID, Convert.ToInt32(drv["ItemID"]), Convert.ToInt32(drv["ItemUnitID"]), Convert.ToInt32(drv["ManufacturerID"]), Convert.ToInt32(drv["ActivityID"]), Convert.ToDouble(drv["InvoiceCost"])))
                    {
                        pricePerPackPage.ShowDialog(this);
                    }
                    LoadSelectedGRVDetailForInvoiceEntry(ReceiptID);
                }

            }
            else if (e != null && e.Column.FieldName == "Margin")
            {
                DataRow drv = gridInvoiceDetailView.GetFocusedDataRow();
                // receipt.SaveFOBForEachReceiveDoc();


                if (drv["Margin"] != DBNull.Value)
                {

                    using (MarginPage marginPage = new MarginPage(ReceiptID, Convert.ToInt32(drv["ItemID"]), Convert.ToInt32(drv["ItemUnitID"]), Convert.ToInt32(drv["ManufacturerID"]), Convert.ToInt32(drv["ActivityID"]), Convert.ToDouble(drv["Margin"])))
                    {
                        marginPage.ShowDialog(this);
                    }
                    LoadSelectedGRVDetailForInvoiceEntry(ReceiptID);
                }
         
               
            }
        }

       

        #endregion

        #region Step 2 Cost Build up

        private void LoadSelectedGRVDetailForCostBuildUp(int ReceiptID)
        {
             // GRV.SaveTotalCost(NewMainWindow.UserId);
                // reload The GRV
              DataRow SelectGRV = gridGRVsView.GetFocusedDataRow();

          
           // GRV = new CenterCostCalculator();
          //  GRV.LoadGRV(ReceiptID);
              if (SelectGRV != null)
                GRV.LoadCostBuilUp(chkUseProration.Checked, SelectGRV["RefNo"].ToString());

              //if (chkUseProration.Checked)
              //    ColGRVValue.OptionsColumn.AllowEdit = false;
              //else
              //    ColGRVValue.OptionsColumn.AllowEdit = true;
         
            //Display Correct Tab
            selectTab = grpTabCostBuildUp;
            FocusOnSelectedTab();
            gridCostBuildUp.DataSource = GRV.CostBuildUp.DataTable;
           
        }

        private void gridCostBuildUpView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "GRVValue")
            {
                DataRow editedDr = gridCostBuildUpView.GetFocusedDataRow();
                GRV.CostBuildUp.SetEditedValue(editedDr["Variable"].ToString(), Convert.ToDouble(editedDr["GRVValue"]));
                gridCostBuildUp.DataSource = GRV.CostBuildUp.DataTable;
            }
        }

        private void btnPO_Click(object sender, EventArgs e)
        {
            BLL.Receipt GRV = new BLL.Receipt();
            GRV.LoadByPrimaryKey(ReceiptID);
            ReceiptInvoice invoice = new ReceiptInvoice();
            invoice.LoadByPrimaryKey(GRV.ReceiptInvoiceID);
            PODialog InvoiceDialog = new PODialog(invoice.POID);
            InvoiceDialog.ShowDialog();
            LoadSelectedGRVDetailForCostBuildUp(ReceiptID);
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            BLL.Receipt GRV = new BLL.Receipt();
            GRV.LoadByPrimaryKey(ReceiptID);
            ReceiptInvoice invoice = new ReceiptInvoice();
            invoice.LoadByPrimaryKey(GRV.ReceiptInvoiceID);
            ReceiptInvoiceDialog InvoiceDialog = new ReceiptInvoiceDialog(invoice.POID,invoice.ID);
            InvoiceDialog.ShowDialog();
            LoadSelectedGRVDetailForCostBuildUp(ReceiptID);
        }

        private void chkUseProration_CheckedChanged(object sender, EventArgs e)
        {
            LoadSelectedGRVDetailForCostBuildUp(ReceiptID);
            
        }
        #endregion

        #region Step 3 Unit Cost
        
        private void LoadSelectedGRVDetailForUnitCostCalculation(int ReceiptID)
        {
            DataRow dr = GRV.IsItemBeingPricedElsewhere();
            if (dr != null)
            {
                    MessageBox.Show(string.Format(
@"The Item {0} - with Unit: {1} - and Manufacturer: {2} is {3}.
Please finalize the receive process For {4} under the Activity {5} before continuing"
                                        , dr["FullItemName"], dr["ItemUnitName"], dr["ManufacturerName"], dr["Description"], dr["GRVNo"], dr["ActivityFullName"]
                                        )
                                   , string.Format(@"Pending Receipt()...{0}", dr["ReceiptID"].ToString()), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // if The Flow is correct Calculate the Cost Coeff and all information on the Previous Tab
            if(selectTab == grpTabCostBuildUp)
                GRV.SaveCostCoefficient(CurrentContext.UserId);

            //Display Correct Tab
            selectTab = grpTabUnitCost;
            FocusOnSelectedTab();
             // Load the GRV First
            GRV = new CenterCostCalculator();
            GRV.LoadGRV(ReceiptID);
            DataRow SelectGRV = gridGRVsView.GetFocusedDataRow();
            if (SelectGRV != null)
            {
                GRV.LoadCostBuilUp(false, SelectGRV["RefNo"].ToString());
                GRV.SuspendFromIssuing();
                gridJournal.DataSource = GRV.CostAnalysis(SelectGRV["RefNo"].ToString());
            }
            gridUnitCost.DataSource = GRV.GRVSoundDetail;

        }

        #endregion

        #region Step 4 Moving Average Cost

        private void LoadSelectedGRVDetailForMovingAverage(int ReceiptID)
        {
            
           //Display Correct Tab
            selectTab = grpTabMovingAverage;
            FocusOnSelectedTab();

            gridMovingAverage.DataSource = GRV.GRVSoundDetail;
            gridPreviousBalance.DataSource = GRV.PreviousStock;
        }
        #endregion

        #region Step 5 Final Result

        private void LoadSelectedGRVDetailForFinalization(int ReceiptID)
        {
            //Display Correct Tab
            if (!GRV.CalculateFinalCost())
            {
                XtraMessageBox.Show("Some Items On the GRV are waiting to be Average,you cannot continue without average them", "Averaging Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } 
            selectTab = grpTabFinalize;
            FocusOnSelectedTab();
          
            gridFinal.DataSource = GRV.GRVSoundDetail;
        }

        #endregion

        #region Navigation

        private void FocusOnSelectedTab()
        {
            if (tabContralGRVDetail.SelectedTabPage != selectTab)
                tabContralGRVDetail.SelectedTabPage = selectTab;
            if (selectTab == grpTabFinalize)
            {
                btnNext.Enabled = false;
                btnBack.Enabled = true;
            }
            else if (selectTab == grpTabInvoiceValue)
            {
                btnBack.Enabled = false;
                btnNext.Enabled = true;
            }
            else
            {
                btnBack.Enabled = true;
                btnNext.Enabled = true;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            NextTab();
            FocusOnSelectedTab();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            PreviousTab();
            FocusOnSelectedTab();
        }

        private void NextTab()
        {
            if (selectTab == grpTabInvoiceValue)
                LoadSelectedGRVDetailForCostBuildUp(ReceiptID);
            else if(selectTab == grpTabCostBuildUp)
                LoadSelectedGRVDetailForUnitCostCalculation(ReceiptID);
            else if (selectTab == grpTabUnitCost)
                LoadSelectedGRVDetailForMovingAverage(ReceiptID);
            else
                LoadSelectedGRVDetailForFinalization(ReceiptID);
        }

        private void PreviousTab()
        {
            if(selectTab == grpTabCostBuildUp)
                LoadSelectedGRVDetailForInvoiceEntry(ReceiptID);
            else if (selectTab == grpTabUnitCost)
               LoadSelectedGRVDetailForCostBuildUp(ReceiptID);
            else if (selectTab == grpTabMovingAverage)
                LoadSelectedGRVDetailForUnitCostCalculation(ReceiptID);
            else
                LoadSelectedGRVDetailForMovingAverage(ReceiptID);
        }

        private void tabContralGRVDetail_SelectedPageChanged(object sender, LayoutTabPageChangedEventArgs e)
        {
            FocusOnSelectedTab();
        }

        #endregion

        #region Finalize and Reset

        private void ResetForm()
        {
            NoSelection.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            Selection.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }
        
        public Boolean SetFinalCost()
        {
            foreach (DataRowView drv in gridFinalView.DataSource as DataView)
            {

                double NewUnitCost, NewSellingPrice;
                NewUnitCost = Math.Round(Convert.ToDouble(drv["AverageCost"]), BLL.Settings.NoOfDigitsAfterTheDecimalPoint);
                NewSellingPrice = Math.Round(Convert.ToDouble(drv["SellingPrice"]), BLL.Settings.NoOfDigitsAfterTheDecimalPoint);
                SellingPricePage sellingPriceForm = new SellingPricePage(ReceiptID, Convert.ToInt32(drv["ItemID"]), Convert.ToInt32(drv["ManufacturerID"]), Convert.ToInt32(drv["ItemUnitID"]), Convert.ToInt32(drv["MovingAverageID"]), NewUnitCost, NewSellingPrice);
                if (sellingPriceForm.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
                {
                    return false;
                }
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            GRV.RecordAverageCostAndSellingPrice(CurrentContext.UserId);
                print();
            BLL.ReceiveDoc recDoc = new ReceiveDoc();

            recDoc.LoadByReceiptID(ReceiptID);

            BLL.Receipt receiptStatus = new BLL.Receipt();
            if (!BLL.Settings.UseReceiveCostConfirmation && PONumber.StartsWith("S2S-"))
            {
                if (SetFinalCost())
                {
                    recDoc.ConfirmGRVPrinted(CurrentContext.UserId);

                    receiptStatus.LoadByPrimaryKey(ReceiptID);
                    receiptStatus.ChangeStatus(ReceiptConfirmationStatus.Constants.GRV_PRINTED, null, this.GetFormIdentifier(), CurrentContext.UserId, "StoreToStore Confirmed");
                }

            }
            else if (BLL.Settings.UseReceiveCostConfirmation)
            {
                recDoc.SetPrice(CurrentContext.UserId);
                receiptStatus.LoadByPrimaryKey(ReceiptID);
                receiptStatus.ChangeStatus(ReceiptConfirmationStatus.Constants.PRICE_CALCULATED, null,
                                           this.GetFormIdentifier(), CurrentContext.UserId, "Price Set");
            }
            else
            {
                recDoc.ConfirmPrice(CurrentContext.UserId);

                receiptStatus.LoadByPrimaryKey(ReceiptID);
                receiptStatus.ChangeStatus(ReceiptConfirmationStatus.Constants.PRICE_CONFIRMED, null, this.GetFormIdentifier(), CurrentContext.UserId, "Price Set");
            }
            XtraMessageBox.Show("Received Cost and Margin Set successfully!", "Success", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            PutAwayListsLoad(null, null);
            this.LogActivity("Print-Cost-Analysis", ReceiptID);

        }
     
        private void print()
        {
            BLL.Receipt receipt = new BLL.Receipt(ReceiptID);
            DataRow dr = gridGRVsView.GetFocusedDataRow();
            String GRNString = dr["RefNo"].ToString();

            HCMIS.Desktop.Reports.CostAnalysisSubReport xReportCostAnalysis = new HCMIS.Desktop.Reports.CostAnalysisSubReport();
            xReportCostAnalysis.DataSource = GRV.CostAnalysis(GRNString);

            HCMIS.Desktop.Reports.CostBuildUp xReportCostBuildUp = new HCMIS.Desktop.Reports.CostBuildUp();
            xReportCostBuildUp.DataSource = GRV.CostBuildUp.DataTable.DefaultView;
            xReportCostBuildUp.xrDate.Text = EthiopianDate.EthiopianDate.GregorianToEthiopian(BLL.DateTimeHelper.ServerDateTime);
            xReportCostBuildUp.xrSubreport1.ReportSource = xReportCostAnalysis;
            xReportCostBuildUp.xrCostedBy.Text = CurrentContext.LoggedInUserName;
            xReportCostBuildUp.ShowPreviewDialog();
            MemoryStream stream = new MemoryStream();
            xReportCostBuildUp.ExportToPdf(stream);
            HCMIS.Core.Distribution.Services.PrintLogService.SavePrintLogNoWait(stream, "CostAnalysis", true, ReceiptID, CurrentContext.UserId, BLL.DateTimeHelper.ServerDateTime);
                     
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            //TODO: finish updating the changed locations
            MyGeneration.dOOdads.TransactionMgr transaction = MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgr();
            if (gridGRVs.DataSource == null)
                return;
            transaction.BeginTransaction();
            try
            {
                PalletLocation pl = new PalletLocation();
                BLL.ReceiveDoc recDoc = new ReceiveDoc();
                recDoc.LoadByReceiptID(ReceiptID);
                recDoc.SetStatusAsReceived(null);
                BLL.Receipt receiptStatus = new BLL.Receipt();
                receiptStatus.LoadByPrimaryKey(ReceiptID);
                receiptStatus.ChangeStatus(ReceiptConfirmationStatus.Constants.RECEIVE_ENTERED, null, this.GetFormIdentifier(), CurrentContext.UserId, "Return For Quantity Editing");
                
                transaction.CommitTransaction();

                this.LogActivity("Return-Receipt-To-Quantity-Confirmation", ReceiptID);

                XtraMessageBox.Show("Receipt Returned!", "Success", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);


            }
            catch (Exception exp)
            {
                transaction.RollbackTransaction();
                throw exp;
            }
            PutAwayListsLoad(null, null);
        }

        private void lkAccount_EditValueChanged(object sender, EventArgs e)
        {
            var filter = String.Format("StoreID = {0}", lkAccount.EditValue);
            gridGRVsView.ActiveFilterString = filter;
           
        }
     
        #endregion
         
        private void gridCostBuildUpView_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
             GridView currentView = sender as GridView;
                DataRow drv = currentView.GetDataRow(e.RowHandle);
                if ((e.Column.FieldName == "GRVValue" && drv["Variable"] == "GRVTransit") || (!chkUseProration.Checked && e.Column.FieldName == "GRVValue"))
                   e.RepositoryItem = txtEnabled;
                else if (e.Column.FieldName == "GRVValue")
                    e.RepositoryItem = Disabled;         
        }

        private void gridGRVs_Click(object sender, EventArgs e)
        {
            gridGRVs_MouseClick(null, null);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var receipt = new BLL.Receipt();
            receipt.LoadByPrimaryKey(ReceiptID);
            var data = BLL.PO.GetOrderSummary(receipt.ReceiptInvoiceID);
            var orderSummary = new OrderSummary {DataSource = data};
            orderSummary.ShowPreview();
        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void labelControl4_Click(object sender, EventArgs e)
        {

        }

        private void gridInvoiceDetail_Click(object sender, EventArgs e)
        {

        }

        private void lblInsurance_Click(object sender, EventArgs e)
        {


        }

        private void labelControl3_Click_1(object sender, EventArgs e)
        {

        }

        private void gridFinal_Click(object sender, EventArgs e)
        {

        }

        private void lblStore_Click(object sender, EventArgs e)
        {

        }


        private void txtFilter_EditValueChanged(object sender, EventArgs e)
        {
            gridGRVsView.ActiveFilterString = string.Format("PONumber like '{0}%' or RefNo like '%{0}%' or InvoiceNumber like '{0}%'", txtFilter.Text);

        }

    }
}