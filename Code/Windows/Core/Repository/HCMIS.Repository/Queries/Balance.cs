using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class Balance
    {
        [SelectQuery]
        public static string SelectGetAvailableNoOfMonths(int itemId, int storeId, DateTime dt1, DateTime dt2)
        {
            return String.Format("SELECT Date, ID, ItemID, StoreId FROM IssueDoc WHERE (ItemID = {0} AND StoreId = {1}) AND (Date Between '{2}' AND '{3}')", itemId, storeId, dt1.ToString(), dt2.ToString());
        }

        [SelectQuery]
        public static string SelectGetAvailableNoOfMonthsInAllStores(int itemId, DateTime dt1, DateTime dt2)
        {
            return String.Format("SELECT Date, ID, ItemID, StoreId FROM IssueDoc WHERE (ItemID = {0} AND (Date Between '{1}' AND '{2}'))", itemId, dt1.ToString(), dt2.ToString());
        }

        [SelectQuery]
        public static string SelectGetUsableStock(int itemID, int storeID, int? unitID, int? physicalStoreID, int? manufacturerID, DateTime? expiryDate)
        {
            string physicalStoreQuery = "";
            if (physicalStoreID.HasValue)
            {
                physicalStoreQuery = string.Format(" and rp.ID in (Select rp.ID from ReceivePallet rp join PalletLocation pl on rp.PalletID=pl.PalletID join Shelf sh on pl.ShelfID=sh.ID where sh.StoreID={0})", physicalStoreID.Value);
            }

            string manufacturerQuery = "";
            if (manufacturerID.HasValue)
            {
                manufacturerQuery = string.Format(" and ManufacturerID={0} ", manufacturerID);
            }

            string expiryQuery = "";
            if (expiryDate.HasValue)
            {
                expiryQuery = string.Format(" and cast(rd.ExpDate as date)  = cast('{0}' as date)",
                                            expiryDate.Value.ToString());
            }


            string query = String.Format(@"SELECT SUM(rd.QuantityLeft/rd.QtyPerPack) - SUM (rp.ReservedStock/rd.QtyPerPack) QL
											FROM ReceiveDoc rd join ReceivePallet rp on rd.ID=rp.ReceiveID
											WHERE ItemID={0} and Confirmed=1 and StoreID={1} and UnitID={2} {3} {4} {5}", itemID, storeID, unitID,
                manufacturerQuery, physicalStoreQuery, expiryQuery);
            return query;
        }

        [SelectQuery]
        public static string SelectPriceOfAllItems(int storeId)
        {
            string query =
                String.Format(
                    "select rd.ItemID, v.Name as Type , s.CompanyName as SupplierName, v.FullItemName, SupplierID , SUM(QuantityLeft / QtyPerPack) SOH, Cost, SellingPrice, pi.ProgramID from ReceiveDoc rd join vwGetAllItems v on rd.ItemID = v.ID join ItemProgram pi on v.ID = pi.ItemID join Supplier s on rd.SupplierID = s.ID where QuantityLeft > 0 and StoreID = {0} Group by SupplierID, rd.ItemID, Cost, SellingPrice , s.CompanyName, v.FullItemName, pi.ProgramID, v.Name order by FullItemName",
                    storeId);
            return query;
        }

        [SelectQuery]
        public static string SelectGetQuantityLeft(int storeID, int itemID, int unitID)
        {
            string query =
                String.Format(
                    "select sum(rd.QuantityLeft) QL from ReceiveDoc rd where rd.ItemID={0} and rd.UnitID={1} and rd.StoreID={2}",
                    itemID, unitID, storeID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetUnPricedQuantityForHub(int itemID, int storeID, int? unitID, int? manufacturerID, int? physicalStoreID, DateTime? preferredExpiryDate)
        {
            string physicalStoreQuery = "";
            if (physicalStoreID.HasValue)
            {
                physicalStoreQuery = string.Format(" and rd.ID in (Select rp.ReceiveID from ReceivePallet rp join PalletLocation pl on rp.PalletID=pl.PalletID join Shelf sh on pl.ShelfID=sh.ID where sh.StoreID={0})", physicalStoreID.Value);
            }

            string expiryQuery = "";
            if (preferredExpiryDate.HasValue)
            {
                expiryQuery = string.Format(" and cast(rd.ExpDate as date)  = cast('{0}' as date)",
                                            preferredExpiryDate.Value.ToString());
            }

            return String.Format(
                "select sum(rd.Quantity / rd.QtyPerPack) UQ from ReceiveDoc rd where rd.ItemID={0} and rd.UnitID={1} and rd.StoreID={2} and rd.Cost is null and rd.DeliveryNote=1 {4} {5} {3}",
                itemID, unitID, storeID,
                manufacturerID.HasValue ? String.Format(" and ManufacturerID={0}", manufacturerID.Value) : "",
                physicalStoreQuery, expiryQuery);
        }

        [SelectQuery]
        public static string SelectGetUnPricedQuantityForCenter(int itemID, int storeID, int? unitID, int? manufacturerID, int? physicalStoreID, DateTime? preferredExpiryDate)
        {
            string physicalStoreQuery = "";
            if (physicalStoreID.HasValue)
            {
                physicalStoreQuery = string.Format(" and rd.ID in (Select rp.ReceiveID from ReceivePallet rp join PalletLocation pl on rp.PalletID=pl.PalletID join Shelf sh on pl.ShelfID=sh.ID where sh.StoreID={0})", physicalStoreID.Value);
            }

            string expiryQuery = "";
            if (preferredExpiryDate.HasValue)
            {
                expiryQuery = string.Format(" and cast(rd.ExpDate as date)  = cast('{0}' as date)",
                                            preferredExpiryDate.Value.ToString());
            }

            return String.Format(
                "select sum(rd.Quantity / rd.QtyPerPack) UQ from ReceiveDoc rd join ReceivePallet rp on rd.ID = rp.ReceiveID join PalletLocation pl on rp.PalletID = pl.PalletID join StorageType st on st.ID = pl.StorageTypeID where rd.ItemID={0} and rd.UnitID={1} and rd.StoreID={2} and (rd.Cost is null or rd.Cost = 0) and (rd.ExpDate is not null and rd.ExpDate <= GetDate()) and (st.StorageTypeCode <> 'SA') {4} {5} {3}",
                itemID, unitID, storeID,
                manufacturerID.HasValue ? String.Format(" and ManufacturerID={0}", manufacturerID.Value) : "",
                physicalStoreQuery, expiryQuery);
        }

        [SelectQuery]
        public static string SelectGetPicklistedValueForFacility(int userID, int itemID, int unitID)
        {
            string query =
                String.Format(@"select acct.ActivityName,ru.ID FacilityID,o.ID as OrderID, o.RefNo , ru.Name, i.FullItemName, sum(od.Packs) Quantity from PickListDetail od join PickList pl on od.PickListID = pl.ID join [Order] o on o.ID=pl.OrderID join Institution ru on ru.ID=o.RequestedBy 
											join vwGetAllItems i on i.ID=od.ItemID join vwAccounts acct on od.StoreID=acct.ActivityID
											where o.OrderStatusID in (select ID from OrderStatus Where OrderStatusCode in('PIKL','PLCN')) and od.StoreID in (select StoreID from UserStore where UserID={0} and CanAccess=1)  and od.ItemID={1} and od.UnitID={2}
											group by acct.ActivityName, ru.Name, i.FullItemName, ru.ID, o.ID, o.RefNo", userID, itemID, unitID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetReservedItemsWithAmount(int modeID, int pickListGenerated, int pickListConfirmed)
        {
            string query =
                String.Format(@"select o.RefNo,acct.AccountName,ru.Name,pl.SavedDate, sum(pld.Cost) Amount, '' Difference
                                            from [order] o join Picklist pl on pl.OrderID=o.ID join [PicklistDetail] pld on pl.ID=pld.PicklistID
                                            join Institution ru on o.RequestedBy=ru.ID join vwAccounts acct on pld.StoreID=acct.ActivityID
                                            where o.OrderStatusID in ({0},{1}) and o.FromStore={2}
                                            group by o.RefNo,acct.AccountName,ru.Name,pl.SavedDate
                                            order by pl.SavedDate", pickListGenerated, pickListConfirmed, modeID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetApprovedValueForFacilityPerActivity(int storeID, int itemID, int unitID)
        {
            string query =
                String.Format(@"select ru.Name, i.FullItemName, sum(od.Pack) Quantity from OrderDetail od join [Order] o on o.ID=od.OrderID join Institution ru on ru.ID=o.RequestedBy 
											join vwGetAllItems i on i.ID=od.ItemID
											where o.OrderStatusID in (select ID from OrderStatus Where OrderStatusCode = 'APRD') and od.StoreID={0} and od.ItemID={1} and od.UnitID={2}
											group by acct.ActivityName, ru.Name, i.FullItemName", storeID, itemID, unitID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetApprovedValueForFacility(int userID, int itemID, int unitID)
        {
            string query =
                String.Format(@"select acct.ActivityName, ru.Name, i.FullItemName, sum(od.Pack) Quantity from OrderDetail od join [Order] o on o.ID=od.OrderID join Institution ru on ru.ID=o.RequestedBy 
											join vwGetAllItems i on i.ID=od.ItemID join vwAccounts acct on od.StoreID=acct.ActivityID
											where o.OrderStatusID in (select ID from OrderStatus Where OrderStatusCode = 'APRD') and od.StoreID in (select StoreID from UserStore where UserID={0} and CanAccess=1) and od.ItemID={1} and od.UnitID={2}
											group by acct.ActivityName, ru.Name, i.FullItemName", userID, itemID, unitID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetAllSOHForPrintOutInitial(int storeId)
        {
            string query =
                String.Format(
                    "select SUM((rp.Balance - rp.ReservedStock) / rd.QtyPerPack) as SOH,v.Name as Category, m.Name as Manufacturer, max(rd.ExpDate) as ExpiryDate, rd.ItemID, v.FullItemName, iu.Text as Unit,  CASE WHEN DATEDIFF(mm ,GETDATE(), max(rd.ExpDate)) < 0 THEN 'Expired' ELSE CASE WHEN DATEDIFF(mm,GETDATE(), max(rd.ExpDate)) < 6 THEN 'Yes' ELSE '-' END END as NearExpiry  from ReceiveDoc rd join ReceivePallet rp on rp.ReceiveID = rd.ID join PalletLocation pl on rp.PalletLocationID = pl.ID join StorageType st on st.ID = pl.StorageTypeID  and st.StorageTypeCode <> 'SA' join ItemUnit iu on rd.UnitID = iu.ID join vwGetAllItems v on rd.ItemID = v.ID join Manufacturers m on rd.ManufacturerId = m.ID where StoreID = {0} and rd.QuantityLeft > 0 and (rd.ExpDate > GetDate() or rd.ExpDate is null) group by m.Name , year(rd.ExpDate),month(rd.ExpDate), rd.ItemID, v.FullItemName,v.Name, iu.Text  order by v.FullItemName",
                    storeId);
            return query;
        }

        [SelectQuery]
        public static string SelectGetAllSOHForPrintOut(int storeId)
        {
            string query =
                String.Format(
                    "select SUM((rp.Balance - rp.ReservedStock) / rd.QtyPerPack) as SOH,v.Name as Category, m.Name as Manufacturer, max(rd.ExpDate) as ExpiryDate, rd.ItemID, v.FullItemName, iu.Text as Unit,  CASE WHEN DATEDIFF(mm, GETDATE(), max(rd.ExpDate)) < 0 THEN 'Expired' ELSE CASE WHEN DATEDIFF(mm,GETDATE(), max(rd.ExpDate)) < 6 THEN 'Yes' ELSE '-' END END as NearExpiry  from ReceiveDoc rd join ReceivePallet rp on rp.ReceiveID = rd.ID join PalletLocation pl on rp.PalletLocationID = pl.ID join StorageType st on st.ID = pl.StorageTypeID and st.StorageTypeCode <> 'SA' join ItemUnit iu on rd.UnitID = iu.ID join vwGetAllItems v on rd.ItemID = v.ID join Manufacturers m on rd.ManufacturerId = m.ID where StoreID = {0} and rd.QuantityLeft > 0 and (rd.ExpDate > GetDate() or rd.ExpDate is null) group by m.Name , year(rd.ExpDate),month(rd.ExpDate), rd.ItemID, v.FullItemName,v.Name, iu.Text  order by v.FullItemName",
                    storeId);
            return query;
        }

        /// <summary>
        /// Gets the readyness filters.
        /// </summary>
        /// <param name="setting">The setting.</param>
        /// <param name="storeId">The store id.</param>
        /// <param name="itemID">The item ID.</param>
        /// <param name="unitid">The unitid.</param>
        /// <param name="preferedExpiry">The prefered expiry.</param>
        /// <param name="preferredManufacturer">The preferred manufacturer.</param>
        /// <param name="preferredPhysicalStoreID">The preferred physical store ID.</param>
        /// <returns></returns>
        [FilterQuery]
        private static string GetReadynessFilters(bool deliveryNoteOnly, bool issueUnpricedCommodity, int storeId, int itemID, int? unitid, DateTime? preferedExpiry, int? preferredManufacturer, int? preferredPhysicalStoreID)
        {

            string filters;
            if (deliveryNoteOnly && issueUnpricedCommodity)
            {
                filters = String.Format("Where ItemID = {0} and UnitID = {1} and SellingPrice is null and StoreID = {2} ", itemID, unitid, storeId);
            }
            else if (deliveryNoteOnly && !issueUnpricedCommodity)
            {
                filters = String.Format("Where ItemID = {0} and UnitID = {1} and DeliveryNote = 1 and StoreID = {2} ", itemID, unitid, storeId);
            }
            else
            {
                filters = String.Format("Where ItemID = {0} and UnitID = {1} and SellingPrice is not null and StoreID = {2} ", itemID, unitid, storeId);
            }
            if (preferedExpiry != null)
            {
                filters += String.Format(" and Cast(ExpDate as Date) = cast('{0}' as Date) ", preferedExpiry);
            }

            if (preferredManufacturer != null)
            {
                filters += String.Format(" and ManufacturerID = {0}", preferredManufacturer);
            }
            if (preferredPhysicalStoreID != null)
            {
                filters += String.Format(" and PhyicalStoreID = {0}", preferredPhysicalStoreID);
            }
            return filters;
        }


        [SelectQuery]
        public static string SelectGetItemsAvailableForApproval(int userID, int storeID, int itemID, int? unitID, bool deliveryNoteOnly, bool issueUnpricedCommodity, bool doNotIssueNearlyExpired, DateTime? preferedExpiry, int? preferredManufacturer, int? preferredPhysicalStoreID)
        {
            string filters = GetReadynessFilters(
                deliveryNoteOnly, issueUnpricedCommodity, storeID, itemID, unitID,
                preferedExpiry, preferredManufacturer, preferredPhysicalStoreID);

            string nearExpiryFilter = "";
            if (doNotIssueNearlyExpired)
            {
                nearExpiryFilter =
                    string.Format(" and  (ExpDate is null or ExpDate not between GETDATE() and DATEADD(day,v.NearExpiryTrigger,GETDATE()))");
            }

            string query =
                String.Format(
                    "select Sum(Balance/QtyPerPack) - sum(v.ReservedStock/QtyPerPack) as Usable from vwItemsReadyForDispatch v join vwPallet p on v.PalletLocationID = p.PalletLocationID and p.PhyicalStoreID in (select PhysicalStoreID from UserPhysicalStore where UserID = {1} and CanAccess = 1) and (v.ExpDate > GetDate() or v.ExpDate is null) {0} {2}",
                    filters, userID, nearExpiryFilter);
            return query;
        }

        [SelectQuery]
        public static string SelectGetStockStatusByAccountShowUnitPrice(int accountID)
        {
            string query;
            query =
                String.Format(@"select a.AccountName, a.SubAccountName,a.ActivityName,i.FullItemName,iu.Text, ExpDate, rd.UnitCost, SUM( rd.QuantityLeft / rd.QtyPerPack) as SOH from 
	                                            ReceiveDoc rd 
	                                            join vwGetAllItems i on i.ID = rd.ItemID 
	                                            join ItemUnit iu on iu.ID = rd.UnitID 
	                                            join vwAccounts a on a.ActivityID = rd.StoreID
                                                Join PhysicalStore phy on phy.ID = rd.PhysicalStoreID
	                                            where QuantityLeft > 0 and a.AccountID = {0} and phy.IsActive =1
	                                            group by 
	                                            a.AccountName, a.SubAccountName,a.ActivityName,i.FullItemName,iu.Text, ExpDate, rd.UnitCost
                                                Order by ActivityName, FullItemName,rd.UnitCost
                                                ", accountID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetStockStatusByAccountHideUnitPrice(int accountID)
        {
            string query;
            query =
                String.Format(@"select a.AccountName, a.SubAccountName,a.ActivityName,i.FullItemName,iu.Text, ExpDate, SUM( rd.QuantityLeft / rd.QtyPerPack) as SOH from 
	                                            ReceiveDoc rd 
	                                            join vwGetAllItems i on i.ID = rd.ItemID 
	                                            join ItemUnit iu on iu.ID = rd.UnitID 
	                                            join vwAccounts a on a.ActivityID = rd.StoreID
                                                Join PhysicalStore phy on phy.ID = rd.PhysicalStoreID
	                                            where QuantityLeft > 0 and a.AccountID = {0} and phy.IsActive =1
	                                            group by 
	                                            a.AccountName, a.SubAccountName,a.ActivityName,i.FullItemName,iu.Text, ExpDate
                                                Order by ActivityName, FullItemName
                                                ", accountID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetStockStatusByMode()
        {
            string query =
                String.Format(@"Select Case when m.ModeCode = 'HPR'  Then 'Health Program' else 'RDF Regular' end MovingAverageName,
		                                            Sum(Case When ct.CommodityTypeCode = 'PHAR' then (rd.QuantityLeft /rd.QtyperPack) * rd.Cost else 0 end) Pharmaceuticals
	                                              , Sum(Case When ct.CommodityTypeCode = 'MEDS' then (rd.QuantityLeft /rd.QtyperPack) * rd.Cost else 0 end) MedicalSupplies
	                                              , Sum(Case When ct.CommodityTypeCode = 'MEDE' then (rd.QuantityLeft /rd.QtyperPack) * rd.Cost else 0 end) MedicalEquipments
	                                              , Sum(Case When ct.CommodityTypeCode = 'CHEM' then (rd.QuantityLeft /rd.QtyperPack) * rd.Cost else 0 end) ChemicalsAndReagents
	                                              , Sum((rd.QuantityLeft /rd.QtyperPack)* rd.Cost) GrandTotal      
                                            from Receivedoc rd
	                                            Join ReceiveDocConfirmation rdc on rd.ID = rdc.ReceiveDocID
	                                            Join vwAccounts a on rd.StoreID = a.ActivityID
	                                            Join vwGetAllItems i on i.ID = rd.ItemID
                                                join Mode m on m.ID = a.ModeID
                                                join CommodityType ct on ct.ID = TypeID
                                                join ReceiptConfirmationStatus rcs on rcs.ID = rdc.ReceiptConfirmationStatusID
                                            Where QuantityLeft > 0 and rcs.ReceiptConfirmationStatusCode in ('GRVP','SREC','CANC','GRNFP')
                                            Group by  m.ModeCode");
            return query;
        }

        [SelectQuery]
        public static string SelectGetStockStatusByAccountDamagedExcluded()
        {
            string query = String.Format(@"Select a.ModeID,a.MovingAverageName,
		                                        Sum(Case When ct.CommodityTypeCode = 'PHAR' then (rd.QuantityLeft /rd.QtyperPack) * rd.Cost else 0 end) Pharmaceuticals
	                                          , Sum(Case When ct.CommodityTypeCode = 'MEDS' then (rd.QuantityLeft /rd.QtyperPack) * rd.Cost else 0 end) MedicalSupplies
	                                          , Sum(Case When ct.CommodityTypeCode = 'MEDE' then (rd.QuantityLeft /rd.QtyperPack) * rd.Cost else 0 end) MedicalEquipments
	                                          , Sum(Case When ct.CommodityTypeCode = 'CHEM' then (rd.QuantityLeft /rd.QtyperPack) * rd.Cost else 0 end) ChemicalsAndReagents
	                                          , Sum((rd.QuantityLeft /rd.QtyperPack)* rd.Cost) GrandTotal
                                            from Receivedoc rd
                                                Join ReceivePallet rp on rd.ID = rp.ReceiveID
												Join vwPallet pl on rp.PalletId = pl.PalletId
	                                            Join ReceiveDocConfirmation rdc on rd.ID = rdc.ReceiveDocID
	                                            Join vwAccounts a on rd.StoreID = a.ActivityID
	                                            Join vwGetAllItems i on i.ID = rd.ItemID
                                                join CommodityType ct on ct.ID = TypeID
                                                join ReceiptConfirmationStatus rcs on rcs.ID = rdc.ReceiptConfirmationStatusID
                                                join StorageType st on st.ID = pl.StorageTypeID   
                                            Where QuantityLeft > 0 and rcs.ReceiptConfirmationStatusCode in ('GRVP','SREC','CANC','GRNFP')
                                                    and (rd.ExpDate > GETDATE() or rd.Expdate is null)
													  and st.StorageTypeCode <> 'SA'
                                            Group by  a.ModeID,a.MovingAverageName
                                        Order by a.ModeID");
            return query;
        }

        [SelectQuery]
        public static string SelectGetStockStatusByAccount()
        {
            string query = String.Format(@"Select a.ModeID,a.MovingAverageName,
		                                            Sum(Case When ct.CommodityTypeCode = 'PHAR' then (rd.QuantityLeft /rd.QtyperPack) * rd.Cost else 0 end) Pharmaceuticals
	                                              , Sum(Case When ct.CommodityTypeCode = 'MEDS' then (rd.QuantityLeft /rd.QtyperPack) * rd.Cost else 0 end) MedicalSupplies
	                                              , Sum(Case When ct.CommodityTypeCode = 'MEDE' then (rd.QuantityLeft /rd.QtyperPack) * rd.Cost else 0 end) MedicalEquipments
	                                              , Sum(Case When ct.CommodityTypeCode = 'CHEM' then (rd.QuantityLeft /rd.QtyperPack) * rd.Cost else 0 end) ChemicalsAndReagents
                                                  , Sum((rd.QuantityLeft /rd.QtyperPack)* rd.Cost) GrandTotal
	                                            from Receivedoc rd
	                                            Join ReceiveDocConfirmation rdc on rd.ID = rdc.ReceiveDocID
	                                            Join vwAccounts a on rd.StoreID = a.ActivityID
	                                            Join vwGetAllItems i on i.ID = rd.ItemID
                                                join CommodityType ct on ct.ID = TypeID
                                                join ReceiptConfirmationStatus rcs on rcs.ID = rdc.ReceiptConfirmationStatusID
                                            Where QuantityLeft > 0 and rcs.ReceiptConfirmationStatusCode in ('GRVP','SREC','CANC','GRNFP')
                                            Group by  a.MovingAverageName, a.ModeID
                                            Order by a.ModeID
                                            ");
            return query;
        }

        [SelectQuery]
        public static string SelectGetStockStatusByModeDamagedExcluded()
        {
            string query =
                String.Format(@"SELECT CASE
                                       WHEN m.ModeCode = 'HPR' THEN 'Health Program'
                                       ELSE 'RDF Regular'
                                   END MovingAverageName,
                                   Sum(CASE WHEN ct.CommodityTypeCode = 'PHAR' THEN (rp.Balance /rd.QtyperPack) * rd.Cost ELSE 0 END) Pharmaceuticals ,
                                   Sum(CASE WHEN ct.CommodityTypeCode = 'MEDS' THEN (rp.Balance /rd.QtyperPack) * rd.Cost ELSE 0 END) MedicalSupplies ,
                                   Sum(CASE WHEN ct.CommodityTypeCode = 'MEDE' THEN (rp.Balance /rd.QtyperPack) * rd.Cost ELSE 0 END) MedicalEquipments ,
                                   Sum(CASE WHEN ct.CommodityTypeCode = 'CHEM' THEN (rp.Balance /rd.QtyperPack) * rd.Cost ELSE 0 END) ChemicalsAndReagents ,
                                   Sum((rd.QuantityLeft /rd.QtyperPack)* rd.Cost) Total , --Problem QuantityLeft != Balance
                                   sum((rp.Balance /rd.QtyperPack) * rd.Cost) GrandTotal
                            FROM Receivedoc rd
                            JOIN ReceivePallet rp ON rd.ID = rp.ReceiveID
                            JOIN vwPallet pl ON rp.PalletId = pl.PalletId
                            JOIN ReceiveDocConfirmation rdc ON rd.ID = rdc.ReceiveDocID
                            JOIN vwAccounts a ON rd.StoreID = a.ActivityID
                            JOIN vwGetAllItems i ON i.ID = rd.ItemID
                            join Mode m on m.ID = a.ModeID
                            join CommodityType ct on ct.ID = TypeID
                            join ReceiptConfirmationStatus rcs on rcs.ID = rdc.ReceiptConfirmationStatusID
                            join StorageType st on st.ID = pl.StorageTypeID  
                            WHERE QuantityLeft > 0
                              AND rcs.ReceiptConfirmationStatusCode in ('GRVP','SREC','CANC','GRNFP')
                              AND (rd.ExpDate > GETDATE()
                                   OR rd.Expdate IS NULL)
                              AND st.StorageTypeCode <> 'SA'
                            GROUP BY m.ModeCode");
            return query;
        }

        [SelectQuery]
        public static string SelectGetStockStatusByAccountDamagedExcludedShowUnitPrice(int accountID)
        {
            string query;
            query =
                String.Format(@"Select a.AccountName, a.SubAccountName,a.ActivityName,i.FullItemName,iu.Text, ExpDate,rd.UnitCost, SUM( rp.Balance / rd.QtyPerPack) as SOH from 
	                                            ReceiveDoc rd 
                                                Join ReceivePallet rp on rd.ID = rp.ReceiveID
												Join vwPallet pl on rp.PalletId = pl.PalletId
	                                            join vwGetAllItems i on i.ID = rd.ItemID 
	                                            join ItemUnit iu on iu.ID = rd.UnitID 
	                                            join vwAccounts a on a.ActivityID = rd.StoreID
                                                join StorageType st on st.ID = pl.StorageTypeID 
	                                            where QuantityLeft > 0 
													  and a.AccountID = {0}
                                                      and (rd.ExpDate > GETDATE() or rd.Expdate is null)
													  and st.StorageTypeCode <> 'SA'
	                                            group by 
	                                            a.AccountName, a.SubAccountName,a.ActivityName,i.FullItemName,iu.Text, ExpDate,pl.StorageTypeID,rd.ExpDate,rd.UnitCost
                                                Order by ActivityName, FullItemName,rd.UnitCost
                                                ", accountID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetStockStatusByAccountDamagedExcludedHideUnitPrice(int accountID)
        {
            string query;
            query =
                String.Format(@"Select a.AccountName, a.SubAccountName,a.ActivityName,i.FullItemName,iu.Text, ExpDate, SUM( rp.Balance / rd.QtyPerPack) as SOH from 
	                                            ReceiveDoc rd 
                                                Join ReceivePallet rp on rd.ID = rp.ReceiveID
												Join vwPallet pl on rp.PalletId = pl.PalletId
	                                            join vwGetAllItems i on i.ID = rd.ItemID 
	                                            join ItemUnit iu on iu.ID = rd.UnitID 
	                                            join vwAccounts a on a.ActivityID = rd.StoreID
                                                join StorageType st on st.ID = pl.StorageTypeID  
	                                            where QuantityLeft > 0 
													  and a.AccountID = {0}
                                                      and (rd.ExpDate > GETDATE() or rd.Expdate is null)
													  and st.StorageTypeCode <> 'SA'
	                                            group by 
	                                            a.AccountName, a.SubAccountName,a.ActivityName,i.FullItemName,iu.Text, ExpDate,pl.StorageTypeID,rd.ExpDate
                                                Order by ActivityName, FullItemName
                                                ", accountID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetStockStatusByPhysicalStore(int physicalStoreID, int activityID, bool showStockout)
        {
            string stockOutQuery = "";
            if (!showStockout)
            {
                stockOutQuery = " and rp.Balance>0 and rp.Balance is not null ";
            }

            string query =
                String.Format(
                    @"SELECT i.StockCode,i.ID,i.FullItemName,iu.[Text] Unit,m.Name Manufacturer,rd.BatchNo,rd.ExpDate, i.Name [Type]
                            ,i.TypeID
                            , SUM(case when(rd.ExpDate is null or rd.ExpDate >GETDATE()) and st.StorageTypeCode <> 'SA' then 
								(rp.Balance/rd.QtyPerPack) else 0 end) [SOH]
                            , SUM(case when st.StorageTypeCode = 'SA' then 
								(rp.Balance/rd.QtyPerPack) else 0 end) Damaged
                            , SUM(case when rd.ExpDate <= GETDATE() and st.StorageTypeCode <> 'SA' then (rp.Balance/rd.QtyPerPack) else 0 end ) [Expired]
                            FROM ReceiveDoc rd 
	                            join ReceivePallet rp on rd.ID=rp.ReceiveID 
	                            join vwGetAllItems i on rd.ItemID=i.ID
                                join Manufacturers m on rd.ManufacturerId=m.ID join vwPallet p on rp.PalletID=p.PalletID 
                                join ItemUnit iu on rd.UnitID=iu.ID
	                            join vwPallet plt on rp.PalletID=plt.PalletID 
                                join StorageType st on st.ID = plt.StorageTypeID   
                            where p.PhyicalStoreID={0} and rd.StoreID={1} {2}
                            group by i.StockCode,m.Name,i.ID,i.FullItemName,iu.[Text], rd.BatchNo,rd.ExpDate, i.Name,i.TypeID
                            order by i.FullItemName",
                    physicalStoreID, activityID, stockOutQuery);
            return query;
        }

        [SelectQuery]
        public static string SelectGetCountSheetByPhysicalStoreShowStockOut(int physicalStoreID, int activityID, string stockOutQuery)
        {
            stockOutQuery = String.Format(
                @"SELECT distinct i.StockCode,i.ID,i.FullItemName,iu.[Text] Unit,m.Name Manufacturer, BatchNo = null, ExpDate = null, i.Name [Type],i.TypeID, [SOH] = null, 
                             Damaged = null, [Expired] = null
                                FROM ReceiveDoc rd 
                                    join ReceivePallet rp on rd.ID=rp.ReceiveID 
                                    join vwGetAllItems i on rd.ItemID=i.ID
                                    join Manufacturers m on rd.ManufacturerId=m.ID 
                                    join vwPallet p on rp.PalletLocationID=p.PalletLocationID 
                                    join ItemUnit iu on rd.UnitID=iu.ID
                            where p.PhyicalStoreID={0} and rd.StoreID={1} and rd.QuantityLeft = 0
                            group by 
                                i.StockCode,m.Name,i.ID,i.FullItemName,iu.[Text], i.Name,i.TypeID",
                physicalStoreID, activityID);
            return stockOutQuery;
        }

        [SelectQuery]
        public static string SelectGetCountSheetByPhysicalStoreHideStockOut(int physicalStoreID, int activityID, string stockOutQuery)
        {
            string query =
                String.Format(
                    @"SELECT distinct i.StockCode,i.ID,i.FullItemName,iu.[Text] Unit,m.Name Manufacturer, BatchNo = null, ExpDate = null, i.Name [Type],i.TypeID, [SOH] = null, 
                             Damaged = null, [Expired] = null
                                FROM ReceiveDoc rd 
                                    join ReceivePallet rp on rd.ID=rp.ReceiveID 
                                    join vwGetAllItems i on rd.ItemID=i.ID
                                    join Manufacturers m on rd.ManufacturerId=m.ID 
                                    join vwPallet p on rp.PalletID=p.PalletID 
                                    join ItemUnit iu on rd.UnitID=iu.ID
                                    left join (select rPallet.ID,rPallet.ReceiveID,rPallet.Balance from ReceivePallet rPallet join vwPallet plt on rPallet.PalletID=plt.PalletID 
                                    join StorageType st on st.ID = plt.StorageTypeID 
                            where st.StorageTypeCode = 'SA') as DamagedAndSuspended on rd.ID = DamagedAndSuspended.ReceiveID
                            where p.PhyicalStoreID={0} and rd.StoreID={1}  and rp.Balance>0 and rp.Balance is not null
                            group by 
                                i.StockCode,m.Name,i.ID,i.FullItemName,iu.[Text],  i.Name,i.TypeID
                            {2}
                            order by i.FullItemName, m.Name",
                    physicalStoreID, activityID, stockOutQuery);
            return query;
        }

        [SelectQuery]
        private static string SelectGetCountSheetByPhysicalStoreWithBatchExpiryShoeStockOut(int physicalStoreID, int activityID, string stockOutQuery, string locationSelect, string locationGroup)
        {
            stockOutQuery =
                String.Format(
                    @" Union SELECT distinct i.StockCode,i.ID,i.FullItemName,iu.[Text] Unit,m.Name Manufacturer, BatchNo ,ExpDate, i.Name [Type],i.TypeID, [SOH] = null, 
                             Damaged = null, [Expired] = null, p.PalletLocationID {2}
                                FROM ReceiveDoc rd 
                                    join ReceivePallet rp on rd.ID=rp.ReceiveID 
                                    join vwGetAllItems i on rd.ItemID=i.ID
                                    join Manufacturers m on rd.ManufacturerId=m.ID 
                                    join vwPallet p on rp.PalletLocationID=p.PalletLocationID
                                    join ItemUnit iu on rd.UnitID=iu.ID
                            where p.PhyicalStoreID={0} and rd.StoreID={1} and rd.QuantityLeft = 0
                            group by 
                                i.StockCode, m.Name,i.ID,i.FullItemName,iu.[Text],  i.Name,i.TypeID, rd.BatchNo, rd.ExpDate,p.PalletLocationID {3}",
                    physicalStoreID, activityID, locationSelect, locationGroup);
            return stockOutQuery;
        }

        [SelectQuery]
        public static string SelectGetCountSheetByPhysicalStoreWithBatchExpiryHideStockOut(int physicalStoreID, int activityID, bool showLocations, bool showStockout)
        {
            string locationSelect = "", locationGroup = "";
            if (showLocations)
            {
                locationSelect = " , p.Label AS [Location]";
                locationGroup = " , p.Label ";
            }

            string stockOutQuery = "";
            if (showStockout)
            {

                stockOutQuery = HCMIS.Repository.Queries.Balance.SelectGetCountSheetByPhysicalStoreWithBatchExpiryShoeStockOut(physicalStoreID, activityID, stockOutQuery, locationSelect, locationGroup);
            }

            string query =
                String.Format(
                    @"SELECT distinct i.StockCode,i.ID,i.FullItemName,iu.[Text] Unit,m.Name Manufacturer, BatchNo ,ExpDate, i.Name [Type],i.TypeID, [SOH] = null, 
                             Damaged = null, [Expired] = null, p.PalletLocationID {3}
                                FROM ReceiveDoc rd 
                                    join ReceivePallet rp on rd.ID=rp.ReceiveID 
                                    join vwGetAllItems i on rd.ItemID=i.ID
                                    join Manufacturers m on rd.ManufacturerId=m.ID 
                                    join vwPallet p on rp.PalletID=p.PalletID 
                                    join ItemUnit iu on rd.UnitID=iu.ID
                                    left join (select rPallet.ID,rPallet.ReceiveID,rPallet.Balance from ReceivePallet rPallet join vwPallet plt on rPallet.PalletID=plt.PalletID 
                                    join StorageType st on st.ID = plt.StorageTypeID 
                            where st.StorageTypeCode = 'SA') as DamagedAndSuspended on rd.ID = DamagedAndSuspended.ReceiveID
                            where p.PhyicalStoreID={0} and rd.StoreID={1} and rp.Balance>0 and rp.Balance is not null 
                            group by 
                                i.StockCode, m.Name,i.ID,i.FullItemName,iu.[Text],  i.Name,i.TypeID, rd.BatchNo, rd.ExpDate,p.PalletLocationID {4}
                            {2}
                            order by i.FullItemName, m.Name, rd.ExpDate, rd.BatchNo",
                    physicalStoreID, activityID, stockOutQuery, locationSelect, locationGroup);
            return query;
        }

        [SelectQuery]
        public static string SelectGetBalanceByPhysicalStore(int physicalStoreID, int activityID, bool showStockout)
        {
            string stockOutQuery = "";
            if (!showStockout)
            {
                stockOutQuery = " and rp.Balance>0 and rp.Balance is not null ";
            }

            string query =
                String.Format(
                    @"SELECT 
                                distinct i.StockCode
                                    , i.ID
                                    , i.FullItemName
                                    , iu.[Text] Unit
                                    , max(iu.ID) as UnitID
                                    , m.Name Manufacturer
                                    , m.ID ManufacturerID
                                    , BatchNo
                                    , ExpDate
                                    , i.Name [Type]
                                    , i.TypeID
                                    , Sum( rd.QuantityLeft / rd.QtyPerPack)  - isnull(Sum( DamagedAndSuspended.Balance / rd.QtyPerPack), 0 ) as [SoundSOH]
                                    , Sum( isnull( DamagedAndSuspended.Balance , 0) / rd.QtyPerPack) as DamagedSOH
                                    , max(rd.Cost) as Cost
                                    , max(rd.Margin) as Margin
                                    , Max(p.PalletLocationID) PalletLocationID
                                FROM ReceiveDoc rd 
                                    join ReceivePallet rp on rd.ID=rp.ReceiveID 
                                    join vwGetAllItems i on rd.ItemID=i.ID
                                    join Manufacturers m on rd.ManufacturerId=m.ID 
                                    join vwPallet p on rp.PalletID=p.PalletID 
                                    join ItemUnit iu on rd.UnitID=iu.ID
                                    left join ( 
                                                    select rPallet.ID,rPallet.ReceiveID , rPallet.Balance from ReceivePallet rPallet join vwPallet plt on rPallet.PalletID=plt.PalletID 
                                                    join StorageType st on st.ID = plt.StorageTypeID 
                                                    where st.StorageTypeCode = 'SA'
                                                ) as DamagedAndSuspended on rd.ID = DamagedAndSuspended.ReceiveID
                            where p.PhyicalStoreID={0} and rd.StoreID={1} {2}
                            group by 
                                i.StockCode, m.Name,i.ID,i.FullItemName,iu.[Text], m.ID , i.Name,i.TypeID, rd.BatchNo, rd.ExpDate
                            order by i.FullItemName, m.Name, rd.ExpDate, rd.BatchNo",
                    physicalStoreID, activityID, stockOutQuery);
            return query;
        }

        [SelectQuery]
        public static string SelectGetSOHReportForFinance(int warehouseID, int activityID)
        {
            string query =
                String.Format(
                    @"SELECT ROW_NUMBER() OVER (Order by itm.FullItemName) [RowNo],  itm.StockCode, itm.FullItemName, iu.[Text] UnitName, m.Name ManufacturerName, rd.ExpDate ExpiryDate, 
		                                            Sum(rp.Balance/iu.QtyPerUnit) Quantity, rd.Cost UnitCost,Margin, Sum((rp.Balance/iu.QtyPerUnit) * rd.Cost) TotalCost, itm.Name [CommodityTypeName], acct.ActivityName, 
		                                            acct.SubAccountName, acct.AccountName, p.WarehouseName, p.ClusterName
                                            FROM 
                                            ReceiveDoc rd 
                                            JOIN vwGetAllItems itm on rd.ItemID = itm.ID
                                            JOIN ItemUnit iu on rd.UnitID=iu.ID
                                            JOIN Manufacturer m on rd.ManufacturerID = m.ID
                                            JOIN vwAccounts acct on rd.StoreID=acct.ActivityID
                                            JOIN ReceivePallet rp on rd.ID=rp.ReceiveID
                                            JOIN vwPallet p on rp.PalletLocationID = p.PalletLocationID
                                            Join ReceivedocConfirmation rdc on rdc.ReceivedocID = rd.ID
                                            join ReceiptConfirmationStatus rcs on rcs.ID = rdc.ReceiptConfirmationStatusID
                                            WHERE p.WarehouseID={0} and acct.ActivityID={1} and												 
												rcs.ReceiptConfirmationStatusCode in ('GRVP','SREC','CANC','GRNFP') and Balance > 0
                                            GROUP BY
                                            itm.StockCode, itm.FullItemName, iu.[Text], m.Name, rd.ExpDate, rd.Cost, itm.[Name]
											, acct.ActivityName, acct.SubAccountName, acct.AccountName,Margin, p.WarehouseName, p.ClusterName",
                    warehouseID, activityID);
            return query;
        }

        [SelectQuery]
        public static string SelectNotReceivedQuantity(int itemId, int itemUnitID, int storeID)
        {
            string query = String.Format(@"  Select Top 1 isNull(Sum(pd.Quantity),0) Requested,isNull(Sum(rid.Quantity),0) GIT,0.0 Approved from PO 
		                                          Join PurchaseOrderDetail pd on po.ID = pd.PurchaseOrderID 
												 Left Join ReceiptInvoice ri on ri.POID = po.ID
		                                         Left Join ReceiptInvoiceDetail rid on rid.ReceiptInvoiceID = ri.ID  
		                                         Left Join ItemUnitBase iu on iu.ItemID = pd.ItemID and iu.UnitOfIssueID = pd.UnitOfIssueID
                                           Where PO.POFinalized = 0  and pd.ItemID = {0} and iu.ID = {1} and po.StoreID = {2}", itemId, itemUnitID, storeID);
    
            return query;
        }

        [SelectQuery]
        public static string SelectHubRequested(int itemId, int itemUnitID, int modeID)
        {
            var query = string.Format(@"Select p.ID, isnull(pd.Quantity,0) Requested,p.PONumber , p.RefNo,p.PODate from PO p 
                                        JOIN PurchaseOrderDetail pd on p.ID = pd.PurchaseOrderID 
                                        JOIN ItemUnitBase iuRequested on pd.ItemID = iuRequested.ItemID and pd.UnitOfIssueID = iuRequested.UnitOfIssueID
                                        JOIN OrderStatus stat ON p.OrderStatusID = stat.ID
                                        Where p.POFinalized = 0 and pd.ItemID = {0} and iuRequested.ID = {1} and p.ModeID = {2} and stat.OrderStatusCode = 'ORFI' order by p.PODate asc", itemId, itemUnitID, modeID);
            return query;
        }

         [SelectQuery]
        public static string SelectHubApproved(object itemID, int itemUnitID, int modeID)
        {
            var query = string.Format(@"Select p.ID ,p.RefNo ,p.PoNumber ,p.PODate ,isNull(pd.ApprovedQuantity,0) Approved  from PO P 
                                        JOIN PurchaseOrderDetail pd on p.ID = pd.PurchaseOrderID 
                                        JOIN ItemUnitBase iuRequested on pd.ItemID = iuRequested.ItemID and pd.UnitOfIssueID = iuRequested.UnitOfIssueID
                                        JOIN OrderStatus stat ON p.OrderStatusID = stat.ID
                                        Where p.POFinalized = 0 and pd.ItemID = {0} and iuRequested.ID = {1} and p.ModeID = {2} and stat.OrderStatusCode IN ('APRD','PIKL','PLCN') order by p.PODate asc", itemID, itemUnitID, modeID);
            return query;

        }
         [SelectQuery]
        public static string SelectGIT(int itemId, int itemUnitID, int modeID)
        {
            var query = string.Format(@"SELECT p.ID,p.PODate , p.PONumber, p.ModeID, inv.PrintedDate InvoicedDate , 
                                              inv.STVOrInvoiceNo, det.ItemID, itb.ID ItemUnitID, 
                                              det.Quantity as GIT 
                                        FROM ReceiptInvoice inv
                                        JOIN ReceiptInvoiceDetail det ON det.ReceiptInvoiceID = inv.ID
                                        JOIN ItemUnitBase itb ON det.UnitOfIssueID = itb.UnitOfIssueID AND det.ItemID = itb.ItemID
                                        JOIN PO p ON inv.POID = p.ID
                                        WHERE inv.ID NOT IN (SELECT ISNULL(ReceiptInvoiceID,0) FROM Receipt) and det.ItemID ={0} and itb.ID = {1} and p.ModeID ={2} order by inv.PrintedDate asc", itemId, itemUnitID, modeID);
             return query;
        }
        [SelectQuery]
        public static string SelectTotalApprovedQty(int orderId, int itemId, int itemUnitId, int modeId)
        {
            var queryTotReq = string.Format(@"SELECT TOP 1 it.ID ItemID, itb.ID UnitID, ISNULL(x.TotalRequested,0.0) TotalRequested
                                            FROM Item it
                                            JOIN ItemUnitBase itb ON itb.ID = {1}
                                            LEFT JOIN (select od.ItemID, od.UnitID, SUM(ISNULL(od.ApprovedQuantity,0)) TotalRequested
			                                            FROM [OrderDetail] od
			                                            JOIN [Order] o ON o.ID = od.OrderID
			                                            JOIN [OrderStatus] stat ON o.OrderStatusID = stat.ID
			                                            WHERE stat.OrderStatusCode IN ('APRD','PIKL','PLCN') AND o.FromStore = {2} AND o.ID <> {3}
			                                            GROUP BY od.ItemID, od.UnitID) AS x ON x.ItemID = it.ID AND x.UnitID = itb.ID
                                            WHERE IT.ID = {0}", itemId, itemUnitId, modeId, orderId);
            return queryTotReq;
        }
        [SelectQuery]
        public static  string SelecthubGIT(int itemId, int itemUnitId, int modeId)
        {
            var queryGIT = string.Format(@"select it.ID ItemID, un.ID UnitOfIssueID, ISNull(x.GIT ,0) GIT, isnull(x.Requested,0) Requested, isnull(x.Approved,0) Approved ,isnull(so.DOS,0) DOS ,isnull(ci.TotalIssued ,0) TotalIssued ,isnull(fy.FiscalYearDays,0) FiscalYearDays
                                            FROM Item it
                                            JOIN ItemUnitBase itb on it.ID = itb.ItemID
                                            JOIN UnitOfIssue un ON itb.UnitOfIssueID =un.ID
                                            left join 
	                                            (select invDet.ItemID,invDet.UnitOfIssueID, SUM(invDet.Quantity) GIT, 0.0 Requested, 0.0 Approved
	                                            FROM ReceiptInvoiceDetail invDet
	                                            JOIN ReceiptInvoice inv ON invDet.ReceiptInvoiceID = inv.ID
	                                            JOIN ItemUnitBase iu on invDet.UnitOfIssueID =iu.UnitOfIssueID and invDet.ItemID = iu.ItemID
	                                            JOIN PO pur ON inv.POID = pur.ID
	                                            WHERE pur.POFinalized = 0 and pur.ModeID = {2} and inv.ID NOT IN (SELECT ISNULL(ReceiptInvoiceID,0) FROM Receipt)
                                                GROUP BY invDet.ItemID, invDet.UnitOfIssueID) x 
                                            ON x.ItemID =it.ID and x.UnitOfIssueID = un.ID
                                            LEFT JOIN (SELECT ItemID, UnitID, SUM(NumberOfDays) DOS FROM Stockout GROUP BY ItemID, UnitID) so on it.ID = so.ItemID and itb.ID =so.UnitID
                                            LEFT JOIN (SELECT ItemID ,UnitID ,SUM(Quantity) TotalIssued From CurrentIssueDoc GROUP BY ItemID, UnitID) ci on it.ID = ci.ItemID and itb.ID =ci.UnitID
                                            LEFT JOIN (SELECT DateDiff(Day,StartDate,GetDate()) FiscalYearDays,StartDate ,EndDate , IsCurrent FROM Fiscalyear) fy on fy.IsCurrent =1
                                            where it.ID ={0} and itb.ID ={1}", itemId, itemUnitId, modeId);
            return queryGIT;
        }

        [SelectQuery]
        public static string Selecthubrequest (int itemId, int itemUnitId, int modeId)
        {
            var queryRQ = String.Format(@"Select Top 1 isnull(Sum(isnull(pd.Quantity,0)),0) Requested, 0.0 Approved from PO p 
                                                  JOIN PurchaseOrderDetail pd on p.ID = pd.PurchaseOrderID 
                                                  JOIN ItemUnitBase iuRequested on pd.ItemID = iuRequested.ItemID and pd.UnitOfIssueID = iuRequested.UnitOfIssueID
                                                  JOIN OrderStatus stat ON p.OrderStatusID = stat.ID
                                                  Where p.POFinalized = 0 and pd.ItemID = {0} and iuRequested.ID = {1} and p.ModeID = {2} and stat.OrderStatusCode = 'ORFI'
                                                  ", itemId, itemUnitId, modeId);
            return queryRQ;
        }

        [SelectQuery]
        public static string Selecthubapproved (int itemId, int itemUnitId, int modeId)
        {
            var queryAP = string.Format(@"Select Top 1 0.0 Requested, ISNULL(sum(isNull(pd.ApprovedQuantity,0)),0) Approved from PO P 
                                                  JOIN PurchaseOrderDetail pd on p.ID = pd.PurchaseOrderID 
                                                  JOIN ItemUnitBase iuRequested on pd.ItemID = iuRequested.ItemID and pd.UnitOfIssueID = iuRequested.UnitOfIssueID
                                                  JOIN OrderStatus stat ON p.OrderStatusID = stat.ID
                                           Where p.POFinalized = 0 and pd.ItemID = {0} and iuRequested.ID = {1} and p.ModeID = {2} and stat.OrderStatusCode IN ('APRD','PIKL','PLCN')",
               itemId, itemUnitId, modeId);
            return queryAP;
        }

        public static string SelectApprovedInformationByOrderID(int orderID)
        {
            var query = string.Format(@"Select 
                                            v.ItemID ,
                                            v.UnitID ,
	                                        v.ManufacturerID ,
	                                        v.ActivityID ,
	                                        v.IsDeliveryNote ,
	                                        v.ExpiryDate ,
	                                        v.PhysicalStoreID ,
	                                        ReservedQuantity ApprovedQuantity
                                        From OrderDetail od
                                                Join VwApprovedQuantity v on v.ItemID = od.ItemID and v.UnitID = od.UnitID 
                                                Join vwAccounts a on v.ActivityID = a.ActivityID
		                                        Join [Order] o on o.ID = od.OrderID 
                                        Where od.OrderID = {0} and a.ModeID = o.FromStore ", orderID);
            return query;
        }
        public static string SelectvwDispatchableItemByOrderID(int orderID,int userId)
        {
            var query = string.Format(@"Select  od.ItemID
		                                        , od.UnitID
		                                        , v.ActivityID
		                                        , v.ManufacturerID
		                                        , v.PhysicalStoreID
		                                        , v.ExpiryDate
		                                        , v.DeliveryNote DeliveryNote
		                                        , sum(v.DispatchableStock) as Usable
		
                                        From OrderDetail od 
                                              Join [Order] o on o.ID = od.OrderID 
	                                          Join vwDispatchableItem v on v.ItemID = od.ItemID and v.UnitID = od.UnitID 
	                                          Join (select * from UserActivity where UserID = {1} and CanAccess=1) us on us.ActivityID = v.ActivityID
	                                          Join (Select * from UserPhysicalStore where UserID = {1} and CanAccess = 1) up on up.PhysicalStoreID = v.PhysicalStoreID
                                        Where od.OrderID ={0} 
		                                        and v.ModeID = o.FromStore
                                                and (ExpiryDate is null or ExpiryDate not between GETDATE() and DATEADD(day,v.NearExpiryTrigger,GETDATE())) 
                                        Group by od.ItemID,od.UnitID,v.ActivityID, v.ManufacturerID, v.PhysicalStoreID,Cast(v.ExpiryDate as Date), v.DeliveryNote
                                        Order by ItemID,UnitID,ExpiryDate", orderID,userId);
            return query;
        }
    }
}
