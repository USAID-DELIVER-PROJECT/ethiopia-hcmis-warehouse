using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using HCMIS.Logging.Loggers;
using HCMIS.Logging.Migrations;
using HCMIS.Logging.Models;

namespace HCMIS.Logging
{
    public static class LogManager
    {
        #region Fields
        private static string _connectionString="";

        #endregion

        #region Private Helper Methods
        static void CheckIfConnectionStringExists()
        {
            if (String.IsNullOrEmpty(ConnectionString))
                throw new Exception("Connection string is not set. Use LogManager.ConnectionString to set a new connection string.");
            else
            {
                try
                {
                    var context = new LoggingContext();
                    context.Dispose();
                }
                catch (Exception exception)
                {
                    throw new Exception("Invalid connection string or name. Try re-setting LogManager.ConnectionString.");
                }
            }
            Database.SetInitializer(new GenericInitializer<LoggingContext>());
        }
        #endregion

        #region Methods
        public static IActivityLog GetActivityLogger(object page)
        {
            CheckIfConnectionStringExists();
            IActivityLog logger = new ActivityLogger(page);
            return logger;
        }

        public static IErrorLog GetErrorLogger()
        {
            CheckIfConnectionStringExists();
            IErrorLog logger = new ErrorLogger();
            return logger;
        }

        public static ISessionLog GetSessionLogger()
        {
            CheckIfConnectionStringExists();
            ISessionLog logger = new SessionLogger();
            return logger;
        }

        public static IProfiler GetProfilerLogger()
        {
            CheckIfConnectionStringExists();
            IProfiler logger = new Profiler();
            return logger;
        }

        #endregion

        #region Properties

        public static string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value;}
        }

        #endregion

    }
}
