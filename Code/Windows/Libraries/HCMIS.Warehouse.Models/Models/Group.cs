using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("Group")]
    public class Group
    {
        [Key]
        public int GroupID { get; set; }

        public string Name { get; set; }
        public int? ParentID { get; set; }
        public bool? IsActive { get; set; }
        public Guid? rowguid { get; set; }
        public string GroupCode { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        [Column("SN")]
        public int SerialNumber { get; set; }
    }
}
