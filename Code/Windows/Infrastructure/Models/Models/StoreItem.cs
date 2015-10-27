using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class StoreItem
    {
        public int ID { get; set; }
        public Nullable<int> ItemID { get; set; }
        public Nullable<int> StoreID { get; set; }
        public Nullable<bool> UsedInThisStore { get; set; }
        public virtual Item Item { get; set; }
        public virtual Store Store { get; set; }
    }
}
