using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Repository.Queries
{
    public class UserActivity
    {
        public static string SelectLoadByUserID(int userID)
        {
            string query = String.Format("Select * from UserStore us join Stores s on us.StoreID=s.ID where us.UserID={0}", userID);
            return query;
        }

        public static string SelectLoadByUserIDAndStoreType(int userID, int storeTypeID, int itemID, int unitID)
        {
            string query = String.Format("Select * from UserStore us join vwAccounts a on us.StoreID = a.ActivityID where us.UserID={0} and us.CanAccess=1 and a.ModeID = {1} and  {2} in (select ItemId from ReceiveDoc r where r.StoreID = a.ActivityID and ItemID = {2} and UnitID = {3} and r.QuantityLeft > 0) ", userID, storeTypeID, itemID, unitID);
            return query;
        }

        public static string SelectLoadByUserAndStoreID(int userID, int storeID)
        {
            string query = String.Format("Select * from UserStore us join Stores s on us.StoreID=s.ID where us.UserID={0} and us.StoreID={1}", userID, storeID);
            return query;
        }

        public static string UpdateMakeDefault(int userID, int storeID)
        {
            string query = String.Format("Update UserStore Set IsDefault=1 where UserID={0} and StoreID={1} and CanAccess=1", userID, storeID);
            return query;
        }

        public static string UpdateUserStoreMakeDefault(int userID, int storeID)
        {
            string query = String.Format("Update UserStore Set IsDefault=0 where UserID={0} and ID not in (Select ID from UserStore  where UserID={0} and StoreID={1} and CanAccess=1)", userID, storeID);
            return query;
        }
    }
}
