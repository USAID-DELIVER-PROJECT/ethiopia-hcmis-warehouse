using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Logging.Models;
using HCMIS.Logging.Helpers;

namespace HCMIS.Logging.Loggers
{
    public class ActivityLogger : LoggerBase, IActivityLog
    {
        private string _className;
        public ActivityLogger(object obj):base()
        {
            this._className = obj.GetType().Name;
        }

        public void SaveAction(int userId, int activityId, string page, string activityName)
        {
            var log = new ActivityLog
                                  {
                                      UserID = userId,
                                      ActivityID = activityId,
                                      Page = page,
                                      ActivityName = activityName,
                                      TimeStamp = Helper.ServerDateTime,
                                      ClassName = this._className,
                                      IPAddress = Helper.GetIP(),
                                      OccuranceDate = Helper.ServerDateTime,
                                      HostName = Helper.GetHostName()
                                  };
            Repository.Add(log);
        }

    }
}
