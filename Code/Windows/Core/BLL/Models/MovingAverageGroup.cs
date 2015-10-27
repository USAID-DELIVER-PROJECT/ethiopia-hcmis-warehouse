using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Models
{
    public class MovingAverageGroup : _MovingAverageGroup
    {

        public static int Convert(int ActivityID)
        {
            var activity = new Activity();
            activity.LoadByPrimaryKey(ActivityID);
            return activity.MovingAverageGroupID;
        }

        public void LoadByUser(int userID)
        {
            LoadFromRawSql(HCMIS.Repository.Queries.MovingAverageGroup.SelectByUser(userID));
        }

        public void LoadByUserForPriceHistory(int userID)
        {
            LoadFromRawSql(HCMIS.Repository.Queries.MovingAverageGroup.SelectByUserForPriceHistory(userID));
        }

    }
}
