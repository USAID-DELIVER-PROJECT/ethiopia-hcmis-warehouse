using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("SupplyCategory")]
    public class SupplyCategory
    {
        [Key][Column("ID")]
        public int SupplyCategoryID { get; set; }

        public string Name { get; set; }
        [Column("ParentId")]
        public int? ParentID { get; set; }

        public string Code { get; set; }
    }
}
