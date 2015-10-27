using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class PickListDetail
    {
        [SelectQuery]
        public static string SelectLoadByPickListID(int plId)
        {
            string query = String.Format("select * from PickListDetail where PickListID = {0}", plId);
            return query;
        }

        [SelectQuery]
        public static string SelectLoadByPickListIDWithStvlogID(int plId)
        {
            string query = String.Format(@"select pld.*,stv.IDPrinted from PickListDetail pld 
                                                    Join IssueDoc id on pld.ID = id.PLDetailID 
                                                    Join STVLog stv on stv.ID = id.STVID
                                                where pld.PickListID = {0}
                                                   Order by IDPrinted", plId);
            return query;
        }
    }
}
