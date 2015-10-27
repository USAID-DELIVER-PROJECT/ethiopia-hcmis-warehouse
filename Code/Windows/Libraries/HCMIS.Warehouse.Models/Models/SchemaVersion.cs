using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("SchemaVersion")]
    public class SchemaVersion
    {
        [Key]
        [Column("ID")]
        public int SchemaVersionID { get; set; }

        [Column("SchemaVersion")]
        public string Schemaversion { get; set; }

        public int SerialNumber { get; set; }
        public DateTime? RunDate { get; set; }
    }
}
