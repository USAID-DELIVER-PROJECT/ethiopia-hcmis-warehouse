using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class Inventory
    {
        [SelectQuery]
        public static string SelectGetOverageShortageReport(int activityId, int warehouseId, string periodIds)
        {
            string query =
                String.Format(
                    @"select distinct inv.*
                                , itm.StockCode
                                , itm.[Name] CommodityTypeName
                                , itm.FullItemName
                                , iu.[Text] Unit
                                , m.Name [ManufacturerName]
                                , acct.ActivityName
                                , acct.SubAccountName
                                , acct.AccountName
                                , p.PhysicalStoreName
                                , p.WarehouseName
                                , p.ClusterName
                                , inv.ExpiryDate
                                , inv.SystemTotal
                                , inv.InvTotal
                                , inv.SystemTotal * (case when rd.UnitCost is Null then inv.UnitCost else rd.UnitCost end)  as SystemTotalCost
                                , inv.InvTotal * (case when rd.UnitCost is Null then inv.UnitCost else rd.UnitCost end)  InvTotalCost
                                , (case when rd.UnitCost is Null then inv.UnitCost else rd.UnitCost end)  Cost
                                , case when inv.InvDifference > 0 then inv.InvDifference else NULL end as Shortage
                                , case when inv.InvDifference < 0 then -inv.InvDifference else NULL end as Overage
                                , case when inv.InvDifference > 0 then inv.InvDifference * (case when rd.UnitCost is Null then inv.UnitCost else rd.UnitCost end)  else NULL end as ShortageCost
                                , case when inv.InvDifference < 0 then -inv.InvDifference * (case when rd.UnitCost is Null then inv.UnitCost else rd.UnitCost end)  else NULL end as OverageCost
                                from 
                                ( SELECT 
                                        inventoryperiodid
		                                , physicalstoreid
		                                , activityid
		                                , itemid
		                                , unitid
		                                , manufacturerid
		                                , expirydate
		                                , Sum(Isnull(systemsoundquantity,0) + Isnull(systemexpiredquantity,0)) SystemTotal
		                                , Sum(Isnull(inventorysoundquantity,0)+ Isnull(inventoryexpiredquantity,0)) InvTotal
		                                , Sum(Isnull(systemsoundquantity,0) + Isnull(systemexpiredquantity,0) - (Isnull(inventorysoundquantity,0)+ Isnull(inventoryexpiredquantity,0))) InvDifference
		                                , receivedocid
		                                , CASE WHEN Sum(Isnull(inventoryexpiredquantity,0)) > 0 THEN 'Expired' ELSE 'Sound' END Remark
		                                , cost UnitCost 
		                                FROM inventory i
										Join PhysicalStore ps on i.PhysicalStoreID = ps.ID
										Join Warehouse w on ps.PhysicalStoreTypeID = w.ID
		                                Where ActivityID = {0} and InventoryPeriodID in ({1}) and w.ID = {2}
                                    AND ((Isnull(systemsoundquantity,0) + Isnull(systemexpiredquantity,0)) > 0 
	                                OR (Isnull(inventorysoundquantity,0)+ Isnull(inventoryexpiredquantity,0)) > 0)
                                    GROUP BY inventoryperiodid
			                                , physicalstoreid
			                                , activityid
			                                , itemid
			                                , cost
			                                , unitid
			                                , manufacturerid
			                                , expirydate
			                                , receivedocid
  
                                    UNION 

                                    SELECT 
                                        inventoryperiodid 
                                        , physicalstoreid 
                                        , activityid 
                                        , itemid 
                                        , unitid 
                                        , manufacturerid 
                                        , expirydate 
                                        , Sum(Isnull(systemdamagedquantity,0)) SystemTotal
                                        , Sum(Isnull(inventorydamagedquantity,0)) InvTotal
                                        , Sum(Isnull(Isnull(systemdamagedquantity,0) - Isnull(inventorydamagedquantity,0),0)) InvDifference
                                        , damagedreceivedocid 
                                        , 'Damaged' AS Remark 
                                        , cost UnitCost 
                                    FROM inventory i
									Join PhysicalStore ps on i.PhysicalStoreID = ps.ID
									Join Warehouse w on ps.PhysicalStoreTypeID = w.ID
                                    Where ActivityID = {0} and InventoryPeriodID in({1}) and w.ID = {2}
                                    AND (Isnull(systemdamagedquantity,0) > 0 
	                                OR Isnull(inventorydamagedquantity,0) > 0)
                                    GROUP BY inventoryperiodid
	                                , physicalstoreid
	                                , activityid
	                                , itemid
	                                , cost
	                                , unitid
	                                , manufacturerid
	                                , expirydate
	                                , damagedreceivedocid
                                ) as inv 
                                Left Join ReceiveDoc rd on rd.ID = inv.ReceiveDocID 
                                Join vwGetAllItems itm on inv.ItemID=itm.ID 
                                Join ItemUnit iu on inv.UnitID=iu.ID 
                                Join Manufacturer m on inv.ManufacturerID=m.ID 
                                Join vwAccounts acct on inv.ActivityID=acct.ActivityID 
                                Join vwPallet p on inv.PhysicalStoreID=p.PhyicalStoreID",
                    activityId,
                    periodIds,
                    warehouseId);
            return query;
        }

        [SelectQuery]
        public static string SelectGetOverageShortageAggregateReport(int activityId, int warehouseId, string periodIds)
        {
            string query =
                String.Format(@"select distinct         itm.StockCode
                        , itm.[Name] CommodityTypeName
                        , itm.FullItemName
                        , iu.[Text] Unit
                        , m.Name [ManufacturerName]
                        , acct.ActivityName
                        , acct.SubAccountName
                        , acct.AccountName
                        , p.PhysicalStoreName
                        , p.WarehouseName
                        , p.ClusterName
                        , ' ' as ExpiryDate--inv.ExpiryDate
                        , ( inv.SystemTotal) SystemTotal
                        , ( inv.InvTotal) InvTotal
                        , ( inv.SystemTotal) * inv.UnitCost  as SystemTotalCost
                        , ( inv.InvTotal) * inv.UnitCost  InvTotalCost
                        , inv.UnitCost  Cost
                        , ( case when inv.InvDifference > 0 then inv.InvDifference else 0 end) as Shortage
                        , ( case when inv.InvDifference < 0 then -inv.InvDifference else 0 end) as Overage
                        , ( case when inv.InvDifference > 0 then inv.InvDifference * inv.UnitCost else 0 end) as ShortageCost
                        , ( case when inv.InvDifference < 0 then -inv.InvDifference * inv.UnitCost  else 0 end) as OverageCost
                        , inv.Remark
						from 
                        ( 
							SELECT distinct
								i.inventoryperiodid
								, i.physicalstoreid
								, activityid
								, i.itemid
								, i.unitid
								, i.manufacturerid
								, Sum(Isnull(systemsoundquantity,0)  + Isnull(systemexpiredquantity,0)) SystemTotal
								, Sum(Isnull(inventorysoundquantity,0) + Isnull(inventoryexpiredquantity,0)) InvTotal
								, Sum(Isnull(systemsoundquantity,0) + Isnull(systemexpiredquantity,0) - (Isnull(inventorysoundquantity,0)+ Isnull(inventoryexpiredquantity,0))) InvDifference
								, CASE WHEN Sum(Isnull(inventoryexpiredquantity,0)) > 0 THEN 'Expired' ELSE 'Sound' END Remark
								, CASE WHEN r.unitcost is null then i.cost else r.UnitCost end UnitCost 
								FROM inventory i
								Left Join ReceiveDoc r on i.ReceiveDocID = r.id
								Join PhysicalStore ps on i.PhysicalStoreID = ps.ID
								Join Warehouse w on ps.PhysicalStoreTypeID = w.ID
								Where ActivityID = {0} and i.InventoryPeriodID in ({1}) and w.ID = {2}
							AND ((Isnull(systemsoundquantity,0) + Isnull(systemexpiredquantity,0)) > 0 
							OR (Isnull(inventorysoundquantity,0)+ Isnull(inventoryexpiredquantity,0)) > 0)
							GROUP BY i.inventoryperiodid
									, i.physicalstoreid
									, activityid
									, i.itemid
									, i.unitid
									, i.manufacturerid											
									, CASE WHEN r.unitcost is null then i.cost else r.UnitCost end
  
							UNION 

							SELECT distinct
								i.inventoryperiodid 
								, i.physicalstoreid 
								, i.activityid 
								, i.itemid 
								, i.unitid 
								, i.manufacturerid 
								, Sum(Isnull(systemdamagedquantity,0)) SystemTotal
								, Sum(Isnull(inventorydamagedquantity,0)) InvTotal
								, Sum(Isnull(Isnull(systemdamagedquantity,0) - Isnull(inventorydamagedquantity,0),0)) InvDifference
								, 'Damaged' AS Remark 
								, CASE WHEN r.unitcost is null then i.cost else r.UnitCost end UnitCost 
							FROM inventory i
							Left Join ReceiveDoc r on i.damagedreceivedocid = r.id
							Join PhysicalStore ps on i.PhysicalStoreID = ps.ID
							Join Warehouse w on ps.PhysicalStoreTypeID = w.ID
							Where i.ActivityID = {0} and i.InventoryPeriodID in({1}) and w.ID = {2}
							AND (Isnull(systemdamagedquantity,0) > 0 
							OR Isnull(inventorydamagedquantity,0) > 0)
							GROUP BY i.inventoryperiodid
							, i.physicalstoreid
							, i.activityid
							, i.itemid
							, i.unitid
							, i.manufacturerid
							, CASE WHEN r.unitcost is null then i.cost else r.UnitCost end /**/
                        ) as inv                                 
						Join vwGetAllItems itm on inv.ItemID=itm.ID 
                        Join ItemUnit iu on inv.UnitID=iu.ID 
                        Join Manufacturer m on inv.ManufacturerID=m.ID 
                        Join vwAccounts acct on inv.ActivityID=acct.ActivityID 
                        Join vwPallet p on inv.PhysicalStoreID=p.PhyicalStoreID
						Group by 
						 itm.[Name]
						 , itm.StockCode
                        , itm.FullItemName
                        , iu.[Text] 
                        , m.Name
                        , acct.ActivityName
                        , acct.SubAccountName
                        , acct.AccountName
                        , p.PhysicalStoreName
                        , p.WarehouseName
                        , p.ClusterName
						, inv.UnitCost
						, inv.Remark
						, ( inv.SystemTotal) 
                        , ( inv.InvTotal)
                        , inv.InvDifference",
                    activityId,
                    periodIds, 
                    warehouseId);
            return query;
        }


        [SelectQuery]
        public static string SelectSOHForFinance(int activityId, int periodId)
        {
            string query = String.Format(@"select ROW_NUMBER() OVER (Order by vw.FullItemName) [RowNo],
		                                                i.ItemID
		                                                ,i.UnitID
		                                                ,i.manufacturerID
		                                                ,i.ActivityID
		                                                ,vw.FullItemName
                                                        ,vw.StockCode
		                                                ,iu.Text UnitName
		                                                ,m.Name ManufacturerName
		                                                ,i.ExpiryDate
		                                                ,a.AccountName
		                                                ,a.SubAccountName
		                                                ,a.ActivityName
		                                                ,PhysicalStoreID
		                                                ,PhysicalStoreName
		                                                ,WarehouseID
		                                                ,WarehouseName
		                                                ,ClusterName
		                                                ,ClusterID
                                                        ,vw.Name [CommodityTypeName]
		                                                ,sum(isNull(systemSoundQuantity,0) + isNull(systemDamagedQuantity,0) + isNull(systemExpiredQuantity,0)) Quantity
		                                                ,Cost UnitCost
                                                        ,Margin Margin
		                                                ,sum(isNull(systemSoundQuantity,0) + isNull(systemDamagedQuantity,0) + isNull(systemExpiredQuantity,0)) * Cost TotalCost		
		                                                ,Case when (systemDamagedQuantity>0 and SystemDamagedQuantity is not null) then 'Damaged' else Case when (systemExpiredQuantity>0 and SystemExpiredQuantity is not null) then 'Expired' else '' end end remark  
                                                From Inventory i 
		                                                join vwGetAllItems vw on vw.ID = i.ItemID
		                                                join itemunit iu on iu.ID = i.unitID
		                                                join manufacturer m on m.ID = i.ManufacturerID
		                                                join vwAccounts a on a.activityID = i.activityID
		                                                Join (select distinct phyicalStoreID,WarehouseID,WarehouseName,PhysicalStoreName,ClusterID,ClusterName from vwPallet) pl on pl.PhyicalStoreID = i.PhysicalStoreID
                                                where i.ActivityId={0} and InventoryPeriodID = {1}
                                                Group by  i.ItemID,i.UnitID,i.manufacturerID,i.ActivityID
			                                                ,vw.FullItemName,iu.Text,m.Name,a.AccountName
			                                                ,a.SubAccountName,a.ActivityName,i.Cost,i.Margin,a.AccountName
			                                                ,a.SubAccountName,a.ActivityName,PhysicalStoreID,PhysicalStoreName
			                                                ,WarehouseID,Margin,WarehouseName,ClusterName,ClusterID,i.ExpiryDate,vw.Name,vw.StockCode,Case when (systemDamagedQuantity>0 and SystemDamagedQuantity is not null) then 'Damaged' else Case when (systemExpiredQuantity>0 and SystemExpiredQuantity is not null) then 'Expired' else '' end end",
                activityId,
                periodId);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadByStoreAndActivityExcludeStockedout(int activityId, int physicalStoreId, int periodId)
        {
            string query;
            query =
                String.Format(@"select vw.Name as Category,ROW_NUMBER() OVER(PARTITION BY vw.Name ORDER BY FullItemName,ExpiryDate, BatchNo DESC),vw.TypeID ,i.Remarks ,vw.FullItemName, m.Name as ManufacturerName,iu.Text as Unit,NewSoundQuantity = cast(0 as decimal(18,4)), NewDamagedQuantity = cast(0 as decimal(18,4)) , i.*,  vw.StockCode,Case when (ExpiryDate < GetDate() and SystemSoundQuantity > 0) then Cast(1 as bit)  else Cast(0 as bit) end  isExpiredAfterInventory
                                                 from Inventory i
                                                        join vwGetAllItems vw on vw.ID = i.ItemID
                                                        join ItemUnit iu on iu.ID = i.UnitID
                                                        join Manufacturer m on m.ID = i.ManufacturerID
                                                    where 
                                                        i.InventoryPeriodID = {0} and i.PhysicalStoreID = {1} and i.ActivityID = {2}
                                                     Order By vw.Name,vw.FullItemName, i.ExpiryDate, i.BatchNo",
                    periodId, physicalStoreId, activityId);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadByStoreAndActivityIncludeStockedout(int activityId, int physicalStoreId, int periodId)
        {
            string query;
            query =
                String.Format(@"Select vw.Name as Category,[LineNo] = ROW_NUMBER() OVER(PARTITION BY vw.Name ORDER BY FullItemName,ExpiryDate, BatchNo DESC), 
                                            vw.FullItemName,m.Name as ManufacturerName,iu.[Text] Unit, 
                                            NewSoundQuantity = cast(0 as decimal(18,4)),NewDamagedQuantity = cast(0 as decimal(18,4))
                                            ,i.*,
                                            vw.StockCode ,Case when (ExpiryDate < GetDate() and SystemSoundQuantity > 0) then Cast(1 as bit)  else Cast(0 as bit) end  isExpiredAfterInventory
                                            from Inventory i
	                                            join vwGetAllItems vw on vw.ID = i.ItemID
 	                                            join ItemUnit iu on iu.ID = i.UnitID
 	                                            join Manufacturer m on m.ID = i.ManufacturerID
                                            where i.InventoryPeriodID = {0} and i.PhysicalStoreID = {1} and i.ActivityID = {2}
                                            Union
                                            SELECT vw.Name,[LineNo] = ROW_NUMBER() OVER(PARTITION BY vw.Name ORDER BY FullItemName,ExpDate, BatchNo DESC), 
                                                    vw.FullItemName,m.Name as ManufacturerName,iu.[Text] Unit,
                                                    NewSoundQuantity = cast(0 as decimal(18,4)),NewDamagedQuantity = cast(0 as decimal(18,4)),Null ID,
                                                    {0} InventoryPeriodID, {1} PhysicalStoreID, {2} ActivityID,rd.ItemID,rd.UnitID,rd.ManufacturerID ,Null SupplierID,rd.BatchNo,rd.ExpDate ExpiryDate,Null SystemSoundQuantity,Null SystemDamagedQuantity,Null InventorySoundQuantity,Null InventoryDamagedQuantity,Null Cost,Null Margin,Null SellingPrice,Null RecordedDate,Null IsDraft,Null ApprovedDate,Null RecordedBy,Null ApprovedBy,Null SystemExpiredQuantity,Null InventoryExpiredQuantity,Null Remarks, NULL ReceiveDocID, NULL	PalletLocationID,NULL	DamagedReceiveDocID,vw.StockCode , 0
                                             FROM ReceiveDoc rd join vwGetAllItems vw on rd.ItemID=vw.ID
                                                 join Manufacturers m on rd.ManufacturerId=m.ID 
	                                             join ReceivePallet rp on rd.ID=rp.ReceiveID 
                                                 join vwPallet p on rp.PalletID=p.PalletID 
	                                             join ItemUnit iu on rd.UnitID=iu.ID
                                            where rd.QuantityLeft = 0 
                                                and not exists (select * 
                                                            from inventory i where (i.ExpiryDate = rd.Expdate or (i.ExpiryDate is null and rd.ExpDate is null))
	                                                                            and (i.BatchNo = rd.BatchNo or (i.BatchNo is null and rd.BatchNo is null))
	                                                                            and i.ItemID = rd.ItemID
	                                                                            and i.UnitID = rd.UnitID
	                                                                            and i.ManufacturerID = rd.ManufacturerID
                                                                                and i.InventoryPeriodID = {0} and i.PhysicalStoreID = {1} and i.ActivityID = {2})
                                                                                and p.PhyicalStoreID={1} and rd.StoreID={2} 
                                            Order By vw.Name,vw.FullItemName, i.ExpiryDate, i.BatchNo", periodId,
                    physicalStoreId, activityId);
            return query;
        }
    }
}
