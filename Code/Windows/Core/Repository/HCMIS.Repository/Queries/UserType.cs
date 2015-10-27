using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Repository.Queries
{
    public class UserType
    {
        public static string SelectLoadAllButSysAdmin(int superAdmin)
        {
            return String.Format("Select * from UserType where ID <> {0}", superAdmin);
        }
    }
}
