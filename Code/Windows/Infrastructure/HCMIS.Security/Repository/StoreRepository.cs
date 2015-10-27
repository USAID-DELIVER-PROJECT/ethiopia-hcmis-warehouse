using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Security.DataContext;
using HCMIS.Security.Models;

namespace HCMIS.Security.Repository
{
    public class StoreRepository : GenericRepository<SecurityContext,Store>
    {

        public StoreRepository(SecurityContext context)
        {
            this.Context = context;
        }
    }
}
