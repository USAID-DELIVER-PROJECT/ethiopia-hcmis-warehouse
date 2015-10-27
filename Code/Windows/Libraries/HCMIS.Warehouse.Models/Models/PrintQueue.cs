using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("PrintQueue")]
    public class PrintQueue
    {
        [Key][Column("ID")]
        public int PrintQueueID { get; set; }

        public string DocumentType { get; set; }
        public byte[] Document { get; set; }
        public int Identifier { get; set; }
        public string Printer { get; set; }
        public bool? IsPrinted { get; set; }
        public int Attempts { get; set; }
        public int PageNo { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? PrintBy { get; set; }
        public DateTime? PrintDate { get; set; }
    }
}
