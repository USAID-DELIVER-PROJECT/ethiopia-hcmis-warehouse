
using System;
using DAL;
using System.Data;

namespace BLL
{
	public class LogReceiptChange : _LogReceiptChange
	{
        //Stores a snapshot of the object to be analyzed for change log.
        private MyGeneration.dOOdads.BusinessEntity snapShot;

        private LogReceiptChange()
        {
            
        }
        
        public LogReceiptChange(MyGeneration.dOOdads.BusinessEntity entity)
        {
            TakeSnapshot(entity);
        }
        
        /// <summary>
        /// Takes a snapshot of a business entity object
        /// Use this before you make any manipulations with the object.
        /// </summary>
        /// <param name="entity"></param>
        private void TakeSnapshot(MyGeneration.dOOdads.BusinessEntity entity)
        {   
            snapShot = entity;
        }

        /// <summary>
        /// Analyzes a business entity against the snapshot and saves log if there has been a change.
        /// Returns true if there has been a change.
        /// </summary>
        /// <param name="entity">The entity to be compared to the snapshot</param>
        /// <param name="userName">The username that's performing the change</param>
        /// <returns></returns>
        public bool SaveChangeLog(MyGeneration.dOOdads.BusinessEntity entity, int userId)
        {            
            bool dataChanged=false;
            foreach(DataColumn col in entity.DefaultView.Table.Columns)
            {
                string colBeforeChange = snapShot.GetColumn(col.ColumnName).ToString();
                string colAfterChange=entity.GetColumn(col.ColumnName).ToString();
                if (colBeforeChange != colAfterChange) //This column has been changed
                {
                    dataChanged = true;
                    LogReceiptChange log = new LogReceiptChange();
                    log.AddNew();
                    log.TableName = entity.GetType().ToString();
                    log.ColumnName = col.ColumnName;
                    log.ChangedBy = userId;
                    log.DateChanged = DateTimeHelper.ServerDateTime;
                    log.RefID = int.Parse(snapShot.GetColumn("ID").ToString());
                    if (snapShot.GetColumn(col.ColumnName) != null)
                        log.OldValue = snapShot.GetColumn(col.ColumnName).ToString();
                    if (entity.GetColumn(col.ColumnName) != null)
                        log.NewValue = entity.GetColumn(col.ColumnName).ToString();
                    log.Save();
                }
            }
            return dataChanged;            
        }
	}
}
