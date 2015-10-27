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
using HCMIS.Security.Repository;
using HCMIS.Security.UserManagement.ViewModels;
using HCMIS.Logging;

namespace HCMIS.Security.UserManagement.Views
{
    public partial class AddGroup : DevExpress.XtraEditors.XtraForm
    {
        private static IActivityLog activityLogger = LogManager.GetActivityLogger("Some Page");
        private static IErrorLog errorLogger = LogManager.GetErrorLogger();
        public User CurrentUser { get; private set; }
        private UnitOfWork repository;
        private UserGroup userGroup;

        public AddGroup(UnitOfWork repo)
        {
            repository = repo;
            InitializeComponent();
            LoadGroup();
            userGroup = new UserGroup();
            usergroupbindingSource.DataSource = userGroup;
        }
        public AddGroup(int userId,UnitOfWork repo)
        {
            repository = repo;
            InitializeComponent();
           
            this.CurrentUser = repository.Users.FindBy(u => u.UserID == userId).SingleOrDefault();
            LoadGroup();
            var viewmodel =new GroupsListViewModel(this.CurrentUser.UserGroups.ToList());
            usergroupbindingSource.DataSource = viewmodel.Grouplist;

        }
        private void LoadGroup()
        {
           
            var allgroups = repository.Groups.GetAll().ToList();
            if (CurrentUser.UserGroups != null)
            {
                var groups = from c in CurrentUser.UserGroups.Where(g => g.GroupStatus == true) select c.Group;
                foreach (var group in groups)
                {
                    if (groups.Where(a => a.GroupID == group.GroupID).Count() > 0)
                    {
                        var a = allgroups.SingleOrDefault(c => c.GroupID == group.GroupID);
                        allgroups.Remove(a);
                    }
                }
                               
            }
            grouplistbindingSource.DataSource = allgroups;
        }

        private void BtnSaveGroupClick(object sender, EventArgs e)
        {
            if (grouplistbox.SelectedItem == null)
            {
                ViewHelper.ShowErrorMessage("There is no group to be added.");
                activityLogger.SaveAction(CurrentUser.UserID, 1, "Group Window", "There is no group to be added."); 
                this.Close();
            }
            usergroupbindingSource.EndEdit();
            var obj = usergroupbindingSource.DataSource as List<UserGroup>;
            try
            {
                var selectedItems = grouplistbox.SelectedItems;
                foreach (var anItem in selectedItems)
                {
                    var item = anItem as Group;
                    //foreach (var groupPermission in item.GroupPermissions)
                    //{
                    //    var permission = new Permission
                    //    {
                    //        UserID = CurrentUser.UserID,
                    //        OperationID = groupPermission.OperationID,
                    //        Allow = groupPermission.Allow
                    //    };
                    //    repository.Permissions.Add(permission);     
                    //   activityLogger.SaveAction(CurrentUser.UserID, 1, "User Permission Window", "User Permission Succesfully Added");   
                    //  }
                    var ug = repository.UserGroups.FindBy(g => g.GroupID == item.GroupID && g.UserID == CurrentUser.UserID).FirstOrDefault();
                    if (ug != null)
                    {
                        ug.GroupStatus = true;
                        repository.UserGroups.Update(ug);
                    }
                    else
                    {
                        var usergroup = new UserGroup
                                            {
                                                GroupID = item.GroupID,
                                                UserID = CurrentUser.UserID,
                                                GroupStatus = true
                                            };
                        repository.UserGroups.Add(usergroup);
                        activityLogger.SaveAction(CurrentUser.UserID, 1, "Group Window", "Group Succesfully Added");
                        
                    }
                }
                this.Close();
            }
            catch (Exception ex)
            {
                ViewHelper.ShowErrorMessage("Unable to create user group!");
                errorLogger.SaveError(CurrentUser.UserID, 1, 1, 2, "Add group attempt", "Warehouse", ex);
            }
        }

        

        private void btnAddClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewGroupView_Load(object sender, EventArgs e)
        {
            // A hack to clear the selection.
            grouplistbox.SelectionMode = SelectionMode.None;
            grouplistbox.SelectionMode = SelectionMode.MultiSimple;
        }



        

        

        
    }
}