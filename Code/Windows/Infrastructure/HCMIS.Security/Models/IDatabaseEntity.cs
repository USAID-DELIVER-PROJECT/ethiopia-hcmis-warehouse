using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Security.Models
{
    interface IDatabaseEntity
    {
        int CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
    }
}
