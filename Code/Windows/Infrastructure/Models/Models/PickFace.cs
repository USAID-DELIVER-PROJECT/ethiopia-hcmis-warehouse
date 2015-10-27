using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class PickFace
    {
        public int ID { get; set; }
        public Nullable<int> PalletLocationID { get; set; }
        public Nullable<int> DesignatedItem { get; set; }
        public Nullable<int> Balance { get; set; }
        public Nullable<int> LogicalStore { get; set; }
        public virtual Item Item { get; set; }
        public virtual PalletLocation PalletLocation { get; set; }
    }
}
