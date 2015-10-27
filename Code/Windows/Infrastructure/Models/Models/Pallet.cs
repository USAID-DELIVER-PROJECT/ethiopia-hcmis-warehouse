using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class Pallet
    {
        public Pallet()
        {
            this.PalletLocations = new List<PalletLocation>();
            this.ReceivePallets = new List<ReceivePallet>();
        }

        public int ID { get; set; }
        public Nullable<int> PalletNo { get; set; }
        public Nullable<int> StorageTypeID { get; set; }
        public virtual ICollection<PalletLocation> PalletLocations { get; set; }
        public virtual ICollection<ReceivePallet> ReceivePallets { get; set; }
    }
}
