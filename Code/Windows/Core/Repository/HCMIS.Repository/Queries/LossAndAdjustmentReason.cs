using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class LossAndAdjustmentReason
    {
        [SelectQuery]
        public static string SelectGetAvailableReasons()
        {
            return String.Format("SELECT * FROM LossAndAdjustmentReason WHERE ID IN (SELECT ReasonID FROM LossAndAdjustment)");
        }

        [SelectQuery]
        public static string SelectAvailableReasonsById( int reasonid)
        {
            return String.Format("SELECT * FROM LossAndAdjustmentReason WHERE ID = {0}", reasonid);
        }
    }
}
