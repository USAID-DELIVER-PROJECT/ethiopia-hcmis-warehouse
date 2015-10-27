using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCMIS.Security.DataContext;
using HCMIS.Security.Helpers;
using HCMIS.Security.Models;
using HCMIS.Security.Repository;
using System.Security.Permissions;
using System.Security.Authentication;
using System.Threading;
using HCMIS.Security.Common;
using HCMIS.Logging;
using HCMIS.Security.UserManagement.ViewModels;
using HCMIS.Security.UserManagement.Helpers;


namespace HCMIS.Security.UserManagement.Views
{
    [FormIdentifier("UM-UG-UL-FR")]
    public partial class UsersListView : DevExpress.XtraEditors.XtraForm
    {
        public bool ShowLoginWindowOnClose { get; set; }
        UnitOfWork repository = UnitOfWork.CreateInstance();

       
        public List<User> AllUsers { get; private set; }

        public UsersListView()
        {
            InitializeComponent();
            RefreshUsersList();

            if ((ModifierKeys & Keys.Control) == Keys.Control)
            {
                colDelete.Visible = true;
                colConsolidate.Visible = true;
            }
        }
       
        private void BtnAddNewUserClick(object sender, EventArgs e)
        {
            var window = new UserDetail(repository);
            window.ShowDialog();
        }

        private void BrnRefreshClick(object sender, EventArgs e)
        {
            RefreshUsersList();
        }

        private void RefreshUsersList()
        {
            repository = UnitOfWork.CreateInstance();
            AllUsers = repository.Users.GetAll().OrderBy(u=>u.UserName).ToList();
            UserListViewModel viewModel = new UserListViewModel(AllUsers);
            usersbindingSource.DataSource = viewModel.Users;
        }

       

        private void txtFilterUserName_EditValueChanged(object sender, EventArgs e)
        {
            gridUserListView.ActiveFilterString = string.Format("Username like '{0}%' or FirstName like '{0}' or LastName like '{0}'", txtFilterUserName.Text);
        }

        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
            var userDetailForm = new UserDetail((usersbindingSource.Current as UserViewModel).UserID,repository);
            userDetailForm.ShowDialog();
            RefreshUsersList();
        }

        private void repDelete_Click(object sender, EventArgs e)
        {
            var user = (UserViewModel)usersbindingSource[gridUserListView.FocusedRowHandle];
            if (user != null)
            {
               
                if (XtraMessageBox.Show("Are you sure you would like to delete this User?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        int id = user.UserID;
                        DirtyDBHelper.RemoveUserDependancies(id);
                        repository.Users.DeleteBy(j => j.UserID == id);
                        RefreshUsersList();
                        XtraMessageBox.Show("The User has been deleted", "Confirmation");
                    }
                    catch
                    {
                        XtraMessageBox.Show(
                            "This user cannot be deleted because it has been used in transactions. Either consolidate it or you will not be able to delete it.");
                    }
                }

            }
        }

        private void repConsolidate_Click(object sender, EventArgs e)
        {
            var user = (UserViewModel)usersbindingSource[gridUserListView.FocusedRowHandle];
            Consolidate oConsolidate = new Consolidate(repository,user.UserID);
            oConsolidate.ShowDialog();
            RefreshUsersList();
        }
     

        
    }
}