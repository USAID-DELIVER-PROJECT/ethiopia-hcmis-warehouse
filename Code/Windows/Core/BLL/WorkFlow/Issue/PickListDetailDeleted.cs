using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL.WorkFlow.Issue
{
    public class PickListDetailDeleted : _PickListDetailDeleted
    {
        public PickListDetailDeleted()
        {

        }
        
        /// <summary>
        /// Adds a new delete log
        /// </summary>
        /// <param name="deletedPickListDetail">The PickListDetail object to be deleted</param>
        /// <param name="deletedByUser">The user performing the deletion</param>
        public static void AddNewLog(PickListDetail deletedPickListDetail, int deletedByUser)
        {
                var pickListLog = new PickListDetailDeleted();
                CheckAndRemoveIfPreviouslyDeleted(deletedPickListDetail.PickListID);

                pickListLog.AddNew();
                foreach (DataColumn col in deletedPickListDetail.DefaultView.Table.Columns)
                {
                    pickListLog.SetColumn((col.ColumnName.Equals("ID") ? "PickListDetailDeletedID" : col.ColumnName), deletedPickListDetail.GetColumn(col.ColumnName));
                }
                pickListLog.DeletedBy = deletedByUser;
                pickListLog.DateDeleted = DateTimeHelper.ServerDateTime;
                pickListLog.Save();
        }

        private static void CheckAndRemoveIfPreviouslyDeleted(int picklistID)
        {
            var picklistdetailDeleted = new PickListDetailDeleted();
            picklistdetailDeleted.Where.PickListID.Value = picklistID;
            picklistdetailDeleted.Query.Load();

            picklistdetailDeleted.Rewind();
            while (!picklistdetailDeleted.EOF)
            {
                picklistdetailDeleted.MarkAsDeleted();
                picklistdetailDeleted.MoveNext();
            }
            picklistdetailDeleted.Save();
        }
    }
}
