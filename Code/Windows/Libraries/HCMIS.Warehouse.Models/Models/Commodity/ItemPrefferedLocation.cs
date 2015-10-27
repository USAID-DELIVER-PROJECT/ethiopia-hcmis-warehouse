using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("ItemPrefferedLocation")]
    public class ItemPrefferedLocation
    {
        [Key][Column("ID")]
        public int ItemPrefferedLocationID { get; set; }
        public int? ItemID { get; set; }
        public int? PalletLocationID { get; set; }
        public bool? IsFixed { get; set; }

    }
}
