using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Security.Common
{
    public interface IOperation
    {
        int OperationID { get; set; }
        string Name { get; set; }
        int MenuItemID { get; set; }
        string Description { get; set; }
    }
}
