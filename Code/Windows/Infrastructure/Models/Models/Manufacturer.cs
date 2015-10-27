using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class Manufacturer
    {
        public Manufacturer()
        {
            this.ItemManufacturers = new List<ItemManufacturer>();
            this.ReceiveDocs = new List<ReceiveDoc>();
            this.WeightedAverageLogs = new List<WeightedAverageLog>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string CountryOfOrigin { get; set; }
        public string PFSAManufCode { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public virtual ICollection<ItemManufacturer> ItemManufacturers { get; set; }
        public virtual ICollection<ReceiveDoc> ReceiveDocs { get; set; }
        public virtual ICollection<WeightedAverageLog> WeightedAverageLogs { get; set; }
    }
}
