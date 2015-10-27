using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class ChangeLog
    {
        public int ID { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public Nullable<int> ChangedBy { get; set; }
        public Nullable<System.DateTime> DateChanged { get; set; }
        public Nullable<int> RefID { get; set; }
        public virtual User User { get; set; }
    }
}
