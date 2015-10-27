using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("UserAdministrativeUnit")]
    public class UserAdministrativeUnit
    {
        [Key]
        public int UserAdministrativeUnitID { get; set; }
        public int UserID { get; set; }
        public int AdministrativeUnitID { get; set; }
        public int ActionID { get; set; }

    }
}
