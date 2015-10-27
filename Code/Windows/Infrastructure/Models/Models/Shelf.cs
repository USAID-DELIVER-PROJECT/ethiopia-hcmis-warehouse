using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class Shelf
    {
        public Shelf()
        {
            this.PalletLocations = new List<PalletLocation>();
            this.ShelfRowColumns = new List<ShelfRowColumn>();
        }

        public int ID { get; set; }
        public Nullable<int> StoreID { get; set; }
        public string ShelfCode { get; set; }
        public string ShelfType { get; set; }
        public Nullable<int> Rows { get; set; }
        public Nullable<int> Columns { get; set; }
        public Nullable<double> CoordinateX { get; set; }
        public Nullable<double> CoordinateY { get; set; }
        public Nullable<double> Rotation { get; set; }
        public Nullable<double> Length { get; set; }
        public Nullable<double> Width { get; set; }
        public Nullable<double> Height { get; set; }
        public Nullable<int> ShelfStorageType { get; set; }
        public virtual ICollection<PalletLocation> PalletLocations { get; set; }
        public virtual PhysicalStore PhysicalStore { get; set; }
        public virtual ICollection<ShelfRowColumn> ShelfRowColumns { get; set; }
    }
}
