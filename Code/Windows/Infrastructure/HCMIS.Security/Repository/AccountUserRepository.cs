using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Security.DataContext;
using HCMIS.Security.Models;

namespace HCMIS.Security.Repository
{
    public class AccountUserRepository : GenericRepository<SecurityContext, AccountUser>
    {
        public AccountUserRepository(SecurityContext context)
        {
            this.Context = context;
        }
    }
}
