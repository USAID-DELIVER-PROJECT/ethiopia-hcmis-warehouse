using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("UserType")]
    public class UserType
    {
        [Key][Column("ID")]
        public int UserTypeID { get; set; }
        public string Type { get; set; }
    }
}
