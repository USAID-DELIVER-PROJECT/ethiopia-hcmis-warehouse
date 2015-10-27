using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Security.Common
{
    public interface IGroupPermission
    {
        int GroupPermissionID { get; set; }
        int GroupID { get; set; }
        int OperationID { get; set; }
    }
}
