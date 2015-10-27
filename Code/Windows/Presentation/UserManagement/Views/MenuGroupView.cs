using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using DevExpress.XtraEditors;
using HCMIS.Security.UserManagement.ViewModels;
using HCMIS.Security.Models;
using HCMIS.Security.Helpers;
using System.Linq;
using HCMIS.Security.UserManagement.Properties;
using HCMIS.Security.UserManagement.Helpers;

namespace HCMIS.Security.UserManagement.Views
{
    [FormIdentifier("UM-UG-GM-FR")]
    public partial class MenuGroupView : DevExpress.XtraEditors.XtraForm
    {
        #region Fields
        private List<Group> _groups;
        private List<MenuViewModel> _allMenuItems;
        private List<MenuViewModel> _allowedMenuItems;
        private static IUnitOfWork _repository;
        #endregion

        public MenuGroupView()
        {
            _repository = UnitOfWork.CreateInstance();
            InitializeComponent();
            LoadLookUps();
        }

        public void LoadLookUps()
        {
            var groups = _repository.Groups.GetAll();
            groupsBindingSource.DataSource = groups.ToList();
            var resourcetype = _repository.ResourceTypes.GetAll();
            resourceTypesBindingSource.DataSource = resourcetype.ToList();
        }

        void RefreshTreeList()
        {
            menuItemsBindingSource.DataSource = null;
            if (groupsLookUp.EditValue != null && resourceTypeLookUp.EditValue != null)
            {
                menuItemsBindingSource.DataSource = MenuListViewModel.GenerateMenuItems((int)groupsLookUp.EditValue, (int)resourceTypeLookUp.EditValue);
                menuItemsBindingSource.DataSource = HierarchicalCheck(menuItemsBindingSource.DataSource);
                RefreshReadOnlyView();
            }

        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            RefreshTreeList();
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (menuItemsBindingSource.DataSource != null)
            {
                Save();
                XtraMessageBox.Show("Successful!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();            
        }

        void Save()
        {
            var repository = UnitOfWork.CreateInstance();
            var menuItems = menuItemsBindingSource.DataSource as List<MenuViewModel>;
            menuItems = HierarchicalCheck(menuItems).ToList();
            foreach (var menuItem in menuItems)
            {
                var dbItem = repository.MenuItemGroups.FindBy(m => m.GroupID == (int)groupsLookUp.EditValue && m.MenuItemID == menuItem.MenuItemID).FirstOrDefault();
                if (dbItem == null)
                {
                    if (menuItem.Allowed == true)
                        repository.MenuItemGroups.Add(new MenuItemGroup { GroupID = (int)groupsLookUp.EditValue, MenuItemID = menuItem.MenuItemID });
                }
                else
                {
                    if (menuItem.Allowed == false)
                        repository.MenuItemGroups.DeleteBy(m => m.GroupID == (int)groupsLookUp.EditValue && m.MenuItemID == menuItem.MenuItemID);
                }
            }
           RefreshReadOnlyView();
        }

        void RefreshReadOnlyView()
        {
            treeList1.EndUpdate();
            menuItemsBindingSource.DataSource = HierarchicalCheck(menuItemsBindingSource.DataSource);
            var allMenuItems = menuItemsBindingSource.DataSource as List<MenuViewModel>;
            var selectedItems = allMenuItems.Where(m => m.Allowed == true);
            
            effectiveMenuItemBindingSource.DataSource = selectedItems.ToList();
        }

        private List<MenuViewModel> HierarchicalCheck(object bindingSource)
        {
            var menuItems = bindingSource as List<MenuViewModel>;
            var parentIDs = menuItems.Where(m => m.Allowed == true && m.ParentMenuItemID > 0).Select(m => m.ParentMenuItemID);
            foreach (var id in parentIDs)
            {
                menuItems.FirstOrDefault(m => m.MenuItemID == id).Allowed = true;
            }
            return menuItems;
        }

        
    }
}