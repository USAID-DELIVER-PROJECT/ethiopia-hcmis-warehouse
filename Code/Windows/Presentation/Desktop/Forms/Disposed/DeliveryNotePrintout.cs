using System;
using System.ComponentModel;
using System.Data;
using BLL;
using CalendarLib;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using HCMIS.Desktop.Helpers;
using HCMIS.Desktop.ViewHelpers;
using HCMIS.Helpers;
using HCMIS.Desktop.Modals;

namespace HCMIS.Desktop.Forms.WorkFlow
{
    [FormIdentifier("AR-DN-DN-VW","Delivery Note Printout","")]
    public partial class DeliveryNotePrintout : XtraForm
    {
        public enum Modes
        {
           DeliveryNotePrinting = 3
        }
        /// <summary>
        /// TO BE Splitted
        /// </summary>
        Modes currentMode;
        DataSet ds = new DataSet();

    
        int ReceiptID;
        int StoreID;

        public DeliveryNotePrintout()
        {
            InitializeComponent();
            currentMode = Modes.DeliveryNotePrinting;
        }


        private void SetUserPermissions()
        {
            if (BLL.Settings.UseNewUserManagement)
            {
                btnPrint.Enabled = this.HasPermission("Print");
                btnConfirm.Enabled = this.HasPermission("Confirm");
                btnReturn.Enabled = this.HasPermission("Return");
            }
        }

