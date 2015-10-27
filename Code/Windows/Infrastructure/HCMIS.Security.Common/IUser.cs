using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace HCMIS.Security.Common
{
    public interface IUser
    {
        int UserID { get; set; }
        string UserName { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Password { get; set; }
        bool IsActive { get; set; }

        void SetPassword(string rawPassword);
        bool CheckPassword(string rawPassword);
    }
}
