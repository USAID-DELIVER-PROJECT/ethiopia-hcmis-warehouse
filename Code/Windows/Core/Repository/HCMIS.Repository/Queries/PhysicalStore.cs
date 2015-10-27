using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Repository.Queries
{
    public class PhysicalStore
    {
        public static string SelectLoadForItem(int userID, int itemId, int storeID, int unitID)
        {
            string query = String.Format(
                "select vw.PhysicalStoreID ID from vwPhysicalStoreForItems vw join (select * from UserPhysicalStore where UserID = {3} and CanAccess = 1) us on vw.PhysicalStoreID = us.PhysicalStoreID  where vw.ItemID  = {0} and vw.UnitID = {1} and vw.StoreID = {2} and vw.QuantityLeft > 0  group by vw.PhysicalStoreID  OPTION (HASH GROUP, FAST 100)", itemId, unitID, storeID, userID);
            return query;
        }

        public static string LoadForItemOther(string ins)
        {
            string query = String.Format("select * from PhysicalStore where ID in ({0})", ins);
            return query;
        }

        public static string SelectGetStoresWithWarehouseAndCluster()
        {
            string query = String.Format("Select phy.ID, phy.Name, phType.Name Warehouse,c.Name Cluster from PhysicalStore phy join PhysicalStoreType phType on phy.PhysicalStoreTypeID=phType.ID join Cluster c on phType.ClusterID=c.ID");
            return query;
        }

        public static string SelectGetStoresWithWarehouseAndCluster(int warehouseID)
        {
            string query = String.Format(
                "Select phy.ID, phy.Name, phType.Name Warehouse,c.Name Cluster from PhysicalStore phy join PhysicalStoreType phType on phy.PhysicalStoreTypeID=phType.ID join Cluster c on phType.ClusterID=c.ID where phType.ID={0}",
                warehouseID);
            return query;
        }
        public  static string SelectLoadByItemID(int ItemID, int UserID)
        {
            string query = String.Format(@" SELECT ClusterID Value, Type = 'CLUSTER', 'CLUSTER-' + cast(vw.ClusterID AS varchar) ID, vw.ClusterName AS Name, 
																		    NULL ParentID, 1 AS Ordering,Cast(1 as bit) Selected
                                                        FROM     vwReceiptPallet vw 
														where ItemID = {0} and PhyicalStoreID in (select PhysicalStoreID from UserPhysicalStore ups where ups.UserID = {1} and ups.CanAccess = 1)  and ActivityID in (select StoreID from UserStore where UserID = {1} and CanAccess = 1)
														Union
														SELECT        WarehouseID, Type = 'WAREHOUSE', 'WAREHOUSE-' + cast(vw.WarehouseID AS varchar) TextID, vw.WareHouseName AS Name, 'CLUSTER-' +
				                                                         cast(vw.ClusterID AS varchar) ParentID, 2 AS Ordering,Cast(1 as bit)Selected
                                                        FROM     vwReceiptPallet vw 
														where ItemID = {0}  and PhyicalStoreID in (select PhysicalStoreID from UserPhysicalStore ups where ups.UserID = {1} and ups.CanAccess = 1)  and ActivityID in (select StoreID from UserStore where UserID = {1} and CanAccess = 1)
														Union
                                                        SELECT        PhyicalStoreID, Type = 'STORE', 'STORE-' + cast(vw.PhyicalStoreID AS varchar) TextID, vw.PhysicalStoreName AS Name, 'WAREHOUSE-' +
				                                                         cast(vw.WarehouseID AS varchar) ParentID, 3 AS Ordering,Cast(1 as bit)Selected
                                                        FROM     vwReceiptPallet vw 
														where ItemID = {0}  and PhyicalStoreID in (select PhysicalStoreID from UserPhysicalStore ups where ups.UserID = {1} and ups.CanAccess = 1)  and ActivityID in (select StoreID from UserStore where UserID = {1} and CanAccess = 1)", ItemID, UserID);
            return query;
        }

        public static string SelectGetWarehousesFor(int ItemID, int unitID, int activityID, int userID)
        {
            string query = String.Format(@"SELECT distinct WarehouseID as Value, Type = 'WAREHOUSE', 'WAREHOUSE-' + cast(vw.WarehouseID AS varchar) TextID, vw.WareHouseName AS Name, 'CLUSTER-' +
				                                                         cast(vw.ClusterID AS varchar) ParentID, 2 AS Ordering,Cast(1 as bit)Selected
                                                        FROM     vwReceiptPallet vw 
														where ItemID = {0} and ItemUnitID = {1}  and PhyicalStoreID in (select PhysicalStoreID from UserPhysicalStore ups where ups.UserID = {2} and ups.CanAccess = 1)  and ActivityID in (select StoreID from UserStore where UserID = {2} and CanAccess = 1) and ActivityID = {3}", ItemID, unitID, userID, activityID);
            return query;
        }

        public static string SelectGetPhysicalStoreStatus()
        {
            string query = String.Format(
                @"select Name as LocationName,ID as LocationID, IsActive as [Status], (case when IsActive = 1 then 'Active' else 'Frozen' end ) as StatusText from PhysicalStore where Isnull([PhysicalStoreTypeID],0) != 0  order by Name");
            return query;
        }

        public static string UpdateUpdatePhysicalStoreStatusbyWarehouse(int warehouseID, bool IsActive)
        {
            string query = String.Format(
                @"Update PhysicalStore 
                    SET IsActive = {1}
                    where PhysicalStoreTypeID = {0}", warehouseID, Convert.ToInt32(IsActive));
            return query;
        }
        public static string UpdateUpdatePhysicalStoreStatusbyCluster(int cluster, bool IsActive)
        {
            string query = String.Format(
                @" UPDATE physicalstore 
                            SET    isactive = {1} 
                            WHERE  physicalstoretypeid IN (SELECT DISTINCT physicalstoretypeid 
                                                           FROM   warehouse 
                                                           WHERE  clusterid = {0}) ", cluster, Convert.ToInt32(IsActive));
            return query;
        }

        public static string SelectGetAllowedPhysicalStoresForUser(int userId, bool isActive)
        {
            string query = String.Format(@"SELECT phy.id ID, 
                                           phy.name Name, 
                                           phType.name Warehouse, 
                                           c.name      Cluster 
                                    FROM   physicalstore phy 
                                           JOIN physicalstoretype phType 
                                             ON phy.physicalstoretypeid = phType.id 
                                           JOIN cluster c 
                                             ON phType.clusterid = c.id 
                                    WHERE  phy.id IN (SELECT physicalstoreid 
                                                      FROM   userphysicalstore 
                                                      WHERE  canaccess = 1 
                                                             AND userid = {0}){1}", userId, isActive ? "and phy.IsActive = 1" : "");
            return query;
        }

        public static string SelectGetDefaultPhysicalStoreFor(int userId)
        {
            string query = String.Format(@"SELECT phy.*
                                    FROM   physicalstore phy 
                                 WHERE  phy.id IN (SELECT physicalstoreid 
                                                      FROM   userphysicalstore 
                                                      WHERE  canaccess = 1 
                                                             AND userid = {0} and isDefault = 1)", userId);
            return query;
        }

        public static string SelectPhysicalStoreByPalletID(int palletID)
        {
            string query = String.Format(@"Select Top (1) ps.* from PhysicalStore ps 
	                                            join Shelf sh on sh.StoreID = ps.ID 
	                                            join PalletLocation pl on pl.ShelfID = sh.ID
                                            where pl.PalletID = {0}", palletID);
            return query;
        }

        public static string SelectPhysicalStoreByPalletLocationID(int palletLocationID)
        {
            string query = String.Format(@"Select Top (1) ps.* from PhysicalStore ps 
	                                            join Shelf sh on sh.StoreID = ps.ID 
	                                            join PalletLocation pl on pl.ShelfID = sh.ID
                                            where pl.ID = {0}", palletLocationID);
            return query;
        }

        public static string SelectAllPhysicalStoreswithClusterandWarehouseNames()
        {

            string query = String.Format(@"select cl.Name ClusterName , cl.ID ClusterID, 
		                                            wh.Name WarehouseName,wh.ID WarehouseID,
		                                            ps.Name PhysicalStoreName, ps.ID PhysicalStoreID 
                                            From Cluster cl
                                            Join Warehouse wh on cl.ID = wh.ClusterID
                                            Join PhysicalStore ps on wh.ID = ps.PhysicalStoreTypeID");
            return query;
        }

    }
}
