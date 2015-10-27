using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class Region
    {
        public Region()
        {
            this.Zones = new List<Zone>();
        }

        public int ID { get; set; }
        public string RegionName { get; set; }
        public string RegionCode { get; set; }
        public virtual ICollection<Zone> Zones { get; set; }
    }
}
