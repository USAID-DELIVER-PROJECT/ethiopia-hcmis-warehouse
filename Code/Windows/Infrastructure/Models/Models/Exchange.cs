using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class Exchange
    {
        public int ID { get; set; }
        public Nullable<int> ItemID { get; set; }
        public Nullable<int> ExchageTypeID { get; set; }
        public Nullable<int> From { get; set; }
        public Nullable<int> To { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> RecIDIssued { get; set; }
        public Nullable<int> RecIDReceived { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    }
}
