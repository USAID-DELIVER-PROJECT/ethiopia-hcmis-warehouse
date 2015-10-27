using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Specification.Finance.Factories;
using HCMIS.Concrete.Repository;
using HCMIS.Test.Finance.Repository;
using HCMIS.Core.Finance.Domain.Entities;
using HCMIS.Test.Finance.Setup;

namespace HCMIS.Test.Finance
{
    class FakeDomainFactory:IDomainFactory
    {

        IRepositoryFactory Repository; 

        public FakeDomainFactory()
        {
            Repository = new FakeRepositoryFactory();
            RepositoryInitializer Initializer = new RepositoryInitializer(Repository);
            Initializer.SetupAll();
            
        }
        public Specification.Finance.Domain.Entities.IActivity Activity
        {
            get 
            {
                return new Activity(Repository);
            }
        }

        public Specification.Finance.Domain.Entities.IInvoice Invoice
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Specification.Finance.Domain.Entities.IOrder Order
        {
            get { throw new NotImplementedException(); }
        }

        public Specification.Finance.Domain.Entities.IPreviousStock PreviousStock
        {
            get { throw new NotImplementedException(); }
        }

        public Specification.Finance.Domain.Aggregates.ICostElement CostElement
        {
            get { throw new NotImplementedException(); }
        }

        public Specification.Finance.Domain.Aggregates.IGRV GRV
        {
            get { throw new NotImplementedException(); }
        }
    }
}
