using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class PhysicalStoreType
    {
        public PhysicalStoreType()
        {
            this.PhysicalStores = new List<PhysicalStore>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> ClusterID { get; set; }
        public virtual Cluster Cluster { get; set; }
        public virtual ICollection<PhysicalStore> PhysicalStores { get; set; }
    }
}
