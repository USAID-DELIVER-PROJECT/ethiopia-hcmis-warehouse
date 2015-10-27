using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("LogRequisitionEvents")]
    public class LogRequisitionEvents
    {
        [Key][Column("ID")]
        public int LogRequisitionEventsID { get; set; }

        public Guid? Identifier { get; set; }
        public int? RequisitionID { get; set; }
        public char? EventName { get; set; }
        public char? EventDescription { get; set; }
        public int? UserID { get; set; }
        public string ByUserName { get; set; }
        public DateTime? EventTime { get; set; }

    }
}
