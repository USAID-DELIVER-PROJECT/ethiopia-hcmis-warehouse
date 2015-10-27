using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class IssueDoc
    {
        [SelectQuery]
        public static string SelectGetIssuedQuantityTillMonth(int itemId, int storeId, DateTime dt1, DateTime dt2)
        {
            string query =
                String.Format(
                    "SELECT SUM(NoOfPack) AS IssuedQuantity FROM  IssueDoc WHERE (IsApproved = 1) AND (ItemID = {0} AND StoreId = {1} AND (Date between '{2}' AND '{3}'))",
                    itemId, storeId, dt1.ToString(), dt2.ToString());
            return query;
        }

        [SelectQuery]
        public static string SelectGetIssueBySTV(int stvID)
        {
            string query =
                String.Format(
                    "select iu.Text as Unit , DeletedBy = '' ,  p.PhysicalStoreName PhysicalStore , * , isnull(rus.Name,'Transfer') as IssueLocation, o.RefNo,IsDeleted = 0 from IssueDoc id join ReceiveDoc rd on id.RecievDocID = rd.ID join vwGetAllItems v on id.ItemID = v.ID left join Institution rus on id.ReceivingUnitID = rus.ID join [Order] o on o.ID = id.OrderID join ItemUnit iu on iu.ID = rd.UnitID join PickList pl on Pl.OrderID = o.ID and pl.IsConfirmed = 1 join PickListDetail pld on pld.ID = id.PLDetailID join vwPallet p on pld.PalletLocationID = p.PalletLocationID where id.STVID in (Select ID from STVLog where IsReprintOf={0} or ID={0})",
                    stvID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetIssueBySTVIncludingDeletedEntries(int stvID)
        {
            return String.Format("select iu.Text as Unit, u.FullName as DeletedBy , * , PhysicalStore = '' , isnull(rus.Name,'Transfer') as IssueLocation, o.RefNo, IsDeleted = 1 from IssueDocDeleted id join [User] u on u.ID = id.DeletedBy join ReceiveDoc rd on id.RecievDocID = rd.ID join vwGetAllItems v on id.ItemID = v.ID left join Institution rus on id.ReceivingUnitID = rus.ID join [Order] o on o.ID = id.OrderID join PickList pl on Pl.OrderID = o.ID and pl.IsConfirmed = 1 join ItemUnit iu on iu.ID = rd.UnitID where id.STVID in (Select ID from STVLog where IsReprintOf={0} or ID={0})", stvID);
        }

        [SelectQuery]
        public static string SelectGetDistinctIssueDocmentsForAccount(int accountID)
        { 
            string query = String.Format(@"SELECT
                                              ISNULL(ru.name, 'Transfer') AS ReceivingUnit,
                                              sl.id,
                                              sl.idprinted,
                                              sl.IsVoided AS IsVoid,
                                              0 AS LastPrintedID,
                                              o.id AS OrderID,
                                              sl.refno AS RefNo,
                                              sl.VoidApprovalDateTime AS approvalDate,
                                              sl.VoidApprovedByUserID AS approvedBy,
                                              o.paymenttypeid,
                                              ot.Name AS OrderType,  
                                              CASE
                                                WHEN isreprintof IS NULL THEN ''
                                                ELSE CASE
                                                  WHEN (SELECT
                                                    COUNT(*)
                                                  FROM stvlog lg
                                                  WHERE lg.id = sl.isreprintof
                                                  AND lg.isdeliverynote = 1)
                                                  > 0 AND
                                                  (sl.isdeliverynote IS NULL OR
                                                  sl.isdeliverynote = 0) THEN CASE
                                                    WHEN (SELECT
                                                      MIN(ID)
                                                    FROM stvlog lg
                                                    WHERE lg.IsReprintOf = sl.isreprintof)
                                                    = sl.ID THEN 'CN-'
                                                    ELSE 'Re-CN-'
                                                  END
                                                  ELSE 'Re-'
                                                END
                                              END + RIGHT('00000' + CAST(sl.idprinted AS nvarchar), 5) STV,
                                              isreprintof,
                                              sl.isdeliverynote,
                                              (SELECT
                                                COUNT(*)
                                              FROM stvlog lg
                                              WHERE lg.isreprintof = sl.id)
                                              HasRePrints,
                                              (SELECT
                                                COUNT(*)
                                              FROM STVLog lg
                                              WHERE lg.IsReprintOf = sl.IsReprintOf
                                              AND lg.IDPrinted > sl.IDPrinted)
                                              ConvertedAndHasReprints,

                                              (SELECT
                                                COUNT(*)
                                              FROM stvlog lg
                                              WHERE sl.isreprintof = lg.id
                                              AND lg.isdeliverynote = 1
                                              AND (sl.isdeliverynote IS NULL
                                              OR sl.isdeliverynote = 0))
                                              isConvertedDN
                                            FROM stvlog sl
                                            LEFT JOIN institution ru
                                              ON ISNULL(sl.receivingunitid, 0) = ru.id
                                            LEFT JOIN picklist pl
                                              ON sl.picklistid = pl.id
                                            JOIN [order] o
                                              ON pl.orderid = o.id
                                            Left Join OrderType ot on ot.OrderTypeID = o.OrderTypeID
                                            JOIN vwaccounts a
                                              ON sl.storeid = a.activityid
                                            WHERE a.accountid = {0}
                                            AND (sl.isdeliverynote IS NULL
                                            OR sl.isdeliverynote = 0)
                                            GROUP BY sl.id,
                                                     sl.idprinted,
                                                     sl.IsVoided,
                                                     ru.name,
                                                     isreprintof,
                                                     sl.isdeliverynote,
                                                     o.id,
                                                     sl.refno,
                                                     o.paymenttypeid,
                                                     sl.VoidApprovalDateTime,
                                                     ot.Name,
                                                     sl.VoidApprovedByUserID
        
                                            ORDER BY sl.idprinted DESC", accountID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetDistinctIssueDocmentsForAccountWithDeliveryNote(int accountID)
        {
            return String.Format(@"SELECT Isnull(ru.name, 'Transfer')                           AS ReceivingUnit, 
                                                   sl.id, 
                                                   sl.idprinted, 
                                                   0                                                     AS IsVoid, 
                                                   0                                                     AS LastPrintedID, 
                                                   o.id                                                  AS OrderID, 
                                                   sl.refno                                              AS RefNo, 
                                                   o.paymenttypeid, 
                                                   sl.VoidApprovalDateTime                               AS approvalDate,
                                                   sl.VoidApprovedByUserID                               AS approvedBy,
                                                   ot.Name                                               AS OrderType,
                                                   CASE WHEN isreprintof IS NULL THEN '' ELSE CASE WHEN (SELECT Count(*) 
                                                       FROM 
                                                       stvlog lg WHERE lg.id = sl.isreprintof AND lg.isdeliverynote = 1) > 0 AND 
                                                       (sl.isdeliverynote IS NULL OR sl.isdeliverynote = 0) THEN 'CN-' ELSE 
                                                       'Re-' END 
                                                       END 
                                                       + RIGHT('00000' + Cast (sl.idprinted AS NVARCHAR), 5) STV, 
                                                   isreprintof, 
                                                   sl.isdeliverynote, 
                                                   (SELECT Count(*) 
                                                    FROM   stvlog lg 
                                                    WHERE  lg.isreprintof = sl.id)                       HasRePrints, 
                                                   0                                                     isConvertedDN 
                                            FROM   stvlog sl 
                                                   LEFT JOIN institution ru 
                                                          ON sl.receivingunitid = ru.id 
                                                   LEFT JOIN picklist pl 
                                                          ON sl.picklistid = pl.id 
                                                   JOIN [order] o 
                                                     ON pl.orderid = o.id 
                                                   Left Join OrderType ot ON ot.OrderTypeID = o.OrderTypeID
                                                   JOIN vwaccounts a 
                                                     ON sl.storeid = a.activityid
                                                   JOIN PicklistDetail pld on pld.PicklistID = pl.ID
                                                   JOIN ReceiveDoc rd on pld.ReceiveDocID = rd.ID
                                                   JOIN PhysicalStore ps on rd.PhysicalStoreID = ps.ID and ps.IsActive=1  and rd.InventoryPeriodID = ps.CurrentInventoryPeriodID 
                                            WHERE  a.accountid = {0} 
                                                   AND isdeliverynote = 1 
                                            GROUP  BY sl.id, 
                                                      sl.idprinted, 
                                                      ru.name, 
                                                      isreprintof, 
                                                      sl.isdeliverynote, 
                                                      o.id, 
                                                      sl.refno, 
                                                      o.paymenttypeid ,
                                                      sl.VoidApprovedByUserID,
                                                      ot.Name,
                                                      sl.VoidApprovalDateTime
                                            ORDER  BY sl.idprinted DESC ", accountID);
        }

        [SelectQuery]
        public static string SelectGetDistinctIssueDocmentsForAccountAndRoute(int accountID, int routeID)
        {
            string query = String.Format(@"SELECT ru.name                                               AS ReceivingUnit, 
                                                   sl.id, 
                                                   sl.idprinted, 
                                                   0                                                     AS IsVoid, 
                                                   0                                                     AS LastPrintedID, 
                                                   o.id                                                  AS OrderID, 
                                                   o.refno                                               AS RefNo, 
                                                   ot.Name                                               AS OrderType,
                                                   sl.VoidApprovalDateTime AS approvalDate,
                                                   sl.VoidApprovedByUserID AS approvedBy,
                                                   o.paymenttypeid, 
                                                   CASE WHEN isreprintof IS NULL THEN '' ELSE CASE WHEN (SELECT Count(*) 
                                                   FROM 
                                                   stvlog lg WHERE lg.id = sl.isreprintof AND lg.isdeliverynote = 1) > 0 AND 
                                                   (sl.isdeliverynote IS NULL OR sl.isdeliverynote = 0) THEN 'CN-' ELSE 
                                                   'Re-' END 
                                                   END 
                                                   + RIGHT('00000' + Cast (sl.idprinted AS NVARCHAR), 5) STV, 
                                                   isreprintof, 
                                                   sl.isdeliverynote, 
                                                   (SELECT Count(*) 
                                                    FROM   stvlog lg 
                                                    WHERE  lg.isreprintof = sl.id)                       HasRePrints, 
                                                   (SELECT Count(*) 
                                                    FROM   stvlog lg 
                                                    WHERE  sl.isreprintof = lg.id 
                                                           AND lg.isdeliverynote = 1 
                                                           AND ( sl.isdeliverynote IS NULL 
                                                                  OR sl.isdeliverynote = 0 ))            isConvertedDN 
                                            FROM   stvlog sl 
                                                   JOIN institution ru 
                                                     ON ru.id = sl.receivingunitid 
                                                   JOIN picklist pl 
                                                     ON pl.id = sl.picklistid 
                                                   JOIN [order] o 
                                                     ON pl.orderid = o.id 
                                                   Left Join OrderType ot ON ot.OrderTypeID = o.OrderTypeID
                                                   JOIN vwaccounts a 
                                                     ON sl.storeid = a.activityid
                                                   JOIN PicklistDetail pld on pld.PicklistID = pl.ID
                                                   JOIN ReceiveDoc rd on pld.ReceiveDocID = rd.ID
                                                   JOIN PhysicalStore ps on rd.PhysicalStoreID = ps.ID and ps.IsActive=1  and rd.InventoryPeriodID = ps.CurrentInventoryPeriodID 
 
                                            WHERE  a.accountid = {0} 
                                                   AND ( isdeliverynote IS NULL 
                                                          OR isdeliverynote = 0 ) 
                                                   AND ru.route = {1} 
                                            GROUP  BY sl.id, 
                                                      sl.idprinted, 
                                                      ru.name, 
                                                      isreprintof, 
                                                      sl.isdeliverynote, 
                                                      o.id, 
                                                      o.refno, 
                                                      ot.Name,
                                                  sl.VoidApprovalDateTime,
                                                  sl.VoidApprovedByUserID,
                                                      o.paymenttypeid 
                                            ORDER  BY sl.idprinted DESC", accountID, routeID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetDistinctIssueDocmentsForAccountAndRouteWithDeliverNote(int accountID, int routeID)
        {
            return String.Format(@"SELECT ru.name                                               AS ReceivingUnit, 
                                               sl.id, 
                                               sl.idprinted, 
                                               0                                                     AS IsVoid, 
                                               0                                                     AS LastPrintedID, 
                                               o.id                                                  AS OrderID, 
                                               ot.Name                                               AS OrderType,
                                               o.refno                                               AS RefNo, 
                                               sl.VoidApprovalDateTime AS approvalDate,
                                               sl.VoidApprovedByUserID AS approvedBy,
                                               o.paymenttypeid, 
                                               CASE WHEN isreprintof IS NULL THEN '' ELSE CASE WHEN (SELECT Count(*) 
                                               FROM 
                                               stvlog lg WHERE lg.id = sl.isreprintof AND lg.isdeliverynote = 1) > 0 AND 
                                               (sl.isdeliverynote IS NULL OR sl.isdeliverynote = 0) THEN 'CN-' ELSE 
                                               'Re-' END 
                                               END 
                                               + RIGHT('00000' + Cast (sl.idprinted AS NVARCHAR), 5) STV, 
                                               isreprintof, 
                                               sl.isdeliverynote, 
                                               (SELECT Count(*) 
                                                FROM   stvlog lg 
                                                WHERE  lg.isreprintof = sl.id)                       HasRePrints, 
                                               0                                                     isConvertedDN 
                                        FROM   stvlog sl 
                                               JOIN institution ru 
                                                 ON ru.id = sl.receivingunitid 
                                               JOIN picklist pl 
                                                 ON pl.id = sl.picklistid 
                                               JOIN [order] o 
                                                 ON pl.orderid = o.id 
                                               Left Join OrderType ot ON ot.OrderTypeID = o.OrderTypeID
                                               JOIN vwaccounts a 
                                                 ON sl.storeid = a.activityid 
                                        WHERE  a.accountid = {0} 
                                               AND isdeliverynote = 1 
                                               AND ru.route = {1} 
                                        GROUP  BY sl.id, 
                                                  sl.idprinted, 
                                                  ru.name, 
                                                  isreprintof, 
                                                  sl.isdeliverynote, 
                                                  o.id, 
                                                  o.refno, 
                                                  ot.Name,
                                                  o.paymenttypeid ,
                                                  sl.VoidApprovalDateTime,
                                                  sl.VoidApprovedByUserID
                                        ORDER  BY sl.idprinted DESC ", accountID, routeID);
        }

        [SelectQuery]
        public static string SelectLoadByRefenceNumber(string refNo)
        {
            string query =
                String.Format(
                    "select id.*, v.FullItemName, ru.Name as IssueLocation, iu.Text as Unit from IssueDoc id join vwGetAllItems v on id.ItemID = v.ID join Institution ru on ru.ID = id.ReceivingUnitID join ReceiveDoc rd on id.RecievDocID = rd.ID join ItemUnit iu on rd.UnitID = iu.ID  where id.RefNo = '{0}'",
                    refNo);
            return query;
        }

        [SelectQuery]
        public static string SelectGetActivityDataSetReceiveDoc()
        {
            string query =
                String.Format(
                    "select [Date], count(distinct RefNo) as Count, sum(NoOfPack) as Pack from ReceiveDoc group by [Date]");
            return query;
        }

        [SelectQuery]
        public static string SelectGetActivityDataSetIssueDoc()
        {
            return String.Format("select [Date], count (distinct RefNo) as Count, sum(NoOfPack) as Pack from IssueDoc group by [Date]");
        }

        [SelectQuery]
        public static string SelectGetActivityDataSetByPackReceiveDoc()
        {
            string query = String.Format("select [Date], sum(NoOfPack) as Count from ReceiveDoc group by [Date]");
            return query;
        }

        [SelectQuery]
        public static string SelectGetActivityDataSetByPackIssueDoc()
        {
            return String.Format("select [Date],  sum(NoOfPack) as Count from IssueDoc group by [Date]");
        }

        [SelectQuery]
        public static string SelectGetActivityDataSetByItemTypeReceiveDoc()
        {
            string query =
                String.Format(
                    "select [Date], count(distinct ItemID) as Count, sum(NoOfPack) as Pack from ReceiveDoc group by [Date]");
            return query;
        }

        [SelectQuery]
        public static string SelectGetActivityDataSetByItemTypeIssueDoc()
        {
            return String.Format("select [Date], count (distinct ItemID) as Count, sum(NoOfPack) as Pack from IssueDoc group by [Date]");
        }

        [SelectQuery]
        public static string SelectLoadByReceiveId(int receiveId)
        {
            string query = String.Format("select * from IssueDoc where RecievDocID = {0}", receiveId);
            return query;
        }

        [SelectQuery]
        public static string SelectGetIssueSummaryBySupplier(DateTime dtFrom, DateTime dtTo, int storeTypeID)
        {
            string query =
                String.Format(
                    @"select rd.SupplierID, max(s.CompanyName) as SupplierName, sum( id.Cost ) Cost from IssueDoc id join ReceiveDoc rd on id.RecievDocID = rd.ID join Supplier s on rd.SupplierID = s.ID join Stores st on id.StoreID=st.ID where id.EurDate between '{0}' and '{1}' and rd.SupplierID <> 1 and st.StoreTypeID={2} group by rd.SupplierID",
                    dtFrom, dtTo, storeTypeID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetIssueBreakdownBySupplier(DateTime dtFrom, DateTime dtTo, int storeTypeID)
        {
            string query =
                String.Format(
                    @"select rd.ItemID, rd.SupplierID,Max(s.CompanyName) as SupplierName,Max(v.FullItemName) as FullItemName, Sum(id.Quantity / id.QtyPerPack) Quantity, SUM(id.Cost) Cost from IssueDoc id join ReceiveDoc rd on id.RecievDocID = rd.ID join vwGetAllItems v on rd.ItemID = v.ID join Supplier s on rd.SupplierID = s.ID join Stores st on st.ID=id.StoreID where id.EurDate between '{0}' and '{1}' and rd.SupplierID <> 1 and st.StoreTypeID ={2} Group by rd.ItemID, rd.SupplierID order by SupplierName, FullItemName",
                    dtFrom, dtTo, storeTypeID);
            return query;
        }

        [SelectQuery]
        public static string SelectTopItemReceivers(int itemID)
        {
            string query =
                String.Format(@"select id.ReceivingUnitID,ru.Name as FacilityName, sum(Quantity/QtyPerPack) as Quantity from IssueDoc id join Institution ru on ru.ID = id.ReceivingUnitID where ItemID = {0}
											Group by ReceivingUnitID, ru.Name
										   order by Quantity Desc", itemID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetWeeklyTransactionSummary()
        {
            string query;
            query =
                @"select DAY(EURDATE) Day, DATENAME(DW, EurDate) + ' ' + CAST(DAY(EURDATE) as varchar) Date,SUM(Cost) Value from IssueDoc Group by  DateName(dw,EurDate), MONTH(EURDATE), DAY(EURDATE) order by MONTH(EURDATE), DAY(EURDATE)";
            return query;
        }

        [SelectQuery]
        public static string SelectGetWeeklyTransactionSummary(int days)
        {
            return String.Format(@"select DAY(EURDATE) Day, DATENAME(DW, EurDate) + ' ' + CAST(DAY(EURDATE) as varchar) Date,SUM(Cost) Value from IssueDoc where DATEDIFF(dd,EurDate,GetDate())<{0} Group by  DateName(dw,EurDate), MONTH(EURDATE), DAY(EURDATE) order by MONTH(EURDATE), DAY(EURDATE)", days);
        }

        [SelectQuery]
        public static string SelectGetIssueSummary()
        {
            string query;
            query = @"select datename(dw,CONVERT(datetime,floor(CONVERT(float,eurdate)))) + ' ' + 
							cast(Day(CONVERT(datetime,floor(CONVERT(float,eurdate)))) as varchar) [Date],
							CONVERT(datetime,floor(CONVERT(float,eurdate))),
							COUNT(distinct ReceivingUnitID) Value
							from IssueDoc
							group by CONVERT(datetime,floor(CONVERT(float,eurdate)))
							order by CONVERT(datetime,floor(CONVERT(float,eurdate)))";
            return query;
        }

        [SelectQuery]
        public static string SelectGetIssueSummary(int days)
        {
            return String.Format(@"select datename(dw,CONVERT(datetime,floor(CONVERT(float,eurdate)))) + ' ' + 
										cast(Day(CONVERT(datetime,floor(CONVERT(float,eurdate)))) as varchar) [Date],
										CONVERT(datetime,floor(CONVERT(float,eurdate))),
										COUNT(distinct ReceivingUnitID) Value
										from IssueDoc
										where DATEDIFF(dd,eurdate,getdate())<={0}
										group by CONVERT(datetime,floor(CONVERT(float,eurdate)))
										order by CONVERT(datetime,floor(CONVERT(float,eurdate)))", days);
        }

        [SelectQuery]
        public static string SelectGetIssueHistoryForFacility(int receivingUnitID, DateTime startDate, DateTime endDate)
        {
            string query =
                String.Format(@"select id.ID,id.EurDate, id.NoOfPack as Quantity,i.FullItemName, iu.[Text] as Unit  from IssueDoc 
										 id join vwGetAllItems i on id.ItemID=i.ID join ReceiveDoc rd on id.RecievDocID = rd.ID join ItemUnit iu on rd.UnitID=iu.ID
										 where id.ReceivingUnitID={0}
										 and id.EurDate between '{1}' and '{2}'", receivingUnitID, startDate, endDate);
            return query;
        }

        [SelectQuery]
        public static string SelectGetCostOfGoodSold(int AccountID, DateTime aDate, DateTime bDate)
        {
            string query = String.Format(@"select pt.Name  [Transaction], Max(id.EurDate) [date]
                                                        ,i.IDPrinted RefNo
                                                        ,sum(id.NoOfPack * id.SellingPrice) TotalPrice
                                                        ,Sum(id.NoOfPack * id.UnitCost) TotalCost
                                                        ,Sum(id.NoOfPack * id.SellingPrice) - Sum(id.NoOfPack * id.UnitCost) Margin 
                                                    from IssueDoc id 
                                                         join issue i on id.STVID = i.ID 	 
                                                         join [Order] o on o.ID = id.OrderID
														 join PaymentType pt on pt.ID = o.PaymentTypeID
                                                    Where id.StoreID = {0} and id.EurDate between '{1}' and '{2}'
                                                    group by IDPrinted,STVID,pt.Name", AccountID,
                aDate.ToShortDateString(), bDate.ToShortDateString());
            return query;
        }

        [SelectQuery]
        public static string SelectLoadByPickListDetails(string plDetailIDs)
        {
            string query = String.Format("select * from IssueDoc where PLDetailID in ({0})", plDetailIDs);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadByIDs(string plDetailIDs)
        {
            string query = String.Format("select * from IssueDoc where ID in ({0})", plDetailIDs);
            return query;
        }

        [SelectQuery]
        public static string SelectGetPossibleUnconfirmedIssues(string refNo, int storeId)
        {
            string query =
                String.Format(
                    @"select  
                        Case When id.StoreID in (select ActivityID from vwAccounts where AccountID = (select top(1)AccountID from vwAccounts where ActivityID = {1})) then 'Same Activity' else 'Different' end as ActivityComment,
                        iu.Text as Unit, *, p.PhysicalStoreName PhysicalStore , isnull(rus.Name,'Transfer') as IssueLocation, o.RefNo,IsDeleted = 0,Action = 'Confirm' 
                        from 
                            IssueDoc id join ReceiveDoc rd on id.RecievDocID = rd.ID join vwGetAllItems v on id.ItemID = v.ID left join Institution rus on id.ReceivingUnitID = rus.ID join [Order] o on o.ID = id.OrderID join ItemUnit iu on iu.ID = rd.UnitID join PickList pl on Pl.OrderID = o.ID join PickListDetail pld on pld.ID = id.PLDetailID join vwPallet p on pld.PalletLocationID = p.PalletLocationID 
                        where id.STVID is null and id.RefNo = {0}",
                    refNo, storeId);
            return query;
        }

        [SelectQuery]
        public static string SelectIssueAmountByPaymentTypeShowBySellingPrice(int ethiopianMonth, int ethiopianYear, int accountID)
        {
            return String.Format(
                @"Select a.AccountName, Case When (id.Cost is null or id.cost = 0) and DeliveryNote = 1 then 'DeliveryNote' else pt.Name End PaymentType ,Cast(id.[Date] as Date) [Date], ru.Name,i.IDPrinted,Sum(Cost) TotalAmount from IssueDoc id
                            Join vwAccounts a on id.StoreID = a.ActivityID
                            Join Issue i on i.ID = id.STVID
                            Join ReceivingUnits ru on ru.ID = id.ReceivingUnitID
                            Join [Order] o on o.ID = id.OrderID
                            Join PaymentType pt on o.PaymentTypeID = pt.ID 
                            where Month(id.[Date]) = {0}
		                            and year(id.[Date]) = {1}
		                            and a.AccountID = {2}
    	                            and id.ReceivingUnitID is not Null
                                    and (id.Cost is Not null and id.cost <> 0)
                            Group By ru.Name,i.IDPrinted,a.AccountName,Cast(id.[Date] as Date) ,   Case When (id.Cost is null or id.cost = 0) and DeliveryNote = 1 then 'DeliveryNote' else pt.Name End 
                            Order by [Date],IDPrinted", ethiopianMonth, ethiopianYear, accountID);
        }

        [SelectQuery]
        public static string SelectIssueAmountByPaymentType(int ethiopianMonth, int ethiopianYear, int accountID)
        {
            return String.Format(
                @"Select a.AccountName, Case When (id.Cost is null or id.cost = 0) and id.DeliveryNote = 1 then 'DeliveryNote' else pt.Name End PaymentType ,Cast(id.[Date] as Date) [Date], ru.Name,i.IDPrinted,Sum((id.NoOfPack) * rd.UnitCost) TotalAmount 
                            from IssueDoc id
                            Join receiveDoc rd on id.recievDocID = rd.ID
                            Join vwAccounts a on id.StoreID = a.ActivityID
                            Join Issue i on i.ID = id.STVID
                            Join ReceivingUnits ru on ru.ID = id.ReceivingUnitID
                            Join [Order] o on o.ID = id.OrderID
                            Join PaymentType pt on o.PaymentTypeID = pt.ID 
                            where Month(id.[Date]) = {0}
		                            and year(id.[Date]) = {1}
		                            and a.AccountID = {2}
    	                            and id.ReceivingUnitID is not Null
                                    and (id.Cost is Not null and id.cost <> 0)
                            Group By ru.Name,i.IDPrinted,a.AccountName,Cast(id.[Date] as Date) ,   Case When (id.Cost is null or id.cost = 0) and id.DeliveryNote = 1 then 'DeliveryNote' else pt.Name End 
                            Order by [Date],IDPrinted", ethiopianMonth, ethiopianYear, accountID);
        }

        [SelectQuery]
        public static string SelectCostOfSales(int ethiopianMonth, int ethiopianYear, int modeID)
        {
            return String.Format(@"Select a.AccountName Account,vw.WarehouseName Warehouse,pt.Name PaymentType, Sum(Case When ct.CommodityTypeCode = 'PHAR' then (id.NoOfPack) * rd.UnitCost else 0 end) Pharmaceuticals
		                            , Sum(Case When ct.CommodityTypeCode = 'MEDS' then  (id.NoOfPack) * rd.UnitCost else 0 end) MedicalSupplies
		                            , Sum(Case When ct.CommodityTypeCode = 'MEDE' then  (id.NoOfPack) * rd.UnitCost else 0 end) MedicalEquipments
		                            , Sum(Case When ct.CommodityTypeCode = 'CHEM' then  (id.NoOfPack) * rd.UnitCost else 0 end) ChemicalsAndReagents
		                            , Sum((id.NoOfPack) * rd.UnitCost ) GrandTotal
                                from IssueDoc id
									Join receiveDoc rd on id.recievDocID = rd.ID
                                    Join vwAccounts a on id.StoreID = a.ActivityID
                                    Join vwGetAllItems i on i.ID = id.ItemID
	                                Join PickListDetail pld on id.PLDetailID = pld.ID
                                    Join ReceivePallet rp on pld.ReceivePalletID = rp.ID
									Join [Order] o on o.ID = id.OrderID
								    Join PaymentType pt on o.PaymentTypeID = pt.ID 
                                    Join vwPallet vw on vw.PalletID = rp.PalletID
                                    join CommodityType ct on ct.ID = TypeID
                                Where a.ModeID ={2} and Month(id.[Date]) ={0} and Year(id.[Date]) = {1}
                                Group by  a.AccountName,vw.WarehouseName,pt.Name ",
                ethiopianMonth, ethiopianYear, modeID);
        }

        [SelectQuery]
        public static string SelectIssuedAmoutByYearShowBySellingPrice(int ethiopianYear, int accountID)
        {
            return String.Format(@"Select ROW_NUMBER() OVER (ORDER BY Month(Cast(id.[Date] as Date))) AS Row, a.AccountName,  (CASE 
                                WHEN  Month(Cast(id.[Date] as Date)) = 1 THEN 'Meskerem '
		                        WHEN  Month(Cast(id.[Date] as Date)) = 2 THEN 'Tikimet' 
		                        WHEN  Month(Cast(id.[Date] as Date)) = 3 THEN 'Hidar' 
		                        WHEN  Month(Cast(id.[Date] as Date)) = 4 THEN 'Tahisas'
		                        WHEN  Month(Cast(id.[Date] as Date)) = 5 THEN 'Tirr'
		                        WHEN  Month(Cast(id.[Date] as Date)) = 6 THEN 'Yekatit' 
		                        WHEN  Month(Cast(id.[Date] as Date)) = 7 THEN 'Megabit' 
		                        WHEN  Month(Cast(id.[Date] as Date)) = 8 THEN 'Miyazya'
	                            WHEN  Month(Cast(id.[Date] as Date)) = 9 THEN 'Genbot'
		                        WHEN  Month(Cast(id.[Date] as Date)) = 10 THEN 'Sene' 
		                        WHEN  Month(Cast(id.[Date] as Date)) = 11 THEN 'Hamle' 
		                        WHEN  Month(Cast(id.[Date] as Date)) = 12 THEN 'Nehase'
		                        WHEN  Month(Cast(id.[Date] as Date)) = 13 THEN 'Pagume'
                             END )  [Month], Sum(Cost) TotalAmount 
					from IssueDoc id
                    Join vwAccounts a on id.StoreID = a.ActivityID
                    Join Issue i on i.ID = id.STVID
                    where  year(id.[Date]) = {0}
		                    and a.AccountID = {1}
                            and id.ReceivingUnitID is not Null
                            and (id.Cost is Not null and id.cost <> 0)
                    Group By a.AccountName,Month(Cast(id.[Date] as Date))
                    Order by Month(Cast(id.[Date] as Date))", ethiopianYear, accountID);
        }

        [SelectQuery]
        public static string SelectIssuedAmoutByYear(int ethiopianYear, int accountID)
        {
            return String.Format(@"Select ROW_NUMBER() OVER (ORDER BY Month(Cast(id.[Date] as Date))) AS Row, a.AccountName,  (CASE 
                                WHEN  Month(Cast(id.[Date] as Date)) = 1 THEN 'Meskerem '
		                        WHEN  Month(Cast(id.[Date] as Date)) = 2 THEN 'Tikimet' 
		                        WHEN  Month(Cast(id.[Date] as Date)) = 3 THEN 'Hidar' 
		                        WHEN  Month(Cast(id.[Date] as Date)) = 4 THEN 'Tahisas'
		                        WHEN  Month(Cast(id.[Date] as Date)) = 5 THEN 'Tirr'
		                        WHEN  Month(Cast(id.[Date] as Date)) = 6 THEN 'Yekatit' 
		                        WHEN  Month(Cast(id.[Date] as Date)) = 7 THEN 'Megabit' 
		                        WHEN  Month(Cast(id.[Date] as Date)) = 8 THEN 'Miyazya'
	                            WHEN  Month(Cast(id.[Date] as Date)) = 9 THEN 'Genbot'
		                        WHEN  Month(Cast(id.[Date] as Date)) = 10 THEN 'Sene' 
		                        WHEN  Month(Cast(id.[Date] as Date)) = 11 THEN 'Hamle' 
		                        WHEN  Month(Cast(id.[Date] as Date)) = 12 THEN 'Nehase'
		                        WHEN  Month(Cast(id.[Date] as Date)) = 13 THEN 'Pagume'
                             END )  [Month], Sum((id.NoOfPack) * rd.UnitCost) TotalAmount 
					from IssueDoc id
                    Join receiveDoc rd on id.recievDocID = rd.ID
                    Join vwAccounts a on id.StoreID = a.ActivityID
                    Join Issue i on i.ID = id.STVID
                    where  year(id.[Date]) = {0}
		                    and a.AccountID = {1}
                            and id.ReceivingUnitID is not Null
                            and (id.Cost is Not null and id.cost <> 0)
                    Group By a.AccountName,Month(Cast(id.[Date] as Date))
                    Order by Month(Cast(id.[Date] as Date))", ethiopianYear, accountID);
        }

        [SelectQuery]
        public static string SelectGetOutstandingIssues(int warehouseID, int orderApproved, int issued)
        {
            string queryFilter = "";
            if (warehouseID != 0)
            {
                queryFilter = string.Format(" and vwpl.WarehouseID = {0} ", warehouseID);
            }

            return String.Format(
                @"Select o.RefNo as [OrderNo],iss.IDPrinted as InvoiceNo, os.OrderStatus as [Status],vwpl.WarehouseName as Warehouse,m.TypeName as [Mode],vw.AccountName
	                            from [Order] o
		                            Join orderDetail od on o.ID = od.OrderID
		                            Left join issuedoc id on o.ID = id.OrderID
		                            left join issue iss on id.STVID = iss.ID
		                            join OrderStatus os on o.OrderStatusID = os.ID
		                            Join Picklist pl on o.ID = pl.OrderID 
		                            Join PicklistDetail pld on pl.Id = pld.PicklistID 
		                            Join receivePallet rp on rp.ID = pld.ReceivePalletID 
		                            Join vwPallet vwpl on rp.PalletID = vwpl.PalletID
		                            join vwAccounts vw on od.StoreID = vw.ActivityID 
		                            join Mode m on vw.ModeID = m.ID
                                    join [OrderStatus] os on o.OrderStatusID = os.ID
		                           where os.OrderStatusCode in ('PIKL','PLCN') {2}
		                            Group by o.RefNo,iss.IDPrinted, os.OrderStatus,vwpl.WarehouseName,m.TypeName,vw.AccountName
                                    order by m.TypeName,vw.AccountName,o.RefNo,iss.IDPrinted,vwpl.WarehouseName",
                orderApproved, issued, queryFilter);
        }

        [SelectQuery]
        public static string SelectOutstandingIssuedDeliveryNote(int warehouseID, int orderApproved, int issued)
        {
            string queryFilter = "";
            if (warehouseID != 0)
            {
                queryFilter = string.Format(" and vwpl.WarehouseID = {0} ", warehouseID);
            }
            return String.Format(
                @"Select o.RefNo as [OrderNo],iss.IDPrinted as InvoiceNo, (os.OrderStatus + ' /Unconfirmed') as [Status],vwpl.WarehouseName as Warehouse,m.TypeName as [Mode],Max(vw.AccountName) as AccountName,Max(vw.ActivityName) as ActivityName   
	                            from [Order] o
		                            Join orderDetail od on o.ID = od.OrderID
		                            join OrderStatus os on o.OrderStatusID = os.ID
		                            Join Picklist pl on o.ID = pl.OrderID 
		                            Join PicklistDetail pld on pl.Id = pld.PicklistID
		                            left Join IssueDoc id on pld.ID=id.PLDetailID
									left join issue iss on id.STVID=iss.ID
									join ReceiveDoc rd on pld.ReceiveDocID=rd.ID
		                            Join receivePallet rp on rd.ID = rp.ReceiveID
		                            Join vwPallet vwpl on rp.PalletLocationID = vwpl.PalletLocationID
		                            join vwAccounts vw on pld.StoreID = vw.ActivityID 
		                            join Mode m on vw.ModeID = m.ID
		                            where  os.OrderStatusCode  in ('APRD','PIKL','PLCN','ISUD') {2}  and IsDeliveryNote = 1 and (IsNull(HasDeliveryNoteBeenConverted,0) = 0) 
		                            Group by o.RefNo,iss.IDPrinted, os.OrderStatus,vwpl.WarehouseName,m.TypeName
                                    order by m.TypeName,Max(vw.AccountName),Max(vw.ActivityName),o.RefNo,iss.IDPrinted,vwpl.WarehouseName",
                orderApproved, issued, queryFilter);
        }

        [SelectQuery]
        public static string SelectGetOutstandingRequestedVoidForInvoice(int warehouseID, int orderApproved, int issued)
        {
            string queryFilter = "";
            if (warehouseID != 0)
            {
                queryFilter = string.Format(" and vwpl.WarehouseID = {0} ", warehouseID);
            }

            return String.Format(
                @"Select o.RefNo as [OrderNo],iss.IDPrinted as InvoiceNo, os.OrderStatus as [Status],vwpl.WarehouseName as Warehouse,m.TypeName as [Mode],vw.AccountName 
	                            from [Order] o
		                            Join orderDetail od on o.ID = od.OrderID
		                            Left join issuedoc id on o.ID = id.OrderID
		                            left join issue iss on id.STVID = iss.ID
		                            join OrderStatus os on o.OrderStatusID = os.ID
		                            Join Picklist pl on o.ID = pl.OrderID 
		                            Join PicklistDetail pld on pl.Id = pld.PicklistID 
		                            Join receivePallet rp on rp.ID = pld.ReceivePalletID 
		                            Join vwPallet vwpl on rp.PalletID = vwpl.PalletID
		                            join vwAccounts vw on od.StoreID = vw.ActivityID 
		                            join Mode m on vw.ModeID = m.ID
		                            where os.OrderStatusCode in ('PIKL','PLCN','ISUD') {2} and iss.VoidRequest = 1 and (isNull(iss.IsVoided,0) = 0)
                                    Group by o.RefNo,iss.IDPrinted, os.OrderStatus,vwpl.WarehouseName,m.TypeName,vw.AccountName                                    
                                    order by m.TypeName,vw.AccountName,o.RefNo,iss.IDPrinted,vwpl.WarehouseName",
                orderApproved, issued, queryFilter);
        }

        [SelectQuery]
        public static string SelectCheckOutStandingIssues(int warehouseID, int warehouseCount, int orderApproved, int issued)
        {
            string queryFilter = "";
            if (warehouseID != 0 && warehouseCount > 1)
            {
                queryFilter = string.Format(" and PalletLocationID in(select PalletLocationID from vwPallet vwpl where vwpl.WarehouseID ={0}) ", warehouseID);
            }

            return String.Format(
                @"Select Count(*) count
                        from [Order] o
		                   Left join issuedoc id on o.ID = id.OrderID
		                   left join issue iss on id.STVID = iss.ID
		                   Join Picklist pl on o.ID = pl.OrderID 
		                   Join PicklistDetail pld on pl.Id = pld.PicklistID 
                           join OrderStatus os on os.ID = OrderStatusID
		               where ((os.OrderStatusCode in ('APRD','PIKL','PLCN'))  or (IsDeliveryNote = 1 and IsNull(HasDeliveryNoteBeenConverted,0) = 0) or (iss.VoidRequest = 1 and (isNull(iss.IsVoided,0) = 0)) and os.OrderStatusCode <> 'DSCN') {2}",
                orderApproved, issued, queryFilter);
        }

        [SelectQuery]
        public static string SelectLoadMissingByOrderId(int orderID)
        {
            return String.Format(@"SELECT id.*, 
                                                       v.FullItemName, 
                                                       ru.name AS IssueLocation, 
                                                       iu.text AS Unit 
                                                FROM   issuedoc id 
                                                       JOIN vwgetallitems v 
                                                         ON id.itemid = v.id 
                                                       JOIN institution ru 
                                                         ON ru.id = id.receivingunitid 
                                                       JOIN receivedoc rd 
                                                         ON id.recievdocid = rd.id 
                                                       JOIN itemunit iu 
                                                         ON rd.unitid = iu.id 
                                                WHERE  id.orderid = {0} and id.STVID is null", orderID);
        }
       
        [SelectQuery]
        public static string SelectIssuedAmountForInstitutionsByDate(DateTime from, DateTime to)
        {
            return  string.Format(@"SELECT i.Name Institution,it.Name InstitutionType,ot.Name [Ownership] ,r.RegionName Region,
                                       z.ZoneName Zone,
                                                  w.WoredaName Woreda,
                                                  i.Phone,
                                                  i.TinNo,
                                                  SUM(id.Quantity*rd.UnitCost) IssuedAmount
                                FROM IssueDoc id
								JOIN ReceiveDoc rd ON rd.ID = id.RecievDocID
                                LEFT JOIN Institution i ON i.ID = id.ReceivingUnitID
                                LEFT JOIN Woreda w ON w.ID = i.Woreda
                                LEFT JOIN ZONE z ON z.ID = i.ZONE
								LEFT JOIN Region r ON r.ID = z.RegionID
                                LEFT JOIN InstitutionType it ON it.ID = i.RUType
								LEFT JOIN OwnershipType ot ON ot.ID = i.[Ownership]
								WHERE id.ReceivingUnitID is not null 
								AND Cast(id.EurDate as Date) >= '{0}' and Cast(id.EurDate as Date) <= '{1}'
                                GROUP BY i.Name,
                                         i.Phone,
                                         i.Town,
                                         i.TinNo,
                                         w.WoredaName,
                                         z.ZoneName,
                                         it.Name,
										 r.RegionName,
										 ot.Name", from ,to); 
           }
    }
    
}
