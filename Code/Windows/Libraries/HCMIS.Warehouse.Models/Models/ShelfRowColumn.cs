using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("ShelfRowColumn")]
    public class ShelfRowColumn
    {
        [Key][Column("ID")]
        public int ShelfRowColumnID { get; set; }

        public string Label { get; set; }
        public int? ShelfID { get; set; }
        public int? Index { get; set; }
        public double? Dimension { get; set; }
        public string Type { get; set; }
    }
}
