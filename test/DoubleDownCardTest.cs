﻿using Two_Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace test
{
    
    
    /// <summary>
    ///This is a test class for DoubleDownCardTest and is intended
    ///to contain all DoubleDownCardTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DoubleDownCardTest
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
        ///A test for OnDraw
        ///</summary>
        [TestMethod()]
        public void OnDrawTest()
        {
            DoubleDownCard target = new DoubleDownCard(); // TODO: Initialize to an appropriate value
            TwoServerWindow twoServer = null; // TODO: Initialize to an appropriate value
            Player player = null; // TODO: Initialize to an appropriate value
            string[] cardArgs = null; // TODO: Initialize to an appropriate value
            target.OnDraw(twoServer, player, cardArgs);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Execute
        ///</summary>
        [TestMethod()]
        public void ExecuteTest()
        {
            DoubleDownCard target = new DoubleDownCard(); // TODO: Initialize to an appropriate value
            TwoServerWindow twoServer = null; // TODO: Initialize to an appropriate value
            Player player = null; // TODO: Initialize to an appropriate value
            string[] cardArgs = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Execute(twoServer, player, cardArgs);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DoubleDownCard Constructor
        ///</summary>
        [TestMethod()]
        public void DoubleDownCardConstructorTest()
        {
            DoubleDownCard target = new DoubleDownCard();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
