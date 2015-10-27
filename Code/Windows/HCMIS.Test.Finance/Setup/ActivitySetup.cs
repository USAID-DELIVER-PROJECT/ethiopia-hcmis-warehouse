using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Concrete.Repository;
using HCMIS.Concrete.Models;

namespace HCMIS.Test.Finance.Setup
{
    public class ActivitySetup: SetupBase
    {
        public ActivitySetup(IRepositoryFactory Repository)
            : base(Repository)
        {

        }
        public const int RCC1 = 1;
        public const int RCC2 = 2;
        public const int RDF_Regular = 3;

        public void InsertRCCActivityIntoHAPCO()
        {
            //Insert Health Program Mode For Testing
            Repository.Stores.Insert(new Store() { StoreName = "RCC1", StoreGroupDivisionID = SubAccountSetup.GF });
            Repository.Stores.Insert(new Store() { StoreName = "RCC2", StoreGroupDivisionID = SubAccountSetup.GF });
      
        }
        public void InsertRDFRegularActivitytIntoRDFRegular()
        {
            //Insert RDF Mode For Testing
            Repository.Stores.Insert(new Store() { StoreName = "RDF Regular", StoreGroupDivisionID = SubAccountSetup.RDF_Regular });
        }
        public static void InsertAllTestingData(IRepositoryFactory Repository)
        {
            ModeSetup.InsertAllTestingData(Repository);
            AccountSetup.InsertAllTestingData(Repository);
            SubAccountSetup.InsertAllTestingData(Repository);
            ActivitySetup activitySetup = new ActivitySetup(Repository);
            activitySetup.InsertRCCActivityIntoHAPCO();
            activitySetup.InsertRDFRegularActivitytIntoRDFRegular();
        }
    }
}
