using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Security.DataContext;
using HCMIS.Security.Models;

namespace HCMIS.Security.Repository
{
    public class AccountRepository : GenericRepository<SecurityContext,Activity>
    {
      
        public AccountRepository(SecurityContext context)
        {
            this.Context = context;
        }
    }
}
