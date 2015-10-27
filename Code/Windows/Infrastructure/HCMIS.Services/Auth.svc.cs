using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Authentication;
using System.Security.Principal;
using System.ServiceModel;
using System.Text;
using HCMIS.Security.Common.DataContracts;
using HCMIS.Security.Repository;

namespace HCMIS.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Auth" in code, svc and config file together.
    public class Auth : IAuth
    {
        public Auth()
        {
            HCMIS.Security.Settings.ConnectionString = "Server=.\\SQLEXPRESS;Database=Security;Trusted_Connection=true;";
        }

        public void DoWork()
        {
        }


        public UserInformation Authenticate(string username, string password)
        {
            var userInformation = new UserInformation();
            var repository = new UserRepository();
            var user = repository.FindBy(u => u.Username == username).FirstOrDefault();
            var userGroupRepository = new UserGroupRepository();
            var groups = userGroupRepository.FindBy(u => u.UserID == user.UserID);
            if (user == null || !user.CheckPassword(password))
                return null;
            userInformation.Username = user.Username;
            if (user.Permissions != null)
                userInformation.Permissions = user.Permissions.ToDictionary(permission => permission.Operation.Name, permission => permission.Allow);
            if (groups != null)
                userInformation.Groups = groups.ToDictionary(usergroup => usergroup.GroupID,
                                                                      usergroup => usergroup.Group.Name);
            if (user.StoreUsers != null)
                userInformation.Stores = user.StoreUsers.ToDictionary(store => store.StoreID, store => store.Store.Name);
            if (user.AccountUsers != null)
                userInformation.Accounts = user.AccountUsers.ToDictionary(account => account.AccountID,
                                                                          account => account.Account.Name);
            return userInformation;
        }
    }
}
