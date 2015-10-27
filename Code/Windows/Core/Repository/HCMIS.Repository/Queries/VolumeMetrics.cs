using System;
using HCMIS.Repository.Helpers;
using System.Collections.Generic;

namespace HCMIS.Repository.Queries
{
    public class VolumeMetrics
    {
        [SelectQuery]
        public static string SelectGetVolumeProperty(int ItemID, int UnitID, int ManufacturerID)
        {
            var query = @"Select WidthMM, HeightMM, LengthMM, Weight from dbo.VolumeMetrics
                            Where ItemID = {0} and UnitID = {1} and ManufacturerId = {2}";
            return String.Format(query, ItemID, UnitID, ManufacturerID);
        }

        [SelectQuery]
        public static string SelectGetVolumeProperty(List<Tuple<int, int>> itemUnits)
        {
            var query = @"Select WidthMM, HeightMM, LengthMM, Weight 
                          from dbo.VolumeMetrics
                            Where {0}";

            foreach (Tuple<int, int> itemUnit in itemUnits)
            {

            }

            return String.Format(query);
        }

        [SelectQuery]
        public static string SelectGetVolumeProperty(int [] itemIDs)
        {
            var query = @"Select *
                          from dbo.VolumeMetrics
                            Where ItemId in ({0})";

            return String.Format(String.Format(query, String.Join(", ", itemIDs)));
        }
    }
}
