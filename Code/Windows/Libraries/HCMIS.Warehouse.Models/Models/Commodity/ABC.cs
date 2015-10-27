using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("ABC")]
    public class ABC
    {
        [Key][Column("ID")]
        public int AbcID { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public string ABCCode { get; set; }
        public bool IsActive { get; set; }
        
        public Guid rowguid { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        [Column("SN")]
        public int SerialNumber { get; set; }
        public string ModifiedBy { get; set; }
    }
}
