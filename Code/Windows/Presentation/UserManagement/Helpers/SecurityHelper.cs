using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using HCMIS.Logging;
using HCMIS.Security.Common;
using HCMIS.Security.Helpers;
using HCMIS.Security.Models;
using HCMIS.Security.Repository;

namespace HCMIS.Security.UserManagement.Helpers
{
    public static class SecurityHelper
    {
        private static IUnitOfWork _repository;

        public static IUnitOfWork Repository
        {
            get { return _repository ?? (UnitOfWork.CreateInstance()); }
            set { _repository = value; }
        }
        
        
        private static IActivityLog activityLogger = LogManager.GetActivityLogger("this");
        private static IErrorLog errorLogger = LogManager.GetErrorLogger();

        
        public static SecurityPrincipal CurrentPrincipal
        {
            get { return Thread.CurrentPrincipal as SecurityPrincipal; }
        }

        public static bool Login(string username, string password)
        {
            var userInfo = Auth.Authenticate(username, password);
            if (userInfo == null)
            {
                errorLogger.SaveError(0,1,1,2,"Login Attempt","Warehouse",new InvalidCredentialException("Invalid credentials, Username = " + username));
                return false;
            }
            Thread.CurrentPrincipal = SecurityPrincipal.CreateSecurityPrincipal(userInfo);
            activityLogger.SaveAction(userInfo.UserID,1,"Login Window","Successful Login");
            return true;
        }

        public static bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            if(Thread.CurrentPrincipal.Identity.Name == username)
            {
                var user = Repository.Users.FindByName(username);
                if (!user.CheckPassword(oldPassword))
                    return false;
                else
                {
                    user.SetPassword(newPassword);
                    Repository.Users.Update(user);
                    return true;
                }
            }
            errorLogger.SaveError(Repository.Users.FindByName(Thread.CurrentPrincipal.Identity.Name).UserID,0,0,0,"ChangePassword","Unknown",new Exception("The supplied password was incorrect."));
            return false;
        }
        
        public static bool ChangePassword(IUnitOfWork repository, string userName, string oldPassword, string newPassword)
        {
            Repository = repository;
            return ChangePassword(userName, oldPassword, newPassword);
        }

        public static bool ResetPassword(string username, string newPassword)
        {
            var user = Repository.Users.FindByName(username);
            if(user == null)
                return false;
            user.SetPassword(newPassword);
            Repository.Users.Update(user);
            return true;
        }

        public static bool EnableDisableUser(int userID)
        {
            var user = Repository.Users.FindBy(u=>u.UserID == userID).FirstOrDefault();
            if (user == null)
                return false;
            user.IsActive = !user.IsActive;
            Repository.Users.Update(user);
            return true;
        }

        public static List<User> AllUsers()
        {
            return Repository.Users.GetAll().ToList();
        }

        public static bool CreateUser(User user)
        {
            try
            {
                Repository.Users.Add(user);
                return true;
            }
            catch(Exception exception)
            {
                errorLogger.SaveError(0,0,0,2,"Create User","",exception);
                return false;
            }
        }

        public static bool UsernameIsAvailable(string username)
        {
            return Repository.Users.UsernameIsAvailable(username);
        }

        public static void AssignToGroup(int userId, int groupId)
        {
            Repository.UserGroups.Add(new UserGroup()
                               {
                                   UserID = userId,
                                   GroupID = groupId
                               });
        }

        public static void AssignToStore(int userId, int storeId)
        {
            Repository.StoreUsers.Add(new StoreUser()
                               {
                                   UserID = userId,
                                   StoreID = storeId
                               });
        }

        public static void AssignToAccount(int userId, int accountId)
        {
            Repository.AccountUsers.Add(new AccountUser()
                               {
                                   UserID = userId,
                                   AccountID = accountId
                               });
        }


    }
}
