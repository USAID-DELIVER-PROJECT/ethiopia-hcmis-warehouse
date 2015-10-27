using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class Activity
    {
        [SelectQuery]
        public static string SelectAllFromVwAccounts()
        {
            const string query = @"Select a.ActivityID ID, ActivityName Name, a.ActivityName Activity, * 
                                    from VwAccounts a 
                                    join Account.activity as ac on a.ActivityID = ac.ActivityID";
            return query;
        }

        [SelectQuery]
        public static string SelectFromVwAccountsByID(int activityID)
        {
            string query = String.Format("Select a.ActivityID ID,ActivityName Name, ac.rowguid, * from VwAccounts a join Account.activity as ac on a.ActivityID = ac.ActivityID where a.ActivityID ={0}", activityID);
            return query;
        }

        [SelectQuery]
        public static string SelectFirstByMode(int modeID)
        {
            string query =
                String.Format("Select a.ActivityID ID,ActivityName Name, ac.rowguid, * from VwAccounts a join Account.activity as ac on a.ActivityID = ac.ActivityID where a.ModeID ={0}", modeID);
            return query;
        }

        [SelectQuery]
        public static string SelectByMode(int modeID)
        {
            string query =
                String.Format(@"Select Select a.ActivityID ID,ActivityName Name, ac.rowguid, * from VwAccounts a join Account.activity as ac on a.ActivityID = ac.ActivityID where a.ModeID ={0}", modeID);
            return query;
        }
     
        [SelectQuery]
        public static string SelectAllWhereUserHasAccess(int userID)
        {
            string query =
                String.Format(@"Select a.ActivityID ID,ActivityName Name, ac.rowguid, * from VwAccounts a join Account.activity as ac on a.ActivityID = ac.ActivityID WHERE a.ActivityID IN (SELECT StoreID 
                                                                FROM UserStore 
                                                                    WHERE UserID={0} and CanAccess=1)
                                ", userID);
            return query;
        }

        [SelectQuery]
        public static string SelectFirstActivityUsingFEFO(int itemID, int unitID)
        {
            string query =
                String.Format("select top(1) ActivityID ID,ActivityName Name, * from vwItemsReadyForDispatch ird join vwAccounts a on ird.StoreID = a.ActivityID where itemid={0} and unitID={1} order by ExpDate asc", itemID, unitID);
            return query;
        }
       
        [SelectQuery]
        public static string SelectDefaultStoreByUserID(int userID)
        {
            string query =
                String.Format(@"Select a.ActivityID ID,ActivityName Name, ac.rowguid, * from VwAccounts a join Account.activity as ac on a.ActivityID = ac.ActivityID
                                        WHERE a.ActivityID IN (SELECT StoreID 
                                                                FROM UserStore 
                                                                    WHERE UserID={0} and CanAccess=1 and IsDefault=1)", userID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetAllWithTextID()
        {
            string query =
                @"select StoreName, *, 'N' + Cast(ID as varchar) TextID from Stores union select 'DN - ' + StoreName as StoreName, *, 'D' + Cast(ID as varchar) TextID from Stores";
            return query;
        }

        [SelectQuery]
        public static string SelectGetAccountTree(int userID)
        {
            string query = String.Format("select * from vwAccountTreeByUser where UserID = {0} order by Ordering, Name", userID);
            return query;
        }

        [SelectQuery]
        public static string SelectTreeByItem(int ItemID, int UserID)
        {
            string query =
                String.Format(@"    SELECT        sg.ID Value, 'ACCOUNT', 'ACCOUNT-' + cast(sg.ID AS varchar) ID, sg.Name,NULL AS ParentID, 1 AS Ordering,Cast(1 as bit) Selected
                                                        FROM            StoreGroup sg join StoreGroupDivision sgd on sg.ID = sgd.StoreGroupID join Stores st on sgd.ID = st.StoreGroupDivisionID
				                                                         Join vwReceiveDocWarehouse rd on rd.StoreID = st.ID  
                                                        WHERE        StoreGroupDivisionID IS NOT NULL and ItemID ={0} and rd.WarehouseID in  (select PhysicalStoreTypeID from UserPhysicalStore ups join PhysicalStore ps on ps.ID = ups.PhysicalStoreID where ups.UserID = {1} and ups.CanAccess = 1) and rd.StoreID in (select StoreID from UserStore where UserID = {1} and CanAccess = 1)
                                                        UNION

                                                        SELECT        sgd.ID, 'SUBACCOUNT', 'SUBACCOUNT-' + cast(sgd.ID AS varchar) TextID, sgd.Name, 'ACCOUNT-' + cast(sgd.StoreGroupID AS varchar) ParentID, 2 AS Ordering,Cast(1 as bit) Selected
                                                        FROM               StoreGroup sg join StoreGroupDivision sgd on sg.ID = sgd.StoreGroupID join Stores st on sgd.ID = st.StoreGroupDivisionID
				                                                         Join vwReceiveDocWarehouse rd on rd.StoreID = st.ID   
                                                        WHERE        StoreGroupDivisionID IS NOT NULL and ItemID ={0} and rd.WarehouseID in (select PhysicalStoreTypeID from UserPhysicalStore ups join PhysicalStore ps on ps.ID = ups.PhysicalStoreID where ups.UserID = {1} and ups.CanAccess = 1)  and rd.StoreID in (select StoreID from UserStore where UserID = {1} and CanAccess = 1)
                                                        UNION

                                                        SELECT        st.ID, 'ACTIVITY', 'ACTIVITY-' + cast(st.ID AS varchar) TextID, StoreName AS Name, 'SUBACCOUNT-' +
				                                                         cast(StoreGroupDivisionID AS varchar) ParentID, 3 AS Ordering,Cast(1 as bit) Selected
                                                        FROM           StoreGroup sg join StoreGroupDivision sgd on sg.ID = sgd.StoreGroupID join Stores st on sgd.ID = st.StoreGroupDivisionID
				                                                         Join vwReceiveDocWarehouse rd on rd.StoreID = st.ID  
                                                        WHERE        StoreGroupDivisionID IS NOT NULL and ItemID ={0} and rd.WarehouseID in (select PhysicalStoreTypeID from UserPhysicalStore ups join PhysicalStore ps on ps.ID = ups.PhysicalStoreID where ups.UserID = {1} and ups.CanAccess = 1)  and rd.StoreID in (select StoreID from UserStore where UserID = {1} and CanAccess = 1)
                                          ", ItemID, UserID);
            return query;
        }

        [SelectQuery]
        public static string SelectByItemAndUnit(int itemID, int unitID, int userID)
        {
            string query = String.Format(@"select * from vwAccounts 
                                                    where ActivityID in ( 
                                                                            select distinct StoreID 
                                                                                        from vwReceiveDocWarehouse 
                                                                                rd where ItemID = {0} and UnitID = {1} and WarehouseID in (select PhysicalStoreTypeID from UserPhysicalStore ups join PhysicalStore ps on ps.ID = ups.PhysicalStoreID where ups.UserID = {2} and ups.CanAccess = 1) 
                                                        and rd.StoreID in (
                                                                            select StoreID from UserStore where UserID = {2} and CanAccess = 1)
                                            )  ", itemID, unitID, userID);
            return query;
        }

    }
}
