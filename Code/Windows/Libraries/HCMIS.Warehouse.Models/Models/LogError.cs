using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("LogError")]
   public class LogError
    {
        [Key][Column("LogID")]
        public int LogErrorID { get; set; }

        public string WareHouse { get; set; }
        public string HostName { get; set; }
        public string IPAddress { get; set; }
        public DateTime OccuranceDate { get; set; }
        public int ErrorLevel { get; set; }
        public string Message { get; set; }
        public string ExceptionType { get; set; }
        public string Form { get; set; }
        public int LineNumberOnMainForm { get; set; }
        public string CallerMethod { get; set; }
        public string FileName { get; set; }
        public string Method { get; set; }
        public int LineNumber { get; set; }
        public string Activity { get; set; }
        public string Detail { get; set; }
        public string StackTrace { get; set; }
        public string InnerException { get; set; }
        public string AppVersion { get; set; }
        public string DbVersion { get; set; }
        public int VPNIP { get; set; }
    }
}
