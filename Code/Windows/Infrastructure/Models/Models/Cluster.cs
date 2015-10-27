using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class Cluster
    {
        public Cluster()
        {
            this.PhysicalStoreTypes = new List<PhysicalStoreType>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<PhysicalStoreType> PhysicalStoreTypes { get; set; }
    }
}
