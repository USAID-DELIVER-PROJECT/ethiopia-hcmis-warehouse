using System;
using HCMIS.Logging.Models;
using HCMIS.Logging.Helpers;
using System.Diagnostics;

namespace HCMIS.Logging.Loggers
{
    public class ErrorLogger : LoggerBase, IErrorLog
    {
        public void SaveError(int userId, int appVersion, int dbVersion, int errorLevel, string activity, string warehouse, Exception exception)
        {
            try
            {


                StackTrace s = new StackTrace(exception, true);
                StackFrame sf;
                int lineNumber = 0;
                string form = "";
                if (s.FrameCount > 0)
                {
                    sf = s.GetFrame(0);
                    //string Filename = sf.GetFileName().ToString();
                    sf = s.GetFrame(s.FrameCount - 1);
                    lineNumber = s.GetFrame(s.FrameCount - 1).GetFileLineNumber();
                    form = sf.GetFileName().ToString();
                }

                string callerMethod = s.GetFrame(s.FrameCount - 1).GetMethod().ToString();

                // Get InnerException
                string innerException;
                if (exception.InnerException != null)
                {
                    innerException = exception.InnerException.ToString();
                    // innerException = exception.Message.ToString();
                }
                else
                {
                    innerException = "No InnerException";
                }
                var log = new ErrorLog
                              {
                                  UserID = userId,
                                  TimeStamp = Helper.ServerDateTime,
                                  Activity = activity,
                                  AppVersion = appVersion.ToString(),
                                  DbVersion = dbVersion.ToString(),
                                  Form = form,
                                  ErrorLevel = errorLevel,
                                  Detail = Convert.ToString(exception),
                                  StackTrace = Convert.ToString(exception.StackTrace),
                                  FileName = form,
                                  Method = Convert.ToString(exception.TargetSite),
                                  LineNumber = Helper.GetLineNumber(exception),
                                  CallerMethod = callerMethod,
                                  LineNumberOnMainForm = lineNumber,
                                  Message = exception.Message,
                                  ExceptionType = Convert.ToString(exception.GetType()),
                                  IPAddress = Helper.GetIP(),
                                  WareHouse = warehouse,
                                  HostName = Helper.GetHostName(),
                                  OccuranceDate = Helper.ServerDateTime,
                                  InnerException = innerException
                              };
                Repository.Add(log);
            }
            catch
            {

            }
        }
        
    }
}
