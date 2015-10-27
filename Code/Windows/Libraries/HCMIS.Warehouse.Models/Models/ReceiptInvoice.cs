using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMIS.Warehouse.Models
{
    [Table("ReceiptInvoice")]
    public class ReceiptInvoice
    {
        [Key][Column("ID")]
        public int ReceiptInvoiceID { get; set; }

        public int? InvoiceTypeID { get; set; }
        public string STVOrInvoiceNo { get; set; }
        public string WayBillNo { get; set; }
        public string TransitTransferNo { get; set; }
        public string InsurancePolicyNo { get; set; }
        public DateTime? DateOfEntry { get; set; }
        public int? ReceiptInvoiceType { get; set; }
        public double? TotalValue { get; set; }
        public double? Insurance { get; set; }
        public double? AirFreight  { get; set; }
        public double? SeaFreight { get; set; }
        public double? InlandFreight { get; set; }
        public double? NBE { get; set; }
        public double? CBE { get; set; }
        public double? CustomDutyTax { get; set; }
        public double? TransitServiceCharge { get; set; }
        public double? Provision { get; set; }
        public double? OtherExpense { get; set; }
        public double? ExchangeRate { get; set; }
        public int? SavedByUserID { get; set; }
        public int? POID { get; set; }
        public string Currency { get; set; }
        public int? LCID { get; set; }

    }
}
