using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class Program
    {
        public Program()
        {
            this.ProgramProducts = new List<ProgramProduct>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> ParentID { get; set; }
        public string ProgramCode { get; set; }
        public virtual ICollection<ProgramProduct> ProgramProducts { get; set; }
    }
}
