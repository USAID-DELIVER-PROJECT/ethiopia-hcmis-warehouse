using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class RUOwnershipType
    {
        public RUOwnershipType()
        {
            this.ItemOwnershipTypes = new List<ItemOwnershipType>();
            this.ProductRUOwnershipTypes = new List<ProductRUOwnershipType>();
            this.ReceivingUnits = new List<ReceivingUnit>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ItemOwnershipType> ItemOwnershipTypes { get; set; }
        public virtual ICollection<ProductRUOwnershipType> ProductRUOwnershipTypes { get; set; }
        public virtual ICollection<ReceivingUnit> ReceivingUnits { get; set; }
    }
}
