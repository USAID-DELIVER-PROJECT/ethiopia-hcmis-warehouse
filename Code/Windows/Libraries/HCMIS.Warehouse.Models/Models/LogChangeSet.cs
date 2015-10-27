using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("logchangeset")]
   public class LogChangeSet
    {
        [Key]
        [Column("id")]
        public int LogChangeSetID { get; set; }

        public int? SessionID { get; set; }
    
        public string UserName { get; set; }
    
        public string AppName { get; set; }
       
        public string HostName { get; set; }
       
        public DateTime? UpdateDate { get; set; }

    
    }
}
