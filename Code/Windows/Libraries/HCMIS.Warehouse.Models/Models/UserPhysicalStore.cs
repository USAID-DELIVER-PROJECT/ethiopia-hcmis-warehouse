using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("UserPhysicalStore")]
    public class UserPhysicalStore
    {
        [Key][Column("ID")]
        public int UserPhysicalStoreID { get; set; }

        public int? UserID { get; set; }
        public int? PhysicalStoreID { get; set; }
        public bool? CanAccess { get; set; }
        public bool? IsDefault { get; set; }
    }
}
