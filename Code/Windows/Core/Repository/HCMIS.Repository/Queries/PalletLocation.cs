using System;
using HCMIS.Repository.Helpers;


namespace HCMIS.Repository.Queries
{
    public class PalletLocation
    {

        [SelectQuery]
        public static string SelectNormalPalletLocation(int warehouseID, int userId)
        {
            string query =
                String.Format(@"select pl.ID ID,pl.ID PalletLocationID
		                                , (ps.Name + ' ' + st.Prefix + ' ' + pl.Label) as PalletLocationName
		                                , ps.ID PhysicalStoreID
                                        , pl.label PalletLocationLabel
		                                , ps.Name PhysicalStoreName
		                                , st.ID StorageTypeID
		                                , st.StorageTypeName StorageTypeName
		                                , s.ShelfCode ShelfCode
                                        ,Prefered = 2 
                                from PalletLocation pl 
	                                join StorageType st on pl.StorageTypeID = st.ID 
	                                join Shelf s on s.ID = pl.ShelfID 
	                                join PhysicalStore ps on ps.ID = s.StoreID 
                                where StorageTypeCode <> 'SA' and ps.PhysicalStoreTypeID ={0} and ps.ID IN (
		                            Select PhysicalStoreID from 
			                            UserPhysicalStore 
			                            where CanAccess = 1 
			            and Userid = {1})", warehouseID, userId);
            return query;
        }

        [SelectQuery]
        public static string SelectQuaranteenPalletLocation(int warehouseID, int userId)
        {
            string query =
                 String.Format(@"select pl.ID ID,pl.ID PalletLocationID
		                                , (ps.Name + ' ' + st.Prefix + ' ' + pl.Label) as PalletLocationName
                                        , pl.ID  PutAwayLocation
		                                , ps.ID PhysicalStoreID
                                        , pl.label PalletLocationLabel
		                                , ps.Name PhysicalStoreName
		                                , st.ID StorageTypeID
		                                , st.StorageTypeName StorageTypeName
		                                , s.ShelfCode ShelfCode
                                        ,Prefered = 1 
                                from PalletLocation pl 
	                                join StorageType st on pl.StorageTypeID = st.ID 
	                                join Shelf s on s.ID = pl.ShelfID 
	                                join PhysicalStore ps on ps.ID = s.StoreID 
                                where StorageTypeCode = 'SA' and ps.PhysicalStoreTypeID ={0} and ps.ID IN (
		                            Select PhysicalStoreID from 
			                            UserPhysicalStore 
			                            where CanAccess = 1 
			            and Userid = {1})", warehouseID, userId);
            return query;
        }

        [SelectQuery]
        public static string SelectNormalPalletLocationByPhysicalStore(int physicalStoreId, int userId)
        {
            string query =
                String.Format(@"select pl.ID PalletLocationID
		                                , (ps.Name + ' ' + st.Prefix + ' ' + pl.Label) as PalletLocationName
		                                , ps.ID PhysicalStoreID
                                        , pl.label PalletLocationLabel
		                                , ps.Name PhysicalStoreName
		                                , st.ID StorageTypeID
		                                , st.StorageTypeName StorageTypeName
		                                , s.ShelfCode ShelfCode
                                        ,Prefered = 2 
                                from PalletLocation pl 
	                                join StorageType st on pl.StorageTypeID = st.ID 
	                                join Shelf s on s.ID = pl.ShelfID 
	                                join PhysicalStore ps on ps.ID = s.StoreID 
                                where StorageTypeCode <> 'SA' and ps.ID IN (
		                            Select PhysicalStoreID from 
			                            UserPhysicalStore 
			                            where CanAccess = 1 and ps.ID = {0}
			            and Userid = {1})", physicalStoreId, userId);
            return query;
        }
        [SelectQuery]
        public static string SelectQuaranteenPalletLocationByPhysicalStore(int physicalStoreId, int userId)
        {
            string query =
                 String.Format(@"select pl.ID PalletLocationID
		                                , (ps.Name + ' ' + st.Prefix + ' ' + pl.Label) as PalletLocationName
		                                , ps.ID PhysicalStoreID
                                        , pl.label PalletLocationLabel
		                                , ps.Name PhysicalStoreName
		                                , st.ID StorageTypeID
		                                , st.StorageTypeName StorageTypeName
		                                , s.ShelfCode ShelfCode
                                        ,Prefered = 1 
                                from PalletLocation pl 
	                                join StorageType st on pl.StorageTypeID = st.ID 
	                                join Shelf s on s.ID = pl.ShelfID 
	                                join PhysicalStore ps on ps.ID = s.StoreID 
                                where StorageTypeCode = 'SA' and ps.ID IN (
		                            Select PhysicalStoreID from 
			                            UserPhysicalStore 
			                            where CanAccess = 1 and ps.ID = {0}
			            and Userid = {1})", physicalStoreId, userId);
            return query;
        }
        [SelectQuery]
        public static string SelectLoadPalletLocationsByShelf(int shelfId)
        {
            string query=
             String.Format("select * from PalletLocation where ShelfID = {0}", shelfId);
            return query;
        }
        public static string SelectLoadPalletLocationsByShelf(int shelfId, string storageType)
        {
            string query=
             String.Format("select * from PalletLocation where ShelfID = {0} and StorageTypeID = {1}", shelfId, storageType);
            return query;
        }

        public static string SelectLoadPalletLocationFor(string shelfId, string column, string row)
        {
            string query=
             String.Format("select * from PalletLocation where ShelfID = {0} and [Column] = {1} and [Row] = {2}", shelfId, column, row);
            return query;
        }
        public static string SelectLoadPalletLocationFor(int shelfId, int column, int row)
        {
            string query=
             String.Format("select * from PalletLocation where ShelfID = {0} and [Column] = {1} and [Row] = {2}", shelfId, column, row);
            return query;
        }
        public static string UpdateChangeStorageTypesOf(int shelfID, int @from, int to)
        {
             string query=
             String.Format("update PalletLocation set StorageTypeID = {2} where ShelfID = {0} and StorageTypeID = {1}", shelfID, @from, to);
            return query;
        }
        public static string UpdateChangeStorageTypesOf(int shelfID, int to)
        {
            string query=
            String.Format("update PalletLocation set StorageTypeID = {1} where ShelfID = {0} ", shelfID, to);
            return query;
        }
       
      
        public static string SelectGetAllFreeFree(string StorageType)
        {
            string query=
             String.Format("select (ps.Name + ' ' + st.Prefix + ' ' + pl.Label) as PalletLocationName  , * from PalletLocation pl join StorageType st on pl.StorageTypeID = st.ID join Shelf s on s.ID = pl.ShelfID join PhysicalStore ps on ps.ID = s.StoreID where StorageTypeID = {0}", StorageType);
            return query;
        }
        public static string SelectGetAllFreeElse(string StorageType, string storageTypeFree)
        {
            string query=
             String.Format("select (ps.Name + ' ' + st.Prefix + ' ' + pl.Label) as PalletLocationName  , * from PalletLocation pl join StorageType st on pl.StorageTypeID = st.ID join Shelf s on s.ID = pl.ShelfID join PhysicalStore ps on ps.ID = s.StoreID where StorageTypeID in ({0},{1}) and pl.PalletID is null", StorageType, storageTypeFree);
            return query;
        }

        public static string SelectGetAllFreeBulkStore(string StorageType, string storageTypeStackedStorage, string storageTypePickFace, string storageTypeFree)
        {
            string query=
             String.Format("select (ps.Name + ' ' + st.Prefix + ' ' + pl.Label) as PalletLocationName  , * from PalletLocation pl join StorageType st on pl.StorageTypeID = st.ID join Shelf s on s.ID = pl.ShelfID join PhysicalStore ps on ps.ID = s.StoreID where StorageTypeID in ({0},{1},{2},{3})", StorageType,storageTypeStackedStorage,storageTypePickFace,storageTypeFree);
            return query;
        }
        public static string SelectGetAllFreeForItemFree(int itemID, string StorageType)
        {
            return String.Format("select (ps.Name + ' ' + st.Prefix + ' ' + pl.Label) as PalletLocationName  , * , Prefered = 0 from PalletLocation as pl join StorageType st on pl.StorageTypeID = st.ID  join Shelf s on s.ID = pl.ShelfID join PhysicalStore ps on ps.ID = s.StoreID  where StorageTypeID = {0} and pl.IsEnabled = 1 and pl.ID not in (select PalletLocationID from ItemPrefferedLocation ipll where ipll.ItemID = {1})", StorageType, itemID);
        }
        public static string SelectGetAllFreeForItemElse(int itemID, string StorageType, string storageTypeFree,int shelfId = 0)
        {
            return String.Format(@"select (ps.Name + ' ' + st.Prefix + ' ' + pl.Label) as PalletLocationName  , * , Prefered = 0 
                                        from PalletLocation as pl join StorageType st on pl.StorageTypeID = st.ID  
                                        join Shelf s on s.ID = pl.ShelfID join PhysicalStore ps on ps.ID = s.StoreID  
                                        where  pl.IsEnabled = 1 {3} and pl.ID not in 
                                        (select PalletLocationID from ItemPrefferedLocation ipll where ipll.ItemID = {1})"
                                        , StorageType, itemID, storageTypeFree, shelfId != 0 ? String.Format("and ps.ID =(select StoreID from Shelf where id ={0})", shelfId) : "");
        }
        public static string SelectGetAllFreeForItemBulkStore(int itemID, string StorageType, double volume, int userID,string stackedStorageID, string freeStorageID)
        {
            return String.Format(@"select c.Name Cluster,
                                                psT.Name Warehouse,
                                                ps.Name Store, (ps.Name + ' ' + st.Prefix + ' ' + pl.Label) as PalletLocationName  , * , 
                                                Prefered = 2, (( {2} / case when pl.AvailableVolume = 0 then 1 else pl.AvailableVolume end ) * 100) 
                                                as Utilization, pst.ID as WarehouseID 
                                            from 
                                                PalletLocation as pl 
                                                join StorageType st on pl.StorageTypeID = st.ID  
                                                join Shelf s on s.ID = pl.ShelfID 
                                                join PhysicalStore ps on ps.ID = s.StoreID   
                                                join PhysicalStoreType psT on ps.PhysicalStoreTypeID = psT.ID 
                                                join Cluster c on pst.ClusterID = c.ID 
                                            where ( StorageTypeID = {0} or StorageTypeID = {3}) 
                                                and pl.PalletID is null 
                                                and pl.IsEnabled = 1 
                                                -- I don't think this is a correct query specification.
                                                and pl.ID not in (select PalletLocationID 
                                                                        from 
                                                                            ItemPrefferedLocation ipll 
                                                                        where 
                                                                            ipll.ItemID = {1}   
                                                                  )
                                                and  ps.ID in (select PhysicalStoreID from UserPhysicalStore where CanAccess=1 and UserID={5})  
                                        union
                                        select 
                                                c.Name Cluster,psT.Name Warehouse,ps.Name Store, (ps.Name + ' ' + st.Prefix + ' ' + pl.Label) as PalletLocationName  , * , 
                                                Prefered = 2, (( {2} / case when pl.AvailableVolume = 0 then 1 else pl.AvailableVolume end ) * 100) as Utilization , pst.ID as WarehouseID 
                                            from 
                                                PalletLocation as pl 
                                                join StorageType st on pl.StorageTypeID = st.ID  
                                                join Shelf s on s.ID = pl.ShelfID 
                                                join PhysicalStore ps on ps.ID = s.StoreID  
                                                join PhysicalStoreType psT on ps.PhysicalStoreTypeID=psT.ID 
                                                join Cluster c on pst.ClusterID=c.ID 
                                        where 
                                                (StorageTypeID = {4}) 
                                                and pl.IsEnabled = 1 
                                                and  ps.ID in (
                                                                    select PhysicalStoreID from UserPhysicalStore where CanAccess=1 and UserID={5}
                                                                )   
                                        order by PalletLocationName",
                StorageType, itemID, volume,stackedStorageID,freeStorageID, userID);
        }
        public static string SelectGetAllFreeForItem(int itemID, string StorageType, double volume, int userID)
        {
            return String.Format(
                @"select  
                            c.Name Cluster, psT.Name Warehouse, ps.Name Store, (ps.Name + ' ' + st.Prefix + ' ' + pl.Label) as PalletLocationName  , * , Prefered = 2, (( {2} / case when pl.AvailableVolume = 0 then 1 else pl.AvailableVolume end ) * 100) as Utilization, pst.ID as WarehouseID 
                                from 
                                    PalletLocation as pl 
                                    join StorageType st on pl.StorageTypeID = st.ID  
                                    join Shelf s on s.ID = pl.ShelfID 
                                    join PhysicalStore ps on ps.ID = s.StoreID 
                                    join PhysicalStoreType psT on ps.PhysicalStoreTypeID=psT.ID 
                                    join Cluster c on pst.ClusterID=c.ID   
                                where 
                                    (StorageTypeID = {0}) 
                                    and pl.IsEnabled = 1 
                                    and  ps.ID in (
                                                        select PhysicalStoreID 
                                                            from 
                                                               UserPhysicalStore 
                                                            where 
                                                                CanAccess=1 and UserID={3}
                                                    )  
                                order by PalletLocationName",
                StorageType, itemID, volume, userID);
        }
        public static string SelectGetAllFreeForItemElseExistingLocation(int itemID)
        {
            return String.Format(@"select pl.* 
                                            from PalletLocation pl 
                                                 join Pallet p on pl.PalletID = p.ID 
                                                 join ReceivePallet rp on p.ID = rp.PalletID 
                                            join ReceiveDoc rd on rp.ReceiveID = rd.ID where rd.ItemID = {0} and rd.QuantityLeft > 0", itemID);
        }
        public static string SelectGetAllFreeForItemElseError(int itemID, string StorageType, double volume, int userID, string ins, string storageTypeFree)
        {
            if (ins != "")
            {
                ins = string.Format(" or pl.PalletID in ({0}) ", ins);
            }

            return String.Format(@"select  c.Name Cluster, psT.Name Warehouse,ps.Name Store, (ps.Name + ' ' + st.Prefix + ' ' + pl.Label) as PalletLocationName  , * , Prefered = 2, 
                                        (( {2} / case when pl.AvailableVolume = 0 then 1 else pl.AvailableVolume end ) * 100) as Utilization , pst.ID as WarehouseID
                                            from PalletLocation as pl 
                                                join StorageType st on pl.StorageTypeID = st.ID  
                                                join Shelf s on s.ID = pl.ShelfID 
                                                join PhysicalStore ps on ps.ID = s.StoreID 
                                                join PhysicalStoreType psT on ps.PhysicalStoreTypeID=psT.ID 
                                                join Cluster c on pst.ClusterID=c.ID 
                                        where StorageTypeID = {0} 
                                                and (pl.PalletID is null {3}) 
                                                and pl.IsEnabled = 1    
                                                and pl.ID not in (select PalletLocationID 
                                                                        from ItemPrefferedLocation ipll 
                                                                        where 
                                                                           ipll.ItemID = {1}  
                                                                   )
                                                and  ps.ID in (select PhysicalStoreID from UserPhysicalStore where CanAccess=1 and UserID={5})
                                       ",
                StorageType, itemID, volume, ins, storageTypeFree, userID);
        }
        public static string SelectLoadLocationForPallet(int pallet)
        {
            return String.Format("select * from PalletLocation where PalletID = {0}", pallet);
        }

        public static string SelectGetAllFreeFor(int itemID)
        {
            return String.Format(
                @"select (ps.Name + ' ' + st.Prefix + ' ' + pl.Label) as PalletLocationName  , *, Prefered = 1 from PalletLocation pl join StorageType st on pl.StorageTypeID = st.ID join ItemPrefferedLocation ipl on ipl.PalletLocationID = pl.ID  join Shelf s on s.ID = pl.ShelfID join PhysicalStore ps on ps.ID = s.StoreID where ipl.ItemID = {0} and pl.PalletID is null and pl.IsEnabled = 1",
                itemID);
        }

        public static string SelectGetAllFreeForthesameStore(int itemID,int palletid)
        {
            return
                string.Format(
                    @"select (ps.Name + ' ' + st.Prefix + ' ' + pl.Label) as PalletLocationName  , * , Prefered = 0,pl.ID as palletlocationid 
                                    from PalletLocation as pl 
	                                    join StorageType st on pl.StorageTypeID = st.ID  
	                                    join Shelf s on s.ID = pl.ShelfID 
	                                    join PhysicalStore ps on ps.ID = s.StoreID  
                                    where  pl.IsEnabled = 1  and 
	                                       ps.ID=(select s .storeid from palletlocation pl join shelf s on s.ID=pl.shelfid where pl .palletid={0}) and
	                                       pl.StorageTypeID = (select StorageTypeID from palletlocation pl  where pl.palletid={0}) and
	                                       pl.palletid is not null and
	                                       pl.ID not in (select PalletLocationID from ItemPrefferedLocation ipll where ipll.ItemID = {1})
                                           and pl.id not in (select pl.id from palletlocation pl where pl.palletid = 3044)",
                    palletid, itemID);
        }

        public static string SelectGetCurrentAndAllFreeFor(int itemID)
        {
            return String.Format("select (ps.Name + ' ' + st.Prefix + ' ' + pl.Label) as PalletLocationName  , *, Prefered = 1 from PalletLocation pl join StorageType st on pl.StorageTypeID = st.ID join ItemPrefferedLocation ipl on ipl.PalletLocationID = pl.ID  join Shelf s on s.ID = pl.ShelfID join PhysicalStore ps on ps.ID = s.StoreID  where ipl.ItemID = {0} and pl.PalletID is null and pl.IsEnabled = 1", itemID);
        }
        public static string SelectGetAllFreeFor(int itemID, double volume, int userID)
        {
            return String.Format(
                "select c.Name Cluster, psT.Name Warehouse, ps.Name Store, (ps.Name + ' ' + st.Prefix + ' ' + pl.Label) as PalletLocationName  , *, Prefered = 1 , (({1}/ case when pl.AvailableVolume = 0 then 1 else pl.AvailableVolume end )* 100 )as Utilization, pst.ID as WarehouseID from PalletLocation pl join StorageType st on pl.StorageTypeID = st.ID join ItemPrefferedLocation ipl on ipl.PalletLocationID = pl.ID  join Shelf s on s.ID = pl.ShelfID join PhysicalStore ps on ps.ID = s.StoreID join PhysicalStoreType psT on ps.PhysicalStoreTypeID=psT.ID join Cluster c on pst.ClusterID=c.ID  where ipl.ItemID = {0} and pl.PalletID is null and pl.IsEnabled = 1 and ps.ID in (select PhysicalStoreID from UserPhysicalStore where CanAccess=1 and UserID={2}) order by Prefered, PalletLocationName ",
                itemID, volume, userID);
        }

        public static string SelectGetQuaranteen(int userID, string storageType)
        {
            string query = String.Format(
                "select (ps.Name + ' ' + st.Prefix + ' ' + pl.Label) as PalletLocationName  , *, Prefered = 1, pst.ID as WarehouseID from PalletLocation pl join StorageType st on pl.StorageTypeID = st.ID  join Shelf s on s.ID = pl.ShelfID join PhysicalStore ps on ps.ID = s.StoreID join PhysicalStoreType pst on ps.PhysicalStoreTypeID = pst.ID where pl.StorageTypeID = {0} and pl.IsEnabled = 1 and ps.IsActive = 1 and  ps.ID in (select PhysicalStoreID from UserPhysicalStore where CanAccess=1 and UserID={1}) ",
                storageType, userID);
            return query;
        }
        public static string SelectGetAllFreeNonBulk(string bulkStoreStorage,string pickFaceStorage,string quarantineStorage,string freeStorage)
        {
            string query = String.Format("select (ps.Name + ' ' + st.Prefix + ' ' + pl.Label) as PalletLocationName  , * from PalletLocation pl join StorageType st on pl.StorageTypeID = st.ID  join Shelf s on s.ID = pl.ShelfID join PhysicalStore ps on ps.ID = s.StoreID  where ( StorageTypeID <> {0} and StorageTypeID <> {1} and pl.PalletID is null ) or ( pl.StorageTypeID in ({2},{3}))",bulkStoreStorage,pickFaceStorage,quarantineStorage,freeStorage);
            return query;
        }
        public static string SelectGetAll()
        {
            string query = String.Format("select (ps.Name + ' ' + st.Prefix + ' ' + pl.Label) as PalletLocationName  , * from PalletLocation pl join StorageType st on pl.StorageTypeID = st.ID join Shelf s on s.ID = pl.ShelfID join PhysicalStore ps on ps.ID = s.StoreID ");
            return query;
        }
        public static string SelectGetAll(int physicalStoreId, string storageType)
        {
            string query = String.Format(@"select (ps.Name + ' ' + st.Prefix + ' ' + pl.Label) as PalletLocationName  
                                          , * from PalletLocation pl 
                                                join StorageType st on pl.StorageTypeID = st.ID 
                                                join Shelf s on s.ID = pl.ShelfID 
                                                join PhysicalStore ps on ps.ID = s.StoreID
                                            Where ps.ID = {0} and StorageTypeID <> {1}", physicalStoreId, storageType);
            return query;
        }
        public static string SelectLoadFreePrefferedLocationFor(int itemID)
        {
            string query = String.Format("select pl.* from PalletLocation pl join ItemPrefferedLocation ipl on pl.ID = ipl.PalletLocationID where pl.PalletID is null and ipl.ItemID = {0}", itemID);
            return query;
        }
        public static string SelectGetUnConfirmedReceivesForUser(int userID, int receiptConfirmationStatusID)
        {
            string query = String.Format("select rd.RefNo, min(rd.Date)  as Date from ReceiveDoc rd where rd.StoreID in (select StoreID from UserStore where UserID = {0} and CanAccess=1) and rd.ID in (Select ReceiveDocID from ReceiveDocConfirmation where ReceiptConfirmationStatusID={1}) group by RefNo", userID, receiptConfirmationStatusID);
            return query;
        }
        public static string SelectGetUnConfirmedReceives(int userID, int receiptConfirmationStatus)
        {
            string query = String.Format("select rd.RefNo, min(rd.Date)as Date,rd.StoreID, rdc.ReceiptConfirmationStatusID [Status],rcs.Name,{1} as CurrentStatus from ReceiveDoc rd join ReceiveDocConfirmation rdc on rd.ID = rdc.ReceivedocID  join receiptConfirmationStatus rcs on rdc.ReceiptConfirmationStatusID = rcs.ID where rd.StoreID in (select StoreID from UserStore where UserID = {0} and CanAccess=1) and rcs.ReceiptConfirmationStatusCode <> 'PRCO' group by RefNo,StoreID,ReceiptConfirmationStatusID,rcs.Name", userID, receiptConfirmationStatus);
            return query;
        }

        public static string SelectGetReceivesForQtyConfirmation(int userID, int receiveEnteredID, int receiveQtyConfirmedID, bool showBeginningBalanceOnGRNF)
        {
            string filter = "";
            if (!showBeginningBalanceOnGRNF)
            {
                filter = " and rd.RefNo <> 'BeginningBalance'";
            }

            string query = string.Format(@"select rd.ReceiptID,  case when rd.ReturnedStock=1 then 'SRM: ' else '' end + rctInvoice.STVOrInvoiceNo as STVOrInvoiceNo, s.CompanyName Supplier,po.PONumber,
	                                    rd.RefNo, min(rd.Date)as Date,
										rd.StoreID, rT.Name ReceiptType,rcs.Name Status,rdc.ReceiptConfirmationStatusID,
										ps.ClusterName,ps.WarehouseID,ps.WarehouseName, pot.Name POType, pt.Name PaymentType, dt.Name DocumentType, rct.ID ReceiptNo 
                        From  
	                         ReceiveDoc rd join Receipt rct on rd.ReceiptID=rct.ID join 
                             ReceiptInvoice rctInvoice on rct.ReceiptInvoiceID=rctInvoice.ID join
							 MessageBroker.DocumentType dt on rctInvoice.DocumentTypeID = dt.DocumentTypeID Join
                             PO po on po.ID=rctInvoice.POID join Supplier s on s.ID=po.SupplierID join
							 Procurement.PurchaseOrderType pot on po.Purchasetype =  pot.PurchaseOrderTypeID Left Join 
							 PaymentType pt on po.PaymentTypeID = pt.ID Join
	                         ReceiveDocConfirmation rdc on rd.ID = rdc.ReceivedocID join 
	                         ReceiptConfirmationStatus rcs on rdc.ReceiptConfirmationStatusID = rcs.ID join
                             ReceivePallet rp on rd.ID=rp.ReceiveID join
                             PalletLocation pl on rp.PalletLocationID=pl.ID join
                             Shelf sh on sh.ID=pl.ShelfID join
                             vwPhysicalStore ps on ps.PhysicalStoreID=sh.StoreID join 
                             ReceiptType rT on rT.ID=rct.ReceiptTypeID join
                             UserPhysicalStore ups on ups.UserID = {0} and ups.CanAccess = 1 and ups.PhysicalStoreID = ps.PhysicalStoreID
                        where
	                         rd.StoreID in (select StoreID from UserStore where UserID = {0} and CanAccess=1) 
                            and (rdc.ReceiptConfirmationStatusID = {1} or ReceiptConfirmationStatusID = {2}) {3} 
                        Group by rd.ReceiptID,rd.ReturnedStock,rT.Name,rd.RefNo,rd.StoreID,rctInvoice.STVOrInvoiceNo,po.PONumber,s.CompanyName,ps.ClusterName,ps.WarehouseName,ps.WarehouseID,rcs.Name,rdc.ReceiptConfirmationStatusID, pot.Name, pt.Name, dt.Name, rct.ID", userID, receiveEnteredID, receiveQtyConfirmedID, filter);
            
            return query;
        }
        public static string SelectGetDetailsOfReferenceNo(string referenceNo)
        {
            string query = String.Format("select distinct RefNo, rd.ID ReceiveID, rd.ItemID, p.PalletNo,s.StoreName as Store, su.CompanyName as Supplier , rp.PalletID, vw.FullItemName , rd.ExpDate , rd.NoOfPack , pl.ID PalletLocationID, pl.ID as ProposedPalletLocationID ,rd.PricePerPack PricePerPack, rd.Cost as UnitCost, rp.ReceivedQuantity / rd.QtyPerPack as Packs, (rp.ReceivedQuantity / rd.QtyPerPack) * rd.Cost as TotalCost,(rp.ReceivedQuantity / rd.QtyPerPack) * rd.PricePerPack as TotalReceived, m.Name as Manufacturer, isNull(rd.Margin,0.10) Margin,  IsNull(rd.Insurance,0) Insurance, null as SellingPrice from ReceivePallet rp join ReceiveDoc rd on rp.ReceiveID = rd.ID join Stores s on s.ID = rd.StoreID join Manufacturers m on m.ID = rd.ManufacturerID join vwGetAllItems vw  on vw.ID = rd.ItemID join Pallet p on p.ID = rp.PalletID join PalletLocation pl on pl.PalletID = p.ID left join Supplier su on su.ID = rd.SupplierID where rd.RefNo='{0}'", referenceNo);
            return query;
        }
        public static string SelectGetDetailsOfByReceiptIDIsCenter(int receiptID)
        {
            return String.Format("select distinct RefNo,vw.Stockcode StockCode, rd.ID ReceiveID, rd.ItemID,s.StoreName as Store, su.CompanyName as Supplier , rp.PalletID, vw.FullItemName,rd.UnitID, iu.[Text] Unit ,rd.ManufacturerID, rd.ExpDate , rd.NoOfPack , pl.ID PalletLocationID, pl.ID as ProposedPalletLocationID ,rd.PricePerPack PricePerPack, rd.Cost as UnitCost, rp.ReceivedQuantity / rd.QtyPerPack as Packs,rd.BatchNo Batch, (rp.ReceivedQuantity / rd.QtyPerPack) * rd.Cost as TotalCost,(rp.ReceivedQuantity / rd.QtyPerPack) * rd.PricePerPack as TotalReceived, m.Name as Manufacturer, isNull(rd.Margin,0.10) Margin,  IsNull(rd.Insurance,0) Insurance,rd.ReceiptID, ps.Name PhysicalStoreName,rd.InvoicedNoOfPack InvoicedQty from ReceivePallet rp join ReceiveDoc rd on rp.ReceiveID = rd.ID join Stores s on s.ID = rd.StoreID join Manufacturers m on m.ID = rd.ManufacturerID join vwGetAllItems vw  on vw.ID = rd.ItemID join PalletLocation pl on pl.ID = rp.PalletLocationID join Shelf sh on sh.ID=pl.ShelfID join PhysicalStore ps on sh.StoreID=ps.ID left join Supplier su on su.ID = rd.SupplierID join ItemUnit iu on rd.UnitID=iu.ID where rd.receiptID = {0}", receiptID);
        }
        public static string SelectGetDetailsOfByReceiptIDElse(int receiptID)
        {
            return String.Format("select distinct RefNo,vw.Stockcode StockCode, rd.ID ReceiveID, rd.ItemID,s.StoreName as Store, su.CompanyName as Supplier , rp.PalletID, vw.FullItemName,rd.UnitID, iu.[Text] Unit ,rd.ManufacturerID, rd.ExpDate , rd.NoOfPack , pl.ID PalletLocationID, pl.ID as ProposedPalletLocationID ,rd.PricePerPack PricePerPack, rd.UnitCost as UnitCost, rp.ReceivedQuantity / rd.QtyPerPack as Packs,rd.BatchNo Batch, (rp.ReceivedQuantity / rd.QtyPerPack) * rd.UnitCost as TotalCost,(rp.ReceivedQuantity / rd.QtyPerPack) * rd.PricePerPack as TotalReceived, m.Name as Manufacturer, isNull(rd.Margin,0.10) Margin,  IsNull(rd.Insurance,0) Insurance,rd.ReceiptID, ps.Name PhysicalStoreName,rd.InvoicedNoOfPack InvoicedQty from ReceivePallet rp join ReceiveDoc rd on rp.ReceiveID = rd.ID join Stores s on s.ID = rd.StoreID join Manufacturers m on m.ID = rd.ManufacturerID join vwGetAllItems vw  on vw.ID = rd.ItemID join PalletLocation pl on pl.ID = rp.PalletLocationID  join Shelf sh on sh.ID=pl.ShelfID join PhysicalStore ps on sh.StoreID=ps.ID left join Supplier su on su.ID = rd.SupplierID join ItemUnit iu on rd.UnitID=iu.ID where rd.receiptID = {0}", receiptID);
        }
        public static string SelectGetMasterOfInvoiceByReceiptID(string reference)
        {
            return String.Format("Select  rd.ItemID,rd.UnitID,rd.ManufacturerID,iu.text, vw.FullItemName ,sum(rd.InvoicedNoOfPack) InvoicedNoOfPack , sum(rd.NoOfPack) NoOfPack,Avg(rd.PricePerPack) PricePerPack, Avg(rd.Cost) as UnitCost, Sum(rd.InvoicedNoOfPack * rd.Cost) as TotalCost,Sum(rd.InvoicedNoOfPack * rd.PricePerPack)as TotalReceived, m.Name as Manufacturer from ReceivePallet rp join ReceiveDoc rd on rp.ReceiveID = rd.ID  join receipt r on r.ID = rd.ReceiptID Join Stores s on s.ID = rd.StoreID join Manufacturers m on m.ID = rd.ManufacturerID join vwGetAllItems vw  on vw.ID = rd.ItemID join Pallet p on p.ID = rp.PalletID join PalletLocation pl on pl.PalletID = p.ID left join Supplier su on su.ID = rd.SupplierID join Receipt rt on rt.ID = rd.ReceiptID join itemUnit iu on rd.unitID = iu.ID where  rt.ReceiptInvoiceID is Null and rd.InvoicedNoOfPack is not NULL Group by  rd.ItemID,rd.UnitID,rd.ManufacturerId, vw.FullItemName,m.Name,iu.Text", reference);
        }
        public static string SelectGetDetailsOfInvoice(string referenceNo)
        {
            return String.Format("Select CL.Name Cluster,WH.Name Warehouse,ps.Name Store,rt.ID ReceiptID, rd.ID ReceiveID,rd.ItemID,rd.UnitID,rd.ManufacturerID,rd.InvoicedNoOfPack, rd.ExpDate , rd.NoOfPack NoOfPack,rd.PricePerPack PricePerPack, rd.Cost as UnitCost, rd.InvoicedNoOfPack * rd.Cost as TotalCost,rd.InvoicedNoOfPack * rd.PricePerPack as TotalReceived from ReceivePallet rp join ReceiveDoc rd on rp.ReceiveID = rd.ID  join receipt r on r.ID = rd.ReceiptID Join Stores s on s.ID = rd.StoreID join Manufacturers m on m.ID = rd.ManufacturerID join vwGetAllItems vw  on vw.ID = rd.ItemID join Pallet p on p.ID = rp.PalletID join PalletLocation pl on pl.PalletID = p.ID left join Supplier su on su.ID = rd.SupplierID  join Receipt rt on rt.ID = rd.ReceiptID join Shelf sh on pl.ShelfID = sh.ID join PhysicalStore ps on ps.Id = sh.StoreID join PhysicalStoreType WH on WH.ID = ps.PhysicalStoreTypeID join Cluster CL on CL.ID = WH.ClusterID  where rt.STVOrInvoiceNo =\'{0}\' and rd.InvoicedNoOfPack is not NULL", referenceNo);
        }
        public static string SelectGetDetailsOfShortagaAndDamagedByReceiptID(string referenceNo, string StorageTypeQuaranteen)
        {
            return String.Format(@"select distinct RefNo, rd.ID ReceiveID, rd.ItemID, p.PalletNo,s.StoreName as Store,rd.UnitID,rd.ManufacturerID, su.CompanyName as Supplier , rp.PalletID, vw.FullItemName , rd.ExpDate , rd.NoOfPack , pl.ID PalletLocationID, pl.ID as ProposedPalletLocationID ,rd.PricePerPack PricePerPack, rd.Cost as UnitCost, rp.ReceivedQuantity / rd.QtyPerPack as Packs, (rp.ReceivedQuantity / rd.QtyPerPack) * rd.Cost as TotalCost,(rp.ReceivedQuantity / rd.QtyPerPack) * rd.PricePerPack as TotalReceived, m.Name as Manufacturer, 'Damaged' as Status from ReceivePallet rp join ReceiveDoc rd on rp.ReceiveID = rd.ID join Stores s on s.ID = rd.StoreID join Manufacturers m on m.ID = rd.ManufacturerID join vwGetAllItems vw  on vw.ID = rd.ItemID join Pallet p on p.ID = rp.PalletID join PalletLocation pl on pl.PalletID = p.ID left join Supplier su on su.ID = rd.SupplierID join Shelf sh on pl.ShelfID = sh.ID join PhysicalStore ps on ps.Id = sh.StoreID join PhysicalStoreType WH on WH.ID = ps.PhysicalStoreTypeID join Cluster CL on CL.ID = WH.ClusterID Join Receipt r on r.ID = rd.ReceiptID where  pl.StorageTypeID = {1} and r.STVOrInvoiceNo ='{0}' and rd.InvoicedNoOfPack is not NULL
                                            union
                                          select distinct RefNo, rd.ID ReceiveID, rd.ItemID, p.PalletNo,s.StoreName as Store,rd.UnitID,rd.ManufacturerID, su.CompanyName as Supplier , rp.PalletID, vw.FullItemName , rd.ExpDate , rd.InvoicedNoOfPack - rd.NoOfPack , pl.ID PalletLocationID, pl.ID as ProposedPalletLocationID ,rd.PricePerPack PricePerPack, rd.Cost as UnitCost, rp.ReceivedQuantity / rd.QtyPerPack as Packs, (rp.ReceivedQuantity / rd.QtyPerPack) * rd.Cost as TotalCost,(rp.ReceivedQuantity / rd.QtyPerPack) * rd.PricePerPack as TotalReceived, m.Name as Manufacturer, 'Shortage' as Status from ReceivePallet rp join ReceiveDoc rd on rp.ReceiveID = rd.ID join Stores s on s.ID = rd.StoreID join Manufacturers m on m.ID = rd.ManufacturerID join vwGetAllItems vw  on vw.ID = rd.ItemID join Pallet p on p.ID = rp.PalletID join PalletLocation pl on pl.PalletID = p.ID left join Supplier su on su.ID = rd.SupplierID join Shelf sh on pl.ShelfID = sh.ID join PhysicalStore ps on ps.Id = sh.StoreID join PhysicalStoreType WH on WH.ID = ps.PhysicalStoreTypeID join Cluster CL on CL.ID = WH.ClusterID  Join Receipt r on r.ID = rd.ReceiptID where r.STVOrInvoiceNo ='{0}' and rd.InvoicedNoOfPack - rd.NoOfPack >0 ", referenceNo, StorageTypeQuaranteen);
        }
        public static string SelectGetDetailsOfShortagaAndDamagedByReceiptID(int receiptID, string StorageTypeQuaranteen)
        {
            return String.Format(@"select distinct RefNo, rd.ID ReceiveID, rd.ItemID, p.PalletNo,s.StoreName as Store,rd.UnitID
                                                                ,rd.ManufacturerID, su.CompanyName as Supplier , rp.PalletID, vw.FullItemName,
                                                                 rd.ExpDate,rd.BatchNo Batch,vw.StockCode StockCode, rd.NoOfPack , pl.ID PalletLocationID,iu.[Text] Unit , 
                                                                 pl.ID as ProposedPalletLocationID ,rd.PricePerPack PricePerPack, rd.Cost as UnitCost,
                                                                 rp.ReceivedQuantity / rd.QtyPerPack as Packs, (rp.ReceivedQuantity / rd.QtyPerPack) * rd.Cost as TotalCost,
                                                                (rp.ReceivedQuantity / rd.QtyPerPack) * rd.PricePerPack as TotalReceived, m.Name as Manufacturer, isNull(rd.Margin,0.10) Margin, 
                                                                IsNull(rd.Insurance,0) Insurance, IsNull(shR.Name,'Damaged') as Status 
                                                    from ReceivePallet rp join ReceiveDoc rd on rp.ReceiveID = rd.ID 
                                                    join Stores s on s.ID = rd.StoreID join Manufacturers m on m.ID = rd.ManufacturerID join vwGetAllItems vw  on vw.ID = rd.ItemID join Pallet p on p.ID = rp.PalletID join PalletLocation pl on pl.PalletID = p.ID left join Supplier su on su.ID = rd.SupplierID join Shelf sh on pl.ShelfID = sh.ID join PhysicalStore ps on ps.Id = sh.StoreID join PhysicalStoreType WH on WH.ID = ps.PhysicalStoreTypeID join Cluster CL on CL.ID = WH.ClusterID Join Receipt r on r.ID = rd.ReceiptID join ItemUnit iu on rd.UnitID=iu.ID left join ShortageReasons shR on rd.ShortageReasonID=shR.ID 
                                                    where  pl.StorageTypeID = {1}  and rp.Balance > 0 and r.ID ='{0}' 
                                                    union
                                           select distinct RefNo, rd.ID ReceiveID, rd.ItemID, p.PalletNo,s.StoreName as Store,rd.UnitID,rd.ManufacturerID, su.CompanyName as Supplier , rp.PalletID, vw.FullItemName , rd.ExpDate,rd.BatchNo Batch,vw.StockCode StockCode, rd.InvoicedNoOfPack - rd.NoOfPack,pl.ID PalletLocationID, iu.[Text] Unit, pl.ID as ProposedPalletLocationID ,rd.PricePerPack PricePerPack, rd.Cost as UnitCost, rp.ReceivedQuantity / rd.QtyPerPack as Packs, (rp.ReceivedQuantity / rd.QtyPerPack) * rd.Cost as TotalCost,(rp.ReceivedQuantity / rd.QtyPerPack) * rd.PricePerPack as TotalReceived, m.Name as Manufacturer, isNull(rd.Margin,0.10) Margin,  IsNull(rd.Insurance,0) Insurance, shR.Name as Status from ReceivePallet rp join ReceiveDoc rd on rp.ReceiveID = rd.ID join Stores s on s.ID = rd.StoreID join Manufacturers m on m.ID = rd.ManufacturerID join vwGetAllItems vw  on vw.ID = rd.ItemID join Pallet p on p.ID = rp.PalletID join PalletLocation pl on pl.PalletID = p.ID left join Supplier su on su.ID = rd.SupplierID join Shelf sh on pl.ShelfID = sh.ID join PhysicalStore ps on ps.Id = sh.StoreID join PhysicalStoreType WH on WH.ID = ps.PhysicalStoreTypeID join Cluster CL on CL.ID = WH.ClusterID join ItemUnit iu on rd.UnitID=iu.ID join ShortageReasons shR on rd.ShortageReasonID=shR.ID   where rd.receiptID = {0} and rd.InvoicedNoOfPack - rd.NoOfPack >0  ", receiptID, StorageTypeQuaranteen);
        }

        public static string SelectGetQuaranteenItems(string StorageTypeQuaranteen)
        {
            return String.Format("select RefNo, rd.ItemID,  rp.PalletID, vw.StockCode, vw.FullItemName, rd.ManufacturerID, rd.ExpDate , rd.BatchNo , pl.ID PalletLocationID, rp.Balance / rd.QtyPerPack AS Balance , rd.QtyPerPack , rp.ID as ReceivePalletID , (rp.Balance / rd.QtyPerPack * rd.Cost) as Price, case when rd.ExpDate < GetDate() then 1 else 0 end as IsExpired,Ac.Name Activity,pl.Label as palletlocationname from ReceivePallet rp join ReceiveDoc rd on rp.ReceiveID = rd.ID join vwGetAllItems vw  on vw.ID = rd.ItemID join Pallet p on p.ID = rp.PalletID join PalletLocation pl on pl.PalletID = p.ID join Account.Activity Ac on Ac.ActivityID = rd.StoreID where rp.Balance > 0 and rp.PalletID in (select pll.PalletID from PalletLocation pll where pll.PalletID is not null and pll.StorageTypeID = {0})", StorageTypeQuaranteen);
        }

        public static string UpdateConfirmAllReceived(string reference)
        {
            return String.Format("update PalletLocation set Confirmed = 1 where ID in ( select pl.ID from ReceivePallet rp join ReceiveDoc rd on rp.ReceiveID = rd.ID join PalletLocation pl on pl.PalletID = rp.PalletID where  rd.RefNo = '{0}')", reference);
        }

        public static string SelectCalculateAllVolumes()
        {
            return "select * from PalletLocation where PalletID is not null";
        }

        public static string SelectRecommendPalletMovments(string StorageTypeBulkStore)
        {
            string query = String.Format("select * from PalletLocation pl join ReceivePallet rp on pl.PalletID = rp.PalletID join ReceiveDoc rd on rp.ReceiveID = rd.ID where pl.PalletID is not null and StorageTypeID = {0} order by rd.ItemID", StorageTypeBulkStore);
            return query;
        }

        public static string SelectLoadNonPrimaryHalf(int shelfID, int row, int col)
        {
            string query = String.Format("select * from PalletLocation where ShelfID = {0} and [Row] = {1} and [Column] = {2} ", shelfID, row, col);
            return query;
        }

        public static string UpdateGarbageCollection()
        {
            string query = String.Format(@"UPDATE PalletLocation set PalletID = NULL WHERE PalletID in (SELECT Distinct PalletID Value from PalletLocation 
                                            WHERE PalletID not in ( select PalletID from ReceivePallet group by PalletID having SUM(Balance) > 0) 
                                              AND  StorageTypeID not in (SELECT StorageTypeID FROM InventoryManagement.StorageType WHERE StorageTypeCode IN ('SA','PF')))");
            return query;
        }

        public static string UpdateGarbageCollectionPalletLocation()
        {
            string query = String.Format("UPDATE  PalletLocation SET UsedVolume = 0 WHERE PalletID IS NULL and UsedVolume > 0");
            return query;
        }

        public static string SelectCountUtilized(int shelfID)
        {
            string query = String.Format("select count(*) as Count from PalletLocation where ShelfID = {0} and PalletID is not null", shelfID);
            return query;
        }

        public static string SelectCountUtilizedOther(int shelfID)
        {
            string query = String.Format("select count(*) as Count from PalletLocation where ShelfID = {0}", shelfID);
            return query;
        }

        public static string SelectGetQuaranteenPalletLocation(int physicalStoreID, int storageType)
        {
            string query = String.Format("select * from PalletLocation pl Join Shelf s on pl.ShelfID=s.ID where pl.StorageTypeID = {0} AND s.StoreID = {1}", storageType, physicalStoreID);
            return query;
        }

        public static string SelectGetTransferPalletLocation()
        {
            string query = "select * from PalletLocation pl Join Shelf s on pl.ShelfID=s.ID where StorageTypeID = {0} and ShelfCode = 'Transfer'";
            return query;
        }

        public static string SelectLoadPreferredLocationsFor(int itemId)
        {
            string query = String.Format("select pl.* from ItemPrefferedLocation ipr join PalletLocation pl on pl.ID = ipr.PalletLocationID where ItemID = {0}", itemId);
            return query;
        }

        public static string SelectGetNonFree(int shelfID)
        {
            string query = String.Format("Select * from PalletLocation where PalletID is not Null and ShelfID = {0}",
                                         shelfID);
            return query;
        }

        public static string SelectGetFreeIn(int storageTypeID, int shelfid = 0)
        {
            string query = String.Format(@"select * from PalletLocation as pl join StorageType st on pl.StorageTypeID = st.ID  
                                        join Shelf s on s.ID = pl.ShelfID join PhysicalStore ps on ps.ID = s.StoreID  
                                        where  ps.ID = (select StoreID from Shelf where id ={0})  and pl.IsEnabled = 1 
                                      ", shelfid);
       
            return query;
        }

        public static string SelectCalculateAllVolumes(int itemID)
        {
            string query = String.Format("select pl.* from PalletLocation pl join ReceivePallet rp on pl.PalletID = rp.PalletID join ReceiveDoc rd on rd.ID = rp.ReceiveID  where pl.PalletID is not null and rd.ItemID = {0} ", itemID);
            return query;
        }
        public static string SelectGetLocationForItems(int itemID, string StorageTypePickFace, string StorageTypeQuaranteen)
        {
            string query = String.Format("select distinct (pl.ID),rd.BatchNo, rd.ExpDate as ExpiryDate , pl.* from ReceiveDoc rd join ReceivePallet rp on rd.ID = rp.ReceiveID join PalletLocation pl on rp.PalletID = pl.PalletID where rp.Balance > 0 and rd.ItemID = {0} and pl.StorageTypeID <> {1} and pl.StorageTypeID <> {2}", itemID, StorageTypePickFace, StorageTypeQuaranteen);
            return query;
        }
        public static string SelectGetLocationForItemsExclude(int excludePalletLocationID, int PalletID ,string StorageTypeQuaranteen, string StorageTypePickFace)
        {
            string query = String.Format("select distinct(pll.ID), pll.Label from PalletLocation pll join ReceivePallet rpl on pll.PalletID = rpl.PalletID join ReceiveDoc rdd on rpl.ReceiveID = rdd.ID join (select rd.* from ReceiveDoc rd join ReceivePallet rp on rd.ID = rp.ReceiveID where rp.PalletID = {1}) temp on rdd.ItemID = temp.ItemID and rdd.ExpDate = temp.ExpDate where pll.ID <> {0} and pll.StorageTypeID <> {2} and pll.StorageTypeID <> {3}", excludePalletLocationID, PalletID, StorageTypeQuaranteen, StorageTypePickFace);
            return query;
        }

        public static string SelectloadByPalletID(int p)
        {
            string query = String.Format("select * from PalletLocation where PalletID = {0}", p);
            return query;
        }

        public static string SelectLoadConsolidationOption(int itemID, string date)
        {
            string query = String.Format("select distinct(pl.ID) as ID, '(' + Cast (ISNULL(p.PalletNo,'-') as varchar) + ') ' + st.Prefix + ' ' + pl.Label as Label, p.PalletNo  from PalletLocation pl join StorageType st on pl.StorageTypeID = st.ID  Join Pallet p on p.ID = pl.PalletID join ReceivePallet rp on pl.PalletID = rp.PalletID join ReceiveDoc rd on rd.ID = rp.ReceiveID where (rd.ItemID = {0} and {1} and rp.Balance > 0)", itemID, date);
            return query;
        }

        public static string SelectLoadConsolidationOptionOther(string pfaceQuery)
        {
            string query = String.Format("select distinct(pl.ID) as ID, '(' + Cast (ISNULL(p.PalletNo,'-') as varchar) + ') ' + st.Prefix + ' ' + pl.Label as Label, p.PalletNo  from PalletLocation pl join StorageType st on pl.StorageTypeID = st.ID  Join Pallet p on p.ID = pl.PalletID  where {0}", pfaceQuery);
            return query;
        }

        public static string SelectGetAllOccupied()
        {
            string query = "select distinct (pl.ID) as ID, '(' + cast (ISNULL(p.PalletNo,'-') as varchar) + ') ' + st.Prefix + ' ' + pl.Label as Label, p.PalletNo  from PalletLocation pl join StorageType st on pl.StorageTypeID = st.ID  Join Pallet p on p.ID = pl.PalletID where ( pl.PalletID is not null ) ";
            return query;
        }

        public static string SelectGetLocationListView(string shelfID)
        {
            string query = String.Format("select plv.PalletLocation, vw.FullItemName,SUM(rp.Balance) / max(rd.QtyPerPack) as SKU, p.PalletNo  from PalletLocation pl join Pallet p on pl.PalletID = p.ID join vwPalletLocation plv on pl.ID = plv.ID join ReceivePallet rp on rp.PalletID = pl.PalletID join ReceiveDoc rd on rp.ReceiveID = rd.ID join vwGetAllItems vw on rd.ItemID = vw.ID where pl.ShelfID = {0} group by vw.FullItemName, plv.PalletLocation, PalletNo,pl.[Column], pl.[Row] order by pl.[Column], pl.[Row]", shelfID);
            return query;
        }
        public static string SelectLoadByPalletNumber(int p)
        {
            string query = String.Format("select * from PalletLocation where PalletID in (select ID from Pallet Where PalletNo={0})", p);
            return query;
        }
        public static string SelectLoadFirstOrDefault(int physicalStoreID, int storageTypeID)
        {
            string query = String.Format(
                "Select top(1) * from PalletLocation pl join Shelf sh on pl.ShelfID=sh.ID join PhysicalStore ps on sh.StoreID=ps.ID where ps.ID={0} and pl.StorageTypeID={1}",
                physicalStoreID, storageTypeID);
            return query;
        }
        public static string SelectGetDefaultPalletLocation(int physicalStoreID, string storageType)
        {
            string query = String.Format(@"Select Top 1 * from PalletLocation pl 
			join Shelf sh on pl.ShelfID= sh.ID
where StoreID = {0} and StorageTypeID = {1}", physicalStoreID, storageType);
            return query;
        }

        public static string SelectGetDraftReceives(int userID, int draftRecipt)
        { 
            string query = String.Format(
                            @"select  rd.ReceiptID
                            , rct.ID ReceiptNo
                            , rct.TransitTransferNo transferNo
                            , pot.Name POType
                            , rd.PhysicalStoreID physicalStoreID
                            , rct.WayBillNo WayBillNo
                            , rt.Name ReceiveType
                            , rct.DateOfEntry Date
                            , rd.ReceivedBy ReceivedBy
                            , rcs.Name recieveStatus
                            , rctInvoice.STVOrInvoiceNo
                            , s.CompanyName Supplier
                            , po.PONumber PONo
                            , rcs.Name StatusName
                            , rd.RefNo
                            , min(rd.Date)as Date
                            , rd.StoreID
                            , ps.PhysicalStoreTypeID WarehouseID
                            , rT.Name ReceiptType
                                                    From 
	                         ReceiveDoc rd join 
                             Receipt rct on rd.ReceiptID=rct.ID join ReceiptInvoice rctInvoice on rct.ReceiptInvoiceID=rctInvoice.ID
                             left join ReceiptInvoice ri on rct.ReceiptInvoiceID = ri.ID 
							 join PO po on po.ID=rctInvoice.POID join  Supplier s on s.ID=po.SupplierID
                             join Procurement.PurchaseOrderType pot on po.PurchaseType = pot.PurchaseOrderTypeID 
							 join ReceiveDocConfirmation rdc on rd.ID = rdc.ReceivedocID 
							 join ReceiptConfirmationStatus rcs on rdc.ReceiptConfirmationStatusID = rcs.ID 
							 join ReceivePallet rp on rd.ID=rp.ReceiveID 
							 join PalletLocation pl on rp.PalletLocationID=pl.ID 
							 join Shelf sh on sh.ID=pl.ShelfID 
							 join ReceiptType rT on rT.ID=rct.ReceiptTypeID 
							 join PhysicalStore ps on ps.ID=sh.StoreID
                        where
	                         rd.StoreID in (select StoreID from UserStore where UserID = {0} and CanAccess=1) 
                             and rd.ID in (select ReceiveDocID from ReceiveDocConfirmation where ReceiptConfirmationStatusID = {1}) 
                        Group by rd.PhysicalStoreID
						 , rct.ID
						 , rct.TransitTransferNo
						 , pot.Name
						 , rd.ReceiptID
						 , rct.WayBillNo
						 , rt.Name
						 , rd.ReceivedBy
						 , rcs.name
						 , rd.RefNo
						 , rd.StoreID
						 , rctInvoice.STVOrInvoiceNo
						 , po.PONumber
						 , ps.PhysicalStoreTypeID
						 , s.CompanyName
						 , rT.Name
						 , rcs.Name
						 , rct.DateOfEntry", userID, draftRecipt);
            return query;
        }

        public static string SelectGetReceivesForGRVPrinting(int userID, int priceConfirmed)
        {
            string query = String.Format(@"select rd.ReceiptID
                                            , Max(rcp.IDPrinted) IDPrinted
                                            , rd.RefNo RefNo
                                            , min(rd.Date)as Date
                                            , rd.StoreID
                                            , rdc.ReceiptConfirmationStatusID [Status]
                                            , rcs.Name
                                            , {1}
                                            , rcs.Name as CurrentStatus 
                                            , po.PONumber PONo
                                            , ri.STVOrInvoiceNo
                                            , s.CompanyName SupplierName
                                            , vwa.ModeName 
                                            , vwa.AccountName
                                            , vwa.SubAccountName
                                            , vwa.ActivityName
                                            , ReceiptType.Name ReceiptType
                                            , rdc.PriceConfirmedByUserID confirmedBy
                                            , rd.ConfirmedDateTime confirmedDate
                                            , rdc.UnitCostCalculatedByUserID calculatedBy

                                            from ReceiveDoc rd 
                                            join  ReceiveDocConfirmation rdc on rd.ID = rdc.ReceivedocID 
                                            join  ReceiptConfirmationStatus rcs on rdc.ReceiptConfirmationStatusID = rcs.ID
                                            join Receipt rt on rt.ID = rd.ReceiptID 
                                            join ReceiptType on rt.ReceiptTypeID = ReceiptType.ID
                                            join ReceiptInvoice ri on rt.ReceiptInvoiceID = ri.ID 
                                            join PO on po.ID=ri.POID 
                                            Join Supplier s on s.ID = rd.SupplierID 
                                            join ReceiptConfirmationPrintOut rcp on rcp.ReceiptID = rt.ID 
                                            join vwAccounts vwa on rd.StoreID = vwa.ActivityID
                                            where rd.StoreID in (select StoreID from UserStore where UserID = {0} and CanAccess=1) 
                                                and rd.ReturnedStock<>1 
                                                and  rd.ID in (select ReceiveDocID from ReceiveDocConfirmation where ReceiptConfirmationStatusID = {1}) 
                                            group by rd.ReceiptID
		                                            , rd.RefNo
		                                            , rd.StoreID
		                                            , ReceiptConfirmationStatusID
		                                            , rcs.Name
		                                            , ri.STVOrInvoiceNo
		                                            , po.PONumber
		                                            , s.CompanyName
		                                            , vwa.ModeName
		                                            , vwa.AccountName
		                                            , vwa.SubAccountName
		                                            , vwa.ActivityName
                                                    , rdc.PriceConfirmedByUserID
                                                    , rd.ConfirmedDateTime
                                                    , rdc.UnitCostCalculatedByUserID
		                                            , ReceiptType.Name", userID, priceConfirmed);
                return query;
        }

        public static string SelectPrintingModeGetReceivesForGRVPrinting(int userID, int priceConfirmed)
        {
            string query = String.Format(@"select rd.ReceiptID
                                            , rd.RefNo
                                            , Max(rcp.IDPrinted) IDPrinted
                                            , min(rd.Date)as Date
                                            , rd.StoreID
                                            , rdc.ReceiptConfirmationStatusID [Status]
                                            , s.CompanyName SupplierName
                                            , rcs.Name
                                            , po.PONumber
                                            , {1} as CurrentStatus
                                            , 'SRM' + po.PONumber PONo
                                            , 'SRM' + ri.STVOrInvoiceNo STVOrInvoiceNo
                                            , vwa.ModeName
                                            , vwa.AccountName
                                            , vwa.SubAccountName
                                            , vwa.ActivityName
                                            , rtt.Name ReceiveType
                                            , rcs.Name ReceiveStatus
                                            , rdc.PriceConfirmedByUserID confirmedBy
                                            , rd.ConfirmedDateTime confirmedDate
                                            , rdc.UnitCostCalculatedByUserID calculatedBy
                                            --, rd.EurDate ReceivedTime
                                            --, rd.ReceivedBy
                                            --, rd.ConfirmedDateTime ConfirmedTime
                                            --, u.FullName ConfirmedBy
                                            from ReceiveDoc rd 
                                            join ReceiveDocConfirmation rdc on rd.ID = rdc.ReceivedocID 
                                            join receiptConfirmationStatus rcs on rdc.ReceiptConfirmationStatusID = rcs.ID 
                                            join Receipt rt on rt.ID = rd.ReceiptID 
                                            join ReceiptInvoice ri on rt.ReceiptInvoiceID = ri.ID
                                            join PO on po.ID=ri.POID 
                                            join supplier s on rd.supplierid = s.id
                                            Join ReceiptConfirmationPrintOut rcp on rcp.ReceiptID = rt.ID 
                                            join vwAccounts vwa on vwa.ActivityID = rd.StoreID
                                            join ReceiptType rtt on rt.ReceiptTypeID = rtt.ID
                                            left join [User] u on rd.ConfirmedByUserID = u.ID
                                            where rd.StoreID in (select StoreID from UserStore where UserID = {0} and CanAccess=1) and (rd.ReturnedStock=1) and rd.ID in (select ReceiveDocID from ReceiveDocConfirmation where ReceiptConfirmationStatusID = {1})  
                                            group by rd.ReceiptID,rd.RefNo,rd.StoreID,ReceiptConfirmationStatusID,rcs.Name,ri.STVOrInvoiceNo,po.PONumber
                                            , vwa.ModeName
                                            , vwa.AccountName
                                            , vwa.SubAccountName
                                            , vwa.ActivityName
                                            , rtt.Name
                                            , rcs.Name
                                            , s.CompanyName
                                            , rdc.PriceConfirmedByUserID
                                            , rd.ConfirmedDateTime
                                            , rdc.UnitCostCalculatedByUserID
                                            --, rd.EurDate 
                                            , rd.ReceivedBy
                                            --, rd.ConfirmedDateTime 
                                            --, u.FullName ", userID, priceConfirmed);
            return query;
        }

        public static string SelectGetReceivesForGRVPrintingElse(int userID, int priceConfirmed)
        {
            string query = String.Format(@"select rd.ReceiptID
                                        , rd.RefNo
                                        , rd.RefNo IDPrinted
                                        , min(rd.Date)as Date
                                        , rd.StoreID
                                        , rdc.ReceiptConfirmationStatusID [Status]
                                        , rcs.Name
                                        , po.PONumber PONo
                                        , ri.STVOrInvoiceNo
                                        , s.CompanyName SupplierName
                                        , vwa.ModeName 
                                        , vwa.AccountName
                                        , vwa.SubAccountName
                                        , vwa.ActivityName
                                        , rdc.PriceConfirmedByUserID confirmedBy
                                        , rd.ConfirmedDateTime confirmedDate
                                        , rdc.UnitCostCalculatedByUserID calculatedBy
                                        , ReceiptType.Name ReceiptType
                                        , {1} as CurrentStatus 
                                        from ReceiveDoc rd 
                                        join ReceiveDocConfirmation rdc on rd.ID = rdc.ReceivedocID 
                                        join receiptConfirmationStatus rcs on rdc.ReceiptConfirmationStatusID = rcs.ID 
                                        left join Receipt rt on rt.ID = rd.ReceiptID 
                                        left join ReceiptType on rt.ReceiptTypeID = ReceiptType.ID
                                        left join ReceiptInvoice ri on rt.ReceiptInvoiceID = ri.ID 
                                        left join PO on po.ID=ri.POID 
                                        left Join Supplier s on s.ID = rd.SupplierID 
                                        left join ReceiptConfirmationPrintOut rcp on rcp.ReceiptID = rt.ID 
                                        left join vwAccounts vwa on rd.StoreID = vwa.ActivityID
                                        where rd.StoreID in (select StoreID from UserStore where UserID = {0} and CanAccess=1) and (rd.DeliveryNote=1) and rd.ID in (select ReceiveDocID from ReceiveDocConfirmation where ReceiptConfirmationStatusID = {1}) 
                                         group by rd.ReceiptID
	                                         , rd.RefNo
	                                         , rd.StoreID
	                                         , ReceiptConfirmationStatusID
	                                        , rcs.Name
	                                        , po.PONumber
	                                        , ri.STVOrInvoiceNo
	                                        , s.CompanyName 
	                                        , vwa.ModeName 
	                                        , vwa.AccountName
	                                        , vwa.SubAccountName
	                                        , vwa.ActivityName
                                            , rdc.PriceConfirmedByUserID
                                            , rd.ConfirmedDateTime
                                            , rdc.UnitCostCalculatedByUserID
	                                        , ReceiptType.Name ", userID, priceConfirmed);
            return query;
        }

        public static string SelectGetReceivesForGRVConfirmation(int userID, int grvPrinted)
        {
            string query = String.Format(
                @"select rd.ReceiptID
                    , rcp.ID
                    , rcp.Reason
                    , +Max(rcp.IDPrinted) IDPrinted
                    , (select Max(IDPrinted) from ReceiptConfirmationPrintout t where Reason='PGRV' and t.ReceiptID = rd.ReceiptID ) as PGRV
                    , rd.RefNo, cast(rcp.VoidRequest as int) as VoidRequest
                    , min(rd.Date)as Date
                    , rd.StoreID
                    , rdc.ReceiptConfirmationStatusID [Status]
                    , rcs.Name ReceiptStatus
                    , 6 as CurrentStatus
                    , po.PONumber PONo
                    , rT.Name ReceiptType
                    , CASE WHEN rcp.isreprintof IS NULL THEN CAST (0 as bit) ELSE cast(1 as bit)  End		isreprint
                    , CASE WHEN  (SELECT Count(*) 
                                                   FROM 
                                                   ReceiptConfirmationPrintout lg WHERE lg.IsReprintOf = rcp.id ) > 0  THEN 
                                                   CAST (1 as bit) else  CAST (0 as bit) 
												   End
                                                   hasreprint

                    ,  CASE WHEN rcp.isreprintof IS NULL THEN '' + RIGHT('00000' + Cast (+Max(rcp.IDPrinted) AS NVARCHAR), 5) 
											
												 ELSE CASE WHEN (SELECT Count(*) 
                                                   FROM 
                                                   ReceiptConfirmationPrintout lg WHERE lg.id = rcp.isreprintof ) > 0  THEN 
                                                   'Re-'  + RIGHT('00000' + Cast (+Max(rcp.IDPrinted) AS NVARCHAR), 5) 
												    + '(' + (Select RIGHT('00000' + Cast (+Max(IDPrinted) AS NVARCHAR), 5) +')'
													 From ReceiptConfirmationPrintout Where ID = rcp.IsReprintOf
													) 
												   End
                                                   END 
                                                  as IDPrinteds 
                    , s.CompanyName SupplierName
                    , vwp.ClusterName
                    , vwp.WarehouseName
                    , vwp.PhysicalStoreName
                    , vwa.ModeName 
                    , vwa.AccountName
                    , vwa.SubAccountName
                    , vwa.ActivityName
                    , rdc.PriceConfirmedByUserID confirmedBy
                
                    from ReceiveDoc rd 
                    join ReceiveDocConfirmation rdc on rd.ID = rdc.ReceivedocID 
                    join receiptConfirmationStatus rcs on rdc.ReceiptConfirmationStatusID = rcs.ID  
                    
                    join ReceiptConfirmationPrintout rcp on rd.ReceiptID=rcp.ReceiptID 
                    join Receipt rct on rd.ReceiptID=rct.ID
                    join ReceiptType rT on rct.ReceiptTypeID=rT.ID
                    join PhysicalStore ps on rd.PhysicalStoreID = ps.ID and ps.IsActive=1  and rd.InventoryPeriodID = ps.CurrentInventoryPeriodID
                    left join ReceiptInvoice ri on rct.ReceiptInvoiceID = ri.ID 
                    left join PO on po.ID=ri.POID 
                    left Join Supplier s on s.ID = rd.SupplierID 
                    left join vwPhysicalStore vwp on rd.PhysicalStoreID = vwp.PhysicalStoreID
                    left join vwAccounts vwa on rd.StoreID = vwa.ActivityID
                    where rd.StoreID in (select StoreID from UserStore where UserID = {0} and CanAccess=1) and rcp.Reason in ('GRV','IGRV','SRM')
                    and rd.ID in (select ReceiveDocID from ReceiveDocConfirmation where ReceiptConfirmationStatusID = {1}) 
                    group by rd.ReceiptID
                    , rd.RefNo
                    , rcp.Reason
                    , rd.StoreID
                    , ReceiptConfirmationStatusID
                    , rcs.Name
                    , rcp.VoidRequest
                    , rcp.ID
                    , rT.Name
                    , s.CompanyName 
	                    , vwp.ClusterName
	                    , vwp.WarehouseName
	                    , vwp.PhysicalStoreName
                        , vwa.ModeName 
	                    , vwa.AccountName
	                    , vwa.SubAccountName
	                    , vwa.ActivityName
                        , rdc.PriceConfirmedByUserID
	                    , po.PONumber
                        , rcp.IsReprintOf", userID, grvPrinted);
              
            return query;
        }

        public static string SelectGetReceivesForUnitCostConfirmation(int userID, int grnfPrinted)
        {
            string query = String.Format(@"select rd.ReceiptID, 
	                                               rd.RefNo, min(rd.Date)as Date,rd.StoreID, rdc.ReceiptConfirmationStatusID [Status],{1} CurrentStatus,rcs.Name
                                            From 
	                                             ReceiveDoc rd join 
	                                             ReceiveDocConfirmation rdc on rd.ID = rdc.ReceivedocID join 
	                                             ReceiptConfirmationStatus rcs on rdc.ReceiptConfirmationStatusID = rcs.ID 
                                            where
	                                              rd.StoreID in (select StoreID from UserStore where UserID = {0} and CanAccess=1) 
	                                              and rd.ID in (select ReceiveDocID from ReceiveDocConfirmation where ReceiptConfirmationStatusID = {1})
                                            Group by rd.ReceiptID,RefNo,StoreID,ReceiptConfirmationStatusID,rcs.Name", userID, grnfPrinted);
            return query;
        }

        public static string SelectGetReceivesForMovingAverage(int userID, int priceConfirmed)
        {
            string query = String.Format(@"select rd.ReceiptID, 
	                                               rd.RefNo, min(rd.Date)as Date,rd.StoreID, rdc.ReceiptConfirmationStatusID [Status],{1} CurrentStatus,rcs.Name
                                            From 
	                                             ReceiveDoc rd join 
	                                             ReceiveDocConfirmation rdc on rd.ID = rdc.ReceivedocID join 
	                                             ReceiptConfirmationStatus rcs on rdc.ReceiptConfirmationStatusID = rcs.ID 
                                            where
	                                              rd.StoreID in (select StoreID from UserStore where UserID = {0} and CanAccess=1) 
	                                              and rd.ID in (select ReceiveDocID from ReceiveDocConfirmation where ReceiptConfirmationStatusID = {1})
                                            Group by rd.ReceiptID,RefNo,StoreID,ReceiptConfirmationStatusID,rcs.Name", userID, priceConfirmed);
            return query;
        }

        public static string SelectGetReceivesForUnitCostApproval(int userID, int priceCalculated)
        {
            string query = String.Format(@"select ri.ID,rt.ID ReceiptID, 
	                                                   MAX(rcp.IDPrinted) RefNo, ri.STVOrInvoiceNo InvoiceNumber,Max(rd.Date)as Date,rd.StoreID,s.CompanyName Supplier
                                                From 
	                                                 ReceiveDoc rd join 
	                                                 ReceiveDocConfirmation rdc on rd.ID = rdc.ReceivedocID join 
	                                                 ReceiptConfirmationStatus rcs on rdc.ReceiptConfirmationStatusID = rcs.ID Join
	                                                 Receipt rt on rt.ID = rd.ReceiptID join
                                                     ReceiptInvoice ri on rt.ReceiptInvoiceID = ri.ID join
                                                     Supplier s on s.ID = rd.SupplierID join
                                                     ReceiptConfirmationPrintOut rcp on rcp.ReceiptID = rt.ID 
                                                where
	                                                  rd.StoreID in (select StoreID from UserStore where UserID = {0} and CanAccess=1) 
	                                                  and rcp.Reason = 'PGRV' and rd.ID in (select ReceiveDocID from ReceiveDocConfirmation where ReceiptConfirmationStatusID = {1}) 
                                              Group by ri.ID,rt.ID,ri.STVOrInvoiceNo,rd.StoreID,s.CompanyName", userID, priceCalculated);
            return query;
        }

        public static string SelectGetReceivesForUnitCostCalculation(int userID, int grnfPrint)
        {
            string query = String.Format(@"select ri.ID,rt.ID ReceiptID,MAX(rcp.IDPrinted) RefNo,ri.STVOrInvoiceNo InvoiceNumber,Max(rd.Date)as Date,rd.StoreID,s.CompanyName Supplier
                                                From 
	                                                 ReceiveDoc rd join 
	                                                 ReceiveDocConfirmation rdc on rd.ID = rdc.ReceivedocID join 
	                                                 ReceiptConfirmationStatus rcs on rdc.ReceiptConfirmationStatusID = rcs.ID Join
	                                                 Receipt rt on rt.ID = rd.ReceiptID join
                                                     ReceiptInvoice ri on rt.ReceiptInvoiceID = ri.ID join
                                                     Supplier s on s.ID = rd.SupplierID Join
                                                     ReceiptConfirmationPrintOut rcp on rcp.ReceiptID = rt.ID
                                                where
	                                                  rd.StoreID in (select StoreID from UserStore where UserID = {0} and CanAccess=1) 
	                                                  and rd.ID in (select ReceiveDocID from ReceiveDocConfirmation where ReceiptConfirmationStatusID = {1}) 
                                                Group by ri.ID,rt.ID,ri.STVOrInvoiceNo,rd.StoreID,s.CompanyName", userID, grnfPrint);
            return query;
        }

        public static string SelectGetReceivesForUnitCostCalculationElse(int userID, int grnfPrinted)
        {
            string query = String.Format(@"select rd.ReceiptID, 
	                                                   Max(rcp.IDPrinted) RefNo, ri.STVOrInvoiceNo InvoiceNumber, Max(rd.Date)as Date,rd.StoreID,rd.SupplierID, rdc.ReceiptConfirmationStatusID [Status],rcs.Name,{1} CurrentStatus
                                                From 
	                                                 ReceiveDoc rd join 
	                                                 ReceiveDocConfirmation rdc on rd.ID = rdc.ReceivedocID join 
	                                                 ReceiptConfirmationStatus rcs on rdc.ReceiptConfirmationStatusID = rcs.ID join
                                                     Receipt r on r.ID = rd.ReceiptID Join
                                                     ReceiptConfirmationPrintOut rcp on rcp.ReceiptID = r.ID join
                                                     ReceiptInvoice ri on r.ReceiptInvoiceID = ri.ID 
                                                where
	                                                  rd.StoreID in (select StoreID from UserStore where UserID = {0} and CanAccess=1) 
	                                                  and rcp.Reason = 'PGRV' and rd.ID in (select ReceiveDocID from ReceiveDocConfirmation where ReceiptConfirmationStatusID = {1}) 
                                                Group by rd.ReceiptID,rd.RefNo,rd.StoreID,ReceiptConfirmationStatusID,rcs.Name,rd.SupplierID,rcp.IDPrinted,ri.STVOrInvoiceNo
                                                    union 
                                                Select rd.ReceiptID,rd.RefNo,'Delivery Note',MIN(rd.Date) as Date,rd.StoreID,rd.SupplierID,{1} [Status],'DeliveryNote' Name,{1} as CurrentStatus  
                                                From ReceiveDoc rd join 
	                                                 ReceiveDocConfirmation rdc on rd.ID = rdc.ReceivedocID join 
	                                                 ReceiptConfirmationStatus rcs on rdc.ReceiptConfirmationStatusID = rcs.ID join
                                                     Receipt r on r.ID = rd.ReceiptID Join
                                                     ReceiptConfirmationPrintOut rcp on rcp.ReceiptID = r.ID join
                                                     ReceiptInvoice ri on r.ReceiptInvoiceID = ri.ID                                                      
                                                where rd.DeliveryNote = 1 and rcp.Reason = 'PGRV' and rd.PricePerPack is null and rd.Confirmed =1 
                                                group by  rd.ReceiptID,rd.RefNo,rd.StoreID,rd.SupplierID,ri.STVOrInvoiceNo", userID, grnfPrinted);
            return query;
        }

        public static string SelectGetReceivesForInvoiceConfirmation(int userID, int receiveQuantityConfirmed)
        {
            string query = String.Format(@"select ri.ID, ri.STVOrInvoiceNo InvoiceNumber,Max(rd.Date)as Date,rd.StoreID,s.CompanyName Supplier,ri.WayBillNo WayBillNo,ri.InsurancePolicyNo InsuranceNo,ri.TransitServiceCharge TransitNo,ri.TransitTransferNo TranferNo
                                                From 
	                                                 ReceiveDoc rd join 
	                                                 ReceiveDocConfirmation rdc on rd.ID = rdc.ReceivedocID join 
	                                                 ReceiptConfirmationStatus rcs on rdc.ReceiptConfirmationStatusID = rcs.ID Join
	                                                 Receipt rt on rt.ID = rd.ReceiptID join
                                                     ReceiptInvoice ri on rt.ReceiptInvoiceID = ri.ID join
                                                     Supplier s on s.ID = rd.SupplierID
                                                where
	                                                  rd.StoreID in (select StoreID from UserStore where UserID = {0} and CanAccess=1) 
	                                                  and rd.ID in (select ReceiveDocID from ReceiveDocConfirmation where ReceiptConfirmationStatusID = {1}) 
                                                Group by ri.ID,ri.STVOrInvoiceNo,rd.StoreID,s.CompanyName,ri.WayBillNo,ri.InsurancePolicyNo ,ri.TransitServiceCharge ,ri.TransitTransferNo ", userID, receiveQuantityConfirmed);
            return query;
        }
        public static string SelectGetReceivesForInvoiceConfirmationElse(int userID, int receiveQuantityConfirmed)
        {
            string query = string.Format(@"select rd.ReceiptID, 
	                                                   rd.RefNo, min(rd.Date)as Date,rd.StoreID,rd.SupplierID, rdc.ReceiptConfirmationStatusID [Status],rcs.Name,{1} CurrentStatus
                                                From 
	                                                 ReceiveDoc rd join 
	                                                 ReceiveDocConfirmation rdc on rd.ID = rdc.ReceivedocID join 
	                                                 ReceiptConfirmationStatus rcs on rdc.ReceiptConfirmationStatusID = rcs.ID 
                                                where
	                                                  rd.StoreID in (select StoreID from UserStore where UserID = {0} and CanAccess=1) 
	                                                  and rd.ID in (select ReceiveDocID from ReceiveDocConfirmation where ReceiptConfirmationStatusID = {1}) 
                                                Group by rd.ReceiptID,RefNo,StoreID,ReceiptConfirmationStatusID,rcs.Name,rd.SupplierID
                                           union select rd.ReceiptID,rd.RefNo,MIN(rd.Date) as Date,rd.StoreID,rd.SupplierID,{1} [Status],'DeliveryNote' Name,{1} as CurrentStatus  from ReceiveDoc rd where rd.DeliveryNote = 1 and rd.PricePerPack is null and rd.Confirmed =1 group by  rd.ReceiptID,RefNo,StoreID,SupplierID", userID, receiveQuantityConfirmed);
            return query;
        }

        public static string SelectLoadFixedStoragePallets(string selectedRackID, string bulkStore, string pickFace)
        {
            string query = String.Format("select * from PalletLocation where ShelfID = {0} and StorageTypeID <> {1} and StorageTypeID <> {2}", selectedRackID, bulkStore, pickFace);
            return query;
        }

        public static string SelectPalletLocationsOnTheSameStore(int palletid)
        {
            string query = string.Format(@" select s.ID shelfid,s.ShelfCode,st.StorageTypeName,st.ID StorageTypeID,pl.Label,pl.ID palletlocationid
                                            from PalletLocation pl 
                                                    Join Shelf s on pl.ShelfID=s.ID 
		                                            Join StorageType st on pl.StorageTypeID = st.ID
                                            where   pl.StorageTypeID in (select ID from StorageType where StorageTypeCode not in ('SA')) and
                                                    StoreID =(select StoreID from PalletLocation pl Join Shelf s on pl.ShelfID=s.ID where pl.PalletID={0}) and
                                                    IsEnabled=1 and palletid is not null", palletid);
            return query;
        }

        public static string selectpalletidbyPalletLocation(int palletlocationid)
        {
            string query = string.Format("select palletid from palletlocation pl where pl.ID={0} and palletid is not null", palletlocationid);
            return query;
        }

        public static string selectstoreIDbyPalletLocationID(int palletlocationid)
        {
            string query = string.Format("select StorageTypeID from palletlocation pl join storagetype st on pl.StorageTypeID=st.ID where pl.ID={0}", palletlocationid);
            return query;
        }
    }
}
