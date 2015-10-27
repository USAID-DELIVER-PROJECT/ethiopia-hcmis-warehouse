using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    [Schema("Location")]
    public class Cluster
    {
        [SelectQuery]
        public static string SelectClusterStatus()
        {
            string query = string.Format(@"select Name as LocationName,ID as LocationID, IsActive as [Status], (case when IsActive = 1 then 'Active' else 'Frozen' end ) as StatusText from Cluster order by Name");
            return query;
        }
    }
}
