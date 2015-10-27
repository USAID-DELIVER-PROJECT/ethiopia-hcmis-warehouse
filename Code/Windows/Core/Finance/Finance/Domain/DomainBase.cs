using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Concrete.Repository;
using HCMIS.Specification.Finance.Domain;

namespace HCMIS.Core.Finance.Domain
{
    using HCMIS.Concrete.Repository;
using HCMIS.Core.Finance.Factories;
    public class DomainBase:IDomainBase
    {
        internal IRepositoryFactory _Repository;
        internal DomainFactory _Domain;
        
        public DomainBase(IRepositoryFactory Repository)
        {
            _Repository = Repository;
            _Domain = new DomainFactory(Repository);
        }
        
    }
}
