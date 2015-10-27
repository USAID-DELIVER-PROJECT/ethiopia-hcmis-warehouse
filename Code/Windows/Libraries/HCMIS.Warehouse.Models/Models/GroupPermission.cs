using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("GroupPermission")]
    public class GroupPermission
    {
        [Key]
        public int GroupPermissionID { get; set; }
        public int GroupID { get; set; }
        public int OperationID { get; set; }
        public bool Allow { get; set; }

    }
}
