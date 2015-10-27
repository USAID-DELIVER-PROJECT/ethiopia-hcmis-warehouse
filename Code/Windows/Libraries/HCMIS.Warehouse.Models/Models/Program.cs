using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("Program")]
   public  class Program
    {
        [Key][Column("ID")]
        public int ProgramID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentID { get; set; }
        public string ProgramCode { get; set; }
        public bool? IsActive { get; set; }
        public Guid? rowguid { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        [Column("SN")]
        public int SerialNumber { get; set; }
    }
}
