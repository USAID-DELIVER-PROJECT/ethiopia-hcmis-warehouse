using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class ReceiptConfirmationPrintout
    {
        [SelectQuery]
        public static string SelectPrepareDataForPrintout(int ReceiptID, string quaranteen)
        {
            return String.Format(@"Select * From (
                                    SELECT 
                                    ItemID, 
                                    FullItemName,
                                    ManufacturerID,
                                    manufacturerName, 
                                    ItemUnitID,
                                    ItemUnitName Unit, 
                                    ActivityID StoreID,
                                    ExpiryDate, 
                                    BatchNumber,
									r.CommodityTypeName CommodityType,
                                    SUM(InvoiceQty) InvoicedQty, 
                                    SUM(ReceivedQty) ReceivedQtyPacks,
                                    SUM(InvoiceQty * InvoiceCost) TotalInvoiceCost ,
                                    SUM(ReceivedQty * UnitCost) TotalCost,
                                    Min(ReceiveDocID) ReceiveDocID
                                            FROM      vwReceiveDetail r
                                            WHERE     r.ReceiptID = {0}
		                                    group by ItemID, FullItemName, ManufacturerID ,manufacturerName,ItemUnitID, ItemUnitName,ActivityID, ExpiryDate, BatchNumber,r.CommodityTypeName) rec

		                                    JOIN (
		                                    SELECT DISTINCT rp.ReceiveID , rd.itemid, rd.UnitID, rd.ManufacturerId, rd.storeid, rd.expDate, rd.BatchNo, 
                                                phS.Name PhysicalStoreName ,
                                                phSType.Name PhysicalStoreTypeName
                                        FROM     ReceivePallet rp
                                                JOIN PalletLocation pl ON rp.PalletLocationID = pl.ID
                                                JOIN ReceiveDoc rd ON rd.ID = rp.ReceiveID
                                                JOIN Shelf sh ON sh.ID = pl.ShelfID
                                                JOIN PhysicalStore phS ON phS.ID = sh.StoreID
                                                JOIN PhysicalStoreType phSType ON phSType.ID = phS.PhysicalStoreTypeID
                                        WHERE    rd.ReceiptID = {0}) phs 
	                                    ON rec.ReceivedocID = phs.ReceiveID 
	                                    JOIN vwReceiveDetail rd on rec.ReceiveDocID = rd.ReceiveDocID
	                                    JOIN vwGetAllItems it on rec.ItemID = it.id
	                                    JOIN CommodityType ct on it.TypeID = ct.ID
	                                    ", ReceiptID, quaranteen);
        }

        [SelectQuery]
        public static string SelectPrepareDataForPrintoutIssueDone(int ReceiptID)
        {
            return String.Format(
                @"select ru.Name,rd.RefNo as STVID,rd.Remark SRMReason, i.FullItemName, m.Name ManufacturerName, rd.BatchNo BatchNumber,cast(rd.ExpDate as date) ExpiryDate, 
                            rd.InvoicedNoOfPack InvoicedQty, rd.Quantity ReceivedQtyBU,
                            rd.NoOfPack ReceivedQtyPacks, rd.UnitCost UnitCost, rd.NoOfPack * rd.UnitCost TotalCost, i.Name as CommodityType, rd.RefNo, rd.StoreID, iu.[Text] Unit, cast(rd.[Date] as Date) ReceiveDate, phS.Name PhysicalStoreName, phSType.Name PhysicalStoreTypeName, rd.ReceiptID
                            from ReceiveDoc rd join Receipt r on rd.ReceiptID=r.ID join ReceiptInvoice rI on r.ReceiptInvoiceID=rI.ID join PO po on rI.POID=po.ID join Institution ru on po.RefNo=ru.ID
                            join vwGetAllItems i on i.ID=rd.ItemID 
                            join Manufacturers m on m.ID=rd.ManufacturerId join ItemUnit iu on iu.ID=rd.UnitID
                            join ReceivePallet rp on rd.ID=rp.ReceiveID join PalletLocation pl on rp.PalletLocationID=pl.ID 
                            join Shelf sh on sh.ID=pl.ShelfID join PhysicalStore phS on phS.ID=sh.StoreID 
                            join PhysicalStoreType phSType on phSType.ID=phS.PhysicalStoreTypeID
                            where rd.ReceiptID = {0} order by CommodityType, ManufacturerName, FullItemName",
                ReceiptID);
        }

        [SelectQuery]
        public static string SelectPrepareDataForPrintoutIssueAndReceiveDone(int ReceiptID)
        {
            var query =
                String.Format(
                    @"select ru.Name,id.STVID,r.STVOrInvoiceNo,rd.Remark SRMReason, i.FullItemName, m.Name ManufacturerName, rd.BatchNo BatchNumber,cast(rd.ExpDate as date) ExpiryDate, s.CompanyName SupplierName,s.ID SupplierID, rd.InvoicedNoOfPack InvoicedQty, rd.Quantity ReceivedQtyBU,
                            (rd.NoOfPack - ISNULL(damaged.DamagedQty,0)) ReceivedQtyPacks, rd.UnitCost UnitCost, rd.NoOfPack * rd.UnitCost TotalCost, i.Name as CommodityType, rd.RefNo, rd.StoreID, iu.[Text] Unit, cast(rd.[Date] as Date) ReceiveDate, phS.Name PhysicalStoreName, phSType.Name PhysicalStoreTypeName, rd.ReceiptID
                            
							from Institution ru join IssueDoc id on ru.ID = id.ReceivingUnitID 
                            join ReceiveDoc rd on id.ID = rd.ReturnedFromIssueDocID
                            join vwGetAllItems i on i.ID=rd.ItemID 
                            join Manufacturers m on m.ID=rd.ManufacturerId join ItemUnit iu on iu.ID=rd.UnitID
                            join ReceivePallet rp on rd.ID=rp.ReceiveID join PalletLocation pl on rp.PalletLocationID=pl.ID 
                            join Shelf sh on sh.ID=pl.ShelfID join PhysicalStore phS on phS.ID=sh.StoreID 
                            join PhysicalStoreType phSType on phSType.ID=phS.PhysicalStoreTypeID
                            left join Supplier s on rd.SupplierID=s.ID
							left join Receipt r on r.ID = rd.ReceiptID
							left Join 
							(select rp.ReceiveID ReceiveDocID ,SUM(rp.ReceivedQuantity) DamagedQty from ReceivePallet rp 
							 join PalletLocation pl on rp.PalletLocationID=pl.ID 
							 where pl.StorageTypeID = 7
							 group by rp.ReceiveID) damaged on rd.ID = damaged.ReceiveDocID
                            where rd.ReceiptID = {0} order by CommodityType, ManufacturerName, FullItemName",
                    ReceiptID);
            return query;
        }

        [SelectQuery]
        public static string SelectPrepareDataForPrintout(int ReceiptID)
        {
            return String.Format(@"select i.FullItemName,i.StockCode, m.Name ManufacturerName,rd.BatchNo BatchNumber,rd.ExpDate ExpiryDate, s.CompanyName SupplierName,s.ID SupplierID,
						 sum(case When sr.ShortageReasonsCode = 'DA' then IsNull(sdr.NoOfPacks,0)else 0 end) DamagedQtyPacks,
						 sum(case When sr.ShortageReasonsCode = 'SL' then IsNull(sdr.NoOfPacks,0)else 0 end) ShortlandedQtyPacks,
						 sum(case when sr.ShortageReasonsCode = 'NREC' then ISNULL(sdr.NoOfPacks,0)else 0 end) NotReceivedQtyPacks,
						  rct.WayBillNo, rct.TransitTransferNo,rct.InsurancePolicyNo, rct.STVOrInvoiceNo, purchaseO.PONumber PONumber,
                                        i.Name as CommodityType, rd.RefNo, rd.StoreID, iu.[Text] Unit, cast(rd.[Date] as Date) ReceiveDate
										, rd.ReceiptID, 
										IsNULL((select Case when Sum(NoOfPack) > 0  Then'ExpiredQty( '+Format(Sum(NoOfPack),'#,##0.####')+' )' Else Null End 
										from ReceiveDoc Exrd where ExpDate < EurDate and Exrd.ReceiptID = rd.ReceiptID and Exrd.ItemID = rd.ItemID and Exrd.UnitID = rd.UnitID and Exrd.ManufacturerId=rd.ManufacturerID and Exrd.ExpDate = rd.ExpDate and Exrd.BatchNo = rd.BatchNo and IsDamaged  = 1),'') + IsNULL('Refer GRNF No ' + STUFF ((Select ','+  right(('00000' + cast(MAX(xrcp.IDPRinted) as varchar)),5)
				                                            from  ReceiveDoc xrd 
																Join Receipt xrt on xrd.ReceiptID = xrt.ID
																Join ReceiptConfirmationPrintout xrcp on xrt.ID = xrcp.ReceiptID
				                                            	where xrd.ReceiptID <> rd.ReceiptID
																	and xrd.StoreID =rd.StoreID
						                                            and xrd.ItemID = rd.ItemID
						                                            and xrd.UnitID = rd.UnitID 
						                                            and xrd.ManufacturerId = rd.ManufacturerId
																	and xrt.ReceiptInvoiceID = rctInvoice.ID
																	and Reason like 'PGRV'
						                                    Group by xrd.ReceiptID
				                                            FOR XML PATH('')),1,1,''),'') Remark
                                        from ReceiveDoc rd join vwGetAllItems i on i.ID=rd.ItemID 
                                        join Manufacturers m on m.ID=rd.ManufacturerId join ItemUnit iu on iu.ID=rd.UnitID
                                        join Receipt rct on rd.ReceiptID=rct.ID
                                        join ReceiptInvoice rctInvoice on rct.ReceiptInvoiceID=rctInvoice.ID
                                        left join PO purchaseO on rctInvoice.POID=purchaseO.ID
                                        left join Supplier s on rd.SupplierID=s.ID join ReceiveDocShortage sdr on sdr.ReceiveDocID = rd.ID
                                        join ShortageReasons sr on sr.ID = sdr.ShortageReasonID
					Where rd.ReceiptID ={0}
                                        group by 
                                        i.FullItemName,i.StockCode, m.Name,rd.BatchNo,rd.ExpDate, s.CompanyName,s.ID, i.Name,rd.refno, rd.StoreID, iu.[Text], cast(rd.[Date] as Date),
                                        rd.ReceiptID, rct.WayBillNo, rct.TransitTransferNo,rct.InsurancePolicyNo, rct.STVOrInvoiceNo, purchaseO.PONumber,rd.ItemID, rd.UnitID, rd.ManufacturerId,rctInvoice.ID
                                        order by CommodityType, ManufacturerName, FullItemName", ReceiptID);
        }

        [SelectQuery]
        public static string SelectGetGRNFNo(int ReceiptID)
        {
            string query =
                String.Format(
                    "Select max(IDPrinted) IDPrinted from ReceiptConfirmationPrintout rc join Receipt r on rc.ReceiptID=r.ID Where rc.ReceiptID={0} and Reason='PGRV'",
                    ReceiptID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetListOfGRNFPrinted(int idPrinted)
        {
            string query =
                String.Format(
                    @"SELECT RIGHT('00000' + CAST (rcp.IDPrinted as nvarchar), 5) GRNF, 
                                        acct.AccountName, rcp.ID , rcp.PrintedDate, rcp.IsVoided IsVoid
                                        FROM ReceiptConfirmationPrintout rcp join vwAccounts acct on rcp.StoreID=acct.ActivityID
                                        WHERE rcp.IDPrinted={0} and rcp.Reason='PGRV'
                                        order by rcp.PrintedDate desc",
                    idPrinted);
            return query;
        }

        [SelectQuery]
        public static string SelectGetListOfGRVPrinted(int idPrinted)
        {
            string query =
                String.Format(
                    @"SELECT RIGHT('00000' + CAST (rcp.IDPrinted as nvarchar), 5) GRV, 
                                        acct.AccountName, rcp.ID , rcp.PrintedDate, rcp.IsVoided IsVoid
                                        FROM ReceiptConfirmationPrintout rcp join vwAccounts acct on rcp.StoreID=acct.ActivityID
                                        WHERE rcp.IDPrinted={0} and rcp.Reason='GRV'
                                        order by rcp.PrintedDate desc",
                    idPrinted);
            return query;
        }

        [SelectQuery]
        public static string SelectGetListOfiGRVPrinted(int idPrinted)
        {
            string query =
                String.Format(
                    @"SELECT RIGHT('00000' + CAST (rcp.IDPrinted as nvarchar), 5) GRV, 
                                        acct.AccountName, rcp.ID , rcp.PrintedDate, rcp.IsVoided IsVoid
                                        FROM ReceiptConfirmationPrintout rcp join vwAccounts acct on rcp.StoreID=acct.ActivityID
                                        WHERE rcp.IDPrinted={0} and rcp.Reason='iGRV'
                                        order by rcp.PrintedDate desc",
                    idPrinted);
            return query;
        }

        [SelectQuery]
        public static string SelectGetListOfSRMPrinted(int idPrinted)
        {
            string query =
                String.Format(
                    @"SELECT RIGHT('00000' + CAST (rcp.IDPrinted as nvarchar), 5) GRV, 
                                        acct.AccountName, rcp.ID , rcp.PrintedDate, rcp.IsVoided IsVoid
                                        FROM ReceiptConfirmationPrintout rcp join vwAccounts acct on rcp.StoreID=acct.ActivityID
                                        WHERE rcp.IDPrinted={0} and rcp.Reason='SRM'
                                        order by rcp.PrintedDate desc",
                    idPrinted);
            return query;
        }

        [SelectQuery]
        public static string SelectGetGRVAndiGRVDescriptions(int accountID)
        {
            string query = String.Format(@"SELECT RIGHT('0000' + Cast(rcp.idprinted AS VARCHAR(50)), 5) AS PrintedNo, 
                                                       acct.ActivityName, 
	                                                   acct.SubAccountName,
	                                                   acct.AccountName,
	                                                   rcp.PrintedDate,
                                                       supp.CompanyName                                        Supplier, 
                                                       CASE 
                                                         WHEN rcp.isreprintof IS NULL THEN 'Original' 
                                                         ELSE ( CASE 
                                                                  WHEN EXISTS (SELECT * 
                                                                               FROM   ReceiptConfirmationPrintout 
                                                                               WHERE  id = rcp.isreprintof) THEN 
                                                                  'Reprint Of: ' 
                                                                  + 
                                                                  (SELECT RIGHT('0000' + Cast(idprinted AS VARCHAR(50)), 5) 
                                                                   FROM   ReceiptConfirmationPrintout 
                                                                   WHERE  id = rcp.isreprintof) 
                                                                  ELSE 'Reprint Of: ' 
                                                                       + (SELECT RIGHT('0000' + Cast(idprinted AS VARCHAR(50)), 
                                                                                 5) 
                                                                          FROM   ReceiptConfirmationPrintout 
                                                                          WHERE  id = rcp.isreprintof) 
                                                                END ) 
                                                       END                                            AS [ReprintOf], 
                                                       CASE 
                                                         WHEN rcp.isvoided = 1 THEN 'Voided' 
                                                         ELSE 'Received' 
                                                       END                                            AS [Status], 
                                                       CASE 
                                                         WHEN EXISTS (SELECT * 
                                                                      FROM   ReceiptConfirmationPrintout 
                                                                      WHERE  isreprintof = rcp.id) THEN 'Reprinted to: ' 
                                                                                                        + (SELECT TOP(1) 
                                                                                                          RIGHT('0000' + 
                                                                                                          Cast(idprinted 
                                                                                                          AS VARCHAR(50)), 5) 
                                                                                                           FROM   ReceiptConfirmationPrintout 
                                                                                                           WHERE  isreprintof = 
                                                                                                                  rcp.id
                                                                                                           ORDER  BY id DESC) 
                                                         ELSE 'Not Reprinted' 
                                                       END                                            AS [Reprinted],
                                                       rcp.Reason                                     AS [Type],
                                                       x.TotalAmount
       
                                                FROM   [ReceiptConfirmationPrintout]  rcp 
                                                       JOIN vwaccounts acct 
                                                         ON rcp.StoreID = acct.ActivityID
	                                                   JOIN Supplier supp
		                                                 ON rcp.SupplierID=supp.ID
                                                       join (select rcp.ID,count(*) NoOfTransactions, Sum(rd.UnitCost * rd.NoOfPack) TotalAmount
                                                            from ReceiveDoc rd join Receipt rct on rd.ReceiptID=rct.ID join ReceiptConfirmationPrintout rcp on rct.ID=rcp.ReceiptID
                                                            where Reason='GRV'
                                                            group by rcp.ID) as x on rcp.ID=x.id
                                                WHERE (rcp.Reason = 'iGRV' or rcp.Reason = 'GRV') and acct.AccountID={0}
                                                ORDER BY rcp.idprinted DESC", accountID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetSRMDescriptions(int accountID)
        {
            string query =
                String.Format(@"select RIGHT('0000' + Cast(rcp.idprinted AS VARCHAR(50)), 5) AS PrintedNo, acct.ActivityName, 
	                                                   acct.SubAccountName,
	                                                   acct.AccountName,
	                                                   Cast(rcp.PrintedDate as date) PrintedDate,
													   ru.Name as Supplier,
													   CASE 
                                                         WHEN rcp.isreprintof IS NULL THEN 'Original' 
                                                         ELSE ( CASE 
                                                                  WHEN EXISTS (SELECT * 
                                                                               FROM   ReceiptConfirmationPrintout 
                                                                               WHERE  id = rcp.isreprintof) THEN 
                                                                  'Reprint Of: ' 
                                                                  + 
                                                                  (SELECT RIGHT('0000' + Cast(idprinted AS VARCHAR(50)), 5) 
                                                                   FROM   ReceiptConfirmationPrintout 
                                                                   WHERE  id = rcp.isreprintof) 
                                                                  ELSE 'Reprint Of: ' 
                                                                       + (SELECT RIGHT('0000' + Cast(idprinted AS VARCHAR(50)), 
                                                                                 5) 
                                                                          FROM   ReceiptConfirmationPrintout 
                                                                          WHERE  id = rcp.isreprintof) 
                                                                END ) 
                                                       END                                            AS [ReprintOf], 
                                                       CASE 
                                                         WHEN rcp.isvoided = 1 THEN 'Voided' 
                                                         ELSE 'Received' 
                                                       END                                            AS [Status], 
                                                       CASE 
                                                         WHEN EXISTS (SELECT * 
                                                                      FROM   ReceiptConfirmationPrintout 
                                                                      WHERE  isreprintof = rcp.id) THEN 'Reprinted to: ' 
                                                                                                        + (SELECT TOP(1) 
                                                                                                          RIGHT('0000' + 
                                                                                                          Cast(idprinted 
                                                                                                          AS VARCHAR(50)), 5) 
                                                                                                           FROM   ReceiptConfirmationPrintout 
                                                                                                           WHERE  isreprintof = 
                                                                                                                  rcp.id
                                                                                                           ORDER  BY id DESC) 
                                                         ELSE 'Not Reprinted' 
                                                       END                                            AS [Reprinted],
													    rcp.Reason                                     AS [Type],
                                                        x.TotalAmount
												from  [ReceiptConfirmationPrintout]  rcp 
												join Receipt r on rcp.ReceiptID=r.ID 
												join ReceiveDoc rd on r.ID=rd.ReceiptID
												JOIN vwaccounts acct ON rcp.StoreID = acct.ActivityID
												join IssueDoc id on rd.ReturnedFromIssueDocID=id.ID 
												join ReceivingUnits ru on id.ReceivingUnitID=ru.ID
                                                       join (select rcp.ID,count(*) NoOfTransactions, Sum(rd.UnitCost * rd.NoOfPack) TotalAmount
                                                            from ReceiveDoc rd join Receipt rct on rd.ReceiptID=rct.ID join ReceiptConfirmationPrintout rcp on rct.ID=rcp.ReceiptID
                                                            where Reason='SRM'
                                                            group by rcp.ID) as x on rcp.ID=x.id

												WHERE rcp.Reason = 'SRM' and acct.AccountID ={0}
												Group by rcp.IDPrinted, acct.ActivityName, 

                                acct.SubAccountName,acct.AccountName,Cast(rcp.PrintedDate as date),ru.Name,rcp.isreprintof,rcp.IsVoided,rcp.ID, rcp.Reason, x.TotalAmount
                                                                                order by rcp.IDPrinted DESC", accountID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetGRNFDescriptions(int accountID)
        {
            string query = String.Format(
                @"SELECT RIGHT('0000' + Cast(rcp.idprinted AS VARCHAR(50)), 5) AS PrintedNo, 
                                                       acct.ActivityName, 
	                                                   acct.SubAccountName,
	                                                   acct.AccountName,
	                                                   rcp.PrintedDate,
                                                       supp.CompanyName                                        Supplier, 
                                                       CASE 
                                                         WHEN rcp.isreprintof IS NULL THEN 'Original' 
                                                         ELSE ( CASE 
                                                                  WHEN EXISTS (SELECT * 
                                                                               FROM   ReceiptConfirmationPrintout 
                                                                               WHERE  id = rcp.isreprintof) THEN 
                                                                  'Reprint Of: ' 
                                                                  + 
                                                                  (SELECT RIGHT('0000' + Cast(idprinted AS VARCHAR(50)), 5) 
                                                                   FROM   ReceiptConfirmationPrintout 
                                                                   WHERE  id = rcp.isreprintof) 
                                                                  ELSE 'Reprint Of: ' 
                                                                       + (SELECT RIGHT('0000' + Cast(idprinted AS VARCHAR(50)), 
                                                                                 5) 
                                                                          FROM   ReceiptConfirmationPrintout 
                                                                          WHERE  id = rcp.isreprintof) 
                                                                END ) 
                                                       END                                            AS [ReprintOf], 
                                                       CASE 
                                                         WHEN rcp.isvoided = 1 THEN 'Voided' 
                                                         ELSE 'Received' 
                                                       END                                            AS [Status], 
                                                       CASE 
                                                         WHEN EXISTS (SELECT * 
                                                                      FROM   ReceiptConfirmationPrintout 
                                                                      WHERE  isreprintof = rcp.id) THEN 'Reprinted to: ' 
                                                                                                        + (SELECT TOP(1) 
                                                                                                          RIGHT('0000' + 
                                                                                                          Cast(idprinted 
                                                                                                          AS VARCHAR(50)), 5) 
                                                                                                           FROM   ReceiptConfirmationPrintout 
                                                                                                           WHERE  isreprintof = 
                                                                                                                  rcp.id
                                                                                                           ORDER  BY id DESC) 
                                                         ELSE 'Not Reprinted' 
                                                       END                                            AS [Reprinted],
                                                       'GRNF'                                     AS [Type],
                                                       x.TotalAmount       
                                                FROM   [ReceiptConfirmationPrintout]  rcp 
                                                       JOIN vwaccounts acct 
                                                         ON rcp.StoreID = acct.ActivityID
	                                                   JOIN Supplier supp
		                                                 ON rcp.SupplierID=supp.ID
                                                       join (select rcp.ID,count(*) NoOfTransactions, Sum(rd.UnitCost * rd.NoOfPack) TotalAmount
                                                            from ReceiveDoc rd join Receipt rct on rd.ReceiptID=rct.ID join ReceiptConfirmationPrintout rcp on rct.ID=rcp.ReceiptID
                                                            where Reason='PGRV'
                                                            group by rcp.ID) as x on rcp.ID=x.id

                                                WHERE rcp.Reason = 'PGRV' and acct.AccountID ={0}
                                                ORDER BY rcp.idprinted DESC", accountID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetReceivePrintoutDetails(int receiptID, string reason)
        {
            string query =
                string.Format(@"Select rcp.ReceiptID, rcp.Reason, RIGHT('00000' + CAST (x.IDPrinted as nvarchar), 5) IDPrinted, 
                                            rcp.PrintedDate, rcp.UserID, u.FullName
                                            from ReceiptConfirmationPrintout rcp
                                            Left Join (Select Max(ID) ID, Max(IDPrinted) IDPrinted from ReceiptConfirmationPrintout Where ReceiptID = {0} and Reason = '{1}') x on rcp.ID = x.ID 
                                            Left Join [User] u on rcp.UserID  = u.ID
                                             Where ReceiptID = {0} and Reason = '{1}'", receiptID, reason);
            return query;
        }
    }
}
