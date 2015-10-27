using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class DocumentType
    {
        [SelectQuery]
        public static string SelectLoadByDocumentCode(object documentCode)
        {
            return string.Format("Select * from [MessageBroker].[DocumentType] where DocumentCode = '{0}'",
                documentCode);
        }

        [SelectQuery]
        public static string SelectLoadByDocumentID(Object documentTypeID)
        {
            return string.Format("Select * from [MessageBroker].[DocumentType] where DocumentTypeID = {0}",
                documentTypeID);
        }

        [SelectQuery]
        public static string SelectGetDocumentTypesByPOType(int poTypeID)
        {
            return string.Format(@"Select distinct dt.DocumentTypeID, dt.Name, dt.DocumentCode from  MessageBroker.DocumentType dt
                                    Join Procurement.POTypeDocumentType pdt on dt.DocumentTypeID = pdt.DocumentTypeID
                                    Where pdt.PurchaseOrderTypeID = {0} and dt.IsActive = 1", poTypeID);
        }
    }
}
