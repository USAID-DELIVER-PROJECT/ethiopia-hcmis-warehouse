using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("LogAppError")]
    public class LogAppError
    {
        [Key][Column("ID")]
        public int LogAppErrorID { get; set; }

        public string StatusCode { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
        public int? UserID { get; set; }
        public DateTime? Time { get; set; }
        public string Details { get; set; }
    }
}
