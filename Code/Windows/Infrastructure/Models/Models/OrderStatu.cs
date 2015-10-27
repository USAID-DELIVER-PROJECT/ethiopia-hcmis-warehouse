using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class OrderStatu
    {
        public OrderStatu()
        {
            this.Orders = new List<Order>();
        }

        public int ID { get; set; }
        public string OrderStatus { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
