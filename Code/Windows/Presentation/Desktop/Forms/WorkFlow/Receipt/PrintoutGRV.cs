using System;
using System.ComponentModel;
using System.Data;
using BLL;
using BLL.Finance;
using CalendarLib;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using HCMIS.Desktop.Helpers;
using HCMIS.Helpers;
using HCMIS.Desktop.Modals;
using System.IO;
using HCMIS.Desktop.ViewHelpers;
using HCMIS.Desktop.Forms.Modals.Finance;
using HCMIS.Core.Finance.CostTier;
using HCMIS.Specification.Finance.CostTier;

namespace HCMIS.Desktop.Forms.WorkFlow
{
    [FormIdentifier("CM-GR-GR-CN","GRV Printout","")]
    public partial class PrintoutGRV : XtraForm
    {
        
        public enum Modes
        {
            GRVPrinting = 1
        }
        /// <summary>
        /// TO BE Splitted
        /// </summary>
        Modes currentMode;
        DataSet ds = new DataSet();
        //For Printing Process
        PrintDialog printDialog;
        ICostCalculator GRV;
        int ReceiptID;

        public PrintoutGRV()
        {
            
            InitializeComponent();
            currentMode = Modes.GRVPrinting;
        }

        
        private void PutAwayListsLoad(object sender, EventArgs e)
        {
            SetPermission();
            //Lookup For Accounts
            lkAccount.SetupActivityEditor().SetDefaultActivity();
            BindFormContents();

            gridReceiveView_FocusedRowChanged(null, null);

            
        }

        private void SetPermission()
        {
            if (BLL.Settings.UseNewUserManagement)
            {
                btnPrint.Enabled = this.HasPermission("Print");
                btnReturn.Enabled = this.HasPermission("Return-For-Edit");
            }
        }

        private void BindFormContents()
        {
            PalletLocation pl = new PalletLocation();
            lkPalletLocations.DataSource = PalletLocation.GetAll();

            if (currentMode == Modes.GRVPrinting)
            {

                gridReceives.DataSource = pl.GetReceivesForGRVPrinting(CurrentContext.UserId, 1);
              
            }
        }
     
        #region
    
