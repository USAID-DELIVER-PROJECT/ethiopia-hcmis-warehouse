using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class IssueDocDeleted
    {
        public int ID { get; set; }
        public Nullable<int> ItemID { get; set; }
        public Nullable<int> StoreId { get; set; }
        public Nullable<int> ReceivingUnitID { get; set; }
        public string LocalBatchNo { get; set; }
        public Nullable<long> Quantity { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<bool> IsTransfer { get; set; }
        public string IssuedBy { get; set; }
        public string Remark { get; set; }
        public string RefNo { get; set; }
        public string BatchNo { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public Nullable<double> Cost { get; set; }
        public Nullable<int> NoOfPack { get; set; }
        public Nullable<int> QtyPerPack { get; set; }
        public Nullable<long> DUSOH { get; set; }
        public Nullable<long> DURequestedQty { get; set; }
        public Nullable<long> RecomendedQty { get; set; }
        public Nullable<int> RecievDocID { get; set; }
        public Nullable<System.DateTime> EurDate { get; set; }
        public Nullable<int> OrderID { get; set; }
        public Nullable<int> STVID { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DateDeleted { get; set; }
        public Nullable<bool> DeliveryNote { get; set; }
        public Nullable<bool> DispatchConfirmed { get; set; }
        public Nullable<int> DispatchConfirmedByUserID { get; set; }
        public Nullable<System.DateTime> DispatchConfirmationDate { get; set; }
        public virtual User User { get; set; }
    }
}
