using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class LogRequisitionStatus
    {
        [SelectQuery]
        public static string SelectGetLogRequisitionHistoty(int requisitionID)
        {
            string query = string.Format(@"Select lgs.*, us.FullName from LogRequisitionStatus lgs
                                            Join [User] us on lgs.UserID = us.ID
                                            where lgs.RequisitionID = {0}", requisitionID);
            return query;
        }
    }
}
