using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Concrete.Repository;
using HCMIS.Concrete.Models;

namespace HCMIS.Test.Finance.Setup
{
    public class ModeSetup: SetupBase
    {
        public ModeSetup(IRepositoryFactory Repository)
            : base(Repository)
        {
        } 
        
        public const int HEALTH_PROGRAM = 1;
        public const int RDF = 2 ;
        public void InsertHealthProgramIntoRepo()
        {
            //Insert Health Program Mode For Testing
            Repository.StoreTypes.Insert(new StoreType() { TypeName = "Health Program" });
        }
        public void InsertRDFIntoRepo()
        {
            //Insert RDF Mode For Testing
            Repository.StoreTypes.Insert(new StoreType() { TypeName = "RDF Regular" });
        }
        public static void InsertAllTestingData(IRepositoryFactory Repository)
        {
            ModeSetup modeSetup = new ModeSetup(Repository);
            modeSetup.InsertHealthProgramIntoRepo();
            modeSetup.InsertRDFIntoRepo();
        }
    }
}
