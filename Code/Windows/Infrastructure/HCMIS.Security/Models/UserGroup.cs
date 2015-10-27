using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace HCMIS.Security.Models
{
    [Table("UserGroup")]
    public class UserGroup
    {
        [Key]
        public int UserGroupID { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        [ForeignKey("Group")]
        public int GroupID { get; set; }
        [Column("IsActive")]
        public bool? GroupStatus { get; set; }

        public virtual User User { get; set; }
        public virtual Group Group { get; set; }
    }
}
