using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Logging
{
    public interface IErrorLog : ILog
    {
        void SaveError(int userId, int appVersion, int dbVersion, int errorLevel, string activity, string warehouse, Exception exception);
    }
}
