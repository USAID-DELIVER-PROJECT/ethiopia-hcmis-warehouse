using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("Shelf")]
    public class Shelf
    {
        [Key][Column("ID")]
        public int ShelfID { get; set; }

        [Column("StoreID")]
        public int? ActivityID { get; set; }

        public string ShelfCode { get; set; }
        public string ShelfType { get; set; }
        public int? Rows { get; set; }
        public int? Columns { get; set; }
        public double? CoordinateX { get; set; }
        public double? CoordinateY { get; set; }
        public double? Rotation { get; set; }
        public double? Width { get; set; }
        public double? Length { get; set; }
        public double? Height { get; set; }
        public int ShelfStorageType { get; set; }
    }
}
