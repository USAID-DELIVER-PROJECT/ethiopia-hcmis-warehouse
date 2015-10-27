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
using HCMIS.Security.Repository;
using HCMIS.Security.Models;
using HCMIS.Security.UserManagement.ViewModels;
using HCMIS.Logging;
using HCMIS.Security.Common;
using System.Threading;
using HCMIS.Security.UserManagement.Helpers;

namespace HCMIS.Security.UserManagement.Views
{
    [FormIdentifier("UM-UG-GP-FR")]
    public partial class GroupPermission : DevExpress.XtraEditors.XtraForm
    {

        private IUnitOfWork repository = UnitOfWork.CreateInstance();

        private GroupPermissionListViewModel groupPermissions;
        public GroupPermission Selected { get; private set; }

        public Group CurrentGroup { get; private set; }
        public GroupPermission()
        {
            InitializeComponent();
            LoadLookups();
      
        }

        private void LoadLookups()
        {
            groupbindingSource.DataSource = repository.Groups.GetAll().ToList();
            this.CurrentGroup = groupbindingSource.Current as Group;
            
            groupPermissions = new GroupPermissionListViewModel(repository, this.CurrentGroup);
            groupPermissionBindingSource.DataSource = groupPermissions.GroupPermissions;

        }       

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void btnSaveGroupPermission_Click(object sender, EventArgs e)
        {
            groupPermissionBindingSource.EndEdit();
            UserIdentity ui = Thread.CurrentPrincipal.Identity as UserIdentity;
            var obj = groupPermissionBindingSource.DataSource as List<Security.Models.GroupPermission>;
            if (obj != null)
            {
                try
                {
                    foreach (Security.Models.GroupPermission item in obj)
                    {
                        if (this.CurrentGroup.GroupPermissions.Count(p => p.OperationID == item.OperationID) == 0)
                        {
                           repository.GroupPermissions.Add(item);
                        }
                        else
                        {
                            var groupPermission = repository.GroupPermissions.FindBy(gp => gp.GroupPermissionID == item.GroupPermissionID).FirstOrDefault();
                            groupPermission.Allow = item.Allow;
                            repository.GroupPermissions.Update(groupPermission);
                            //activityLogger.SaveAction(ui.UserID, 1, "Group Permission Window", "Permission with the same operation is created under this group.");
                        }
                    }
                    XtraMessageBox.Show(
                  "Permissions Updated. Users will have to restart their application for the permissions to take effect.",
                  "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    ViewHelper.ShowErrorMessage(ex.Message);
                    // errorLogger.SaveError(
                }

            }
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                this.CurrentGroup = listBox1.SelectedItem as Group;
                groupPermissions = new GroupPermissionListViewModel(repository, this.CurrentGroup);
                groupPermissionBindingSource.DataSource = groupPermissions.GroupPermissions;
            }
        }

        private void repositoryItemCheckEdit1_EditValueChanged(object sender, EventArgs e)
        {
            groupPermissionBindingSource.EndEdit();
        }

      
       

        

        

    }
}