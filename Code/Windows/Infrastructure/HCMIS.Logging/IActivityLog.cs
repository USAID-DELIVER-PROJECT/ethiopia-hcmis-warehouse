using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Logging
{
    public interface IActivityLog : ILog
    {
        void SaveAction(int userId, int activityId, string page, string activityName);
    }
}
