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
using HCMIS.Security.UserManagement.ViewModels;
using HCMIS.Security.Models;
using HCMIS.Security.UserManagement.Helpers;

namespace HCMIS.Security.UserManagement.Views
{
    [FormIdentifier("UM-LU-OP-FR")]
    public partial class OperationsView : DevExpress.XtraEditors.XtraForm
    {
        static readonly IUnitOfWork _repository = UnitOfWork.CreateInstance();
        public OperationsView()
        {
            InitializeComponent();
            LoadBindings();
        }

        private void LoadBindings()
        {
            menuItemBindingSource.DataSource = _repository.MenuItems.FindBy(m=> m.ParentID != null).OrderBy(o => o.Order).ThenBy(o=>o.Text).ToList();
            operationsBindingSource.DataSource = _repository.Operations.GetAll().ToList();
            resourceTypeBindingSource.DataSource = _repository.ResourceTypes.GetAll().OrderBy(o=>o.Name).ToList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            var operations = operationsBindingSource.DataSource as List<Operation>;
            foreach (var operation in operations)
            {
                if (operation.OperationID == null || operation.OperationID == 0)
                {
                    if (operation.MenuItemID == 0)
                    {
                        operation.MenuItemID = Convert.ToInt32(lkMenuItem.EditValue);
                    }
                    _repository.Operations.Add(operation);
                }
                else
                {
                    var item = _repository.Operations.FindBy(m => m.OperationID == operation.OperationID).SingleOrDefault();
                    if (item == null)
                        continue;
                    bool changed = false;
                    if (item.Name != operation.Name)
                    {
                        changed = true;
                        item.Name = operation.Name;
                    }
                   


                    if (item.Description != operation.Description)
                    {
                        changed = true;
                        item.Description = operation.Description;
                    }
                    if (changed)
                        _repository.Operations.Update(item);
                }
            }
            XtraMessageBox.Show("Your changes have been Saved", "Confirmation");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lkResourceType_EditValueChanged(object sender, EventArgs e)
        {
            int resourceTypeID = Convert.ToInt32(lkResourceType.EditValue);
            menuItemBindingSource.DataSource =
                _repository.MenuItems.FindBy(m => m.ResourceTypeID == resourceTypeID && m.ParentID != null).ToList();
            
        }

        private void lkMenuItem_EditValueChanged(object sender, EventArgs e)
        {
            int menuItemID = Convert.ToInt32(lkMenuItem.EditValue);
            operationsBindingSource.DataSource = _repository.Operations.FindBy(o=>o.MenuItemID == menuItemID ).ToList();
        }

      
    }
}
