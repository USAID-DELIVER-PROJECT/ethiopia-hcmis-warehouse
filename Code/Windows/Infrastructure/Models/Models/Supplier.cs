using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class Supplier
    {
        public Supplier()
        {
            this.ItemSuppliers = new List<ItemSupplier>();
            this.POes = new List<PO>();
            this.ReceiptConfirmationPrintouts = new List<ReceiptConfirmationPrintout>();
            this.ReceiveDocs = new List<ReceiveDoc>();
        }

        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string ContactPerson { get; set; }
        public string Mobile { get; set; }
        public string CompanyInfo { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string Email { get; set; }
        public virtual ICollection<ItemSupplier> ItemSuppliers { get; set; }
        public virtual ICollection<PO> POes { get; set; }
        public virtual ICollection<ReceiptConfirmationPrintout> ReceiptConfirmationPrintouts { get; set; }
        public virtual ICollection<ReceiveDoc> ReceiveDocs { get; set; }
    }
}
