using System;
using System.Collections.Generic;
using System.Linq;
using HCMIS.Specification.Finance.Domain.Entities;
using HCMIS.Concrete.Repository;
using HCMIS.Specification.Finance.Factories;
using HCMIS.Specification.Finance.Domain.Aggregates;

namespace HCMIS.Core.Finance.Factories
{
     public class DomainFactory:IDomainFactory
    {
         IRepositoryFactory _Repository;

         public DomainFactory(IRepositoryFactory Repository)
         {
             _Repository = Repository;
         }


         public IActivity Activity
         {
             get { throw new NotImplementedException(); }
         }

         public IInvoice Invoice
         {
             get { throw new NotImplementedException(); }
         }

         public IOrder Order
         {
             get { throw new NotImplementedException(); }
         }

         public IPreviousStock PreviousStock
         {
             get { throw new NotImplementedException(); }
         }

         public ICostElement CostElement
         {
             get { throw new NotImplementedException(); }
         }

         public IGRV GRV
         {
             get { throw new NotImplementedException(); }
         }
    }
    
}
