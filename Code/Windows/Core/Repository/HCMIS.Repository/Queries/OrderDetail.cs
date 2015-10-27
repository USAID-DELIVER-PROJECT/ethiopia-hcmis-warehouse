using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class OrderDetail
    {
        [SelectQuery]
        public static string SelectLoadAllByOrderId(int orderId)
        {
            return String.Format("select (od.Quantity / od.QtyPerPack) as Pack, od.*, v.FullItemName, v.StockCode , iu.Text as Unit, v.StockCode  from OrderDetail od join vwGetAllItems v on od.ItemID = v.ID join ItemUnit iu on od.UnitID = iu.ID where OrderID = {0}", orderId);
        }

        [SelectQuery]
        public static string SelectLoadOrderDetailsAndItemName(int orderId)
        {
            string query =
                String.Format(
                    "select iu.Text as Unit, o.*,vw.FullItemName,vw.StockCode,vw.Name CategoryType from [OrderDetail] o join vwGetAllItems vw on o.ItemID = vw.ID left join ItemUnit iu on o.UnitID = iu.ID where o.OrderID = {0}",
                    orderId);
            return query;
        }

        [SelectQuery]
        public static string SelectStockOutDetail(int orderId)
        {
            string query =
                String.Format(@"select ROW_NUMBER() Over (Order by vw.FullItemName) [LineNo], iu.Text as Unit, od.Pack - od.ApprovedQuantity RequestedSKU,vw.FullItemName,vw.StockCode,vw.Name CategoryType,i.Name FacilityName,i.RegionName Region,i.ZoneName Zone,i.WoredaName Woreda
                                    from [order] o join [OrderDetail] od on o.ID = od.OrderID
                                    Join vwInstitution i on o.RequestedBy = i.ID
                                    join vwGetAllItems vw on od.ItemID = vw.ID 
                                    left join ItemUnit iu on od.UnitID = iu.ID 
                                    where od.OrderID = {0} and od.StockedOut = 1 and od.Pack > 0",
                                                        orderId);
            return query;
        }

        [SelectQuery]
        public static string SelectValidateOrderDetailForIdenticalPreference(int orderID)
        {
            return String.Format(
                @"select top(1) i.FullItemName from vwGetAllItems i join
                                        (
                                        select OrderID,ItemID,UnitID,StoreID,PreferredManufacturerID,PreferredPhysicalStoreID,PreferredExpiryDate 
                                        from OrderDetail Where OrderID={0}
                                        group by OrderID,ItemID,UnitID,StoreID,PreferredManufacturerID,PreferredPhysicalStoreID,PreferredExpiryDate 
                                        having count(*) > 1
                                        ) as x on i.ID=x.ItemID",
                orderID);
        }

        [SelectQuery]
        public static string SelectLoadForBatchConfirmation(int orderId, int userId)
        {
            return String.Format(@"select (od.Quantity / od.QtyPerPack) as Pack, od.*, v.FullItemName, v.StockCode , iu.Text as Unit, v.StockCode  from OrderDetail od join vwGetAllItems v on od.ItemID = v.ID join ItemUnit iu on od.UnitID = iu.ID where OrderID = {0} and PreferredPhysicalStoreID in (
	                                                select PhysicalStoreID from UserPhysicalStore where CanAccess = 1 and UserID = {1}
                                                )", orderId, userId);
        }

        [SelectQuery]
        public static string SelectLoadOrderDetailsWithIssueAndPicklistForPLITS(int hcmisOrderID, int plits)
        {
            return String.Format(
                @"Select od.HACTOrderDetailID,id.NoOfPack,id.EurDate from [IssueDoc] id 
                        join [PicklistDetail] pld on pld.ID=id.PLDetailID join [OrderDetail] od on pld.OrderDetailID=od.ID
                        join [Order] o on id.OrderID=o.ID  
                        where id.OrderID={0} and o.OrderTypeID={1}",
                hcmisOrderID, plits);
        }

        [SelectQuery]
        public static string SelectLastOrderDetailByFacility(int orderId, int facilityId)
        {
            string query = string.Format(@"select *, isnull(od.StockOnHand ,0) SOH, isnull(od.DamagedStock,0) Damaged, isnull(od.ExpiredStock,0) Expired
								from
								vwGetAllItems vw
                                join OrderDetail od on od.ItemID = vw.ID
                                join [order] o on od.OrderID =o.ID   
								join ItemUnit iu on od.UnitID =iu.ID  
                                left join
								(
								select lastOD.ItemID, lastOD.UnitID, lastO.RequestedBy, sum(lastOD.Quantity) TotalRequested, 
                                Sum(lastOD.ApprovedQuantity) TotalIssued, count(distinct lastO.ID) NumberOfRefills ,
                                ISNULL(lastOD.StockOnHand ,0) lastSOH ,ISNULL(lastOD.DamagedStock ,0) lastDamaged,ISNULL(lastOD.ExpiredStock ,0) lastExpired
								from
								OrderDetail lastOD 
                                join [Order] lastO on lastOD.OrderID =lastO.ID and lastO.OrderStatusID in (5,7)
                                join CurrentIssueDoc id on lastO.id = id.OrderID
								where lastO.RequestedBy = {1} and lastO.ID <> {0}
								group by lastO.RequestedBy, lastOD.ItemID, lastOD.UnitID ,lastOD.StockOnHand ,lastOD.DamagedStock ,lastOD.ExpiredStock
								) as x on od.ItemID = x.ItemID and od.UnitID = x.UnitID
								where o.ID = {0}", orderId, facilityId);
            return query;
        }

        [SelectQuery]
        public static string SelectQueryLastDetails(int itemid, int unitid, int requestedby)
        {
            string queryLastDetails = string.Format(@"select top(1) id.[EurDate] LastRequestedDate, od.ApprovedQuantity LastApprovedQuantity, od.Quantity LastRequestedQuantity
		                            from [Order] o join [OrderDetail] od on o.ID = od.OrderID join currentissuedoc id on id.OrderID = o.ID
		                            where od.ItemID = {0} and od.UnitID = {1} and o.RequestedBy = {2}
		                            order by id.[EurDate] desc", itemid, unitid, requestedby);
            return queryLastDetails;
        }

        public static string SelectForcastingByOrderID(int orderId)
        {
            string query =
                string.Format(@"SELECT od.ItemID, od.UnitID, isnull(so.DOS,0) DOS, isnull(ci.TotalIssued,0) TotalIssued, fy.FiscalYearDays
                                            FROM OrderDetail od
                                            LEFT JOIN (SELECT ItemID, UnitID, SUM(NumberOfDays) DOS FROM Stockout GROUP BY ItemID, UnitID) so on od.ItemID = so.ItemID and  od.UnitID =so.UnitID
                                            LEFT JOIN (SELECT ItemID ,UnitID ,SUM(Quantity) TotalIssued From CurrentIssueDoc GROUP BY ItemID, UnitID) ci on od.ItemID = ci.ItemID and  od.UnitID =ci.UnitID
                                            LEFT JOIN (SELECT DateDiff(Day,StartDate,GetDate()) FiscalYearDays,StartDate ,EndDate , IsCurrent FROM Fiscalyear) fy on fy.IsCurrent =1
                               WHERE od.OrderID = {0} ", orderId);
            return query;
        }
    }
}
