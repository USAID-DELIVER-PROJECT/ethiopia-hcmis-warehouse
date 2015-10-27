using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Logging.Repository;

namespace HCMIS.Logging.Loggers
{
    public class LoggerBase : ILog
    {
        private LogRepository _repository;

        public LoggerBase()
        {
            Setup(LogManager.ConnectionString);
            this._repository = new LogRepository();
        }

        public void Setup(string connectionString)
        {
            LogManager.ConnectionString = connectionString;
            this._repository = new LogRepository();
        }

        protected internal LogRepository Repository
        {
            get { return this._repository; }
        }
    }
}
