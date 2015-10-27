using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class DosageForm
    {
        public int ID { get; set; }
        public string Form { get; set; }
        public string Description { get; set; }
        public Nullable<int> TypeID { get; set; }
    }
}
