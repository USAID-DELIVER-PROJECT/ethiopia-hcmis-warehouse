using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Specification.Finance
{
    public interface ICostingMethod
    {
        void On(int receiptID);
       
    }

    
}
