using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using HCMIS.Security.Common.DataContracts;

namespace HCMIS.Security.Common
{
    public sealed class SecurityPrincipal : IPrincipal
    {
        #region Fields
        private Dictionary<string,bool> _securityPermissions;
        private Dictionary<int, string> _securityGroups;
        private Dictionary<int, string> _stores;
        private Dictionary<int, string> _accounts;
        private UserIdentity _identity;
        private int p;
        #endregion

    
        private SecurityPrincipal(Dictionary<string, bool> securityPermissions, Dictionary<int, string> securityGroups, string username, Dictionary<int, string> stores, Dictionary<int, string> accounts)
            
        {
            this._securityPermissions = securityPermissions;
            this._securityGroups = securityGroups;
            this._stores = stores;
            this._accounts = accounts;
            
        }

        public SecurityPrincipal(int p)
        {
            // TODO: Complete member initialization
            this.p = p;
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
        public bool HasPermission(string formIdentifier, string permissionString)
        {
            string fullOperationName = formIdentifier + "-" + permissionString;
            return this._securityPermissions.Contains(new KeyValuePair<string, bool>(fullOperationName, true));
        }

        public bool HasPermission(string formIdentifier, string permission, int storeId)
        {
            return HasPermission(formIdentifier, permission) && this._stores.ContainsKey(storeId);
        }

        public bool HasPermission(string formIdentifier, string permission, int storeId, int accountId)
        {
            return HasPermission(formIdentifier, permission, storeId) && this._stores.ContainsKey(accountId);
        }
        #endregion

        #region Static Methods to create a SecurityPrincipal instance

        public static SecurityPrincipal CreateSecurityPrincipal(UserInformation userInfo)
        {
            if (userInfo != null)
            {
                return new SecurityPrincipal(userInfo.Permissions, userInfo.Groups, userInfo.Username, userInfo.Stores, userInfo.Accounts)
                {
                    _identity = UserIdentity.CreateUserIdentity(userInfo)
                };
            }
            return null;
        }
        #endregion
    }
}
