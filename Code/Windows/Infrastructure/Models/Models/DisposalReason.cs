using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class DisposalReason
    {
        public DisposalReason()
        {
            this.Disposals = new List<Disposal>();
        }

        public int ID { get; set; }
        public string Reason { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Disposal> Disposals { get; set; }
    }
}
