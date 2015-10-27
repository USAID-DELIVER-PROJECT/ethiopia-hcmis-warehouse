using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class MovingAverageGroup
    {
        [SelectQuery]
        public static string SelectByUser(int userID)
        {
           string query =
                String.Format(@"
                                SELECT Distinct m.TypeName StoreType ,MovingAverageID,MovingAverageName StoreGroup
                                    FROM vwAccounts a Join Mode m on a.ModeID = m.ID
                                        WHERE a.ActivityID IN (SELECT StoreID 
                                                                FROM UserStore 
                                                                    WHERE UserID={0} and CanAccess=1)
                                ", userID);
            return query;
        }

        public static string SelectByUserForPriceHistory(int userID)
        {
            string query =
                  String.Format(@"
                                SELECT Distinct m.TypeName StoreType ,MovingAverageID,MovingAverageName StoreGroup, a.AccountID
                                    FROM vwAccounts a Join Mode m on a.ModeID = m.ID
                                        WHERE a.ActivityID IN (SELECT StoreID 
                                                                FROM UserStore 
                                                                    WHERE UserID={0} and CanAccess=1)
                                ", userID);
            return query;
        }
    }
}
