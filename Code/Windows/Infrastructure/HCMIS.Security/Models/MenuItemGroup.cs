using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HCMIS.Security.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Security.Models
{
    [Table("MenuItemGroup")]
    public class MenuItemGroup
    {
        public int MenuItemGroupID { get; set; }
        [ForeignKey("Group")]
        public int GroupID { get; set; }
        [ForeignKey("MenuItem")]
        public int MenuItemID { get; set; }

        public virtual MenuItem MenuItem { get; set; }
        public virtual Group Group { get; set; }
    }
}