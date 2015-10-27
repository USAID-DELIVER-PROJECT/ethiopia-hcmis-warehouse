using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class Balance
    {
        public int ID { get; set; }
        public Nullable<int> ItemID { get; set; }
        public Nullable<int> StoreId { get; set; }
        public Nullable<System.DateTime> LastDate { get; set; }
        public Nullable<long> SOH { get; set; }
        public Nullable<long> PhysicalCount { get; set; }
        public Nullable<int> Month { get; set; }
        public Nullable<int> Year { get; set; }
        public Nullable<long> AMC { get; set; }
        public Nullable<double> SOHCost { get; set; }
        public virtual Item Item { get; set; }
        public virtual Store Store { get; set; }
    }
}
