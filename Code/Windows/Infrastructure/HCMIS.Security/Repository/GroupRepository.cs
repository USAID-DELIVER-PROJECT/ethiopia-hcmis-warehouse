using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Security.DataContext;
using HCMIS.Security.Models;

namespace HCMIS.Security.Repository
{
    public class GroupRepository : GenericRepository<SecurityContext,Group>
    {
        public GroupRepository(SecurityContext context)
        {
           this.Context = context;
        }

        public GroupRepository()
        {
            // TODO: Complete member initialization
        }
    }
}
