using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HCMIS.Security.Helpers;
using HCMIS.Security.Models;
using HCMIS.Security.Repository;
using HCMIS.Logging;

namespace HCMIS.Security.UserManagement.Views
{
    public partial class UserDetail : DevExpress.XtraEditors.XtraForm
    {
       
        public User CurrentUser { get; private set; }
        private bool NewMode = true;
        
        UnitOfWork repository;

        public List<Activity> Accounts = new List<Activity>(); 
        public List<Store> Stores =new List<Store>(); 
        public List<Group> Groups =new List<Group>();
        //public List<Permission> Permissions = new List<Permission>();
        private static IActivityLog activityLogger = LogManager.GetActivityLogger("Some Page");
        private static IErrorLog errorLogger = LogManager.GetErrorLogger();
        private string _username;

        public UserDetail(UnitOfWork repo)
        {
            repository = repo;
            InitializeComponent();
            Refresh(0);
            Loadlookups();
          }

        private void Refresh(int userId)
        {
            repository.RefreshContext();
            CurrentUser = repository.Users.FindBy(u => u.UserID == userId).SingleOrDefault();
            currentUserBindingSource.DataSource = CurrentUser;
            if (CurrentUser != null)
            {
                //repository.Dispose();
                //repository = new UnitOfWork();

                CurrentUser = repository.Users.FindBy(u => u.UserID == userId).SingleOrDefault();
                currentUserBindingSource.DataSource = CurrentUser;
                Accounts = (from au in CurrentUser.AccountUsers.Where(u => u.IsActive && u.Account.SubAccount != null) select au.Account).OrderBy(o=>o.FullName).ToList();
                Stores = (from us in CurrentUser.StoreUsers.Where(u => u.IsActive) select us.Store).Where(o=>o.Warehouse != null).OrderBy(o=>o.FullName).ToList();
                Groups = (from ug in CurrentUser.UserGroups.Where(u => u.GroupStatus == true) select ug.Group).ToList();

                NewMode = false;

                deptbindingSource.DataSource = CurrentUser.Department;
                jobtitlebindingSource.DataSource = CurrentUser.JobTitle;

                // This is edit
                btnSetPassword.Enabled = true;
                btnClose.Enabled = true;
                btnDisable.Enabled = true;
                btnAddStore.Enabled = true;
                btnAddGroup.Enabled = true;
                btnAddAccount.Enabled = true;
                btnRemoveAccount.Enabled = true;
                btnRemoveGroup.Enabled = true;
                btnRemoveStore.Enabled = true;
                passwordtextEdit.Enabled = false;
                btnSetPassword.Enabled = true;
                isActiveCheckEdit.Enabled = false;
                Loadlookups();
                btnSaveUserDetail.Enabled = true;
                NewMode = false;
                Text = @"Edit User";

                _username = CurrentUser.UserName;
            }else
            {
                NewMode = true;
                btnSetPassword.Enabled = false;
                btnClose.Enabled = false;
                btnDisable.Enabled = false;
                btnAddStore.Enabled = false;
                btnAddGroup.Enabled = false;
                btnAddAccount.Enabled = false;
                btnRemoveAccount.Enabled = false;
                btnRemoveGroup.Enabled = false;
                btnRemoveStore.Enabled = false;
                CurrentUser = new User();
                currentUserBindingSource.DataSource = CurrentUser;
                Text = @"New User";
            }
            accountsbindingSource.DataSource = Accounts;
            storebindingSource.DataSource = Stores;
            groupsbindingSource.DataSource = Groups;
         }

        public UserDetail(int userId, UnitOfWork repo)
            : this(repo)
        {
            Refresh(userId);
            
        }
        
        private void Loadlookups()
        {
            deptbindingSource.DataSource = repository.Departments.GetAll().ToList();
            jobtitlebindingSource.DataSource = repository.JobTitles.GetAll().ToList();
        }

