using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Security.DataContext;
using HCMIS.Security.Models;

namespace HCMIS.Security.Repository
{
    public class MenuItemGroupRepository : GenericRepository<SecurityContext,MenuItemGroup>
    {
     

        public MenuItemGroupRepository(SecurityContext context)
        {
            this.Context = context;
        }
        public IEnumerable<MenuItem> GetMenuItemForGroup(int groupId, int resourceTypeID)
        {
            return this.FindBy(m => m.GroupID == groupId && m.MenuItem.ResourceTypeID == resourceTypeID).Select(m => m.MenuItem);
        }
    }
}
