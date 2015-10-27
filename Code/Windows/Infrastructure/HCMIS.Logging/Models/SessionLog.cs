using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Logging.Models
{
    [Table("LogSession")]
    public class SessionLog : Log
    {
        public Guid SessionID { get; set; }
        public DateTime? EndTime { get; set; }

        public string IPAddress { get; set; }
        public string VPNIP { get; set; }

    }
}
