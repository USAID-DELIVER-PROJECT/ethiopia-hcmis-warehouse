using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class PaymentType
    {
        public PaymentType()
        {
            this.UserPaymentTypes = new List<UserPaymentType>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserPaymentType> UserPaymentTypes { get; set; }
    }
}
