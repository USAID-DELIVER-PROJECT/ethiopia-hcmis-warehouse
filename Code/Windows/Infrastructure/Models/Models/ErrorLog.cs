using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class ErrorLog
    {
        public long ID { get; set; }
        public string StatusCode { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<System.DateTime> Time { get; set; }
        public string Details { get; set; }
        public virtual User User { get; set; }
    }
}
