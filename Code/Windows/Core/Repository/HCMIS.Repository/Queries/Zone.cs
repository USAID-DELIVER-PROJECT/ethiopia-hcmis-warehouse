using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class Zone
    {
        [SelectQuery]
        public static string SelectGetZoneByRegionAndNumberRU(int regionId)
        {
            string query =
                String.Format(@"SELECT Zone.ID
                                        ,Zone.ZoneName
                                        ,Zone.ZoneName + ' ('+ CAST(COUNT(Institution.ID) as varchar) +')' Count
                                FROM Institution 
                                    join Woreda on Woreda.ID = Institution.Woreda
                                    join Zone on Zone.ID = Woreda.ZoneID
                                    join Region on Region.ID = Zone.RegionId
                                Where zone.regionId = {0}
                                Group by Zone.ID
                                        ,Zone.ZoneName ", regionId);
            return query;
        }

        [SelectQuery]
        public static string SelectGetZoneByRegionAndNumberRU(int regionId, int storeID)
        {
            string query =
                String.Format(@"SELECT Zone.ID
                                        ,Zone.ZoneName
                                        ,Zone.ZoneName + ' ('+ CAST(COUNT(Institution.ID) as varchar) +')' Count
                                FROM Institution 
                                    join Woreda on Woreda.ID = Institution.Woreda
                                    join Zone on Zone.ID = Woreda.ZoneID
                                    join Region on Region.ID = Zone.RegionId
                                Where zone.regionId = {0} and zone.ID in (Select z.ID from IssueDoc id join Institution ru on id.ReceivingUnitID=ru.ID join Zone z on z.ID=ru.Zone where id.StoreID={1})
                                Group by Zone.ID
                                        ,Zone.ZoneName ", regionId, storeID);
            return query;
        }
    }
}
