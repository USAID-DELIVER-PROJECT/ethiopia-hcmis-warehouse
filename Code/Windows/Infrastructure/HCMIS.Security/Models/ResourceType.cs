using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace HCMIS.Security.Models
{
    [Table("ResourceType")]
    public class ResourceType
    {
        [Key]
        public int ResourceTypeID { get; set; }
        public string Name { get; set; }
    }
}