        private void BtnSaveUserDetailClick(object sender, EventArgs e)
        {
            currentUserBindingSource.EndEdit();
            if (!ValidateForm())
                return;
            try
            {
                if (NewMode)
                {
                    if (!repository.Users.UsernameIsAvailable(usernametextEdit.Text))
                    {
                        ViewHelper.ShowErrorMessage("Username already exist,Please provide a new one.");
                        activityLogger.SaveAction(CurrentUser.UserID, 1, "New user Window", "Username already exist,Please provide a new one.");   
                        return;
                    }
                    CurrentUser.IsActive = true;
                    CurrentUser.CreatedDate = Security.Helpers.DateTimeHelper.ServerDateTime;
                    if (CurrentUser.Password == null)
                    {
                        CurrentUser.Password = passwordtextEdit.Text;
                    }
                    CurrentUser.SetPassword(CurrentUser.Password);
                    CurrentUser.FullName = CurrentUser.FirstName + " " + CurrentUser.LastName;
                     // this is for supporting legacy code.
                    CurrentUser.UserType = 1;
                    CurrentUser.PasswordExpires = true;
                    repository.Users.Add(CurrentUser);
                   
                    ViewHelper.ShowSuccessMessage("User information added succesfully!");
                   // activityLogger.SaveAction(CurrentUser.UserID, 1, "New user Window", "New user added Succesfully");
                   Refresh(CurrentUser.UserID);
                   
                }

                else 
                {              
                    if (!(_username == usernametextEdit.Text) && !repository.Users.UsernameIsAvailable(usernametextEdit.Text))
                    {
                        ViewHelper.ShowErrorMessage("Username already exist,Please enter another one");
                        return;
                    }
                    CurrentUser.ModifiedDate = Security.Helpers.DateTimeHelper.ServerDateTime;
                     CurrentUser.FullName = CurrentUser.FirstName + " " + CurrentUser.LastName;
                     repository.Users.Update(CurrentUser);
                    
                    ViewHelper.ShowSuccessMessage("User information updated succesfully!");
                    activityLogger.SaveAction(CurrentUser.UserID, 1, "User detail Window", "User updated Succesfully"); 
                    
                }
            }
             catch (Exception ex)
            {
                
                 this.Close();
                
            }
        }

        private bool ValidateForm()
        {
            return UserValidation.Validate();                 
        }

        private void BtnResetPasswordClick(object sender, EventArgs e)
        {
            var user1 = currentUserBindingSource.Current as User;
            if (user1 != null)
            {
                var setpassword = new SetPasswordView(user1.UserID);
                setpassword.ShowDialog();
                Refresh(CurrentUser.UserID);
            }
        }

        private void BtnDisableClick(object sender, EventArgs e)
        {
            if (CurrentUser.IsActive == true)
            {
               var result = ViewHelper.ShowConfirmDialog("Do you want to disable this user?");
               if (result == DialogResult.Yes)
               {
                   CurrentUser.IsActive = false;
                   repository.Users.Update(CurrentUser);
                   //Helpers.SecurityHelper.EnableDisableUser(CurrentUser.UserID);
                   ViewHelper.ShowSuccessMessage("User disabled successfuly.");
                   activityLogger.SaveAction(CurrentUser.UserID, 1, "Disable user", "User disabled successfuly."); 
                   Refresh(CurrentUser.UserID);

               }
               else
               {
                   Exception ex = new Exception("Unable to disable user");
                   //errorLogger.SaveError(CurrentUser.UserID, 1, 1, 2, "Disable user account", "Warehouse", ex);
                   return;
               }
         }
            else if (CurrentUser.IsActive == false)
            {
                var result = ViewHelper.ShowConfirmDialog("Do you want to enable this user?");
                if (result == DialogResult.Yes)
                {
                    CurrentUser.IsActive = true;
                    repository.Users.Update(CurrentUser);
                    //SecurityHelper.EnableDisableUser(CurrentUser.UserID);
                    ViewHelper.ShowSuccessMessage("User password enabled successfuly.");
                    activityLogger.SaveAction(CurrentUser.UserID, 1, "Enable user", "User enabled successfuly."); 
                    Refresh(CurrentUser.UserID);
                }
                else
                {
                    Exception ex = new Exception("Unable to enable user account.");
                    errorLogger.SaveError(CurrentUser.UserID, 1, 1, 2, "Enable user account", "Warehouse", ex);
                    return;
                }

            }
            else
            {
                Exception ex = new Exception("Error disabling user account.");
                ViewHelper.ShowErrorMessage("Error disabling user account.");
                errorLogger.SaveError(CurrentUser.UserID, 1, 1, 2, "Enable/Disable user account", "Warehouse", ex);
               // this.Close();
            } 
                   
        }
        

       private void BtnAddAccountClick(object sender, EventArgs e)
        {
              var user1 = currentUserBindingSource.Current as User;
                if (user1 != null)
                {
                    var addaccount = new AddAccount(user1.UserID,repository);
                   addaccount.ShowDialog();
                   Refresh(CurrentUser.UserID);
                   
                }
            
        }

