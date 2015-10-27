using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("ChangeSetAnchor")]
    public class ChangeSetAnchor
    {
        [Key]
        public int ChangeSetAnchorID { get; set; }
        public int? AnchorValue { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string TableName { get; set; }
        public int? InsertedRows { get; set; }
        public int? UpdatedRows { get; set; }
    }
}
