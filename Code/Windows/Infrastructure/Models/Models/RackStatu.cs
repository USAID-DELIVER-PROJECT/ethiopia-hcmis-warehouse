using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class RackStatu
    {
        public RackStatu()
        {
            this.PalletLocations = new List<PalletLocation>();
        }

        public int ID { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public virtual ICollection<PalletLocation> PalletLocations { get; set; }
    }
}
