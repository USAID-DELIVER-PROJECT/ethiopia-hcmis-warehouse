using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using HCMIS.Security.Common;

namespace HCMIS.Security.Models
{
    [Table("Operation")]
    public class Operation : IOperation
    {
        [Key]
        public int OperationID { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [ForeignKey("MenuItem")]
        public int MenuItemID { get; set; }

        public string Description { get; set; }

       
        public virtual ICollection<GroupPermission> GroupPermissions { get; set; }
        public virtual MenuItem MenuItem { get; set; }
    }
}
