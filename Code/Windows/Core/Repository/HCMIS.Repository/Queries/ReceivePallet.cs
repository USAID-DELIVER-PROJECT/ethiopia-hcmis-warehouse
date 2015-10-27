using HCMIS.Repository.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Repository.Queries
{
    public class ReceivePallet
    {
        public static string SelectLoadMisplacedItems(int storeID)
        {
            string query = String.Format("Select *,rp.ReceivedQuantity/rd.QtyPerPack ReceivedQtyPack,rp.Balance/rd.QtyPerPack BalanceQtyPack, iu.[Text] UnitText from receivepallet rp join receivedoc rd on rp.ReceiveID=rd.ID join ItemUnit iu on rd.UnitID=iu.ID join vwGetAllItems i on rd.ItemID=i.ID  where rp.Balance>0 and rp.ID not in (Select rp.ID from receivepallet rp join palletlocation pl on rp.PalletID=pl.PalletID) and rd.StoreID = {0}", storeID);
            return query;
        }

        public static string SelectLoadByItemID(int itemID)
        {
            string query = String.Format("Select * from ReceivePallet where ReceiveID in (select ID from ReceiveDoc where ItemID={0})", itemID);
            return query;
        }

        public static string SelectLoadAllItemsReadyToDispatch(int itemID, int? unitID, int fromStore, bool doNotIssueNearExpiryItems)
        {
            string nearExpiryFilter = "";
            if (doNotIssueNearExpiryItems)
            {
                nearExpiryFilter =
                    String.Format(" and  (ExpDate is null or  ExpDate not between GETDATE() and DATEADD(day,v.NearExpiryTrigger,GETDATE()))");
            }

            string query = String.Format(
                "select * from vwItemsReadyForDispatch where ItemID = {0} and Confirmed=1 and StoreID = {1} {2} {3} order by ExpDate",
                itemID, fromStore, (unitID != null) ? String.Format(" and UnitID = {0}", unitID) : "",
                nearExpiryFilter);
            return query;
        }

        [SelectQuery]
        public static string LoadNonPickFaceAllItemsReadyToDispatch(int userID, int itemID, int? unitID, int fromStore, int preferredManufacturerID, int preferredPhysicalStoreID, DateTime? preferredExpiryDate, string storageTypePickFace, bool deliveryNote, bool issueUnpricedCommodity, bool doNotIssueNearlyExpired,bool isCenter = false)
        {
            string manufacturerFilter = preferredManufacturerID == -1 ? "" : String.Format(" and ManufacturerId = {0}", preferredManufacturerID);
            string physicalStoreFilter = preferredPhysicalStoreID == -1 ? "" : String.Format(" and ShelfID in (Select ID from Shelf Where StoreID={0})", preferredPhysicalStoreID);
            string expiryDateFilter = !preferredExpiryDate.HasValue
                                          ? ""
                                          : String.Format(" and cast(ExpDate as date) = cast('{0}' as date)",
                                                          preferredExpiryDate);
            string deliveryNoteFilter = "";
            if (deliveryNote && issueUnpricedCommodity)
            {
                //~ Note: SellingPrice May or May not be Null for Center case but still can be DeliveryNote, As long as the receive is not on GRV status ~//
                deliveryNoteFilter = isCenter
                    ? " AND rdc.ReceiptConfirmationStatusID IN (SELECT ID FROM ReceiptConfirmationStatus WHERE ReceiptConfirmationStatusCode IN ('GRNFP', 'UCC','PRC','PRCO')) "
                    : " AND DeliveryNote = 1 AND rdc.ReceiptConfirmationStatusID IN (SELECT ID FROM ReceiptConfirmationStatus WHERE ReceiptConfirmationStatusCode IN ('GRNFP', 'UCC','PRC','PRCO')) ";
            }
            else if (deliveryNote)
            {
                deliveryNoteFilter = " and DeliveryNote = 1 ";
            }
            else
            {
                // Note on center: There wont be any case like: issueUnpricedCommodity = true && deliveryNote = false(For a receive > GRNF): As we are handling it on vwDispatchableItem(DeliveryNote is true for all center issues with issueUnpricedCommodity=1 and ReceiptConfirmationStatus is between: [GRNF -> GRV) not inclusive) //
                deliveryNoteFilter = " and DeliveryNote = 0 AND rdc.ReceiptConfirmationStatusID IN (SELECT ID FROM ReceiptConfirmationStatus WHERE ReceiptConfirmationStatusCode = 'GRVP' )  ";
            }
            string nearExpiryFilter = "";
            if (doNotIssueNearlyExpired)
            {
                nearExpiryFilter =
                    String.Format(" and  (ExpDate is null or  ExpDate not between GETDATE() and DATEADD(day,vw.NearExpiryTrigger, GETDATE()))");
            }

            string query = String.Format(
                @"select *, (UsedVolume / case when AvailableVolume > 0 then AvailableVolume else 1 end) as Utilized,
                                    (select  SUM(rp.Balance) - SUM(rp.ReservedStock) from ReceivePallet rp where rp.PalletID = vw.PalletID) TotalOnPallet 
                                                from vwItemsReadyForDispatch vw join vwPallet p on vw.PalletLocationID = p.PalletLocationID and p.PhyicalStoreID in (select PhysicalStoreID from UserPhysicalStore where UserID = {9} and CanAccess = 1)
                                                 join ReceiveDocConfirmation rdc on vw.ReceiveDocID = rdc.ReceivedocID         
                                               where (ExpDate > GETDATE() or ExpDate is null)  and vw.ItemID = {0} and vw.StoreID = {1}  and vw.StorageTypeID <> {2} and vw.UnitID = {3} {4} {5} {6} {7} {8} order by ExpDate ASC, TotalOnPallet ASC, (vw.Balance - vw.ReservedStock) ASC, [Row] ASC",
                itemID, fromStore, storageTypePickFace, unitID, manufacturerFilter, deliveryNoteFilter,
                physicalStoreFilter, expiryDateFilter, nearExpiryFilter, userID);
            return query;
        }

        public static string SelectLoadPickFaceAllItemsReadyToDispatch(int itemID, int fromStore, string StorageTypePickFace)
        {
            string query = String.Format("select * from vwItemsReadyForDispatch where Confirmed=1 and ItemID = {0} and StoreID = {1} and StorageTypeID = {2}  and (ExpDate>GETDATE() or ExpDate is null)  order by ExpDate", itemID, fromStore, StorageTypePickFace);
            return query;
        }
        public static string SelectLoadPickFaceAllItemsReadyToDispatchElse(int itemID, int? unitID, int fromStore, string StorageTypePickFace)
        {
            string query = String.Format("select * from vwItemsReadyForDispatch where Confirmed=1 and ItemID = {0} and StoreID = {1} and StorageTypeID = {2} and SellingPrice is not null  and (ExpDate>GETDATE() or ExpDate is null)  and SellingPrice <> 0 {3} order by ExpDate", itemID, fromStore, StorageTypePickFace, (unitID != null) ? String.Format(" and UnitID = {0}", unitID) : "");
            return query;
        }

        public static string SelectGetBalanceByPalletID(int palletID)
        {
            string query = String.Format("select sum(Balance) as Balance from ReceivePallet where PalletID = {0}", palletID);
            return query;
        }

        public static string UpdateConsolidate(int sourcePalletID, int destinationPalletID)
        {
            string query = String.Format("update ReceivePallet set PalletID = {1} where PalletID = {0} and Balance > 0", sourcePalletID, destinationPalletID);
            return query;
        }

        public static string SelectLoadNonZeroRPByReceiveID(int recID)
        {
            string query = String.Format("select * from ReceivePallet where ReceiveID = {0} and PalletID in (Select PalletID from PalletLocation)", recID);
            return query;
        }

        public static string SelectLoadNonZeroRPByItemExpiry(int itemID, DateTime expDate)
        {
            string query = String.Format("select rp.* from ReceivePallet rp join ReceiveDoc rd on rp.ReceiveID = rd.ID where rd.ItemID = {0} and ExpDate = '{1}' and PalletID in (Select PalletID from PalletLocation)", itemID, expDate.ToShortDateString());
            return query;
        }

        public static string SelectGetPalletLocationReadyForMovement(int palletID)
        {
            string query = String.Format("select rp.ID, vw.FullItemName, rd.ItemID, rd.ExpDate, rd.BatchNo, rd.QtyPerPack , rp.Balance / rd.QtyPerPack as Balance, BalanceToMove = 0 from ReceivePallet rp join ReceiveDoc rd on rp.ReceiveID = rd.ID  join vwGetAllItems vw on rd.ItemID=vw.ID where rp.Balance > 0 and rp.PalletID = {0}", palletID);
            return query;
        }

        public static string UpdateFixReservedStockProblems()
        {
            string query = String.Format(
                @"update rp set rp.ReservedStock = cReservation.CorrectReserved from	
                                        ReceivePallet rp join
                                        (select Sum(plds.QuantityInBU) CorrectReserved, ReceivePalletID from (select pl.* from PickListDetail pl join PickList p on p.ID = pl.PickListID join [Order] o on o.ID = p.OrderID join OrderStatus os on os.ID = o.OrderStatusID where os.OrderStatusCode in ('PIKL','PLCN','ISUD','CNCL','DSCN') and os.OrderStatusCode in ('DRFT','ORFI','APRD','PIKL','PLCN')) plds group by ReceivePalletID) cReservation
                                        on rp.ID = cReservation.ReceivePalletID 
                                        where rp.ReservedStock <> cReservation.CorrectReserved and rp.Balance >= cReservation.CorrectReserved");
            return query;
        }

        public static string UpdateFixReservedStockProblemsMakeReservationSameAsBalance()
        {
            string query = String.Format(
                @"update rp set rp.ReservedStock = rp.Balance from	(select Sum(plds.QuantityInBU) CorrectReserved, ReceivePalletID from (select pl.* from PickListDetail pl join PickList p on p.ID = pl.PickListID join [Order] o on o.ID = p.OrderID join OrderStatus os on os.ID = o.OrderStatusID where os.OrderStatusCode in ('PIKL','PLCN','ISUD','CNCL','DSCN') and os.OrderStatusCode in ('DRFT','ORFI','APRD','PIKL','PLCN')) plds group by ReceivePalletID) cReservation
                                    join ReceivePallet rp on rp.ID = cReservation.ReceivePalletID 
                                    where rp.ReservedStock <> cReservation.CorrectReserved and rp.Balance < cReservation.CorrectReserved");
            return query;
        }

        public static string UpdateFixReservedStockProblemsCancelReservations()
        {
            string query = String.Format(
                @"update ReceivePallet 
                            set ReservedStock = 0 
                            where Balance>0 and ReservedStock>0 and not Exists (Select * from PickListDetail  pl join PickList p on p.ID = pl.PickListID join [Order] o on o.ID = p.OrderID join OrderStatus os on os.ID = o.OrderStatusID where os.OrderStatusCode in ('PIKL','PLCN','ISUD','CNCL','DSCN') and os.OrderStatusCode in ('DRFT','ORFI','APRD','PIKL','PLCN')  and pl.ReceivePalletID=ReceivePallet.ID)");
            return query;
        }

        public static string SelectGetFacilitiesItemsReservedFor(int receivePalletID, int pickListGenerated, int pickListConfirmed)
        {
            return String.Format(@"select distinct ru.Name from PickListDetail pld join PickList pl on pld.PickListID=pl.ID join [Order] o on o.ID=pl.OrderID join Institution ru on ru.ID=o.RequestedBy
							where pld.ReceivePalletID={0} and o.OrderStatusID in ({1},{2})", receivePalletID, pickListGenerated, pickListConfirmed);
        }
       
        public static string SpCreateProcedureReceiveDocReceivePallet()
        {
            string query = @"Create TRIGGER QLvsBAL_RecPal ON ReceivePallet
									FOR Update
									AS 
									IF (0<>(Select Count(*) from ReceiveDoc rd where rd.ID in (Select rd.ID from ReceiveDoc rd join ReceivePallet rp on rd.ID=rp.ReceiveID where rp.ReceiveID in (select ReceiveID from inserted) group by rd.ID having sum(rp.Balance)<>MAX(rd.QuantityLeft))))
									BEGIN
										declare @itemName as varchar(50), @message as varchar (100)
										set @itemname=(Select FullItemName from vwGetAllItems where ID in (Select ItemID from ReceiveDoc rd join inserted i on i.ReceiveID=rd.ID))
										set @message='Receive Pallet vs. ReceiveDoc Inconsistency for '
										set @message=@message + @itemName
										RAISERROR(@message,16,1)
										ROLLBACK TRANSACTION
									END";
            return query;
        }

        public static string DropTriggerProcedureReceiveDocReceivePallet()
        {
            string query = @"Drop TRIGGER QLvsBAL_RecPal";
            return query;
        }

        public static string SelectLoadByUnitIDItemIDAndBatch(int itemID, int unitID, string batch)
        {
            string query = String.Format("Select * from ReceivePallet rp join receivedoc rd on rd.ID=rp.ReceiveID where rd.ItemID={0} and rd.UnitID={1} and rd.BatchNo={2}", itemID, unitID, batch);
            return query;
        }

        public static string SelectLoadForInventory(string batchNo, DateTime? expDate, int itemID, int unitID, int manufacturerID, int activityID, int physicalStoreID)
        {
            string batchFilter = !String.IsNullOrEmpty(batchNo) ? String.Format("and BatchNo like '{0}'", batchNo) : "and BatchNo is Null";
            string expiryFilter = expDate.HasValue ? String.Format("and ExpDate = '{0}'", expDate.Value) : "and ExpDate is Null";

            return String.Format(
                @"select rp.* from receivePallet rp
                                join receiveDoc rd on rp.ReceiveID = rd.ID
							    join PhysicalStore ps on rd.PhysicalStoreID = ps.ID
                                join vwPallet pl on pl.PalletLocationID = rp.PalletLocationID
                                where rd.ItemID = {0} and rd.UnitID ={1}                                      
							          and rd.InventoryperiodID <> ps.CurrentInventoryperiodID 
                                      and rd.ManufacturerID ={2}and rd.StoreID = {3}
                                      and ps.ID ={4} {5} {6}",
                itemID, unitID
                , manufacturerID
                , activityID, physicalStoreID, batchFilter, expiryFilter);
        }
    }
}
