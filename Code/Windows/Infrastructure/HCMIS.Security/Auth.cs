using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using HCMIS.Security.Common;
using HCMIS.Security.Common.DataContracts;
using HCMIS.Security.Helpers;
using HCMIS.Security.Repository;

namespace HCMIS.Security
{
    public class Auth
    {
        private static UnitOfWork repository = UnitOfWork.CreateInstance();
        public static void InitalizeRepository()
        {
            // Just make sure that this repository has been initalized.
            repository.Users.FindBy(u => u.UserName == "").FirstOrDefault();
        }

        public static UserInformation Authenticate(string username, string password)
        {
            Settings.EncryptionAlgorithm = EncryptionAlgorithms.MD5;
            var userInformation = new UserInformation();

            var user = repository.Users.FindBy(u => u.UserName == username).FirstOrDefault();
            if (user == null || !user.CheckPassword(password) || !user.IsActive)
                return null;
            user.LastLogin = Helpers.DateTimeHelper.ServerDateTime;
            repository.Users.Update(user);
            userInformation.UserID = user.UserID;
            userInformation.Username = user.UserName;

           // if (user.Permissions != null)
            {
                var groups = user.UserGroups.Where(ug => ug.GroupStatus == true).Select(ug => ug.Group);
                userInformation.Permissions = new Dictionary<string, bool>();
                // do the following in the name of optimization
                // Amen to all

                IEnumerable<string> permissions = repository.RawSql<string>(string.Format("select mi.URL + '-' + o.Name from ( select * from [UserGroup] where UserID = {0} and IsActive = 1) ug join (select * from GroupPermission where Allow = 1) gp on ug.GroupID = gp.GroupID join Operation o on o.OperationID = gp.OperationID join MenuItem mi on mi.MenuItemID = o.MenuItemID  join ResourceType rt on mi.ResourceTypeID = rt.ResourceTypeID where rt.ResourceTypeCode = 'WIN'", user.UserID));
                foreach (var operation in permissions)
                {
                    if (!userInformation.Permissions.ContainsKey(operation))
                    {
                        userInformation.Permissions.Add(operation, true);
                    }
                }
                // what was below was replaced by up above
                // and the result was tremendous improvement
                //foreach (var group in groups)
                //{
                //    // Materialize everything whenever you have to iterate on it. this helps reduce the round trips
                //    //var allowedOperations = group.GroupPermissions.Where(p => p.Allow == true).Select(p => p.Operation).Select( operation => operation.MenuItem.URL + "-" + operation.Name).ToList();
                //    //foreach (var operation in allowedOperations)
                //    //{
                //    //    if (!userInformation.Permissions.ContainsKey(operation))
                //    //    {
                //    //        userInformation.Permissions.Add(operation,true);
                //    //    }  
                //    //}
                //}

                //user.Permissions.ToDictionary(permission => permission.Operation.Name, permission => permission.Allow);
            }

            //if (user.UserGroups != null)
            //{
            //    userInformation.Groups = user.UserGroups.Where(g=>g.GroupStatus == true).Select(g=>g.Group).Distinct().ToDictionary(usergroup => usergroup.GroupID,
            //                                                         usergroup => usergroup.Name);
            //}

            //if (user.StoreUsers != null)
            //{
            //    userInformation.Stores = user.StoreUsers.Where(store=>store.Store.Warehouse != null).Select(s=>s.Store).ToList().Distinct().ToDictionary(store => store.StoreID, store => store.Name);
            //}

            //if (user.AccountUsers != null)
            //{
            //    userInformation.Accounts = user.AccountUsers.Where(u=>u.IsActive == true).Select(u=>u.Account).ToList().Distinct().ToDictionary(account => account.ActivityID,
            //                                                              account => account.Name);
            //}

            // This line is there to cope with User's full name created with the legacy User Management and the new one?????

            userInformation.FullName = (user.FullName != null) ? user.FullName : user.FirstName + " " + user.LastName;

            return userInformation;
        }

        public static UserInformation Authenticate(string username)
        {
            Settings.EncryptionAlgorithm = EncryptionAlgorithms.MD5;
            var userInformation = new UserInformation();

            var user = repository.Users.FindBy(u => u.UserName == username).FirstOrDefault();
            if (user == null || !user.IsActive)
                return null;
            userInformation.UserID = user.UserID;
            userInformation.Username = user.UserName;

            //if (user.Permissions != null)
            {
                var groups = user.UserGroups.Where(ug => ug.GroupStatus == true).Select(ug => ug.Group);
                userInformation.Permissions = new Dictionary<string, bool>();
                IEnumerable<string> permissions =
                    repository.RawSql<string>(
                        string.Format(  "select mi.URL + '-' + o.Name from ( select * from [UserGroup] where UserID = {0} and IsActive = 1) ug join (select * from GroupPermission where Allow = 1) gp on ug.GroupID = gp.GroupID join Operation o on o.OperationID = gp.OperationID join MenuItem mi on mi.MenuItemID = o.MenuItemID  join ResourceType rt on mi.ResourceTypeID = rt.ResourceTypeID where rt.ResourceTypeCode = 'WIN'",  user.UserID));
                foreach (var operation in permissions)
                {
                    if (!userInformation.Permissions.ContainsKey(operation))
                    {
                        userInformation.Permissions.Add(operation, true);
                    }
                }
            }
            userInformation.FullName = (user.FullName != null)
                                               ? user.FullName
                                               : user.FirstName + " " + user.LastName;

            return userInformation;

        }
    }
}
