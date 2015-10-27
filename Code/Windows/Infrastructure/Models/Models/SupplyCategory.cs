using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class SupplyCategory
    {
        public SupplyCategory()
        {
            this.ItemSupplyCategories = new List<ItemSupplyCategory>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string Code { get; set; }
        public virtual ICollection<ItemSupplyCategory> ItemSupplyCategories { get; set; }
    }
}
