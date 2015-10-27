using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{   
    [Table("Account")]
    public class Account
    {   
        [Key][Column("ID")]
        public int AccountID { get; set; }
        public string Name  { get; set; }
        public int? ModeID { get; set; }
        public Guid? ModeGuid { get; set; }

        public bool? IsActive { get; set; }
        public Guid? rowguid { get; set; }
        public string AccountCode { get; set; }
        [Column("SN")]
        public int SerialNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
     
        public string ModifiedBy { get; set; }
        [ForeignKey("ModeID")]
        public Mode Mode { get; set; }
        
    }
}
