using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class ReceiptType
    {
        public ReceiptType()
        {
            this.Receipts = new List<Receipt>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}
