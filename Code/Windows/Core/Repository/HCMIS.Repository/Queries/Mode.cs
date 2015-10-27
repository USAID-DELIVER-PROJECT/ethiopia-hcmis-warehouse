using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class Mode
    {
        [SelectQuery]
        public static string SelectByUserID(int userID)
        {
            string query =
                String.Format(
                    "SELECT st.ID,st.TypeName FROM StoreType st join vwAccounts s on st.ID = s.ModeID join UserStore us on us.StoreID = s.ActivityID  where us.UserID={0} and us.CanAccess=1 group by st.ID, st.TypeName",
                    userID);
            return query;
        }

        [SelectQuery]
        public static string SelectModesForAUser(int userID)
        {
            string query = string.Format("SELECT st.ID,st.TypeName FROM StoreType st join vwAccounts s on st.ID = s.ModeID join UserStore us on us.StoreID = s.ActivityID  where us.UserID={0} and us.CanAccess=1 group by st.ID, st.TypeName", userID);
            return query;
        }
    }
}
