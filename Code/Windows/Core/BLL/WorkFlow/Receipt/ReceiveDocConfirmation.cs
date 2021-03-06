
// Generated by MyGeneration Version # (1.3.0.3)

using System;
using DAL;
using System.Data;

namespace BLL
{
    public class ReceiveDocConfirmation : _ReceiveDocConfirmation
    {
       
        /// <summary>
        /// Loads the by receive doc ID.
        /// </summary>
        /// <param name="receiveID">The receive ID.</param>
  
        public void LoadByReceiveDocID(int receiveID)
        {
            this.FlushData();
            this.Where.ReceiveDocID.Value = receiveID;
            this.Query.Load();
        }

        public DataTable GetUserNamebyReceipt(int ReceiptID)
        {
            ReceiveDocConfirmation rdc = new ReceiveDocConfirmation();
            var query = HCMIS.Repository.Queries.ReceiveDocConfirmation.SelectGetUserNamebyReceipt(ReceiptID);
            rdc.LoadFromRawSql(query);
            return rdc.DataTable;
        }

        internal void SetStatusItemReceived(int receiveID, int? userID)
        {
            LoadByReceiveDocID(receiveID);
            if (RowCount == 0)
            {
                AddNew();
                ReceiveDocID = receiveID;
            }
            if (userID.HasValue)
            {
                ReceivedByUserID = userID.Value;
            }

            ReceiptConfirmationStatusID = ReceiptConfirmationStatus.Constants.RECEIVE_ENTERED;
            Save();
        }

        internal void SetStatusConfirmQuantityAndLocation(int receiveID, int? userID)
        {
            LoadByReceiveDocID(receiveID);
            BLL.ReceiveDoc rcDoc=new ReceiveDoc();
            BLL.Receipt rct = new Receipt();
            rcDoc.LoadByPrimaryKey(receiveID);
            rct.LoadByPrimaryKey(rcDoc.ReceiptID);
            if (RowCount == 0)
            {
                AddNew();
                ReceiveDocID = receiveID;
            }

            if(userID.HasValue)
            {
                
               ReceiptQuantityConfirmedByUserID = userID.Value;
            }

                ReceiptConfirmationStatusID = rct.ReceiptTypeID == BLL.ReceiptType.CONSTANTS.BEGINNING_BALANCE?
                                                 ReceiptConfirmationStatus.Constants.GRV_PRINTED:
                                                    ReceiptConfirmationStatus.Constants.RECEIVE_QUANTITY_CONFIRMED;
            
            Save();
        }

        internal void SetStatusPrintGRNF(int receiveID, int? userID)
        {
            LoadByReceiveDocID(receiveID);
            if (RowCount == 0)
            {
                AddNew();
                ReceiveDocID = receiveID;
            }
            if(userID.HasValue)
            {
                SetColumn("GRNFPrintedByUserID", userID.Value);
            }
            ReceiptConfirmationStatusID = ReceiptConfirmationStatus.Constants.GRNF_PRINTED;
            Save();
        }

        internal void SetStatusSetPrice(int receiveID, int? userID)
        {
            LoadByReceiveDocID(receiveID);
            if (RowCount == 0)
            {
                AddNew();
                ReceiveDocID = receiveID;
            }

            if (userID.HasValue)
            {
                PriceAssignedByUserID = userID.Value;
            }
            
            ReceiptConfirmationStatusID = ReceiptConfirmationStatus.Constants.PRICE_CALCULATED;
            this.Save();
        }
     
        internal void SetStatusConfirmPrice(int receiveID, int? userID)
        {
            LoadByReceiveDocID(receiveID);
            if (RowCount == 0)
            {
                AddNew();
                ReceiveDocID = receiveID;
            }
            if(userID.HasValue)
            {
                UnitCostCalculatedByUserID = userID.Value;
            }
            ReceiptConfirmationStatusID = ReceiptConfirmationStatus.Constants.PRICE_CONFIRMED;
            Save();
        }

        internal void SetStatusPrintGRV(int receiveID, int? userID)
        {
            LoadByReceiveDocID(receiveID);
            if (RowCount == 0)
            {
                AddNew();
                ReceiveDocID = receiveID;
            }
            if(userID.HasValue)
            {

                GRVPrintedByUserID = userID.Value;
            }
            
            ReceiptConfirmationStatusID = ReceiptConfirmationStatus.Constants.GRV_PRINTED;
            Save();
        }

        internal void SetStatusDeleted(int receiveID, int userID)
        {
            LoadByReceiveDocID(receiveID);
            if (this.RowCount == 0)
            {
                return;
            }
            this.MarkAsDeleted();
            this.Save();
        }

        internal void SetStatusItemDraft(int receiveID, int userID)
        {
            LoadByReceiveDocID(receiveID);
            if (RowCount == 0)
            {
                AddNew();
                ReceiveDocID = receiveID;
            }

            ReceiptConfirmationStatusID = ReceiptConfirmationStatus.Constants.DRAFT_RECEIPT;
            Save();
        }

        public void ChangeStatusByAccountReceiveDocs(string receiveDocs,int StatusID,int? PreviousStatusID = null)
        {
            if (receiveDocs!= "")
            {
                ReceiveDocConfirmation receiveDocConfirmation = new ReceiveDocConfirmation();

                var query = HCMIS.Repository.Queries.ReceiveDocConfirmation.UpdateChangeStatusByAccountReceiveDocs(receiveDocs, StatusID, PreviousStatusID);
       

                     receiveDocConfirmation.LoadFromRawSql(query);
                    }
        }
    }
}