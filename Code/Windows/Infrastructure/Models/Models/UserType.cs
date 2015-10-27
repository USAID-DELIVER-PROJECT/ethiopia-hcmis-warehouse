using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class UserType
    {
        public UserType()
        {
            this.Users = new List<User>();
        }

        public int ID { get; set; }
        public string Type { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
