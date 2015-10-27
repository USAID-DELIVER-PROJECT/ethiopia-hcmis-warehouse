using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Concrete.Repository;
using HCMIS.Specification.Finance.Domain;

namespace HCMIS.Core.Finance.Domain
{
    using HCMIS.Concrete.Repository;
    public class DomainBase:IDomainBase
    {
        internal IRepositoryFactory _Repository;

       public DomainBase(IRepositoryFactory Repository)
        {
            _Repository = Repository;
        }
    }
}
