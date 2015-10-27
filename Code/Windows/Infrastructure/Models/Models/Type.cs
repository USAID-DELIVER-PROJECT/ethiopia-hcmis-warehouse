using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class Type
    {
        public Type()
        {
            this.Products = new List<Product>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
