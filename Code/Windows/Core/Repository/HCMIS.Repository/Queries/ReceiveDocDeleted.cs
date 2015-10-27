using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class ReceiveDocDeleted
    {
        [SelectQuery]
        public static string SelectLoadAllByReceiptID(int receiptId)
        {
            string query = String.Format(
                @"select rd.NoOfPack Pack,i.FullItemName,iu.[Text] ItemUnitName,m.Name ManufacturerName,rd.ID ID, rd.DeletedBy, IsDeleted=1
                                        from ReceivedocDeleted rd  join vwAccounts vw on vw.ActivityID = rd.StoreID
                                        join Manufacturers m on rd.ManufacturerId=m.ID join vwGetAllItems i on rd.ItemID=i.ID
                                        join ItemUnit iu on rd.UnitID=iu.ID where rd.ReceiptID={0}",
                receiptId);
            return query;
        }
    }
}
