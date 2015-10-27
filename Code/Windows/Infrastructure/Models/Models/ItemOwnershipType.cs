using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class ItemOwnershipType
    {
        public int ID { get; set; }
        public Nullable<int> ItemID { get; set; }
        public Nullable<int> RUOwnershipTypeID { get; set; }
        public Nullable<bool> AllowFully { get; set; }
        public Nullable<bool> Warning { get; set; }
        public Nullable<bool> Restriction { get; set; }
        public Nullable<long> MaxIssueQty { get; set; }
        public Nullable<int> MaxIssueQtyGapDays { get; set; }
        public virtual Item Item { get; set; }
        public virtual RUOwnershipType RUOwnershipType { get; set; }
    }
}
