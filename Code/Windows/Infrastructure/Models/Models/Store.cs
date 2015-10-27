using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class Store
    {
        public Store()
        {
            this.Balances = new List<Balance>();
            this.OrderDetails = new List<OrderDetail>();
            this.PickListDetails = new List<PickListDetail>();
            this.POes = new List<PO>();
            this.ReceiptConfirmationPrintouts = new List<ReceiptConfirmationPrintout>();
            this.StoreItems = new List<StoreItem>();
            this.STVLogs = new List<STVLog>();
            this.Transfers = new List<Transfer>();
            this.Transfers1 = new List<Transfer>();
            this.UserStores = new List<UserStore>();
        }

        public int ID { get; set; }
        public Nullable<int> HospitalID { get; set; }
        public string StoreName { get; set; }
        public Nullable<bool> UsesMovingAverage { get; set; }
        public Nullable<int> StoreTypeID { get; set; }
        public Nullable<int> StoreGroupDivisionID { get; set; }
        public Nullable<int> StoreGroupID { get; set; }
        public virtual ICollection<Balance> Balances { get; set; }
        public virtual GeneralInfo GeneralInfo { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<PickListDetail> PickListDetails { get; set; }
        public virtual ICollection<PO> POes { get; set; }
        public virtual ICollection<ReceiptConfirmationPrintout> ReceiptConfirmationPrintouts { get; set; }
        public virtual StoreGroup StoreGroup { get; set; }
        public virtual StoreGroupDivision StoreGroupDivision { get; set; }
        public virtual ICollection<StoreItem> StoreItems { get; set; }
        public virtual StoreType StoreType { get; set; }
        public virtual ICollection<STVLog> STVLogs { get; set; }
        public virtual ICollection<Transfer> Transfers { get; set; }
        public virtual ICollection<Transfer> Transfers1 { get; set; }
        public virtual ICollection<UserStore> UserStores { get; set; }
    }
}
