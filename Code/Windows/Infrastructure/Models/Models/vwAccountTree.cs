using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class vwAccountTree
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string TextID { get; set; }
        public string Name { get; set; }
        public string ParentID { get; set; }
        public int Ordering { get; set; }
    }
}
