using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class Receipt
    {
        public Receipt()
        {
            this.ReceiptConfirmationPrintouts = new List<ReceiptConfirmationPrintout>();
            this.ReceiveDocs = new List<ReceiveDoc>();
        }

        public int ID { get; set; }
        public Nullable<System.DateTime> DateOfEntry { get; set; }
        public Nullable<int> ReceiptTypeID { get; set; }
        public Nullable<int> SavedByUserID { get; set; }
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
        public Nullable<double> POID { get; set; }
        public string WayBillNo { get; set; }
        public string TransitTransferNo { get; set; }
        public string InsurancePolicyNo { get; set; }
        public string STVOrInvoiceNo { get; set; }
        public Nullable<int> ReceiptInvoiceID { get; set; }
        public virtual ReceiptInvoice ReceiptInvoice { get; set; }
        public virtual ReceiptType ReceiptType { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<ReceiptConfirmationPrintout> ReceiptConfirmationPrintouts { get; set; }
        public virtual ICollection<ReceiveDoc> ReceiveDocs { get; set; }
    }
}
