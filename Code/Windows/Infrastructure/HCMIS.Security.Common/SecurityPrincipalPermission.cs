using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using IPermission = System.Security.IPermission;

namespace HCMIS.Security.Common
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Assembly, AllowMultiple = true, Inherited = false)]
    [Serializable]
    public sealed class SecurityPrincipalPermission : System.Security.IPermission
    {
        #region Fields
        private bool _unrestricted;
        private IPermission _copy;
        #endregion

        #region Custom Properties
        public bool Authenticated { get { return Thread.CurrentPrincipal.Identity.IsAuthenticated; } }
        public string Permission { get; set; }
        public int StoreID { get; set; }
        public int AccountID { get; set; }
        #endregion

        public SecurityPrincipalPermission(PermissionState state)
        {
            if (state == PermissionState.Unrestricted)
            {
                _unrestricted = true;
            }
            else
            {
                _unrestricted = false;
            }
        }


        public System.Security.IPermission Copy()
        {

            throw new NotImplementedException();
        }

        public void Demand()
        {
            throw new NotImplementedException();
        }

        public System.Security.IPermission Intersect(System.Security.IPermission target)
        {
            throw new NotImplementedException();
        }

        public bool IsSubsetOf(System.Security.IPermission target)
        {
            throw new NotImplementedException();
        }

        public System.Security.IPermission Union(System.Security.IPermission target)
        {
            throw new NotImplementedException();
        }

        public void FromXml(SecurityElement e)
        {
            throw new NotImplementedException();
        }

        public SecurityElement ToXml()
        {
            throw new NotImplementedException();
        }
    }
}
