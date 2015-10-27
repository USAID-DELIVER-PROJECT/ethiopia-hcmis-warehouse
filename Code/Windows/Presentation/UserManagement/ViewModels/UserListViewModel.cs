using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Security.Models;

namespace HCMIS.Security.UserManagement.ViewModels
{
    class UserListViewModel : ViewModelBase
    {
        public UserListViewModel(List<User> users)
        {
            this.Users = new List<UserViewModel>();
            foreach (var user in users)
            {
                Users.Add(new UserViewModel(user));
            }
            //AvailableStores = Repository.Stores.GetAll().Count();
            //AvailableAccounts = Repository.Accounts.GetAll().Count();
            //AvailableGroups = Repository.Groups.GetAll().Count();
           
        }

        public List<UserViewModel> Users { get; set; }
        public static int AvailableAccounts { get; set; }
        public static int AvailableStores { get; set; }
        public static int AvailableGroups { get; set; }
        
    }
}
