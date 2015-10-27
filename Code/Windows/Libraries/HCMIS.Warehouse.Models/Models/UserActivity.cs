using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("UserActivity")]
    public class UserActivity
    {
        [Key][Column("ID")]
        public int UserActivityID { get; set; }

        public int? UserID { get; set; }
        public int? ActivityID { get; set; }
        public bool? CanAccess { get; set; }
        public bool? IsDraft { get; set; }
    }
}
