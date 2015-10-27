using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Repository.Queries
{
    public class RRF
    {
        public static string SelectGetSavedRRFForDisplay()
        {
            string query = "select ID,DateOfSubmission, LastRRFStatus, RRFType, cast(FromMonth as varchar) + ',' + cast(FromYear as varchar) + ' - ' + cast(ToMonth as varchar) + ',' + cast(ToYear as varchar) Period from RRF";
            return query;
        }
    }
}
