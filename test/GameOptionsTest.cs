using Two_Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;

namespace test
{
    
    
    /// <summary>
    ///This is a test class for GameOptionsTest and is intended
    ///to contain all GameOptionsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GameOptionsTest
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
        ///A test for changeDrink
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Two Server.exe")]
        public void changeDrinkTest()
        {
            GameOptions_Accessor target = new GameOptions_Accessor(); // TODO: Initialize to an appropriate value
            RadioButton r = null; // TODO: Initialize to an appropriate value
            target.changeDrink(r);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetButton_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Two Server.exe")]
        public void SetButton_ClickTest()
        {
            GameOptions_Accessor target = new GameOptions_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.SetButton_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Two Server.exe")]
        public void InitializeComponentTest()
        {
            GameOptions_Accessor target = new GameOptions_Accessor(); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GameOptions_Load
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Two Server.exe")]
        public void GameOptions_LoadTest()
        {
            GameOptions_Accessor target = new GameOptions_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.GameOptions_Load(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Drink2_CheckedChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Two Server.exe")]
        public void Drink2_CheckedChangedTest()
        {
            GameOptions_Accessor target = new GameOptions_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.Drink2_CheckedChanged(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Drink1_CheckedChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Two Server.exe")]
        public void Drink1_CheckedChangedTest()
        {
            GameOptions_Accessor target = new GameOptions_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.Drink1_CheckedChanged(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Drink0_CheckedChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Two Server.exe")]
        public void Drink0_CheckedChangedTest()
        {
            GameOptions_Accessor target = new GameOptions_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.Drink0_CheckedChanged(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Two Server.exe")]
        public void DisposeTest()
        {
            GameOptions_Accessor target = new GameOptions_Accessor(); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GameOptions Constructor
        ///</summary>
        [TestMethod()]
        public void GameOptionsConstructorTest()
        {
            GameOptions target = new GameOptions();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
