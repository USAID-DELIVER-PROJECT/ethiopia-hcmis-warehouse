using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Logging.Models
{
    [Table("LogError")]
    public class ErrorLog : Log
    {
        public string WareHouse { get; set; }
        public string HostName { get; set; }
        /// <summary>
        /// Gets or sets the IP Address of the machine that is currently running the application
        /// </summary>
        public string IPAddress { get; set; }
        public DateTime OccuranceDate { get; set; }
        public int ErrorLevel { get; set; }
        public string Message { get; set; }
        public string ExceptionType { get; set; }
        public string Form { get; set; }
        /// <summary>
        /// Gets the line number that raised the exception in the Main from
        /// </summary>
        public int LineNumberOnMainForm { get; set; }
        /// <summary>
        /// the caller method that got the raised exception
        /// </summary>
        public string CallerMethod { get; set; }
        /// <summary>
        /// Gets the filename, usually the class name, that raised the exception
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Gets the MethodName that raised the exception Caller 
        /// </summary>
        public string Method { get; set; }
        
        /// <summary>
        /// Gets the the line number of first-in-line in the original file that raised the exception
        /// </summary>
        public int LineNumber { get; set; }
      
        /// <summary>
        /// The activity that caused the exception
        /// </summary>
        public string Activity { get; set; }
        public string Detail { get; set; }
        public string StackTrace { get; set; }
        public string InnerException { get; set; }

        public string AppVersion { get; set; }
        public string DbVersion { get; set; }
        public int VPNIP { get; set; }
    }
}
