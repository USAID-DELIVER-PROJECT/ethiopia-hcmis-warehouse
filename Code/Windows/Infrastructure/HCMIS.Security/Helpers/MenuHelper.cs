using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Security.Models;

namespace HCMIS.Security.Helpers
{
    public class MenuHelper
    {
        public static IEnumerable<MenuItem> GetMenuItems(int userID, string resourceCode)
        {
            IUnitOfWork repository = UnitOfWork.CreateInstance();     
            // AMEN to optimiztion
            IEnumerable<MenuItem> menuItems = repository.RawSql<MenuItem>(string.Format("select distinct mi.* from ( select * from [UserGroup] where UserID = {0} and IsActive = 1) ug join (select * from MenuItemGroup) gp on ug.GroupID = gp.GroupID join MenuItem mi on mi.MenuItemID = gp.MenuItemID join ResourceType rt on mi.ResourceTypeID = rt.ResourceTypeID where rt.ResourceTypeCode ='{1}' AND mi.IsActive = 1", userID, resourceCode));

            //var userGroups = repository.UserGroups.FindBy(m => m.UserID == userID && m.GroupStatus == true).Select(ug => ug.GroupID).ToList();
            //var menuItems = from menuItemGroup in repository.MenuItemGroups.GetAll()
            //                where userGroups.Contains(menuItemGroup.GroupID)
            //                && menuItemGroup.MenuItem.ResourceTypeID == resourceTypeID
            //                select menuItemGroup.MenuItem;
            return menuItems;
        }

        public static IEnumerable<MenuItem> GetMenuItemsForGroup(int groupID, int resourceTypeID)
        {
            IUnitOfWork repository = UnitOfWork.CreateInstance();
            var allowedMenuItems = from menuItemGroup in repository.MenuItemGroups.GetAll()
                                   where menuItemGroup.GroupID == groupID
                                   && menuItemGroup.MenuItem.ResourceTypeID == resourceTypeID
                                   select menuItemGroup.MenuItem;
            return allowedMenuItems.Distinct();
        }
    }
}
