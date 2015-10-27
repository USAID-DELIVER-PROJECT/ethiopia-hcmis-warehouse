using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class Product
    {
        public Product()
        {
            this.ProductReceivingUnitTypes = new List<ProductReceivingUnitType>();
            this.ProductRUOwnershipTypes = new List<ProductRUOwnershipType>();
        }

        public int ID { get; set; }
        public string IIN { get; set; }
        public string ATC { get; set; }
        public string Description { get; set; }
        public Nullable<int> TypeID { get; set; }
        public virtual Type Type { get; set; }
        public virtual ICollection<ProductReceivingUnitType> ProductReceivingUnitTypes { get; set; }
        public virtual ICollection<ProductRUOwnershipType> ProductRUOwnershipTypes { get; set; }
    }
}
