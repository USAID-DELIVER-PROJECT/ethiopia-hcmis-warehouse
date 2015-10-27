using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class Order
    {
        [SelectQuery]
        public static string SelectGetAllOutstandingOrders(int userID, int modeID, int orderFilled)
        {
           string query = string.Format(@"select o.ID, r.Name as RouteName , RefNo,EurDate, ru.Name as RequestedBy 
                                        from [Order] o join Institution ru on o.RequestedBy = ru.ID 
                                        join Route r on ru.Route = r.RouteID 
                                        join vwAccounts acct ON o.FromStore = acct.ModeID
                                        join UserStore us ON us.StoreID = acct.ActivityID and us.UserID = {1} and us.CanAccess = 1
                                        where OrderStatusID = {0} and acct.ModeID = {2}
                                        GROUP BY o.ID, r.Name , RefNo,EurDate, ru.Name", orderFilled, userID, modeID);
            return query;
        }

    
        [SelectQuery]
        public static string SelectGetAllApprovedOrders(int userID, int modeID, int orderApproved)
        {
            string query =
                String.Format(@"select o.ID, r.Name as RouteName
                                , (RefNo)
                                , EurDate
                                , ru.Name as RequestedBy 
                                , IsNull(os.OrderStatus, '-') OrderStatus
                                , IsNull(ot.Name, '-') OrderType
                                , o.LetterNo
                                , ot.Description Description
                                from [Order] o 
                                join Institution ru on o.RequestedBy = ru.ID 
                                left join OrderStatus os on o.OrderStatusID = os.ID
                                left join OrderType ot on o.OrderTypeID = ot.OrderTypeID
                                join Route r on ru.Route = r.RouteID 
                                where OrderStatusID = {0} 
                                and o.FromStore  in (select s.ModeID from UserStore us join vwaccounts s on us.StoreID=s.ActivityID
                                 where us.UserID = {1} and us.CanAccess=1) and o.FromStore = {2}",
                    orderApproved, userID, modeID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetAllApprovedOrdersInPhyiscalStore(int userID, int orderApproved)
        {
            string query =
                String.Format(
                    @"select o.ID, r.Name as RouteName, (RefNo),EurDate, ru.Name as RequestedBy from [Order] o join Institution ru on o.RequestedBy = ru.ID join Route r on ru.Route = r.RouteID where OrderStatusID = {0} and o.ID in 
								(
									select OrderID from OrderDetail od join [Order] o on od.OrderID = o.ID join OrderStatus os on os.ID = OrderStatusID where os.OrderStatusCode = 'APRD' and od.PreferredPhysicalStoreID in 
										(
										   select PhysicalStoreID from UserPhysicalStore where CanAccess = 1 and UserID = {1}
										)                                   
								 ) and o.FromStore  in (select s.StoreTypeID from UserStore us join Stores s on us.StoreID=s.ID where us.UserID = {1} and us.CanAccess = 1)",
                    orderApproved, userID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetPickListedOrders(int userID, int modeID, int pickListConfirmed)
        {
            string query =
                String.Format(@"select o.ID
                                , case when r.Name is null then 'Transfer' else r.Name end as RouteName
                                , (RefNo)
                                , EurDate
                                , case when ru.Name is null then 'Transfer' else ru.Name end as RequestedBy 
                                , IsNull(os.OrderStatus, '-') OrderStatus
                                , IsNull(ot.Name, '-') OrderType
                                , IsNull(ot.Description, '-') Description
                                from [Order] o 
                                left join Institution ru on o.RequestedBy = ru.ID 
                                left join Route r on ru.Route = r.RouteID 
                                left join OrderStatus os on o.OrderStatusID = os.ID
                                join OrderType ot on o.OrderTypeID = ot.OrderTypeID 
                                where o.FromStore = {2} 
                                and  OrderStatusID = {0} 
                                and ot.OrderTypeCode <> 'INV' 
                                and o.FromStore 
                                in (select s.StoreTypeID from UserStore us join Stores s on us.StoreID=s.ID where us.UserID = {1} and us.CanAccess=1)",
                    pickListConfirmed, userID, modeID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetUndispatchedIssues(int userID, string additionalFilter)
        {
            string query =
                String.Format(@"select  s.ID as STVID
		                            , CASE When reprint.IDPrinted is null 
			                            then RIGHT('00000' + CAST (s.IDPrinted as nvarchar), 5) 
			                            else 'Re-'+ RIGHT('00000' + CAST (reprint.IDPrinted as nvarchar), 5) end as IDPrinted
		                            , acc.AccountName StoreName
		                            , s.VoidRequest
		                            , ru.Name as RequestedBy
                            from IssueDoc id 
	                            join STVLog s on id.STVID=s.ID 
	                            join vwAccounts acc on s.StoreID = acc.ActivityID
                                join Institution ru on id.ReceivingUnitID = ru.ID 
	                            left Join(select IsReprintOf ID,Max(IDPRinted) IDPrinted from stvLog where isReprintof is not null Group by IsReprintOf) reprint on reprint.ID = s.ID
                             where id.InventoryPeriodID in (Select InventoryPeriodID from UserPhysicalStore ups join physicalStore ps on ps.ID = ups.PhysicalStoreID  where UserID={0} and CanAccess=1)  
		                            and (id.DispatchConfirmed is null or id.DispatchConfirmed=0) 
		                            and s.StoreID in (select StoreID from UserStore where UserID = {0} and CanAccess=1)
                            Group by s.ID,acc.AccountName ,s.voidRequest,ru.Name,s.IDPrinted,reprint.IDPrinted 
                            {1}
                            order by s.ID desc", userID, additionalFilter);
            return query;
        }

        [SelectQuery]
        public static string SelectGetUndispatchedIssues(int userID, int activityID, int mode ,DateTime dateFrom ,DateTime dateTo )
        {
            string additionalFilter = "";
            //Hardcoding here should be removed.  This is the mode under which the window was opened
            if (mode == 3)
                additionalFilter = " and VoidRequest=1 and VoidApprovedByUserID is null ";

            string query =
                String.Format(@"select  s.ID as STVID
		                            , CASE When reprint.IDPrinted is null 
			                            then RIGHT('00000' + CAST (s.IDPrinted as nvarchar), 5) 
			                            else 'Re-'+ RIGHT('00000' + CAST (reprint.IDPrinted as nvarchar), 5) end as IDPrinted
		                            , acc.AccountName StoreName
		                            , s.VoidRequest
		                            , ru.Name as RequestedBy
                            from IssueDoc id 
	                            join STVLog s on id.STVID=s.ID 
	                            join vwAccounts acc on s.StoreID = acc.ActivityID
                                join Institution ru on id.ReceivingUnitID = ru.ID 
	                            left Join(select IsReprintOf ID,Max(IDPRinted) IDPrinted from stvLog where isReprintof is not null Group by IsReprintOf) reprint on reprint.ID = s.ID
                             where id.InventoryPeriodID in (Select CurrentInventoryPeriodID from UserPhysicalStore ups join physicalStore ps on ps.ID = ups.PhysicalStoreID  where UserID={0} and CanAccess=1)  
		                            and (id.DispatchConfirmed is null or id.DispatchConfirmed=0) 
		                            and s.StoreID = {2} and  Cast(id.EurDate as Date) >= '{3}' and Cast(id.EurDate as Date) <= '{4}'
                            Group by s.ID,acc.AccountName ,s.voidRequest,ru.Name,s.IDPrinted,reprint.IDPrinted 
                            {1}
                            order by s.ID desc", userID, additionalFilter, activityID ,dateFrom ,dateTo);
            return query;
        }

        [SelectQuery]
        public static string SelectGetUnconfirmedPickLists(int userID, int modeID, int pickListGenerated)
        {
            string query =
                String.Format(@"select o.ID
                            , isnull(r.Name,'Transfer') as RouteName
                            , (RefNo)
                            , EurDate
                            , isnull(ru.Name,'Transfer') as RequestedBy 
                            , IsNull(os.OrderStatus, '-') OrderStatus
                            , IsNull(ot.Name, '-') OrderType
                            , IsNull(ot.Description, '-') Description
                            from [Order] o 
                            left join Institution ru on o.RequestedBy = ru.ID 
                            left join Route r on ru.Route = r.RouteID   
                            left join OrderStatus os on o.OrderStatusID = os.ID
                            left join OrderType ot on o.OrderTypeID = ot.OrderTypeID
                            where OrderStatusID = {0} 
                            and o.FromStore in (select s.StoreTypeID from UserStore us join Stores s on us.StoreID=s.ID where us.UserID = {1} and us.CanAccess=1) and o.FromStore = {2}",
                    pickListGenerated, userID, modeID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetNextOrderReference(int fiscalYearId)
        {
            string query =
                String.Format(
                    @"select cast (MAX(CAST (RefNo as int)) as varchar) as RefNo from [Order] Where FiscalYearID = {0}",
                    fiscalYearId);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadByPickListId(int picklistID)
        {
            string query = String.Format("Select * from [Order] Where ID in (Select OrderID from Picklist where ID={0})",
                picklistID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetWeeklyInvoiceSummary()
        {
            string query = @"
								select 'Pending Tasks' as Category, 'Pending Invoices' as Name, COUNT(*) as Value from [Order] join OrderStatus os on os.ID = OrderStatusID where os.OrderStatusCode = 'PLCN'
								Union
								select 'Pending Tasks' as Category, 'Pending Facilities' as Name, COUNT(distinct RequestedBy) as Value from [Order] join OrderStatus os on os.ID = OrderStatusID where os.OrderStatusCode = 'PLCN'
								Union
								select 'Performance' as Category, 'Printed Orders Today' as Name, COUNT(distinct [Order].ID) as Value from [Order] join PickList pl on [Order].ID = pl.OrderID join STVLog sl on sl.PickListID = pl.ID join OrderStatus os on os.ID = OrderStatusID where os.OrderStatusCode = 'ISUD' and DATEDIFF(d,sl.PrintedDate,GETDATE())=0
								Union
								select 'Performance' as Category, 'Printed STVs Today' as Name, COUNT(distinct sl.ID) as Value from [Order] join PickList pl on [Order].ID = pl.OrderID join STVLog sl on sl.PickListID = pl.ID join OrderStatus os on os.ID = OrderStatusID where os.OrderStatusCode = 'ISUD' and  DATEDIFF(d,sl.PrintedDate,GETDATE())=0
								Union
								select 'Performance' as Category, 'Printed for Facilities Today' as Name, COUNT(distinct RequestedBy) as Value from [Order] join PickList pl on [Order].ID = pl.OrderID join STVLog sl on sl.PickListID = pl.ID join OrderStatus os on os.ID = OrderStatusID where os.OrderStatusCode = 'ISUD' and DATEDIFF(d,sl.PrintedDate,GETDATE())=0
								";
            return query;
        }

        [SelectQuery]
        public static string SelectGetWeeklyPickListSummary()
        {
            string query =
                @"select 'Pending Tasks' as Category, 'Approval' as Name, COUNT(*) as Value from [Order] join OrderStatus os on os.ID = OrderStatusID where os.OrderStatusCode = 'ORFI'
								Union
								select 'Pending Tasks' as Category, 'Pick List' as Name, COUNT(*) as Value from [Order] join OrderStatus os on os.ID = OrderStatusID where os.OrderStatusCode = 'APRD'
								Union 
								select 'Pending Tasks' as Category, 'Pick List Confirmation' as Name, COUNT(*) as Value from [Order] join OrderStatus os on os.ID = OrderStatusID where os.OrderStatusCode = 'PIKL'
								Union
								select  'Performance' as Category, 'Printed Today' as Name, COUNT(*) as Value from PickList where  DATEDIFF(d,[IssuedDate],GETDATE())=0
								Union
								select  'Performance' as Category, 'Printed Yesterday' as Name, COUNT(*) as Value from PickList where  DATEDIFF(d,[IssuedDate],GETDATE())=1
								Union
								select  'Performance' as Category, 'Printed Past Week' as Name, COUNT(*) as Value from PickList where  DATEDIFF(d,[IssuedDate],GETDATE())=7
								";
            return query;
        }

        [SelectQuery]
        public static string SelectGetWeeklyWishListSummary()
        {
            string query =
                @"select 'Performance' as Category, 'Entered Today' as Name, count(*) as Value from [Order] where DATEDIFF(d,[EurDate],GETDATE())=0
								Union
								select 'Performance' as Category, 'Entered Yesterday' as Name, count(*) as Value from [Order] where  DATEDIFF(d,[EurDate],GETDATE())=1
								Union
								select 'Performance' as Category, 'Entered Past Week' as Name, count(*) as Value from [Order] where  DATEDIFF(d,[EurDate],GETDATE())=7
								Union
								select 'Performance by Facility' as Category, 'Facilities Today' as Name, count(distinct RequestedBy) as Value from [Order] where DATEDIFF(d,[EurDate],GETDATE())=0
								Union
								select 'Performance by Facility' as Category, 'Entered Yesterday' as Name, count(distinct RequestedBy) as Value from [Order] where DATEDIFF(d,[EurDate],GETDATE())=1
								Union
								select 'Performance by Facility' as Category, 'Entered Past Week' as Name, count(distinct RequestedBy) as Value from [Order] where DATEDIFF(d,[EurDate],GETDATE())=7
							";
            return query;
        }

        [SelectQuery]
        public static string SelectGetWishListSummary()
        {
            string query;
            query = @"select datename(dw,CONVERT(datetime,floor(CONVERT(float,eurdate)))) + ' ' + 
							cast(Day(CONVERT(datetime,floor(CONVERT(float,eurdate)))) as varchar) [Date],
							CONVERT(datetime,floor(CONVERT(float,eurdate))),
							COUNT(distinct requestedBy) Value
							from [Order]
							group by 
							CONVERT(datetime,floor(CONVERT(float,eurdate)))
							order by CONVERT(datetime,floor(CONVERT(float,eurdate)))";
            return query;
        }

        [SelectQuery]
        public static string SelectGetWishListSummary(int days)
        {
            string query;
            query = String.Format(@"select datename(dw,CONVERT(datetime,floor(CONVERT(float,eurdate)))) + ' ' + 
										cast(Day(CONVERT(datetime,floor(CONVERT(float,eurdate)))) as varchar) [Date],
										CONVERT(datetime,floor(CONVERT(float,eurdate))),
										COUNT(distinct requestedBy) Value
										from [Order]
										where datediff(dd,eurdate,getdate())<={0}
										group by 
										CONVERT(datetime,floor(CONVERT(float,eurdate)))
										order by CONVERT(datetime,floor(CONVERT(float,eurdate)))", days);
            return query;
        }

        [SelectQuery]
        public static string SelectGetOrdersForReport(int orderStatusID)
        {
            string query;
            query = String.Format(@"select datename(dw,CONVERT(datetime,floor(CONVERT(float,eurdate)))) + ' ' + 
							cast(Day(CONVERT(datetime,floor(CONVERT(float,eurdate)))) as varchar) [Date],
							CONVERT(datetime,floor(CONVERT(float,eurdate))),
							COUNT(distinct requestedBy) Value
							from [Order]
							where OrderStatusID = {0}
							group by 
							CONVERT(datetime,floor(CONVERT(float,eurdate)))
							order by CONVERT(datetime,floor(CONVERT(float,eurdate)))", orderStatusID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetOrdersForReport(int orderStatusID, int days)
        {
            string query;
            query = String.Format(@"select datename(dw,CONVERT(datetime,floor(CONVERT(float,eurdate)))) + ' ' + 
							cast(Day(CONVERT(datetime,floor(CONVERT(float,eurdate)))) as varchar) [Date],
							CONVERT(datetime,floor(CONVERT(float,eurdate))),
							COUNT(distinct requestedBy) Value
							from [Order]
							where OrderStatusID = {0} and datediff(dd,eurdate,getdate())<={1}
							group by 
							CONVERT(datetime,floor(CONVERT(float,eurdate)))
							order by CONVERT(datetime,floor(CONVERT(float,eurdate)))", orderStatusID, days);
            return query;
        }

        [SelectQuery]
        public static string SelectGetRequisitions(int userID, string orderStatuses)
        {
            string query =
                String.Format(
                    "select o.ID, ru.ID InstitutionID, o.RefNo , ru.Name, ru.[Route],DateRequested='', o.Date, o.EurDate, case when o.Remark is null then os.OrderStatus else os.OrderStatus + '(Back Order)' end as Status from [Order] o join Institution ru on o.RequestedBy = ru.ID join OrderStatus os on o.OrderStatusID=os.ID where o.FromStore in (select s.ModeID from UserStore us join vwaccounts s on us.StoreID=s.ActivityID where UserID = {1} and CanAccess = 1) and os.OrderStatusCode in ({0}) order by o.EurDate desc",
                    orderStatuses, userID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetRequisitionDetailsQuery(int orderID)
        {
            string query =
                String.Format(
                    "select v.FullItemName, iu.Text as UnitText, Quantity / QtyPerPack as Quantity, * from OrderDetail o join vwGetAllItems v on o.ItemID = v.ID join ItemUnit iu on o.UnitID = iu.ID  where OrderID = {0}",
                    orderID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetOrderStatusList(int modeID)
        {
            string query =
                String.Format(
                    "select o.ID, ru.Name as FacilityName ,OrderStatus as Status, RefNo, o.[Date] from [Order] o join OrderStatus os on o.OrderStatusID = os.ID join Institution ru on o.RequestedBy = ru.ID where o.FromStore = {0} order by o.Date Desc",
                    modeID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetApprovedQuantity(int storeId, int itemID, int? unitid, DateTime? preferedExpiry, int? preferredManufacturer, int? preferredPhysicalStoreID, bool isSettingDeliveryNoteOnly)
        {
            string filters;

            if (isSettingDeliveryNoteOnly)
            {
                filters = String.Format("join OrderStatus os on os.ID = o.OrderStatusID Where os.OrderStatusCode = 'APRD' and ItemID = {0} and UnitID = {1} and DeliveryNote = 1 and StoreID = {2}", itemID, unitid, storeId);
            }
            else
            {
                filters = String.Format("join OrderStatus os on os.ID = o.OrderStatusID Where os.OrderStatusCode = 'APRD' and ItemID = {0} and UnitID = {1} and DeliveryNote = 0 and StoreID = {2}", itemID, unitid, storeId);
            }

            if (preferedExpiry != null)
            {
                filters += String.Format(" and Cast(PreferredExpiryDate as Date) = cast('{0}' as Date) ", preferedExpiry);
            }

            if (preferredManufacturer != null)
            {
                filters += String.Format(" and PreferredManufacturerID = {0}", preferredManufacturer);
            }
            if (preferredPhysicalStoreID != null)
            {
                filters += String.Format(" and PreferredPhysicalStoreID = {0}", preferredPhysicalStoreID);
            }


            string query =
                String.Format(
                    "select sum(ApprovedQuantity / QtyPerPack) Approved from OrderDetail od join [Order] o on od.OrderID = o.ID {0}",
                    filters);
            return query;
        }

        [SelectQuery]
        public static string SelectGetMissingSTVs()
        {
            string query = String.Format(@"SELECT DISTINCT o.ID, 
                                                                r.name AS ReceivingUnit, 
                                                                o.RefNo 
                                                FROM   [order] o 
                                                       JOIN institution r 
                                                         ON o.requestedby = r.id 
                                                WHERE  o.id IN (SELECT orderid 
                                                                FROM   issuedoc 
                                                                WHERE  stvid IS NULL) ");
            return query;
        }

        [SelectQuery]
        public static string SelectGetPLITSApprovedOrders(int userID, int modeID, int orderApproved, int plits)
        {
            string query =
                String.Format(
                    "select o.ID, r.Name as RouteName, (RefNo),EurDate, ru.Name as RequestedBy from [Order] o join Institution ru on o.RequestedBy = ru.ID join Route r on ru.Route = r.RouteID where OrderStatusID = {0} and o.OrderTypeID = and o.OrderTypeID = {3} FromStore  in (select s.StoreTypeID from UserStore us join Stores s on us.StoreID=s.ID where us.UserID = {1} and us.CanAccess=1) and o.FromStore = {2}",
                    orderApproved, userID, modeID, plits);
            return query;
        }

        [SelectQuery]
        public static string SelectNeedsBackorder(int orderID)
        {
            string query = String.Format(@"select * from OrderDetail 
                                where OrderID={0} and ApprovedQuantity<Quantity",
                orderID);
            return query;
        }

        [SelectQuery]
        public static string SelectItemDetail(int itemID)
        {
            return String.Format("Select vw.FullItemName,vw.StockCode,vw.Name CategoryType from vwGetAllItems vw Where ID={0}", itemID);
        }
    }
}
