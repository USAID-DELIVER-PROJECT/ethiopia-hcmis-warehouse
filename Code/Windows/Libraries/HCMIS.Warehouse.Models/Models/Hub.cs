using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMIS.Warehouse.Models
{
    [Table("Hub", Schema = "MessageBroker")]
    public class Hub
    {
        [Key]
        public int HubID { get; set; }
        public string Name { get; set; }
        public Guid? rowguid { get; set; }
    }
}
