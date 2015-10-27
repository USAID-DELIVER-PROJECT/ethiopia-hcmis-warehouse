using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class ShortageReason
    {
        public ShortageReason()
        {
            this.ReceiveDocs = new List<ReceiveDoc>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ReceiveDoc> ReceiveDocs { get; set; }
    }
}
