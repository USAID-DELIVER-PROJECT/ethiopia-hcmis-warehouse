using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class UserPaymentType
    {
        public int ID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> PaymentTypeID { get; set; }
        public Nullable<bool> CanAccess { get; set; }
        public Nullable<bool> IsDefault { get; set; }
        public virtual PaymentType PaymentType { get; set; }
        public virtual User User { get; set; }
    }
}
