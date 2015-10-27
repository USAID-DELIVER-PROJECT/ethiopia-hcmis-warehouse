using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class Transfer
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int FromStoreID { get; set; }
        public Nullable<int> ToStoreID { get; set; }
        public int FromPhysicalStoreID { get; set; }
        public Nullable<int> ToPhysicalStoreID { get; set; }
        public Nullable<int> TransferTypeID { get; set; }
        public virtual Order Order { get; set; }
        public virtual PhysicalStore PhysicalStore { get; set; }
        public virtual PhysicalStore PhysicalStore1 { get; set; }
        public virtual Store Store { get; set; }
        public virtual Store Store1 { get; set; }
        public virtual TransferType TransferType { get; set; }
    }
}
