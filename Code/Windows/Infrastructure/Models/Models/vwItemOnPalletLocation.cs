using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class vwItemOnPalletLocation
    {
        public int ID { get; set; }
        public string FullItemName { get; set; }
        public Nullable<long> Balance { get; set; }
        public Nullable<int> ItemID { get; set; }
        public Nullable<int> PalletID { get; set; }
        public Nullable<System.DateTime> ExpDate { get; set; }
    }
}
