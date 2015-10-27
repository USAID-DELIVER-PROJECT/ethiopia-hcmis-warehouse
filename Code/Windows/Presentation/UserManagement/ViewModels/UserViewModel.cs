using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Security.Models;

namespace HCMIS.Security.UserManagement.ViewModels
{
    class UserViewModel
    {
        public UserViewModel()
        {

        }

        public UserViewModel(User user)
        {
            UserID = user.UserID;
            Username = user.UserName;
            if (user.AccountUsers != null)
            {
                //Accounts = (from au in user.AccountUsers.Where(u => u.IsActive) select au.Account).ToList();
                //Stores = (from su in user.StoreUsers.Where(u => u.IsActive) select su.Store).ToList();
               // Groups = (from ug in user.UserGroups select ug.Group).ToList();
                //Permissions = user.Permissions.ToList();
            }

            FirstName = user.FirstName;
            LastName = user.LastName;
            IsActive = user.IsActive;
            LastLogin = Convert.ToDateTime(user.LastLogin);
            Password = user.Password;
            DepartmentID = user.DepartmentID;
            JobTitleID = user.JobTitleID;
            CreatedDate = Convert.ToDateTime(user.CreatedDate);
            ModifiedDate = Convert.ToDateTime(user.ModifiedDate);
            if (user.PasswordExpires != null) PasswordExpires = (bool) user.PasswordExpires;
            ExpirationDate = Convert.ToDateTime(user.ExpirationDate);
        }

        public int UserID { get; set; }
        public string Username { get; set; }        
        public List<Activity> Accounts { get; set; }
        public List<Store> Stores { get; set; }
        public List<Group> Groups { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastLogin { get; set; }
        public string Password { get; set; }
        public int? DepartmentID { get; set; }
        public int? JobTitleID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int CreatedByID { get; set; }
        public bool PasswordExpires { get; set; }
        public DateTime? ExpirationDate { get; set; }

        public string AllowedAccounts
        {
            get { return String.Format("{0} of {1}",(this.Accounts != null)? this.Accounts.Count : 0, UserListViewModel.AvailableAccounts); }
        }

        public string AllowedStores
        {
            get { return String.Format("{0} of {1}", (this.Stores != null)? this.Stores.Count:0, UserListViewModel.AvailableStores); }
        }
        public string AllowedGroups
        {
            get { return String.Format("{0} of {1}", (this.Groups != null)?this.Groups.Count:0, UserListViewModel.AvailableGroups); }
        }
        //public List<Permission> Permissions { get; set; }
    }
}
