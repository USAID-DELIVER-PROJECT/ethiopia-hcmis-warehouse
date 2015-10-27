using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("JEventCoreAccount", Schema = "Core")]
     public class JEventCoreAccount
    {
        [Key]
        public int JEventCoreAccountID { get; set; }
        public int JEventID { get; set; }
        public int CoreAccountID { get; set; }

        }
}
