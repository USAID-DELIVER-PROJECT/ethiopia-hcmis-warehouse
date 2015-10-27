using System.Collections.Generic;
using System.Linq;
using HCMIS.Security.Models;
using HCMIS.Security.Helpers;

namespace HCMIS.Desktop.ViewModels
{
    public class MenuListViewModel
    {
        static List<MenuViewModel> GenerateMenu(IEnumerable<MenuItem> menuItems, int parentId)
        {
            var menuTree = new List<MenuViewModel>();
            IEnumerable<MenuItem> upperLevelMenus;
            if (parentId == 0)
            {
                upperLevelMenus = menuItems.Where(m => m.ParentID == null).OrderBy(o=>o.Order).ThenBy(o=>o.Text);
            }
            else
            {
                upperLevelMenus = menuItems.Where(m => m.ParentID == parentId).OrderBy(o => o.Order).ThenBy(o => o.Text);
            }
            
            foreach (var menuItem in upperLevelMenus)
            {
                menuTree.Add(new MenuViewModel(menuItem));
            }

            foreach (var menu in menuTree)
            {
                var children = menuItems.Select(m => m.ParentID == menu.MenuItemID);
                if (menuItems.Select(m => m.ParentID == menu.MenuItemID).Any())
                    menu.SubMenus = GenerateMenu(menuItems, menu.MenuItemID);
            }
            return menuTree;
        }

        public static List<MenuViewModel> GenerateMenu(IEnumerable<MenuItem> menuItems)
        {
            return GenerateMenu(menuItems, 0);
        }

        public static IEnumerable<MenuViewModel> GenerateMenuForUser(int userId)
        {
            //TODO: ResourceType look-up should be carefully maintained across app versions
            //TODO: Remove the (hard-coded) second parameter below
            var allowedMenuItems = MenuHelper.GetMenuItems(userId, "WIN").ToList();
            return GenerateMenu(allowedMenuItems);
        }

    }
}