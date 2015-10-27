using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("VEN")]
    public class VEN
    {
        [Key]
        [Column("ID")]
        public int VENID { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public string VENCode { get; set; }
        public bool IsActive { get; set; }
        public Guid rowguid { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        [Column("SN")]
        public int SerialNumber { get; set; }
        public string ModifiedBy { get; set; }
    }
}
