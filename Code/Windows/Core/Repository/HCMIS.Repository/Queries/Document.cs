using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class Document
    {
        [SelectQuery]
        public static string SelectLoadSTVsNotYetReceived(int stv)
        {
            string query =
                String.Format(
                    "Select top(100) * from MessageBroker.Document where DocumentID not in (select DocumentID from ReceiptDocument) and DocumentTypeID={0}", stv);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadByPrimaryKey(int docID)
        {
            string query = String.Format("Select * from MessageBroker.Document WHERE DocumentID={0}", docID);
            return query;
        }
    }
}
