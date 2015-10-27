using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class ItemSupplier
    {
        [SelectQuery]
        public static string SelectGetSuppliersAndMarkThoseUsed(int itemId)
        {
            string query =
                String.Format(
                    "Select s.*,CASE When itmS.ItemID is null THEN 0 ELSE 1 END as [IsUsed] from Supplier s Left JOIN ItemSupplier itmS ON s.ID = itmS.SupplierID WHERE itmS.ItemID = {0} or itmS.ItemID is null",
                    itemId);
            return query;
        }

        [SelectQuery]
        public static string SelectCheckIfExist(int itemId, int supplierId)
        {
            string query = String.Format(
                "Select * from ItemSupplier itmS where itmS.SupplierID={0} AND itmS.ItemID={1}", supplierId, itemId);
            return query;
        }
    }
}
