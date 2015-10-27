using HCMIS.Specification.Finance.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HCMIS.Concrete.Repository;
using HCMIS.Test.Finance.Repository;
using HCMIS.Specification.Finance.Factories;
using HCMIS.Test.Finance.Setup;

namespace HCMIS.Test.Finance
{
    
    
    /// <summary>
    ///This is a test class for IActivityTest and is intended
    ///to contain all IActivityTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IActivityTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        internal virtual IActivity CreateIActivity()
        {
            IDomainFactory Domain = new FakeDomainFactory();
            IActivity target = Domain.Activity;
            return target;
        }

        /// <summary>
        ///A test for Load
        ///</summary>
        [TestMethod()]
        public void LoadActivityTest()
        {
            IActivity target = CreateIActivity(); 
            int ID = ActivitySetup.RDF_Regular ; 
            target.Load(ID);
            Assert.AreEqual(ID,target.ID);
        }

        /// <summary>
        ///A test for IsFreeStore
        ///</summary>
        [TestMethod()]
        public void IsFreeStoreTest()
        {
            IActivity target = CreateIActivity();
            target.Load(ActivitySetup.RCC1);
            bool actual;
            actual = target.IsFreeStore;
            Assert.AreEqual(true, actual);
        }

        /// <summary>
        ///A test for MovingAverageGroupID
        ///</summary>
        [TestMethod()]
        public void MovingAverageGroupIDTest()
        {
            IActivity FirstTarget = CreateIActivity();
            FirstTarget.Load(ActivitySetup.RCC1);
            IActivity SecondTarget = CreateIActivity();
            SecondTarget.Load(ActivitySetup.RCC2);
            Assert.AreEqual(FirstTarget.MovingAverageGroupID,SecondTarget.MovingAverageGroupID);

        }
    }
}
