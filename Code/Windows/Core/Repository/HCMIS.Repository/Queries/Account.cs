using System;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class Account
    {
        [SelectQuery]
        public static string SelectByUser(int userID)
        {
            string query =
                String.Format(@"select distinct ModeName,AccountID,AccountName from vwAccounts vw
                                            WHERE ActivityID in
                                            (select us.StoreID from UserStore us where UserID={0} and CanAccess=1 )",
                    userID);
            return query;
        }

    }
}
