using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("ItemManufacturer")]
    public class ItemManufacturer
    {
        [Key][Column("ID")]
        public int ItemManufacturerID { get; set; }
        public int? ItemID { get; set; }
        public int? ManufacturerID { get; set; }
        public int? PackageLevel { get; set; }
        public int? QuantityPerLevel { get; set; }
        public bool? IssuingDefault { get; set; }
        public double? BoxWidth { get; set; }
        public double? BoxHeight { get; set; }
        public double? BoxLength { get; set; }
        public string BrandName { get; set; }
        public double? StackHeight { get; set; }
        public Guid? ItemGuid { get; set; }
        public Guid? ManufacturerGuid { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }

    }
}
