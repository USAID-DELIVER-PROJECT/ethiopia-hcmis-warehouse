using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("ItemCategory")]
    public class ItemCategory
    {
        [Key][Column("ID")]
        public int ItemCategoryID { get; set; }
        public int SubCategoryID { get; set; }
        public int? ItemID { get; set; }

    }
}
