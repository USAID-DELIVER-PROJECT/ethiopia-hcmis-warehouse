using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Security.Models
{
    [Table("MenuItem")]
    public class MenuItem
    {        
        [Key]
        public int MenuItemID { get; set; }
        public string Text { get; set; }
        public string URL { get; set; }

        [ForeignKey("ResourceType")]
        public int ResourceTypeID { get; set; }
        [MaxLength(50)]
        public string Icon { get; set; }
        public string ToolTip { get; set; }
        [Column("Order")]
        public int Order { get; set; }
        [ForeignKey("Parent")]
        public int? ParentID { get; set; }

        public virtual MenuItem Parent { get; set; }
        public virtual ICollection<MenuItemGroup> MenuItemGroups { get; set; }
        public virtual ResourceType ResourceType { get; set; }
        public virtual ICollection<Operation> Operations { get; set; } 
     
        [NotMapped]
        public string Name
        {
            get
            {
                return this.Text.Replace("&", "");
            }
        }
    }
}