using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Concrete.Repository;
using HCMIS.Concrete.Models;

namespace HCMIS.Test.Finance.Setup
{
    public class RepositoryInitializer: SetupBase
    {
        public RepositoryInitializer(IRepositoryFactory Repository)
            : base(Repository)
        {

        }
        public void SetupAll()
        {
            ActivitySetup.InsertAllTestingData(Repository);
        }
    }
}
