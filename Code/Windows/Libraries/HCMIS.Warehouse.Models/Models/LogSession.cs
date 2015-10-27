using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("LogSession")]
    public class LogSession
    {
        [Key][Column("LogID")]
        public int LogSessionID { get; set; }
        public Guid SessionID { get; set; }
        public DateTime? EndTime { get; set; }
        public string IPAddress { get; set; }
        public string VPNIP { get; set; }

    }
}
