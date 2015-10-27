using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCMIS.Security.Helpers;

namespace HCMIS.Security.UserManagement.Views
{
    public partial class MenuItemsView : DevExpress.XtraEditors.XtraForm
    {
        static readonly IUnitOfWork _repository = UnitOfWork.CreateInstance();
        public MenuItemsView()
        {
            InitializeComponent();
            LoadResourceTypes();
        }

        private void LoadResourceTypes()
        {
            var resourceTypes = _repository.ResourceTypes.GetAll();
            resourceTypesBindingSource.DataSource = resourceTypes.ToList();
        }

        private void LoadMenuItems()
        {
            menuItemsBindingSource.DataSource = null;
            if (cmbResourceType.EditValue != null || (int)cmbResourceType.EditValue > 0)
            {
                var menuItems = _repository.MenuItems.FindBy(m => m.ResourceTypeID == (int)cmbResourceType.EditValue && m.ParentID == null);
                if (menuItems != null)
                    menuItemsBindingSource.DataSource = menuItems.ToList();
            }
        }

        private void cmbResourceType_EditValueChanged(object sender, EventArgs e)
        {
            LoadMenuItems();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files (*.jpg, *.gif, *.png)|*.jpg;*.gif;*.png;";

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtIconFilePath.Text = dialog.FileName;
                imgIcon.Image = new Bitmap(dialog.FileName);
            }
        }

        private void Save()
        {
            if (validationProvider.Validate())
            {
                var newItem = new HCMIS.Security.Models.MenuItem()
                {
                    Text = txtText.Text,
                    ResourceTypeID = (int)cmbResourceType.EditValue,                    
                    URL = txtURL.Text,
                    ToolTip = txtToolTip.Text,
                    Icon = txtIconFilePath.Text
                };
                if (cmbParent.EditValue != null && cmbParent.EditValue != "")
                    newItem.ParentID = (int)cmbParent.EditValue;
                _repository.MenuItems.Add(newItem);
                XtraMessageBox.Show("Menu Item saved successfully.");
                this.Close();
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Save();            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
