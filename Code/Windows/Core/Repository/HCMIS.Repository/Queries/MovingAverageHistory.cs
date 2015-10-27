using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class MovingAverageHistory
    {
        [SelectQuery]
        public static string SelectGetListForGRVPricing(int beginingBalance)
        {
            string query = String.Format(@"Select wal.ReceiptId as ReceiptID,po.PONumber OrderNo,
                                                  ri.STVOrInvoiceNo InvoiceNo,
                                                 rcp.IDPrinted GRVNo,rcp.Reason
                                             From weightedAveragelog wal join 
                                                 receipt rt on rt.ID = wal.ReceiptID join
                                                 ReceiptInvoice ri on rt.ReceiptInvoiceID = ri.ID join
                                                 PO on ri.POID = po.ID left join
                                                 receiptConfirmationPrintout rcp on rt.ID = rcp.ReceiptID
                                             Where wal.ReceiptID is not null and rcp.Reason in ('GRV','IGRV')   
											 Group by wal.ReceiptID,ri.STVOrInvoiceNo,rcp.IDPrinted,rcp.Reason,po.PONumber",
                beginingBalance);
            return query;
        }

        [SelectQuery]
        public static string SelectGetMovingAverageByReceiptId(int ReceiptID)
        {
            string query =
                String.Format(@"select su.CompanyName Supplier, vwa.SubAccountName SubAccount,vwa.AccountName Account,vwa.ActivityName Activity , r.DateOfEntry Date,r.ID GRVNo,GETDATE() GRVDate,i.FullItemName ItemName,iu.[Text] Unit,m.Name Manufacturer,wl.* 
                                                from weightedAveragelog wl join 
                                                        vwGetAllItems i on wl.ItemID = i.ID join 
                                                        Manufacturers m on m.ID = wl.ManufacturerID Join 
                                                        ItemUnit iu on iu.ID = wl.UnitID join 
                                                        Receipt r on r.ID = wl.ReceiptId join 
                                                        ReceiptInvoice ri on ri.ID = r.ReceiptInvoiceID join 
                                                        PO on po.ID = ri.POID Join 
                                                        vwAccounts vwa on vwa.ActivityID = po.StoreID join
                                                        Supplier su on su.ID = po.SupplierID 
                                                where ReceiptId = {0}", ReceiptID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetHistory(int itemId, int itemUnitId, int manufacturerId, int movingAverageId)
        {
            string query =
                String.Format(
                    "select Case when w.UPQty = 0 then 'Not applicable' else (select Cast(Max(IDPrinted) as varchar) from ReceiptConfirmationPrintout rcp where (Reason = 'GRV' or Reason = 'IGRV') and rcp.ReceiptID = w.ReceiptID ) end GRV,case when w.UPQty = 0 then 'Override' else Case when w.PQty = 0 then 'Initial Pricing' else 'Moving Averge' end end Remark,w.UPQty,w.UPUnitCost,Case when w.PQty = 0 then 'N/A' else cast(w.PQty as varchar) end PQty,Case when w.PQty = 0 then 'N/A' else Cast(w.PUnitCost as varchar) end PUnitCost, w.Price,w.NQty, w.NUnitCost, w.Margin, u.FullName,w.[Date], m.Name as Manufacturer,w.Remark from MovingAverageHistory w join Manufacturers m on w.ManufacturerID = m.ID join [User] u on w.UserID = u.ID join ItemUnit iu on w.UnitID = iu.ID  where w.ItemID = {0} and w.UnitID = {1} and w.ManufacturerId = {2} and w.StoreID = {3}",
                    itemId, itemUnitId, manufacturerId, movingAverageId);
            return query;
        }

        [SelectQuery]
        public static string SelectGetBeginningBalance(int itemId, int itemUnitId, int manufacturerId, int movingAverageId)
        {
            string query =
                String.Format(
                    @"select eurDate ReceivedDate,BatchNo,ExpDate,sum(Distinct NoOfPack) Quantity,PricePerPack UnitCost 
                            ,sum(Distinct NoOfPack)  * PricePerPack TotalCost,isNull(Margin,0) Margin,Round(PricePerPack * (1+ isNull(Margin,0)),2)SellingPrice, Case when SellingPrice is null then 'Price Not Set' else 'Price Set' end Status
                            from ReceiveDoc rd Join vwReceiptPallet rp on rd.ID = rp.ReceiveDocID
	                 where RefNo like 'BeginningBalance' and rd.ItemID = {0} and rp.ItemUnitID = {1} and rp.ManufacturerID = {2} and rp.AccountID = {3} 
	                        Group by rd.ID,eurDate,batchNo,ExpDate,PricePerPack,Margin,SellingPrice",
                    itemId, itemUnitId, manufacturerId, movingAverageId);
            return query;
        }
    }
}
