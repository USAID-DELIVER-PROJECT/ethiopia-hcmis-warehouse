using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class Item
    {
        [SelectQuery]
        public static string SelectFullItemName(int id)
        {
            string query = String.Format("select FullItemName from vwGetAllItems where ID = {0}", id);
            return query;
        }

        public static string SelectFromVwgetAllItems()
        {
            string query = String.Format("select i.*,vw.FullItemName from vwGetAllItems vw Join Item i on vw.ID =i.ID");
            return query;
        }
        public static string SelectFromVwgetAllItemsByID(int id)
        {
            string query = String.Format("select i.*,vw.FullItemName from vwGetAllItems vw Join Item i on vw.ID =i.ID where i.ID = {0}", id);
            return query;
        }
            [SelectQuery]
        public static string SelectGetIDFromSerialNumber(int serialNumber)
        {
            string query = String.Format("Select ID from Item where SN={0}", serialNumber);
            return query;
        }

        [SelectQuery]
        public static string SelectGetAllItemsByCommodityType(int CommodityType)
        {
            return String.Format("select * from vwGetAllItems where TypeID = {0} AND IsActive=1 order by FullItemName", CommodityType);
        }

        [SelectQuery]
        public static string SelectGetSerialNumberFromItemID(int id)
        {
            string query = String.Format("Select SN from Item where ID={0}", id);
            return query;
        }

        [SelectQuery]
        public static string SelectGetStackHeight(int itemId, int manufId)
        {
            string query =
                String.Format(
                    "select distinct (StackHeight) from ItemManufacturer where ItemID = {0} and StackHeight is not null and ManufacturerID = {1}",
                    itemId, manufId);
            return query;
        }

        [SelectQuery]
        public static string SelectAllYears()
        {
            string query = "SELECT Distinct YEAR(Date)as Year from ReceiveDoc order by year desc";
            return query;
        }

        [SelectQuery]
        public static string SelectGetAllItems(int inList)
        {
            string query = String.Format("select *, " +
                                         " CASE WHEN (SELECT COUNT(*) from ItemManufacturer i where i.ItemID = v.ID) > 0 then 1 else 0 end as HasManufacturer " +
                                         " from vwGetAllItems v where v.IsInHospitalList = {0} AND v.Name = 'Drug' ORDER BY v.FullItemName",
                inList);
            return query;
        }

        [SelectQuery]
        public static string SelectGetAllItems()
        {
            string query = String.Format("Select Distinct vw.* from vwGetAllItems vw Join Receivedoc rd on rd.ItemID = vw.ID");
            return query;
        }

        [SelectQuery]
        public static string SelectGetCommodityForRequisition(int commodityTypeId, int modeId, bool isCenter)
        {
            string query =
                String.Format(
                    @"Select *,Cast(0 as bit) IsSelected,CASE WHEN Stock>0 then 0 else 1 end StockedOut from vwCommodity where ModeID = {0} {1} {2}",
                    modeId,
                    commodityTypeId != 0 ? "and TypeID = " + commodityTypeId : "",
                    isCenter ? "and Stock>0" : "");
            return query;
        }

        [SelectQuery]
        public static string SelectGetCommodityHistoryByFacilityForRequisition(int facilityID, int modeId, bool isCenter, int range = -1)
        {
            string rangeQuery = (range == -1) ? ">= -1" : "<= "+range.ToString(CultureInfo.InvariantCulture);
                    string query =
                        String.Format(
                              @"SELECT od.ID,
                                       od.ItemID,
                                       od.UnitID,
                                       od.StoreID,
                                       od.Quantity,
                                       od.ApprovedQuantity,
	                                   od.DamagedStock,
	                                   od.QtyPerPack,
	                                   od.Pack,
	                                   od.OrderID,
	                                   od.DeliveryNote,
	                                   od.StockOnHand,
	                                   od.ExpiredStock,
	                                   od.StoreID,
                                       o.EurDate,
                                       vwComm.*,
                                       CAST(0 AS bit) IsSelected,
                                       CASE
                                           WHEN vwComm.Stock > 0 THEN 0
                                           ELSE 1
                                       END StockedOut
                                FROM OrderDetail od
                                JOIN [Order] o ON od.OrderID = o.ID
                                JOIN
                                  (SELECT od.ItemID,
                                          od.UnitID,
                                          MAX(o.EurDate) MaxEurDate
                                   FROM OrderDetail od
                                   JOIN [Order] o ON od.OrderID = o.ID
                                   WHERE o.RequestedBy = {0}
                                   GROUP BY od.ItemID,
                                            od.UnitID) Main ON od.ItemID = Main.ItemID
                                JOIN vwCommodity vwComm ON main.ItemID = vwComm.ID
                                WHERE o.EurDate = Main.MaxEurDate
                                  AND od.UnitID = Main.UnitID
                                  AND vwComm.UnitID = Main.UnitID
                                  AND vwComm.ModeID = o.FromStore
                                  AND o.FromStore =  {1}
                                  AND DateDiff(DAY,o.EurDate,GETDATE()) {2}
                                ORDER BY vwComm.FullItemName ASC", facilityID,modeId,rangeQuery);
            return query;
        }

        [SelectQuery]
        public static string SelectGetFacilityHistory(int facilityID, string fromDate, string toDate)
        {
            var query = @"Select i.Name Facility
                            , vwg.FullItemName Item
                            , iu.Text Unit
                            , SUM(od.Quantity) Requested
                            , IsNull(SUM(id.Quantity), 0) Issued
                            , Cast(id.EurDate as Date) Date
                        from  [Order] o
                        Join OrderDetail od on o.ID = od.OrderID
                        Left Join IssueDoc id on od.ID = id.OrderID
                        Join vwGetAllItems vwg on id.ItemID = vwg.ID
                        Join ItemUnit  iu on id.UnitID = iu.ID
                        Join Institution i on id.ReceivingUnitID = i.ID
                        Where id.ReceivingUnitID = {0} and id.EurDate Between '{1}' and '{2}' 
                        Group By  i.Name
		                        , vwg.FullItemName
		                        , iu.Text
		                        , o.ID
		                        , Cast(id.EurDate as Date)";

            return String.Format(query, facilityID, fromDate, toDate);
        }

        [SelectQuery]
        public static string SelectGetActiveItemsByCommodityTypeAllItems(string query, int? storeID)
        {
            string additionalFilter = "";
            if (storeID.HasValue)
            {
                additionalFilter = String.Format(" and v.ID in (Select ItemID from StoreItem Where StoreID={0} and UsedInThisStore=1)", storeID.Value);
            }

            query = String.Format("select iu.ID as UnitID, v.Name as CommodityType,v.TypeID , iu.Text as Unit, *,  CASE WHEN (SELECT COUNT(*) from ItemManufacturer i where i.ItemID = v.ID) > 0 then 1 else 0 end as HasManufacturer, IsSelected = cast( 0 as bit)  from vwGetAllItems v join ItemUnit iu on v.ID = iu.ItemID where v.IsInHospitalList = 1 {0}  ORDER BY v.FullItemName", additionalFilter);
            return query;
        }

        [SelectQuery]
        public static string SelectGetActiveItemsByCommodityType(int commodityType, string query, int? storeID)
        {
            string additionalFilter = "";
            if (storeID.HasValue)
            {
                additionalFilter = String.Format(" and v.ID in (Select ItemID from StoreItem Where StoreID={0} and UsedInThisStore=1)", storeID.Value);
            }

            query = String.Format("select iu.ID as UnitID, v.Name as CommodityType, v.TypeID , iu.Text as Unit, *, " +
                                  " CASE WHEN (SELECT COUNT(*) from ItemManufacturer i where i.ItemID = v.ID) > 0 then 1 else 0 end as HasManufacturer, IsSelected = cast( 0 as bit) " +
                                  " from vwGetAllItems v join ItemUnit iu on v.ID = iu.ItemID " +
                                  " where v.IsInHospitalList = 1 and v.TypeID = '{0}' {1} ORDER BY v.FullItemName",
                commodityType, additionalFilter);
            return query;
        }

        [SelectQuery]

        public static string SelectGetActiveItemsBySupplier(int supplierID, int? storeID)
        {
            string additionalFilter = "";
            if (storeID.HasValue)
            {
                additionalFilter = String.Format(" and v.ID in (Select ItemID from StoreItem Where StoreID={0} and UsedInThisStore=1)", storeID.Value);
            }

            string query =
                string.Format(@"Select iu.ID as UnitID, v.Name as CommodityType, v.TypeID , iu.Text as Unit, *,
                                            CASE WHEN (SELECT COUNT(*) from ItemManufacturer i where i.ItemID = v.ID) > 0 then 1 else 0 end as HasManufacturer, IsSelected = cast( 0 as bit) 
                                            from ItemSupplier isup
                                            Join vwGetAllItems v on isup.ItemID= v.ID
                                            join ItemUnit iu on v.ID = iu.ItemID
                                            Where v.IsInHospitalList = 1 and isup.SupplierID = {0} {1}
                                            ORDER BY v.FullItemName", supplierID, additionalFilter);
            return query;
        }

        [SelectQuery]
        public static string SelectGetActiveItemsByCommodityTypeNotRdfMode(int commodityType, string query, int? storeID)
        {
            string additionalFilter = "";
            if (storeID.HasValue)
            {
                additionalFilter = String.Format(" and v.ID in (Select ItemID from StoreItem Where StoreID={0} and UsedInThisStore=1)", storeID.Value);
            }

            query = String.Format("select UnitID = null, v.Name as CommodityType, v.TypeID , *, " +
                                  " CASE WHEN (SELECT COUNT(*) from ItemManufacturer i where i.ItemID = v.ID) > 0 then 1 else 0 end as HasManufacturer, IsSelected = cast( 0 as bit) " +
                                  " from vwGetAllItems v where v.IsInHospitalList = 1  " +
                                  " and iu.ID in (select UnitID from ReceiveDoc rd where rd.QuantityLeft>0)  AND v.TypeID = '{0}' {1} ORDER BY v.FullItemName",
                commodityType, additionalFilter);
            return query;
        }

        [SelectQuery]
        public static string SelectGetDistinctActiveItemsByCommodityTypeAllItems(string query, int userID,bool ExculdeNeverReceived)
        {
            // this may just not be optimal.
            string additionalFilter = ExculdeNeverReceived?String.Format(" and v.ID in (select ItemID from vwReceiveDocWarehouse rd where rd.StoreID in (select StoreID from UserStore where UserID = {0} and CanAccess = 1) and rd.PhysicalStoreID in (select PhysicalStoreID from UserPhysicalStore where UserID = {0} and CanAccess = 1)) ", userID):"";

            query = String.Format("select  v.Name as CommodityType,v.TypeID , *,  CASE WHEN (SELECT COUNT(*) from ItemManufacturer i where i.ItemID = v.ID) > 0 then 1 else 0 end as HasManufacturer, IsSelected = cast( 0 as bit)  from vwGetAllItems v where v.IsInHospitalList = 1 {0}  ORDER BY v.FullItemName", additionalFilter);
            return query;
        }

        [SelectQuery]
        public static string SelectGetDistinctActiveItemsByCommodityType(int commodityType, string query, int userID, bool ExculdeNeverReceived)
        {
            // this may just not be optimal.
            string additionalFilter = ExculdeNeverReceived?String.Format(" and v.ID in (select ItemID from vwReceiveDocWarehouse rd where rd.StoreID in (select StoreID from UserStore where UserID = {0} and CanAccess = 1) and rd.PhysicalStoreID in (select PhysicalStoreID from UserPhysicalStore where UserID = {0} and CanAccess = 1)) ", userID):"";

            query = String.Format("select v.Name as CommodityType, v.TypeID ,  *, " +
                                  " CASE WHEN (SELECT COUNT(*) from ItemManufacturer i where i.ItemID = v.ID) > 0 then 1 else 0 end as HasManufacturer, IsSelected = cast( 0 as bit) " +
                                  " from vwGetAllItems v " +
                                  " where v.IsInHospitalList = 1 and v.TypeID = '{0}' {1} ORDER BY v.FullItemName",
                commodityType, additionalFilter);
            return query;
        }

        [SelectQuery]
        public static string SelectGetActiveItemsByCommodityTypeForReceiveScreenAllItem(string query, int? storeID)
        {
            string additionalFilter = "";
            if (storeID.HasValue)
            {
                additionalFilter = String.Format(" and v.ID in (Select ItemID from StoreItem Where StoreID={0} and UsedInThisStore=1)", storeID.Value);
            }

            query = String.Format("select v.Name as CommodityType,v.TypeID , *,  CASE WHEN (SELECT COUNT(*) from ItemManufacturer i where i.ItemID = v.ID) > 0 then 1 else 0 end as HasManufacturer, IsSelected = cast( 0 as bit)  from vwGetAllItems v where v.IsInHospitalList = 1 and v.IsActive = 1 {0}  ORDER BY v.FullItemName", additionalFilter);
            return query;
        }

        [SelectQuery]
        public static string SelectGetActiveItemsByCommodityTypeForReceiveScreen(int commodityType, string query, int? storeID)
        {
            string additionalFilter = "";
            if (storeID.HasValue)
            {
                additionalFilter = String.Format(" and v.ID in (Select ItemID from StoreItem Where StoreID={0} and UsedInThisStore=1)", storeID.Value);
            }

            query = String.Format("select v.Name as CommodityType, v.TypeID , *, " +
                                  " CASE WHEN (SELECT COUNT(*) from ItemManufacturer i where i.ItemID = v.ID) > 0 then 1 else 0 end as HasManufacturer, IsSelected = cast( 0 as bit) " +
                                  " from vwGetAllItems v " +
                                  " where v.IsInHospitalList = 1 and v.IsActive = 1  and v.TypeID = '{0}' {1} ORDER BY v.FullItemName",
                commodityType, additionalFilter);
            return query;
        }

        [SelectQuery]
        public static string SelectGetActiveItemsByCommodityTypeForReceiveScreenNotRdfMode(int commodityType, string query, int? storeID)
        {
            string additionalFilter = "";
            if (storeID.HasValue)
            {
                additionalFilter = String.Format(" and v.ID in (Select ItemID from StoreItem Where StoreID={0} and UsedInThisStore=1)", storeID.Value);
            }

            query = String.Format("select v.Name as CommodityType, v.TypeID , *, " +
                                  " CASE WHEN (SELECT COUNT(*) from ItemManufacturer i where i.ItemID = v.ID) > 0 then 1 else 0 end as HasManufacturer, IsSelected = cast( 0 as bit) " +
                                  " from vwGetAllItems v where v.IsInHospitalList = 1 and v.IsActive = 1   " +
                                  " and v.TypeID = '{0}' {1} ORDER BY v.FullItemName",
                commodityType, additionalFilter);
            return query;
        }

        [SelectQuery]
        public static string SelectGetItemsBySTVInvoiceNoForStockReturn(int stvID, int storeID)
        {
            var query = String.Format(@"select 
                                         v.ID,v.StockCode, iu.ID as UnitID, v.Name as CommodityType, v.FullItemName, v.TypeID , iu.Text as Unit, rd.ManufacturerID, id.BatchNo, id.NoOfPack,rd.ExpDate,id.NoOfPack- isnull(x.ReturnedTot,0) as IssuedQty, id.ID IssueDocID,m.Name as Manufacturer,
							  CASE WHEN (SELECT COUNT(*) from ItemManufacturer i where i.ItemID = v.ID) > 0 then 1 else 0 end as HasManufacturer, IsSelected = cast(1 as bit), IsReturnedStock=cast(1 as bit)
							  from 
                                        vwGetAllItems v 
                                            join IssueDoc id on id.ItemID=v.ID 
                                            join ReceiveDoc rd on rd.ID=id.RecievDocID 
                                            join Manufacturer m on m.ID = rd.ManufacturerID
                                            join ItemUnit iu on rd.UnitID = iu.ID
							  left join (select rd.ReturnedFromIssueDocID, Sum(rd.NoOfPack) ReturnedTot from ReceiveDoc rd Where rd.ReturnedStock=1
                                group by rd.ReturnedFromIssueDocID) as x on id.ID=x.ReturnedFromIssueDocID
							  where v.IsInHospitalList = 1 and (id.STVID in (select IsReprintOf from STVLog where ID = {0} ) or id.STVID = {0} ) 
                                    ORDER BY v.FullItemName",
                stvID, storeID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetItemsByReceiptInvoiceNoForSTVTransfer(int receiptInvoiceID)
        {
            var query = String.Format(@"select 
                                         v.ID,v.StockCode, iu.ID as UnitID, v.Name as CommodityType, v.FullItemName, v.TypeID , ui.[Text] as Unit, riDetail.ManufacturerID, riDetail.BatchNumber BatchNo, riDetail.Quantity NoOfPack,riDetail.Quantity InvoicedNoOfPack,riDetail.ExpiryDate ExpDate,riDetail.UnitPrice, riDetail.Margin, m.Name as Manufacturer,
							  CASE WHEN (SELECT COUNT(*) from ItemManufacturer i where i.ItemID = v.ID) > 0 then 1 else 0 end as HasManufacturer, IsSelected = cast(1 as bit), IsReturnedStock=cast(0 as bit)
							  from 
                                        vwGetAllItems v 
                                            join ReceiptInvoiceDetail riDetail on riDetail.ItemID = v.ID
                                            join Manufacturer m on m.ID = riDetail.ManufacturerID
                                            join UnitOfIssue ui on riDetail.UnitOfIssueID = ui.ID
                                            join ItemUnitBase iu on ui.ID = iu.UnitOfIssueID and iu.ItemID = riDetail.ItemID
                                    where riDetail.ReceiptInvoiceID = {0}
                                    ORDER BY v.FullItemName",
                receiptInvoiceID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetItemByPrimaryKey(int pk)
        {
            return String.Format("SELECT * FROM vwGetAllItems WHERE ID = {0}", pk);
        }

        [SelectQuery]
        public static string SelectCountAllItems()
        {
            return String.Format("SELECT * FROM vwGetAllItems WHERE IsInHospitalList = 1 AND Name = 'Drug'");
        }

        [SelectQuery]
        public static string SelectCountEdlItems()
        {
            return String.Format("SELECT * FROM vwGetAllItems WHERE IsInHospitalList = 1 AND EDL = 0 AND Name = 'Drug'");
        }

        [SelectQuery]
        public static string SelectGetEdlItems()
        {
            return String.Format("SELECT * FROM vwGetAllItems WHERE IsInHospitalList = 1 AND EDL = 0 AND Name = 'Drug'");
        }

        [SelectQuery]
        public static string SelectCountFreeItems()
        {
            return String.Format("SELECT * FROM vwGetAllItems WHERE IsInHospitalList = 1 AND IsFree = 1 AND Name = 'Drug'");
        }

        [SelectQuery]
        public static string SelectGetFreeItems()
        {
            return String.Format("SELECT * FROM vwGetAllItems WHERE IsInHospitalList = 1 AND IsFree = 1 AND Name = 'Drug'");
        }

        [SelectQuery]
        public static string SelectGetVitalItems()
        {
            return String.Format("SELECT * FROM vwGetAllItems WHERE IsInHospitalList = 1 AND VEN = 'V' AND Name = 'Drug'");
        }

        [SelectQuery]
        public static string SelectCountRefrigeratedItems(string storageType)
        {
            return String.Format("SELECT * FROM vwGetAllItems WHERE IsInHospitalList = 1 AND Name = 'Drug' AND StorageTypeID = {0}", storageType);
        }

        [SelectQuery]
        public static string SelectGetRefrigeratedItems()
        {
            return String.Format("SELECT * FROM vwGetAllItems WHERE IsInHospitalList = 1 AND Name = 'Drug' AND Refrigeratored = 1");
        }

        [SelectQuery]
        public static string SelectGetItemById(int itemId)
        {
            return String.Format("SELECT * FROM vwGetAllItems WHERE ID = {0}", itemId);
        }

        [SelectQuery]
        public static string SelectGetItemsBySubCategory(int subCategoryId)
        {
            return String.Format("SELECT * FROM vwGetItemsByCategory WHERE SubCategoryID = {0}  ORDER BY ItemName", subCategoryId);
        }

        [SelectQuery]
        public static string SelectGetItemsReceivedByBatch(int storeId)
        {
            return String.Format("SELECT * FROM vwGetReceivedItemsByBatch WHERE StoreId = {0} AND Name = 'Drug' ORDER BY ItemName", storeId);
        }

        [SelectQuery]
        public static string SelectGetCommoditiesReceivedByBatch(int storeId)
        {
            return String.Format("SELECT * FROM vwGetReceivedItemsByBatch WHERE StoreId = {0} AND Name = 'Supply' ORDER BY ItemName", storeId);
        }

        [SelectQuery]
        public static string SelectGetItemsReceivedByBatchByKeyword(string keyword, int storeId)
        {
            return String.Format("SELECT * FROM vwGetReceivedItemsByBatch WHERE StoreId = {1} AND Name='Drug' AND ItemName LIKE '{0}%' ORDER BY ID", keyword, storeId);
        }

        [SelectQuery]
        public static string SelectGetCommoditiesReceivedByBatchByKeyword(string keyword, int storeId)
        {
            return String.Format("SELECT * FROM vwGetReceivedItemsByBatch WHERE StoreId = {1} AND Name='Supply' AND ItemName LIKE '{0}%' ORDER BY ID", keyword, storeId);
        }

        [SelectQuery]
        public static string SelectGetItemsReceivedByBatchByCatId(int categoryId, int storeId)
        {
            return String.Format("select * from vwGetReceivedItemsByBatch where StoreId = {1} AND ID IN (Select ItemID from ProductsCategory Where SubCategoryID IN (Select ID from SubCategory where CategoryID = {0}))", categoryId, storeId);
        }

        [SelectQuery]
        public static string SelectGetItemsReceivedByBatchBySubCatId(int subCategoryId, int storeId)
        {
            return String.Format("select * from vwGetReceivedItemsByBatch where StoreId = {1} AND  ID IN (Select ItemID from ProductsCategory Where SubCategoryID = {0})", subCategoryId, storeId);
        }

        [SelectQuery]
        public static string SelectGetItemsIssuedByBatch(int storeId)
        {
            return String.Format("SELECT * FROM vwGetIssuedItemsByBatch Where StoreId = {0} ", storeId);
        }

        [SelectQuery]
        public static string SelectGetQuantityIssuedByBatch(string batchNo, int itemId, int storeId)
        {
            return String.Format("SELECT * FROM vwGetIssuedItemsByBatch WHERE BatchNo = '{0}' AND ID = {1} AND StoreId = {2}", batchNo, itemId, storeId);
        }

        [SelectQuery]
        public static string SelectGetQuantityIssuedByItemPerMonth(int month, int itemId, int storeId, int year)
        {
            return String.Format("SELECT SUM(Quantity) AS Quantity FROM IssueDoc WHERE (IsApproved = 1) AND (ItemID = {1}) AND (MONTH(Date) = {0} AND StoreId = {2} AND Year(Date) = {3})", month, itemId, storeId, year);
        }

        [SelectQuery]
        public static string SelectGetQuantityReceiveByItemPerMonth(int month, int itemId, int storeId, int year)
        {
            string query =
                String.Format(
                    "SELECT SUM(Quantity / QtyPerPack) AS Quantity FROM ReceiveDoc WHERE (ItemID = {1}) AND (StoreId = {2}) AND (MONTH(Date) = {0} AND Year(Date) = {3})",
                    month, itemId, storeId, year);
            return query;
        }

        [SelectQuery]
        public static string SelectGetCostIssuedByItemPerMonth(int month, int storeId, int year)
        {
            return String.Format("SELECT SUM(rd.UnitCost * id.NoOfPack) AS Cost FROM IssueDoc id Join receiveDoc rd on id.recievDocID = rd.ID WHERE (MONTH(id.Date) = {0} AND id.StoreId = {1} AND Year(id.Date) = {2})", month, storeId, year);
        }

        [SelectQuery]
        public static string SelectGetCostReceiveByItemPerMonth(int month, int storeId, int year)
        {
            return String.Format("SELECT SUM(UnitCost * NoOfPack) AS Cost FROM ReceiveDoc WHERE (StoreId = {1}) AND (MONTH(Date) = {0} AND Year(Date) = {2})", month, storeId, year);
        }

        [SelectQuery]
        public static string SelectGetLostQuantity(string batchNo, int itemId, int storeId)
        {
            return String.Format("SELECT * FROM vwGetLosses WHERE BatchNo = '{0}' AND ID = {1} AND StoreId = {2}", batchNo, itemId, storeId);
        }

        [SelectQuery]
        public static string SelectGetAdjustedQuantity(string batchNo, int itemId, int storeId)
        {
            return String.Format("SELECT * FROM vwGetAdjustments WHERE BatchNo = '{0}' AND ID = {1} AND StoreId = {2}", batchNo, itemId, storeId);
        }

        [SelectQuery]
        public static string SelectGetExpiredItemsByBatch(int modeID)
        {
            string query =
                String.Format(
                    "SELECT vw.StockCode,iu.Text as Unit,ma.Name as ManufacturerName, cast(rd.[EurDate] as date) as ReceivedDate,rd.[Date] as ReceivedDateEth,'' as Difference,acct.AccountName + ' - ' + acct.SubAccountName + ' - ' +  acct.ActivityName as Account,rd.NoOfPack as ReceivedQty, (rd.QuantityLeft / rd.QtyPerPack) as Quantity, rd.BatchNo, (rd.Cost * rd.QuantityLeft / rd.QtyPerPack) AS Cost, cast(rd.ExpDate as date) as ExpDate, rd.ID, vw.FullItemName FROM Receivedoc rd join vwAccounts acct on rd.StoreID=acct.ActivityID join vwGetAllItems vw on rd.ItemID = vw.ID join ItemUnit iu on iu.ID = rd.UnitID join Manufacturer ma on ma.ID= rd.ManufacturerId WHERE (rd.ExpDate <= GETDATE()) AND (rd.QuantityLeft > 0) AND ModeID = {0}",
                    modeID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetExpiredItemsByBatch(int modeID, int warehouseID) ////Added to filter by warehouse too.
        {
            string query =
                String.Format(
                    @"SELECT vw.StockCode,
                           iu.Text AS Unit,
                           ma.Name AS ManufacturerName,
                           cast(rd.[EurDate] as date) as ReceivedDate,rd.[Date] AS ReceivedDateEth,
                                '' AS Difference,
                                acct.AccountName + ' - ' + acct.SubAccountName + ' - ' + acct.ActivityName AS Account,
                                rd.NoOfPack AS ReceivedQty,
                                (rd.QuantityLeft / rd.QtyPerPack) AS Quantity,
                                rd.BatchNo,
                                (rd.Cost * rd.QuantityLeft / rd.QtyPerPack) AS Cost,
                                cast(rd.ExpDate AS date) AS ExpDate,
                                rd.ID,
                                vw.FullItemName
                    FROM Receivedoc rd
                    JOIN vwAccounts acct ON rd.StoreID=acct.ActivityID
                    JOIN vwGetAllItems vw ON rd.ItemID = vw.ID
                    JOIN ItemUnit iu ON iu.ID = rd.UnitID
                    JOIN Manufacturer ma ON ma.ID= rd.ManufacturerId
                    JOIN PhysicalStore ps ON ps.ID = rd.PhysicalStoreID
                    WHERE (rd.ExpDate <= GETDATE())
                      AND (rd.QuantityLeft > 0)
                      AND ModeID ={0}
                      AND ps.PhysicalStoreTypeID ={1}
                     AND rd.EurDate > (select StartDate from FiscalYear where isCurrent = 1)",
                    modeID,warehouseID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetExpiredItems(int modeID)
        {
            string query =
                String.Format(
                    @"SELECT vw.StockCode, iu.Text as Unit,ma.Name as ManufacturerName, SUM(QuantityLeft / QtyPerPack) as Quantity, min(rd.BatchNo) + ' - ' + max(rd.BatchNo) as BatchNo , 
                        SUM (Cost * QuantityLeft / QtyPerPack) AS Cost, Convert( varchar, min(ExpDate),101) + ' - ' + Convert( varchar, max(ExpDate), 101) as ExpDate, 
                        rd.ID, FullItemName 
                        FROM ReceiveDoc rd 
                            join vwAccounts acct on rd.storeID=acct.ActivityID 
                            join vwGetAllItems vw on rd.ItemID = vw.ID 
                            join ItemUnit iu on iu.ID = rd.UnitID 
                            join Manufacturer ma on ma.ID= rd.ManufacturerId
                        WHERE (rd.ExpDate <= GETDATE()) AND rd.QuantityLeft > 0 and acct.ModeID = {0}
                        group by rd.ID, vw.FullItemName,vw.StockCode,iu.Text", modeID);
            return query;
        }

        [SelectQuery]

        public static string SelectGetExpiredItems(int modeID ,int warehouseID) //Added to filter by warehouse too.
        {
            string query =
                String.Format(
                    @"SELECT vw.StockCode,
                       iu.Text AS Unit,
                       SUM(QuantityLeft / QtyPerPack) AS Quantity,
                       min(rd.BatchNo) + ' - ' + max(rd.BatchNo) AS BatchNo ,
                       SUM (Cost * QuantityLeft / QtyPerPack) AS Cost,
                           Convert(varchar, min(ExpDate),101) + ' - ' + Convert(varchar, max(ExpDate), 101) AS ExpDate,
                           rd.ID,
                           FullItemName
                FROM ReceiveDoc rd
                JOIN vwAccounts acct ON rd.storeID=acct.ActivityID
                JOIN vwGetAllItems vw ON rd.ItemID = vw.ID
                JOIN ItemUnit iu ON iu.ID = rd.UnitID
                JOIN PhysicalStore ps ON rd.PhysicalStoreID = ps.ID
                WHERE  (rd.ExpDate <= GETDATE())
                  AND rd.QuantityLeft > 0
                  AND acct.ModeID = {0}
                  AND ps.PhysicalStoreTypeID ={1}
                  AND rd.EurDate > (select StartDate from FiscalYear where isCurrent = 1)
                GROUP BY rd.ID,
                         vw.FullItemName,
                         vw.StockCode,
                         iu.[Text]", modeID, warehouseID);
			 return query;
			        }
        public static string SelectGetExpiredItemsByReceivedDate(int modeID ,DateTime datefrom ,DateTime dateto ,int warehouseID) // Added to filter by date from date - to date
        {
            string query =
                String.Format(
                    "SELECT vw.StockCode,iu.Text as Unit,ma.Name as ManufacturerName, cast(rd.[EurDate] as date) as ReceivedDate," +
                    "rd.[Date] as ReceivedDateEth,'' as Difference,acct.AccountName + ' - ' + acct.SubAccountName + ' - ' +  acct.ActivityName as Account," +
                    "rd.NoOfPack as ReceivedQty, (rd.QuantityLeft / rd.QtyPerPack) as Quantity, rd.BatchNo, " +
                    "(rd.Cost * rd.QuantityLeft / rd.QtyPerPack) AS Cost, " +
                    "cast(rd.ExpDate as date) as ExpDate, rd.ID, " +
                    "vw.FullItemName FROM Receivedoc rd " +
                    "join vwAccounts acct on rd.StoreID=acct.ActivityID " +
                    "join vwGetAllItems vw on rd.ItemID = vw.ID " +
                    "join ItemUnit iu on iu.ID = rd.UnitID " +
                    "join Manufacturer ma on ma.ID= rd.ManufacturerId join PhysicalStore ps on ps.ID= rd.PhysicalStoreID  " +
                    "WHERE (rd.ExpDate <= GETDATE()) AND (rd.QuantityLeft > 0) AND ModeID = {0} and cast(rd.[EurDate] as date) >= '{1}' and cast(rd.[EurDate] as date) <= '{2}' and ps.PhysicalStoreTypeID = {3}",
                    modeID ,datefrom ,dateto ,warehouseID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetExpiredItemsByBatchByKeywordByStore(int storeId, string keyword)
        {
            return String.Format("SELECT (QuantityLeft / QtyPerPack) as QuantityLeft, (Cost * QuantityLeft / QtyPerPack) AS Price, * FROM vwGetReceivedItemsByBatch WHERE ( Name = 'Drug') AND (ExpDate <= GETDATE()) AND (QuantityLeft > 0) AND ItemName LIKE '{1}%' AND StoreId = {0} ORDER BY Price DESC", storeId, keyword);
        }

        [SelectQuery]
        public static string SelectGetExpiredItemsByBatchByKeyword(string keyword)
        {
            return String.Format("SELECT (QuantityLeft / QtyPerPack) as QuantityLeft, (Cost * QuantityLeft / QtyPerPack) AS Price, * FROM vwGetReceivedItemsByBatch WHERE ( Name = 'Drug') AND (ExpDate <= GETDATE()) AND (QuantityLeft > 0) AND ItemName LIKE '{0}%' ORDER BY Price DESC", keyword);
        }

        [SelectQuery]
        public static string SelectGetExpiredSupplyByBatchByKeywordByStore(int storeId, string keyword)
        {
            return String.Format("SELECT (QuantityLeft / QtyPerPack) as QuantityLeft, (Cost * QuantityLeft / QtyPerPack) AS Price, * FROM vwGetReceivedItemsByBatch WHERE ( Name = 'Supply') AND (ExpDate <= GETDATE()) AND (Out = 0) AND ItemName LIKE '{1}%' AND StoreId = {0} ORDER BY Price DESC", storeId, keyword);
        }

        [SelectQuery]
        public static string SelectGetExpiredSupplyByBatchByKeyword(string keyword)
        {
            return String.Format("SELECT (QuantityLeft / QtyPerPack) as QuantityLeft, (Cost * QuantityLeft / QtyPerPack) AS Price, * FROM vwGetReceivedItemsByBatch WHERE ( Name = 'Supply') AND (ExpDate <= GETDATE()) AND (Out = 0) AND ItemName LIKE '{0}%' ORDER BY Price DESC", keyword);
        }

        [SelectQuery]
        public static string SelectCountExpiredItemsAndAmount(int storeId)
        {
            return String.Format("Select Count(DISTINCT ItemID) AS Qty , Sum( (QuantityLeft / QtyPerPack) * Cost ) AS Price From ReceiveDoc where QuantityLeft > 0 And ExpDate < GETDATE() AND StoreID = {0}", storeId);
        }

        [SelectQuery]
        public static string SelectGetExpiredSupplysByBatch(int storeId)
        {
            return String.Format("SELECT *,(Cost * QuantityLeft/ QtyPerPack) AS Price FROM vwGetReceivedItemsByBatch WHERE ( Name = 'Supply') AND (ExpDate <= GETDATE()) AND (Out = 0) AND StoreId = {0} ORDER BY Price DESC", storeId);
        }

        [SelectQuery]
        public static string SelectGetExpiredItemsActivity(int activityId)
        {
            return String.Format(
                @" select rd.ID ReceiveDocID
                        , rd.ItemID
	                    , rd.UnitID
	                    , vw.FullItemName
                        , NoOfPack Pack
						, m.Name Manufacturer
						, m.CountryOfOrigin
                        , QuantityLeft StockOnHand
                        , rd.QtyPerPack
	                    , QuantityLeft / QtyPerPack as Quantity
	                    , BatchNo
	                    , (QuantityLeft / QtyPerPack) * Cost as Amount
	                    , iu.Text as Unit 
                        , ExpDate ExpiryDate
                        , rd.StoreID
                    from ReceiveDoc rd 
	                    join vwGetAllItems vw on rd.ItemID = vw.ID join ItemUnit iu on rd.UnitID = iu.ID
                        join ReceivePallet rp on rd.ID = rp.ReceiveID 
                        join PalletLocation pl on rp.PalletLocationID = pl.ID
                        join Shelf sh on pl.ShelfID = sh.ID
                        join PhysicalStore ps on sh.StoreID = ps.ID 
                        join PhysicalStoreType pt on ps.PhysicalStoreTypeID = pt.ID
                        join Cluster c on pt.ClusterID = c.ID 
						Join Manufacturer m on rd.ManufacturerId = m.ID
                    where ExpDate < GetDate() and ExpDate is not null and QuantityLeft > 0 and rd.StoreID = {0}
                    order by vw.FullItemName, Unit, ExpiryDate, Quantity", activityId);
        }

        [SelectQuery]
        public static string SelectGetExpiredItemsById(int storeId, int itemId)
        {
            return String.Format("SELECT * FROM vwGetReceivedItemsByBatch WHERE (ExpDate <= GETDATE()) AND (QuantityLeft > 0) AND StoreId = {0} AND ID = {1} ORDER BY ID", storeId, itemId);
        }

        [SelectQuery]
        public static string SelectGetExpiredQtyItemsById(int itemId, int storeId)
        {
            return String.Format("SELECT * FROM vwGetReceivedItemsByBatch WHERE (ExpDate <= GETDATE()) AND (QuantityLeft > 0) AND StoreId = {0} AND ID = {1} ", storeId, itemId);
        }

        [SelectQuery]
        public static string SelectGetExpiredQtyAmountItemsById(int itemId, int storeId)
        {
            return String.Format("SELECT * ,(Cost * QuantityLeft) AS Price  FROM vwGetReceivedItemsByBatch WHERE (ExpDate <= GETDATE()) AND (Out = 0) AND StoreId = {0} AND ID = {1} ", storeId, itemId);
        }

        [SelectQuery]
        public static string SelectGetNearlyExpiredQtyItemsById(int itemId, int storeId)
        {
            return String.Format("SELECT * FROM vwGetReceivedItemsByBatch WHERE StoreId = {0} AND (ExpDate BETWEEN GETDATE() AND GETDATE() + 185 ) AND (Out = 0) AND ID = {1}", storeId, itemId);
        }

        [SelectQuery]
        public static string SelectGetNearlyExpiredQtyAmountItemsById(int itemId, int storeId)
        {
            return String.Format("SELECT *,(Cost * QuantityLeft) AS Price FROM vwGetReceivedItemsByBatch WHERE StoreId = {0} AND (ExpDate BETWEEN GETDATE() AND GETDATE() + 185 ) AND (Out = 0) AND ID = {1}", storeId, itemId);
        }

        [SelectQuery]
        public static string SelectCountNearlyExpiredQtyAmount(int storeId)
        {
            return String.Format("SELECT Count(DISTINCT ID) AS Qty,Sum(QuantityLeft/QtyPerPack * Cost) AS Price FROM vwGetReceivedItemsByBatch WHERE StoreId = {0} AND (ExpDate BETWEEN GETDATE() AND GETDATE() + 185 ) AND (QuantityLeft > 0) ", storeId);
        }

        [SelectQuery]
        public static string SelectGetLastIssuedDate(int itemId, int storeId)
        {
            return String.Format("SELECT TOP (1) Date FROM IssueDoc WHERE (StoreId = {1}) AND (ItemID = {0})ORDER BY Date DESC", itemId, storeId);
        }

        [SelectQuery]
        public static string SelectGetLastReceiveDate(int itemId, int storeId)
        {
            return String.Format("SELECT TOP (1) Date FROM ReceiveDoc WHERE (StoreID = {1}) AND (ItemID = {0})ORDER BY Date DESC", itemId, storeId);
        }

        [SelectQuery]
        public static string SelectGetItemsExcludeNeverReceived()
        {
            return String.Format("SELECT * FROM  dbo.vwGetAllItems WHERE (ID IN (SELECT ItemID FROM  dbo.ReceiveDoc)) AND (IsInHospitalList = 1) AND Name = 'Drug' ORDER BY ItemName");
        }

        [SelectQuery]
        public static string SelectGetItemsExcludeNeverReceivedByStoreId(int storeId)
        {
            return String.Format("SELECT * FROM  dbo.vwGetAllItems WHERE (ID IN (SELECT ItemID FROM  dbo.ReceiveDoc WHERE (StoreID = {0}))) AND (IsInHospitalList = 1) AND Name = 'Drug' ORDER BY ItemName", storeId);
        }

        [SelectQuery]
        public static string SelectExcludeNeverReceivedItemsByKeyword(string itemName)
        {
            return String.Format("SELECT * FROM  dbo.vwGetAllItems WHERE ItemName LIKE '{0}%' AND (ID IN (SELECT ItemID FROM  dbo.ReceiveDoc)) AND (IsInHospitalList = 1) AND Name = 'Drug' ORDER BY ItemName", itemName);
        }

        [SelectQuery]
        public static string SelectExcludeNeverReceivedItemsByKeywordByStoreId(int storeId, string itemName)
        {
            return String.Format("SELECT * FROM  dbo.vwGetAllItems WHERE ItemName LIKE '{1}%' AND(ID IN (SELECT ItemID FROM  dbo.ReceiveDoc WHERE (StoreID = {0}))) AND (IsInHospitalList = 1) AND Name = 'Drug' ORDER BY ItemName", storeId, itemName);
        }

        [SelectQuery]
        public static string SelectHasTransactions(int itemId)
        {
            return String.Format("select ID,ItemID from IssueDoc where ItemID = {0} union select ID,ItemID from ReceiveDoc where ItemID = {0}", itemId);
        }

         [SelectQuery]
        public static string SelectLoadItemsByStorageType(string storageType)
        {
            string query =
                String.Format(
                    "SELECT *, ( ItemName + ' - ' + DosageForm + ' - ' + Strength) as DrugName FROM vwGetAllItems Where Name = 'Drug' and StorageTypeID = {0} ORDER BY ItemName",
                    storageType);
            return query;
        }

        [SelectQuery]
        public static string SelectGetNextItemId()
        {
            string query = "select Max(ID) as MaxTop from Items";
            return query;
        }

        [FilterQuery]
        public static string GetSelectClauseFor_GetIssueByReceivingUnits(string @select, string institutionName, int index)
        {
            return String.Format("{0}, r{2}.Quantity as [{1}]", @select, institutionName, index);
        }

        [FilterQuery]
        public static string GetFromClauseFor_GetIssueByReceivingUnits(int instID, int index ,int storeid=0)
        {
            return String.Format(" left join (select id.ItemID as ID, sum(id.Quantity/id.QtyPerPack) Quantity , Max(id.QtyPerPack) QtyPerPack from  IssueDoc id where ReceivingUnitID = {0}{2} group by id.ItemID) r{1} on i.ID = r{1}.ID", instID, index,storeid==0?"":string.Format("and id.storeid ={0}",storeid));
        }
        [FilterQuery]
        public static string GetFromClauseFor_GetIssueByReceivingUnitsFilterByDateRange(int instID, int index,DateTime sDate,DateTime edate,int storeid)
        {
            return String.Format(@" left join (select id.ItemID as ID, sum(id.Quantity/id.QtyPerPack) Quantity , Max(id.QtyPerPack) QtyPerPack from  IssueDoc id where dateadd(dd,0, datediff(dd,0, id.[EurDate]))>='{2}'AND dateadd(dd,0, datediff(dd,0, id.[EurDate]))<='{3}' and ReceivingUnitID = {0} AND id.storeid={4}   group by id.ItemID) r{1} on i.ID = r{1}.ID", instID, index, sDate, edate,storeid);
        }
        [SelectQuery]
        public static string SelectGetIssuesByReceivingUnit(int type, string @select, string theFrom)
        {
            string query =
                String.Format(
                    "select i.ID,i.FullItemName {0} from vwGetAllItems i {1} where i.TypeID = '{2}' and i.IsInHospitalList = 1 order by i.FullItemName",
                    @select, theFrom, type);
            return query;
        }

        [SelectQuery]
        public static string SelectGetIssuesByReceivingUnitFaster(int type)
        {
            string query =
                String.Format(
                    "select i.ID,i.FullItemName from vwGetAllItems i where i.TypeID = '{0}' and i.IsInHospitalList = 1 and i.ID in (select ItemID from IssueDoc) order by i.FullItemName",
                    type);
            return query;
        }

        [SelectQuery]
        public static string SelectGetIssuesByReceivingUnitFasterIssueQuery(int itemID, int rusId)
        {
            string issueQuery =
                String.Format(
                    "select i.ID, sum(id.Quantity/id.QtyPerPack) Quantity , Max(id.QtyPerPack) QtyPerPack from  IssueDoc id join vwGetAllItems i on id.ItemID=i.ID where i.ID = {0} and ReceivingUnitID={1} group by i.ID",
                    itemID, rusId);
            return issueQuery;
        }

        [SelectQuery]
        public static string SelectGetIssuedItems()
        {
            string query = String.Format("select distinct ItemID as ID from IssueDoc");
            return query;
        }

        [SelectQuery]
        public static string SelectGetRecievedItems()
        {
            string query = String.Format("select distinct ItemID as ID from ReceiveDoc");
            return query;
        }

        [SelectQuery]
        public static string SelectGetNearlyExpiredItemsByBatch(int modeID, int months, int category, int warehouseID)
        {
            string query =
                String.Format(
                    @"select rd.ItemID, vw.FullItemName,iu.[Text] as Unit, QuantityLeft / QtyPerPack as Quantity, BatchNo , rd.UnitCost as UnitPrice,(QuantityLeft / QtyPerPack) * Cost as Cost, Convert(varchar,ExpDate,101) as ExpDate 
                                           from ReceiveDoc rd 
                                           join vwGetAllItems vw on rd.ItemID = vw.ID 
                                           join ItemUnit iu on rd.UnitID = iu.ID 
                                           join vwAccounts acct on rd.StoreID=acct.ActivityID 
                                           join PhysicalStore ps on rd.PhysicalStoreID=ps.ID
                                           where ExpDate > GetDate() and ExpDate < DATEADD(MONTH,{1},GetDate()) and ExpDate is not null 
                                           and QuantityLeft > 0 and acct.ModeID={0} and vw.TypeID = {2} and ps.PhysicalStoreTypeID ={3} order by ExpDate DESC, vw.FullItemName",
                    modeID, months, category ,warehouseID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetNearlyExpiredItems(int modeID, int months, int category ,int warehouseID)
        {
            string query =
                String.Format(
                    @"select rd.ItemID, vw.FullItemName,iu.[Text] as Unit, sum(QuantityLeft / QtyPerPack) as Quantity, max(BatchNo) as BatchNo  , rd.UnitCost as UnitPrice , Sum((QuantityLeft / QtyPerPack) * Cost) as Cost, Convert(varchar,MIN(ExpDate) ,101) + ' - '  +  convert(varchar,MAX(ExpDate) ,101) as ExpDate 
                                            from ReceiveDoc rd 
                                            join vwGetAllItems vw on rd.ItemID = vw.ID 
                                            join ItemUnitBase iu on rd.UnitID = iu.ID 
                                            join vwAccounts acct on rd.StoreID=acct.ActivityID 
                                            join PhysicalStore ps on rd.PhysicalStoreID=ps.ID
                                            where ExpDate > GetDate() and ExpDate < DATEADD(MONTH,{1},GetDate()) and ExpDate is not null and QuantityLeft > 0 and acct.ModeID={0} and vw.TypeID = {2} and ps.PhysicalStoreTypeID ={3}
                                            group by rd.ItemID, vw.FullItemName, iu.ID,iu.[Text],rd.UnitCost order by ExpDate DESC, vw.FullItemName",
                    modeID, months, category ,warehouseID);
            return query;
        }

        [SelectQuery]
        public static string SelectIsMovingAverage(int itemId, int supplierId)
        {
            string query =
                String.Format("select ID from ReceiveDoc where ItemID = {0} and SellingPrice is not null and SupplierID = {1}",
                    itemId, supplierId);
            return query;
        }

        [SelectQuery]
        public static string SelectGetNearExpiryBreakdown(int itemType, int modeID)
        {
            string query =
                String.Format(
                    @"select v.StockCode,v.FullItemName, PivotTable.* from (select ItemID, sum(QuantityLeft / QtyPerPack) as Quantity, (DateDiff(Month,GetDate(),ExpDate)) as ExpiryMonth from ReceiveDoc rd join vwAccounts acct on rd.StoreID=acct.ActivityID 
												where ExpDate > GetDate() and QuantityLeft > 0 and acct.ModeID={1} 
												Group by ItemID,(DateDiff(Month,GetDate(),ExpDate)))
												PivotData
												pivot 
												(
													sum(Quantity)
													For [ExpiryMonth]
													in 
													([0],[1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12])
												)
												as PivotTable join vwGetAllitems v on PivotTable.ItemID = v.ID where v.TypeID = {0} order by v.FullItemName",
                    itemType, modeID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetNearExpiryBreakdown(int itemType, int modeID, int warehouseID) //Added to filter near expiry products by warehouse
        {
            string query =
                String.Format(
                    @"select v.StockCode,v.FullItemName, PivotTable.* from (select ItemID, sum(QuantityLeft / QtyPerPack) as Quantity, (DateDiff(Month,GetDate(),ExpDate)) as ExpiryMonth
                      from ReceiveDoc rd join vwAccounts acct on rd.StoreID=acct.ActivityID join physicalStore ps on rd.PhysicalStoreID =ps.ID
												where ExpDate > GetDate() and QuantityLeft > 0 and acct.ModeID={1} and ps.PhysicalStoreTypeID ={2}
												Group by ItemID,(DateDiff(Month,GetDate(),ExpDate)))
												PivotData
												pivot 
												(
													sum(Quantity)
													For [ExpiryMonth]
													in 
													([0],[1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12])
												)
												as PivotTable join vwGetAllitems v on PivotTable.ItemID = v.ID where v.TypeID = {0} order by v.FullItemName",
                    itemType, modeID, warehouseID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetItemPriceList(int storeID)
        {
            string query =
                String.Format(
                    @"select distinct itm.FullItemName [Particular],iu.Text Unit,rd.RefNo GRVNo, rd.Cost [UnitCost], rd.SellingPrice [UnitsSellingBeforeFormat], 
											case when rd.ExpDate is not null then convert(varchar,rd.ExpDate,101) else 'NA' end ExpDate,s.CompanyName [Supplier], sr.StoreName as Program,m.Name as Manufacturer, tp.Name Category 
											from ReceiveDoc rd join Manufacturers m on rd.ManufacturerId = m.ID join vwGetAllItems itm on rd.ItemID=itm.ID
											join ItemUnit iu on rd.UnitID=iu.ID join ReceivePallet rp on rp.ReceiveID=rd.ID
											join PalletLocation pl on rp.PalletID=pl.PalletID
											join Supplier s on s.ID=rd.SupplierID join Stores sr on sr.ID=rd.StoreID
											join Type tp on itm.TypeID=tp.ID
											where rd.StoreID = {0}
								group by itm.FullItemName,iu.Text,rd.SellingPrice,rd.ExpDate,rd.Cost,s.CompanyName,sr.StoreName,tp.Name,rd.RefNo,m.Name",
                    storeID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetItemPriceList(DateTime fromDate, DateTime toDate, int storeID)
        {
            string query =
                String.Format(
                    @"select distinct itm.FullItemName [Particular],iu.Text Unit,rd.RefNo GRVNo,rd.Cost [UnitCost], rd.SellingPrice [UnitsSellingBeforeFormat], 
							case when rd.ExpDate is not null then convert(varchar,rd.ExpDate,101) else 'NA' end ExpDate,s.CompanyName [Supplier],m.Name as Manufacturer, sr.StoreName as Program, tp.Name Category 
							from ReceiveDoc rd join Manufacturers m on rd.ManufacturerId = m.ID join vwGetAllItems itm on rd.ItemID=itm.ID
							join ItemUnit iu on rd.UnitID=iu.ID join ReceivePallet rp on rp.ReceiveID=rd.ID
							join PalletLocation pl on rp.PalletID=pl.PalletID
							join Supplier s on s.ID=rd.SupplierID join Stores sr on sr.ID=rd.StoreID
							join Type tp on itm.TypeID=tp.ID
							where convert(datetime,floor(convert(float,rd.EurDate))) between '{0}' and '{1}' and  rd.StoreID = {2}
							group by itm.FullItemName,iu.Text,rd.SellingPrice,rd.ExpDate,rd.Cost,m.Name,s.CompanyName,sr.StoreName,tp.Name,rd.RefNo",
                    fromDate, toDate, storeID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetItemPriceList(DateTime date, int storeID)
        {
            string query =
                String.Format(
                    @"select distinct itm.FullItemName [Particular],iu.Text Unit,rd.RefNo GRVNo,rd.Cost [UnitCost], rd.SellingPrice [UnitsSellingBeforeFormat], 
							case when rd.ExpDate is not null then convert(varchar,rd.ExpDate,101) else 'NA' end ExpDate,s.CompanyName [Supplier],m.Name as Manufacturer, sr.StoreName as Program, tp.Name Category 
							from ReceiveDoc rd join Manufacturers m on rd.ManufacturerId = m.ID  join vwGetAllItems itm on rd.ItemID=itm.ID
							join ItemUnit iu on rd.UnitID=iu.ID join ReceivePallet rp on rp.ReceiveID=rd.ID
							join PalletLocation pl on rp.PalletID=pl.PalletID
							join Supplier s on s.ID=rd.SupplierID join Stores sr on sr.ID=rd.StoreID
							join Type tp on itm.TypeID=tp.ID
							where convert(datetime,floor(convert(float,rd.EurDate))) = convert(datetime,floor(convert(float,convert(datetime,'{0}')))) and rd.StoreID = {1}
							group by itm.FullItemName,iu.Text,rd.SellingPrice,rd.ExpDate,rd.Cost,m.Name,s.CompanyName,sr.StoreName,tp.Name,rd.RefNo",
                    date, storeID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetItemPriceListByManufacturer(int storeID)
        {
            string query =
                String.Format(@"select distinct itm.FullItemName [Particular],iu.Text Unit,rd.SellingPrice [UnitsSellingBeforeFormat],case when rd.ExpDate is not null then convert(varchar,rd.ExpDate,101) else 'NA' end ExpDate
											from ReceiveDoc rd join Manufacturers m on rd.ManufacturerId = m.ID join vwGetAllItems itm on rd.ItemID=itm.ID
											join ItemUnit iu on rd.UnitID=iu.ID 
											join Supplier s on s.ID=rd.SupplierID join Stores sr on sr.ID=rd.StoreID
											join Type tp on itm.TypeID=tp.ID
											where rd.StoreID = {0}
											group by itm.FullItemName,iu.Text,rd.SellingPrice,rd.ExpDate,s.CompanyName,sr.StoreName,tp.Name,rd.RefNo
											order by s.CompanyName,itm.FullItemName", storeID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetItemPriceListByManufacturer(DateTime fromDate, DateTime toDate, int storeID)
        {
            string query =
                String.Format(@"select distinct itm.FullItemName [Particular],iu.Text Unit,rd.SellingPrice [UnitsSellingBeforeFormat],case when rd.ExpDate is not null then convert(varchar,rd.ExpDate,101) else 'NA' end ExpDate,s.CompanyName [Supplier]
											from ReceiveDoc rd join Manufacturers m on rd.ManufacturerId = m.ID join vwGetAllItems itm on rd.ItemID=itm.ID
											join ItemUnit iu on rd.UnitID=iu.ID 
											join Supplier s on s.ID=rd.SupplierID join Stores sr on sr.ID=rd.StoreID
											join Type tp on itm.TypeID=tp.ID
											where convert(datetime,floor(convert(float,rd.EurDate))) between '{0}' and '{1}' and  rd.StoreID = {2}
											group by itm.FullItemName,iu.Text,rd.SellingPrice,rd.ExpDate,s.CompanyName,sr.StoreName,tp.Name,rd.RefNo
											order by s.CompanyName,itm.FullItemName", fromDate, toDate, storeID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetItemPriceListByManufacturer(DateTime date, int storeID)
        {
            string query =
                String.Format(@"select distinct itm.FullItemName [Particular],iu.Text Unit,rd.SellingPrice [UnitsSellingBeforeFormat],case when rd.ExpDate is not null then convert(varchar,rd.ExpDate,101) else 'NA' end ExpDate,s.CompanyName [Supplier]
											from ReceiveDoc rd join Manufacturers m on rd.ManufacturerId = m.ID join vwGetAllItems itm on rd.ItemID=itm.ID
											join ItemUnit iu on rd.UnitID=iu.ID 
											join Supplier s on s.ID=rd.SupplierID join Stores sr on sr.ID=rd.StoreID
											join Type tp on itm.TypeID=tp.ID
											where convert(datetime,floor(convert(float,rd.EurDate))) = convert(datetime,floor(convert(float,convert(datetime,'{0}')))) and rd.StoreID = {1}
											group by itm.FullItemName,iu.Text,rd.SellingPrice,rd.ExpDate,s.CompanyName,sr.StoreName,tp.Name,rd.RefNo
											order by s.CompanyName,itm.FullItemName", date, storeID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetItemsByCommodityTypeForTransferToHub(int StoreID)
        {
            var query =
                String.Format(@"select vw.ID,vw.FullItemName,iu.text Unit,IsSelected = CAST (0 as Bit),iu.ID UnitID,vw.TypeID,rd.StoreID
													from vwGetAllItems vw 
														Join ReceiveDoc rd on rd.ItemID = vw.ID
				                                        Join Receipt r on r.ID = rd.ReceiptID
				                                        Join ReceiptType rt on r.ReceiptTypeID = rt.ID
				                                        join ReceiveDocConfirmation rdc on rdc.ReceiveDocID =rd.ID 
														Join ReceivePallet rp on rp.ReceiveID = rd.ID join ItemUnit iu on rd.UnitID=iu.ID 
													where rd.StoreID = {0} 
                                                          AND (rdc.ReceiptConfirmationStatusID = 
															  (Case When rt.ReceiptTypeCode = 'DN' 
																	   Then (Select ID From ReceiptConfirmationStatus Where ReceiptConfirmationStatusCode = 'GRNFP')
																	Else (Select ID From ReceiptConfirmationStatus Where ReceiptConfirmationStatusCode = 'GRVP')
																	End
															  ))
													Group by vw.ID,vw.FullItemName,iu.text,iu.ID,vw.TypeID,rd.StoreID
													Having Sum((rp.Balance - rp.ReservedStock)/QtyPerPack) > 0
													Order by FullItemName", StoreID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetItemsByCommodityTypeForTransferToHubByCommodity(int commodityType, int StoreID)
        {
            var query =
                String.Format(@"select vw.ID,vw.FullItemName,iu.text Unit,IsSelected = CAST (0 as Bit),iu.ID UnitID,vw.TypeID,rd.StoreID
													from vwGetAllItems vw 
														Join ReceiveDoc rd on rd.ItemID = vw.ID 
														Join ReceivePallet rp on rp.ReceiveID = rd.ID join ItemUnit iu on rd.UnitID=iu.ID 
													where rd.StoreID = {1} and vw.TypeID = '{0}'
													Group by vw.ID,vw.FullItemName,iu.text,iu.ID,vw.TypeID,rd.StoreID
													Having Sum((rp.Balance - rp.ReservedStock)/QtyPerPack) > 0
												 ORDER BY FullItemName",
                    commodityType, StoreID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetItemsByCommodityTypeForTransferByPhysicalStore(int StoreID, int PhysicalStoreID)
        {
            var query =
                String.Format(@"select vw.ID,vw.FullItemName,iu.text Unit,IsSelected = CAST (0 as Bit),iu.ID UnitID,vw.TypeID,rd.StoreID
													from vwGetAllItems vw 
														Join ReceiveDoc rd on rd.ItemID = vw.ID
			                                            Join Receipt r on r.ID = rd.ReceiptID
			                                            Join ReceiptType rt on r.ReceiptTypeID = rt.ID
			                                            join ReceiveDocConfirmation rdc on rdc.ReceiveDocID =rd.ID 
														Join ReceivePallet rp on rp.ReceiveID = rd.ID join ItemUnit iu on rd.UnitID=iu.ID
                                                        Join vwPallet vp on vp.PalletID = rp.PalletID 
													where rd.StoreID = {0} and PhyicalStoreID = {1} 
                                                               AND (rdc.ReceiptConfirmationStatusID = 
													                    (Case When rt.ReceiptTypeCode = 'DN' 
															                    Then (Select ID From ReceiptConfirmationStatus Where ReceiptConfirmationStatusCode = 'GRNFP')
														                    Else (Select ID From ReceiptConfirmationStatus Where ReceiptConfirmationStatusCode = 'GRVP')
														                    End
													                    ))
													Group by vw.ID,vw.FullItemName,iu.text,iu.ID,vw.TypeID,rd.StoreID
													Having Sum((rp.Balance - rp.ReservedStock)/QtyPerPack) > 0
													Order by FullItemName", StoreID, PhysicalStoreID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetItemsByCommodityTypeForTransferByPhysicalStoreByCommodity(int commodityType, int StoreID, int PhysicalStoreID)
        {
            var query =
                String.Format(@"select vw.ID,vw.FullItemName,iu.text Unit,IsSelected = CAST (0 as Bit),iu.ID UnitID,vw.TypeID,rd.StoreID
													from vwGetAllItems vw 
														Join ReceiveDoc rd on rd.ItemID = vw.ID 
														Join ReceivePallet rp on rp.ReceiveID = rd.ID join ItemUnit iu on rd.UnitID=iu.ID 
												          Join vwPallet vp on vp.PalletID = rp.PalletID 
													where rd.StoreID = {1} and PhyicalStoreID = {2} and vw.TypeID = '{0}'
													Group by vw.ID,vw.FullItemName,iu.text,iu.ID,vw.TypeID,rd.StoreID
													Having Sum((rp.Balance - rp.ReservedStock)/QtyPerPack) > 0
												 ORDER BY FullItemName",
                    commodityType, StoreID, PhysicalStoreID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetItemByIdForTransfer(int ItemID, int unitID, int StoreID, int PhysicalStoreID)
        {
            string query = "";
            query =
                String.Format(
                    @"select pl.ID as LocationID,rp.ID as ReceivingLocationID,rd.StoreID,(rp.Balance - rp.reservedStock)/QtyPerPack as Packs,QtyPerPack,rd.Cost as UnitPrice, rd.Margin Margin ,rd.ID as ReceiveDocID,vw.FullItemName, vw.StockCode, m.ID as ManufacturerID , m.Name as Manufacturer,iu.Text Unit,rp.Balance,pl.Label as Location,s.CompanyName as Supplier,st.StoreName as account,rd.BatchNo,  rd.ExpDate,vw.ID as ItemID,iu.ID UnitID  from vwGetAllItems vw 
                            Join receivedoc rd on rd.ItemID = vw.ID 
							Join Receipt r on r.ID = rd.ReceiptID
							Join ReceiptType rt on r.ReceiptTypeID = rt.ID
							join ReceiveDocConfirmation rdc on rdc.ReceiveDocID =rd.ID  
                            join receivepallet rp on rd.ID=rp.ReceiveID join palletlocation pl on pl.PalletID=rp.PalletID join manufacturers m on m.ID=rd.ManufacturerID join Supplier s on s.ID=rd.SupplierID join Stores st on st.ID = rd.StoreID join ItemUnit iu on rd.UnitID=iu.ID 
                                                join shelf sh on sh.ID =  pl.ShelfID Join vwPallet vp on vp.PalletLocationID = pl.ID 
                                        where (rp.Balance - rp.reservedStock)/QtyPerPack > 0 
                                                        	AND (rdc.ReceiptConfirmationStatusID = 
																			  (Case When rt.ReceiptTypeCode = 'DN' 
																					   Then (Select ID From ReceiptConfirmationStatus Where ReceiptConfirmationStatusCode = 'GRNFP')
																					Else (Select ID From ReceiptConfirmationStatus Where ReceiptConfirmationStatusCode = 'GRVP')
																					End
																			  ))
                                                  and rd.itemID ={0} and iu.ID = {1} and st.ID = {2} and vp.PhyicalStoreID ={3}",
                    ItemID, unitID, StoreID, PhysicalStoreID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetItemByIdForTransferToHub(int ItemID, int unitID, int StoreID)
        {
            var query =
                String.Format(
                    @"select pl.ID as LocationID,rp.ID as ReceivingLocationID,rd.StoreID,(rp.Balance - rp.reservedStock)/QtyPerPack as Packs,QtyPerPack,rd.Cost as UnitPrice, rd.Margin Margin ,rd.ID as ReceiveDocID,vw.FullItemName, vw.StockCode, m.ID as ManufacturerID , m.Name as Manufacturer,iu.Text Unit,rp.Balance,pl.Label as Location,s.CompanyName as Supplier,st.StoreName as account,rd.BatchNo,  rd.ExpDate,vw.ID as ItemID,iu.ID UnitID  from vwGetAllItems vw Join receivedoc rd on rd.ItemID = vw.ID join receivepallet rp on rd.ID=rp.ReceiveID join palletlocation pl on pl.PalletID=rp.PalletID join manufacturers m on m.ID=rd.ManufacturerID join Supplier s on s.ID=rd.SupplierID join Stores st on st.ID = rd.StoreID join ItemUnit iu on rd.UnitID=iu.ID 
                                                join shelf sh on sh.ID =  pl.ShelfID 
                                        where (rp.Balance - rp.reservedStock)/QtyPerPack > 0 and rd.itemID ={0} and iu.ID = {1} and st.ID = {2} ",
                    ItemID, unitID, StoreID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetItemByIdForCustomIssueCenter(int ItemID, int unitID, int StoreID)
        {
            var query =
                String.Format(@"select pl.ID as LocationID,rp.ID as ReceivingLocationID,rd.StoreID,(rp.Balance - rp.reservedStock)/QtyPerPack as Packs,QtyPerPack,
												rd.Cost as UnitPrice, rd.Margin Margin ,rd.ID as ReceiveDocID,vw.FullItemName, vw.StockCode, m.ID as ManufacturerID , m.Name as Manufacturer,iu.Text Unit,rp.Balance,pl.Label as Location,s.CompanyName as Supplier,st.StoreName as account,rd.BatchNo,  rd.ExpDate,vw.ID as ItemID,iu.ID UnitID  from vwGetAllItems vw Join receivedoc rd on rd.ItemID = vw.ID 
										join receivepallet rp on rd.ID=rp.ReceiveID join palletlocation pl on pl.PalletID=rp.PalletID 
										join manufacturers m on m.ID=rd.ManufacturerID join Supplier s on s.ID=rd.SupplierID 
										join Stores st on st.ID = rd.StoreID join ItemUnit iu on rd.UnitID=iu.ID 
										join shelf sh on sh.ID =  pl.ShelfID 
									where (rp.Balance - rp.reservedStock)/QtyPerPack > 0 and rd.itemID ={0} and iu.ID = {1} and st.ID = {2}",
                    ItemID, unitID, StoreID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetItemByIdForCustomIssueHub(int ItemID, int unitID, int StoreID)
        {
            var query =
                String.Format(@"select pl.ID as LocationID,rp.ID as ReceivingLocationID,rd.StoreID,(rp.Balance - rp.reservedStock)/QtyPerPack as Packs,QtyPerPack,
										rd.SellingPrice as UnitPrice, rd.Margin Margin ,rd.ID as ReceiveDocID,vw.FullItemName, vw.StockCode, m.ID as ManufacturerID , m.Name as Manufacturer,iu.Text Unit,rp.Balance,pl.Label as Location,s.CompanyName as Supplier,st.StoreName as account,rd.BatchNo,  rd.ExpDate,vw.ID as ItemID,iu.ID UnitID  from vwGetAllItems vw Join receivedoc rd on rd.ItemID = vw.ID 
										join receivepallet rp on rd.ID=rp.ReceiveID join palletlocation pl on pl.PalletID=rp.PalletID 
										join manufacturers m on m.ID=rd.ManufacturerID join Supplier s on s.ID=rd.SupplierID 
										join Stores st on st.ID = rd.StoreID join ItemUnit iu on rd.UnitID=iu.ID 
										join shelf sh on sh.ID =  pl.ShelfID 
									where (rp.Balance - rp.reservedStock)/QtyPerPack > 0 and rd.itemID ={0} and iu.ID = {1} and st.ID = {2}",
                    ItemID, unitID, StoreID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetItemsByCommodityTypeForTransferToAccount(int AccountFrom, int AccountTo)
        {
            var query =
                String.Format(@"select Distinct vw.ID,vw.FullItemName,iu.text Unit,IsSelected = CAST (0 as Bit),iu.ID UnitID,vw.TypeID,{0} StoreID
													from vwGetAllItems vw 
														Join ReceiveDoc rd on rd.ItemID = vw.ID 
														Join ReceivePallet rp on rp.ReceiveID = rd.ID join ItemUnit iu on rd.UnitID=iu.ID
													Where rd.StoreID = {0}
													Group by vw.ID,vw.FullItemName,iu.text,iu.ID,vw.TypeID,rd.StoreID
													Having Sum(rd.QuantityLeft - rp.ReservedStock)/QtyPerPack > 0
													
													INTERSECT

													select Distinct vw.ID,vw.FullItemName,iu.text Unit,IsSelected = CAST (0 as Bit),iu.ID UnitID,vw.TypeID,{0} StoreID
													from vwGetAllItems vw 
													Join ReceiveDoc rd on rd.ItemID = vw.ID 
													Join ReceivePallet rp on rp.ReceiveID = rd.ID join ItemUnit iu on rd.UnitID=iu.ID
													Where rd.StoreID = {1}
													Group by vw.ID,vw.FullItemName,iu.text,iu.ID,vw.TypeID,rd.StoreID
													Having  Sum(rd.QuantityLeft - rp.ReservedStock)/QtyPerPack > 0
													ORDER BY vw.FullItemName", AccountFrom, AccountTo);
            return query;
        }

        [SelectQuery]
        public static string SelectGetItemByManufactuerAndUnit()
        {
            var query = String.Format(@"Select rd.ItemID,vwrp.ManufacturerID,vwrp.ItemUnitID,vwrp.AccountID,vwrp.AccountName,
											vwrp.FullItemName,vwrp.ManufacturerName,vwrp.ItemUnitName,
											rd.PricePerPack ,rd.Cost,rd.SellingPrice,rd.Margin*100 Margin,Sum(vwrp.Packs) Quantity,cast(isNULL(HasUnConfirmed,0) as Bit) HasUnConfirmed,cast(isNULL(HasUnPriced,0) as Bit) HasUnPriced,Case when(Sum(rd.QuantityLeft/rd.QtyPerPack)<>Sum(vwrp.Packs)) then Cast(1 as Bit) else Cast(0 as Bit) End Inconsistancy
									from Receivedoc rd left join 
											vwReceiptPallet vwrp on vwrp.ReceiveDocID = rd.ID left Join 
											(Select rd.ItemID,rd.ManufacturerID,rd.UnitID, Cast(1 as Bit)HasUnConfirmed from ReceiveDoc rd where (Confirmed is Null or Confirmed =0 ) ) as uc On rd.ItemID = uc.ItemID and vwrp.ManufacturerID = uc.ManufacturerID and vwrp.ItemUnitID = uc.UnitID left Join
											(Select rd.ItemID,rd.ManufacturerID,rd.UnitID, Cast(1 as Bit)HasUnPriced from ReceiveDoc rd where (Confirmed is Null or Confirmed =0 ) ) as up On rd.ItemID = up.ItemID and vwrp.ManufacturerID = up.ManufacturerID and vwrp.ItemUnitID = up.UnitID
											Group by rd.ItemID,vwrp.ManufacturerID,vwrp.ItemUnitID,vwrp.AccountID,
												vwrp.AccountName,vwrp.FullItemName,vwrp.ManufacturerName,rd.qtyPerPack,
												vwrp.ItemUnitName,rd.PricePerPack,rd.Cost,rd.SellingPrice,rd.Margin,HasUnConfirmed,HasUnPriced
									Order By FullItemName");
            return query;
        }

        [SelectQuery]
        public static string SelectGetCostTierComparision()
        {
            var query = String.Format(@"Select Distinct rd.ItemID,rd.UnitID,rd.ManufacturerID,acc.MovingAverageID,ll.ID LedgerID,
		                                    vw.fullItemname Item
		                                    ,m.Name Manufacturer
		                                    ,iu.Text Unit
		                                    ,rd.Cost CurrentUnitCost
                                            ,acc.MovingAverageName MovingAverage 
		                                    ,IsNull(rd.Margin,0) CurrentMargin
		                                    ,rd.SellingPrice CurrentSellingPrice
		                                    ,ll.UnitCost CostTierUnitCost
		                                    ,ll.Margin CostTierMargin
		                                    ,ll.SellingPrice CostTierSellingPrice
	                                    From ReceiveDoc rd 
		                                    Join ReceivePallet rp on rp.receiveID = rd.ID
											join vwPallet pl on rp.PalletID = pl.palletId
                                            join vwgetAllItems vw on rd.ItemID = vw.ID
		                                    join manufacturer m on rd.ManufacturerID = m.ID
		                                    join itemUnit iu on rd.UnitID = iu.ID
		                                    join vwAccounts acc on rd.StoreID = acc.ActivityID
		                                    join ReceiveDocConfirmation rdc on rd.ID = rdc.ReceiveDocID
                                            join ReceiptConfirmationStatus rcs on rcs.ID = rdc.ReceiptConfirmationStatusID 
                                            join StorageType st on st.ID = pl.StorageTypeID 
		                                    Join LedgerLite ll on ll.itemID = rd.ItemID 
								                                    and ll.ManufacturerID = rd.ManufacturerID
								                                    and ll.UnitId = rd.UnitID
								                                    and ll.AccountID = acc.MovingAverageID
	                                    where Quantityleft > 0 
		                                    and rcs.ReceiptConfirmationStatusCode in ('GRVP','SREC','CANC','GRNFP')
		                                    and rd.Cost <> 0 
		                                    and rd.SellingPrice <> 0
											and st.StorageTypeCode <> 'SA'
											and rd.ExpDate > GetDate()");
            return query;
        }

        [SelectQuery]
        public static string SelectGetReceiveDocDetailForDiagnostics(int itemID, int ManufacturerID, int UnitID, int MovingAverageID)
        {
            var query = String.Format(@"Select rd.ID ReceiveDocID
                                          ,rd.ReceiptID
                                          ,rd.ReturnedStock IsSRM
                                          ,rd.DeliveryNote IsDeliveryNote
                                          ,rd.Cost UnitCost
                                          ,rd.Margin
                                          ,rd.SellingPrice      
	                                    From ReceiveDoc rd 
		                                    Join ReceivePallet rp on rp.receiveID = rd.ID
											join vwPallet pl on rp.PalletID = pl.palletId
                                            join vwAccounts acc on rd.StoreID = acc.ActivityID
		                                    join ReceiveDocConfirmation rdc on rd.ID = rdc.ReceiveDocID
                                            join ReceiptConfirmationStatus rcs on rcs.ID = rdc.ReceiptConfirmationStatusID
                                            join StorageType st on st.ID = pl.StorageTypeID    
		                               where Quantityleft > 0 
		                                    and rcs.ReceiptConfirmationStatusCode in ('GRVP','SREC','CANC','GRNFP')
		                                    and rd.Cost <> 0 
		                                    and rd.SellingPrice <> 0
											and st.StorageTypeCode <> 'SA'
											and rd.ExpDate > GetDate()
                                            and rd.ItemId ={0} and rd.ManufacturerID = {1} and rd.UnitID={2} and acc.MovingAverageID={3}",
                itemID, ManufacturerID, UnitID, MovingAverageID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetJournalEntriesForDiagnostics(int AffectedLedgerID)
        {
            var query = String.Format(@"select * from JournalLite where AffectedLedgerID = {0}", AffectedLedgerID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetMovingAverageLogForDiagnostics(int itemID, int ManufacturerID, int UnitID, int MovingAverageID)
        {
            var query = String.Format(@"select * from weightedAverageLog  wl                       
	                                        join vwAccounts acc on wl.StoreID = acc.ActivityID
		                               where wl.ItemId ={0} 
                                            and wl.ManufacturerID = {1} 
                                            and wl.UnitID={2} 
                                            and acc.MovingAverageID={3}", itemID, ManufacturerID, UnitID,
                MovingAverageID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetReceiveDocByItemAndManufactuerAndUnit(int ItemID, int ManufacturerID, int ItemUnitID, int AccountID)
        {
            var query =
                String.Format(@"Select rd.ID ReceiveDocID,rd.ItemID,vwrp.ManufacturerID,vwrp.ItemUnitID,vwrp.AccountID,vwrp.AccountName,
											vwrp.FullItemName,vwrp.ManufacturerName,vwrp.ItemUnitName,rd.QuantityLeft Quantity,
											rd.PricePerPack ,rd.Cost,rd.SellingPrice,rd.Margin*100 Margin,vwrp.Packs Balance,vwrp.AccountName + ' - ' + vwrp.SubAccountName + ' - ' + vwrp.ActivityName FullActivityName,  vwrp.ClusterName+ ' - ' +vwrp.WareHouseName + ' - '+ vwrp.PhysicalStoreName FullPhysicalStoreName, 
											rd.Confirmed HasUnConfirmed,Case when(SellingPrice = 0 or Cost is Null or SellingPrice is Null or Cost = 0 or PricePerPack Is Null or PricePerPack = 0) Then Cast(0 as Bit)  else Cast(1 as Bit) End HasUnPriced,Case when (rd.QuantityLeft/rd.QtyPerPack)<>vwrp.Packs then Cast(0 as Bit) else Cast(1 as Bit) End Inconsistancy
									from Receivedoc rd left join 
											vwReceiptPallet vwrp on vwrp.ReceiveDocID = rd.ID
									Where rd.ItemID = {0} and rd.ManufacturerID = {1} and rd.UnitID = {2} and vwrp.AccountID = {3}
									Order By FullItemName", ItemID, ManufacturerID, ItemUnitID, AccountID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetPicklistByItemAndManufactuerAndUnit(int ItemID, int ManufacturerID, int ItemUnitID, int AccountID)
        {
            var query =
                String.Format(@"Select rd.ID ReceiveDocID,rd.ItemID,vwrp.ManufacturerID,vwrp.ItemUnitID,vwrp.AccountID,vwrp.AccountName,
											vwrp.FullItemName,vwrp.ManufacturerName,vwrp.ItemUnitName,rd.QuantityLeft Quantity,pld.UnitPrice,pld.Cost pldCost,ru.Name ReceivingUnitName,
											rd.PricePerPack ,rd.Cost,rd.SellingPrice,rd.Margin*100 Margin,vwrp.Packs Balance,vwrp.AccountName + ' - ' + vwrp.SubAccountName + ' - ' + vwrp.ActivityName FullActivityName,  vwrp.ClusterName+ ' - ' +vwrp.WareHouseName + ' - '+ vwrp.PhysicalStoreName FullPhysicalStoreName, 
											rd.Confirmed HasUnConfirmed,Case when(UnitPrice <> rd.SellingPrice and pl.IsConfirmed = 1) Then Cast(0 as Bit)  else Cast(1 as Bit) End HasUnPriced,Case when rd.QuantityLeft<>vwrp.Packs then Cast(0 as Bit) else Cast(1 as Bit) End Inconsistancy
									from Receivedoc rd left join 
											vwReceiptPallet vwrp on vwrp.ReceiveDocID = rd.ID Join PicklistDetail pld on rd.ID = pld.ReceiveDocID Join Picklist pl on Pld.PickListID = pl.Id Join [Order] o on o.Id = pl.OrderID Join Institution ru on ru.ID = o.RequestedBy
									Where rd.ItemID = {0} and rd.ManufacturerID = {1} and rd.UnitID = {2} and vwrp.AccountID = {3}
									Order By FullItemName", ItemID, ManufacturerID, ItemUnitID, AccountID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetItemsDetailByFilter(string Filter)
        {
            string query =
                String.Format(@"SELECT   Manufacturers.Name AS ManufacturerName, Case When dbo.vwAccounts.ActivityName = dbo.vwAccounts.SubAccountName and dbo.vwAccounts.AccountName = dbo.vwAccounts.SubAccountName Then dbo.vwAccounts.ActivityName else dbo.vwAccounts.AccountName + ' - ' + dbo.vwAccounts.SubAccountName +' - '+ dbo.vwAccounts.ActivityName end  ActivityName, dbo.ItemUnit.Text AS ItemUnitName,Sum(Balance/QtyPerPack) SOH,Sum(Case when rd.ExpDate < GETDATE() and st.StorageTypeCode <> 'SA' then Balance else 0 end) Expired,Sum(Case when st.StorageTypeCode = 'SA'  then Balance / QtyPerPack else 0 end) Suspended,Sum(Case when rd.ExpDate < GETDATE() and st.StorageTypeCode <> 'SA' then Balance / QtyPerPack else 0 end) NearExpired,Sum(rp.ReservedStock / QtyPerPack) Reserved,Sum(Case when rd.DeliveryNote = 1 and rd.SellingPrice is null then Balance / QtyPerPack else 0 end) DeliveryNote,Sum(Case when (rd.Confirmed <> 1 Or rd.Confirmed is Null) then Balance / QtyPerPack else 0 end) UnConfirmed,PhysicalStoreName
													FROM          dbo.ReceivePallet AS rp INNER JOIN
															 dbo.ReceiveDoc AS rd ON rp.ReceiveID = rd.ID INNER JOIN
															 dbo.vwPallet pt ON rp.PalletID = pt.PalletID INNER JOIN
															 dbo.vwGetAllItems AS vw ON rd.ItemID = vw.ID INNER JOIN
															 dbo.Manufacturers ON rd.ManufacturerId = dbo.Manufacturers.ID INNER JOIN
															 dbo.ItemUnit ON rd.UnitID = dbo.ItemUnit.ID INNER JOIN
															 dbo.vwAccounts ON rd.StoreID = dbo.vwAccounts.ActivityID
	                                                         join StorageType st on st.ID = pt.StorageTypeID 
											Where {0} Group By FullItemName,rd.ItemID,ManufacturerId, Manufacturers.Name ,rd.UnitID,ItemUnit.Text,PhyicalStoreID,ActivityID, dbo.vwAccounts.ActivityName, dbo.vwAccounts.SubAccountName, dbo.vwAccounts.AccountName,PhysicalStoreName
									", Filter);
            return query;
        }

        [SelectQuery]
        public static string SelectGetGRNFDetailByFilter(string Filter)
        {
            string query = String.Format(@"Select rt.ID,
		                                                 case
				                                             when isNull(rd.RefNo,'Unknown') like 'BeginningBalance' 
				                                             then 'Beginning Balance' 
				                                             else  
					                                             isNull((select 'GRNF' + Cast(Max(IDPrinted) as varchar) from ReceiptConfirmationPrintout rcp where rcp.ReceiptID = rt.ID And Reason like 'PGRV'),'Not Printed')
					                                             + isNull((select '\GRV' + Cast(Max(IDPrinted) as varchar) from ReceiptConfirmationPrintout rcp where rcp.ReceiptID = rt.ID and Reason in('GRV','IGRV')),'')
					                                             + isNull((select '\SRM' + Cast(Max(IDPrinted) as varchar) from ReceiptConfirmationPrintout rcp where rcp.ReceiptID = rt.ID And Reason like 'SRM'),'')
			                                             end Document
	                                                , Sum(rd.NoOfPack) ReceiveQty
		                                            , Sum(Case when rd.ExpDate < GetDate() and  st.StorageTypeCode <> 'SA' then rd.QuantityLeft / rd.QtyPerPack Else 0 end) ExpiredQty
		                                            , Sum(Case when st.StorageTypeCode = 'SA' then rp.Balance /rd.QtyPerPack else 0 end) DamagedQty
		                                            , isNull(sum(id.NoOfPack),0) IssuedQty	
		                                            , isNull(sum(d.Quantity / rd.QtyPerPack),0) DiposalQty 
		                                            , Sum(rd.NoOfPack) 
			                                            - isNull(Sum(Case when rd.ExpDate < GetDate() and  st.StorageTypeCode <> 'SA' then rd.QuantityLeft / rd.QtyPerPack Else 0 end),0)
			                                            - isNull(Sum(Case when st.StorageTypeCode = 'SA' then rp.Balance /rd.QtyPerPack else 0 end),0)
			                                            - isNull(sum(id.NoOfPack),0) 	
			                                            - isNull(sum(d.Quantity / rd.QtyPerPack),0) RemainingQty 
		                                            ,rcs.Name Status
		                                            ,rcs.ID StatusID
	                                            from ReceiveDoc rd
		                                            left join ReceivePallet rp on rp.ReceiveID = rd.ID
		                                            left join vwPallet pl on  pl.PalletID = rp.PalletID 
		                                            left join IssueDoc id on id.RecievDocID = rd.ID
		                                            left join Disposal d on d.Losses = 1 and d.RecID = rd.ID
		                                            left join vwAccounts acc on acc.ActivityID = rd.StoreID
		                                            left Join Receipt rt on rt.ID = rd.ReceiptID
		                                            left join ReceiveDocConfirmation rdc on rdc.ReceiveDocID = rd.ID
		                                            left join ReceiptConfirmationStatus rcs on rdc.ReceiptConfirmationStatusID = rcs.ID
                                                    join StorageType st on st.ID = pl.StorageTypeID  
                                                Where {0}
	                                            Group by rcs.Name,rcs.ID,rt.ID,isNull(rd.RefNo,'Unknown')", Filter);
            return query;
        }

        [SelectQuery]
        public static string SelectGetItemDetailForItemChanger(int ItemID, int ManufacturerID, int UnitID, int ActivityID)
        {
            string query = String.Format(@"select 
                                                PONumber ,
                                                ri.STVorInvoiceNo STVorInvoice,
                                                rd.ID ReceiveDocID
                                                ,rp.ID ReceivePalletID
												,ws.ID[WearehouseID]
                                                ,rd.BatchNo
                                                ,rd.ExpDate ExpiryDate
                                                ,Format(Max(IDPrinted),'00000') IDPrinted
                                                ,InvoicedNoOfPack InvoiceQty
                                                ,rp.ReceivedQuantity/rd.QtyPerPack ReceivedQty
                                                ,rp.ReservedStock ReservedQty
                                                ,rp.Balance/rd.QtyPerPack -isNull(rp.ReservedStock,0) CurrentQty
                                                ,0.0 PickedQty
                                                ,0.0 ChangedQty
												,st.Name Store,ws.Name[WearehouseName]
                                                from ReceiveDoc rd 
	                                                join ReceivePallet rp on rd.ID = rp.ReceiveID 
                                                    Join Receipt rt on rd.receiptId = rt.ID
                                                    Join ReceiptInvoice ri on ri.ID = rt.ReceiptInvoiceID
                                                    Join PO po on po.ID = ri.POID 
													JOIN PhysicalStore st ON st.ID = rd.PhysicalStoreID
													JOIN Warehouse ws ON st.PhysicalStoreTypeID = ws.ID
	                                                left Join (select ReceiptID,IDPrinted from ReceiptConfirmationPrintout where Reason in ('GRV','iGRV','SRM') ) rcp on rcp.ReceiptID = rd.ReceiptID
                                                where rd.ItemID = {0} and rd.ManufacturerID ={1} and rd.UnitID = {2} and rd.StoreID = {3}
                                                Group by PONumber,ri.STVorInvoiceNo, rd.ID,rd.BatchNo,ws.ID,rd.ExpDate,rd.InvoicedNoOfPack,NoOfPack,rp.Balance,rp.ID	,rp.ReceivedQuantity,rd.QtyPerPack,rp.ReservedStock,st.Name,ws.Name", ItemID,
                ManufacturerID, UnitID, ActivityID);
            return query;
        }

        [UpdateQuery]
        public static string UpdateFixExpirySettings()
        {
            string query =
                @"update i set  i.NeedExpiryBatch = 1 from Items i join Product p on i.IINID = p.ID join CommodityType ct on ct.ID = p.TypeID where i.NeedExpiryBatch is null and ct.CommodityTypeCode = 'PHAR'
                                    update i set  i.NeedExpiryBatch = 0 from Items i join Product p on i.IINID = p.ID join CommodityType ct on ct.ID = p.TypeID where i.NeedExpiryBatch is null and ct.CommodityTypeCode <> 'PHAR'";
            return query;
        }
        [SelectQuery]
        public static string SelectItemsDistributedByAccount(int accountid, DateTime fromdate, DateTime todate)
        {
            string query = string.Format(@"Select vwg.FullItemName Item 
                                        , iu.Text Unit 
                                        , m.Name Manufacturer
                                        , SUM(id.Quantity) Quantity
                                        ,(SUM(id.Cost)/SUM(id.Quantity)) UnitCost
                                        , SUM(id.Cost) Amount
                                        From IssueDoc id 
                                        Join dbo.vwAccounts vwa ON id.StoreId = vwa.ActivityID 
                                        Join Account a on a.ID = vwa.AccountID
                                        JOIN dbo.vwGetAllItems vwg ON id.ItemID = vwg.ID 
                                        JOIN dbo.ItemUnit iu ON id.UnitID = iu.ID 
                                        Join dbo.Manufacturer m on m.ID = id.ManufacturerID
                                        Join ReceivingUnits ru on ru.ID = id.ReceivingUnitID
                                        Where id.EurDate Between '{0}' and '{1}' and a.ID = {2}
                                        GROUP BY  
                                         vwg.FullItemName  
                                        , iu.Text  
                                        , m.Name
                                        ORDER BY vwg.FullItemName  
                                        , iu.Text  
                                        , m.Name", fromdate, todate, accountid);
            return query;
        }
    }
}
