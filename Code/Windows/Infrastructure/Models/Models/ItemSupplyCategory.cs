using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class ItemSupplyCategory
    {
        public int ID { get; set; }
        public Nullable<int> ItemID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public virtual Item Item { get; set; }
        public virtual SupplyCategory SupplyCategory { get; set; }
    }
}
