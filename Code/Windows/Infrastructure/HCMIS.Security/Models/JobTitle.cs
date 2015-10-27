using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace HCMIS.Security.Models
{
    [Table("JobTitle")]
    public class JobTitle
    {
        [Key]
        public int JobTitleID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
