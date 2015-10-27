using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class UnitofIssue
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public int QtyPerUnit { get; set; }
        public string Description { get; set; }
    }
}
