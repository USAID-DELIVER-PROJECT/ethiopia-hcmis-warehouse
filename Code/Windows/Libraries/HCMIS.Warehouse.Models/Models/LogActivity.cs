using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("LogActivity")]
    public class LogActivity
    {
        [Key][Column("LogID")]
        public int LogActivityID { get; set; }

        public int ActivityID { get; set; }
        public string HostName { get; set; }
        public string IPAddress { get; set; }
        public DateTime OccuranceDate { get; set; }
        public string Page { get; set; }
        public string ActivityName { get; set; }
        public string ClassName { get; set; }
    }
}
