using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("ModePaymentType")]
    public class ModePaymentType
    {
        [Key][Column("ID")]
        public int ModePaymentTypeID { get; set; }
        public int ModeID { get; set; }
        public Guid? ModeGuid { get; set; }
        public int PaymentTypeID { get; set; }
        public Guid? PaymentTypeGuid { get; set; }

    }
}