        private void gridReceiveView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            // Bind the detail grid
            PalletLocation pl = new PalletLocation();
            try
            {
                ReceiptID = Convert.ToInt32(gridReceiveView.GetFocusedDataRow()["ReceiptID"]);
                BLL.Receipt receiptDoc = new BLL.Receipt();
                var rd = new ReceiveDoc();
                rd.LoadByReceiptID(ReceiptID);

                var ps = new PhysicalStore();
                ps.LoadByPrimaryKey(rd.PhysicalStoreID);

                var w = new BLL.Warehouse();
                w.LoadByPrimaryKey(ps.PhysicalStoreTypeID);
                lblWarehouse.Text = w.Name ?? "-";

                var c = new Cluster();
                c.LoadByPrimaryKey(w.ClusterID);
                lblCluster.Text = c.Name ?? "-";
                   
                
                
                receiptDoc.LoadByPrimaryKey(ReceiptID);
                DataTable GRNFDetail =  receiptDoc.GetDetailsForGRNF();   
                gridDetails.DataSource = GRNFDetail;
                gridShortage.DataSource = receiptDoc.GetDiscrepancyForGRNF();
                int status = Convert.ToInt32(gridReceiveView.GetFocusedDataRow()["Status"]);

                var SelectGRV = gridReceiveView.GetFocusedDataRow();

                lblMode.Text = (string)SelectGRV["ModeName"];
                lblAccount.Text = (string)SelectGRV["AccountName"];
                lblSubAccount.Text = (string)SelectGRV["SubAccountName"];
                lblActivity.Text = (string)SelectGRV["ActivityName"];
                lblSupplier.Text = (string)SelectGRV["SupplierName"];
                lblPONumber.Text = (string)SelectGRV["PONo"];
              
                lblType.Text = (string)SelectGRV["ReceiptType"];
                lblStatus.Text = (string)SelectGRV["CurrentStatus"];

                var lgs = new LogReceiptStatus();
                lgs.LoadByReceiptID(ReceiptID);
               
                lblCalculatedDate.Text = lgs.StatusChangedDate.ToShortDateString();

                

                var user = new User();
                if (SelectGRV["calculatedBy"] != DBNull.Value)
                {
                    user.LoadByPrimaryKey(Convert.ToInt32(SelectGRV["calculatedBy"]));
                    lblCalculatedBy.Text = user.FullName;
                }

                else
                {
                    lblCalculatedBy.Text = "-";
                }

                lblCostConfirmedBy.Text = SelectGRV["confirmedBy"] != DBNull.Value ? SelectGRV["confirmedBy"].ToString() : "-";

                //lblGRVNumber.Text = reference;
                //lblRecivedDate.Text = ((DateTime)SelectGRV["Date"]).ToShortDateString();
                lblCostConfirmedDate.Text = SelectGRV["confirmedDate"] != DBNull.Value ? Convert.ToDateTime(SelectGRV["confirmedDate"]).ToShortDateString() : "-";


                string s = "";

                int length = ((string)SelectGRV["STVOrInvoiceNo"]).Length;
                string grv = (Convert.ToInt32(SelectGRV["IDPrinted"])).ToString();
                HeaderGroup.Text = "Invoice No: " + (string)SelectGRV["STVOrInvoiceNo"] + s.PadRight(240 - length) + "GRV No: " + grv ;




                //ReceiptID = Convert.ToInt32(gridReceiveView.GetFocusedDataRow()["ReceiptID"]);
                //ds = new DataSet();
                //DataTable dvMaster = pl.GetDetailsOfByReceiptID(ReceiptID);
                //dvMaster.TableName = "Master";
                //ds.Tables.Add(dvMaster);
                //gridDetails.DataSource = ds.Tables[dvMaster.TableName];


               

                //var receipt = new BLL.Receipt();
                //receipt.LoadByPrimaryKey(ReceiptID);
                //int receiptTypeID = receipt.ReceiptTypeID;
                
                
                
                if (currentMode == Modes.GRVPrinting)
                {
                    if (status != ReceiptConfirmationStatus.Constants.PRICE_CONFIRMED)
                    {
                        gridDetails.Enabled = false;
                       
                        btnConfirm.Enabled = false;
                        btnPrint.Enabled = false;
                        btnReturn.Enabled = false;
                    }
                    else
                    {
                        gridDetails.Enabled = true;
                        btnConfirm.Enabled = true;
                        btnPrint.Enabled = true;
                        btnReturn.Enabled = true;
                    }
                }
            }

            catch
            {
                gridDetails.DataSource = null;
                gridShortage.DataSource = null;
            }
        }

