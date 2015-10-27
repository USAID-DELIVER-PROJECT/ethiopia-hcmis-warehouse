using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class vwPhysicalStoreForItem
    {
        public int PhysicalStoreID { get; set; }
        public Nullable<int> ItemID { get; set; }
        public Nullable<int> UnitID { get; set; }
        public Nullable<int> StoreID { get; set; }
        public Nullable<long> QuantityLeft { get; set; }
        public Nullable<long> Balance { get; set; }
    }
}
