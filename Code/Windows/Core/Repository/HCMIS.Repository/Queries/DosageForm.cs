using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class DosageForm
    {
        [SelectQuery]
        public static string SelectLoadAll()
        {
            string query = String.Format("select t.Name as Type, d.* from DosageForm d join Type t on d.TypeID = t.ID ");
            return query;
        }
    }
}
