using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Web.Security;
using HCMIS.Security.Models;
using HCMIS.Security.Repository;
using HCMIS.Security.Helpers;

namespace HCMIS.Security.MVC
{
    public sealed class CustomRoleProvider : RoleProvider
    {
        #region Fields
        private UnitOfWork repository = UnitOfWork.CreateInstance();
        #endregion


        #region RoleProvider Members
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            ICollection<Group> groups = new Collection<Group>();
            foreach (string roleName in roleNames)
            {
                string name = roleName;
                groups.Add(repository.Groups.FindBy(g => g.Name == name).FirstOrDefault());
            }
            foreach (var username in usernames)
            {
                var user = repository.Users.FindByName(username);
                if (user == null) continue;
                var userGroups = (from ug in user.UserGroups select ug.Group).ToList();
                foreach (var group in groups)
                {
                    if (!(userGroups.Count(g => g.GroupID == @group.GroupID) > 0))
                    {
                        user.UserGroups.Add(new UserGroup()
                                                {
                                                    GroupID = group.GroupID
                                                });
                    }
                }
                repository.Users.Update(user);
            }
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            if (repository.Groups.FindBy(g => g.Name == roleName).Any())
                return;
            repository.Groups.Add(new Group()
                                     {
                                         Name = roleName
                                     });
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            if (repository.Groups.FindBy(g => g.Name == roleName).Any())
            {
                repository.Groups.DeleteBy(g => g.Name == roleName);
                return true;
            }
            return false;
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            return (from g in repository.Groups.GetAll() select g.Name).ToArray();
        }

        public override string[] GetRolesForUser(string username)
        {
            var groups = from ug in repository.Users.FindByName(username).UserGroups select ug.Group;
            return (from g in groups select g.Name).ToArray();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            var group = repository.Groups.FindBy(g => g.Name == roleName).FirstOrDefault();
            if (group == null)
                return null;
            var users = @group.UserGroups.Select(ug => ug.User).ToList();
            return (from u in users select u.UserName).ToArray();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            return (repository.Users.FindByName(username).UserGroups.Any(ug => ug.Group.Name == roleName));
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            return (repository.Groups.FindBy(g => g.Name == roleName).Any());
        }

        #endregion
    }
}
