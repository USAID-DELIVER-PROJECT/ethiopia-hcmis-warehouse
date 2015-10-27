using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class Issue
    {
        [SelectQuery]
        public static string SelectGetLogFor(string refNo)
        {
            return String.Format("Select * from STVLog where RefNo = '{0}'", refNo);
        }

        [SelectQuery]
        public static string SelectGetLastPrintedIDByPaymentTypeID(int activityId, int? paymentTypeId)
        {
            return String.Format(@"Select top(1) sl.IDPrinted 
                                        from STVLog sl join Picklist pl on sl.PicklistID=pl.ID join [Order] o on o.ID=pl.OrderID 
                                            join stores stor on sl.StoreID=stor.ID 
                                            join StoreGroupDivision sDiv on stor.StoreGroupDivisionID=sDiv.ID 
                                            join StoreGroup sg on sDiv.StoreGroupID=sg.ID
                                        where sg.ID in (select sg.ID 
                                            from stores stor join StoreGroupDivision sDiv on stor.StoreGroupDivisionID=sDiv.ID 
                                                    join StoreGroup sg on sDiv.StoreGroupID=sg.ID where stor.ID={0}) and o.PaymentTypeID = {1}
                                        Order By sl.IDPrinted desc", activityId, paymentTypeId);
        }

        [UpdateQuery]
        public static string UpdateFixInconsistencies()
        {
            string query = String.Format(@"update s
                                           set s.PickListID=pl.ID
                                           from PickListDetail pld join stvlog s on pld.ID=s.PicklistID join PickList pl on pl.ID=pld.PickListID
                                           where pld.ID in (select PickListID from STVLog where PickListID not in (select ID from PickList) group by PickListID)");
            return query;
        }

        [SelectQuery]
        public static string SelectGetIssueDetails(int _stvID)
        {
            string query = String.Format(@"select
                                               *,
                                               id.ID as IssueDocID,
                                               iu.Text as Unit,
                                               pld.*,
                                               p.PalletNo,
                                               supp.CompanyName as SupplierName,
                                               i.FullItemName,
                                               i.Name as CommodityType,
                                               m.Name ManufacturerName,
                                               vwp.PalletLocation,
                                               id.NoOfPack ActuallyIssuedNoOfPack
                                            from
                                               IssueDoc id 
                                            join
                                               STVLog s 
                                                  on id.STVID=s.ID 
                                            join
                                               vwGetAllItems i 
                                                  on i.ID=id.ItemID 
                                            join
                                               PickListDetail pld 
                                                  on pld.ID=id.PLDetailID 
                                            join
                                               Manufacturers m 
                                                  on m.ID = pld.ManufacturerID 
                                            left join
                                               ItemUnit iu 
                                                  on pld.UnitID = iu.ID 
                                            join
                                               vwPalletLocation vwp 
                                                  on vwp.ID = pld.PalletLocationID 
                                            left Join
                                               PalletLocation plc 
                                                  on pld.PalletLocationID = plc.ID 
                                            left join
                                               Pallet p 
                                                  on plc.PalletID = p.ID 
                                            join
                                               ReceiveDoc rd 
                                                  on pld.ReceiveDocID = rd.ID 
                                            join
                                               Supplier supp 
                                                  on rd.SupplierID = supp.ID 
                                            where
                                               id.DispatchConfirmed=0 
                                               and s.ID = {0}", _stvID);
            return query;
        }

        [UpdateQuery]
        public static string UpdateMarkAsDispatched(int userID, int id)
        {
            string query = String.Format(@"update IssueDoc
                                            set DispatchConfirmed=1, DispatchConfirmationDate=GETDATE(),DispatchConfirmedByUserID={0}, NoOfPackIssued=NoOfPack
                                            where STVID={1}", userID, id);
            return query;
        }

        [UpdateQuery]
        public static string UpdateMarkAsDispatched(int id)
        {
            string queryConfirmIssue = String.Format(@"update Issue set IsChecked=1 WHERE ID={0}", id);
            return queryConfirmIssue;
        }

        [SelectQuery]
        public static string SelectLoadLatestReprint(int id)
        {
            string query = String.Format("select * from STVLog where IsReprintOf = {0} or ID = {0} order by IDPrinted desc", id);
            return query;
        }

        [SelectQuery]
        public static string SelectGetLogForFacility(int storeID, int facilityID)
        {
            string query = String.Format(@"Select distinct max(s.ID) ID
                                            , MAX(s.IDPrinted) IDPrinted
                                            ,cast (cast(Max(s.PrintedDate) as date) as varchar) PrintedDate  
                                            from STVLog s join IssueDoc id on s.IsReprintOf=id.STVID 
                                            where IsReprintOf is not null and id.ReceivingUnitID={0} and s.StoreID={1}
                                            group by s.IsReprintOf

                                            union
 
                                            select distinct s.ID
                                            ,s.IDPrinted
                                            ,cast (cast(s.PrintedDate as date) as varchar) PrintedDate
                                            from STVLog s join IssueDoc id on id.STVID=s.ID
                                            where not exists (select * from stvlog where IsReprintOf = s.ID) and id.ReceivingUnitID={0} and s.StoreID={1}
                                            ", facilityID, storeID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetVisitHistoryForFacility(int facilityID)
        {
            string query = String.Format(@"SELECT  AllFacilitiesHistory.InstitutionID ,
                                                    AllFacilitiesHistory.VisitCount ,
                                                    AllFacilitiesHistory.LastVisit ,
                                                    AllFacilitiesHistory.FacilityName,
		                                            AllFacilitiesHistory.OrderType,  
                                                    AllFacilitiesHistory.Description               
                                            FROM    ( SELECT    iss.ReceivingUnitID InstitutionID ,
                                                                COUNT(iss.ReceivingUnitID) VisitCount ,
                                                                MAX(iss.PrintedDate) LastVisit ,
                                                                i.Name FacilityName,
					                                            ot.Name OrderType,
                                                                ot.Description Description
                                                      FROM      Issue iss
                                                                JOIN Institution i ON iss.ReceivingUnitID = i.ID
					                                            JOIN dbo.IssueDoc id ON iss.id = id.STVID
					                                            JOIN dbo.[Order] od ON id.OrderID = od.ID
					                                            JOIN dbo.OrderType ot ON od.OrderTypeID = ot.OrderTypeID
                                                    GROUP BY  iss.ReceivingUnitID,
                                                                i.Name ,
					                                            ot.Name,
                                                                ot.Description
                                                    ) AS AllFacilitiesHistory
                                            WHERE AllFacilitiesHistory.InstitutionID={0}", facilityID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetVisitHistoryForFacility(string facilityname)
        {
            string query = String.Format(@"SELECT  AllFacilitiesHistory.InstitutionID ,
                                                    AllFacilitiesHistory.VisitCount ,
                                                    AllFacilitiesHistory.LastVisit ,
                                                    AllFacilitiesHistory.FacilityName,
		                                            AllFacilitiesHistory.OrderType
                                            FROM    ( SELECT    iss.ReceivingUnitID InstitutionID ,
                                                                COUNT(iss.ReceivingUnitID) VisitCount ,
                                                                MAX(iss.PrintedDate) LastVisit ,
                                                                i.Name FacilityName,
					                                            ot.Name OrderType
                                                      FROM      Issue iss
                                                                JOIN Institution i ON iss.ReceivingUnitID = i.ID
					                                            JOIN dbo.IssueDoc id ON iss.id = id.STVID
					                                            JOIN dbo.[Order] od ON id.OrderID = od.ID
					                                            JOIN dbo.OrderType ot ON od.OrderTypeID = ot.OrderTypeID
                                                    GROUP BY  iss.ReceivingUnitID ,
                                                                i.Name ,
					                                            ot.Name
                                                    ) AS AllFacilitiesHistory
                                            WHERE AllFacilitiesHistory.FacilityName='{0}'", facilityname);
            return query;
        }
        [SelectQuery]
        public static string SelectGetDeliveryNotesToBeConverted(int storeId)
        {
            string query =
                String.Format(@"SELECT * FROM (SELECT           s.ID,
								o.RefNo OrderNo,
								pt.Name PaymentType,
								os.OrderStatus,
								ot.Name OrderType,
								i.InstitutionTypeName InstitutionType,
								i.OwnershipTypeName OwnershipType,
								i.RegionName Region,
								i.ZoneName Zone,
								i.WoredaName Woreda,
								acc.ModeName Mode,
								acc.AccountName Account,
								acc.SubAccountName SubAccount,
								acc.ActivityName Activity,
                                CASE
		                            WHEN i.Name IS NULL THEN 'Transfer'
		                            ELSE i.Name
                                END AS FacilityName,
								CASE WHEN rep.IDPrinted IS NOT NULL THEN rep.IDPrinted 
								ELSE s.IDPrinted
								END AS PrintedID,
								s.PrintedDate,
								sUser.FullName PrintedBy,
								o.EurDate RequestedDate,
								oUser.FullName RequestedBy
                            FROM Issue s
							LEFT JOIN PickList pl on s.PickListID = pl.ID
							LEFT JOIN [Order] o on pl.OrderID = o.ID
							LEFT JOIN [OrderStatus] os on o.OrderStatusID = os.ID
							LEFT JOIN [OrderType] ot on o.OrderTypeID = ot.OrderTypeID
							LEFT JOIN [PaymentType] pt on o.PaymentTypeID = pt.ID
                            LEFT JOIN vwInstitution i ON s.ReceivingUnitID = i.ID
							LEFT JOIN vwAccounts acc on s.StoreID = acc.ActivityID
							LEFT JOIN (SELECT ID, IsReprintOf, IDPrinted FROM dbo.STVLog WHERE IsReprintOf IS NOT NULL) rep ON s.ID = rep.IsReprintOf
							LEFT JOIN [User] sUser on s.UserID = sUser.ID
							LEFT JOIN [User] oUser on o.FilledBy = oUser.ID
                            WHERE s.IsDeliveryNote = 1
			                            AND 
                            (s.HasDeliveryNoteBeenConverted = 0 OR s.HasDeliveryNoteBeenConverted IS NULL)
			                            AND 
                            (SELECT COUNT(*) FROM IssueDoc id WHERE id.STVID = s.ID AND id.StoreID = {0}) > 0 
							) x
							Order by PrintedID", storeId);
            return query;
        }

        [SelectQuery]
        public static string SelectGetDetailItems(int STVLogID)
        {
            string query =
                String.Format(@"SELECT id.ID,
                               v.FullItemName,
	                           iu.Text Unit,
                               rd.SellingPrice ,
                               CASE
                                   WHEN rd.SellingPrice IS NOT NULL
                                        AND rd.SellingPrice <> 0 AND rdc.ReceiptConfirmationStatusID = 
																(SELECT ID FROM ReceiptConfirmationStatus WHERE ReceiptConfirmationStatusCode ='GRVP') THEN 'Priced'
                                   ELSE 'Not Priced'
                               END AS Status ,
                               id.Quantity / id.QtyPerPack AS Packs
                        FROM vwGetAllItems v
                        JOIN IssueDoc id ON v.ID = id.ItemID
                        JOIN ReceiveDoc rd ON rd.ID = id.RecievDocID
						JOIN ReceiveDocConfirmation rdc on rd.ID = rdc.ReceiveDocID						
                        JOIN ItemUnit iu on iu.ItemID = v.ID AND iu.ID = id.UnitID
                        WHERE id.STVID = {0}",
                    STVLogID);
            return query;
        }

        [SelectQuery]
        public static string SelectSearch(string searchString, string type, int paymentType)
        {
            string query =
                String.Format(
                    "select * from (select s.ID,  RIGHT('00000' + CAST (s.IDPrinted as nvarchar), 5) as {0},a.AccountName, rus.Name as [To], cast(s.PrintedDate as Date) PrintedDate, case when s.IsVoided = 1 or( (select count(*) from IssueDoc where STVID = s.ID) = 0 and s.IsRePrintOf is null) then 1 else 0 end IsVoid from STVLog s join vwAccounts a on s.StoreID = a.ActivityID left join Institution rus on s.ReceivingUnitID = rus.ID join PickList pl on pl.ID = s.PickListID join [Order] o on o.ID = pl.OrderID where s.IDPrinted = {1} and o.PaymentTypeID = {2} and isnull(s.IsDeliveryNote,0) = 0) iq where IsVoid = 0",
                    type, searchString, paymentType);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadAllReprints(int stvID)
        {
            string query = String.Format("select * from STVLog where IsReprintOf = {0}", stvID);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadAllNotChecked(int userID)
        {
            string query = String.Format(
                @"SELECT Distinct
                           iss.ID, 
                           acct.AccountName,
                           acct.SubAccountName,
                           acct.ActivityName,
                           RIGHT('0000' + Cast(iss.IDPrinted AS VARCHAR), 5) IDPrinted,
                           case when ru.Name is null then 'Transfer' else ru.Name END as                                FacilityName,
                           iss.PrintedDate,
                           iss.IsChecked,
                           0 as IsChanged                           
                    FROM   [Issue] iss
                           JOIN vwAccounts acct
                             ON iss.StoreID = acct.ActivityID
                           LEFT JOIN ReceivingUnits ru
                             ON iss.ReceivingUnitID = ru.ID
                           JOIN IssueDoc id
                             ON iss.ID = id.STVID
                           JOIN ReceiveDoc rd
                             ON id.RecievDocID = rd.ID
                           JOIN vwReceiptPallet rp
                             ON rd.ID = rp.ReceiveDocID
                    WHERE  iss.StoreID IN (SELECT ActivityID
                                                   FROM   UserActivity
                                                   WHERE  UserID = {0}
                                                          AND CanAccess = 1)
                               AND id.InventoryPeriodID in (Select CurrentInventoryPeriodID from UserPhysicalStore ups join physicalStore ps on ps.ID = ups.PhysicalStoreID  where UserID={0} and CanAccess=1)  

                              
                    UNION
                    --These are reprints
                    SELECT Distinct
                           iss.ID, 
                           acct.AccountName,
                           acct.SubAccountName,
                           acct.ActivityName,
                           'Re-' + RIGHT('0000' + Cast(iss.IDPrinted AS VARCHAR), 5) IDPrinted,
                           case when ru.Name is null then 'Transfer' else ru.Name END as                                FacilityName,
                           iss.PrintedDate,
                           iss.IsChecked,
                           0 as IsChanged
                    FROM   [Issue] iss
                           JOIN vwAccounts acct
                             ON iss.StoreID = acct.ActivityID
                           JOIN ReceivingUnits ru
                             ON iss.ReceivingUnitID = ru.ID
                           JOIN IssueDoc id
                             ON iss.IsReprintOf = id.STVID
                           JOIN ReceiveDoc rd
                             ON id.RecievDocID = rd.ID
                           JOIN vwReceiptPallet rp
                             ON rd.ID = rp.ReceiveDocID 
                    WHERE  iss.StoreID IN (SELECT ActivityID
                                                   FROM   UserActivity
                                                   WHERE  UserID = {0}
                                                          AND CanAccess = 1)
                               AND id.InventoryPeriodID in (Select CurrentInventoryPeriodID from UserPhysicalStore ups join physicalStore ps on ps.ID = ups.PhysicalStoreID  where UserID={0} and CanAccess=1)  
                    ORDER  BY PrintedDate DESC ",
                userID);
            return query;
        }

        [UpdateQuery]
        public static string UpdateSaveInvoiceChecked(bool isChecked, int id)
        {
            string query = String.Format("UPDATE Issue SET IsChecked=cast('{0}' as bit) WHERE ID={1}", isChecked, id);
            return query;
        }

        [SelectQuery]
        public static string SelectGetIssueDescriptions(int accountID)
        {
            string query = String.Format(@"select *, x.TotalAmount
                                         from vwInvoiceDescription s
                                            join (select STVID,Count(*) NoOfTransactions,sum(Cost) TotalAmount from IssueDoc group by STVID) as x on x.STVID=s.STVID
                                         where AccountID = {0}
                                         ORDER BY PrintedNo DESC", accountID);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadSTVDetails(int stvID)
        {
            string query =
                String.Format(
                    @"SELECT iss.IDPrinted STVNo, 
                               i.FullItemName, 
                               acct.ActivityName, 
                               id.NoOfPack   Qty, 
                               iu.[text]     UnitName, 
                               m.name       Manufacturer, 
                               rd.BatchNo,
                               cast(rd.ExpDate as date) ExpDate
                        FROM   issue iss 
                               JOIN issuedoc id 
                                 ON iss.id = id.stvid 
                               JOIN receivedoc rd 
                                 ON id.recievdocid = rd.id 
                               JOIN vwAccounts acct 
                                 ON id.storeid = acct.activityid 
                               JOIN vwgetallitems i 
                                 ON rd.itemid = i.id 
                               JOIN itemunit iu 
                                 ON rd.unitid = iu.id 
                               JOIN manufacturer m 
                                 ON rd.manufacturerid = m.id 
                        WHERE iss.ID={0}
                        UNION

                        SELECT iss.IDPrinted STVNo, 
                               i.FullItemName, 
                               acct.ActivityName, 
                               id.NoOfPack   Qty, 
                               iu.[text]     UnitName, 
                               m.name       Manufacturer, 
                               rd.BatchNo,
                               cast(rd.ExpDate as date) ExpDate
                        FROM   issue iss 
                               JOIN issuedoc id 
                                 ON iss.IsReprintOf = id.stvid 
                               JOIN receivedoc rd 
                                 ON id.recievdocid = rd.id 
                               JOIN vwAccounts acct 
                                 ON id.storeid = acct.activityid 
                               JOIN vwgetallitems i 
                                 ON rd.itemid = i.id 
                               JOIN itemunit iu 
                                 ON rd.unitid = iu.id 
                               JOIN manufacturer m 
                                 ON rd.manufacturerid = m.id
                        WHERE iss.ID={0}
                        ", stvID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetTotalInvoices()
        {
            string query = String.Format(@"select count(*) Value from Issue iss
                                        where iss.IsVoided<>1 and not exists (select * from Issue where IsReprintOf=iss.ID)");
            return query;
        }

        [SelectQuery]
        public static string SelectGetUnconfirmedInvoices()
        {
            string query = String.Format(@"select count(*) Value from Issue iss
                                            where iss.IsVoided<>1 and not exists (select * from Issue where IsReprintOf=iss.ID) and (IsChecked=0 or IsChecked is null)");
            return query;
        }

        [SelectQuery]
        public static string SelectGetConfirmedInvoices()
        {
            string query = String.Format(@"select count(*) Value from Issue iss
                                            where iss.IsVoided<>1 and not exists (select * from Issue where IsReprintOf=iss.ID) and (IsChecked=1)");
            return query;
        }

        [SelectQuery]
        public static string SelectGetIssueDetailByFacility(int accountId, DateTime fromdate, DateTime toDate, int facilityID)
        {
            string query = String.Format(@"SELECT * 
                                            From 
					                                            (
						                                             SELECT RIGHT('0000' + Cast(iss.idprinted AS VARCHAR(50)), 5) AS PrintedNo, iss.id STVID,acct.AccountName,acct.AccountID,iss.PrintedDate,ru.ID,ru.name IssuedTo     
						                                             FROM   [issue] iss JOIN vwaccounts acct  ON iss.storeid = acct.activityid  
								                                            left JOIN receivingunits ru ON iss.receivingunitid = ru.id
					                                            ) s
                                            JOIN  
		                                                       (
				                                                 SELECT STVID,Count(*) NoOfTransactions,sum(Cost) TotalAmount 
				                                                 FROM IssueDoc
					                                             GROUP BY STVID
				                                               ) as x 
                                            ON x.STVID=s.STVID
                                            where s.AccountID = {0} and Cast(PrintedDate as Date) >= '{1}' and Cast(PrintedDate as Date) <= '{2}' and s.ID = {3}
                                            Order by PrintedDate DESC", accountId, fromdate.ToShortDateString(),
                toDate.ToShortDateString(), facilityID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetDispatchConfirmationStatus(int accountID, int warehouseID)
        {
            return String.Format(@"select *, x.TotalAmount
                                         from vwInvoiceDescription s
                                            join (
                                                    select STVID,Count(*) 
                                                    NoOfTransactions
                                                    , sum(Cost) TotalAmount 
                                                    , DispatchConfirmed 
                                                    , IssuedBy 
                                                    , PhysicalStoreID
                                                    , OrderID
											        , ReceivingUnitID
                                                    , ot.Name OrderType
											        , IssueTypeID
                                         from IssueDoc
                                             join [Order] o on o.ID = OrderID
											 join OrderType ot on o.OrderTypeID = ot.OrderTypeID
                                         group by STVID,ot.Name,DispatchConfirmed ,IssuedBy ,PhysicalStoreID,OrderID,ReceivingUnitID,IssueTypeID) as x on x.STVID=s.STVID join PhysicalStore ps on x.PhysicalStoreID = ps.ID
                                         where AccountID = {0} and PhysicalStoreTypeID ={1}
                                         ORDER BY PrintedNo DESC", accountID, warehouseID);
        }

        [SelectQuery]
        public static string SelectPrintedQtyAndActualDispatched(int accountID)
        {
            return String.Format(@"select *, x.TotalAmount from vwInvoiceDescription s join (select STVID,Count(*) NoOfTransactions,sum(Cost) TotalAmount ,ItemID ,BatchNo ,StoreID ,UnitID ,IssuedBy , DispatchConfirmed ,NoOfPack ,NoOfPackIssued from IssueDoc group by STVID,ItemID ,BatchNo ,StoreID ,UnitID ,IssuedBy ,DispatchConfirmed ,NoOfPack ,NoOfPackIssued) as x on x.STVID=s.STVID join vwGetAllItems vw on x.ItemID = vw.ID join ItemUnit iu on x.UnitID =iu.ID where AccountID = {0}  and DispatchConfirmed =1 ORDER BY PrintedNo DESC ", accountID);
        }

        [SelectQuery]
        public static string SelectIssueByOrderID(int orderID)
        {
            return String.Format(@"select iss.* from issue iss  join PickList pl on iss.PickListID = pl.ID  where pl.OrderID={0}", orderID);
        }

        [SelectQuery]
        public static string SelectIssueByPicklistID(int picklistID)
        {
            return String.Format(@"select iss.* from issue iss  join PickList pl on iss.PickListID = pl.ID  where pl.ID = {0}", picklistID);
        }
    }
}
