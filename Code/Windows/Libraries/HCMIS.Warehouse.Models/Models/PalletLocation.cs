using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("PalletLocation")]
    public class PalletLocation
    {
        [Key][Column("ID")]
        public int PalletLocationID { get; set; }
        public string Label { get; set; }
        public int? ShelfID { get; set; }
        public int? Row { get; set; }
        public int? Column { get; set; }
        public int? StorageTypeID { get; set; }
        public bool? IsFullSize { get; set; }
        public bool? IsEnabled { get; set; }
        public int? RackStatusID { get; set; }
        public int? PalletID { get; set; }
        public double? PercentUsed { get; set; }
        public double? Width { get; set; }
        public double? Height { get; set; }
        public double? Length { get; set; }
        public bool? Confirmed { get; set; }
        public bool? IsExtended { get; set; }
        public int? ExtendedRows { get; set; }
        public double? AvailableVolume { get; set; }
        public int? UsedVolume { get; set; }
        public int? UniquePalletID { get; set; }
    }
}
