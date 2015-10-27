using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class YearEnd
    {
        public int ID { get; set; }
        public Nullable<int> ItemID { get; set; }
        public Nullable<int> StoreID { get; set; }
        public Nullable<int> Year { get; set; }
        public Nullable<long> BBalance { get; set; }
        public Nullable<long> EBalance { get; set; }
        public Nullable<long> PhysicalInventory { get; set; }
        public string Remark { get; set; }
        public Nullable<int> Month { get; set; }
        public Nullable<decimal> EndingPrice { get; set; }
        public Nullable<decimal> PhysicalInventoryPrice { get; set; }
        public Nullable<decimal> BBPrice { get; set; }
        public Nullable<int> UnitID { get; set; }
        public Nullable<int> PhysicalStoreID { get; set; }
        public virtual Item Item { get; set; }
        public virtual ItemUnit ItemUnit { get; set; }
        public virtual PhysicalStore PhysicalStore { get; set; }
    }
}
