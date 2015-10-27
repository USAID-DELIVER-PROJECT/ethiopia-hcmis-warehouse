using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCMIS.Security.Common.DataContracts
{
    public class UserInformation
    {
        public UserInformation()
        {
            this.Permissions = new Dictionary<string, bool>();
            this.Groups = new Dictionary<int, string>();
            this.Accounts = new Dictionary<int, string>();
            this.Stores = new Dictionary<int, string>();
        }

        public int UserID { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public Dictionary<string, bool> Permissions { get; set; }
        public Dictionary<int,string> Groups { get; set; }
        public Dictionary<int,string> Stores { get; set; }
        public Dictionary<int,string> Accounts { get; set; }
    }
}