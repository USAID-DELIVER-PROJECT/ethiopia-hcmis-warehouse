using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class PickList
    {
        [SelectQuery]
        public static string SelectLoadByOrderID(int orderId)
        {
            string query = String.Format("select * from PickList where OrderID = {0}", orderId);
            return query;
        }

        [SelectQuery]
        public static string SelectGetPickListDetailsForOrder(int picklistID)
        {
            string query =
                String.Format(
                    "select [LineNum]=0, iu.Text as Unit,pld.BatchNumber BatchNo, pld.ExpireDate ExpDate, pld.ID PLDetailID, pld.*, rd.Margin, p.PalletNo, s.CompanyName as SupplierName, vw.FullItemName,vw.StockCode StockCode,vw.Name as CommodityType, m.Name ManufacturerName, vwp.PalletLocation, sg.ID StoreGroupID, sg.Name StoreGroupName,pl.SavedDate PickedDate from PickListDetail pld join Manufacturers m on m.ID = pld.ManufacturerID join PickList pl on pl.ID = pld .PickListID join vwGetAllItems vw on vw.ID = pld.ItemID left join ItemUnit iu on pld.UnitID = iu.ID join vwPalletLocation vwp on vwp.ID = pld.PalletLocationID left Join PalletLocation plc on pld.PalletLocationID = plc.ID left join Pallet p on plc.PalletID = p.ID join ReceiveDoc rd on pld.ReceiveDocID = rd.ID join Supplier s on rd.SupplierID = s.ID  join stores stor on pld.StoreID=stor.ID join StoreGroupDivision sdiv on stor.StoreGroupDivisionID=sdiv.ID join StoreGroup sg on sdiv.StoreGroupID=sg.ID where PickListID = {0} order by sg.ID",
                    picklistID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetPickListDetailsForOrderPrepared(int id)
        {
            string query =
                String.Format(
                    "select [LineNum]=0, iu.Text as Unit,pld.BatchNumber BatchNo, pld.ExpireDate ExpDate,pld.ID PLDetailID, pld.*, rd.Margin, p.PalletNo, s.CompanyName as SupplierName, vw.FullItemName,vw.StockCode StockCode,vw.Name as CommodityType, m.Name ManufacturerName, vwp.PalletLocation, sg.ID StoreGroupID, sg.Name StoreGroupName from PickListDetail pld join Manufacturers m on m.ID = pld.ManufacturerID join vwGetAllItems vw on vw.ID = pld.ItemID left join ItemUnit iu on pld.UnitID = iu.ID join vwPalletLocation vwp on vwp.ID = pld.PalletLocationID left Join PalletLocation plc on pld.PalletLocationID = plc.ID left join Pallet p on plc.PalletID = p.ID join ReceiveDoc rd on pld.ReceiveDocID = rd.ID join Supplier s on rd.SupplierID = s.ID  join stores stor on pld.StoreID=stor.ID join StoreGroupDivision sdiv on stor.StoreGroupDivisionID=sdiv.ID join StoreGroup sg on sdiv.StoreGroupID=sg.ID where PickListID = {0} order by sg.ID",
                    id);
            return query;
        }

        [SelectQuery]
        public static string SelectGetPickedOrderDetailForOrder(int stvLogID)
        {
            return String.Format("select distinct pl.ID, [LineNum]=0, id.Date as IssueDate , id.STVID, id.Margin, iu.Text as Unit, id.BatchNo as BatchNumber ,id.Cost, id.NoOfPack as Packs, id.Quantity as QuantityInBU,pld.ID PickListDetailID ,pld.*, s.ID as SupplierID, s.CompanyName as SupplierName, vw.FullItemName, vw.StockCode, m.Name ManufacturerName, vwp.PalletLocation,vw.Name as CommodityType, sg.ID StoreGroupID, sg.Name StoreGroupName, cast(id.ID as varchar) IssueDocID from PickListDetail pld join Manufacturers m on m.ID = pld.ManufacturerID join vwGetAllItems vw on vw.ID = pld.ItemID join vwPalletLocation vwp on vwp.ID = pld.PalletLocationID join ReceiveDoc rd on pld.ReceiveDocID = rd.ID join Supplier s on rd.SupplierID = s.ID left join ItemUnit iu on rd.UnitID = iu.ID join PickList pl on pld.PickListID = pl.ID join  IssueDoc id on id.PLDetailID = pld.ID join stores stor on pld.StoreID=stor.ID join StoreGroupDivision sdiv on stor.StoreGroupDivisionID=sdiv.ID join StoreGroup sg on sdiv.StoreGroupID=sg.ID where  id.STVID in (Select ID from StvLog where ID={0} or IsReprintOf={0})", stvLogID);
        }

        [SelectQuery]
        public static string SelectGetPickedOrderDetailForOrderIncludeDeleted(int stvLogID)
        {
            return String.Format("select distinct ID=null, [LineNum]=0, id.Date as IssueDate , id.STVID, rd.Margin, iu.Text as Unit, id.BatchNo as BatchNumber ,id.Cost, id.NoOfPack as Packs, id.Quantity as QuantityInBU, s.ID as SupplierID, s.CompanyName as SupplierName, vw.FullItemName, vw.StockCode, m.Name ManufacturerName, PalletLocation = null,vw.Name as CommodityType, a.AccountID StoreGroupID, a.AccountName StoreGroupName, cast(id.ID as varchar) IssueDocID ,rd.StoreID from IssueDocDeleted id join  vwGetAllItems vw on vw.ID = id.ItemID join ReceiveDoc rd on id.RecievDocID = rd.ID join Supplier s on rd.SupplierID = s.ID  join ItemUnit iu on rd.UnitID = iu.ID  join vwAccounts a on a.ActivityID = id.StoreID join Manufacturers m on m.ID = rd.ManufacturerID  where id.STVID in (Select ID from StvLog where ID={0} or IsReprintOf={0})", stvLogID);
        }

        [SelectQuery]
        public static string SelectGetDistinctPickList(int storeId, int issuedTo)
        {
            string query =
                String.Format(
                    "SELECT  DISTINCT(RefNo), Min(o.ID) as ID , Parent = 0, min(Date) as Date FROM PickListDetail pld join PickList pl on pl.ID = pld.PickListID Join [Order] o on pl.OrderID = o.ID WHERE pld.StoreID = {0} and RequestedBy = {1} group by RefNo ",
                    storeId, issuedTo);
            return query;
        }

        [SelectQuery]
        public static string SelectGetDistinctPickList(int storeId)
        {
            return String.Format("SELECT DISTINCT( RefNo ),Cast(RefNo as int) as R, Min(o.ID) as ID , Parent = 0, min(Date) as Date FROM PickListDetail pld join PickList pl on pl.ID = pld.PickListID Join [Order] o on pl.OrderID = o.ID WHERE pld.StoreID = {0} group by RefNo Order By Cast(RefNo as int) DESC", storeId);
        }

        [SelectQuery]
        public static string SelectGetPickListSummary()
        {
            string query;
            query = @"select datename(dw,CONVERT(datetime,floor(CONVERT(float,eurdate)))) + ' ' + 
							cast(Day(CONVERT(datetime,floor(CONVERT(float,eurdate)))) as varchar) [Date],
							CONVERT(datetime,floor(CONVERT(float,eurdate))),
							COUNT(distinct o.RequestedBy) Value
							from PickList pl join [Order] o on pl.OrderID=o.ID
							group by CONVERT(datetime,floor(CONVERT(float,eurdate)))
							order by CONVERT(datetime,floor(CONVERT(float,eurdate)))";
            return query;
        }

        [SelectQuery]
        public static string SelectGetPickListSummary(int days)
        {
            return String.Format(@"select datename(dw,CONVERT(datetime,floor(CONVERT(float,eurdate)))) + ' ' + 
										cast(Day(CONVERT(datetime,floor(CONVERT(float,eurdate)))) as varchar) [Date],
										CONVERT(datetime,floor(CONVERT(float,eurdate))),
										COUNT(distinct o.RequestedBy) Value
										from PickList pl join [Order] o on pl.OrderID=o.ID
										where DATEDIFF(dd,eurdate,getdate())<={0}
										group by CONVERT(datetime,floor(CONVERT(float,eurdate)))
										order by CONVERT(datetime,floor(CONVERT(float,eurdate)))", days);
        }

        [SelectQuery]
        public static string SelectGetPickListDetailWithDiagnostics(int orderID, int _itemID, int _unitID)
        {
            string query =
                String.Format(
                    "select rp.Balance / pld.QtyPerPack as Balance, rp.ReservedStock / pld.QtyPerPack as Reserved, pld.Packs as Picked  from PickListDetail pld join PickList pl on pl.ID = pld.PickListID join ReceivePallet rp on pld.ReceivePalletID = rp.ID where pl.OrderID = {0} and pld.ItemID = {1} and pld.UnitID = {2} ",
                    orderID, _itemID, _unitID);
            return query;
        }

        [SelectQuery]
        public static string SelectCancelExpiredPicklists(int noOfDaysPicklistStaysAfterPrinting)
        {
            string query =
                String.Format(
                    "Select pl.OrderID from Picklist pl join [Order] o on pl.OrderID=o.ID where  not exists (select OrderID from IssueDoc where OrderID = o.ID) and o.OrderStatusID  in (  select ID from OrderStatus where OrderStatusCode in('PIKL','CNCL')) and datediff(dd,SavedDate,getdate())>{0}",
                    noOfDaysPicklistStaysAfterPrinting);
            return query;
        }

        [SelectQuery]
        public static string SelectTotalExpiredPicklists(int noOfDaysPicklistStaysAfterPrinting)
        {
            string query =
                String.Format(
                    "Select o.ID from Picklist pl join [Order] o on pl.OrderID=o.ID  join [OrderStatus] os on o.OrderStatusID = os.ID where  os.OrderStatusCode  in ('CNCL','PIKL') and datediff(dd,SavedDate,getdate())>{0}",
                    noOfDaysPicklistStaysAfterPrinting);
            return query;
        }
    }
}
