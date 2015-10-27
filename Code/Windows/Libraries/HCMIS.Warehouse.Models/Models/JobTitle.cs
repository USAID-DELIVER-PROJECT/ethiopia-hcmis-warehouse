using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("JobTitle")]
   public class JobTitle
    {
        [Key][Column("ID")]
        public int JobTitleID { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public Guid? rowguid { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        [Column("SN")]
        public int SerialNumber { get; set; }
    }
}
