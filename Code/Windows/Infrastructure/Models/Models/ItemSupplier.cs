using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class ItemSupplier
    {
        public int ID { get; set; }
        public Nullable<int> SupplierID { get; set; }
        public Nullable<int> ItemID { get; set; }
        public virtual Item Item { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
