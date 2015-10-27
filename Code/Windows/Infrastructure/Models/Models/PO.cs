using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class PO
    {
        public PO()
        {
            this.ReceiptInvoices = new List<ReceiptInvoice>();
        }

        public int ID { get; set; }
        public string PONumber { get; set; }
        public string LetterNo { get; set; }
        public Nullable<int> SupplierID { get; set; }
        public Nullable<int> StoreID { get; set; }
        public Nullable<System.DateTime> DateOfEntry { get; set; }
        public Nullable<int> SavedbyUserID { get; set; }
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
        public Nullable<double> ExhangeRate { get; set; }
        public string Description { get; set; }
        public Nullable<int> PurchaseType { get; set; }
        public string RefNo { get; set; }
        public string Delivery { get; set; }
        public string Currency { get; set; }
        public Nullable<int> LCID { get; set; }
        public Nullable<int> TermOfPayement { get; set; }
        public Nullable<System.DateTime> PODate { get; set; }
        public virtual Store Store { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<ReceiptInvoice> ReceiptInvoices { get; set; }
    }
}
