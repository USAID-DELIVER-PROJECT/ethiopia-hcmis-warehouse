using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class ReceiptInvoice
    {
        public ReceiptInvoice()
        {
            this.Receipts = new List<Receipt>();
        }

        public int ID { get; set; }
        public Nullable<int> InvoiceTypeID { get; set; }
        public string STVOrInvoiceNo { get; set; }
        public string WayBillNo { get; set; }
        public string TransitTransferNo { get; set; }
        public string InsurancePolicyNo { get; set; }
        public Nullable<System.DateTime> DateOfEntry { get; set; }
        public Nullable<int> ReceiptInvoiceType { get; set; }
        public Nullable<double> TotalValue { get; set; }
        public Nullable<double> Insurance { get; set; }
        public Nullable<double> AirFreight { get; set; }
        public Nullable<double> SeaFreight { get; set; }
        public Nullable<double> InlandFreight { get; set; }
        public Nullable<double> NBE { get; set; }
        public Nullable<double> CBE { get; set; }
        public Nullable<double> CustomDutyTax { get; set; }
        public Nullable<double> TransitServiceCharge { get; set; }
        public Nullable<double> Provision { get; set; }
        public Nullable<double> OtherExpense { get; set; }
        public Nullable<double> ExchangeRate { get; set; }
        public Nullable<int> SavedByUserID { get; set; }
        public Nullable<int> POID { get; set; }
        public string Currency { get; set; }
        public Nullable<int> LCID { get; set; }
        public virtual PO PO { get; set; }
        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}
