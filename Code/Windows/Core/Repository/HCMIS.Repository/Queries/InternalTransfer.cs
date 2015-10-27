using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class InternalTransfer
    {
       
        public static string SelectGetAllTransfers(string type)
        {
            string query =
                String.Format(
                    "select IsSelected = cast (0 as bit), it.*,vw1.PalletLocation as ToPalletLocationName, vw2.PalletLocation as FromPalletLocationName, vw.FullItemName, m.Name as ManufacturerName from InternalTransfer it join vwPalletLocation vw1 on it.ToPalletLocationID = vw1.ID join vwPalletLocation vw2 on vw2.ID = it.FromPalletLocationID join vwGetAllItems vw on it.ItemID = vw.ID join Manufacturers m on m.ID = it.ManufacturerID where status = 0 and it.Type = '{0}'",
                    type);
            return query;
        }

        public static string SelectGetNewPrintNumber()
        {
            string query =
                String.Format("select Max(PrintNumber) as ID from InternalTransfer");
            return query;
        }
        public static string SelectGetStoreTransfer()
        {
            string query =
             String.Format(@"select
                                            pld.ID PicklistID,
                                            pld.ItemId ItemID,
                                            vw.FullItemName,
                                            pld.BatchNumber,
                                            pld.ExpireDate ,
                                            pld.Packs,
                                            pld.QuantityInBU, 
                                            ploc.Label FromPalletLocationName,
                                            ploc.ID FromPalletLocationID,
                                            m.Name as ManufacturerName,
                                            rp.ID receivePalletID
                                        from 
                                            PickListDetail pld join PickList pl ON pld.PickListID=pl.ID JOIN 
                                            ReceivePallet rp ON pld.ReceivePalletID=rp.id JOIN 
                                            [Order] o ON o.id=pl.OrderID JOIN 
                                            [Transfer] tr ON o.ID = tr.OrderID  JOIN
                                            PalletLocation ploc on  rp.PalletID = ploc.PalletID join 
                                            vwGetAllItems vw on pld.ItemID = vw.ID Join
                                            Manufacturers m on pld.ManufacturerID = m.ID
                                        Where ploc.ID = pld.PalletLocationID");
            return query;
        }

    }
}
