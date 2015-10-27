using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
    public class ReceiveService
    {
        public PO CreateFakePO(int orderTypeId,int StoreId,int? SupplierId,string remark, int userID)
        {
             return PO.CreatePOforStandard(orderTypeId, StoreId, SupplierId, remark, userID);
        }

        public ReceiptInvoice CreateFakeInvoice(PO po,int IDPrinted,int userID)
        {
            ReceiptInvoice rctInvoice = new ReceiptInvoice();
            rctInvoice.AddNew();

            //Enter Invoice Related Information
            //We should Save the STV Number Here
            rctInvoice.POID = po.ID;

            rctInvoice.SavedByUserID = userID;
            rctInvoice.ActivityID = po.StoreID;

            rctInvoice.STVOrInvoiceNo = IDPrinted.ToString("00000");
            rctInvoice.ExchangeRate = 1;
            rctInvoice.Insurance = 0;
            rctInvoice.InvoiceTypeID = InvoiceType.Internal;
            rctInvoice.DateOfEntry = DateTimeHelper.ServerDateTime;
            rctInvoice.ActivityID = po.StoreID;
            rctInvoice.SavedByUserID = CurrentContext.LoggedInUser.ID;
            rctInvoice.IsDeliveryNote = false;
            rctInvoice.Rowguid = Guid.NewGuid();
            rctInvoice.PrintedDate = DateTime.Now;
            rctInvoice.IsVoided = false;
            rctInvoice.ShippingSite = " "; 
            rctInvoice.IsConvertedFromDeliveryNote = false;
            rctInvoice.Save();
            return rctInvoice;
        }

        public ReceiptInvoice CreateFakeInvoiceWithPO(int orderTypeId,int StoreId,int? SupplierId,string remark,int IDPrinted,int  userID)
        {
            PO po = CreateFakePO(orderTypeId, StoreId, SupplierId, remark, userID);
            return CreateFakeInvoice(po, IDPrinted,userID);
        }

        public Receipt CreateFakeReceipt(int receiptTypeID, ReceiptInvoice rctInvoice, int userId, int receiptStatusID, int wearehouse =0)
        {
            Receipt receipt = new Receipt();
            receipt.AddNew();
            receipt.DateOfEntry = DateTimeHelper.ServerDateTime;
            receipt.ReceiptTypeID = receiptTypeID;
           
            receipt.ReceiptTypeID = receiptTypeID; 
          
            receipt.SavedByUserID = userId;
            receipt.WarehouseID = wearehouse;

            receipt.ReceiptInvoiceID = rctInvoice.ID;
            receipt.STVOrInvoiceNo = rctInvoice.STVOrInvoiceNo;

            receipt.SavedByUserID = userId;


            if (receipt.IsColumnNull("TransitTransferNo"))
            {
                receipt.TransitTransferNo = rctInvoice.TransitTransferNo;
            }
            receipt.InsurancePolicyNo = rctInvoice.InsurancePolicyNo;
            receipt.WayBillNo = rctInvoice.WayBillNo;
            receipt.ReceiptStatusID = receiptStatusID;
            receipt.Save();
            return receipt;
        }

        public Receipt CreateFakeReceiptWithInvoicePO(int orderTypeId, int storeId, int? supplierId, string remark, int idPrinted, int receiptTypeID, int userid, int receiptStatusID, int wearehouse = 0)
        {
            ReceiptInvoice receiptInvoice = CreateFakeInvoiceWithPO(orderTypeId, storeId, supplierId, remark, idPrinted, userid);
            return CreateFakeReceipt(receiptTypeID, receiptInvoice, userid, receiptStatusID, wearehouse);
        }

        public void CloneReceiveForErrorCorrection(int confirmationStatusID, ReceivePallet receivePallet, ReceiveDoc receiveDoc, decimal pack, User user, int itemId, int storeId, int receiptId, int manufacturerId, ItemUnit itemUnit, DateTime convertedEthDate, bool changeExpiryDate = false, DateTime? ExpiryDate = null, bool changeBatchNo = false, string batchNo = null)
        {
            var newReceiveDoc = receiveDoc.Clone();

            newReceiveDoc.ItemID = itemId;

            if (changeBatchNo)
            {
                newReceiveDoc.BatchNo = batchNo;
            }

            if (changeExpiryDate)
            {
                if (ExpiryDate.HasValue)
                {
                    newReceiveDoc.ExpDate = ExpiryDate.Value;
                }
                else
                {
                    newReceiveDoc.SetColumnNull("ExpDate");
                }
            }

            newReceiveDoc.ManufacturerId = manufacturerId;
            newReceiveDoc.SetColumn("UnitID", itemUnit.ID);
            newReceiveDoc.Quantity = pack * itemUnit.QtyPerUnit;
            newReceiveDoc.QuantityLeft = pack * itemUnit.QtyPerUnit;
            newReceiveDoc.NoOfPack = pack;
            newReceiveDoc.InvoicedNoOfPack = pack;
            newReceiveDoc.QtyPerPack = itemUnit.QtyPerUnit;
            newReceiveDoc.Date = convertedEthDate;
            newReceiveDoc.ReceivedBy = user.UserName;
            newReceiveDoc.StoreID = storeId;
            newReceiveDoc.RefNo = receiptId.ToString();
            newReceiveDoc.EurDate = DateTimeHelper.ServerDateTime;
            newReceiveDoc.Confirmed = true;
            newReceiveDoc.ConfirmedDateTime = DateTimeHelper.ServerDateTime;
            newReceiveDoc.ReturnedStock = false;
            newReceiveDoc.ReceiptID = receiptId;

            newReceiveDoc.Save();

            //Now Save the ReceiveDocConfirmation

            ReceiveDocConfirmation rdConf = new ReceiveDocConfirmation();
            rdConf.AddNew();
            rdConf.ReceiveDocID = newReceiveDoc.ID;
            rdConf.ReceivedByUserID = user.ID;
            rdConf.ReceiptConfirmationStatusID = confirmationStatusID;
            rdConf.Save();

            ReceivePallet newReceivePallet = new ReceivePallet();
            newReceivePallet.AddNew();
            newReceivePallet.ReceiveID = newReceiveDoc.ID;
            newReceivePallet.ReceivedQuantity = pack * itemUnit.QtyPerUnit;
            newReceivePallet.Balance = pack * itemUnit.QtyPerUnit;
            newReceivePallet.ReservedStock = 0;
            newReceivePallet.BoxSize = 0;
            newReceivePallet.PalletID = receivePallet.PalletID;
            newReceivePallet.IsOriginalReceive = true;
            if (!receivePallet.IsColumnNull("PalletLocationID"))
            {
                newReceivePallet.PalletLocationID = receivePallet.PalletLocationID;
            }
            newReceivePallet.Save();
            
        }


        private ReceiveDoc CreateReceiveDocForInventory(Inventory inventory, int confirmationStatusID, decimal foundQty, int receiptID, DateTime convertedEthDate, User user,string remark)
        {
            ReceiveDoc newReceiveDoc = new ReceiveDoc();
            newReceiveDoc.AddNew();

            newReceiveDoc.SetColumn("BatchNo", inventory.GetColumn("BatchNo"));
            newReceiveDoc.ItemID = inventory.ItemID;
            newReceiveDoc.ManufacturerId = inventory.ManufacturerID;
            newReceiveDoc.SetColumn("UnitID", inventory.UnitID);
            if (!inventory.IsColumnNull("SupplierID"))
                newReceiveDoc.SupplierID = inventory.SupplierID;
            BLL.ItemUnit iu = new ItemUnit();
            iu.LoadByPrimaryKey(inventory.UnitID);
            newReceiveDoc.Quantity = newReceiveDoc.QuantityLeft = foundQty*iu.QtyPerUnit;
            newReceiveDoc.NoOfPack = foundQty;
            newReceiveDoc.InvoicedNoOfPack = foundQty;
            newReceiveDoc.QtyPerPack = iu.QtyPerUnit;
            newReceiveDoc.Date = convertedEthDate;
            newReceiveDoc.SetColumn("ExpDate", inventory.GetColumn("ExpiryDate"));
            newReceiveDoc.Out = false;
            newReceiveDoc.ReceivedBy = user.UserName;
            newReceiveDoc.StoreID = inventory.ActivityID;
            newReceiveDoc.SetColumn("LocalBatchNo", inventory.GetColumn("BatchNo"));
            newReceiveDoc.RefNo = receiptID.ToString();
            newReceiveDoc.SetColumn("Cost", inventory.GetColumn("Cost"));
            newReceiveDoc.SetColumn("IsApproved", DBNull.Value);
            newReceiveDoc.EurDate = DateTimeHelper.ServerDateTime;
            newReceiveDoc.SetColumn("SellingPrice", inventory.GetColumn("SellingPrice"));
            newReceiveDoc.SetColumn("UnitCost", inventory.GetColumn("Cost"));
            newReceiveDoc.SetColumn("Cost", inventory.GetColumn("Cost"));
            newReceiveDoc.SetColumn("PricePerPack", inventory.GetColumn("Cost"));
            newReceiveDoc.SetColumn("DeliveryNote", DBNull.Value);
            newReceiveDoc.Confirmed = true;
            newReceiveDoc.ConfirmedDateTime = DateTimeHelper.ServerDateTime;
            newReceiveDoc.ReturnedStock = false;
            newReceiveDoc.ReceiptID = receiptID;
            newReceiveDoc.SetColumn("Margin", inventory.GetColumn("Margin"));
            newReceiveDoc.RefNo = "BeginningBalance";
            if(!string.IsNullOrEmpty(remark))
            newReceiveDoc.IsDamaged = false;
            if (!string.IsNullOrEmpty(remark))
            {
                newReceiveDoc.Remark = remark;
            }
            newReceiveDoc.Save();

            //Now Save the ReceiveDocConfirmation

            ReceiveDocConfirmation rdConf = new ReceiveDocConfirmation();
            rdConf.AddNew();
            rdConf.ReceiveDocID = newReceiveDoc.ID;
            rdConf.ReceivedByUserID = user.ID;
            rdConf.ReceiptConfirmationStatusID = confirmationStatusID;
            rdConf.Save();

            return newReceiveDoc;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inventory"></param>
        /// <param name="palletLocation">Please note that the pallet location passed here is going to be used for the sound qty.  A quarantine location in the physical store that the pallet location exists is chosen for the damaged location.  For now, we're using the same pallet location for the expired quantity as well. (Only if the location type is free)</param>
        /// <param name="confirmationStatusID"></param>
        /// <param name="receipt"></param>
        /// <param name="user"></param>
        /// <param name="convertedEthDate"></param>
        /// <param name="remark"></param>
        internal void CreateReceiveEntriesForInventory(Inventory inventory, PalletLocation palletLocation, int confirmationStatusID, Receipt receipt, User user, DateTime convertedEthDate, string remark)
        {
            //Now Save the receive doc entry
            decimal soundQty = inventory.IsColumnNull("InventorySoundQuantity") ? 0 : inventory.InventorySoundQuantity;
            decimal damagedQty = inventory.IsColumnNull("InventoryDamagedQuantity") ? 0 : inventory.InventoryDamagedQuantity;
            decimal expQty = inventory.IsColumnNull("InventoryExpiredQuantity") ? 0 : inventory.InventoryExpiredQuantity;

            //As per the design of the Inventory object, expired and sound cannot be passed using a single object: Why? There's a data memeber for Expiry Date which can only hold one value.
            decimal soundOrExpiredQty = soundQty + expQty;
            decimal totalFoundQty = soundOrExpiredQty + damagedQty;


            ReceiveDoc newReceiveDoc = CreateReceiveDocForInventory(inventory, confirmationStatusID, totalFoundQty,
                                                                    receipt.ID, convertedEthDate, user, remark);
            
            ReceivePallet newReceivePallet = new ReceivePallet();
            BLL.ItemUnit iu = new ItemUnit();
            iu.LoadByPrimaryKey(inventory.UnitID);


            if (soundOrExpiredQty > 0)
            {
                newReceivePallet.AddNew();
                newReceivePallet.ReceiveID = newReceiveDoc.ID;
                newReceivePallet.ReceivedQuantity = newReceivePallet.Balance = soundOrExpiredQty*iu.QtyPerUnit;
                newReceivePallet.ReservedStock = 0;
                newReceivePallet.PalletID = palletLocation.PalletID;
                newReceivePallet.PalletLocationID = palletLocation.ID;
            }
            
            if(damagedQty>0)
            {
                newReceivePallet.AddNew();
                newReceivePallet.ReceiveID = newReceiveDoc.ID;
                newReceivePallet.ReceivedQuantity = newReceivePallet.Balance = damagedQty*iu.QtyPerUnit;
                newReceivePallet.ReservedStock = 0;
                
                if(palletLocation.StorageTypeID==Convert.ToInt32(BLL.StorageType.Quaranteen)) //Was the original pallet stored in a quarantine location?
                {
                    newReceivePallet.PalletID = palletLocation.PalletID;
                    newReceivePallet.PalletLocationID = palletLocation.ID;
                }
                else //The original pallet was not marked as a quarantine or suspension location.  Meaning we need to choose a quarantine location in the same physical store as the original pallet location.
                {
                    BLL.PalletLocation plQuarantine = new PalletLocation();
                    plQuarantine.LoadFirstOrDefault(palletLocation.PhysicalStoreID,
                                                    Convert.ToInt32((StorageType.Quaranteen)));
                    if(plQuarantine.RowCount>0) //There is already quarantine location. 
                    {
                        //Pick the first quarantine location.
                        if(plQuarantine.IsColumnNull("PalletID"))
                        {
                            //TODO: Create a Pallet.
                        }

                        newReceivePallet.PalletID = plQuarantine.PalletID;
                        newReceivePallet.PalletLocationID = plQuarantine.ID;
                    }
                    else 
                    {
                        //There is no quarantine locaiton in the physical store: This is basically bad news.  We let them know that this is unacceptable.
                        throw new Exception("Please create a quarantine storage location for this store");
                    }
                }
            }
            newReceivePallet.IsOriginalReceive = true;
            newReceivePallet.Save();
        }
        
        public ReceiveDoc CreateInventoryReceive(Inventory inventory,int receiptID,Inventory.QuantityType quantityType,DateTime ethiopianDate,User user)
        {
            ItemUnit itemUnit = new ItemUnit();
            itemUnit.LoadByPrimaryKey(inventory.UnitID);

            ReceiveDoc receiveDoc = new ReceiveDoc();
            receiveDoc.AddNew();
            receiveDoc.ItemID = inventory.ItemID;
            receiveDoc.UnitID = inventory.UnitID;
            receiveDoc.ManufacturerId = inventory.ManufacturerID;
           
            receiveDoc.StoreID = inventory.ActivityID;
            receiveDoc.Date = ethiopianDate;
            receiveDoc.EurDate = DateTimeHelper.ServerDateTime;
            receiveDoc.PhysicalStoreID = inventory.PhysicalStoreID;
            receiveDoc.SetColumn("BatchNo", inventory.GetColumn("BatchNo"));
            decimal quantity = quantityType == Inventory.QuantityType.Sound
                                   ? inventory.InventorySoundQuantity
                                   : quantityType == Inventory.QuantityType.Damaged
                                    ? inventory.InventoryDamagedQuantity :inventory.InventoryExpiredQuantity;

            if(quantityType == Inventory.QuantityType.Damaged) receiveDoc.ShortageReasonID = ShortageReasons.Constants.DAMAGED;
            receiveDoc.Quantity = receiveDoc.QuantityLeft = quantity * itemUnit.QtyPerUnit;
            receiveDoc.NoOfPack = receiveDoc.InvoicedNoOfPack = quantity;
            receiveDoc.QtyPerPack = itemUnit.QtyPerUnit;
            receiveDoc.SetColumn("ExpDate", inventory.GetColumn("ExpiryDate"));

            receiveDoc.Out = false;

            receiveDoc.ReceivedBy = user.UserName;

            receiveDoc.StoreID = inventory.ActivityID;
            receiveDoc.RefNo = "BeginningBalance";
            decimal cost = 0;
            decimal margin = 0;

            if (!inventory.IsColumnNull("Cost"))
            {
                cost = inventory.Cost;
            }
            
            if(!inventory.IsColumnNull("Margin"))
            {
                margin = inventory.Margin;
            }

            receiveDoc.Cost = Convert.ToDouble(cost);
            receiveDoc.PricePerPack = Convert.ToDouble(cost);
            receiveDoc.UnitCost = cost;
            receiveDoc.Margin = Convert.ToDouble(margin);
            receiveDoc.SellingPrice = Convert.ToDouble(BLL.Settings.IsCenter ? cost : cost * (1 + margin));
            receiveDoc.SupplierID = 2; //TODO: HARDCODE WARNING WARNING WARNING
            receiveDoc.DeliveryNote = false;
            receiveDoc.Confirmed = true;
            receiveDoc.ConfirmedDateTime = DateTimeHelper.ServerDateTime;
            receiveDoc.ReturnedStock = false;
            receiveDoc.ReceiptID = receiptID;
            receiveDoc.RefNo = "BeginningBalance";
            receiveDoc.InventoryPeriodID = inventory.InventoryPeriodID;
            receiveDoc.IsDamaged = (quantityType == Inventory.QuantityType.Damaged ||
                                   quantityType == Inventory.QuantityType.Expired);
            receiveDoc.Save();

            //Now Save the ReceiveDocConfirmation

            ReceiveDocConfirmation rdConf = new ReceiveDocConfirmation();
            rdConf.AddNew();
            rdConf.ReceiveDocID = receiveDoc.ID;
            rdConf.ReceivedByUserID = user.ID;
            rdConf.ReceiptConfirmationStatusID = ReceiptConfirmationStatus.Constants.RECEIVE_QUANTITY_CONFIRMED;
            rdConf.Save();
            
            //TODO: Create Receive Pallet Here
            PalletLocation palletLocation = new PalletLocation();

            palletLocation.LoadByPrimaryKey(quantityType != Inventory.QuantityType.Damaged
                                                ? inventory.PalletLocationID
                                                : inventory.DamagedPalletLocationID);

           
            ReceivePallet receivePallet = new ReceivePallet();
            receivePallet.AddNew();
            receivePallet.Balance = quantity * itemUnit.QtyPerUnit;
            receivePallet.ReceivedQuantity = quantity * itemUnit.QtyPerUnit;
            receivePallet.ReservedStock = 0;
            receivePallet.ReceiveID = receiveDoc.ID; 
            
            if(palletLocation.IsColumnNull("PalletID"))
            {
                Pallet pallet = new Pallet();
                pallet.AddNew();
                pallet.Save();
                palletLocation.PalletID = pallet.ID;
                palletLocation.Save();
            }

            receivePallet.PalletID = palletLocation.PalletID;
            receivePallet.PalletLocationID =palletLocation.ID;
            receivePallet.BoxSize = 0;
            receivePallet.IsOriginalReceive = true;
            receivePallet.Save();
            
            return receiveDoc;
        }
    }
}
