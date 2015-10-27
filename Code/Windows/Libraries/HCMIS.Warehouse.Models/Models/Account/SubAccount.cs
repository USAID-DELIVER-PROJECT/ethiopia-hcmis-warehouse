using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("SubAccount")]
    public class SubAccount
    {
        [Key,Column("ID")]
        public int SubAccountID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? AccountID { get; set; }
        public Guid? AccountGuid { get; set; }
        public bool? IsActive { get; set; }
        public Guid? rowguid { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        [Column("SN")]
        public int SerialNumber { get; set; }
        [ForeignKey("AccountID")]
        public Account Account { get; set; }
    }
}
