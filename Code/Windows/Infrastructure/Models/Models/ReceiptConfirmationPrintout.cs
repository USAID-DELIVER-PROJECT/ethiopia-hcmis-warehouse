using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class ReceiptConfirmationPrintout
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> PrintedDate { get; set; }
        public Nullable<int> SupplierID { get; set; }
        public Nullable<int> IsReprintOf { get; set; }
        public string Reason { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> StoreID { get; set; }
        public Nullable<int> IDPrinted { get; set; }
        public Nullable<bool> VoidRequest { get; set; }
        public Nullable<System.DateTime> VoidRequestDateTime { get; set; }
        public Nullable<int> VoidRequestUserID { get; set; }
        public Nullable<bool> IsVoided { get; set; }
        public Nullable<int> VoidApprovedByUserID { get; set; }
        public Nullable<System.DateTime> VoidApprovalDateTime { get; set; }
        public Nullable<int> ReceiptID { get; set; }
        public virtual Receipt Receipt { get; set; }
        public virtual Store Store { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
        public virtual User User2 { get; set; }
    }
}
