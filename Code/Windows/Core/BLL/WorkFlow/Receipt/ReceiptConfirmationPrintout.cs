
// Generated by MyGeneration Version # (1.3.0.3)

using System;
using DAL;
using System.Data;

namespace BLL
{
    public class ReceiptConfirmationPrintout : _ReceiptConfirmationPrintout
    {
        int _totalNumberOfItemsOnAPage = 5;

        public ReceiptConfirmationPrintout()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="refNo"></param>
        /// <param name="userID"></param>
        /// <param name="shortageAndDamage"></param>
        /// <param name="preGRVOrGRVOrSRM">1-PreGRV, 2-GRV, 3-SRM, 4-iGRV, 5-DeliveryNote</param>
        /// <param name="IDToBePrintedOut">Only applicable for the shortage where we need to show the same ID</param>
        /// <returns></returns>
        public int PrepareDataForPrintout(int ReceiptID, int? userID, bool shortageAndDamage, int preGRVOrGRVOrSRM, int? IDToBePrintedOut, int? isReprintOfRCPrintoutID,FiscalYear fiscalYear)
        {
            string query = "";

           
            if (!shortageAndDamage && preGRVOrGRVOrSRM != 3)
            {
                query =
                    HCMIS.Repository.Queries.ReceiptConfirmationPrintout.SelectPrepareDataForPrintout(ReceiptID, StorageType.Quaranteen);
            }
            else if (preGRVOrGRVOrSRM == 3)//SRM
            {
                BLL.ReceiveDoc rd = new ReceiveDoc();
                rd.LoadAllByReceiptID(ReceiptID);
                if (rd.IsColumnNull("ReturnedFromIssueDocID")) //This is an SRM done for an issue from the old system. (The issue was done using the old system)
                {
                    query = HCMIS.Repository.Queries.ReceiptConfirmationPrintout.SelectPrepareDataForPrintoutIssueDone(ReceiptID);
                }
                else //This is a normal SRM (Both the issue and the receive were done using this system)
                {
                    query = HCMIS.Repository.Queries.ReceiptConfirmationPrintout.SelectPrepareDataForPrintoutIssueAndReceiveDone(ReceiptID);

                }
            }
            else
            {
                //Cost Calculations should be removed from the query below
                query = HCMIS.Repository.Queries.ReceiptConfirmationPrintout.SelectPrepareDataForPrintout(ReceiptID);
            }
            this.LoadFromRawSql(query);

            if (this.RowCount == 0) 
            {
                if (ReceiveDoc.IsThereShortageOrDamage(ReceiptID))
                {
                    query = HCMIS.Repository.Queries.ReceiptConfirmationPrintout.SelectPrepareDataForPrintout(ReceiptID);
                    this.LoadFromRawSql(query);
                }
                if (this.RowCount == 0)
                    throw new Exception("No Data To Print, please receive Document before Trying again");

            }

            this.Rewind();

            this.AddColumn("LineNum", typeof(int));
            this.AddColumn("PrintedGRVNumber", typeof(string));

            BLL.Receipt receipt = new Receipt();
            int receiptID = int.Parse(this.GetColumn("ReceiptID").ToString());
            receipt.LoadByPrimaryKey(receiptID);

            int receiptTypeID = receipt.ReceiptTypeID;
            int printedGRVNumber;
            int lineNum = 1;
            int totalItems = 0;

            BLL.ReceiptConfirmationPrintout rcp = new ReceiptConfirmationPrintout();
            int? supplierID = null;
            if (preGRVOrGRVOrSRM != 3)
                supplierID = this.SupplierID;
            if (IDToBePrintedOut.HasValue)
            {
                printedGRVNumber = IDToBePrintedOut.Value;
            }
            else
            {
               printedGRVNumber = rcp.AddNew(this.StoreID, supplierID, receiptTypeID == 2 ? null : userID, receipt.ID,
                           preGRVOrGRVOrSRM, isReprintOfRCPrintoutID);
            }

            
            if (!IDToBePrintedOut.HasValue) //We want to save a new receipt confirmation printout only when a new ID is generated (Not when an ID to be printed has been passed as a parameter)
            {
                 //For delivery note only, we don't save the saved by user id so that we don't say GRV has been printed.
            }

            while (!this.EOF)
            {
                this.SetColumn("LineNum", lineNum);
                lineNum++;
                this.SetColumn("PrintedGRVNumber", fiscalYear.GetCode(printedGRVNumber));

                totalItems++;
                this.MoveNext();
            }

            return  printedGRVNumber;
        }

