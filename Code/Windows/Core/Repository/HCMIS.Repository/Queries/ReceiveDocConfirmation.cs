using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class ReceiveDocConfirmation
    {
        [SelectQuery]
        public static string SelectGetUserNamebyReceipt(int ReceiptID)
        {
            string query = String.Format(@"select distinct rd.ReceiptID,
                                                 rby.FullName ReceivedBy,
                                                 cby.FullName ConfirmedBy,
                                                 CostBy.FullName CostedBy,
                                                 chby.FullName CheckedBy,
                                                 grvby.FullName PrintedBy
                                                    from 
                                                              ReceiveDocConfirmation rdc join Receivedoc rd on rd.ID = rdc.ReceiveDOCID 
                                                              left join [user] rby on rby.ID = rdc.ReceivedByUserID  
                                                              left join [user] Cby on Cby.ID = rdc.ReceiptQuantityConfirmedByUserID  
                                                              left join [user] CostBy on CostBy.ID = UnitCostCalculatedByUserID  
                                                              left join [user] Chby on Chby.ID = rdc.PriceAssignedByUserID
                                                              left join [user] grvby on grvby.ID = rdc.PriceAssignedByUserID
                                                 where ReceiptID = {0}", ReceiptID);
            return query;
        }

        [UpdateQuery]
        public static string UpdateChangeStatusByAccountReceiveDocs(string receiveDocs, int StatusID, int? PreviousStatusID)
        {
            string query = String.Format(@"Update receiveDocConfirmation
                                set receiptconfirmationstatusID = {0}
                                   where ReceiveDocID in({1}) {2}", StatusID,
                receiveDocs,
                PreviousStatusID.HasValue
                    ? "and receiptconfirmationstatusID = " + PreviousStatusID.ToString()
                    : "");
            return query;
        }
    }
}
