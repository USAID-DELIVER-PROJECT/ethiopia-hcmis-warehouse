using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class vwGetUser
    {
        public string Type { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public int ID { get; set; }
        public string FullName { get; set; }
        public Nullable<int> UserType { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}
