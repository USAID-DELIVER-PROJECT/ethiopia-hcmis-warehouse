using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("UserPaymentType")]
    public class UserPaymentType
    {
        [Key][Column("ID")]
        public int UserPaymentTypeID { get; set; }
        public int? UserID { get; set; }
        public int? PaymentTypeID { get; set; }
        public bool? CanAccess { get; set; }
        public bool? IsDefault { get; set; }
    }
}
