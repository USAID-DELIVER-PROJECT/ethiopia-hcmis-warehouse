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
using HCMIS.Security.Models;
using HCMIS.Security.UserManagement.Helpers;

namespace HCMIS.Security.UserManagement.Views
{
    [FormIdentifier("UM-UG-GV-FR")]
    public partial class GroupView : DevExpress.XtraEditors.XtraForm
    {
        IUnitOfWork _repository = UnitOfWork.CreateInstance();
        public GroupView()
        {
            InitializeComponent();
            LoadGroups();
        }

        private void LoadGroups()
        {
            var groups = _repository.Groups.GetAll();
            groupsBindingSource.DataSource = groups.ToList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            var groups = groupsBindingSource.DataSource as List<Group>;
            foreach (var group in groups)
            {
                if (group.GroupID == null || group.GroupID == 0) // Newly added
                {
                    _repository.Groups.Add(group);
                }
                else
                {
                    var item = _repository.Groups.FindBy(m => m.GroupID == group.GroupID).SingleOrDefault();
                    _repository.Groups.Update(item);
                }
            }
            XtraMessageBox.Show("Your changes have been saved","Confirmation",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void repDelete_Click(object sender, EventArgs e)
        {
            var group = (Group)groupsBindingSource[gridView1.FocusedRowHandle];
            if (group != null)
            {
                if (group.UserGroups.Where(g => g.GroupStatus == true).Count() > 0)
                {
                    XtraMessageBox.Show(
                        "This user group has users associated with it. You cannot delete a group that has active users. Please delete the group from the users and try again.","Cannot Delete this User Group.",MessageBoxButtons.OK);
                }else  if (XtraMessageBox.Show("Are you sure you would like to delete this User Group?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                   
                    // delete user groups
                    List<int> userGroups = new List<int>();
                    userGroups = group.UserGroups.Select(g => g.UserGroupID).ToList();
                    foreach (var ug in userGroups)
                    {
                        _repository.UserGroups.DeleteBy(u=>u.UserGroupID == ug);
                    }

                    // delete menus
                    List<int> groupMenus = group.MenuItemGroups.Select(u => u.MenuItemGroupID).ToList();
                    foreach (var gm in groupMenus)
                    {
                        _repository.MenuItemGroups.DeleteBy(g=>g.MenuItemGroupID == gm);
                    }

                    // delete permissions
                    List<int> permissions = group.GroupPermissions.Select(p => p.GroupPermissionID).ToList();
                    foreach (var pr in permissions)
                    {
                        _repository.GroupPermissions.DeleteBy(p=>p.GroupPermissionID == pr);
                    }

                    _repository.Groups.DeleteBy(j => j.GroupID == group.GroupID);
                    

                    LoadGroups();
                    XtraMessageBox.Show("The Group has been deleted", "Confirmation");
                }

            }
        }
    }
}
