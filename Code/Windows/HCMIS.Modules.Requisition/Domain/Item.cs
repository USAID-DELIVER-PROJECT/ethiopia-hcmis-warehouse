using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Modules.Requisition.Domain
{
    public class Item
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string StockCode { get; set; }
    }
}
