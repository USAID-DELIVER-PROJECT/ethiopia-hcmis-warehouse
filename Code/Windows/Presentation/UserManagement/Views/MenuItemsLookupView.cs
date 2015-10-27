using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HCMIS.Security.UserManagement.ViewModels;
using HCMIS.Security.Helpers;
using HCMIS.Security.UserManagement.Helpers;
using DevExpress.XtraEditors;

namespace HCMIS.Security.UserManagement.Views
{
    [FormIdentifier("UM-LU-ML-FR")]
    public partial class MenuItemsLookupView : DevExpress.XtraEditors.XtraForm
    {
        private IUnitOfWork _repository = UnitOfWork.CreateInstance();
        public MenuItemsLookupView()
        {
            InitializeComponent();
            LoadResourceTypes();            
        }

        private void LoadResourceTypes()
        {
            var resourceTypes = _repository.ResourceTypes.GetAll();
            resourceTypesBindingSource.DataSource = resourceTypes.ToList();
        }

        private void LoadMenuItems(int resourceTypeId)
        {
            var menuItems = _repository.MenuItems.FindBy(m => m.ResourceTypeID == resourceTypeId);
            var viewModel = new List<MenuViewModel>();
            foreach (var item in menuItems)
            {
                viewModel.Add(new MenuViewModel(item));
            }
            menuItemsBindingSource.DataSource = viewModel;
        }

        private void resourceTypeLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            menuItemsBindingSource.DataSource = null;
            if (resourceTypeLookUpEdit.EditValue != null && (int)resourceTypeLookUpEdit.EditValue != 0)
            {
                LoadMenuItems((int)resourceTypeLookUpEdit.EditValue);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Save();
            XtraMessageBox.Show("Save Successful");
        }

        private void Save()
        {
            var menuItems = menuItemsBindingSource.DataSource as List<MenuViewModel>;
            if (menuItems == null)
                return;

            foreach (var menuItem in menuItems)
            {
                var item = _repository.MenuItems.FindBy(m => m.MenuItemID == menuItem.MenuItemID).SingleOrDefault();
                if (item == null)
                    continue;
                bool changed = false;
                if (item.Text != menuItem.Text)
                {
                    item.Text = menuItem.Text;
                    changed = true;
                }
                if (item.URL != menuItem.URL)
                {
                    item.URL = menuItem.URL;
                    changed = true;
                }

                if (item.Icon != menuItem.Icon)
                {
                    item.Icon = menuItem.Icon;
                    changed = true;
                }

                if (item.ToolTip != menuItem.ToolTip)
                {
                    item.ToolTip = menuItem.ToolTip;
                    changed = true;
                }
                if (item.Order != menuItem.Order)
                {
                    item.Order = menuItem.Order;
                    changed = true;
                }

                if (changed)
                    _repository.MenuItems.Update(item);
            }
        }

        private void btnAddNewMenuItem_Click(object sender, EventArgs e)
        {
            MenuItemsView dialog = new MenuItemsView();
            dialog.ShowDialog(this);
        }
    }
}
