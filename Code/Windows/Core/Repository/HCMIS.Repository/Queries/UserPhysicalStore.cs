using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Repository.Queries
{
    public class UserPhysicalStore
    {
        public static string SelectLoadAllowedForUserID(int userID)
        {
            string query = String.Format("Select * from UserPhysicalStore us join PhysicalStore s on us.PhysicalStoreID=s.ID where us.UserID={0} and us.CanAccess = 1", userID);
            return query;
        }

        public static string SelectLoadAllEntriesByUserID(int userID)
        {
            string query = String.Format("Select * from UserPhysicalStore us join PhysicalStore s on us.PhysicalStoreID=s.ID where us.UserID={0}", userID);
            return query;
        }

        public static string SelectLoadByUserAndStoreID(int userID, int physicalStoreID)
        {
            string query =
                String.Format(
                    "Select * from UserPhysicalStore us join PhysicalStore s on us.PhysicalStoreID=s.ID where us.UserID={0} and us.PhysicalStoreID={1} and us.CanAccess = 1",
                    userID, physicalStoreID);
            return query;
        }

        public static string SelectLoadAllByUserAndStoreID(int userID, int physicalStoreID)
        {
            string query =
                String.Format(
                    "Select * from UserPhysicalStore us join PhysicalStore s on us.PhysicalStoreID=s.ID where us.UserID={0} and us.PhysicalStoreID={1}",
                    userID, physicalStoreID);
            return query;
        }

        public static string UpdateMakeDefault(int userID, int phyStoreID)
        {
            string query = String.Format("Update UserPhysicalStore Set IsDefault=1 where UserID={0} and PhysicalStoreID={1} and CanAccess=1", userID, phyStoreID);
            return query;
        }

        public static string UpdateUserPhysicalStoreMakeDefault(int userID, int phyStoreID)
        {
            string query = String.Format("Update UserPhysicalStore Set IsDefault=0 where UserID={0} and ID not in (Select ID from UserPhysicalStore  where UserID={0} and PhysicalStoreID={1} and CanAccess=1)", userID, phyStoreID);
            return query;
        }
    }
}
