using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class InvoiceType
    {
        [SelectQuery]
        public static string SelectGetAllInvoiceType()
        {
            string query = string.Format(@"Select * from InvoiceType where isActive = 1");
            return query;
        }

        [SelectQuery]
        public static string SelectGetInvoiceTypeByCode(string invoiceTypeCode)
        {
            string query = string.Format(@"Select * from InvoiceType where isActive = 1 and InvoiceTypeCode = '{0}'",
                invoiceTypeCode);
            return query;
        }
    }
}
