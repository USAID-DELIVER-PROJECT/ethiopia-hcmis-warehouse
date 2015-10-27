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
using DevExpress.XtraReports.UI;
using HCMIS.Core.Finance.CostTier.Services;
using HCMIS.Desktop.Helpers;
using HCMIS.Desktop.Reports.Finance;
using HCMIS.Desktop.Reports.Helpers;
using HCMIS.Desktop.ViewHelpers;
using HCMIS.Helpers;
using HCMIS.Specification.Finance.CostTier;

namespace HCMIS.Desktop.Forms.WorkFlow.Finance
{
    [FormIdentifier("AC-EP-EP-FR", "Error Correction Pricing", "")]
    public partial class ErrorCorrectionPricing : Form
    {
        private BLL.Receipt receipt;

        public ErrorCorrectionPricing()
        {
            InitializeComponent();
        }

        private void ErrorCorrectionPricing_Load(object sender, EventArgs e)
        {
            lkAccount.SetupActivityEditor().SetDefaultActivity();
            DataTable receipts =
                BLL.Receipt.GetListOfReceipt(ReceiptType.CONSTANTS.ERROR_CORRECTION,
                                             ReceiptConfirmationStatus.Constants.GRNF_PRINTED, CurrentContext.UserId).
                    Table;

            receipts.Merge(BLL.Receipt.GetListOfReceipt(ReceiptType.CONSTANTS.ERROR_CORRECTION,
                                                        ReceiptConfirmationStatus.Constants.PRICE_CALCULATED,
                                                        CurrentContext.UserId).Table);
            grdLeftSelection.DataSource = receipts;

        }

        public void Select(int receiptID)
        {
            receipt = new BLL.Receipt();
            receipt.LoadByPrimaryKey(receiptID);
            btnSave.Enabled = receipt.ReceiptStatusID == ReceiptConfirmationStatus.Constants.GRNF_PRINTED &&
                              this.HasPermission("Save");
            btnConfirm.Enabled =btnReturn.Enabled = receipt.ReceiptStatusID == ReceiptConfirmationStatus.Constants.PRICE_CALCULATED &&
                                 this.HasPermission("Confirmation");
            grdDetail.DataSource = receipt.GetGRVDetailsforCosting();
        }

        private void grdLeftSelection_Click(object sender, EventArgs e)
        {
            var dr = grdLeftSelectionView.GetFocusedDataRow();
            if (dr != null)
            {
                Select(Convert.ToInt32(dr["ID"]));
            }
        }



