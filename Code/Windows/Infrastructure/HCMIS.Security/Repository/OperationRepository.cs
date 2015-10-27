using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Security.DataContext;
using HCMIS.Security.Models;

namespace HCMIS.Security.Repository
{
    public class OperationRepository : GenericRepository<SecurityContext,Operation>
    {
      
        public OperationRepository(SecurityContext context)
        {
            this.Context = context;
        }
    }
}
