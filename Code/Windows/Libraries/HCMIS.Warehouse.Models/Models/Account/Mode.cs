using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("Mode")]
    public class Mode
    {
        [Key][Column("ID")]
        public int ModeID { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public Guid rowguid { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModeCode { get; set; }
        [Column("SN")]
        public int SerialNumber { get; set; }
    }
}
