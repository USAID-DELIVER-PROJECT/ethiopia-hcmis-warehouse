using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class ReceivePallet
    {
        public ReceivePallet()
        {
            this.PickListDetails = new List<PickListDetail>();
        }

        public int ID { get; set; }
        public Nullable<int> ReceiveID { get; set; }
        public Nullable<int> PalletID { get; set; }
        public Nullable<long> ReceivedQuantity { get; set; }
        public Nullable<long> Balance { get; set; }
        public int ReservedStock { get; set; }
        public Nullable<int> ReserveOrderID { get; set; }
        public Nullable<int> BoxSize { get; set; }
        public Nullable<int> PalletLocationID { get; set; }
        public virtual Pallet Pallet { get; set; }
        public virtual PalletLocation PalletLocation { get; set; }
        public virtual ICollection<PickListDetail> PickListDetails { get; set; }
        public virtual ReceiveDoc ReceiveDoc { get; set; }
    }
}
