using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Repository.Queries
{
    public class Manufacturer
    {
        public static string SelectGetNewManufacturersFor(int itemId)
        {
            string query = String.Format("select * from Manufacturers where ID not in (select ManufacturerID from ItemManufacturer where ItemID = {0}) order by Name", itemId);
            return query;
        }

        public static string SelectLoadForItem(int itemId)
        {
            string query = String.Format("select m.* from  Manufacturers m where m.ID in (select distinct( im.ManufacturerID ) from ItemManufacturer im where  im.ItemID = {0} ) order by Name", itemId);
            return query;
        }

        public static string SelectLoadForItem(int itemId, int storeID, int unitID)
        {
            string query = String.Format("select m.* from  Manufacturers m where m.ID in (select distinct( im.ManufacturerID ) from ItemManufacturer im where  im.ItemID = {0}) and m.ID in (select distinct ManufacturerID from ReceiveDoc where QuantityLeft>0 and UnitID={1} and StoreID={2}) order by Name", itemId, unitID, storeID);
            return query;
        }

        public static string SelectLoadAll()
        {
            string query = "select * from Manufacturers Order By Name";
            return query;
        }
    }
}
