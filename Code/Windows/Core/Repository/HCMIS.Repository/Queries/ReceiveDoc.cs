using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class ReceiveDoc
    {
        [SelectQuery]
        public static string SelectGetAllWithQuantityLeft(int itemID, int storeID)
        {
            string query =
                String.Format(
                    "select * from receivedoc where quantityleft>0 and itemid={0} and storeID={1} and SubProgramID={2}",
                    itemID, storeID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetDistinctRecDocments(int storeId)
        {
            return String.Format(
                @"SELECT DISTINCT TOP (100) PERCENT rd.RefNo,rd.ReceiptID, rd.StoreID, rd.Date,rt.Name ReceiptType, rcs.Name ReceiptStatus,r.DateOfEntry ReceivedDate, rUser.FullName ReceivedBy
                    ,acc.ModeName Mode, acc.AccountName Account, acc.SubAccountName SubAccount, acc.ActivityName Activity,
                    s.Name Supplier, ri.STVOrInvoiceNo,pot.Name POType, pt.Name PaymentType, p.PONumber, dt.Name DocumentType, st.ClusterName Cluster, st.WarehouseName Warehouse, st.PhysicalStoreName PhysicalStore
                    FROM ReceiveDoc rd
                    Join vwAccounts acc on rd.StoreID = acc.ActivityID
                    Join Receipt r on rd.ReceiptID = r.ID
                    Join ReceiptInvoice ri on r.ReceiptInvoiceID = ri.ID
                    Join PO p on ri.POID = p.ID
                    Left Join Commodity.Supplier s on p.SupplierID = s.SupplierID
                    Left Join Procurement.PurchaseOrderType pot on p.PurchaseType = pot.PurchaseOrderTypeID
                    Left Join PaymentType pt on p.PaymentTypeID = pt.ID
                    Left Join MessageBroker.DocumentType dt on ri.DocumentTypeID = dt.DocumentTypeID
                    Join vwPhysicalStore st on rd.PhysicalStoreID = st.PhysicalStoreID
                    Join  [User] rUser on r.SavedByUserID = rUser.ID
                    Join ReceiptType rt on r.ReceiptTypeID = rt.ID
                    Join ReceiptConfirmationStatus rcs on r.ReceiptStatusID = rcs.ID
                    --Left Join (Select ReceiptID, UserID, Reason, PrintedDate From ReceiptConfirmationPrintout) rcp on r.ID = rcp.ReceiptID 
                     WHERE rd.StoreId = {0} ORDER BY Date DESC",
                storeId);
        }

        [SelectQuery]
        public static string SelectGetTransactionByRefNo(string refNo, int storeId, string dt)
        {
            string query =
                String.Format(
                    "SELECT rd.*, ((rd.Quantity/QtyPerPack) * PricePerPack) as TotalPrice , v.FullItemName, s.CompanyName as Supplier  FROM ReceiveDoc rd join vwGetAllItems v on rd.ItemID = v.ID join Supplier s on rd.SupplierID = s.ID WHERE (RefNo = '{0}' AND Date = '{2}') AND StoreId = {1} ORDER BY Date DESC",
                    refNo, storeId, dt);
            return query;
        }

        [SelectQuery]
        public static string SelectGetAllTransaction(int storeId)
        {
            return String.Format(
                "SELECT  rd.*,((rd.Quantity/QtyPerPack) * PricePerPack) as TotalPrice, v.FullItemName, s.CompanyName as Supplier  FROM ReceiveDoc rd join vwGetAllItems v on rd.ItemID = v.ID join Supplier s on rd.SupplierID = s.ID  WHERE StoreId = {0} ORDER BY Date DESC",
                storeId);
        }

        [SelectQuery]
        public static string SelectGetTransactionBySupplierId(int storeId, int supplierId)
        {
            return String.Format(
                "SELECT  rd.*,((rd.Quantity/QtyPerPack) * PricePerPack) as TotalPrice , v.FullItemName, s.CompanyName as Supplier  FROM ReceiveDoc rd join vwGetAllItems v on rd.ItemID = v.ID join Supplier s on rd.SupplierID = s.ID  WHERE StoreId = {0} AND SupplierID = {1} ORDER BY Date DESC",
                storeId, supplierId);
        }

        [SelectQuery]
        public static string SelectGetTransactionByDateRange(int storeId, DateTime dt1, DateTime dt2)
        {
            return String.Format(
                "SELECT rd.*, ((rd.Quantity/QtyPerPack) * PricePerPack) as TotalPrice , v.FullItemName, s.CompanyName as Supplier  FROM ReceiveDoc rd join vwGetAllItems v on rd.ItemID = v.ID join Supplier s on rd.SupplierID = s.ID WHERE StoreId = {0} AND (Date BETWEEN '{1}' AND '{2}' ) ORDER BY Date DESC",
                storeId, dt1.ToShortDateString(), dt2.ToShortDateString());
        }

        [SelectQuery]
        public static string SelectGetReceivedQuantityTillMonth(int itemId, int storeId, DateTime dt1, DateTime dt2)
        {
            return String.Format(
                "SELECT SUM(NoOfPack) AS Quantity FROM ReceiveDoc WHERE (ItemID = {0}) AND (StoreID = {1} AND ( Date between '{2}' AND '{3}'))",
                itemId, storeId, dt1, dt2);
        }

        [SelectQuery]
        public static string SelectCountNeverReceivedItems()
        {
            return String.Format(
                "SELECT * FROM  dbo.vwGetAllItems WHERE (ID NOT IN (SELECT ItemID FROM  dbo.ReceiveDoc)) AND (IsInHospitalList = 1)");
        }

        [SelectQuery]
        public static string SelectCountNeverReceivedItems(int storeId)
        {
            return String.Format(
                "SELECT * FROM  dbo.vwGetAllItems WHERE (ID NOT IN (SELECT ItemID FROM  dbo.ReceiveDoc WHERE (StoreID = {0}))) AND (IsInHospitalList = 1)",
                storeId);
        }

        [SelectQuery]
        public static string SelectGetRecievedItemsWithBalance(int itemID, int storeID, int? unitID)
        {
            string query =
                String.Format(
                    "select  rd.ID, vw.FullItemName,vw.StockCode, s.CompanyName as Supplier, rp.BoxSize as BoxLevel , QuantityLeft, BatchNo, ItemID,SupplierID, ExpDate ExpiryDate, ExpDate, StoreID, RefNo, Cost, (rp.Balance / rd.QtyPerPack) as Balance, rp.ID as ReceivePalletID, ManufacturerID,m.Name as ManufacturerName,ReceiveID, PalletID, EurDate, PalletNo, vw.IsFree from ReceiveDoc rd join ReceivePallet rp on rd.ID = rp.ReceiveID join Manufacturers m on m.ID = rd.ManufacturerID left join Pallet p on p.ID = rp.PalletID join Supplier s on s.ID = rd.SupplierID join vwGetAllItems vw on vw.ID = rd.ItemID where rd.StoreID = {1} and rd.ItemID = {0} and rp.Balance > 0 {2}",
                    itemID, storeID, (unitID.HasValue) ? String.Format(" and rd.UnitID = {0}", unitID) : "");
            return query;
        }

        [SelectQuery]
        public static string SelectGetRecievedItemsWithBalanceExcludeQuaranteenShowZeroBalance(int itemID, int unitID, string quarenteen)
        {
            string query;
            query =
                String.Format(@"SELECT rd.ID,
                               vw.FullItemName,
                               pl.ID AS PalletLocationID,
                               vw.StockCode,
                               rd.BoxLevel ,
                               (QuantityLeft / QtyPerPack) AS QuantityLeft,
                               BatchNo,
                               ItemID,
                               SupplierID,
                               ExpDate ExpiryDate,
                               ExpDate,
                               s.CompanyName Supplier,
                               StoreID,
                               RefNo,
                               Cost,
                               (rp.Balance / rd.QtyPerPack) AS Balance,
                               rp.ID AS ReceivePalletID,
                               ManufacturerID,
                               m.Name AS ManufacturerName,
                               ReceiveID,
                               rp.PalletID,
                               EurDate,
                               p.PalletNo,
                               vw.IsFree,
                               Adjust = NULL,
                               CASE
                                   WHEN ExpDate < GetDate() THEN 1
                                   ELSE 0
                               END AS Reason,
                               CASE
                                   WHEN ExpDate < GetDate() THEN 1
                                   ELSE 0
                               END AS IsExpired,
                               CASE
                                   WHEN ExpDate < GetDate() THEN Balance
                                   ELSE NULL
                               END AS Loss,
                               vp.WarehouseName
                        FROM ReceiveDoc rd
                        JOIN ReceivePallet rp ON rd.ID = rp.ReceiveID
                        JOIN vwPallet vp ON rp.PalletID=vp.PalletID
                        JOIN Manufacturers m ON m.ID = rd.ManufacturerID
                        JOIN Supplier s ON rd.SupplierID=s.ID
                        LEFT JOIN Pallet p ON p.ID = rp.PalletID
                        JOIN vwGetAllItems vw ON vw.ID = rd.ItemID
                        JOIN PalletLocation pl ON pl.PalletID = rp.PalletID
                        WHERE ItemID = {0}
                          AND pl.StorageTypeID <> {1}
                          AND rd.UnitID={2}",
                    itemID, quarenteen, unitID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetRecievedItemsWithBalanceExcludeQuaranteen(int itemID, int unitID, string quarenteen)
        {
            string query;
            query =
                String.Format(@"SELECT rd.ID,
                                   vw.FullItemName,
                                   pl.ID AS PalletLocationID,
                                   vw.StockCode,
                                   rd.BoxLevel ,
                                   (QuantityLeft / QtyPerPack) AS QuantityLeft,
                                   BatchNo,
                                   ItemID,
                                   SupplierID,
                                   ExpDate ExpiryDate,
                                   ExpDate,
                                   s.CompanyName Supplier,
                                   StoreID,
                                   RefNo,
                                   Cost,
                                   (rp.Balance / rd.QtyPerPack) AS Balance,
                                   rp.ID AS ReceivePalletID,
                                   ManufacturerID,
                                   m.Name AS ManufacturerName,
                                   ReceiveID,
                                   rp.PalletID,
                                   EurDate,
                                   p.PalletNo,
                                   vw.IsFree,
                                   Adjust = NULL,
                                   CASE
                                       WHEN ExpDate < GetDate() THEN 1
                                       ELSE 0
                                   END AS Reason,
                                   CASE
                                       WHEN ExpDate < GetDate() THEN 1
                                       ELSE 0
                                   END AS IsExpired,
                                   CASE
                                       WHEN ExpDate < GetDate() THEN Balance
                                       ELSE NULL
                                   END AS Loss,
                                   vp.WarehouseName
                            FROM ReceiveDoc rd
                            JOIN ReceivePallet rp ON rd.ID = rp.ReceiveID
                            JOIN vwPallet vp ON rp.PalletID=vp.PalletID
                            JOIN Manufacturers m ON m.ID = rd.ManufacturerID
                            JOIN Supplier s ON rd.SupplierID=s.ID
                            LEFT JOIN Pallet p ON p.ID = rp.PalletID
                            JOIN vwGetAllItems vw ON vw.ID = rd.ItemID
                            JOIN PalletLocation pl ON pl.PalletID = rp.PalletID
                            WHERE ItemID = {0}
                              AND QuantityLeft > 0
                              AND rp.Balance > 0
                              AND pl.StorageTypeID <> {1}
                              AND rd.UnitID={2}",
                    itemID, quarenteen, unitID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetExpiredItemsWithBalanceExcludeQuaranteen(string quaranteen)
        {
            string query =
                String.Format(
                    "select  rd.ID, vw.FullItemName,pl.ID as PalletLocationID, vw.StockCode, rd.BoxLevel , QuantityLeft, BatchNo, ItemID,SupplierID, ExpDate ExpiryDate, ExpDate, StoreID, RefNo, Cost, rp.Balance, rp.ID as ReceivePalletID, ManufacturerID,m.Name as ManufacturerName, s.CompanyName Supplier, ReceiveID, rp.PalletID, EurDate, PalletNo, vw.IsFree,Balance as Loss, Adjust = null, Reason = 1, IsExpired = 1 from ReceiveDoc rd join ReceivePallet rp on rd.ID = rp.ReceiveID join Manufacturers m on m.ID = rd.ManufacturerID left join Supplier s on rd.SupplierID=s.ID join Pallet p on p.ID = rp.PalletID join vwGetAllItems vw on vw.ID = rd.ItemID join PalletLocation pl on pl.PalletID = rp.PalletID where QuantityLeft > 0 and rp.PalletID not in (select PalletID from PalletLocation where StorageTypeID = {0}) and rd.ExpDate < GETDATE()",
                    quaranteen);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadAllPricedReceives(int storeId)
        {
            string query =
                String.Format(
                    @"select rd.ItemID, vw.FullItemName, m.Name as Manufacturer,'Details' as SupplierName,0 supplierID, m.ID as ManufacturerID , rd.UnitID, u.Text as Unit, '' GRVNo
	                                            from ReceiveDoc rd left Join Receivepallet rp  on rp.receiveID = rd.Id join ItemUnit u on rd.UnitID = u.ID 
	                                            Join vwGetAllItems vw on vw.ID = rd.ItemID 
	                                            join Supplier s on s.ID = rd.SupplierID 
	                                            join Manufacturers m on m.ID = rd.ManufacturerID 
	                                            left join PalletLocation p on rp.palletID = p.palletID 
                                                join vwAccounts sg on sg.activityID = rd.StoreID 
                                                Join ReceiveDocConfirmation ON rd.ID = dbo.ReceiveDocConfirmation.ReceiveDocID
                                                join StorageType st on st.ID = p.StorageTypeID
                                                join ReceiptConfirmationStatus rcs on rcs.ID = ReceiveDocConfirmation.ReceiptConfirmationStatusID
	                                       where (st.StorageTypeCode <> 'SA' or p.StorageTypeID is null) 
                                                and rp.Balance > 0 and (rd.ExpDate > GetDate() or rd.ExpDate is null) and (rcs.ReceiptConfirmationStatusCode in ('GRVP','SREC','CANC','GRNFP'))
                                                and sg.MovingAverageID={0} 
                                                group by rd.ItemID, vw.FullItemName, m.Name, m.ID , rd.UnitID, u.Text
	                                                Having Count(Distinct Cost) < 2 and COUNT(Distinct SellingPrice) < 2 ",
                    storeId);
            return query;
        }

        [SelectQuery]
        public static string SelectDoesPriceNeedToBeChanged(int storeID, int itemID, int unitID, int ManufacturerID)
        {
            string query;
            query = String.Format(@"select rd.ItemID,rd.UnitID,rd.ManufacturerId,acc.MovingAverageID,rd.Cost, rd.SellingPrice
                                        from Receivedoc rd 
                                            join vwAccounts acc on acc.ActivityID = rd.StoreID 
                                            join ReceivePallet rp on rp.ReceiveID = rd.ID
                                            left join PalletLocation pl on rp.PalletID = pl.PalletID
                                       	    left    Join ReceivedocConfirmation rdc on rdc.ReceiveDocID = rd.ID
                                            join ReceiptConfirmationStatus rcs on rcs.ID = rdc.ReceiptConfirmationStatusID
                                            join StorageType st on st.ID = pl.StorageTypeID
											where Balance > 0 
												and (st.StorageTypeCode <> 'SA' or pl.StorageTypeID is Null) 
												and (rd.ExpDate > GETDATE() or rd.ExpDate is null) 
	                                            and rd.Confirmed = 1 
												and rcs.ReceiptConfirmationStatusCode in ('GRVP','SREC','CANC')
										        and rd.ItemID = {0} and rd.UnitID ={1} and rd.ManufacturerID = {2} and acc.MovingAverageID in(select distinct MovingAverageID from vwAccounts vw where vw.ActivityID = {3}) 
	                                    Group by rd.ItemID,rd.UnitID,rd.ManufacturerId,acc.MovingAverageID,rd.Cost,rd.Margin,rd.SellingPrice",
                itemID, unitID, ManufacturerID, storeID);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadAllItemsPendingPriceConfirmation(int AccountId)
        {
            string query;
            query = String.Format(
                @"select rd.ItemID,vw.FullItemName,0 SupplierID,rd.ManufacturerID,rd.UnitID,m.Name as Manufacturer,u.Text as Unit,CAST(Max(rcp.IDPRinted) as varchar(50)) GRVNo  from ReceiveDoc rd join Supplier s on rd.SupplierID = s.ID
                            join vwGetAllItems vw on rd.ItemID = vw.ID join Manufacturers m on rd.ManufacturerID = m.ID left join ReceivePallet rp on rp.ReceiveID = rd.ID Left Join
                            ItemUnit u on rd.UnitID = u.ID join ReceiveDocConfirmation rdc on rd.ID = rdc.ReceiveDocID left join PalletLocation p on rp.PalletID = p.PalletID
                                        join vwAccounts sg on sg.activityID = rd.StoreID left join Receipt rt on rt.ID = rd.ReceiptID left join ReceiptConfirmationPrintout rcp on rcp.ReceiptID = rt.ID
                                        join StorageType st on st.ID = p.StorageTypeID
                            where (st.StorageTypeCode <> 'SA' or p.StorageTypeID is null) and rp.Balance > 0 and sg.MovingAverageID = {0} and rdc.PriceAssignedByUserID is not null and rdc.PriceConfirmedByUserID is null
                            Group by rd.ItemID,vw.FullItemName,rd.ManufacturerID,rd.UnitID,m.Name,u.Text", AccountId);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadAllItemsPendingAverageBeginningBalanceIncluded(int accountId)
        {
            string query;
            query = String.Format(
                @"select rd.ItemID,vw.FullItemName,0 SupplierID,rd.ManufacturerID,rd.UnitID,m.Name as Manufacturer,u.Text as Unit,'Other' GRVNo   from ReceiveDoc rd join Supplier s on rd.SupplierID = s.ID
                    join vwGetAllItems vw on rd.ItemID = vw.ID join Manufacturers m on rd.ManufacturerID = m.ID left join 
                        ItemUnit u on rd.UnitID = u.ID join receivepallet rp on rp.ReceiveID = rd.ID join PalletLocation p on rp.PalletID = p.PalletID 
                       join vwAccounts sg on sg.activityID = rd.StoreID                        
                       join StorageType st on st.ID = p.StorageTypeID    
					where (st.StorageTypeCode <> 'SA' or p.StorageTypeID is null) and rp.Balance > 0 and rd.QuantityLeft > 0 and (rd.ExpDate > GetDATE() or rd.ExpDate is null) and sg.MovingAverageID = {0} and rd.confirmed = 1
                        Group by rd.ItemID,vw.FullItemName,rd.ManufacturerID,rd.UnitID,m.Name,u.Text
                    Having Count(Distinct rd.Cost) > 1 Or COUNT(Distinct SellingPrice) > 1
                        Union 
                    select rd.ItemID,vw.FullItemName,0 SupplierID,rd.ManufacturerID,rd.UnitID,m.Name as Manufacturer,u.Text as Unit,CAST(Max(rcp.IDPRinted) as varchar(50)) GRVNo   from ReceiveDoc rd join Supplier s on rd.SupplierID = s.ID
                        join vwGetAllItems vw on rd.ItemID = vw.ID join Manufacturers m on rd.ManufacturerID = m.ID left join 
                            ItemUnit u on rd.UnitID = u.ID join receivepallet rp on rp.ReceiveID = rd.ID left join PalletLocation p on rp.PalletID = p.PalletID
	                    join vwAccounts sg on sg.activityID = rd.StoreID left join Receipt rt on rt.ID = rd.ReceiptID left join ReceiptConfirmationPrintout rcp on rcp.ReceiptID = rt.ID
                        where (st.StorageTypeCode <> 'SA' or p.StorageTypeID is null) and rp.Balance > 0 and rd.QuantityLeft > 0 and(rd.ExpDate > GetDate()  or rd.ExpDate is null) and rd.Confirmed = 1 and sg.MovingAverageID = {0} and SellingPrice is null
                     Group by rd.ItemID,vw.FullItemName,rd.ManufacturerID,rd.UnitID,m.Name,u.Text", accountId);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadAllItemsPendingAverage(int accountId)
        {
            string query;
            query = String.Format(
                @"select rd.ItemID,vw.FullItemName,0 SupplierID,rd.ManufacturerID,rd.UnitID,m.Name as Manufacturer,u.Text as Unit from ReceiveDoc rd join Supplier s on rd.SupplierID = s.ID
                    join vwGetAllItems vw on rd.ItemID = vw.ID join Manufacturers m on rd.ManufacturerID = m.ID left join 
                        ItemUnit u on rd.UnitID = u.ID join receivepallet rp on rp.ReceiveID = rd.ID join PalletLocation p on rp.PalletID = p.PalletID 
                       join vwAccounts sg on sg.activityID = rd.StoreID Join dbo.ReceiveDocConfirmation ON rd.ID = dbo.ReceiveDocConfirmation.ReceiveDocID     
                       join StorageType st on st.ID = p.StorageTypeID         
				    	join ReceiptConfirmationStatus rcs on rcs.ID = ReceiveDocConfirmation.ReceiptConfirmationStatusID                  
					where (st.StorageTypeCode <> 'SA' or p.StorageTypeID is null) and rp.Balance > 0 and rd.QuantityLeft > 0 and (rd.ExpDate > GetDATE() or rd.ExpDate is null) and sg.MovingAverageID = {0} and rd.confirmed = 1 and (rcs.ReceiptConfirmationStatusCode in ('GRVP','SREC','CANC','GRNFP'))
                        Group by rd.ItemID,vw.FullItemName,rd.ManufacturerID,rd.UnitID,m.Name,u.Text
                    Having Count(Distinct Cost) > 1 Or COUNT(Distinct SellingPrice) > 1
                        Union 
                    select rd.ItemID,vw.FullItemName,0 SupplierID,rd.ManufacturerID,rd.UnitID,m.Name as Manufacturer,u.Text as Unit from ReceiveDoc rd join Supplier s on rd.SupplierID = s.ID
                        join vwGetAllItems vw on rd.ItemID = vw.ID join Manufacturers m on rd.ManufacturerID = m.ID left join 
                            ItemUnit u on rd.UnitID = u.ID join receivepallet rp on rp.ReceiveID = rd.ID left join PalletLocation p on rp.PalletID = p.PalletID
	                  join vwAccounts sg on sg.activityID = rd.StoreID  left join Receipt rt on rt.ID = rd.ReceiptID Join dbo.ReceiveDocConfirmation ON rd.ID = dbo.ReceiveDocConfirmation.ReceiveDocID
                        join StorageType st on st.ID = p.StorageTypeID         
				    	join ReceiptConfirmationStatus rcs on rcs.ID = ReceiveDocConfirmation.ReceiptConfirmationStatusID        
                        where (st.StorageTypeCode <> 'SA' or p.StorageTypeID is null) and rp.Balance > 0 and rd.QuantityLeft > 0 and(rd.ExpDate > GetDate()  or rd.ExpDate is null) and rd.Confirmed = 1 and sg.MovingAverageID = {0} and cost is not null and SellingPrice is null and (rcs.ReceiptConfirmationStatusCode in ('GRVP','SREC','CANC','GRNFP'))
			       Group by rd.ItemID,vw.FullItemName,rd.ManufacturerID,rd.UnitID,m.Name,u.Text", accountId);
            return query;
        }

        [SelectQuery]
        public static string SelectReceivedAmountByReason(int ethiopianMonth, int ethiopianYear, int accountID)
        {
            string query =
                String.Format(
                    @"Select a.AccountName, Case When (rd.UnitCost is null or rd.UnitCost = 0) and DeliveryNote = 1 then 'DeliveryNote' else rcp.Reason End [IGRV/GRV] ,Cast(rd.[Date] as Date) [Date], s.CompanyName as Name,rcp.IDPrinted,Sum(rd.UnitCost * rd.NoOfPack) TotalAmount  
                        FROM ReceiveDoc rd 
                        join Receipt rct on rd.ReceiptID=rct.ID
                        join ReceiptInvoice rctI on rct.ReceiptInvoiceID=rctI.ID
                        join PO po on rctI.POID=po.ID
                        join vwAccounts a on rd.StoreID=a.ActivityID
                        join Supplier s on rd.SupplierID=s.ID
                        join ReceiptConfirmationPrintout rcp on rct.ID=rcp.ReceiptID
                        join ReceiptType rt on rt.ID = rct.ReceiptTypeID
                        Where rt.ReceiptTypeCode = 'CBFD2
		                         and rd.RefNo<>'BeginningBalance' 
		                         and (rcp.Reason='iGRV' or rcp.Reason='GRV')
                                 and rcp.ID not in (select IsReprintOf from ReceiptConfirmationPrintout where IsReprintOf is not null)
		                         and Month(rd.[Date]) = {0} 
		                         and year(rd.[Date]) = {1}
		                         and a.AccountID = {2}
		                         and rd.SupplierID is not Null
		                         and (rd.UnitCost is Not null and rd.UnitCost <> 0)
                        Group By s.CompanyName,rcp.IDPrinted,a.AccountName,Cast(rd.[Date] as Date) ,Case When (rd.UnitCost is null or rd.UnitCost = 0) and DeliveryNote = 1 then 'DeliveryNote' else rcp.Reason End 
                        Order by IDPrinted,[Date]", ethiopianMonth, ethiopianYear, accountID);
            return query;
        }

        [SelectQuery]
        public static string SelectReceivedAmoutByYear(int ethiopianYear, int accountID)
        {
            string query =
                String.Format(
                    @"Select ROW_NUMBER() OVER (ORDER BY Month(Cast(rd.[Date] as Date))) AS Row,a.AccountName,  CASE 
                        WHEN  Month(Cast(rd.[Date] as Date)) = 1 THEN 'Meskerem '
		                WHEN  Month(Cast(rd.[Date] as Date)) = 2 THEN 'Tikimet' 
		                WHEN  Month(Cast(rd.[Date] as Date)) = 3 THEN 'Hrdar' 
		                WHEN  Month(Cast(rd.[Date] as Date)) = 4 THEN 'Tahisas'
		                WHEN  Month(Cast(rd.[Date] as Date)) = 5 THEN 'Tirr'
		                WHEN  Month(Cast(rd.[Date] as Date)) = 6 THEN 'Yekatit' 
		                WHEN  Month(Cast(rd.[Date] as Date)) = 7 THEN 'Megabit' 
		                WHEN  Month(Cast(rd.[Date] as Date)) = 8 THEN 'Miyazya'
	                    WHEN  Month(Cast(rd.[Date] as Date)) = 9 THEN 'Genbot'
		                WHEN  Month(Cast(rd.[Date] as Date)) = 10 THEN 'Sene' 
		                WHEN  Month(Cast(rd.[Date] as Date)) = 11 THEN 'Hamle' 
		                WHEN  Month(Cast(rd.[Date] as Date)) = 12 THEN 'Nehase'
		                WHEN  Month(Cast(rd.[Date] as Date)) = 13 THEN 'Pagume'
                     END   [Month],Sum(rd.UnitCost * rd.NoOfPack) TotalAmount   
                        FROM ReceiveDoc rd 
						join Receipt rct on rd.ReceiptID=rct.ID
                        join vwAccounts a on rd.StoreID=a.ActivityID
						join ReceiptConfirmationPrintout rcp on rct.ID=rcp.ReceiptID
                        join ReceiptType rt on rt.ID = rct.ReceiptTypeID
                        Where rt.ReceiptTypeCode = 'SR'
		                         and rd.RefNo <>'BeginningBalance' 
                                 and rcp.ID not in (select IsReprintOf from ReceiptConfirmationPrintout where IsReprintOf is not null)
		                         and (rcp.Reason='iGRV' or rcp.Reason='GRV')
		                         and year(rd.[Date]) = {0}
		                         and a.AccountID = {1}
		                         and (rd.UnitCost is Not null and rd.UnitCost <> 0)
                        Group By a.AccountName,Month(Cast(rd.[Date] as Date))
                        Order by Month(Cast(rd.[Date] as Date)) ", ethiopianYear, accountID);
            return query;
        }

        [SelectQuery]
        public static string SelectVitalReportReceived(int storeId, DateTime dt1, DateTime dt2)
        {
            var query = String.Format(@"select distinct Items.ID, isnull(Quantity,0) as Quantity from
                                      Items left join (select ItemID, sum(Quantity) as Quantity from ReceiveDoc rd
                                      where [Date] between Cast ('{0}' as Date) and Cast('{1}' as Date) and
                                      StoreID = {2} group by ItemID) as
                                      A on Items.ID = A.ItemID", dt1, dt2, storeId);
            return query;
        }

        [SelectQuery]
        public static string SelectVitalReportIssued(int storeId, DateTime dt1, DateTime dt2)
        {
            var query = String.Format(@"select distinct Items.ID, isnull(Quantity,0) as Quantity
                                  from Items left join (select ItemID, sum(Quantity) Quantity
                                  from IssueDoc rd where [Date] between Cast ('{0}' as Date) and Cast('{1}' as Date) and
                                  StoreID = {2} group by ItemID) as A on Items.ID = A.ItemID", dt1, dt2, storeId);
            return query;
        }

        [SelectQuery]
        public static string SelectVitalReportLost(int storeId, DateTime dt1, DateTime dt2)
        {
            var query = String.Format(@"select distinct Items.ID, isnull(Quantity,0) as Quantity from 
                                  Items left join (select ItemID, sum(case when Losses = 1 then - Quantity else
                                  Quantity end) Quantity from Disposal where [Date] between Cast ('{0}' as Date) and Cast('{1}' as Date)
                                  and StoreID = {2} group by ItemID) as A on Items.ID = A.ItemID", dt1, dt2, storeId);
            return query;
        }

        [SelectQuery]
        public static string SelectVitalReportPreferredPackSize()
        {
            var query = String.Format(@"select distinct Items.ID,Items.StockCodeDACA,Items.Cost, case Items.Cost
                                  when 0 then 1 else isnull(Items.Cost,1) end as QtyPerPack from Items");
            return query;
        }

        [SelectQuery]
        public static string SelectLoadForPricingSkipBeginningBalancePricing(int itemID, int supplierID, int storeID, int manufacturerID, int? unitId, string quaranteen)
        {
            string query;
            query =
                String.Format(
                    @"select rt.STVOrInvoiceNo RefNo, rd.ItemID, vw.FullItemName, m.Name ManufacturerName, rd.ManufacturerID ,sum(Balance / QtyPerPack) as Balance, 
                        sum(Cost * Balance / QtyPerPack) Cost, Cost as UnitCost , max(rd.SellingPrice) as SellingPrice,Max(rd.Margin) Margin,Case when sg.ActivityName = sg.SubAccountName then sg.ActivityName else sg.SubAccountName + '-' + sg.ActivityName end Activity
                        from ReceiveDoc rd Join vwGetAllItems vw on vw.ID = rd.ItemID join Manufacturers m on m.ID = rd.ManufacturerID 
                            join receivepallet rp on rp.ReceiveID = rd.ID left join PalletLocation p on rp.PalletID = p.PalletID 
                                join vwAccounts sg on sg.activityID = rd.StoreID  join receipt rt on rt.ID = rd.ReceiptID join ReceiveDocConfirmation rdc ON rd.ID = rdc.ReceiveDocID
                                join ReceiptConfirmationStatus rcs on rcs.ID = ReceiptConfirmationStatusID   
                        where rp.Balance > 0 and (rd.ExpDate > GETDATE() or rd.ExpDate is null) and rd.Confirmed = 1 and  Cost is not null and sg.MovingAverageID = {2} and rcs.ReceiptConfirmationStatusCode in ('GRVP','SREC','CANC','GRNFP') and p.StorageTypeID <> {5} and 
                        rd.ManufacturerID = {3} {4}  group by  sg.ActivityName, sg.SubAccountName,rd.ManufacturerID, rd.Cost, rd.ItemID,m.Name, 
                        vw.FullItemName,rt.STVOrInvoiceNo",
                    itemID, supplierID, storeID, manufacturerID,
                    (unitId != null) ? String.Format("and rd.UnitID = {0}", unitId) : "", quaranteen);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadForPricing(int itemID, int supplierID, int storeID, int manufacturerID, int? unitId, string quaranteen)
        {
            string query;
            query =
                String.Format(
                    @"select rt.STVOrInvoiceNo RefNo, rd.ItemID, vw.FullItemName, m.Name ManufacturerName, rd.ManufacturerID ,sum(Balance / QtyPerPack) as Balance, 
                        sum(rd.Cost * Balance / QtyPerPack) Cost, rd.Cost as UnitCost , max(rd.SellingPrice) as SellingPrice,Max(rd.Margin) Margin, Case when sg.ActivityName = sg.SubAccountName then sg.ActivityName else sg.SubAccountName + '-' + sg.ActivityName end Activity
                        from ReceiveDoc rd Join vwGetAllItems vw on vw.ID = rd.ItemID join Manufacturers m on m.ID = rd.ManufacturerID 
                            join receivepallet rp on rp.ReceiveID = rd.ID left join PalletLocation p on rp.PalletID = p.PalletID 
                                join vwAccounts sg on sg.activityID = rd.StoreID  join receipt rt on rt.ID = rd.ReceiptID join ReceiveDocConfirmation rdc ON rd.ID = rdc.ReceiveDocID
                                 join ReceiptConfirmationStatus rcs on rcs.ID = ReceiptConfirmationStatusID   
                        where rp.Balance > 0 and (rd.ExpDate > GETDATE() or rd.ExpDate is null)  and sg.MovingAverageID = {2} and rcs.ReceiptConfirmationStatusCode in ('GRVP','SREC','CANC','GRNFP') and p.StorageTypeID <> {5} and 
                        rd.ManufacturerID = {3} {4}  group by sg.ActivityName, sg.SubAccountName,rd.ManufacturerID, rd.Cost, rd.ItemID,m.Name, 
                        vw.FullItemName,rt.STVOrInvoiceNo", itemID, supplierID, storeID, manufacturerID,
                    (unitId != null) ? String.Format("and rd.UnitID = {0}", unitId) : "", quaranteen);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadForCostSheetDetailSkipBeginningBalancePricing(int itemID, int storeID, int supplierID, int manufacturerID, int unitId)
        {
            string query;
            query =
                String.Format(
                    @"select rd.RefNo as RefNo,rd.ReceiptID ReceiptID,
			                        Status = Case When rd.SellingPrice Is Null then 'Pending' else 'Processed' end,
		                                rd.Date as [Date],
		                            rd.NoOfPack as InitialQuantity,
		                            rp.Balance/rd.QtyPerPack as RemainingQuantity,
		                            rd.PricePerPack as UnitCost,
		                            IsNull(rd.Insurance,0) as Insurance,
                                    IsNull(rd.Insurance,0) as InsurancePercentage,
                                    rd.Cost ActualCost,
		                            isNull(rd.Cost,0) as AverageCost,
                                    isNull(tot.Qty,0) as AveragedQty,
                                    ISNULL(tot.TotalCost,0) as AveragedTotalCost,
                                    isnull(rd.Margin,0) as Margin,
		                            (rp.Balance/rd.QtyPerPack ) * (rd.Cost) as TotalRemainingCost,
		                            (rd.Quantity/rd.QtyPerPack ) *(rd.Cost) as TotalInitialCost,
		                            isNull(rd.Margin,0) as MarginPercentage
	                              From ReceiveDoc rd  
                                            join vwAccounts sg on sg.activityID = rd.StoreID join ReceiveDocConfirmation rdc ON rd.ID = rdc.ReceiveDocID
                                            join ReceiptConfirmationStatus rcs on rcs.ID = ReceiptConfirmationStatusID   
                                          join (select ReceiveID,sum(Balance) Balance 
														from ReceivePallet  rp 
														left join PalletLocation p on  rp.PalletID = p.PalletID 
                                                        join StorageType st on st.ID = p.StorageTypeID 
														where st.StorageTypeCode <> 'SA' or p.StorageTypeID is Null Group by ReceiveID) rp on rd.ID = rp.ReceiveID   
                                            join (select rd.Cost AverageCost,Sum(rp.Balance/rd.QtyPerPack) Qty,Sum((rp.Balance/rd.QtyPerPack ) * rd.Cost ) TotalCost 
													from ReceiveDoc rd join vwAccounts sg on sg.activityID = rd.StoreID 
													join (select ReceiveID,sum(Balance) Balance 
																from ReceivePallet  rp 
																left join PalletLocation p on rp.PalletID = p.PalletID 
                                                                join StorageType st on st.ID = p.StorageTypeID 
														  where st.StorageTypeCode <> 'SA' Group by ReceiveID) rp on rd.ID = rp.ReceiveID   
													where rd.Quantityleft >0 and rd.ItemID ={0}  and sg.MovingAverageID = {2}  and rd.ManufacturerID = {3} and unitId = {4}
													 Group by rd.Cost) tot 
													 on tot.AverageCost = rd.Cost
                            where  rp.Balance > 0 and (rd.ExpDate > GETDATE() or rd.ExpDate is Null) and rd.Confirmed = 1 and rd.ItemID ={0}  and sg.MovingAverageID= {2}  and rd.ManufacturerID = {3} and unitId = {4} and rcs.ReceiptConfirmationStatusCode in ('GRVP','SREC','CANC','GRNFP')
                        Order by AverageCost,rd.Eurdate ", itemID, supplierID, storeID, manufacturerID, unitId);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadForCostSheetDetail(int itemID, int storeID, int supplierID, int manufacturerID, int unitId)
        {
            string query;
            query =
                String.Format(
                    @"select rd.RefNo as RefNo,rd.ReceiptID ReceiptID,
			                        Status = Case When rd.SellingPrice Is Null then 'Pending' else 'Processed' end,
		                                rd.Date as [Date],
		                            rd.NoOfPack as InitialQuantity,
		                            rp.Balance/rd.QtyPerPack as RemainingQuantity,
		                            rd.PricePerPack as UnitCost,
		                            IsNull(rd.Insurance,0) as Insurance,
                                    IsNull(rd.Insurance,0) as InsurancePercentage,
                                    isNull(rd.Cost,0) ActualCost,
		                            isNull(rd.Cost,0) as AverageCost,
                                    isNull(rp.Balance/rd.QtyPerPack ,0) as AveragedQty,
                                    isNull(rp.Balance/rd.QtyPerPack ,0) * isNull(rd.Cost,0) as AveragedTotalCost,
                                    isnull(rd.Margin,0) as Margin,
		                            isnull((rp.Balance/rd.QtyPerPack ) * (rd.Cost),0) as TotalRemainingCost,
		                            isnull((rd.Quantity/rd.QtyPerPack ) *(rd.Cost),0) as TotalInitialCost,
		                            isNull(rd.Margin,0) as MarginPercentage
	                              From ReceiveDoc rd  
                                          join vwAccounts sg on sg.activityID = rd.StoreID   join (select ReceiveID,sum(Balance) Balance 
														from ReceivePallet  rp 
														left join PalletLocation p on  rp.PalletID = p.PalletID 
                                                        join StorageType st on st.ID = p.StorageTypeID    
														where st.StorageTypeCode <> 'SA' or p.StorageTypeID is Null Group by ReceiveID) rp on rd.ID = rp.ReceiveID   
                                            
                            where  rp.Balance > 0 and (rd.ExpDate > GETDATE() or rd.ExpDate is Null) and rd.Confirmed = 1 and  rd.ItemID ={0}  and sg.MovingAverageID= {2}  and rd.ManufacturerID = {3} and unitId = {4}
                            Order by AverageCost,rd.Eurdate ", itemID, supplierID, storeID, manufacturerID, unitId);
            return query;
        }

        [UpdateQuery]
        public static string UpdateSetPricePerPackCostAndSellingPrice(int rsItemId, int rsSupplierId, double rsNewUnitCost, int rsStoreId, int rsManufacturerId, int? rsUnitId, double rsNewSellingPrice, double rsMargin, string query, int noOfDigitsAfterTheDecimalPoint)
        {
            query =
                String.Format(
                    @"update ReceiveDoc set Cost = {0}, SellingPrice ={6}, Margin = {7} where ItemID= {1}  and QuantityLeft > 0 and StoreID in (select ActivityID from vwAccounts  
                                where MovingAverageID={3})  and PricePerPack is not null and  ManufacturerID = {4} {5}

                          update ReceiveDoc set PricePerPack = {0}, Cost = {0}, SellingPrice ={6}, Margin = {7} where ItemID= {1}  and QuantityLeft > 0 and StoreID in (select ActivityID from vwAccounts  
                                where MovingAverageID={3}) and PricePerPack is  null and ManufacturerID = {4} {5}",
                    Math.Round(rsNewUnitCost, noOfDigitsAfterTheDecimalPoint), rsItemId, rsSupplierId,
                    rsStoreId, rsManufacturerId, (rsUnitId != null) ? String.Format(" and UnitID = {0}", rsUnitId) : "",
                    Math.Round(rsNewSellingPrice, noOfDigitsAfterTheDecimalPoint),
                    Math.Round(rsMargin, noOfDigitsAfterTheDecimalPoint + 2));
            return query;
        }

        [UpdateQuery]
        public static string UpdateSendToFinanceManagerConfirmation(int userID, int rsItemID, int rsSupplierID, int rsStoreID, int rsManufacturerID, int? rsUnitID)
        {
            var query =
                String.Format(
                    @"Update ReceiveDocConfirmation set [PriceAssignedByUserID] = {0},[PriceConfirmedByUserID] = Null where ReceiveDocID in (select Id from Receivedoc where ItemID= {1}  and QuantityLeft > 0 and StoreID in (select ActivityID from vwAccounts  
                                where MovingAverageID={3}) and ManufacturerID = {4} {5})",
                    userID, rsItemID, rsSupplierID, rsStoreID, rsManufacturerID,
                    (rsUnitID != null) ? String.Format(" and UnitID = {0}", rsUnitID) : "");
            return query;
        }

        [UpdateQuery]
        public static string UpdatePriceDeliveryNoteforHub(int itemId, int supplierId, int storeId, int manufactrerId, int? unitId, double newSellingPrice, int noOfDigitsAfterTheDecimalPoint)
        {
            var query =
                String.Format(
                    @"Update IssueDoc set Cost = ({0} * NoOfPack) where RecievDocID in(select ID from ReceiveDoc where DeliveryNote = 1 and Confirmed = 1 and ItemID= {1} and  StoreID in (select ActivityID from vwAccounts  
                                where MovingAverageID={3}) and PricePerPack is not null and ManufacturerID = {4} {5}) and Cost is Null",
                    Math.Round(newSellingPrice, noOfDigitsAfterTheDecimalPoint), itemId, supplierId,
                    storeId, manufactrerId, (unitId != null) ? String.Format(" and UnitID = {0}", unitId) : "");
            return query;
        }

        [UpdateQuery]
        public static string UpdatePriceDeliveryNoteforHub1(int itemId, int supplierId, int storeId, int manufactrerId, int? unitId, double newSellingPrice, int noOfDigitsAfterTheDecimalPoint)
        {
            var query = String.Format(
                @"update pld set pld.Cost = (pld.QuantityInBU / pld.QtyPerPack) * {1}, pld.UnitPrice = {1} from PickList pl join PickListDetail pld on pl.ID = pld.PickListID join ReceiveDoc rd on rd.ID = pld.ReceiveDocID where (pl.Isconfirmed is null Or pl.IsConfirmed = 0) and(pld.Cost is null and pld.UnitPrice is null) and pld.ItemID = {0} and  rd.StoreID in (select ActivityID from vwAccounts  
                                where MovingAverageID={3})  and rd.PricePerPack is not null and rd.ManufacturerID = {4} {5}",
                itemId, Math.Round(newSellingPrice, noOfDigitsAfterTheDecimalPoint), supplierId,
                storeId, manufactrerId, (unitId != null) ? String.Format(" and rd.UnitID = {0}", unitId) : "");
            return query;
        }

        [UpdateQuery]
        public static string UpdatePriceDeliveryNoteforHubPld(int itemId, int supplierId, int storeId, int manufactrerId, int? unitId, double newSellingPrice, int noOfDigitsAfterTheDecimalPoint)
        {
            var query = String.Format(
                @"update pld set pld.Cost = (pld.QuantityInBU / pld.QtyPerPack) * {1}, pld.UnitPrice = {1} from PickList pl join PickListDetail pld on pl.ID = pld.PickListID join ReceiveDoc rd on rd.ID = pld.ReceiveDocID where pld.ItemID = {0} and (pl.IsConfirmed=1 and pld.Cost is null and pld.UnitPrice is null) and  rd.StoreID in (select ActivityID from vwAccounts  
                                where MovingAverageID={3}) and rd.PricePerPack is not null and rd.ManufacturerID = {4} {5}",
                itemId, Math.Round(newSellingPrice, noOfDigitsAfterTheDecimalPoint), supplierId,
                storeId, manufactrerId, (unitId != null) ? String.Format(" and rd.UnitID = {0}", unitId) : "");
            return query;
        }

        [UpdateQuery]
        public static string UpdatePriceDeliveryNoteforCenterIssueDoc(int itemId, int supplierId, int storeId, int manufactrerId, int? unitId, double newUnitCost, int noOfDigitsAfterTheDecimalPoint)
        {
            var query =
                String.Format(
                    @"Update IssueDoc set Cost = ({0}*NoOfPack) where RecievDocID in(select ID from ReceiveDoc where DeliveryNote = 1 and Confirmed = 1 and ItemID= {1} and StoreID in (select ActivityID from vwAccounts  
                                where MovingAverageID={3})  and PricePerPack is not null and ManufacturerID = {4} {5}) and Cost is Null",
                    Math.Round(newUnitCost, noOfDigitsAfterTheDecimalPoint), itemId, supplierId,
                    storeId, manufactrerId, (unitId != null) ? String.Format(" and UnitID = {0}", unitId) : "");
            return query;
        }

        [UpdateQuery]
        public static string UpdatePriceDeliveryNoteforCenter(int itemId, int supplierId, int storeId, int manufactrerId, int? unitId, double newUnitCost, int noOfDigitsAfterTheDecimalPoint)
        {
            var query = String.Format(
                @"update pld set pld.Cost = (pld.QuantityInBU / pld.QtyPerPack) * {1}, pld.UnitPrice = {1} from PickList pl join PickListDetail pld on pl.ID = pld.PickListID join ReceiveDoc rd on rd.ID = pld.ReceiveDocID where (pl.Isconfirmed is null Or pl.IsConfirmed = 0) and(pld.Cost is null and pld.UnitPrice is null) and pld.ItemID = {0} and  rd.StoreID in (select ActivityID from vwAccounts  
                                where MovingAverageID={3}) and rd.PricePerPack is not null and rd.ManufacturerID = {4} {5}",
                itemId, Math.Round(newUnitCost, noOfDigitsAfterTheDecimalPoint), supplierId, storeId,
                manufactrerId, (unitId != null) ? String.Format(" and rd.UnitID = {0}", unitId) : "");
            return query;
        }

        [UpdateQuery]
        public static string UpdatePriceDeliveryNoteforCenterPld(int itemId, int supplierId, int storeId, int manufactrerId, int? unitId, double newUnitCost, int noOfDigitsAfterTheDecimalPoint)
        {
            var query = String.Format(
                @"update pld set pld.Cost = (pld.QuantityInBU / pld.QtyPerPack) * {1}, pld.UnitPrice = {1} from PickList pl join PickListDetail pld on pl.ID = pld.PickListID join ReceiveDoc rd on rd.ID = pld.ReceiveDocID where pld.ItemID = {0} and (pl.IsConfirmed=1 and pld.Cost is null and pld.UnitPrice is null) and  rd.StoreID in (select ActivityID from vwAccounts  
                                where MovingAverageID={3}) and rd.PricePerPack is not null and rd.ManufacturerID = {4} {5}",
                itemId, Math.Round(newUnitCost, noOfDigitsAfterTheDecimalPoint), supplierId, storeId,
                manufactrerId, (unitId != null) ? String.Format(" and rd.UnitID = {0}", unitId) : "");
            return query;
        }

        [UpdateQuery]
        public static string UpdateSetCostAndSellingPriceAndSendToConfirmationReceiveDoc(double newUnitCost, int noOfDigitsAfterTheDecimalPoint, int itemId, int supplierId, int storeId,
            int manufacturerId, int? unitId, double newSellingPrice, double margin)
        {
            var query =
                String.Format(
                    @"update ReceiveDoc set Cost = {0}, SellingPrice ={6}, Margin = {7} where ItemID= {1}  and QuantityLeft > 0 and StoreID in (select ActivityID from vwAccounts  
                                where MovingAverageID={3}) and PricePerPack is not null and ManufacturerID = {4} {5}",
                    Math.Round(newUnitCost, noOfDigitsAfterTheDecimalPoint), itemId, supplierId,
                    storeId, manufacturerId, (unitId != null) ? String.Format(" and UnitID = {0}", unitId) : "",
                    Math.Round(newSellingPrice, noOfDigitsAfterTheDecimalPoint),
                    Math.Round(margin, noOfDigitsAfterTheDecimalPoint + 2));
            return query;
        }

        [UpdateQuery]
        public static string UpdateSetCostAndSellingPriceAndSendToConfirmationReceiveDocConfirmation(int itemId, int supplierId, int storeId, int manufacturerId, int? unitId, int userID)
        {
            var query =
                String.Format(
                    @"Update ReceiveDocConfirmation set [PriceAssignedByUserID] = {0},[PriceConfirmedByUserID] = Null where ReceiveDocID in (select Id from Receivedoc where ItemID= {1}  and QuantityLeft > 0 and StoreID in (select ActivityID from vwAccounts  
                                where MovingAverageID={3})  and PricePerPack is not null and ManufacturerID = {4} {5})",
                    userID, itemId, supplierId, storeId, manufacturerId,
                    (unitId != null) ? String.Format(" and UnitID = {0}", unitId) : "");
            return query;
        }

        [UpdateQuery]
        public static string UpdatePricePicklistforHub(int itemId, double newSellingPrice, int noOfDigitsAfterTheDecimalPoint, int supplierId, int storeId, int manufacturerId, int? unitId, int orderStatus)
        {
            var query = String.Format(
                @"update pld set pld.Cost = (pld.QuantityInBU / pld.QtyPerPack) * {1}, pld.UnitPrice = {1} 
                                            from PickList pl 
                                                 join PickListDetail pld on pl.ID = pld.PickListID 
                                                 join ReceiveDoc rd on rd.ID = pld.ReceiveDocID
                                                 join [Order] o on o.ID = pl.OrderID
                                                 join [OrderStatus] os on o.OrderStatusID = os.ID
                                            where pld.ItemID = {0} and  
                                                rd.StoreID in (select ActivityID from vwAccounts  
                                where MovingAverageID={3}) 
                                                and rd.PricePerPack is not null and os.OrderStatusCode in('ORFI','APRD','PIKL','PLCN') and rd.ManufacturerID = {4} {5}",
                itemId, Math.Round(newSellingPrice, noOfDigitsAfterTheDecimalPoint), supplierId,
                storeId, manufacturerId, (unitId != null) ? String.Format(" and rd.UnitID = {0}", unitId) : "",
                orderStatus);
            return query;
        }

        [UpdateQuery]
        public static string UpdatePricePicklistforCenter(int itemId, double newUnitCost, int noOfDigitsAfterTheDecimalPoint, int supplierId, int storeId, int manufacturerId, int? unitId, int orderStatus)
        {
            var query = String.Format(
                @"update pld set pld.Cost = (pld.QuantityInBU / pld.QtyPerPack) * {1}, pld.UnitPrice = {1} 
                                            from PickList pl 
                                                 join PickListDetail pld on pl.ID = pld.PickListID 
                                                 join ReceiveDoc rd on rd.ID = pld.ReceiveDocID
                                                 join [Order] o on o.ID = pl.OrderID
                                                 join [OrderStatus] os on o.OrderStatusID = os.ID
                                            where pld.ItemID = {0} and  
                                                rd.StoreID in (select ActivityID from vwAccounts  
                                            where MovingAverageID={3}) 
                                                and rd.PricePerPack is not null and os.OrderStatusCode in('ORFI','APRD','PIKL','PLCN')  and rd.ManufacturerID = {4} {5}",
                itemId, Math.Round(newUnitCost, noOfDigitsAfterTheDecimalPoint), supplierId, storeId,
                manufacturerId, (unitId != null) ? String.Format(" and rd.UnitID = {0}", unitId) : "",
                orderStatus);
            return query;
        }

        [UpdateQuery]
        public static string UpdateConfirmMovingAverage(int itemId, int supplierId, int storeId, int manufacturerId, int userID, int? unitId)
        {
            var query =
                String.Format(
                    @"Update ReceiveDocConfirmation set [PriceConfirmedByUserID] = {0} where ReceiveDocID in (select Id from Receivedoc where ItemID= {1}  and QuantityLeft > 0 and StoreID in (select ActivityID from vwAccounts  
                                where MovingAverageID={3})  and PricePerPack is not null and Cost is not null and  ManufacturerID = {4} {5} ) ",
                    userID, itemId, supplierId, storeId, manufacturerId,
                    (unitId != null) ? String.Format(" and UnitID = {0}", unitId) : "");
            return query;
        }

        [SelectQuery]
        public static string SelectLoadUniqueReceivedItems()
        {
            string query =
                String.Format(
                    "select * from vwGetAllItems where ID in (select ItemID from ReceiveDoc rd where QuantityLeft > 0)");
            return query;
        }

        [SelectQuery]
        public static string SelectGetNextQtyPerPackFor(int itemID)
        {
            string query =
                String.Format(
                    "select TOP(1) QtyPerPack from ReceiveDoc where ItemID = {0} and QuantityLeft > 0 order by ExpDate", itemID);
            return query;
        }

        [UpdateQuery]
        public static string UpdateFixQuantityLeftProblemRd(int itemID)
        {
            string query =
                String.Format(
                    @"update rd
                                set rd.QuantityLeft=case when rd.Quantity-x.TotalQty-x.LostQty < 0 then 0 else rd.Quantity-x.TotalQty-x.LostQty end
                                from
                                ReceiveDoc rd join 
                                (select id.RecievDocID,sum(id.NoOfPack) TotalPacks, sum(id.Quantity) TotalQty, (case When sum(d.Quantity) is null then 0 else sum(d.Quantity) end) LostQty
                                from IssueDoc id left join LossAndAdjustment d on id.RecievDocID=d.RecID where (d.Losses<>0 or d.Losses is null) group by id.RecievDocID) as x on rd.ID=x.RecievDocID
                                where rd.QuantityLeft<>(rd.Quantity-x.TotalQty-x.LostQty) and rd.ItemID = {0}", itemID);
            return query;
        }

        [UpdateQuery]
        public static string UpdateFixQuantityLeftProblemReceivedoc(int itemID)
        {
            return String.Format(
                @"Update receivedoc
                        set QuantityLeft=Quantity
                        where ID not in (Select RecievDocID from IssueDoc union Select RecID from LossAndAdjustment) and ItemID={0}",
                itemID);
        }

        [UpdateQuery]
        public static string SelectLoadExpiryDatesForItem(int itemID, int storeID, int unitID, bool loadOnlyThoseWithBalance, int? preferredManufacturer, int? preferredLocation)
        {
            string balanceQuery = loadOnlyThoseWithBalance ? " and QuantityLeft > 0 " : "";
            string manufacturerFilter = (preferredManufacturer == null) ? "" : String.Format(" and rd.ManufacturerID = {0}", preferredManufacturer);
            string locationFilter = (preferredLocation == null) ? "" : String.Format(" and v.PhyicalStoreID = {0}", preferredLocation);

            string query =
                String.Format(
                    "Select distinct cast(cast(ExpDate as date) as nvarchar(50)) as ExpiryDateString from ReceiveDoc rd join ReceivePallet rp on rd.ID = rp.ReceiveID join vwPallet v on rp.PalletLocationID = v.PalletLocationID where ItemID={0} and ( ExpDate > getdate() or ExpDate is null) and StoreID={1} and UnitID={2} {3} {4} {5}",
                    itemID, storeID, unitID, balanceQuery, locationFilter, manufacturerFilter);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadExpiryDatesForAllItems()
        {
            string query =
                String.Format(
                    "Select distinct cast(cast(ExpDate as date) as nvarchar(50)) as ExpiryDateString from ReceiveDoc where (ExpDate>getdate() or ExpDate is null)");
            return query;
        }

        [SelectQuery]
        public static string SelectLoadByReferenceNo(string reference)
        {
            string query = String.Format("select * from ReceiveDoc where RefNo='{0}'", reference);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadByReceiptID(int ReceiptID)
        {
            string query = String.Format("select * from ReceiveDoc rd where rd.ReceiptID = {0}", ReceiptID);
            return query;
        }

        [SelectQuery]
        public static string SelectIsThereShortageOrDamage(int reference)
        {
            string query = String.Format(@"Select rd.ID from ReceiveDoc rd join ReceiveDocShortage rds on rd.ID = rds.ReceiveDocID where RefNo='{0}'
                                            union
                                            select rd.ID from ReceiveDoc rd join ReceivePallet rp on rd.ID=rp.ReceiveID
                                            join PalletLocation pl on rp.PalletLocationID=pl.ID
                                            join StorageType st on st.ID = pl.StorageTypeID    
                                            where st.StorageTypeCode = 'SA' and rd.ReceiptID ={0}", reference);
            return query;
        }

        [SelectQuery]
        public static string SelectIsBatchElectronicReceive(int reference)
        {
            string query = String.Format(@"
			Select InvoicedNoOfPack InvoicedQty, Sum(Quantity) TotalReceived 
			from receivedoc where RefNo='{0}' and InvoicedNoOfPack>NoOfPack
			group by ItemID, UnitID, InvoicedNoOfPack", reference);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadByItemIDUnitIDStoreID(int itemID, int unitID, int storeID)
        {
            string query = String.Format("Select * from ReceiveDoc where ItemID={0} and UnitID={1} and StoreID={2}", itemID,
                unitID, storeID);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadAllByReceiptId(int ReceiptId)
        {
            return String.Format("select rd.NoOfPack Pack,vw.FullItemName,vw.ItemUnitName,vw.ManufacturerName,vw.ReceiveDocID ID,rd.SupplierID,rd.ReturnedFromIssueDocID, IsDeleted=0 from Receivedoc rd  join vwReceiptPallet vw on vw.ReceiveDocID = rd.ID where rd.ReceiptID = {0}", ReceiptId);
        }

        [SelectQuery]
        public static string SelectFixQuantityProblem(int itemId)
        {
            string query =
                String.Format("select count(*) [Count] from ReceiveDoc where itemid={0} and Quantity<>QtyPerPack*NoOfPack",
                    itemId);
            return query;
        }

        [UpdateQuery]
        public static string UpdateFixQuantityProblemReceivedoc(int itemId)
        {
            return String.Format(
                "update receivedoc set Quantity=QtyPerPack * NoOfPack where itemid={0} and exists (select * from ReceiveDoc where itemid={0} and Quantity<>QtyPerPack*NoOfPack)",
                itemId);
        }

        [SelectQuery]
        public static string SelectLoadDeletedByReceiptId(int receiptId)
        {
            string query = String.Format("select * from ReceiveDocDeleted rd where rd.ReceiptID = {0}", receiptId);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadRelatedReceiveDocs(int itemID, int unitID, int manufacturerID, int physicalStoreID, string batchNo, DateTime? expDate)
        {
            string batchFilter = "", expFilter = "";
            if (!String.IsNullOrEmpty(batchNo))
            {
                batchFilter = String.Format(" and rd.BatchNo = '{0}'", batchNo);
            }
            if (expDate.HasValue)
            {
                expFilter = String.Format(" and rd.ExpDate = cast('{0}' as datetime)", expDate);
            }

            string query =
                String.Format(
                    @"select * from ReceiveDoc rd join ReceivePallet rp on rd.ID=rp.ReceiveID join vwPallet p on rp.PalletID=p.PalletID where rd.ItemID={0} and rd.UnitID = {1} and rd.ManufacturerID = {2} {3} {4} and p.PhyicalStoreID={5}",
                    itemID, unitID, manufacturerID, batchFilter, expFilter, physicalStoreID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetWhereItIsLocated(int receiveDocID)
        {
            string query =
                String.Format(
                    "SELECT p.PalletLocationID from ReceiveDoc rd join ReceivePallet rp on rd.ID=rp.ReceiveID join vwPallet p on rp.PalletID=p.PalletID where rd.ID={0}",
                    receiveDocID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetSoundStock(int itemId, int itemUnitId, int manufacturerId, int movungAverageId, int receiptConfirmationStatusId)
        {
            string query = String.Format(
                @"select 
                        IsNull(sum(rp.packs),0) Quantity

                 from CurrentReceiveDoc rd 
	                join vwReceiptPallet rp on rp.ReceiveDocID = rd.ID 
					join receivedocConfirmation rdc on rdc.receivedocID = rd.ID
                    Join PhysicalStore ps on ps.ID = rp.PhyicalStoreID
                    join StorageType st on st.ID = rp.StorageTypeID  
				 where rd.SellingPrice is Not Null 
				       and rd.Confirmed = 1  
					   and (rd.ExpDate > GetDate() or rd.Expdate is Null) 
					   and st.StorageTypeCode <> 'SA' 
                       and rp.ItemID ={0}
					   and rp.ItemUnitID = {1}
					   and rp.ManufacturerID = {2}
					   and rp.MovingAverageID = {3}
					   and rdc.receiptConfirmationStatusID ={4}
                       and ps.IsActive = 1                     
                        
					   ", itemId, itemUnitId, manufacturerId, movungAverageId, receiptConfirmationStatusId);
            return query;
        }

        [SelectQuery]
        public static string SelectGetOutstandingReceives(int grnfPrinted, int warehouseID, int stockReturn, int standardReciept)
        {
            string queryFilter = "";
            if (warehouseID != 0)
            {
                queryFilter = String.Format(" and vrp.WarehouseID = {0} ", warehouseID);
            }

            string query =
                String.Format(
                    @"select isNull(Cast(rcpGRNF.IDPrinted as varchar),'Not Printed') GRNF,ri.STVOrInvoiceNo as [InvoiceNo], rcs.Name as [Status],vrp.WarehouseName as Warehouse,m.TypeName as [Mode],vw.AccountName 
                                from Receipt rt 
                                     join ReceiveDoc rd on rd.ReceiptID = rt.ID 
	                                 join vwReceiptPallet vrp on vrp.ReceiveDocID = rd.ID
	                                 join ReceiptInvoice ri on ri.ID = rt.ReceiptInvoiceID
	                                 join PO on po.ID = ri.POID
	                                 left join ReceiveDocConfirmation rdc on rdc.ReceiveDocID  = rd.ID
                                     left join ReceiptConfirmationStatus rcs on rcs.ID = rdc.ReceiptConfirmationStatusID
	                                 left Join(Select * from ReceiptConfirmationPrintout where reason = 'PGRV') rcpGRNF on rcpGRNF.ReceiptID = rt.ID
                                     left Join(Select * from ReceiptConfirmationPrintout where reason = 'GRV' or reason = 'IGRV' or reason = 'SRM') rcpGRV on rcpGRV.ReceiptID = rt.ID
	                                 join vwAccounts vw on rd.StoreID = vw.ActivityID 
	                                 join Mode m on vw.ModeID = m.ID
	                                 where  rd.refno not like 'BeginningBalance' and (rt.ReceiptTypeID = {2} or rt.ReceiptTypeID = {3}) and rcs.ReceiptConfirmationStatusCode in ('DRRC','REEN','RECC') {1} 
	                                 Group by rcpGRNF.IDPrinted,ri.STVOrInvoiceNo, rcs.Name,vrp.WarehouseName,m.TypeName,vw.AccountName
	                                 order by m.TypeName,vw.AccountName,rcpGRNF.IDPrinted,ri.STVOrInvoiceNo,vrp.WarehouseName",
                    grnfPrinted, queryFilter, stockReturn, standardReciept);
            return query;
        }

        [SelectQuery]
        public static string SelectGetOutstandingReceiveDeliveryNote(int warehouseID, int grnfPrinted, int deliverNote)
        {
            string queryFilter = "";
            if (warehouseID != 0)
            {
                queryFilter = String.Format(" and vrp.WarehouseID = {0} ", warehouseID);
            }


            string query =
                String.Format(
                    @"select isNull(Cast(rcpGRNF.IDPrinted as varchar),'Not Printed') GRNF,ri.STVOrInvoiceNo as [InvoiceNo], rcs.Name as [Status],vrp.WarehouseName as Warehouse,m.TypeName as [Mode],vw.AccountName 
                                from Receipt rt 
                                     join ReceiveDoc rd on rd.ReceiptID = rt.ID 
	                                 join vwReceiptPallet vrp on vrp.ReceiveDocID = rd.ID
	                                 join ReceiptInvoice ri on ri.ID = rt.ReceiptInvoiceID
	                                 join PO on po.ID = ri.POID
	                                 left join ReceiveDocConfirmation rdc on rdc.ReceiveDocID  = rd.ID
                                     left join ReceiptConfirmationStatus rcs on rcs.ID = rdc.ReceiptConfirmationStatusID
	                                 left Join(Select * from ReceiptConfirmationPrintout where reason = 'PGRV') rcpGRNF on rcpGRNF.ReceiptID = rt.ID
                                     left Join(Select * from ReceiptConfirmationPrintout where reason = 'GRV' or reason = 'IGRV' or reason = 'SRM') rcpGRV on rcpGRV.ReceiptID = rt.ID
	                                 join vwAccounts vw on rd.StoreID = vw.ActivityID 
	                                 join Mode m on vw.ModeID = m.ID
	                                 where  rd.refno not like 'BeginningBalance' and (rt.ReceiptTypeID = {2}) and rcs.ReceiptConfirmationStatusCode in ('DRRC','REEN','RECC')  {1} 
	                                 Group by rcpGRNF.IDPrinted,ri.STVOrInvoiceNo, rcs.Name,vrp.WarehouseName,m.TypeName,vw.AccountName
	                                 order by m.TypeName,vw.AccountName,rcpGRNF.IDPrinted,ri.STVOrInvoiceNo,vrp.WarehouseName",
                    grnfPrinted, queryFilter, deliverNote);
            return query;
        }

        [SelectQuery]
        public static string SelectGetOutstandingTransfer(int receiptType, int grnfPrinted)
        {
            string query =
                String.Format(
                    @"select isNull(Cast(rcpGRNF.IDPrinted as varchar),'Not Printed') GRNF,ri.STVOrInvoiceNo as [InvoiceNo], rcs.Name as [Status],vrp.WarehouseName as Warehouse,m.TypeName as [Mode],vw.AccountName 
                                from Receipt rt 
                                     join ReceiveDoc rd on rd.ReceiptID = rt.ID 
	                                 join vwReceiptPallet vrp on vrp.ReceiveDocID = rd.ID
	                                 join ReceiptInvoice ri on ri.ID = rt.ReceiptInvoiceID
	                                 join PO on po.ID = ri.POID
	                                 left join ReceiveDocConfirmation rdc on rdc.ReceiveDocID  = rd.ID
                                     left join ReceiptConfirmationStatus rcs on rcs.ID = rdc.ReceiptConfirmationStatusID
	                                 left Join(Select * from ReceiptConfirmationPrintout where reason = 'PGRV') rcpGRNF on rcpGRNF.ReceiptID = rt.ID
                                     left Join(Select * from ReceiptConfirmationPrintout where reason = 'GRV' or reason = 'IGRV' or reason = 'SRM') rcpGRV on rcpGRV.ReceiptID = rt.ID
	                                 join vwAccounts vw on rd.StoreID = vw.ActivityID 
	                                 join Mode m on vw.ModeID = m.ID
	                                 where  rd.refno not like 'BeginningBalance' and rt.ReceiptTypeID = {1} and rcs.ReceiptConfirmationStatusCode in ('DRRC','REEN','RECC') and  rdc.ReceiptConfirmationStatusID < {0} 
	                                 Group by rcpGRNF.IDPrinted,ri.STVOrInvoiceNo, rcs.Name,vrp.WarehouseName,m.TypeName,vw.AccountName
	                                 order by m.TypeName,vw.AccountName,rcpGRNF.IDPrinted,ri.STVOrInvoiceNo,vrp.WarehouseName",
                    grnfPrinted, receiptType);
            return query;
        }

        [SelectQuery]
        public static string SelectGetCutOffNumber(int fiscalPeriodID, int accountID)
        {
            string query =
                String.Format(@"select * 
                                from
                                (
                                       ( Select Case 
												When rcp.Reason = 'PGRV' then 'GRNF' else rcp.Reason 
												End as DocumentType, Max(rcp.IDPrinted) as CuttOffNumber,(select  s.CompanyName
												 								 from ReceiptConfirmationPrintout  ircp 
																					join vwAccounts ia on ircp.StoreID=ia.ActivityID
																					join ReceiveDoc rd on ircp.ReceiptID  = rd.ReceiptID
																					join Supplier s on rd.SupplierID  = s.ID 
																				where rd.StoreID = {0} and ircp.FiscalYearID = {1} and ircp.IDPrinted = Max(rcp.IDPrinted) and ircp.Reason = rcp.Reason
																				Group by ircp.IDPrinted, ircp.Reason,s.CompanyName) As Institution, (select sum(rd.NoOfPack * rd.UnitCost)
														from ReceiptConfirmationPrintout  ircp 
														join vwAccounts ia on ircp.StoreID=ia.ActivityID
														join ReceiveDoc rd on ircp.ReceiptID  = rd.ReceiptID
														where rd.StoreID = {0} and ircp.FiscalYearID = {1} and ircp.IDPrinted = Max(rcp.IDPrinted) and ircp.Reason = rcp.Reason
														Group by ircp.IDPrinted) as Amount
										FROM 
											ReceiptConfirmationPrintout rcp 
											join vwAccounts a on rcp.StoreID=a.ActivityID
											join ReceiveDoc rd on rcp.ReceiptID  = rd.ReceiptID
										where rcp.Reason <> 'SRM' and a.AccountID = {0} and rcp.FiscalYearID = {1}
										Group by rcp.Reason)

										union 
										
                                      ( Select Case 
												When rcp.Reason = 'PGRV' then 'GRNF' else rcp.Reason 
												End as DocumentType, Max(rcp.IDPrinted) as CuttOffNumber,(select  ru.Name
												 								 from ReceiptConfirmationPrintout  ircp 
																					join vwAccounts ia on ircp.StoreID=ia.ActivityID
																					join ReceiveDoc rd on ircp.ReceiptID  = rd.ReceiptID
																					join Supplier s on rd.SupplierID  = s.ID
                                                                                    join IssueDoc id on rd.ReturnedFromIssueDocID=id.ID 
												                                    join ReceivingUnits ru on id.ReceivingUnitID=ru.ID
																				where rd.StoreID = {0} and ircp.FiscalYearID = {1} and ircp.IDPrinted = Max(rcp.IDPrinted) and ircp.Reason = rcp.Reason
																				Group by ircp.IDPrinted, ircp.Reason,ru.Name) As Institution, (select sum(rd.NoOfPack * rd.UnitCost)
														from ReceiptConfirmationPrintout  ircp 
														join vwAccounts ia on ircp.StoreID=ia.ActivityID
														join ReceiveDoc rd on ircp.ReceiptID  = rd.ReceiptID
														where rd.StoreID = {0} and ircp.FiscalYearID = {1} and ircp.IDPrinted = Max(rcp.IDPrinted) and ircp.Reason = rcp.Reason
														Group by ircp.IDPrinted) as Amount
										FROM 
											ReceiptConfirmationPrintout rcp 
											join vwAccounts a on rcp.StoreID=a.ActivityID
											join ReceiveDoc rd on rcp.ReceiptID  = rd.ReceiptID
										where rcp.Reason = 'SRM' and  a.AccountID = {0} and rcp.FiscalYearID = {1}
										Group by rcp.Reason)
                                    ) receiveDocument
						            Union
						            ( 
                                        select pt.Name as PaymentType,Max(i.IDPrinted) CuttOffNumber ,(select max(ru.Name) from
																										Issue oi 
																										join PickList opl on opl.ID = oi.PickListID 
																										join vwAccounts oa on oi.StoreID = oa.ActivityID 
																										join [Order] oo on oo.ID = opl.OrderID
																										join IssueDoc oid on oo.ID = oid.OrderID
																										join ReceivingUnits ru on oid.ReceivingUnitID = ru.ID
																										Join PaymentType opt on oo.PaymentTypeID = opt.ID
																										where oid.StoreId = {0} and oi.FiscalYearID = {1} and oi.IDPrinted = Max(i.IDPrinted) and opt.Name = pt.Name
																				Group by opt.Name) As Institution,(select Sum(oid.UnitCost * oid.NoOfPack) from
																                                                            Issue oi 
																                                                            join PickList opl on opl.ID = oi.PickListID 
																                                                            join vwAccounts oa on oi.StoreID = oa.ActivityID 
																                                                            join [Order] oo on oo.ID = opl.OrderID
																                                                            join IssueDoc oid on oo.ID = oid.OrderID
																                                                            Join PaymentType opt on oo.PaymentTypeID = opt.ID
																                                                            where oid.StoreId = {0} and oi.FiscalYearID = {1} and oi.IDPrinted = Max(i.IDPrinted) and opt.Name = pt.Name
		                                                                                            Group by oi.IDPrinted) as Amount
                                        from
                                            Issue i 
                                            join PickList pl on pl.ID = i.PickListID 
                                            join vwAccounts a on i.StoreID = a.ActivityID 
		                                    join [Order] o on o.ID = pl.OrderID
                                            Join PaymentType pt on o.PaymentTypeID = pt.ID
										where a.AccountID = {0} and i.FiscalYearID = {1}
		                                Group by pt.Name 
                                    )"
                    , accountID, fiscalPeriodID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetOutstandingVoidRequestGRV(int warehouseID, int grnfPrinted)
        {
            string queryFilter = "";
            if (warehouseID != 0)
            {
                queryFilter = String.Format(" and pl.WarehouseID = {0} ", warehouseID);
            }

            string query =
                String.Format(@"select rcp.IDPrinted As GRNF ,ri.STVOrInvoiceNo as [InvoiceNo],rcs.Name as [Status],pl.WarehouseName as Warehouse,m.TypeName as [Mode],vw.AccountName 
                                                    from receivePallet rp 
					                                join receiveDoc rd on rp.ReceiveID = rd.ID
													join vwAccounts vw on rd.StoreID = vw.ActivityID 
													join Mode m on vw.ModeID = m.ID
                                                    join vwPallet pl on pl.PalletID = rp.PalletID
					                                join receiveDocConfirmation rdc on rdc.ReceiveDocID = rd.ID
													join ReceiptConfirmationStatus rcs on rdc.ReceiptConfirmationStatusID = rcs.ID
													join ReceiptConfirmationPrintout rcp on (rcp.ReceiptID = rd.ReceiptID and rcp.Reason='GRV')
													join receipt rpt on rd.ReceiptID = rpt.ID 
													join receiptinvoice ri on rpt.ReceiptInvoiceID = ri.ID
                                                where  rd.refno not like 'BeginningBalance' and rcs.ReceiptConfirmationStatusCode in ('DRRC','REEN','RECC','GRNFP')
                                                                  {1} and rcp.VoidRequest = 1 and (IsNull(rcp.IsVoided,0) = 0)
												Group by rcp.IDPrinted ,ri.STVOrInvoiceNo,rcs.Name,pl.WarehouseName,m.TypeName,vw.AccountName 
												order by m.TypeName,vw.AccountName,rcp.IDPrinted,ri.STVOrInvoiceNo,pl.WarehouseName",
                    grnfPrinted, queryFilter);
            return query;
        }

        [SelectQuery]
        public static string SelectCheckOutstandingReceives(int warehouseID, int grvPrinted, int stockReturn, int standardReceipt)
        {
            string queryFilter = "";
            if (warehouseID != 0)
            {
                queryFilter = String.Format(" and pl.WarehouseID = {0} ", warehouseID);
            }

            string query =
                String.Format(@"select Count(*) count from Receipt rt 
		                            join ReceiveDoc rd on rd.ReceiptID = rt.ID 
		                            join ReceivePallet rp  on rp.ReceiveID = rd.ID
		                            join vwPallet pl on pl.PalletID = rp.PalletID
		                            join ReceiveDocConfirmation rdc on rdc.ReceiveDocID  = rd.ID
		                            join ReceiptConfirmationStatus rcs on rcs.ID = rdc.ReceiptConfirmationStatusID
                                where  rd.refno not like 'BeginningBalance' and QuantityLeft > 0
                                        and rcs.ReceiptConfirmationStatusCode in ('DRRC','REEN','RECC','GRNFP','UCC','PRC','PRCO')
                                        {1} ",
                    grvPrinted, queryFilter, stockReturn, standardReceipt);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadReceivesForStores(int storeID)
        {
            string query = String.Format("Select * from ReceiveDoc where StoreID={0}", storeID);
            return query;
        }

        [SelectQuery]
        public static string SelectReceives(int receiptID,int itemID,int unitID,int manufacturerID,int movingAverageID)
        {
            string query = String.Format(@"Select rd.* from ReceiveDoc rd join vwAccounts a on rd.StoreID = a.ActivityID 
                                                    where ReceiptID = {0} and ItemID = {1} and UnitID= {2} and manufacturerID ={3} and MovingAverageID = {4}"
                                                          ,receiptID,itemID,unitID,manufacturerID,movingAverageID );
            return query;
        }

        [SelectQuery]
        public static string SelectGetRelatedReceive(int ReceiptID, int ItemID, int ItemUnitID, int ManufacturerID, int ActivityID, double NewPricePerPack)
        {
            string query =
                String.Format(@"SELECT distinct rd.ID,vw.StockCode,vw.FullItemName,vw.ItemUnitName,vw.ManufacturerName,vw.ActivityName,rd.BatchNo, rd.ExpDate,rd.InvoicedNoOfPack,rd.NoOfPack,rd.QuantityLeft/rd.QtyPerPack NoOfPackLeft,
	                                                           rd.PricePerPack PreviousPricePerPack,{5} NewPricePerPack, {5} * rd.NoOfPack TotalPrice
                                                       FROM Receivedoc rd Join vwReceiveDetail vw on rd.ID = vw.ReceiveDocID
                                                       WHERE rd.ReceiptID = {0} and rd.ItemID = {1} and rd.UnitID = {2} and rd.ManufacturerId = {3} 
                                                             and rd.StoreID = {4}", ReceiptID, ItemID, ItemUnitID,
                    ManufacturerID, ActivityID, NewPricePerPack);
            return query;
        }

        [SelectQuery]
        public static string SelectGetRelatedReceiveForMarginChange(int ReceiptID, int ItemID, int ItemUnitID, int ManufacturerID, int ActivityID, double Margin)
        {
            string query =
                String.Format(@"SELECT rd.ID,vw.StockCode,vw.FullItemName,vw.ItemUnitName,vw.ManufacturerName,vw.ActivityName,rd.BatchNo, rd.ExpDate,rd.InvoicedNoOfPack,rd.NoOfPack,rd.QuantityLeft/rd.QtyPerPack NoOfPackLeft,
	                                                           rd.Margin PreviousMargin,{5} NewMargin, {5} * rd.NoOfPack TotalPrice
                                                       FROM Receivedoc rd Join vwreceiptPallet vw on rd.ID = vw.ReceiveDocID
                                                       WHERE rd.ReceiptID = {0} and rd.ItemID = {1} and rd.UnitID = {2} and rd.ManufacturerId = {3} 
                                                             and rd.StoreID = {4}", ReceiptID, ItemID, ItemUnitID,
                    ManufacturerID, ActivityID, Margin);
            return query;
        }

        [SelectQuery]
        public static string SelectGetItemInformation(int ItemID, int ItemUnitID, int ManufacturerID, int MovingAverageID)
        {
            string query =
                String.Format(@"SELECT rp.StockCode,rp.FullItemName,rp.ItemUnitName,rp.ManufacturerName,rp.AccountName,rp.ActivityName from ReceiveDoc rd join vwReceiptPallet rp on rp.ReceiveDocID = rd.ID 
                                    where  rd.ItemID = {0} and rd.UnitID = {1} and rd.ManufacturerId = {2} 
                                                                                 and rp.MovingAverageID = {3}", ItemID,
                    ItemUnitID, ManufacturerID, MovingAverageID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetRelatedReceiveForFinalPriceSetting(int? ReceiptID, int ItemID, int ManufacturerID, int ItemUnitID, int AccountID)
        {
            string query =
                String.Format(@"SELECT rd.ID,vw.StockCode,vw.FullItemName,vw.ItemUnitName,vw.ManufacturerName,vw.ActivityName,rd.BatchNo, rd.ExpDate,rd.InvoicedNoOfPack,rd.NoOfPack,rd.QuantityLeft/rd.QtyPerPack NoOfPackLeft,
	                                                            rd.Cost NewAverageCost,rd.Margin, rd.SellingPrice NewSellingPrice
                                                       FROM Receivedoc rd Join vwreceiptPallet vw on rd.ID = vw.ReceiveDocID
                                                       WHERE {0} rd.ItemID = {1} and rd.UnitID = {2} and rd.ManufacturerId = {3} 
                                                             and vw.MovingAverageID = {4}",
                    ReceiptID != null ? String.Format("rd.ReceiptID = {0} and", ReceiptID) : "", ItemID, ItemUnitID,
                    ManufacturerID, AccountID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetRelatedReceiveForUnitCost(int ReceiptID, int ItemID, int ItemUnitID, int ManufacturerID, int ActivityID, double NewUnitCost)
        {
            string query =
                String.Format(@"SELECT rd.ID,vw.StockCode,vw.FullItemName,vw.ItemUnitName,vw.ManufacturerName,vw.ActivityName,rd.BatchNo, rd.ExpDate,rd.InvoicedNoOfPack,rd.NoOfPack,rd.QuantityLeft/rd.QtyPerPack NoOfPackLeft,
	                                                           rd.Cost PreviousPricePerPack,{5} NewPricePerPack, {5} * rd.NoOfPack TotalPrice
                                                       FROM Receivedoc rd Join vwreceiptPallet vw on rd.ID = vw.ReceiveDocID
                                                       WHERE rd.ReceiptID = {0} and rd.ItemID = {1} and rd.UnitID = {2} and rd.ManufacturerId = {3} 
                                                             and rd.StoreID = {4}", ReceiptID, ItemID, ItemUnitID,
                    ManufacturerID, ActivityID, NewUnitCost);
            return query;
        }

        [SelectQuery]
        public static string SelectGetRelatedPreviousStockForUnitCostAndSellingPrice(int ReceiptID, int ItemID, int ManufacturerID, int ItemUnitID, int ActivityID, double NewUnitCost, double SellingPrice)
        {
            string query =
                String.Format(
                    @"SELECT rd.ID,rp.StockCode,rp.FullItemName,rp.ItemUnitName,rp.ManufacturerName,rp.ActivityName,rd.BatchNo, rd.ExpDate,rd.InvoicedNoOfPack,rd.NoOfPack,rd.QuantityLeft/rd.QtyPerPack NoOfPackLeft,
	                                                          rd.Cost PreviousAverageCost,{5} NewAverageCost, {5} * rd.NoOfPack TotalPrice,rd.Margin,rd.SellingPrice PreviousSellingPrice,{6} NewSellingPrice
                                                      from ReceiveDoc rd join vwReceiptPallet rp on rp.ReceiveDocID = rd.ID join PhysicalStore ps on rp.PhyicalStoreID =ps.ID
                                                      join StorageType st on st.ID = rp.StorageTypeID  
	                                       where st.StorageTypeCode <> 'SA' and rd.Confirmed = 1 and rd.Quantityleft > 0 and rd.SellingPrice is Not Null and rd.ItemID = {1} and rd.UnitID = {2} and rd.ManufacturerId = {3} and (rd.ExpDate > GETDATE() or rd.ExpDate is Null) {0}
                                                                                 and rp.MovingAverageID = {4} and ps.IsActive = 1",
                    ReceiptID != null ? String.Format("  and rd.ReceiptID <> {0}", ReceiptID) : "", ItemID, ItemUnitID,
                    ManufacturerID, ActivityID, NewUnitCost, SellingPrice);
            return query;
        }

        [SelectQuery]
        public static string SelectGetRelatedPicklistForChangingPrice(int ItemID, int ManufacturerID, int ItemUnitID, int AccountID, double SellingPrice)
        {
            string query =
                String.Format(@"select o.RefNo,pld.UnitPrice,{0} NewSellingPrice,pld.BatchNumber ,pld.ExpireDate ExpDate  from PickList pl 
                                                 join PickListDetail pld on pl.ID = pld.PickListID 
                                                 join ReceiveDoc rd on rd.ID = pld.ReceiveDocID
                                                 join [Order] o on o.ID = pl.OrderID
                                                 join OrderStatus os on os.ID = o.OrderStatusID
                                            where os.OrderStatusCode in ('DRFT','ORFI','APRD','PIKL','PLCN') and pld.ReceiveDocID in (select rd.ID  from ReceiveDoc rd join vwAccounts acc on acc.ActivityID = rd.StoreID where rd.Confirmed = 1 and rd.Quantityleft > 0 and rd.ItemID = {1} and rd.UnitID = {2} and rd.ManufacturerId = {3} and (rd.ExpDate > GETDATE() or rd.ExpDate is Null)
                                                                                 and acc.MovingAverageID = {4})",
                    SellingPrice, ItemID, ItemUnitID, ManufacturerID, AccountID);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadByReceiptIDWithReceivePallet(int receiptID)
        {
            var query = String.Format("select * from ReceiveDoc rd join ReceivePallet rp on rd.ID=rp.ReceiveID where rd.ReceiptID = {0}", receiptID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetRelatedDeliveryNotesChangingPrice(int ReceiptID, int ItemID, int ManufacturerID, int ItemUnitID, int ActivityID, double NewUnitCost, double SellingPrice)
        {
            string query =
                String.Format(@"SELECT rd.ID,vw.StockCode,vw.FullItemName,vw.ItemUnitName,vw.ManufacturerName,vw.ActivityName,STVLog.IDPrinted,id.NoOfPack,rd.BatchNo, rd.ExpDate,
	                                                           rd.Cost PreviousPricePerPack,{5} NewPricePerPack, {5} * rd.NoOfPack TotalPrice
                                                       FROM Receivedoc rd Join vwreceiptPallet vw on rd.ID = vw.ReceiveDocID Join IssueDoc id on id.RecievDocID = rd.ID join STVLog on STVLog.ID = id.STVID 
                                                       WHERE rd.ReceiptID = {0} and rd.ItemID = {1} and rd.UnitID = {2} and rd.ManufacturerId = {3} 
                                                             and vw.MovingAverageID = {4}", ReceiptID, ItemID,
                    ItemUnitID, ManufacturerID, ActivityID, NewUnitCost, SellingPrice);
            return query;
        }

        [SelectQuery]
        public static string SelectGetRelatedReceiveForUnitCostAndSellingPrice(int ReceiptID, int ItemID, int ManufacturerID, int ItemUnitID, int ActivityID, double NewUnitCost, double NewSellingPrice)
        {
            string query =
                String.Format(@"SELECT rd.ID,vw.StockCode,vw.FullItemName,vw.ItemUnitName,vw.ManufacturerName,vw.ActivityName,rd.BatchNo, rd.ExpDate,rd.InvoicedNoOfPack,rd.NoOfPack,rd.QuantityLeft/rd.QtyPerPack NoOfPackLeft,
	                                                           rd.Cost PreviousAverageCost,{5} NewAverageCost, {5} * rd.NoOfPack TotalPrice,rd.SellingPrice PreviousSellingPrice,{6} NewSellingPrice
                                                       FROM Receivedoc rd Join vwreceiptPallet vw on rd.ID = vw.ReceiveDocID
                                                       WHERE rd.ReceiptID = {0} and rd.ItemID = {1} and rd.UnitID = {2} and rd.ManufacturerId = {3} 
                                                             and vw.MovingAverageID = {4}", ReceiptID, ItemID,
                    ItemUnitID, ManufacturerID, ActivityID, NewUnitCost, NewSellingPrice);
            return query;
        }

        [SelectQuery]
        public static string SelectGetRelatedReceiveForUnitCostAndSellingPriceRd(int ReceiptID, int itemId, int itemUnitId, int manufacturerId, int movingAverageId, double averageCost, double sellingPrice)
        {
            string query =
                String.Format(@"SELECT rd.ID,vw.StockCode,vw.FullItemName,vw.ItemUnitName,vw.ManufacturerName,vw.ActivityName,rd.BatchNo, rd.ExpDate,rd.InvoicedNoOfPack,rd.NoOfPack,rd.QuantityLeft/rd.QtyPerPack NoOfPackLeft,
	                                                           rd.Cost PreviousAverageCost,{5} NewAverageCost, {5} * rd.NoOfPack TotalPrice,rd.SellingPrice PreviousSellingPrice,{6} NewSellingPrice
                                                       FROM Receivedoc rd Join vwreceiptPallet vw on rd.ID = vw.ReceiveDocID
                                                       WHERE rd.ReceiptID = {0} and rd.ItemID = {1} and rd.UnitID = {2} and rd.ManufacturerId = {3} 
                                                             and vw.MovingAverageID = {4}", ReceiptID,
                    itemId, itemUnitId, manufacturerId, movingAverageId, averageCost, sellingPrice);
            return query;
        }

        [UpdateQuery]
        public static string InsertSuspendForPricing()
        {
            return String.Format(
                @"INSERT INTO ReceivePriceConfirmation(ReceiveDocID,isCostConfirmed)
                                select ID, 0  as Confirmed
                                     from ReceiveDoc rd where Rd.ID not in (select ReceiveDocID from ReceivePriceConfirmation)");
        }

        [UpdateQuery]
        public static string UpdateSuspendForPricing(int ItemID, int ManufacturerID, int ItemUnitID, int MovingAverageID)
        {
            return String.Format(@"update rcp set IsCostConfirmed = 0 from Receivedoc rd join ReceivePriceConfirmation rcp on rcp.ReceivedocId = rd.ID
                            where rd.ID in (select rd.ID from Receivedoc rd join vwreceiptPallet rp on rp.ReceivedocID = rd.ID
                                                       WHERE rd.ItemID = {0} and rd.UnitID = {1} and rd.ManufacturerId = {2} 
                                                             and rp.MovingAverageID = {3})", ItemID, ItemUnitID, ManufacturerID, MovingAverageID);
        }

        [UpdateQuery]
        public static string InsertReleaseForIssue()
        {
            return String.Format(
                @"INSERT INTO ReceivePriceConfirmation(ReceiveDocID,isCostConfirmed)
                                select ID, 0 as Confirmed
                                     from ReceiveDoc rd where rd.ID not in (select ReceiveDocID from ReceivePriceConfirmation)");
        }

        [UpdateQuery]
        public static string UpdateReleaseForIssue(int ItemID, int ManufacturerID, int ItemUnitID, int AccountID)
        {
            return String.Format(@"update rcp set IsCostConfirmed = 1 from Receivedoc rd join ReceivePriceConfirmation rcp on rcp.ReceivedocId = rd.ID
                            where rd.ID in (select rd.ID from Receivedoc rd join vwreceiptPallet rp on rp.ReceivedocID = rd.ID
                                                       WHERE rd.ItemID = {0} and rd.UnitID = {1} and rd.ManufacturerId = {2} 
                                                             and rp.MovingAverageID = {3})", ItemID, ItemUnitID, ManufacturerID, AccountID);
        }

        [SelectQuery]
        public static string SelectListOfItemPendingPrintAndConfirmation(int itemID, int ManufacturerID, int ItemUnitID, int MovingAverageID, int grnfPrinted, int grvPrinted)
        {
            string query = String.Format(@"select distinct	rp.StockCode
		                                            ,rp.FullItemName
		                                            ,rp.ItemUnitName
		                                            ,rp.ManufacturerName
		                                            ,Case when AccountName <> SubAccountName then AccountName + ' - ' else '' End 
			                                            + Case when SubAccountName <> ActivityName then SubAccountName + ' - 'else ''  End 
			                                            + ActivityName  ActivityFullName
		                                            ,rcs.[Description]
		                                            ,isNull(
					                                            (
						                                            Select 'GRNF No:' + Format(Max(IDPRINTED),'00000') 
							                                            from ReceiptConfirmationPrintout 
							                                            where Reason='PGRV' 
								                                            and ReceiptID = rp.ReceiptID
					                                            )
					                                            ,'RefNo:'+ rd.RefNo
				                                            ) GRVNo
                                                    ,rp.ReceiptID
	                                            from ReceiveDoc rd 
		                                            join vwreceiveDetail rp on rp.ReceiveDocID = rd.ID
		                                            join ReceiveDocConfirmation rdc on rd.ID = rdc.ReceiveDocID
		                                            join ReceiptConfirmationStatus rcs on rdc.ReceiptConfirmationStatusID = rcs.ID
	                                            where rd.itemID = {0} 
		                                            and rp.ManufacturerID = {1} 
		                                            and rp.ItemUnitID = {2} 
		                                            and rp.MovingAverageID = {3} 
                                                    and rcs.ReceiptConfirmationStatusCode in ('UCC','PRC','PRCO') "
                , itemID, ManufacturerID, ItemUnitID, MovingAverageID, grnfPrinted,
                grvPrinted);
            return query;
        }
    }
}