        private void gridReceiveView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            gridReceiveView_FocusedRowChanged(null, null);
        }
      
        #endregion
        
        private void OnQueryPopup(object sender, CancelEventArgs e)
        {
            PalletLocation pl = new PalletLocation();
            LookUpEdit lke = (LookUpEdit)gridDetailView.ActiveEditor;
            int itemID = Convert.ToInt32(gridDetailView.GetFocusedDataRow()["ItemID"]);
            lke.Properties.DataSource = PalletLocation.GetAllFreeFor(itemID);
        }

        private bool SetSellingPrice(ICostCalculator CostCalculator)
        {
                    
            foreach (CostElement costElement in CostCalculator.CostElements)
            {
                costElement.CheckMovingAverageCost();
                    using (SellingPriceValidation pricePerPackPage = new SellingPriceValidation(costElement.PreviousCostDetials)) 
                    {
                       if(pricePerPackPage.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
                       return false;
                    }
            }
            return true;
        }
        private void OnConfirmClicked(object sender, EventArgs e)
        {
           
            printDialog = new PrintDialog();
               
                if (printDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
               {
                   XtraMessageBox.Show("Print has been Canceled By User");
                   return;
               }
                if (BLL.Settings.IsCenter)
                {
                    GRV = new CenterCostCalculator();
                    GRV.LoadGRV(ReceiptID);
                    GRV.CalculateFinalCost();
                }
                else
                {
                    GRV = new CostCalculator();
                    GRV.LoadGRV(ReceiptID);
                    (GRV as CostCalculator).LoadGRVPreviousStock();
                    GRV.CalculateFinalCost();
                }
                if(!SetSellingPrice(GRV))
                {
                    return;
                }

                HCMIS.Desktop.Reports.ReceiptConfirmationPrintout printout = new HCMIS.Desktop.Reports.ReceiptConfirmationPrintout(CurrentContext.LoggedInUserName);
                MyGeneration.dOOdads.TransactionMgr transaction = MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgr();
                try
                {
                  transaction.BeginTransaction();
                  // This is where we set the Price for the previous Stock
                  foreach (CostElement costElement in GRV.CostElements)
                  {
                          costElement.PreviousCostDetials.Confirm(CurrentContext.UserId);
                  }
                    printout = PrintConfirmation(null);
                    CostingService.ConfirmPriceChange(GRV.CostElements, CurrentContext.UserId, ChangeMode.Recieve, ReceiptID.ToString());
                    GRV.SetFinalCostlog(CurrentContext.UserId);
                    transaction.CommitTransaction();
                }
                catch (Exception ex)
                {
                    transaction.RollbackTransaction();
                    
                    XtraMessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    throw ;
                }
                printout.Print(printDialog.PrinterSettings.PrinterName);
        }


        /// <summary>
        /// Prints GRV, SRM or Delivery Note
        /// </summary>

        private HCMIS.Desktop.Reports.ReceiptConfirmationPrintout PrintConfirmation(int? reprintOfReceiptConfirmationPrintoutID)
        {
            int ReceiptID = Convert.ToInt32(gridReceiveView.GetFocusedDataRow()["ReceiptID"].ToString());
            return PrintReceiptConfirmation(ReceiptID, reprintOfReceiptConfirmationPrintoutID);
        }

        private HCMIS.Desktop.Reports.ReceiptConfirmationShortagePrintout PrintReceiptConfirmationForShortage(int ReceiptID, int printedID)
        {
            HCMIS.Desktop.Reports.ReceiptConfirmationShortagePrintout printout = new HCMIS.Desktop.Reports.ReceiptConfirmationShortagePrintout();
           ReceiptConfirmationPrintout rc = new ReceiptConfirmationPrintout();

            BLL.ReceiveDoc receiveDoc = new ReceiveDoc();
            receiveDoc.LoadAllByReceiptID(ReceiptID);

            if (currentMode == Modes.GRVPrinting )
            {
                BLL.Supplier supplier = new Supplier();
                supplier.LoadByPrimaryKey(receiveDoc.SupplierID);
            }
            rc.PrepareDataForPrintout(ReceiptID, CurrentContext.UserId, true, 2, printedID,null,FiscalYear.Current);
            printout.DataSource = rc.DefaultView.ToTable();            
            return printout;
        }

        private HCMIS.Desktop.Reports.ReceiptConfirmationPrintout PrintReceiptConfirmation(int ReceiptID, int? reprintOfReceiptConfirmationPrintoutID)
        {
            ReceiptConfirmationPrintout rc = new ReceiptConfirmationPrintout();

            HCMIS.Desktop.Reports.ReceiptConfirmationPrintout printout = new HCMIS.Desktop.Reports.ReceiptConfirmationPrintout(CurrentContext.LoggedInUserName);
            
            
        
            BLL.ReceiveDoc receiveDoc = new ReceiveDoc();
            //  receiveDoc.LoadByReferenceNo(reference);
            receiveDoc.LoadByReceiptID(ReceiptID);
            var activity = new Activity();
            activity.LoadByPrimaryKey(receiveDoc.StoreID);
            BLL.Supplier supplier = new Supplier();         
            supplier.LoadByPrimaryKey(receiveDoc.SupplierID);
            BLL.Receipt receipt=new BLL.Receipt();
            receipt.LoadByPrimaryKey(receiveDoc.ReceiptID);
            BLL.ReceiptInvoice receiptInvoice= new ReceiptInvoice();
            receiptInvoice.LoadByPrimaryKey(receipt.ReceiptInvoiceID);
            BLL.PO po = new PO();
            po.LoadByPrimaryKey(receiptInvoice.POID);
            BLL.POType poType = new POType();
            poType.LoadByPrimaryKey(po.PurchaseType);

            int printedID = 0;
            string GRNFNo = FiscalYear.Current.GetCode(BLL.ReceiptConfirmationPrintout.GetGRNFNo(ReceiptID));
            if (currentMode == Modes.GRVPrinting) //The GRVConfirmation is for reprinting
            {
                printout.BranchName.Text = GeneralInfo.Current.HospitalName;
                PrepareGRVPrintout(printout);
                //  String reference = gridReceiveView.GetFocusedDataRow()["RefNo"].ToString();

                if (poType.PurchaseOrderTypeCode == "LP") printout.xrGRVLabel.Text = "GRV No.";
                else printout.xrGRVLabel.Text = "iGRV No.";          
                
                if (supplier.SupplierTypeID == SupplierType.CONSTANTS.HOME_OFFICE ||
                 supplier.SupplierTypeID == SupplierType.CONSTANTS.HUBS ||
                 supplier.SupplierTypeID == SupplierType.CONSTANTS.ACCOUNTS ||
                 supplier.SupplierTypeID == SupplierType.CONSTANTS.STORES)
                {
                    //printout.xrGRVLabel.Text =  "iGRV No.";
                    printout.xrAir.Visible = false;
                    printout.xrAirValue.Visible = false;
                    printout.xrTransit.Visible = false;
                    printout.xrTransitValue.Visible = false;
                    printout.xrInsurance.Visible = false;
                    printout.xrInsuranceValue.Visible = false;
                    printout.xrNumberOfCases.Visible = false;
                    printout.xrNumberOfCasesValue.Visible = false;
                    printout.xrInvoiceNo.Text = "STV No.";
                    printout.xrPurchaseOrderNo.Visible = false;
                    printout.xrPurchaseOrderNoValue.Visible = false;

                    printout.xrLabelGRNF.Text = GRNFNo;
                    printout.xrSTV.Visible = false;
                    printout.xrSTVNoValue.Visible = false;
                    printedID = rc.PrepareDataForPrintout(ReceiptID, CurrentContext.UserId, false, 4,
                                                                    null,reprintOfReceiptConfirmationPrintoutID,FiscalYear.Current);
                    printout.DataSource = rc.DefaultView.ToTable();
                    CalendarLib.DateTimePickerEx dtDate = new CalendarLib.DateTimePickerEx();
                    //dtDate.CustomFormat = "dd/MM/yyyy";
                    dtDate.Value = receiveDoc.EurDate;

                    printout.Date.Text = dtDate.Text;
                }
                else
                {
                   // printout.xrGRVLabel.Text = "GRV No.";
                    printout.xrSTV.Visible = false;
                    printout.xrSTVNoValue.Visible = false;
                    printedID = rc.PrepareDataForPrintout(ReceiptID, CurrentContext.UserId, false, 2,
                                                                    null, reprintOfReceiptConfirmationPrintoutID,FiscalYear.Current);
                    printout.xrLabelGRNF.Text = GRNFNo;
                    printout.DataSource = rc.DefaultView.ToTable();

                    CalendarLib.DateTimePickerEx dtDate = new CalendarLib.DateTimePickerEx();
                    //dtDate.CustomFormat = "dd/MM/yyyy";
                    dtDate.Value = receiveDoc.EurDate;

                    printout.Date.Text = dtDate.Text;
                }
            }


            printout.xrLabelStoreName.Text = activity.FullActivityName;

            if (ReceiveDoc.IsThereShortageOrDamage(ReceiptID))
            {
                HCMIS.Desktop.Reports.ReceiptConfirmationShortagePrintout printoutShortage =
                    PrintReceiptConfirmationForShortage(ReceiptID, printedID);
                if (currentMode == Modes.GRVPrinting)
                    PrepareGRVPrintout(printoutShortage);
                printout.xrShortageReport.ReportSource = printoutShortage;
              
                printout.PrintingSystem.ContinuousPageNumbering = true;
            }
            else
            {
                printout.ReportFooter.Visible = false;
            }

            //Release Product 
            CostCalculator GRV = new CostCalculator();
            GRV.LoadGRV(ReceiptID);

            String reference = gridReceiveView.GetFocusedDataRow()["RefNo"].ToString();
            
            BLL.ReceiveDoc recDoc = new ReceiveDoc();
            recDoc.LoadByReceiptID(ReceiptID);
            recDoc.ConfirmGRVPrinted(CurrentContext.UserId);
            BLL.Receipt receiptStatus = new BLL.Receipt();
            receiptStatus.LoadByPrimaryKey(ReceiptID);
            receiptStatus.ChangeStatus(ReceiptConfirmationStatus.Constants.GRV_PRINTED, null, this.GetFormIdentifier(), CurrentContext.UserId, "GRV Printed");
          
            BindFormContents();
            // LOG Cost Analysis printout in PDF Log
            MemoryStream stream = new MemoryStream();
            printout.ExportToPdf(stream);
            HCMIS.Core.Distribution.Services.PrintLogService.SavePrintLogNoWait(stream, "GRV/IGRV", true, ReceiptID, CurrentContext.UserId, BLL.DateTimeHelper.ServerDateTime);
            return printout;
        }

        private void PrepareGRVPrintout(DevExpress.XtraReports.UI.XtraReport printout)
        {
            BLL.ReportPrintout rpt = new ReportPrintout();
            
            if (rpt.IsReportSizeCustom("GOODS_RECEIPT_VOUCHER"))
            {
                printout.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
                printout.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                printout.PageHeight = rpt.HeightInMM / 10; //Convert.ToInt32(BLL.Settings.PaperHeightCredit);
                printout.PageWidth = rpt.WidthInMM / 10; //Convert.ToInt32(BLL.Settings.PaperWidthCredit);
            }
        }

        #region
        
        private void btnPrint_Click(object sender, EventArgs e)
        {
            gridDetails.ShowPrintPreview();
        }

        #endregion
     
        private void lkAccount_EditValueChanged(object sender, EventArgs e)
        {
            gridReceiveView.ActiveFilterString = String.Format("StoreID = {0}", lkAccount.EditValue);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (currentMode == Modes.GRVPrinting)
                ReturnFromGRVPrinting();

        }

        private void ReturnFromGRVPrinting()
        {
            BLL.ReceiveDoc receiveDoc = new ReceiveDoc();
            int ReceiptID = Convert.ToInt32(gridReceiveView.GetFocusedDataRow()["ReceiptID"]); 
             receiveDoc.LoadByReceiptID(ReceiptID);
            receiveDoc.ConfirmGRNFPrinted(null);
            BLL.Receipt receiptStatus = new BLL.Receipt();
            receiptStatus.LoadByPrimaryKey(ReceiptID);
            receiptStatus.ChangeStatus(ReceiptConfirmationStatus.Constants.PRICE_CALCULATED, null, this.GetFormIdentifier(), CurrentContext.UserId, "Return For Price Change");
            BindFormContents();
        }

        private void ReturnToStoreForQuantityEdit()
        {
            //TODO: finish updating the changed locations
            MyGeneration.dOOdads.TransactionMgr transaction = MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgr();
            transaction.BeginTransaction();
            try
            {
                PalletLocation pl = new PalletLocation();
                String reference = gridReceiveView.GetFocusedDataRow()["RefNo"].ToString();
                //           pl.ConfirmAllReceived(reference);
                if (gridDetailView.DataSource == null)
                    return;

                foreach (DataRowView drv in gridDetailView.DataSource as DataView)
                {
                    int PalletLocationID = Convert.ToInt32(drv["PalletLocationID"]);
                    int ProposedPalletLocationID = Convert.ToInt32(drv["ProposedPalletLocationID"]);
                    int PalletID = Convert.ToInt32(drv["PalletID"]);
                    int receiveID = Convert.ToInt32(drv["ReceiveID"]);

                    if (PalletLocationID != ProposedPalletLocationID)
                    {
                        pl.LoadByPrimaryKey(PalletLocationID);
                        if (pl.IsColumnNull("PalletID"))
                        {
                            pl.Confirmed = false;
                            pl.Save();
                        }
                    }
                    else
                    {
                        pl.LoadByPrimaryKey(PalletLocationID);
                        pl.Confirmed = false;
                        pl.Save();
                    }
                }



                BLL.ReceiveDoc recDoc = new ReceiveDoc();
                recDoc.LoadByReferenceNo(reference);
                recDoc.SetStatusAsReceived(null);
                transaction.CommitTransaction();
                XtraMessageBox.Show("Receipt Returned!", "Success", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                BindFormContents();

            }
            catch (Exception exp)
            {
                transaction.RollbackTransaction();
                XtraMessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridDetailView_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridDetailView.GetFocusedDataRow();

        }

        //TODO: Definitly going to BLL but i don't have time to do a clean job here.
        #region Void Process

        private void btnVoid_Click(object sender, EventArgs e)
        {
            int receiptID = Convert.ToInt32(gridReceiveView.GetFocusedDataRow()["ReceiptID"].ToString());

            if(BLL.Receipt.AreThereIssues(receiptID))
            {
                if (CurrentContext.LoggedInUser.UserType == UserType.Constants.FINANCE) //Allow only the manager to void the GRV.
                {
                    if(XtraMessageBox.Show("There are issues with this GRV. Are you sure you want to void it anyway?","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.No)
                    {
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show("There are issues with this GRV.  You can't void it.");
                    return;
                }
            }

            ReceiptConfirmationPrintout grv = new ReceiptConfirmationPrintout();
            grv.Where.ReceiptID.Value = receiptID;
            grv.Query.Load();

            if (!grv.VoidRequest)
            {
                XtraMessageBox.Show("Void needs to be first requested.", "Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "Are you sure, you want to Void the Document?", "Are you sure:", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                while (!grv.EOF)
                {
                    grv.IsVoided = true;
                    grv.VoidApprovedByUserID = CurrentContext.UserId;
                    grv.VoidApprovalDateTime = DateTimeHelper.ServerDateTime;
                    grv.MoveNext();
                }

                grv.Save();



                ReturnToStoreForQuantityEdit();
            }
        }
  
        private void btnVoidRequest_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "Are you sure, you want to request void for this Document?", "Are you sure:", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                int receiptID = Convert.ToInt32(gridReceiveView.GetFocusedDataRow()["ReceiptID"].ToString());

                ReceiptConfirmationPrintout grv = new ReceiptConfirmationPrintout();
                grv.Where.ReceiptID.Value = receiptID;
                grv.Query.Load();

                while (!grv.EOF)
                {
                    grv.VoidRequestUserID = CurrentContext.UserId;
                    grv.VoidRequest = true;
                    grv.VoidRequestDateTime = DateTimeHelper.ServerDateTime;
                    grv.MoveNext();
                }

                grv.Save();
                XtraMessageBox.Show("Void requested.", "Success");
            }
        }

        private void btnCancelVoidRequest_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "Are you sure, you want to request void for this Document?", "Are you sure:", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                int receiptID = Convert.ToInt32(gridReceiveView.GetFocusedDataRow()["ReceiptID"].ToString());

                ReceiptConfirmationPrintout grv = new ReceiptConfirmationPrintout();
                grv.Where.ReceiptID.Value = receiptID;
                grv.Query.Load();

                while (!grv.EOF)
                {
                    grv.SetColumnNull("VoidRequestUserID");
                    grv.VoidRequest = true;
                    grv.SetColumnNull("VoidRequestDateTime");
                    grv.MoveNext();
                }

                grv.Save();
                XtraMessageBox.Show("Void request cancelled.", "Success");
            }
        }
        
        #endregion

        private void gridDetails_Click(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void labelControl12_Click(object sender, EventArgs e)
        {

        }

        private void txtFilter_EditValueChanged(object sender, EventArgs e)
        {
            gridReceiveView.ActiveFilterString = string.Format("IDPrinted like '%{0}%' or Date like '{0}%' or PONo like '{0}%' or STVOrInvoiceNo like '{0}%'", txtFilter.Text);
        }
    }
}
