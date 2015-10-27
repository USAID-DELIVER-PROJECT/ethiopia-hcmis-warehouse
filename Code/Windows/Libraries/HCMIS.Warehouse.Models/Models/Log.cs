using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("Log")]
    public class Log
    {
        [Key]
        public int LogID { get; set; }
        public int UserID { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
