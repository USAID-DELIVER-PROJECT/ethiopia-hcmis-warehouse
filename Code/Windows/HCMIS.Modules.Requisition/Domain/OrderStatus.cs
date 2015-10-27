using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Modules.Requisition.Helpers;

namespace HCMIS.Modules.Requisition.Domain
{
    public enum OrderStatus
    {
        [Code("DRFT")]
        Draft,
        [Code("ORFI")]
        Submitted,
        [Code("APRD")]
        Approved,
    }
}
