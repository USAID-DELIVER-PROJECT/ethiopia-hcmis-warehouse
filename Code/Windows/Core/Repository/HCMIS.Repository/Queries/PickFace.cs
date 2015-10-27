using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Repository.Queries
{
    public class PickFace
    {
        public static string SelectLoadByPalletLocation(int palletLocationId)
        {
            string query = String.Format("select * from PickFace where PalletLocationID = {0}", palletLocationId);
            return query;
        }

        public static string SelectLoadPalletLocationsWithoutEntries(string StorageTypePickFace)
        {
            string query = String.Format("select * from PalletLocation where ID not in (Select PalletLocationID from PickFace) and StorageTypeID = {0}", StorageTypePickFace);
            return query;
        }

        public static string DeleteDeleteNonPickfaceEntries(string StorageTypePickFace)
        {
            string query = String.Format("delete from PickFace where PalletLocationID in (Select ID from PalletLocation where StorageTypeID <> {0})", StorageTypePickFace);
            return query;
        }

        public static string SelectGetPalletLocationsForItemLookup(int itemId)
        {
            string query = String.Format("select pf.*, pl.ID PalletLocationID, pl.Label from PickFace pf join PalletLocation pl on pl.ID = pf.PalletLocationID where ( pf.DesignatedItem = {0} ) or DesignatedItem is null order by pl.Label", itemId);
            return query;
        }

        public static string SelectGetPalletLocationsForItem(int itemId, int storeID)
        {
            string query = String.Format("select pf.*, pl.ID PalletLocationID, pl.Label from PickFace pf join PalletLocation pl on pl.ID = pf.PalletLocationID where (pf.DesignatedItem = {0} and pf.LogicalStore = {1} ) or DesignatedItem is null order by pl.Label", itemId, storeID);
            return query;
        }

        public static string SelectGetExistingPalletLocationsForItem(int itemId)
        {
            string query = String.Format("select pf.*, pl.ID PalletLocationID, pl.Label from PickFace pf join PalletLocation pl on pl.ID = pf.PalletLocationID where pf.DesignatedItem = {0} order by pl.Label", itemId);
            return query;
        }

        public static string SelectPalletLocationForItem(int itemId)
        {
            string query = String.Format("select pl.ID from PickFace pf join PalletLocation pl on pl.ID = pf.PalletLocationID where pf.DesignatedItem = {0}", itemId);
            return query;
        }

        public static string UpdateSavePickFaceLocation(int itemId, int storeID)
        {
            string query = String.Format("update PickFace set DesignatedItem = null where DesignatedItem = {0} and LogicalStore = {1}", itemId, storeID);
            return query;
        }

        public static string SelectGetDetailItemsFor(int palletID)
        {
            string query = String.Format("select  rp.*, (rp.Balance / rd.QtyPerPack) as SKU,vw.FullItemName,m.Name as Manufacturer,rd.ItemID,rd.ManufacturerID, rd.BatchNo, rd.ExpDate as ExpiryDate, rp.Balance from ReceivePallet rp join ReceiveDoc rd on rp.ReceiveID = rd.ID join vwGetAllItems vw on rd.ItemID = vw.ID join Manufacturers m on m.ID = rd.ManufacturerID where rp.PalletID = {0} and rp.Balance > 0 order by ExpDate", palletID);
            return query;
        }

        public static string SelectGetReplenishmentListFor(int itemId, string StorageTypeBulkStore)
        {
            string query = String.Format("select distinct( BatchNo ), rp.ID as ReceivePalletID, vwpl.PalletLocation, rd.ID, vw.FullItemName, rd.BoxLevel , QuantityLeft, ItemID,SupplierID, ExpDate ExpiryDate, StoreID, RefNo, Cost, Balance, ManufacturerID,m.Name as ManufacturerName,ReceiveID, rp.PalletID, EurDate, PalletNo from ReceiveDoc rd join ReceivePallet rp on rd.ID = rp.ReceiveID join Manufacturers m on m.ID = rd.ManufacturerID left join Pallet p on p.ID = rp.PalletID join vwGetAllItems vw on vw.ID = rd.ItemID join PalletLocation pl on rp.PalletID = pl.PalletID join vwPalletLocation vwpl on vwpl.ID = pl.ID where ItemID = {0} and QuantityLeft > 0 and pl.StorageTypeID = {1}", itemId, StorageTypeBulkStore);
            return query;
        }

        public static string SelectFormLoadPalletLocationForItemGridat(int itemId)
        {
            string query = String.Format("select s.ID as LogicalStore, s.StoreName, pf.PalletLocationID from Stores s left join (select * from PickFace  where DesignatedItem = {0}) pf on s.ID = pf.LogicalStore", itemId);
            return query;
        }

        public static string UpdateGetPickFaceStockLevel()
        {
            string query = "update i set Balance = a.Balance from PickFace i join PalletLocation pl on i.PalletLocationID = pl.ID join (select rp.PalletID, sum(rp.Balance - rp.ReservedStock) as Balance, rd.ItemID from ReceiveDoc rd join ReceivePallet rp on rd.ID = rp.ReceiveID  group by rp.PalletID,rd.ItemID) a on pl.PalletID = a.PalletID where a.ItemID = i.DesignatedItem ";
            return query;
        }

        public static string SelectGetPickFaceStockLevel(int logicalStore)
        {
            string query = String.Format("select distinct (a.Balance / isnull(rd.QtyPerPack,1)) as Balance ,  a.* from  (select max(isnull(pf.Balance,0) ) as Balance , vwp.PalletLocation, vw.FullItemName,  pf.DesignatedItem, pf.PalletLocationID, pf.ID from PickFace  pf join PalletLocation pl on pf.PalletLocationID = pl.ID join vwGetAllItems vw on pf.DesignatedItem = vw.ID join vwPalletLocation vwp on pf.PalletLocationID = vwp.ID where pf.LogicalStore = {0} group by vwp.PalletLocation, vw.FullItemName,vw.StockCode, pf.DesignatedItem, pf.PalletLocationID, pf.ID ) a left join PalletLocation pl on a.PalletLocationID = pl.ID left join ReceivePallet rp on pl.PalletID = rp.PalletID left join ReceiveDoc rd on rp.ReceiveID = rd.ID order by a.FullItemName", logicalStore);
            return query;
        }

        public static string SelectGetReplenishmentListFor(int itemId, int storeId, string StorageTypeBulkStore)
        {
            string query = String.Format("select BatchNo ,(UsedVolume/ case when AvailableVolume = 0 then 1 else isnull(AvailableVolume,1) end ) as Percentage,rp.ID as ReceivePalletID, vwpl.PalletLocation, rd.ID,rp.BoxSize, vw.FullItemName, rd.BoxLevel , QuantityLeft, ItemID,SupplierID, ExpDate ExpiryDate, StoreID, RefNo, Cost, (Balance - isnull(ReservedStock,0)) as Balance, ManufacturerID,m.Name as ManufacturerName,ReceiveID, rp.PalletID, EurDate, PalletNo from ReceiveDoc rd join ReceivePallet rp on rd.ID = rp.ReceiveID join Manufacturers m on m.ID = rd.ManufacturerID left join Pallet p on p.ID = rp.PalletID join vwGetAllItems vw on vw.ID = rd.ItemID join PalletLocation pl on rp.PalletID = pl.PalletID join vwPalletLocation vwpl on vwpl.ID = pl.ID where ItemID = {0} and rp.Balance - rp.ReservedStock > 0 and pl.StorageTypeID = {1} and rd.StoreID = {2} order by ExpDate,Percentage,rp.Balance", itemId, StorageTypeBulkStore, storeId);
            return query;
        }

        public static string SelectLoadPickFaceFor(int itemId, int storeId)
        {
            string query = String.Format("select * from PickFace where DesignatedItem = {0} and LogicalStore = {1}", itemId, storeId);
            return query;
        }

        public static string SelectClearPickFaceFor(int itemId, int logicalStore)
        {
            string query = String.Format("update PickFace set DesignatedItem = null where DesignatedItem = {0} and LogicalStore = {1}", itemId, logicalStore);
            return query;
        }
    }
}
