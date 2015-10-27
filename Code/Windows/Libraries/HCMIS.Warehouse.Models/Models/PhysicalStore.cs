using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("PhysicalStore")]
    public class PhysicalStore
    {
        [Key][Column("ID")]
        public int PhysicalStoreID { get; set; }
        public string Name { get; set; }
        public double? Width { get; set; }
        public double Height { get; set; }
        public double? Length { get; set; }
        public int? DoorSide { get; set; }
        public int? DoorSize { get; set; }
        public double? DistanceFromCornor { get; set; }
        public int? PhysicalStoreTypeID { get; set; }
        public DateTime? CurrentPeriodStartDate { get; set; }
        public int? CurrentInventoryPeriodID { get; set; }
        public bool? IsActive { get; set; }
    }
}
