using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace HCMIS.Services.DataContracts
{
    [DataContract]
    public class UserInformation
    {
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public Dictionary<string, bool> Permissions { get; set; }
        [DataMember]
        public Dictionary<int,string> Groups { get; set; }
        [DataMember]
        public Dictionary<int,string> Stores { get; set; }
        [DataMember]
        public Dictionary<int,string> Accounts { get; set; }
    }
}