using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("PO", Schema = "dbo")]
    public class PO
    {
        [Key][Column("ID")]
        public int POID { get; set; }

        public string PONumber { get; set; }
        public string LetterNo { get; set; }
        public int? SupplierID { get; set; }
        [Column("StoreID")]
        public int? ActivityID { get; set; }

        public DateTime? DateOfEntry { get; set; }
        public int? SavedByUserID { get; set; }
        public double? TotalValue { get; set; }
        public double? Insurance { get; set; }
        public double? AirFreight { get; set; }
        public double? SeaFreight { get; set; }
        public double? InlandFreight { get; set; }
        public double? NBE { get; set; }
        public double? CBE { get; set; }
        public double? CustomDutyTax { get; set; }
        public double? TransitServiceCharge { get; set; }
        public double? Provision { get; set; }
        public double? OtherExpense { get; set; }
        [Column("ExhangeRate")]
        public double ExchangeRate { get; set; }

        public string Description { get; set; }
        public int? PurchaseType { get; set; }
        [Column("RefNo")]
        public string ReferenceNumber { get; set; }

        public string Delivery { get; set; }
        public string Currency { get; set; }
        public int? LCID { get; set; }
        public int? TermOfPayment { get; set; }
        public DateTime? PODate { get; set; }
    }
}
