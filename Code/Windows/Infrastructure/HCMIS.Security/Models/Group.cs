using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using HCMIS.Security.Common;

namespace HCMIS.Security.Models
{
    [Table("Group")]
    public class Group : IGroup
    {
        [Key]
        public int GroupID { get; set; }
        public string Name { get; set; }
        [ForeignKey("Parent")]
        public int? ParentID { get; set; }

        public virtual Group Parent { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }
        public virtual ICollection<GroupPermission> GroupPermissions { get; set; }
        public virtual ICollection<MenuItemGroup> MenuItemGroups { get; set; }
    }
}
