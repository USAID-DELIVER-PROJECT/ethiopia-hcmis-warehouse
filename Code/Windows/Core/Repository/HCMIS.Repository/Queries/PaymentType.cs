using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class PaymentType
    {
        [SelectQuery]
        public static string SelectGetAllowedTypes(string inPaymentTypes)
        {
            string query = String.Format(@"select * from PaymentType pt where ID in ({0})", inPaymentTypes);
            return query;
        }
        [SelectQuery]
        public static string SelectByCode(string code)
        {
            string query = String.Format(@"select * from PaymentType pt where PaymentTypeCode= '{0}'", code);
            return query;
        }

        [SelectQuery]
        public static string SelectByCodes(string codes)
        {
            string query = String.Format(@"select * from PaymentType pt where PaymentTypeCode in ({0})", codes);
            return query;
        }
    }
}
