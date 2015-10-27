using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HCMIS.Security.Models
{
    [Table("GroupPermission")]
    public class GroupPermission
    {
        [Key]
        public int GroupPermissionID { get; set; }
        [ForeignKey("Group")]
        public int GroupID { get; set; }
        [ForeignKey("Operation")]
        public int OperationID { get; set; }
        public bool Allow { get; set; }
        
        public virtual Group Group { get; set; }
        public virtual Operation Operation { get; set; }

    }
}
