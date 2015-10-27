using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Repository.Queries
{
    public class UserPaymentType
    {
        public static string SelectLoadByUserID(int userID)
        {
            string query = String.Format("Select * from UserPaymentType us join PaymentType s on us.paymentTypeID=s.ID where us.UserID={0}", userID);
            return query;
        }

        public static string UpdateMakeDefault(int userID, int paymentTypeID)
        {
            string query = String.Format("Update UserPaymentType Set IsDefault=1 where UserID={0} and PaymentTypeID={1} and CanAccess=1", userID, paymentTypeID);
            return query;
        }
       
        public static string UpdateUserPaymentTypeMakeDefault(int userID, int paymentTypeID)
        {
            string query = string.Format("Update UserPaymentType Set IsDefault=0 where ID not in (Select ID from UserPaymentType  where UserID={0} and PaymentTypeID={1} and CanAccess=1)", userID, paymentTypeID);
            return query;
        }
    }
}
