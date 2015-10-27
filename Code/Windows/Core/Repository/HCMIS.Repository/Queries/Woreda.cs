using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class Woreda
    {
        [SelectQuery]
        public static string SelectGetWoredaByZoneAndNumberRU(int zoneId)
        {
            string query = String.Format(@" SELECT Woreda.ID
                                      ,Woreda.WoredaName
                                      ,Woreda.WoredaName + ' (' + CAST(COUNT(Institution.ID) as varchar) + ')' as Count
                                  FROM Institution 
                                  join Woreda on Woreda.ID = Institution.Woreda
                                  join Zone on Zone.ID = Woreda.ZoneID
                                  join Region on Region.ID = Zone.RegionId
                                  Where Woreda.Zoneid = {0}
                                  Group by Woreda.ID
                                      ,Woreda.WoredaName ", zoneId);
            return query;
        }

        public static string SelectGetWoredaByZoneAndNumberRU(int zoneId, int storeID)
        {
            string query = String.Format(@" SELECT Woreda.ID
                                      ,Woreda.WoredaName
                                      ,Woreda.WoredaName + ' (' + CAST(COUNT(Institution.ID) as varchar) + ')' as Count
                                  FROM Institution 
                                  join Woreda on Woreda.ID = Institution.Woreda
                                  join Zone on Zone.ID = Woreda.ZoneID
                                  join Region on Region.ID = Zone.RegionId
                                  Where Woreda.Zoneid = {0} and Woreda.ID in (Select w.ID from IssueDoc id join Institution ru on id.ReceivingUnitID=ru.ID join Woreda w on w.ID=ru.Woreda where id.StoreID={1})
                                  Group by Woreda.ID
                                      ,Woreda.WoredaName ", zoneId, storeID);
            return query;
        }
    }
}
