using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class ItemUnitCopy
    {
        public int ID { get; set; }
        public int ItemID { get; set; }
        public int QtyPerUnit { get; set; }
        public string Text { get; set; }
    }
}
