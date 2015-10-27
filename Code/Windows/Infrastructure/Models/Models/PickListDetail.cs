using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class PickListDetail
    {
        public PickListDetail()
        {
            this.IssueDocs = new List<IssueDoc>();
        }

        public int ID { get; set; }
        public Nullable<int> PickListID { get; set; }
        public Nullable<int> ItemID { get; set; }
        public Nullable<int> PalletLocationID { get; set; }
        public string BatchNumber { get; set; }
        public Nullable<System.DateTime> ExpireDate { get; set; }
        public Nullable<int> ReceiveDocID { get; set; }
        public Nullable<int> BoxLevel { get; set; }
        public Nullable<double> Cost { get; set; }
        public Nullable<int> ManufacturerID { get; set; }
        public Nullable<int> Packs { get; set; }
        public Nullable<int> QtyPerPack { get; set; }
        public Nullable<long> QuantityInBU { get; set; }
        public Nullable<int> ReceivePalletID { get; set; }
        public Nullable<double> UnitPrice { get; set; }
        public Nullable<int> UnitID { get; set; }
        public Nullable<int> StoreID { get; set; }
        public Nullable<bool> DeliveryNote { get; set; }
        public virtual ICollection<IssueDoc> IssueDocs { get; set; }
        public virtual Item Item { get; set; }
        public virtual ItemUnit ItemUnit { get; set; }
        public virtual PickList PickList { get; set; }
        public virtual ReceiveDoc ReceiveDoc { get; set; }
        public virtual ReceivePallet ReceivePallet { get; set; }
        public virtual Store Store { get; set; }
    }
}
