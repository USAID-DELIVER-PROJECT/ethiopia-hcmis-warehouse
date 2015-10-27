using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class LoginLog
    {
        public int ID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<System.DateTime> LoginTime { get; set; }
        public Nullable<bool> SuccesfulLogin { get; set; }
        public Nullable<System.DateTime> LogOffTime { get; set; }
        public string HostName { get; set; }
        public string IPAddress { get; set; }
        public string MACAddress { get; set; }
        public Nullable<bool> UnknownUser { get; set; }
        public string UnknownUserName { get; set; }
        public string ApplicationVersion { get; set; }
        public virtual User User { get; set; }
    }
}
