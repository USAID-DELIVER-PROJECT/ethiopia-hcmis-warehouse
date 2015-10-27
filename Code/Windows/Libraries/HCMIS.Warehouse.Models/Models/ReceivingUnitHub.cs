using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("ReceivingUnitHub", Schema = "MessageBroker")]
    public class ReceivingUnitHub
    {
        [Key]
        public int ReceivingUnitHubID { get; set; }
        public int ReceivingUnitID { get; set; }
        public int HubID { get; set; }
    }
}
