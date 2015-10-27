using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("LogProfile")]
    public class LogProfile
    {
        [Key][Column("LogID")]
        public int LogProfileID { get; set; }

        public string Page { get; set; }
        public string Action { get; set; }
        [Column("OperationID")]
        public Guid OperationGuid { get; set; }

        public DateTime? EndTime { get; set; }
    }
}
