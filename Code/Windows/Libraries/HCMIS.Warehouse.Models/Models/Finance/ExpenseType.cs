using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("ExpenseType", Schema = "Finance")]
    public class ExpenseType
    {
        [Key]
        public int ExpenseTypeID { get; set; }
        public string Name { get; set; }
        public string ExpenseTypeCode { get; set; }
        public string Description { get; set; }
    }
}
