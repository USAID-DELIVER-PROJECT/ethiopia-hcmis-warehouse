using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using HCMIS.Security.Common;

namespace HCMIS.Security.Models
{
    [Table("UserPermission")]
    public class UserPermission
    {
        [Key]
        public int UserPermissionID { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        [ForeignKey("Operation")]
        public int OperationID { get; set; }
        public bool Allow { get; set; }

        public virtual User User { get; set; }
        public virtual Operation Operation { get; set; }

        
    }
}
