using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class HalfPalletLocation
    {
        public int ID { get; set; }
        public Nullable<int> PalletLocationID { get; set; }
        public string Label { get; set; }
        public Nullable<int> PalleteID { get; set; }
        public Nullable<bool> Confirmed { get; set; }
        public virtual PalletLocation PalletLocation { get; set; }
    }
}
