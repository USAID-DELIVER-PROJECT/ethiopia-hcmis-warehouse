using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class Zone
    {
        public Zone()
        {
            this.ReceivingUnits = new List<ReceivingUnit>();
            this.Woredas = new List<Woreda>();
        }

        public int ID { get; set; }
        public string ZoneName { get; set; }
        public Nullable<int> RegionId { get; set; }
        public string ZoneCode { get; set; }
        public virtual ICollection<ReceivingUnit> ReceivingUnits { get; set; }
        public virtual Region Region { get; set; }
        public virtual ICollection<Woreda> Woredas { get; set; }
    }
}