        private void PutAwayListsLoad(object sender, EventArgs e)
        {
            //Lookup For Accounts
            SetUserPermissions();
            lkAccount.SetupActivityEditor().SetDefaultActivity();
            BindFormContents();

            if (currentMode == Modes.DeliveryNotePrinting)
            {
                colReceivingCost.Visible = false;
            }
            
           //lkAccount.EditValue = Stores.GetDefaultStore(NewMainWindow.UserId).ID;
                gridReceiveView_FocusedRowChanged(null, null);
            XtraMessageBox.Show("This Page is no longer in use!", "This Page Is no Longer in use", MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
            this.Enabled = false;
        }

        private void BindFormContents()
        {
            PalletLocation pl = new PalletLocation();
            lkPalletLocations.DataSource = PalletLocation.GetAll();

             if (currentMode == Modes.DeliveryNotePrinting)
            {

                gridReceives.DataSource = pl.GetReceivesForGRVPrinting(CurrentContext.UserId, 3);
                colLocation.Visible = false;
                colInsurance.Visible = false;
                colMargin.Visible = false;
            }
           
        }
     
        #region
    
        private void gridReceiveView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            // Bind the detail grid
            PalletLocation pl = new PalletLocation();
            try
            {
                String reference = gridReceiveView.GetFocusedDataRow()["RefNo"].ToString();
                lblGRVNo.Text = reference;
                ReceiptID = Convert.ToInt32(gridReceiveView.GetFocusedDataRow()["ReceiptID"]);
                ds = new DataSet();
                DataTable dvMaster = pl.GetDetailsOfByReceiptID(ReceiptID);
                    dvMaster.TableName = "Master";
                    ds.Tables.Add(dvMaster);
                    gridDetails.DataSource = ds.Tables[dvMaster.TableName];
                  
                
                int status = Convert.ToInt32(gridReceiveView.GetFocusedDataRow()["Status"]);
                try
                {
                    StoreID = Convert.ToInt32(gridReceiveView.GetFocusedDataRow()["StoreID"]);

                     Convert.ToInt32(gridReceiveView.GetFocusedDataRow()["SupplierID"]);
                }
                catch
                {

                }
                
              
            }

            catch
            {
                gridDetails.DataSource = null;
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

        private void OnConfirmClicked(object sender, EventArgs e)
        {
            if (currentMode == Modes.DeliveryNotePrinting)
            {
                MyGeneration.dOOdads.TransactionMgr transaction = MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgr();
                try
                {
                    transaction.BeginTransaction();
                    SetFinalCost();
                    PrintConfirmation(null);
                    transaction.CommitTransaction();
                }
                catch (Exception ex)
                {
                    transaction.RollbackTransaction();
                    XtraMessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// Final Cost Settings
        /// </summary>
        /// <returns></returns>
        public Boolean SetFinalCost()
        {
            CostCalculator GRV = new CostCalculator();
            GRV.LoadGRV(ReceiptID);
            GRV.CalculateFinalCost(); 
            GRV.SetFinalCostlog(CurrentContext.UserId);
            foreach (DataRowView drv in GRV.GRVSoundDetail.DefaultView)
            {

                double NewUnitCost, NewSellingPrice;
                NewUnitCost = Math.Round(Convert.ToDouble(drv["AverageCost"]), BLL.Settings.NoOfDigitsAfterTheDecimalPoint);
                NewSellingPrice = Math.Round(Convert.ToDouble(drv["SellingPrice"]), BLL.Settings.NoOfDigitsAfterTheDecimalPoint);
                HCMIS.Desktop.Forms.Modals.Finance.SellingPricePage sellingPriceForm = new HCMIS.Desktop.Forms.Modals.Finance.SellingPricePage(ReceiptID, Convert.ToInt32(drv["ItemID"]), Convert.ToInt32(drv["ManufacturerID"]), Convert.ToInt32(drv["ItemUnitID"]), Convert.ToInt32(drv["AccountID"]), NewUnitCost, NewSellingPrice);
                if (sellingPriceForm.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
                {
                    return false;
                }
            }
           
            return true;
        }

        /// <summary>
        /// Prints GRV, SRM or Delivery Note
        /// </summary>

        private void PrintConfirmation(int? reprintOfReceiptConfirmationPrintoutID)
        {
            String reference = gridReceiveView.GetFocusedDataRow()["RefNo"].ToString();
            PrintReceiptConfirmation(reference, reprintOfReceiptConfirmationPrintoutID);
        }

        private HCMIS.Desktop.Reports.ReceiptConfirmationShortagePrintout PrintReceiptConfirmationForShortage(string reference, int printedID)
        {
            HCMIS.Desktop.Reports.ReceiptConfirmationShortagePrintout printout = new HCMIS.Desktop.Reports.ReceiptConfirmationShortagePrintout();
            ReceiptConfirmationPrintout rc = new ReceiptConfirmationPrintout();

            BLL.ReceiveDoc receiveDoc = new ReceiveDoc();
            receiveDoc.LoadByReceiptID(ReceiptID);
            rc.PrepareDataForPrintout(ReceiptID, CurrentContext.UserId, true, 2, printedID,null,FiscalYear.Current);
            printout.DataSource = rc.DefaultView.ToTable();
            return printout;
        }

        private void ConfirmQuantityAndLocation()
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
                            pl.PalletID = PalletID;
                            pl.Confirmed = true;
                            pl.Save();

                            pl.LoadByPrimaryKey(ProposedPalletLocationID);
                            pl.SetColumnNull("PalletID");
                            pl.Save();
                        }
                        else
                        {
                            XtraMessageBox.Show("Some Items/Pallets were not confirmed correctly because the newly selected pallet location was already occupied.", "Some Items were not confirmed.");
                        }
                    }
                    else
                    {
                        pl.LoadByPrimaryKey(PalletLocationID);
                        pl.PalletID = PalletID;
                        pl.Confirmed = true;
                        pl.Save();
                    }
                }

                BLL.ReceiveDoc recDoc = new ReceiveDoc();
                recDoc.LoadByReferenceNo(reference);
                recDoc.ConfirmQuantityAndLocation(null);

                transaction.CommitTransaction();
                XtraMessageBox.Show("Receipt Confirmed!", "Success", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                BindFormContents();

            }
            catch (Exception exp)
            {
                transaction.RollbackTransaction();
                XtraMessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintReceiptConfirmation(string referenceNumber, int? reprintOfReceiptConfirmationPrintoutID)
        {
            ReceiptConfirmationPrintout rc = new ReceiptConfirmationPrintout();
            HCMIS.Desktop.Reports.ReceiptConfirmationPrintout printout = new HCMIS.Desktop.Reports.ReceiptConfirmationPrintout(CurrentContext.LoggedInUserName);

            HCMIS.Desktop.Reports.SRMPrintout srmPrintout = new HCMIS.Desktop.Reports.SRMPrintout(CurrentContext.LoggedInUserName);

            int ReceiptID = Convert.ToInt32(gridReceiveView.GetFocusedDataRow()["ReceiptID"]);
            BLL.ReceiveDoc receiveDoc = new ReceiveDoc();
            //  receiveDoc.LoadByReferenceNo(reference);
            receiveDoc.LoadByReceiptID(ReceiptID);
            BLL.Supplier supplier = new Supplier();
            supplier.LoadByPrimaryKey(receiveDoc.SupplierID);

            int printedID = 0;
            int GRNFNo = BLL.ReceiptConfirmationPrintout.GetGRNFNo(ReceiptID);
            if (currentMode == Modes.DeliveryNotePrinting)
            {

                printout.BranchName.Text = GeneralInfo.Current.HospitalName;

                printout.xrGRVLabel.Text = "Delivery Note.";
                printout.xrAir.Visible = false;
                printout.xrAirValue.Visible = false;
                printout.xrTransit.Visible = false;
                printout.xrTransitValue.Visible = false;
                printout.xrInsurance.Visible = false;
                printout.xrInsuranceValue.Visible = false;
                printout.xrNumberOfCases.Visible = false;
                printout.xrNumberOfCasesValue.Visible = false;
                printout.xrInvoiceNo.Visible = false;

                printout.xrInvoiceNoValue.Visible = false;
                printout.xrPurchaseOrderNo.Visible = false;
                printout.xrPurchaseOrderNoValue.Visible = false;


                printout.xrSTV.Visible = false;
                printout.xrSTVNoValue.Visible = false;

                printout.DataSource = rc.PrepareDataForPrintout(ReceiptID, CurrentContext.UserId, false, 5, null, reprintOfReceiptConfirmationPrintoutID,FiscalYear.Current);
                
                CalendarLib.DateTimePickerEx dtDate = new CalendarLib.DateTimePickerEx();
                //dtDate.CustomFormat = "dd/MM/yyyy";
                dtDate.Value = receiveDoc.EurDate;

                printout.Date.Text = dtDate.Text;
            }

            var activity = new Activity();
            activity.LoadByPrimaryKey(receiveDoc.StoreID);
            printout.xrLabelStoreName.Text = activity.FullActivityName;

            if (ReceiveDoc.IsThereShortageOrDamage(ReceiptID))
            {
                HCMIS.Desktop.Reports.ReceiptConfirmationShortagePrintout printoutShortage =
                    PrintReceiptConfirmationForShortage(referenceNumber, printedID);

              
                printout.xrShortageReport.ReportSource = printoutShortage;

                printout.PrintingSystem.ContinuousPageNumbering = true;
            }
            else
            {
               printout.ReportFooter.Visible = false;
            }
            

            //Successfully printed
            
            //Release Product 
            CostCalculator GRV = new CostCalculator();
            GRV.LoadGRV(ReceiptID);
            GRV.ReleaseForIssue();

            String reference = gridReceiveView.GetFocusedDataRow()["RefNo"].ToString();
            BLL.ReceiveDoc recDoc = new ReceiveDoc();
            recDoc.LoadByReferenceNo(reference);
            recDoc.ConfirmGRVPrinted(CurrentContext.UserId);
            BindFormContents();
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
        
        private void btnReprintGRV_Click(object sender, EventArgs e)
        {
            MyGeneration.dOOdads.TransactionMgr transaction = MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgr();
            try
            {
                transaction.BeginTransaction();
                DataRow dr = gridReceiveView.GetFocusedDataRow();
                int? receiptConfirmationPrintoutID = Convert.ToInt32(dr["ID"]);
                PrintConfirmation(receiptConfirmationPrintoutID);
                transaction.CommitTransaction();
            }
            catch (Exception ex)
            {
                transaction.RollbackTransaction();
                XtraMessageBox.Show(ex.Message);
            }
        }

    }
}
