using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class vwIssueDoc
    {
        public Nullable<int> ItemID { get; set; }
        public string BatchNo { get; set; }
        public Nullable<long> Quantity { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string LocalBatchNo { get; set; }
        public string RefNo { get; set; }
        public Nullable<int> StoreId { get; set; }
        public int ID { get; set; }
        public Nullable<System.DateTime> EurDate { get; set; }
    }
}
