using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class InternalTransfer
    {
        public int ID { get; set; }
        public Nullable<int> ItemID { get; set; }
        public Nullable<int> FromPalletLocationID { get; set; }
        public Nullable<int> ToPalletLocationID { get; set; }
        public string BatchNumber { get; set; }
        public Nullable<System.DateTime> ExpireDate { get; set; }
        public Nullable<int> ReceiveDocID { get; set; }
        public Nullable<int> ManufacturerID { get; set; }
        public Nullable<int> BoxLevel { get; set; }
        public Nullable<int> QtyPerPack { get; set; }
        public Nullable<int> Packs { get; set; }
        public Nullable<long> QuantityInBU { get; set; }
        public string Type { get; set; }
        public Nullable<System.DateTime> IssuedDate { get; set; }
        public Nullable<System.DateTime> ConfirmedDate { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> PrintNumber { get; set; }
    }
}
