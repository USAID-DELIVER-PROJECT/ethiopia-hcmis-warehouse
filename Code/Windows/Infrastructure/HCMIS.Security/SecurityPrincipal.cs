using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace HCMIS.Security
{
    public class SecurityPrincipal : IPrincipal
    {
        #region Fields
        private Dictionary<string,bool> _securityPermissions;
        private Dictionary<int, string> _securityGroups;
        private Dictionary<int, string> _stores;
        private Dictionary<int, string> _accounts;
        private UserIdentity _identity;
        #endregion

        private SecurityPrincipal(Dictionary<string,bool> securityPermissions, Dictionary<int,string> securityGroups, string username)
        {
            this._securityPermissions = securityPermissions;
            this._securityGroups = securityGroups;
            this._identity = UserIdentity.CreateUserIdentity(username);
        }

        private SecurityPrincipal(Dictionary<string, bool> securityPermissions, Dictionary<int, string> securityGroups, string username, Dictionary<int, string> stores, Dictionary<int, string> accounts)
            : this(securityPermissions, securityGroups, username)
        {
            this._stores = stores;
            this._accounts = accounts;
        }

        #region IPrincipal Members

        public IIdentity Identity
        {
            get { return this._identity; }
        }

        public bool IsInRole(string role)
        {
            return this._securityGroups.ContainsValue(role);
        }

        #endregion

        #region Custom Methods
        public bool HasPermission(string permissionString)
        {
            return this._securityPermissions.Contains(new KeyValuePair<string, bool>(permissionString, true));
        }

        public bool HasPermission(string permission, string store)
        {
            return HasPermission(permission) && this._stores.ContainsValue(store);
        }

        public bool HasPermission(string permission, string store, string account)
        {
            return HasPermission(permission, store) && this._stores.ContainsValue(account);
        }
        #endregion

        #region Static Methods to create a SecurityPrincipal instance
        public static SecurityPrincipal CreateSecurityPrincipal(Dictionary<string, bool> securityPermissions, Dictionary<int, string> securityGroups, string username)
        {
            return new SecurityPrincipal(securityPermissions,securityGroups,username);
        }

        public static SecurityPrincipal CreateSecurityPrincipal(Dictionary<string, bool> securityPermissions, Dictionary<int, string> securityGroups, string username, Dictionary<int, string> stores, Dictionary<int, string> accounts)
        {
            return new SecurityPrincipal(securityPermissions,securityGroups,username,stores,accounts);
        }
        #endregion
    }
}
