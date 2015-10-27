using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("IssueDocInventory")]
    public class IssueDocInventory
    {
        [Key]
        public int IssueDocID { get; set; }
        public int InventoryID { get; set; }

    }
}
