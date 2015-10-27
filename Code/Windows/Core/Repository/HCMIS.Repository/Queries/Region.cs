using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class Region
    {
        [SelectQuery]
        public static string SelectGetAllRegionsItemDispatched(int storeID)
        {
            string query;
            query =
                String.Format(
                    "Select * from Region where ID in (Select z.RegionId from IssueDoc id join Institution ru on id.ReceivingUnitID=ru.ID join Zone z on z.ID=ru.Zone WHERE id.StoreID={0})",
                    storeID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetRegionForActivity(int activityID)
        {
            return string.Format("Select * from Region where ID not in (Select z.RegionId from IssueDoc id join Institution ru on id.ReceivingUnitID=ru.ID join Zone z on z.ID=ru.Zone WHERE id.StoreID={0})", activityID);
        }
    }
}
