using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class ReceiptConfirmationStatu
    {
        public ReceiptConfirmationStatu()
        {
            this.ReceiveDocConfirmations = new List<ReceiveDocConfirmation>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ReceiveDocConfirmation> ReceiveDocConfirmations { get; set; }
    }
}
