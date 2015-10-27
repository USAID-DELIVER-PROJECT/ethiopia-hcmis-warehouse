using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class STVLog
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> PrintedDate { get; set; }
        public string RefNo { get; set; }
        public Nullable<int> PickListID { get; set; }
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
        public Nullable<int> PrePrintedInvoiceNo { get; set; }
        public Nullable<int> ReceivingUnitID { get; set; }
        public Nullable<bool> IsDeliveryNote { get; set; }
        public Nullable<bool> HasDeliveryNoteBeenConverted { get; set; }
        public Nullable<bool> HasInsurance { get; set; }
        public Nullable<double> InsuranceValue { get; set; }
        public virtual Store Store { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
        public virtual User User2 { get; set; }
    }
}