        /// <summary>
        /// Gets the next GRV number.
        /// </summary>
        /// <param name="storeID">The store ID.</param>
        /// <param name="receiptTypeID">The receipt type ID.</param>
        /// <param name="preGRVorGRVOrSRM">The pre GR vor GRV or SRM.</param>
        /// <returns></returns>
        
        /// <summary>
        /// Adds the new.
        /// </summary>
        /// <param name="printedConfirmationNumber">The printed confirmation number.</param>
        /// <param name="storeID">The store ID.</param>
        /// <param name="supplierID">The supplier ID.</param>
        /// <param name="userID">The user ID.</param>
        /// <param name="receiptID">The receipt ID.</param>
        /// <param name="grvOrPreGRVorSRM">The GRV or pre GR vor SRM.</param>
        /// <param name="isReprintOfRCNo">The is reprint of RC no.</param>
        private int AddNew(int storeID, int? supplierID, int? userID, int receiptID, int grvOrPreGRVorSRM, int? isReprintOfRCNo)
        {

            //1-PreGRV,2-GRV,3-SRM,4-iGRV,5-DeliveryNote

            AddNew();
            PrintedDate = DateTimeHelper.ServerDateTime;
            StoreID = storeID;

            if (supplierID.HasValue)
                SupplierID = supplierID.Value;
            if (userID.HasValue)
                UserID = userID.Value;
            ReceiptID = receiptID;
            FiscalYearID = FiscalYear.Current.ID;

            Activity activity = new Activity();
            activity.LoadByPrimaryKey(storeID);
            AccountID = activity.AccountID;

            //This has been Added to maintain the grvOrPreGRVorSRM(the variable with a funny name) 
            //Which should be removed soon
            if (grvOrPreGRVorSRM == 1)
            {
                Reason = "PGRV";
                DocumentTypeID = DocumentType.documentTypes.GRNF.DocumentTypeID;
            }
            else if (grvOrPreGRVorSRM == 2)
            {
                Reason = "GRV";
                DocumentTypeID = DocumentType.documentTypes.GRV.DocumentTypeID;
       
            }
            else if (grvOrPreGRVorSRM == 3)
            {
                Reason = "SRM";
                DocumentTypeID = DocumentType.documentTypes.SRM.DocumentTypeID;
       
            }
            else
            {
                Reason = "iGRV";
                DocumentTypeID = DocumentType.documentTypes.IGRV.DocumentTypeID;
       
            }


            if (isReprintOfRCNo.HasValue)
            {
                IsReprintOf = isReprintOfRCNo.Value;
            }
            IDPrinted = DocumentType.GetNextSequenceNo(DocumentTypeID, AccountID, FiscalYearID);
            Save();
            return IDPrinted;
        }

        /// <summary>
        /// Gets the GRNF no.
        /// </summary>
        /// <param name="ReceiptID">The receipt ID.</param>
        /// <returns></returns>
        public static int GetGRNFNo(int ReceiptID)
        {
            BLL.ReceiptConfirmationPrintout rc = new ReceiptConfirmationPrintout();
            var query = HCMIS.Repository.Queries.ReceiptConfirmationPrintout.SelectGetGRNFNo(ReceiptID);
            rc.LoadFromRawSql(query);
            int printedID;
            try
            {
                printedID = int.Parse(rc.GetColumn("IDPrinted").ToString());
            }
            catch
            {
                printedID = 0;
            }
            return printedID;
        }

