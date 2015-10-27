using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMIS.Warehouse.Models
{
    [Table("RackStatus")]
    public class RackStatus
    {
        [Key][Column("ID")]
        public int RackStatusID { get; set; }

        public string Status { get; set; }
        public string Description { get; set; }

    }
}
