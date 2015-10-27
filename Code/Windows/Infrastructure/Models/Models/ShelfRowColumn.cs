using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class ShelfRowColumn
    {
        public int ID { get; set; }
        public string Label { get; set; }
        public Nullable<int> ShelfID { get; set; }
        public Nullable<int> Index { get; set; }
        public Nullable<double> Dimension { get; set; }
        public string Type { get; set; }
        public virtual Shelf Shelf { get; set; }
    }
}
