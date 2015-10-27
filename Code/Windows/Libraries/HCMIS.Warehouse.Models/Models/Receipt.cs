using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("Receipt")]
    public class Receipt
    {
        [Key][Column("ID")]
        public int ReceiptID { get; set; }
        public DateTime? DateOfEntry { get; set; }
        public int? ReceiptTypeID { get; set; }
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
        public double? POID { get; set; }
        public string WayBillNo { get; set; }
        public string TransitTransferNo { get; set; }
        public string InsurancePolicyNo { get; set; }
        public string STVOrInvoiceNo { get; set; }
        public int? ReceiptInvoiceID { get; set; }
        public int? WareHouseID { get; set; }
        public int? ReceiptStatusID { get; set; }

       
       }
}
