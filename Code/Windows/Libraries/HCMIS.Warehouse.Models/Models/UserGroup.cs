using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("UserGroup")]
    public class UserGroup
    {
        [Key]
        public int UserGroupID { get; set; }
        public int UserID { get; set; }
        public int GroupID { get; set; }
        public bool? IsActive { get; set; }

    }
}
