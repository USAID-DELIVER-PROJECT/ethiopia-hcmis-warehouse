using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace HCMIS.Security.Models
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; } 
    }
}
