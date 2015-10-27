using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class ItemManufacturer
    {
        public int ID { get; set; }
        public Nullable<int> ItemID { get; set; }
        public Nullable<int> ManufacturerID { get; set; }
        public Nullable<int> PackageLevel { get; set; }
        public Nullable<int> QuantityPerLevel { get; set; }
        public Nullable<bool> IsssuingDefault { get; set; }
        public Nullable<bool> RecevingDefault { get; set; }
        public double BoxWidth { get; set; }
        public double BoxHeight { get; set; }
        public double BoxLength { get; set; }
        public string BrandName { get; set; }
        public Nullable<double> StackHeight { get; set; }
        public virtual Item Item { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
    }
}
