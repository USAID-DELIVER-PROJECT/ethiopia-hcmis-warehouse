using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class Unit
    {
        public Unit()
        {
            this.Items = new List<Item>();
        }

        public int ID { get; set; }
        public string Unit1 { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
