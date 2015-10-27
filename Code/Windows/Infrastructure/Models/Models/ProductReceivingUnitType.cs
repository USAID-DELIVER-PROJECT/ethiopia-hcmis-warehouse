using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class ProductReceivingUnitType
    {
        public int ID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> ReceivingUnitTypeID { get; set; }
        public Nullable<bool> AllowFully { get; set; }
        public Nullable<bool> Warning { get; set; }
        public Nullable<bool> Restriction { get; set; }
        public virtual Product Product { get; set; }
        public virtual ReceivingUnitType ReceivingUnitType { get; set; }
    }
}
