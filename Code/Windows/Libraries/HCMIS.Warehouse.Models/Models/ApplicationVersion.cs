using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("ApplicationVersion")]
    public class ApplicationVersion
    {
        [Key][Column("ID")]
        public int ApplicationVersionID { get; set; }
        public string Applicationversion { get; set; }
        public int SerialNumber { get; set; }
        public int? MinSchemaVersion { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string ReleaseNotes { get; set; }

    }
}
