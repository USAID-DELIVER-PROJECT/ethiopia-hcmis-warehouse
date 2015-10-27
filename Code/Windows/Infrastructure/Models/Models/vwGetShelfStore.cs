using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class vwGetShelfStore
    {
        public string ShelfCode { get; set; }
        public int ID { get; set; }
        public string ShelfType { get; set; }
        public Nullable<int> StoreID { get; set; }
    }
}
