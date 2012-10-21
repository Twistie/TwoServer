using Two_Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace test
{
    
    
    /// <summary>
    ///This is a test class for TimedEventTest and is intended
    ///to contain all TimedEventTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TimedEventTest
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


        /// <summary>
        ///A test for Start
        ///</summary>
        [TestMethod()]
        public void StartTest()
        {
            TwoServerWindow twoServer = null; // TODO: Initialize to an appropriate value
            float timeToEvent = 0F; // TODO: Initialize to an appropriate value
            TimedEvent target = new TimedEvent(twoServer, timeToEvent); // TODO: Initialize to an appropriate value
            target.Start();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Running
        ///</summary>
        [TestMethod()]
        public void RunningTest()
        {
            TwoServerWindow twoServer = null; // TODO: Initialize to an appropriate value
            float timeToEvent = 0F; // TODO: Initialize to an appropriate value
            TimedEvent target = new TimedEvent(twoServer, timeToEvent); // TODO: Initialize to an appropriate value
            target.Running();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Execute
        ///</summary>
        [TestMethod()]
        public void ExecuteTest()
        {
            TwoServerWindow twoServer = null; // TODO: Initialize to an appropriate value
            float timeToEvent = 0F; // TODO: Initialize to an appropriate value
            TimedEvent target = new TimedEvent(twoServer, timeToEvent); // TODO: Initialize to an appropriate value
            target.Execute();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for TimedEvent Constructor
        ///</summary>
        [TestMethod()]
        public void TimedEventConstructorTest()
        {
            TwoServerWindow twoServer = null; // TODO: Initialize to an appropriate value
            float timeToEvent = 0F; // TODO: Initialize to an appropriate value
            TimedEvent target = new TimedEvent(twoServer, timeToEvent);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
