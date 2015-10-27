using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("Audit")]
    public class Audit
    {
        public char? Type { get; set; }
        public string TableName { get; set; }
        public string PK { get; set; }
        public string FieldName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserName { get; set; }

    }
}
