using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class LogReceiptStatus
    {
        [SelectQuery]
        public static string SelectGetLogHistory(int receiptID)
        {
            string query = String.Format(
                @"select StatusChangedDate [Date] ,[Description] + ' by ' + u.FullName  + ' on '+ Cast(StatusChangedDate as varchar) [Description]
                        from LogReceiptStatus lrs 
                            join [User] u on lrs.UserID = u.ID where ReceiptID = {0}
                    Order by [Date] Desc",
                receiptID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetLogHistory(int receiptID, string statusCode)
        {
            string query = String.Format(
                @"
							select rcs.Name, u.FullName, lrs.StatusChangedDate Date
							from LogReceiptStatus lrs 
                            join [User] u on lrs.UserID = u.ID 
                            join ReceiptConfirmationStatus rcs on lrs.ToStatusID = rcs.id
							where lrs.ReceiptID = {0} and rcs.ReceiptConfirmationStatusCode = '{1}'
                            order by [Date] desc",
                receiptID, statusCode);
            return query;
        }

    }
}
