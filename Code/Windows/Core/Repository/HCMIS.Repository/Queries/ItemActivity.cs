using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class ItemActivity
    {
        [SelectQuery]
        public static string SelectLoadByItemId(int itemId)
        {
            string query = String.Format(@"Select *,
                                         case When s.ActivityName=s.SubAccountName and s.SubAccountName=s.AccountName then s.ActivityName else s.AccountName + ' - ' + s.SubAccountName + ' - ' + s.ActivityName end AS StoreName
                                         from StoreItem si join vwAccounts s on si.StoreID=s.ActivityID where si.itemID={0}", itemId);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadByItemAndStoreId(int itemId, int storeId)
        {
            string query =
                String.Format(
                    "Select * from StoreItem si join Stores s on si.StoreID=s.ID where si.itemID={0} and si.StoreID={1}", itemId,
                    storeId);
            return query;
        }

        [SelectQuery]
        public static string SelectIsEmpty()
        {
            string query = "select top(1) * from StoreItem";
            return query;
        }

        [SelectQuery]
        public static string SelectIsAccountTypeMatrixEntered(int itemId)
        {
            string query =
                String.Format(
                    "Select count(*) as Total from StoreItem si join vwGetAllItems i on si.ItemID=i.ID Where i.ID = {0} and si.UsedInThisStore=1",
                    itemId);
            return query;
        }
    }
}
