using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class vwAccount
    {
        public int ActivityID { get; set; }
        public string ActivityName { get; set; }
        public Nullable<int> SubAccountID { get; set; }
        public string SubAccountName { get; set; }
        public int AccountID { get; set; }
        public string AccountName { get; set; }
        public Nullable<int> ModeID { get; set; }
    }
}
