using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("DirectoryUpdates")]
    public class DirectoryUpdates
    {
        [Key]
        public string ServerName   { get; set; }
        public DateTime? LastCalled { get; set; }
    }
}
