using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using HCMIS.Security.DataContext;

namespace HCMIS.Security.UserManagement.Helpers
{
    public class DirtyDBHelper
    {
        public static void RemoveUserDependancies(int id)
        {
            Security.DataContext.SecurityContext context = new SecurityContext();
            SqlParameter parameter = new SqlParameter("fromUser", id);
            SqlParameter parameter2 = new SqlParameter("toUser", id);
            context.Database.SqlQuery<string>("CHANGE_USER", new object[] { parameter, parameter2 });
        }

        internal static void ConsolidateUser(int fromUserID, int toUserID)
        {
            Security.DataContext.SecurityContext context = new SecurityContext();
            SqlParameter parameter = new SqlParameter("@FromUser", fromUserID);
            SqlParameter parameter2 = new SqlParameter("@ToUser", toUserID);
            IEnumerable<string> str = context.Database.SqlQuery<string>("CHANGE_USER @FromUser, @ToUser", new object[] { parameter, parameter2 }).ToList();
            context.Database.ExecuteSqlCommand(string.Format("delete from [User] where ID = {0}", fromUserID));
        }
    }
}
