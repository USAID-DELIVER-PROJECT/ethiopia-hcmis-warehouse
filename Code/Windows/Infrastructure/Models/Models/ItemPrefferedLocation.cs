using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class ItemPrefferedLocation
    {
        public int ID { get; set; }
        public Nullable<int> ItemID { get; set; }
        public Nullable<int> PalletLocationID { get; set; }
        public Nullable<bool> IsFixed { get; set; }
        public virtual PalletLocation PalletLocation { get; set; }
        public virtual Item Item { get; set; }
    }
}
