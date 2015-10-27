using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Repository.Queries
{
    public class ItemPrefferedLocation
    {
        public static string SelectIsPreferedPalleteLocation(int palletLocationId, int itemId)
        {
            return String.Format("select * from ItemPrefferedLocation where PalletLocationID = {0} and ItemID = {1}", palletLocationId, itemId);
        }

        public static string SelectLoadByRackId(int rackId)
        {
            string query =
             String.Format("select * from ItemPrefferedLocation where PalletLocationID = {0}", rackId);
            return query;

        }
        public static string SelectSaveNewItemPreferredRack(int itemId, int palletLocation)
        {
            return String.Format("select * from ItemPrefferedLocation where ItemID = {0} and PalletLocationID={1}", itemId, palletLocation);
        }
        public static string SelectLoadByItemId(int itemId)
        {
            return String.Format("select ipr.*,pl.Label from ItemPrefferedLocation ipr join PalletLocation pl on pl.ID = ipr.PalletLocationID where ItemID = {0}", itemId);
        }
    }
}
