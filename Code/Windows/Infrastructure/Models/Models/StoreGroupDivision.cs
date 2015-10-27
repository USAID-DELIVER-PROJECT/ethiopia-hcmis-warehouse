using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class StoreGroupDivision
    {
        public StoreGroupDivision()
        {
            this.Stores = new List<Store>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Descriptiont { get; set; }
        public Nullable<int> StoreGroupID { get; set; }
        public virtual StoreGroup StoreGroup { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
    }
}
