using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("DirectoryUpdateStatus")]
    public class DirectoryUpdateStatus
    {
        [Key][Column("ID")]
        public int DirectoryUpdateStatusID { get; set; }
        public string Name { get; set; }
        public int? LastVersion { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
