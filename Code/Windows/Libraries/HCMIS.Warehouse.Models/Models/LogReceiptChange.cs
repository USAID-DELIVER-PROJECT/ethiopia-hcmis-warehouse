using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("LogReceiptChange")]
    public class LogReceiptChange
    {
        [Key][Column("ID")]
        public int LogReceiptChangeID { get; set; }

        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public int? ChangedBy { get; set; }
        public DateTime? DateChanged { get; set; }
        public int? ReferenceID { get; set; }

    }
}
