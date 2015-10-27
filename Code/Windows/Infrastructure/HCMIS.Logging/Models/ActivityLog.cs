using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Logging.Models
{
    [Table("LogActivity")]
    public class ActivityLog : Log
    {
        public int ActivityID { get; set; }
        public string HostName { get; set; }
        public string IPAddress { get; set; }
        public DateTime OccuranceDate { get; set; }
        public string Page { get; set; }
        public string ActivityName { get; set; }
        public string ClassName { get; set; }
        
    }
}
