using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class VEN
    {
        public VEN()
        {
            this.Items = new List<Item>();
        }

        public int ID { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
