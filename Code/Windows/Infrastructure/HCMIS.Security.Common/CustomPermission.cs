using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;
using IPermission = System.Security.IPermission;

namespace HCMIS.Security.Common
{
    class CustomPermission : IPermission
    {
        public int PermissionID
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

        public int OperationID
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

        public int UserID
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

        public bool Allow
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

        public IPermission Copy()
        {
            throw new NotImplementedException();
        }

        public void Demand()
        {
            throw new NotImplementedException();
        }

        public IPermission Intersect(IPermission target)
        {
            throw new NotImplementedException();
        }

        public bool IsSubsetOf(IPermission target)
        {
            throw new NotImplementedException();
        }

        public IPermission Union(IPermission target)
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