        public DataView getPriceChangeReport(CostElement costElement)
        {
            TheDataSet dataSet = new TheDataSet();
            DataRow dr = dataSet.PriceOveride.NewRow();

            dataSet.PriceOveride.Rows.Add(costElement.priceChangeReport(dr));
            return dataSet.PriceOveride.DefaultView;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            MyGeneration.dOOdads.TransactionMgr transaction = MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgr();

            var dt = grdDetailView.DataSource as DataView;
            if ((dt) != null)
            {

                // This is where we set the Price

                foreach (DataRow dr in dt.Table.Rows)
                {
                    var costElement = new CostElement();
                    costElement.LoadFromDataRow(dr, receipt.ID);
                    costElement.AverageCost =Math.Round(Convert.ToDouble(dr["AverageCost"]),BLL.Settings.NoOfDigitsAfterTheDecimalPoint,MidpointRounding.AwayFromZero);
                    costElement.Margin = Convert.ToDouble(dr["Margin"]);

                    costElement.SellingPrice = Math.Round(Convert.ToDouble(dr["SellingPrice"]), BLL.Settings.NoOfDigitsAfterTheDecimalPoint, MidpointRounding.AwayFromZero);
                    try
                    {
                        transaction.BeginTransaction();
                        var journalService = new JournalService();
                        journalService.StartRecordingSession();
                        costElement.SetPriceForReceiveDocs();
                        costElement.SavePrice(CurrentContext.UserId, costElement.ReceiptID.ToString(), journalService,
                                              ChangeMode.ErrorCorrection);
                        journalService.CommitRecordingSession();
                        transaction.CommitTransaction();

                    }
                    catch (Exception exception)
                    {
                        transaction.RollbackTransaction();
                        XtraMessageBox.Show("Error : " + exception.Message, "Error...", MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                        throw exception;
                    }
                    var report = new PriceOverridePrintout
                                     {
                                         xrCostedBy = {Text = CurrentContext.LoggedInUserName},
                                         lblDate = {Text = DateTimeHelper.ServerDateTime.ToString()},
                                         DataSource = getPriceChangeReport(costElement)
                                     };
                    report.ShowPreviewDialog();

                }
                var recDoc = new ReceiveDoc();
                recDoc.LoadByReceiptID(receipt.ID);
                recDoc.SetPrice(CurrentContext.UserId);
                receipt.ChangeStatus(ReceiptConfirmationStatus.Constants.PRICE_CALCULATED, null,
                                     this.GetFormIdentifier(), CurrentContext.UserId, "Price Set");

            }
        }

        private void grdDetailView_CellValueChanged(object sender,
                                                    DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRow dr = grdDetailView.GetDataRow(e.RowHandle);
            if (!dr.IsNull("AverageCost") && !dr.IsNull("Margin"))
            {
                if (e.Column == colUnitCost)
                {
                    dr["SellingPrice"] = Math.Round(
                        (Convert.ToDecimal(dr["Margin"]) + 1) * Convert.ToDecimal(dr["AverageCost"]),
                        BLL.Settings.NoOfDigitsAfterTheDecimalPoint, MidpointRounding.AwayFromZero);
                }
                else if (e.Column == colMargin)
                {
                    dr["SellingPrice"] = Math.Round(
                        (Convert.ToDecimal(dr["Margin"]) + 1) * Convert.ToDecimal(dr["AverageCost"]),
                        BLL.Settings.NoOfDigitsAfterTheDecimalPoint, MidpointRounding.AwayFromZero);

                }
                else if (e.Column == colSellingPrice)
                {
                    dr["Margin"] =
                        Math.Round(Convert.ToDecimal(dr["SellingPrice"]) / Convert.ToDecimal(dr["AverageCost"]) - 1,
                                   BLL.Settings.NoOfDigitsAfterTheDecimalPoint + 2, MidpointRounding.AwayFromZero);

                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            MyGeneration.dOOdads.TransactionMgr transaction = MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgr();

            var dt = grdDetailView.DataSource as DataView;
            if ((dt) != null)
            {

                // This is where we set the Price

                foreach (DataRow dr in dt.Table.Rows)
                {
                    var costElement = new CostElement();
                    costElement.LoadFromDataRow(dr, receipt.ID);
                    costElement.AverageCost = Convert.ToDouble(dr["AverageCost"]);
                    costElement.Margin = Convert.ToDouble(dr["Margin"]);

                    costElement.SellingPrice = Convert.ToDouble(dr["SellingPrice"]);
                    try
                    {
                        transaction.BeginTransaction();
                        var journalService = new JournalService();
                        journalService.StartRecordingSession();
                        costElement.ConfirmPrice(CurrentContext.UserId, "", journalService, ChangeMode.PriceOverride);
                        var receiveDoc = new ReceiveDoc();
                        receiveDoc.SavePrice(costElement, CurrentContext.UserId);
                        journalService.CommitRecordingSession();
                        transaction.CommitTransaction();

                    }
                    catch (Exception exception)
                    {
                        transaction.RollbackTransaction();
                        XtraMessageBox.Show("Error : " + exception.Message, "Error...", MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                        throw exception;
                    }
                    var report = new PriceOverridePrintout
                                     {
                                         xrCostedBy = {Text = CurrentContext.LoggedInUserName},
                                         lblDate = {Text = DateTimeHelper.ServerDateTime.ToString()},
                                         DataSource = getPriceChangeReport(costElement)
                                     };
                    report.ShowPreviewDialog();

                }
                var recDoc = new ReceiveDoc();
                recDoc.LoadByReceiptID(receipt.ID);
                recDoc.ConfirmGRVPrinted(CurrentContext.UserId);
                receipt.ChangeStatus(ReceiptConfirmationStatus.Constants.GRV_PRINTED, null,
                                     this.GetFormIdentifier(), CurrentContext.UserId, "Price Set");

            }

        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            var recDoc = new ReceiveDoc();
            recDoc.LoadByReceiptID(receipt.ID);
            recDoc.ConfirmGRNFPrinted(CurrentContext.UserId);
            receipt.ChangeStatus(ReceiptConfirmationStatus.Constants.GRNF_PRINTED, null,
                                 this.GetFormIdentifier(), CurrentContext.UserId, "Price Set");
            MessageBox.Show("The Correction has been return to Pricing", "Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void lkAccount_EditValueChanged(object sender, EventArgs e)
        {
            var activityID = lkAccount.EditValue;
            grdLeftSelectionView.ActiveFilterString = string.Format("[ActivityID] = {0}", activityID);
        }
    }
}