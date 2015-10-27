using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Core.Finance.Domain;
using HCMIS.Specification.Finance.Domain.Entities;
using HCMIS.Concrete.Repository;

namespace HCMIS.Core.Finance.Domains.Entities
{
    class Order:DomainBase,IOrder
    {
        public Order(IRepositoryFactory Repository)
            : base(Repository)
        {
            
        }

        public int OrderTypeID
        {
            get { throw new NotImplementedException(); }
        }

        public IActivity Activity
        {
            get { throw new NotImplementedException(); }
        }

        public int SupplierID
        {
            get { throw new NotImplementedException(); }
        }

        public bool NonStandard
        {
            get { throw new NotImplementedException(); }
        }


        public bool Standard
        {
            get { throw new NotImplementedException(); }
        }
    }
}
