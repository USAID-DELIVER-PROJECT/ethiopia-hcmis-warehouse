using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class PalletLocation
    {
        public PalletLocation()
        {
            this.HalfPalletLocations = new List<HalfPalletLocation>();
            this.ItemPrefferedLocations = new List<ItemPrefferedLocation>();
            this.PickFaces = new List<PickFace>();
            this.ReceivePallets = new List<ReceivePallet>();
        }

        public int ID { get; set; }
        public string Label { get; set; }
        public Nullable<int> ShelfID { get; set; }
        public Nullable<int> Row { get; set; }
        public Nullable<int> Column { get; set; }
        public Nullable<int> StorageTypeID { get; set; }
        public bool IsFullSize { get; set; }
        public Nullable<bool> IsEnabled { get; set; }
        public Nullable<int> RackStatusID { get; set; }
        public Nullable<int> PalletID { get; set; }
        public Nullable<double> PercentUsed { get; set; }
        public Nullable<double> Width { get; set; }
        public Nullable<double> Height { get; set; }
        public Nullable<double> Length { get; set; }
        public Nullable<bool> Confirmed { get; set; }
        public bool IsExtended { get; set; }
        public Nullable<int> ExtendedRows { get; set; }
        public double AvailableVolume { get; set; }
        public double UsedVolume { get; set; }
        public virtual ICollection<HalfPalletLocation> HalfPalletLocations { get; set; }
        public virtual ICollection<ItemPrefferedLocation> ItemPrefferedLocations { get; set; }
        public virtual Pallet Pallet { get; set; }
        public virtual ICollection<PickFace> PickFaces { get; set; }
        public virtual RackStatu RackStatu { get; set; }
        public virtual Shelf Shelf { get; set; }
        public virtual StorageType StorageType { get; set; }
        public virtual ICollection<ReceivePallet> ReceivePallets { get; set; }
    }
}
