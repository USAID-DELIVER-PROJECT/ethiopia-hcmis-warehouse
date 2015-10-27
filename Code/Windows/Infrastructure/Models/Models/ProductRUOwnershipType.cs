using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class ProductRUOwnershipType
    {
        public int ID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> RUOwnershipTypeID { get; set; }
        public Nullable<bool> AllowFully { get; set; }
        public Nullable<bool> Warning { get; set; }
        public Nullable<bool> Restriction { get; set; }
        public virtual Product Product { get; set; }
        public virtual RUOwnershipType RUOwnershipType { get; set; }
    }
}
