using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class Disposal
    {
        public int ID { get; set; }
        public Nullable<int> ItemID { get; set; }
        public Nullable<int> StoreId { get; set; }
        public Nullable<int> ReasonId { get; set; }
        public Nullable<long> Quantity { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string ApprovedBy { get; set; }
        public Nullable<bool> Losses { get; set; }
        public string BatchNo { get; set; }
        public string Remark { get; set; }
        public Nullable<double> Cost { get; set; }
        public string RefNo { get; set; }
        public Nullable<System.DateTime> EurDate { get; set; }
        public Nullable<int> RecID { get; set; }
        public virtual DisposalReason DisposalReason { get; set; }
        public virtual Item Item { get; set; }
    }
}
