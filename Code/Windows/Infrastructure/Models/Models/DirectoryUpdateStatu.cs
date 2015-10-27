using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class DirectoryUpdateStatu
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<int> LastVersion { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
    }
}
