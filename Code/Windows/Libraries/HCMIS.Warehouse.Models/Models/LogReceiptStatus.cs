using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("LogReceiptStatus")]
    public class LogReceiptStatus
    {
        public int LogReceiptStatusID { get; set; }
        public int ReceiptID { get; set; }
        public DateTime StatusChangedDate { get; set; }
        public int? FromStatusID { get; set; }
        public int? ToStatusID { get; set; }
        public int? ReceiptConfirmationPrintoutID { get; set; }
        public int? URL { get; set; }
        public int? UserID { get; set; }
        public string ActionIdentifier { get; set; }
        public string Description { get; set; }
    }
}
