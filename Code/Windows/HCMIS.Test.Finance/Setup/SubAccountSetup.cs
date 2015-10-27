using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Concrete.Repository;
using HCMIS.Concrete.Models;

namespace HCMIS.Test.Finance.Setup
{
    public class SubAccountSetup: SetupBase
    {
        public SubAccountSetup(IRepositoryFactory Repository)
            : base(Repository)
        {

        }
        public const int GF = 1;
        public const int RDF_Regular = 2;

        public void InsertGFHapcoSubAccountIntoHAPCO()
        {
            //Insert Health Program Mode For Testing
            Repository.StoreGroupDivisions.Insert(new StoreGroupDivision() { Name = "GF",StoreGroupID = AccountSetup.HAPCO});
      
        }
        public void InsertRDFRegularSubAccountIntoRDFRegular()
        {
            //Insert RDF Mode For Testing
            Repository.StoreGroupDivisions.Insert(new StoreGroupDivision() { Name = "RDF Regular", StoreGroupID = AccountSetup.RDF_Regular });
        }
        public static void InsertAllTestingData(IRepositoryFactory Repository)
        {
            ModeSetup.InsertAllTestingData(Repository);
            AccountSetup.InsertAllTestingData(Repository);
            SubAccountSetup subAccountSetup = new SubAccountSetup(Repository);
            subAccountSetup.InsertGFHapcoSubAccountIntoHAPCO();
            subAccountSetup.InsertRDFRegularSubAccountIntoRDFRegular();


        }
    }
}
