using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HCMIS.Security.Models;
using System.Collections;
using HCMIS.Security.Helpers;

namespace HCMIS.Security.UserManagement.ViewModels
{
    public class MenuListViewModel
    {
        static List<MenuViewModel> GenerateMenu(IEnumerable<MenuItem> menuItems, int parentId)
        {
            var menuTree = new List<MenuViewModel>();
            IEnumerable<MenuItem> upperLevelMenus;
            if (parentId == 0)
            {
                upperLevelMenus = menuItems.Where(m => m.ParentID == null);
            }
            else
            {
                upperLevelMenus = menuItems.Where(m => m.ParentID == parentId);
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
            var allowedMenuItems = MenuHelper.GetMenuItems(userId, "WM");
            return GenerateMenu(allowedMenuItems);
        }

        public static IEnumerable<MenuViewModel> GenerateMenuForGroup(int groupId)
        {
            var allowedMenuItems = MenuHelper.GetMenuItemsForGroup(groupId, 1);
            return GenerateMenu(allowedMenuItems);
        }

        public static IEnumerable<MenuViewModel> GenerateMenuItems(int groupId, int resourceTypeID)
        {
            var repository = UnitOfWork.CreateInstance();
            var allMenuItems = repository.MenuItems.GetMenuItemsInResourceType(resourceTypeID);
            var allowedMenuItems = repository.MenuItemGroups.GetMenuItemForGroup(groupId,resourceTypeID);
            var viewModel = new List<MenuViewModel>();
            foreach (var menuItem in allMenuItems)
            {
                viewModel.Add(new MenuViewModel(menuItem));
            }            
            foreach (var menuItem in viewModel)
            {
                if(allowedMenuItems.Any(m => m.MenuItemID == menuItem.MenuItemID))
                {
                    menuItem.Allowed = true;
                }
            }
            return viewModel;
        }
    }
}