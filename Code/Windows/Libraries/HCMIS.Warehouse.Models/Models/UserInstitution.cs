using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("UserInstitution")]
    public class UserInstitution
    {
        [Key]
        public int UserInstitutionID { get; set; }
        public int UserID { get; set; }
        public int InstitutionID { get; set; }
        public int ActionID { get; set; }

    }
}
