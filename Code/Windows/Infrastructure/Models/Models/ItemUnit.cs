using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class ItemUnit
    {
        public ItemUnit()
        {
            this.OrderDetails = new List<OrderDetail>();
            this.PickListDetails = new List<PickListDetail>();
            this.ReceiveDocs = new List<ReceiveDoc>();
            this.YearEnds = new List<YearEnd>();
        }

        public int ID { get; set; }
        public int ItemID { get; set; }
        public int QtyPerUnit { get; set; }
        public string Text { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<PickListDetail> PickListDetails { get; set; }
        public virtual ICollection<ReceiveDoc> ReceiveDocs { get; set; }
        public virtual ICollection<YearEnd> YearEnds { get; set; }
    }
}
