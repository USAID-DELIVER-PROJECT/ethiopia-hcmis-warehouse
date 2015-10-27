using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Repository.Queries
{
    public class Pallet
    {
        public static string SelectLoadByPalletNumber(string palletNumber)
        {
            string query=
             String.Format("select * from Pallet where PalletNo = '{0}'", palletNumber);
            return query;
        }
        public  static string SelectGetLastPanelNumber()
        {
            string query=
            String.Format( "select max(PalletNo) Last from Pallet");
            return query;
        }
        public static string SelectGetAllItemsInPallet(int palletId)
        {
            return string.Format("select rp.Balance, (rp.Balance / rd.QtyPerPack) as BalanceSKU, * , Loss = 0, Reason = 0 from Pallet p join ReceivePallet rp on p.ID = rp.PalletID join ReceiveDoc rd on rp.ReceiveID = rd.ID join vwGetAllItems vi on vi.ID = rd.ItemID where p.ID = {0} and rp.Balance > 0", palletId);
        }
        public static string SelectGetAllItemsInPalletSKUTotal(int palletId)
        {
            return string.Format("select  SUM(rp.Balance / rd.QtyPerPack) as Total from Pallet p join ReceivePallet rp on p.ID = rp.PalletID join ReceiveDoc rd on rp.ReceiveID = rd.ID join vwGetAllItems vi on vi.ID = rd.ItemID where p.ID = {0} and rp.Balance > 0", palletId);
        }
    }
}
