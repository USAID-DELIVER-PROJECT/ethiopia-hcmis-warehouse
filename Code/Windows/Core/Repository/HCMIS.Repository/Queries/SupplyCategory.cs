using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Repository.Queries
{
    public class SupplyCategory
    {
        public static string SelectGetAllSupplyCategories()
        {
            string query = "select 'U' + cast(ID as varchar) as ID, Name, 'U' + cast(ParentId as varchar ) as Parent from SupplyCategory";
            return query;
        }
    }
}
