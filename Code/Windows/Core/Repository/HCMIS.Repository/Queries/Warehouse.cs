using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class Warehouse
    {
        [SelectQuery]

        public static string SelectGetWarehouseWithCluster(int userID)
        {
            string query = String.Format(
                "Select distinct phType.ID ID,phType.Name Warehouse,c.Name Cluster from PhysicalStore phy join PhysicalStoreType phType on phy.PhysicalStoreTypeID=phType.ID join Cluster c on phType.ClusterID=c.ID where phy.ID in (select PhysicalStoreID from UserPhysicalStore where CanAccess=1 and UserID={0})",
                userID);
            return query;
        }

        public static string SelectgetActiveWarehouseWithCluster(int userID)
        {
            string query = String.Format(@"Select distinct phType.ID ID,phType.Name Warehouse,c.Name Cluster 
	                            from PhysicalStore phy 
		                            join PhysicalStoreType phType on phy.PhysicalStoreTypeID=phType.ID 
		                            join Cluster c on phType.ClusterID=c.ID
                                where phy.ID in (select PhysicalStoreID from UserPhysicalStore 
                                                    where CanAccess=1 and UserID={0}) and phy.IsActive = 1", userID);
            return query;
        }

        public static string SelectLoadUsersClusters(int userID)
        {
            string query = String.Format("select * from PhysicalStoreType where ID in (select PhysicalStoreTypeID from PhysicalStore ps join UserPhysicalStore ups on ps.ID = ups.PhysicalStoreID and ups.UserID = {0} and ups.CanAccess = 1) order by Name", userID);
            return query;
        }

        public static string SelectLoadUsersClustersContainingItem(int userID, int itemID, int unitID, int activityID)
        {
            string query = String.Format("select * from PhysicalStoreType where ID in (select PhysicalStoreTypeID from PhysicalStore ps join UserPhysicalStore ups on ps.ID = ups.PhysicalStoreID and ups.UserID = {0} and ups.CanAccess = 1 and ps.ID in (select s.StoreID from Shelf s join PalletLocation pl on pl.ShelfID = s.ID join ReceivePallet rp on rp.PalletLocationID = pl.ID join ReceiveDoc rd on rp.ReceiveID = rd.ID where rd.ItemID = {1} and rd.UnitID = {2} and rd.StoreID = {3}))  order by Name", userID, itemID, unitID, activityID);
            return query;
        }

        public static string SelectGetWarehouseStatus()
        {
            string query = String.Format(
                @"select Name as LocationName, ID as LocationID, IsActive as [Status], (case when IsActive = 1 then 'Active' else 'Frozen' end ) as StatusText from Warehouse order by Name");
            return query;
        }

        public static string UpdateUpdateWarehouseStatusbyCluster(int clusterId, bool IsActive)
        {
            string query = String.Format(
                @"Update Warehouse  
                    SET IsActive = {1}
                    where ClusterID = {0}", clusterId, Convert.ToInt32(IsActive));
            return query;
        }
    }
}
