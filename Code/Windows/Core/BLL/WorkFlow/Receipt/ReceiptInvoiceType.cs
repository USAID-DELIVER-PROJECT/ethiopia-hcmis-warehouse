using System.Collections.Generic;
using System.Data;
using DAL;

namespace BLL
{
    public class ReceiptInvoiceType:_InvoiceType
    {
        public static class InvoiceType
        {
            public static int INVOICE_AIR;            
            public static int INVOICE_SEA;  
            public static int CIP;        
            public static int STV;
            public static int INVENTORY;
            public static int LOCAL_PURCHASE;
            public static int NON_STANDARD;
            public static int ERROR_CORRECTION;
            public static int INTERNAL;
        }

        public static DataTable GetAllInvoiceTypes()
        {
            var invoiceType = new ReceiptInvoiceType();
            var query = HCMIS.Repository.Queries.InvoiceType.SelectGetAllInvoiceType();
            invoiceType.LoadFromRawSql(query);
            return invoiceType.DataTable;
        }

        public static DataTable GetAllInvoiceTypeByCode(string invoiceTypeCode)
        {
            var invoiceType = new ReceiptInvoiceType();
            var query = HCMIS.Repository.Queries.InvoiceType.SelectGetInvoiceTypeByCode(invoiceTypeCode);
            invoiceType.LoadFromRawSql(query);
            return invoiceType.DataTable;
        }

    }
}
