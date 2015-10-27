
using System;
using DAL;
using System.Data;

namespace BLL
{
    public class ReceiveDocDeleted : _ReceiveDocDeleted
    {
        public ReceiveDocDeleted()
        {

        }

        /// <summary>
        /// Adds a new delete log
        /// </summary>
        /// <param name="deletedReceiveDoc">The ReceiveDoc object to be deleted</param>
        /// <param name="deletedByUser">The user performing the deletion</param>
        public static ReceiveDocDeleted AddNewLog(ReceiveDoc deletedReceiveDoc, int deletedByUser)
        {
            var recLog = new ReceiveDocDeleted();
            recLog.AddNew();
            foreach (DataColumn col in deletedReceiveDoc.DefaultView.Table.Columns)
            {
                try
                {
                    recLog.SetColumn(col.ColumnName, deletedReceiveDoc.GetColumn(col.ColumnName));
                }
                catch { /*Till VVMID Column generated for ReceiveDocDeleted! */}

            }

            recLog.DeletedBy = deletedByUser;
            recLog.DateDeleted = DateTimeHelper.ServerDateTime;
            return recLog;
        }

        /// <summary>
        /// Loads the deleted items using the receipt id
        /// </summary>
        /// <param name="receiptId"></param>
        public void LoadAllByReceiptID(int receiptId)
        {
            var query = HCMIS.Repository.Queries.ReceiveDocDeleted.SelectLoadAllByReceiptID(receiptId);
            LoadFromRawSql(query);
        }
    }
}
