using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("LogPrint")]
    public class LogPrint
    {
        [Key][Column("ID")]
        public int LogPrintID { get; set; }
        public string Type { get; set; }
        public string Printer { get; set; }
        public byte[] Value  { get; set; }
        public DateTime? PrintedDate { get; set; }
        public bool? IsPrinted { get; set; }
        public int PrintedBy { get; set; }
        public int Reference { get; set; }

    }
}
