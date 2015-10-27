using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("SubCategory")]
    public class SubCategory
    {
        [Key][Column("ID")]
        public int SubCategoryID { get; set; }
        [Column("CategoryId")]
        public int? CategoryID { get; set; }

        public string SubCategoryName { get; set; }
        public string SubCategoryCode { get; set; }
        public string Description { get; set; }
        public int? ParentID { get; set; }
    }
}
