using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("Order")]
     public class Order
    {
        [Key]
        [Column("ID")]
        public int OrderID { get; set; }
     
        public int OrderStatusID { get; set; }
        [Column("RequestedBy")]
        public int? InstitutionID { get; set; }
        [Column("Date")]
        public DateTime? OrderDate { get; set; }
        public DateTime? EurDate { get; set; }
        [Column("RefNo")]
        public string ReferenceNumber { get; set; }
        public string Remark { get; set; }
        [Column("FromStore")]
        public int? ModeID { get; set; }
        public int? FromHCTS { get; set; }
        public bool? ConfirmedToHCTS { get; set; }
        public bool? HCTSReferenceID { get; set; }
        public int? PaymentTypeID { get; set; }
        public int FilledBy { get; set; }
        public int? ApprovedBy { get; set; }
        public string ContactPerson { get; set; }
        public int? OrderTypeID { get; set; }
        public int FiscalYearID { get; set; }

    }
}
