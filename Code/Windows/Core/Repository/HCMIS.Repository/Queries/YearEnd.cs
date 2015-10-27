using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Repository.Queries
{
    public class YearEnd
    {
        public static string SelectGetBBalance(int storeId, int itemId, int bYear)
        {
            string query = String.Format("Select * from YearEnd where StoreID = {0} AND ItemID = {1} AND Year = {2}", storeId, itemId, bYear);
            return query;
        }

        public static string SelectGetBBalanceSelectElse(int year, int storeId, int itemId)
        {
            string query = String.Format("Select * from YearEnd where StoreID = {0} AND ItemID = {1} AND Year = {2}", storeId, itemId, year - 1);
            return query;
        }

        public static string SelectGetDocumentByYear(int storeId, string year)
        {
            string query = String.Format("Select ye.*,vw.FullItemName from YearEnd ye join vwGetAllItems vw on ye.ItemID = vw.ID where StoreID = {0} AND Year = {1}", storeId, year);
            return query;
        }
       
        public static string SelectGetDistinctYear(int storeId)
        {
            string query = String.Format("Select DISTINCT Year FROM YearEnd WHERE StoreID = {0} ", storeId);
            return query;
        }

        public static string SelectGetDocumentAll(int storeId)
        {
            string query = String.Format("Select ye.*,vw.FullItemName from YearEnd ye join vwGetAllItems vw on ye.ItemID = vw.ID where StoreID = {0} ORDER BY Year DESC", storeId);
            return query;
        }

        public static string SelectIsPerformedForYear(int year)
        {
            string query = String.Format("select * from YearEnd where Year = {0}", year);
            return query;
        }

        public static string UpdateUpdateYearEndValue(long yearEndQuantity2, int itemID, int unitID, int year)
        {
            string query = String.Format("UPDATE YearEnd SET PhysicalInventory={0}, EBalance={0} WHERE ItemID={1} and UnitID ={2} and year={3}", yearEndQuantity2, itemID, unitID, year);
            return query;
        }

        public static string SelectGetItemsForYearEndInventory(int storeID, int physicalStoreID, bool withQtyOnly)
        {
            string queryQL = withQtyOnly ? " and quantityleft>0 " : "";

            string query = String.Format(@"select  ROW_NUMBER() over (order by i.FullItemName) as RowNo,phS.ID PhysicalStoreID,rd.ExpDate, i.FullItemName,rd.ItemID,iu.[Text] as Unit, sum(yEnd.EBalance) BeginningBalance,rd.BatchNo, sum(rd.QuantityLeft/rd.QtyPerPack)  as EndingBalance,
                                            isnull(yEnd.PhysicalInventory,null) PhysicalInventory, rd.UnitID, null Remark
                                            from ReceiveDoc rd join ItemUnit iu on rd.ItemID=iu.ID join vwGetAllItems i on i.ID=rd.ItemID 
                                            left join YearEnd yEnd on rd.UnitID=yEnd.UnitID and rd.ItemID=yEnd.ItemID and rd.StoreID=yEnd.StoreID
                                            join ReceivePallet rp on rd.ID=rp.ReceiveID join PalletLocation pl on rp.PalletLocationID=pl.ID
                                            join Shelf sh on pl.ShelfID=sh.ID join PhysicalStore phS on phS.ID=sh.StoreID
                                            where rd.StoreID={0} and phS.ID = {1} {2}
                                            group by rd.StoreID,phS.ID,i.FullItemName,rd.ExpDate, rd.ItemID,iu.ID, iu.[Text],rd.UnitID,rd.BatchNo,yEnd.PhysicalInventory", storeID, physicalStoreID, queryQL);
            return query;
        }

        public static string SelectGetItemsDetailLocationForYearEndInventory(int storeID, int physicalStoreID, bool withQtyOnly)
        {
            string queryQL = withQtyOnly ? " and quantityleft>0 " : "";

            string query = String.Format(@"select 
                                                ROW_NUMBER() over (order by i.FullItemName) as RowNo
                                                , i.FullItemName
                                                , rp.ID
                                                , rp.Balance / rd.QtyPerPack Balance
                                                , rd.QtyPerPack
                                                , rd.UnitID
                                                , rd.ItemID
                                                , phS.ID PhysicalStoreID
                                                , iu.[Text] Unit
                                                , m.Name Manufacturer
                                                , pl.Label Location
                                                , rd.ExpDate
                                                , rd.BatchNo
                                                , null NewBalance
                                                , rp.ReceiveID
                                                , cast(rp.ReserveOrderID as bit) InventoryPerformed
                                            from ReceivePallet rp 
                                                join ReceiveDoc rd on rp.ReceiveID=rd.ID 
                                                join PalletLocation pl on rp.PalletLocationID=pl.ID
                                                join Shelf sh on pl.ShelfID=sh.ID 
                                                join PhysicalStore phS on phS.ID=sh.StoreID join vwGetAllItems i on rd.ItemID=i.ID
                                                join ItemUnit iu on rd.UnitID=iu.ID 
                                                join Manufacturers m on rd.ManufacturerID=m.ID
                                            where 
                                                rd.QuantityLeft > 0 and rd.StoreID ={0} and phS.ID = {1} {2}", storeID, physicalStoreID, queryQL);
            return query;
        }

        public static string SelectLoadByItemUnitStoreAndPhysicalStore(int itm, int unit, int storeID, int physicalStoreID, int year)
        {
            string query = String.Format("select * from YearEnd where ItemID={0} and UnitID={1} and StoreID={2} and physicalStoreID={3} and Year={4}", itm, unit, storeID, physicalStoreID, year);
            return query;
        }
    }
}
