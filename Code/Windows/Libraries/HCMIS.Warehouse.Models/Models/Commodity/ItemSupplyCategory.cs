using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("ItemSupplyCategory")]
    public class ItemSupplyCategory
    {
        [Key][Column("ID")]
        public int ItemSupplyCategoryID { get; set; }
        public int? ItemID { get; set; }
        public int? CategoryID { get; set; }

    }
}
