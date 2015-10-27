using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class StoreGroup
    {
        public StoreGroup()
        {
            this.StoreGroupDivisions = new List<StoreGroupDivision>();
            this.Stores = new List<Store>();
            this.WeightedAverageLogs = new List<WeightedAverageLog>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<int> StoreTypeID { get; set; }
        public virtual ICollection<StoreGroupDivision> StoreGroupDivisions { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
        public virtual ICollection<WeightedAverageLog> WeightedAverageLogs { get; set; }
    }
}
