using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class TransferType
    {
        public TransferType()
        {
            this.Transfers = new List<Transfer>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<Transfer> Transfers { get; set; }
    }
}
