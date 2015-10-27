using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Security.DataContext;
using HCMIS.Security.Models;

namespace HCMIS.Security.Repository
{
    public class StoreUserRepository : GenericRepository<SecurityContext,StoreUser>
    {
       
        public StoreUserRepository(SecurityContext context)
        {
            base.Context = context;
        }

        public StoreUserRepository()
        {
            // TODO: Complete member initialization
        }
    }
}
