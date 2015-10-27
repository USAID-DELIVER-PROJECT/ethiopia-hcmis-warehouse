using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("LogLogin")]
    public class LogLogin
    {
        [Key][Column("ID")]
        public int LogLoginID { get; set; }
        public int? UserID { get; set; }
        public DateTime? LoginTime { get; set; }
        public bool? SuccessfulLogin { get; set; }
        public DateTime? LogOffTime { get; set; }
        public string HostName { get; set; }
        public string IPAddress { get; set; }
        public string MACAddress { get; set; }
        public bool? UnknownUser { get; set; }
        public string UnknownUserName { get; set; }
        public string ApplicationVersion { get; set; }

    }
}
