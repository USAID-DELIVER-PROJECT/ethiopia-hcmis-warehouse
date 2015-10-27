using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class Order
    {
        public Order()
        {
            this.IssueDocs = new List<IssueDoc>();
            this.OrderDetails = new List<OrderDetail>();
            this.PickLists = new List<PickList>();
            this.Transfers = new List<Transfer>();
        }

        public int ID { get; set; }
        public int OrderStatusID { get; set; }
        public Nullable<int> RequestedBy { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.DateTime> EurDate { get; set; }
        public string RefNo { get; set; }
        public string Remark { get; set; }
        public Nullable<int> FromStore { get; set; }
        public Nullable<bool> FromHCTS { get; set; }
        public Nullable<bool> ConfirmedToHCTS { get; set; }
        public Nullable<int> HCTSReferenceID { get; set; }
        public string LicenseNo { get; set; }
        public Nullable<int> PaymentTypeID { get; set; }
        public string LetterNo { get; set; }
        public Nullable<int> FilledBy { get; set; }
        public Nullable<int> ApprovedBy { get; set; }
        public string ContactPerson { get; set; }
        public Nullable<int> OrderTypeID { get; set; }
        public virtual ICollection<IssueDoc> IssueDocs { get; set; }
        public virtual OrderStatu OrderStatu { get; set; }
        public virtual ReceivingUnit ReceivingUnit { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<PickList> PickLists { get; set; }
        public virtual ICollection<Transfer> Transfers { get; set; }
    }
}
