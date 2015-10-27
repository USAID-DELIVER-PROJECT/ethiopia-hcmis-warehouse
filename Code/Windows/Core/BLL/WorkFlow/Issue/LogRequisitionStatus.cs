using System.Data;
using DAL;

namespace BLL.WorkFlow.Issue
{
    public class LogRequisitionStatus:_LogRequisitionStatus
    {
        public void LoadByRequisitionID(int requisitionID)
        {
            FlushData();
	        this.Where.RequisitionID.Value = requisitionID;
	        this.Query.Load();
            this.LoadAll();
        }

        public DataView GetLogHistory(int requisitionID)
        {
            var logRequisitionStatus = new LogRequisitionStatus();
            var query = HCMIS.Repository.Queries.LogRequisitionStatus.SelectGetLogRequisitionHistoty(requisitionID);
            logRequisitionStatus.LoadFromRawSql(query);
            return logRequisitionStatus.DefaultView;
        }
    }
}
