using HCMIS.Core.Finance.CostingSheet;
using HCMIS.Specification.Finance.CostingSheet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HCMIS.Test.Finance
{
    
    
    /// <summary>
    ///This is a test class for ICostBuilderTest and is intended
    ///to contain all ICostBuilderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ICostBuilderTest
    {


        private TestContext _testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return _testContextInstance;
            }
            set
            {
                _testContextInstance = value;
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


        internal virtual ICostBuilder CreateICostBuilder()
        {
            ICostBuilder target = new StandardCostBuilder();
            return target;
        }

        /// <summary>
        ///A test for AddToTotalCost
        ///</summary>
        [TestMethod()]
        public void AddToTotalCostTest()
        {
            //initalize Components
            const decimal intialCost = 1000;
            ICostBuilder target = CreateICostBuilder();
            target.InitalCost = intialCost;
            const decimal cost = 2000;
            const decimal expected = intialCost + cost;
            decimal actual = 0;
            
            //try Catch is use to differentiate between
            
                actual = target.AddToTotalCost(cost);

            
          
            Assert.AreEqual(expected, actual, "Initial cost + Additional Cost is not the result return");
        }

        /// <summary>
        ///A test for GetUnitCost
        ///</summary>
        [TestMethod()]
        public void GetUnitCostTest()
        {
            // Initialization

            const decimal intialCost = 1000;
            const decimal cost = 2000;
            
            ICostBuilder target = CreateICostBuilder();
            target.InitalCost = intialCost;
            target.AddToTotalCost(cost);
          
            const decimal expected = 300;
            const decimal unitCost = 100;

            decimal actual = 0;
           
                actual = target.GetUnitCost(unitCost);    
            Assert.AreEqual(expected, actual," Because UnitCost for {0} should have been {2} but {1} was returned",cost,actual,expected);
        }

        /// <summary>
        ///A test for CostCoefficient
        ///</summary>
        [TestMethod()]
        public void CostCoefficientTest()
        {

            const decimal intialCost = 1000;
            const decimal cost = 2000;

            ICostBuilder target = CreateICostBuilder();
            target.InitalCost = intialCost;
            target.AddToTotalCost(cost);

            const decimal expected = 3;
            decimal actual = 0;
            actual = target.CostCoefficient;           
            Assert.AreEqual(expected, actual, "Because CostCoefficient expected was {1} but {0} was returned", actual, expected);         
        }

        /// <summary>
        ///A test for InitalCost
        ///</summary>
        [TestMethod()]
        public void InitalCostTest()
        {
          

            const decimal intialCost = 1000;
            const decimal cost = 2000;

            ICostBuilder target = CreateICostBuilder();
            target.InitalCost = intialCost;
            target.AddToTotalCost(cost);
            const decimal expected = intialCost;
            decimal actual = 0;
            actual = target.InitalCost;
            Assert.AreEqual(expected, actual, " Because InitalCost set was {1} but {0} was returned", actual, expected);
        }

        /// <summary>
        ///A test for TotalCost
        ///</summary>
        [TestMethod()]
        public void TotalCostTest()
        {
            const decimal intialCost = 1000;
            const decimal cost = 2000;

            ICostBuilder target = CreateICostBuilder();
            target.InitalCost = intialCost;
            decimal methodResult = target.AddToTotalCost(cost);
            const decimal expected = intialCost + cost;
            decimal actual = 0;
            actual = target.TotalCost;
            Assert.AreEqual(expected, actual, " Because TotalCost expected was {1} but {0} was returned", actual, expected);
            Assert.AreEqual(methodResult, actual, " Because The result return by AddToTotalCost() and the TotalCost Properties are not the Same");
        }
    }
}
