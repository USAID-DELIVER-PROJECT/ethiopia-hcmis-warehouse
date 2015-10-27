using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Security.Common
{
    public interface IGroup
    {
        int GroupID { get; set; }
        string Name { get; set; }
        int? ParentID { get; set; }
    }
}
