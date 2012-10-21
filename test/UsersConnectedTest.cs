using Two_Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace test
{
    
    
    /// <summary>
    ///This is a test class for UsersConnectedTest and is intended
    ///to contain all UsersConnectedTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UsersConnectedTest
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
        ///A test for UsersConnected_Load
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Two Server.exe")]
        public void UsersConnected_LoadTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            UsersConnected_Accessor target = new UsersConnected_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.UsersConnected_Load(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for PlayerJoined
        ///</summary>
        [TestMethod()]
        public void PlayerJoinedTest()
        {
            PlayerList pL = null; // TODO: Initialize to an appropriate value
            UsersConnected target = new UsersConnected(pL); // TODO: Initialize to an appropriate value
            int playerNumber = 0; // TODO: Initialize to an appropriate value
            target.PlayerJoined(playerNumber);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Two Server.exe")]
        public void InitializeComponentTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            UsersConnected_Accessor target = new UsersConnected_Accessor(param0); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Two Server.exe")]
        public void DisposeTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            UsersConnected_Accessor target = new UsersConnected_Accessor(param0); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for BuildListFromThread
        ///</summary>
        [TestMethod()]
        public void BuildListFromThreadTest()
        {
            PlayerList pL = null; // TODO: Initialize to an appropriate value
            UsersConnected target = new UsersConnected(pL); // TODO: Initialize to an appropriate value
            target.BuildListFromThread();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for BuildList
        ///</summary>
        [TestMethod()]
        public void BuildListTest()
        {
            PlayerList pL = null; // TODO: Initialize to an appropriate value
            UsersConnected target = new UsersConnected(pL); // TODO: Initialize to an appropriate value
            target.BuildList();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UsersConnected Constructor
        ///</summary>
        [TestMethod()]
        public void UsersConnectedConstructorTest()
        {
            PlayerList pL = null; // TODO: Initialize to an appropriate value
            UsersConnected target = new UsersConnected(pL);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