        private void BtnAddStoreClick(object sender, EventArgs e)
        {
            var user1 = currentUserBindingSource.Current as User;
            if (user1 != null)
            {
                var addstore = new AddStore(user1.UserID,repository);
                addstore.ShowDialog();
                Refresh(CurrentUser.UserID);
            }
            
        }

        private void BtnAddGroupClick(object sender, EventArgs e)
        {
               var user1 = currentUserBindingSource.Current as User;
                if (user1 != null)
                {
                    var addgroup = new AddGroup(user1.UserID,repository);
                    addgroup.ShowDialog();
                    Refresh(CurrentUser.UserID);
                }
            
        }

        private void btnRemoveAccount_Click(object sender, EventArgs e)
        {
            if (accountlistBox.SelectedItem == null)
            {
                ViewHelper.ShowErrorMessage("There is no account to be deleted.");
                activityLogger.SaveAction(CurrentUser.UserID, 1, "Remove user account", "There is no account to be deleted."); 
                this.Close();
            }
           var obj = repository.AccountUsers.FindBy(a => a.UserID == CurrentUser.UserID && a.AccountID == (int)accountlistBox.SelectedValue).SingleOrDefault();
           try
            {
                   var result =ViewHelper.ShowConfirmDialog("Do you want to remove the selected account?");
                    if (result == DialogResult.Yes)
                    {
                        obj.IsActive = false;
                        repository.AccountUsers.Update(obj);
                        activityLogger.SaveAction(CurrentUser.UserID, 1, "Remove user account", "User account successfuly removed.");
                        Refresh(CurrentUser.UserID);
                    }
                    else
                    {
                        return;
                    }
            }
                     
            
            catch (Exception ex)
            {

                ViewHelper.ShowErrorMessage("Unable to remove account", ex);
            }
        }

        private void btnRemoveStore_Click(object sender, EventArgs e)
        {
            if (storelistBox.SelectedItem == null)
            {
                ViewHelper.ShowErrorMessage("There is no store to be deleted.");
                activityLogger.SaveAction(CurrentUser.UserID, 1, "Remove store user", "There is no store to be deleted.");
                this.Close();
            }
            var obj = repository.StoreUsers.FindBy(a => a.UserID == CurrentUser.UserID && a.StoreID == (int)storelistBox.SelectedValue && a.IsActive == true).FirstOrDefault();
            try
            {
              var result = ViewHelper.ShowConfirmDialog("Do you want to remove the selected store?");
              if (result == DialogResult.Yes)
              {
                  obj.IsActive = false;
                  repository.StoreUsers.Delete(obj);
                  activityLogger.SaveAction(CurrentUser.UserID, 1, "Remove store user", "Store user successfuly removed."); 
                  Refresh(CurrentUser.UserID);
              }
              else
              {
                  return;
              }
            }
            catch (Exception ex)
            {

                ViewHelper.ShowErrorMessage("Unable to remove user store!", ex);
            }
        }

        private void btnRemoveGroup_Click(object sender, EventArgs e)
        {
            if (grouplistBox.SelectedItem == null)
            {
                ViewHelper.ShowErrorMessage("There is no group to be deleted.");
                activityLogger.SaveAction(CurrentUser.UserID, 1, "Remove user group", "There is no group to be deleted.");
                return;
            }
           var obj = CurrentUser.UserGroups.Where(a => a.UserID == CurrentUser.UserID && a.GroupID==(int)grouplistBox.SelectedValue).SingleOrDefault();
           try
            {
                var result = ViewHelper.ShowConfirmDialog("Do you want to remove the selected group?");
                if (result == DialogResult.Yes)
                {                   
                        foreach (var permission in obj.Group.GroupPermissions)
                        {
                            //var p = repository.Permissions.FindBy(r => r.OperationID == permission.OperationID).FirstOrDefault();
                            //if (p != null)
                            //{
                            //    repository.Permissions.Delete(p);
                            //    activityLogger.SaveAction(CurrentUser.UserID, 1, "Remove user permission", "User permission successfuly removed.");
                            //}
                            
                            Refresh(CurrentUser.UserID);
                        }
                        obj.GroupStatus = false;
                        repository.UserGroups.Update(obj);
                        activityLogger.SaveAction(CurrentUser.UserID, 1, "Remove user group", "User group successfuly removed."); 
                        Refresh(CurrentUser.UserID);
                    }
                 
                else
                {
                    return;
                }
            }


            catch (Exception ex)
            {
                ViewHelper.ShowErrorMessage("Unable to remove user group!", ex);     
            }
          }

        
        
        private void btnViewPermission_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserDetail_Load(object sender, EventArgs e)
        {

        }
    }
}