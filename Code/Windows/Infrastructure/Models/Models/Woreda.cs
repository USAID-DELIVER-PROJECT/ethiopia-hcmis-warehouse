using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class Woreda
    {
        public Woreda()
        {
            this.ReceivingUnits = new List<ReceivingUnit>();
        }

        public int ID { get; set; }
        public string WoredaName { get; set; }
        public Nullable<int> ZoneID { get; set; }
        public string WoredaCode { get; set; }
        public virtual ICollection<ReceivingUnit> ReceivingUnits { get; set; }
        public virtual Zone Zone { get; set; }
    }
}
