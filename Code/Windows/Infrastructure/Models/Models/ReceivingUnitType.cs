using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class ReceivingUnitType
    {
        public ReceivingUnitType()
        {
            this.ItemReceivingUnitTypes = new List<ItemReceivingUnitType>();
            this.ProductReceivingUnitTypes = new List<ProductReceivingUnitType>();
            this.ReceivingUnits = new List<ReceivingUnit>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ItemReceivingUnitType> ItemReceivingUnitTypes { get; set; }
        public virtual ICollection<ProductReceivingUnitType> ProductReceivingUnitTypes { get; set; }
        public virtual ICollection<ReceivingUnit> ReceivingUnits { get; set; }
    }
}
