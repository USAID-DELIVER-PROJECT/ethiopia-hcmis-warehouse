using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class ProgramProduct
    {
        public int ID { get; set; }
        public Nullable<int> ProgramID { get; set; }
        public Nullable<int> ItemID { get; set; }
        public virtual Item Item { get; set; }
        public virtual Program Program { get; set; }
    }
}
