using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("Action")]
    public class Action
    {
        [Key]
        public int ActionID { get; set; }
        public string Name { get; set; }
        public string ActionCode { get; set; }
        public bool? IsActive { get; set; }
        public Guid? rowguid { get; set; }
    }
}
