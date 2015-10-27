using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BLL.WorkFlow.Activities;
using HCMIS.Security.Models;

namespace BLL.Services
{
    public class TransferService
    {

        public void CreateDetailTransactionsForErrorCorrection(Order order, BLL.PickList picklist,
                                        Issue stvLog, int receiptPalletId, int receiptID, User user, DateTime convertedEthDate
                                        , int newItemId, int newUnitId, int newManufacturerId, decimal pickedPack
                                        , decimal Convertedpack, int confirmationStatusId, bool changeExpiryDate
                                        , DateTime? ExpiryDate, bool changeBatchNo, string batchNo)
        {
            //Load the ReceivePallet First From that we Get the Information that We need
            ReceivePallet receivePalletOriginal = new ReceivePallet();
            receivePalletOriginal.LoadByPrimaryKey(receiptPalletId);

            ReceiveDoc receiveDocOriginal = new ReceiveDoc();
            receiveDocOriginal.LoadByPrimaryKey(receivePalletOriginal.ReceiveID);

            //Load ItemUnit Detail for For ItemUnit Change;
            ItemUnit newItemUnit = new ItemUnit();
            newItemUnit.LoadByPrimaryKey(newUnitId);

          // Generate PicklistDetail With OrderDetail information
            PickListService pickListService = new PickListService();
            PickListDetail pickListDetail = pickListService.CreatePicklistDetailWithOrder(receiveDocOriginal, receivePalletOriginal, order, picklist,
                                                          pickedPack);
            // Generate IssueDoc from picklistDetail and substract the quantity from receiveDoc
            IssueService issueService = new IssueService();
            issueService.CreateIssueFromPicklist(pickListDetail, order, convertedEthDate, stvLog, user);

            if (Convertedpack > 0)
            {
                //duplicate The ReceiveDoc and ReceiptPallet
                ReceiveService receiveService = new ReceiveService();
                receiveService.CloneReceiveForErrorCorrection(confirmationStatusId, receivePalletOriginal, receiveDocOriginal
                                                                , Convertedpack, user, newItemId
                                                                , receiveDocOriginal.StoreID, receiptID
                                                                , newManufacturerId, newItemUnit, convertedEthDate,changeExpiryDate,ExpiryDate,changeBatchNo,batchNo);
            }
        }

        public int CreateTransactionForErrorCorrection(DataView dataView, int newItemId, int newUnitId, int newManufacturerId, decimal ConversionFactor, string Remark, DateTime convertedEthDate, int userId, bool changeExpiryDate = false, DateTime? ExpiryDate = null, bool changeBatchNo = false, string batchNo = null)
        {
            //Last Validation
            if (dataView.Count == 0)
            {
                throw new Exception("DataView is empty, the Error correction cannot be commited");
            }
            //User Information
            User user = new User();
            user.LoadByPrimaryKey(userId);

            var stvLog = new Issue();
            Order order;
            PickList picklist;

            //The First ReceiveDoc entry on the It Holds enough Informa
            var firstReceiveDoc = new ReceiveDoc();
            firstReceiveDoc.LoadByPrimaryKey(Convert.ToInt32(dataView[0]["ReceiveDocID"]));
            int activityId = firstReceiveDoc.StoreID;

            stvLog = HandleTransferBeforeReceipt(user,activityId, out order, out picklist);

            var listOfWarehouse = new List<int>();
            foreach (DataRow rw in dataView.Table.Rows)
            {
                if (!listOfWarehouse.Contains(Convert.ToInt32(rw["WearehouseID"])))
                {
                    listOfWarehouse.Add(Convert.ToInt32(rw["WearehouseID"]));
                }
            }
            
            foreach (var wearehouse in listOfWarehouse)
            {
                dataView.RowFilter = String.Format("WearehouseID = {0}", wearehouse);
                DataView singleWearehouseDataView = dataView;
                HandleTransferForSingleWearehouse(wearehouse,singleWearehouseDataView, newItemId, newUnitId, newManufacturerId, ConversionFactor, Remark, convertedEthDate, user, changeExpiryDate, ExpiryDate, changeBatchNo, batchNo,activityId,stvLog,order,picklist);
                dataView.RowFilter = string.Empty;
            }
           
            return stvLog.IDPrinted;

        }

        private void HandleTransferForSingleWearehouse(int wearehouse, DataView dataView, int newItemId, int newUnitId, int newManufacturerId,
                                                        decimal ConversionFactor, string Remark, DateTime convertedEthDate,
                                                        User user, bool changeExpiryDate, DateTime? ExpiryDate,
                                                        bool changeBatchNo, string batchNo, int activityId, Issue stvLog, Order order, PickList picklist)
        {

           int  receiptTypeID = ReceiptType.CONSTANTS.ERROR_CORRECTION;

            ReceiveService receiveService = new ReceiveService();
            
            Receipt receipt = receiveService.CreateFakeReceiptWithInvoicePO(order.OrderTypeID, activityId,GeneralInfo.Current.SupplierID,
                                                                            Remark,
                                                                            stvLog.IDPrinted,
                                                                            receiptTypeID,
                                                                            user.ID, BLL.Settings.IsVaccine ? ReceiptConfirmationStatus.Constants.GRV_PRINTED : ReceiptConfirmationStatus.Constants.GRNF_PRINTED, wearehouse);

            //Loop throw the Dataview and Create Detail Transaction
            foreach (DataRowView dataRowView in dataView)
            {
                int receivePalletID = Convert.ToInt32(dataRowView["receivePalletId"]);
                decimal pack = Convert.ToDecimal(dataRowView["PickedQty"]);
                decimal convertedPack = Convert.ToDecimal(pack*Convert.ToDecimal(ConversionFactor));

                if (pack != 0)
                {
                    CreateDetailTransactionsForErrorCorrection(order, picklist, stvLog, receivePalletID, receipt.ID,
                                                               user, convertedEthDate, newItemId, newUnitId,
                                                               newManufacturerId, pack, convertedPack,
                                                               ReceiptConfirmationStatus.Constants.GRNF_PRINTED,
                                                               changeExpiryDate, ExpiryDate, changeBatchNo, batchNo);
                }
            }

            ErrorCorrection.Log(stvLog, receipt, ConversionFactor); 
        }

        private Issue HandleTransferBeforeReceipt(User user, int activityId,out Order order,out PickList picklist)
        {
            int orderType = OrderType.CONSTANTS.ERROR_CORRECTION_TRANSFER;
            int paymentType = PaymentType.Constants.ERROR_CORRECTION;
            int orderStatus = OrderStatus.Constant.ISSUED;


            order = Order.GenerateOrder(null, orderType,
                                        orderStatus, activityId,
                                        paymentType, user.FullName,GeneralInfo.Current.InstitutionID, user.ID, 0);


            picklist = PickList.GeneratePickList(order.ID);

            var issueService = new IssueService();
            return issueService.CreateSTVLog(null, false, picklist, order, null, activityId, false, user.ID);
        }

        public PickListDetail GeneratePickListDetail(ReceiveDoc rd, ReceivePallet rp, Order o, PickList pl)
        {
            PickListService pickListService = new PickListService ();
            return pickListService.CreatePicklistDetailWithOrder(rd, rp, o, pl);
        }
    }
}
