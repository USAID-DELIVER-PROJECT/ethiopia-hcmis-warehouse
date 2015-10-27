using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL.Services
{
    public class IssueService
    {
        public IssueDoc CreateIssueFromPicklist(PickListDetail picklistDetail,Order order,DateTime convertedEthDate,Issue stvLog,User user)
        {
            ReceivePallet receivePallet = new ReceivePallet();
            receivePallet.LoadByPrimaryKey(picklistDetail.ReceivePalletID);

            ReceiveDoc receiveDoc = new ReceiveDoc();
            receiveDoc.LoadByPrimaryKey(receivePallet.ReceiveID);
            
            IssueDoc issueDoc = new IssueDoc();
            issueDoc.AddNew();
            issueDoc.BatchNo = picklistDetail.BatchNumber;
            if(!picklistDetail.IsColumnNull("Cost"))
            issueDoc.Cost = picklistDetail.Cost;
            issueDoc.Date = convertedEthDate;
            issueDoc.EurDate = DateTimeHelper.ServerDateTime;
            issueDoc.StoreId = picklistDetail.StoreID;
            issueDoc.STVID = stvLog.ID;
            issueDoc.IsTransfer = true;
            issueDoc.IssuedBy = user.FullName;
            issueDoc.ItemID = picklistDetail.ItemID;
            issueDoc.NoOfPack = picklistDetail.Packs;
            issueDoc.QtyPerPack = picklistDetail.QtyPerPack;
            issueDoc.Quantity = picklistDetail.QuantityInBU;
            issueDoc.OrderID = order.ID;
            issueDoc.UnitID = receiveDoc.UnitID;
            issueDoc.ManufacturerID = receiveDoc.ManufacturerId;
            issueDoc.SetColumn("UnitCost" ,receiveDoc.GetColumn("Cost"));
            issueDoc.SetColumn("SellingPrice"  ,receiveDoc.GetColumn("SellingPrice"));
            issueDoc.SetColumn("Margin", receiveDoc.GetColumn("Margin"));
            issueDoc.SetColumn("PhysicalStoreID", receiveDoc.GetColumn("PhysicalStoreID"));
            issueDoc.PLDetailID = picklistDetail.ID;
            issueDoc.RecievDocID = picklistDetail.ReceiveDocID;
            issueDoc.SetColumn("InventoryPeriodID", receiveDoc.GetColumn("InventoryPeriodID"));
            // This is a deprecated field
            issueDoc.RecomendedQty = 0;// picklistDetail.Packs;
            issueDoc.RefNo = stvLog.IDPrinted.ToString();
            issueDoc.DispatchConfirmed = false;
            issueDoc.Save();

            

            //substract from QuantityLeft
            receiveDoc.QuantityLeft -= picklistDetail.QuantityInBU;
            if(receiveDoc.QuantityLeft < 0)
            {
                receiveDoc.QuantityLeft = 0;
            }
            receiveDoc.Save();
            
            receivePallet.Balance -= picklistDetail.QuantityInBU;
            if(receivePallet.Balance < 0)
            {
                receivePallet.Balance=0;
            }

            receivePallet.ReservedStock -= picklistDetail.Packs;
            if(receivePallet.ReservedStock < 0)
            {
                receivePallet.ReservedStock = 0;
            }
            receivePallet.Save();

            return issueDoc;
        }

        public Issue CreateSTVLog(int? stvLogID, bool convertDNtoSTV, PickList pickList, Order order, int? supplierId, int activityId, bool hasInsurance, int userId)
        {
            int paymentTypeID = order.PaymentTypeID;
            Issue stvLog = new Issue();
            stvLog.AddNew();
            stvLog.PrintedDate = DateTimeHelper.ServerDateTime;
            stvLog.RefNo = order.RefNo;
            stvLog.PickListID = pickList.ID;
            if(supplierId != null)
            {
                stvLog.SupplierID = supplierId.Value;
            }
            stvLog.UserID = userId;
            stvLog.StoreID = activityId;
             stvLog.IsDeliveryNote = (paymentTypeID == PaymentType.Constants.DELIVERY_NOTE);
            stvLog.HasInsurance = hasInsurance;
            stvLog.FiscalYearID = FiscalYear.Current.ID;
            
            var activity = new Activity();
            activity.LoadByPrimaryKey(activityId);
            stvLog.AccountID = activity.AccountID;

            if (paymentTypeID == PaymentType.Constants.DELIVERY_NOTE)
            {
                stvLog.DocumentTypeID = DocumentType.documentTypes.DeliveryNote.DocumentTypeID;
            }
            else if (paymentTypeID == PaymentType.Constants.CASH)
            {
                stvLog.DocumentTypeID = DocumentType.documentTypes.Cash.DocumentTypeID;
            }
            else if (paymentTypeID == PaymentType.Constants.CREDIT)
            {
                stvLog.DocumentTypeID = DocumentType.documentTypes.Credit.DocumentTypeID;
            }
            else if (paymentTypeID == PaymentType.Constants.STV)
            {
                stvLog.DocumentTypeID = DocumentType.documentTypes.STV.DocumentTypeID;
            }
            else if(paymentTypeID == PaymentType.Constants.ERROR_CORRECTION)
            {
                stvLog.DocumentTypeID = DocumentType.documentTypes.ErrorCorrection.DocumentTypeID;
            }
            else if(paymentTypeID == PaymentType.Constants.INVENTORY)
            {
                stvLog.DocumentTypeID = DocumentType.documentTypes.EndingBalance.DocumentTypeID;
            }
            else if (paymentTypeID == PaymentType.Constants.DISPOSAL) // This should probably have a disposal document type, but for now, STV
            {
                stvLog.DocumentTypeID = DocumentType.documentTypes.STV.DocumentTypeID;
            }
            stvLog.IDPrinted = DocumentType.GetNextSequenceNo(stvLog.DocumentTypeID, stvLog.AccountID, stvLog.FiscalYearID);
                        
            if (!order.IsColumnNull("RequestedBy"))
            {
                stvLog.ReceivingUnitID = order.RequestedBy;
            }
            if (stvLogID.HasValue)
            {
                stvLog.IsReprintOf = stvLogID.Value;
                //this means the STV is from replaced
                Issue s = new Issue();
                s.LoadByPrimaryKey(stvLogID.Value);
             
                stvLog.IsDeliveryNote = false;
                if (!s.IsColumnNull("IsDeliveryNote") && s.IsDeliveryNote && !convertDNtoSTV)
                {
                    stvLog.IsDeliveryNote = true;
                }
            }
            stvLog.Save();
            return stvLog;
        }

       }
}
