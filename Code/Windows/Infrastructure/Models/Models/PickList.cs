using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class PickList
    {
        public PickList()
        {
            this.PickListDetails = new List<PickListDetail>();
        }

        public int ID { get; set; }
        public Nullable<int> OrderID { get; set; }
        public string PickType { get; set; }
        public Nullable<System.DateTime> IssuedDate { get; set; }
        public Nullable<bool> IsConfirmed { get; set; }
        public string Remark { get; set; }
        public Nullable<System.DateTime> SavedDate { get; set; }
        public Nullable<System.DateTime> PickedDate { get; set; }
        public Nullable<int> PickedBy { get; set; }
        public Nullable<int> PrintedBy { get; set; }
        public virtual Order Order { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<PickListDetail> PickListDetails { get; set; }
    }
}
