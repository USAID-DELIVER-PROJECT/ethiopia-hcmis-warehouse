using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class UserStore
    {
        public int ID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> StoreID { get; set; }
        public Nullable<bool> CanAccess { get; set; }
        public Nullable<bool> IsDefault { get; set; }
        public virtual Store Store { get; set; }
        public virtual User User { get; set; }
    }
}
