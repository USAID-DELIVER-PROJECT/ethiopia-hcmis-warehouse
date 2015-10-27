using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Specification.Finance.Domain.Entities
{
    public interface IOrder
    {
        
        int OrderTypeID { get; }
        IActivity Activity { get; }
        int SupplierID { get; }

        bool NonStandard { get; }
        bool Standard { get; }
       
        
    }
}
