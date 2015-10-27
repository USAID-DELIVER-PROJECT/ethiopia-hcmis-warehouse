using System;
using System.Collections.Generic;
using System.Linq;
using HCMIS.Specification.Finance.Domain;
using HCMIS.Specification.Finance.Domain.Aggregates;
using HCMIS.Specification.Finance.Domain.Entities;

namespace HCMIS.Specification.Finance.Factories
{
     public interface IDomainFactory
    {

    
        IActivity Activity
        {
            get;
        }
        IInvoice Invoice
        {
            get;
        }
        IOrder Order
        {
            get;
        }
        IPreviousStock PreviousStock
        {
            get;
        }
        ICostElement CostElement
        {
            get;
        }
        IGRV GRV
        {
            get;
        }
       
    }
}
