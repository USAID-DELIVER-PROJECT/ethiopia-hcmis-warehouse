using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class ReceiveDocConfirmation
    {
        public int ID { get; set; }
        public Nullable<int> ReceiveDocID { get; set; }
        public Nullable<int> ReceiptConfirmationStatusID { get; set; }
        public Nullable<int> ReceivedByUserID { get; set; }
        public Nullable<int> ReceiptQuantityConfirmedByUserID { get; set; }
        public Nullable<int> PriceAssignedByUserID { get; set; }
        public Nullable<int> PriceConfirmedByUserID { get; set; }
        public Nullable<int> GRVPrintedByUserID { get; set; }
        public Nullable<int> UnitCostCalculatedByUserID { get; set; }
        public virtual ReceiptConfirmationStatu ReceiptConfirmationStatu { get; set; }
        public virtual ReceiveDoc ReceiveDoc { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
        public virtual User User2 { get; set; }
        public virtual User User3 { get; set; }
        public virtual User User4 { get; set; }
        public virtual User User5 { get; set; }
    }
}
