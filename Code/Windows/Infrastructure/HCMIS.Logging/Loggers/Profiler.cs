using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Logging.Helpers;
using HCMIS.Logging.Models;

namespace HCMIS.Logging.Loggers
{
    class Profiler : LoggerBase, IProfiler
    {
        public Guid StartOperation(int userId, string page, string action)
        {            
            var log = new ProfileLog
                          {
                              UserID = userId,
                              Page = page,
                              Action = action,
                              OperationID = Guid.NewGuid(),
                              TimeStamp = Helper.ServerDateTime,
                          };
            Repository.Add(log);
            return log.OperationID;
        }

        public void EndOperation(Guid operationId)
        {
            var profile = Repository.FindByType<ProfileLog>(p => p.OperationID == operationId).Single();
            profile.EndTime = Helper.ServerDateTime;
            Repository.Update(profile);
        }
    }
}