        /// <summary>
        /// Returns a datatable with the following column layout.
        /// (GRNF,AccountName,ID,PrintedDate)
        /// </summary>
        /// <param name="IDPrinted"></param>
        /// <returns></returns>
        public static DataTable GetListOfGRNFPrinted(int idPrinted)
        {
            var query = HCMIS.Repository.Queries.ReceiptConfirmationPrintout.SelectGetListOfGRNFPrinted(idPrinted);

            var receiptConfirmationPrintout = new ReceiptConfirmationPrintout();
            receiptConfirmationPrintout.LoadFromRawSql(query);
            return receiptConfirmationPrintout.DefaultView.Table;
        }

        /// <summary>
        /// Returns a datatable with the following column layout.
        /// (GRV,AccountName,ID,PrintedDate, IsVoid)
        /// </summary>
        /// <param name="IDPrinted"></param>
        /// <returns></returns>
        public static DataTable GetListOfGRVPrinted(int idPrinted)
        {
            var query = HCMIS.Repository.Queries.ReceiptConfirmationPrintout.SelectGetListOfGRVPrinted(idPrinted);

            var receiptConfirmationPrintout = new ReceiptConfirmationPrintout();
            receiptConfirmationPrintout.LoadFromRawSql(query);
            return receiptConfirmationPrintout.DefaultView.Table;
        }

        /// <summary>
        /// Returns a datatable with the following column layout.
        /// (GRV,AccountName,ID,PrintedDate, IsVoid)
        /// </summary>
        /// <param name="IDPrinted"></param>
        /// <returns></returns>
        public static DataTable GetListOfiGRVPrinted(int idPrinted)
        {
            var query = HCMIS.Repository.Queries.ReceiptConfirmationPrintout.SelectGetListOfiGRVPrinted(idPrinted);

            var receiptConfirmationPrintout = new ReceiptConfirmationPrintout();
            receiptConfirmationPrintout.LoadFromRawSql(query);
            return receiptConfirmationPrintout.DefaultView.Table;
        }

        /// <summary>
        /// Returns a datatable with the following column layout.
        /// (GRV,AccountName,ID,PrintedDate, IsVoid)
        /// </summary>
        /// <param name="IDPrinted"></param>
        /// <returns></returns>
        public static DataTable GetListOfSRMPrinted(int idPrinted)
        {
            var query = HCMIS.Repository.Queries.ReceiptConfirmationPrintout.SelectGetListOfSRMPrinted(idPrinted);

            var receiptConfirmationPrintout = new ReceiptConfirmationPrintout();
            receiptConfirmationPrintout.LoadFromRawSql(query);
            return receiptConfirmationPrintout.DefaultView.Table;
        }

        /// <summary>
        /// Gets the list of iGRV and GRV and detail information about both of them.
        /// </summary>
        public void GetGRVAndiGRVDescriptions(int accountID)
        {
            var query = HCMIS.Repository.Queries.ReceiptConfirmationPrintout.SelectGetGRVAndiGRVDescriptions(accountID);

            this.LoadFromRawSql(query);
        }

        public void GetSRMDescriptions(int accountID)
        {
            var query = HCMIS.Repository.Queries.ReceiptConfirmationPrintout.SelectGetSRMDescriptions(accountID);

            this.LoadFromRawSql(query);
        }


        public void GetGRNFDescriptions(int accountID)
        {
            var query = HCMIS.Repository.Queries.ReceiptConfirmationPrintout.SelectGetGRNFDescriptions(accountID);

            this.LoadFromRawSql(query);
        }

        public DataRow GetReceivePrintoutDetail(int receiptID, string reason)
        {
            var query = HCMIS.Repository.Queries.ReceiptConfirmationPrintout.SelectGetReceivePrintoutDetails(receiptID,
                reason);
            this.LoadFromRawSql(query);
            return this.DataTable.Rows.Count > 0 ? this.DataTable.Rows[0] : null;
        }
    }
}
