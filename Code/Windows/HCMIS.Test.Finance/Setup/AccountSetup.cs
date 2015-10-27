using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Concrete.Repository;
using HCMIS.Concrete.Models;

namespace HCMIS.Test.Finance.Setup
{
    public class AccountSetup: SetupBase
    {
        public AccountSetup(IRepositoryFactory Repository)
            : base(Repository)
        {

        }
        public const int HAPCO = 1;
        public const int RDF_Regular = 2;

        public void InsertHapcoAccountIntoHealthProgram()
        {
            //Insert Health Program Mode For Testing
            Repository.StoreGroups.Insert(new StoreGroup() { Name = "HAPCO",StoreTypeID = ModeSetup.HEALTH_PROGRAM });
      
        }
        public void InsertRDFRegularAccountIntoRDF()
        {
            //Insert RDF Mode For Testing
            Repository.StoreGroups.Insert(new StoreGroup() { Name = "RDF Regular", StoreTypeID = ModeSetup.RDF });
        }
        public static void InsertAllTestingData(IRepositoryFactory Repository)
        {
            ModeSetup.InsertAllTestingData(Repository);
            AccountSetup accountSetup = new AccountSetup(Repository);
            accountSetup.InsertHapcoAccountIntoHealthProgram();
            accountSetup.InsertRDFRegularAccountIntoRDF();

        }
    }
}
