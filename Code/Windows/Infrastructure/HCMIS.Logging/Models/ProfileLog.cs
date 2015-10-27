using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Logging.Models
{
    [Table("LogProfile")]
    public class ProfileLog : Log
    {
        public string Page { get; set; }
        public string Action { get; set; }
        public Guid OperationID { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
