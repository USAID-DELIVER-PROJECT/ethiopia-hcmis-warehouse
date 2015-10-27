using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("Category")]
    public class Category
    {
        [Key][Column("ID")]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryCode { get; set; }
        public string Description { get; set; }

    }
}
