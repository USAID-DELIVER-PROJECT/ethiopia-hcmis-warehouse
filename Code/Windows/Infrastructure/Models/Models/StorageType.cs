using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class StorageType
    {
        public StorageType()
        {
            this.Items = new List<Item>();
            this.PalletLocations = new List<PalletLocation>();
            this.StorageType1 = new List<StorageType>();
        }

        public int ID { get; set; }
        public string StorageTypeName { get; set; }
        public Nullable<int> IsSubTypeOf { get; set; }
        public string Prefix { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<PalletLocation> PalletLocations { get; set; }
        public virtual ICollection<StorageType> StorageType1 { get; set; }
        public virtual StorageType StorageType2 { get; set; }
    }
}
