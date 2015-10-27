
using System;
using DAL;
using System.Data;

namespace BLL
{
	public class IssueDocDeleted : _IssueDocDeleted
	{
		public IssueDocDeleted()
		{
            
		
		}

        /// <summary>
        /// Adds a new delete log
        /// </summary>
        /// <param name="deletedissDoc">The IssueDoc Object to be deleted</param>
        /// <param name="userID">The user ID.</param>
        public static void AddNewLog(IssueDoc deletedissDoc, int userID)
        {
            while (!deletedissDoc.EOF)
            {
                BLL.IssueDocDeleted issLog = new IssueDocDeleted();
                issLog.AddNew();
                foreach (DataColumn col in deletedissDoc.DefaultView.Table.Columns)
                {// the try catch is to make sure the database schema change doesn't mess this method
                    try
                    {
                        issLog.SetColumn(col.ColumnName, deletedissDoc.GetColumn(col.ColumnName));
                    }
                    catch
                    {
                        
                    }
                }

                issLog.DeletedBy = userID;
                issLog.DateDeleted = DateTimeHelper.ServerDateTime;
                issLog.Save();
                deletedissDoc.MoveNext();
            }
        }


       
    }
}
