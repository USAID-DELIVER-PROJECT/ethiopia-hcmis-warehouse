using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Security.DataContext;
using HCMIS.Security.Models;

namespace HCMIS.Security.Repository
{
    public class MenuItemRepository : GenericRepository<SecurityContext,MenuItem>
    {
       

        public MenuItemRepository(SecurityContext context)
        {
            this.Context = context;
        }
        public IEnumerable<MenuItem> GetMenuItemsInResourceType(int resourceTypeID)
        {
            return this.FindBy(m => m.ResourceTypeID == resourceTypeID);
        } 
    }
}
