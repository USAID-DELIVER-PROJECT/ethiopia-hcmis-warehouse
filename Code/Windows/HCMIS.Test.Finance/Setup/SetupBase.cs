using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Concrete.Repository;

namespace HCMIS.Test.Finance.Setup
{
   public class SetupBase
    {
       
       IRepositoryFactory _Repository;
       public SetupBase(IRepositoryFactory Repository)
       {
           _Repository = Repository;
       }

        public IRepositoryFactory Repository
        {
            get
            {
                return _Repository;
            }
        }
       
    }
}
