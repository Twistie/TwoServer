using Two_Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;

namespace test
{
    
    
    /// <summary>
    ///This is a test class for PlayerListTest and is intended
    ///to contain all PlayerListTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PlayerListTest
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
        ///A test for UnsetFufu
        ///</summary>
        [TestMethod()]
        public void UnsetFufuTest()
        {
            TwoServerWindow twoServ = null; // TODO: Initialize to an appropriate value
            PlayerList target = new PlayerList(twoServ); // TODO: Initialize to an appropriate value
            target.UnsetFufu();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SwapPlayer
        ///</summary>
        [TestMethod()]
        public void SwapPlayerTest()
        {
            TwoServerWindow twoServ = null; // TODO: Initialize to an appropriate value
            PlayerList target = new PlayerList(twoServ); // TODO: Initialize to an appropriate value
            int p1 = 0; // TODO: Initialize to an appropriate value
            int p2 = 0; // TODO: Initialize to an appropriate value
            target.SwapPlayer(p1, p2);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetPlayer
        ///</summary>
        [TestMethod()]
        public void SetPlayerTest()
        {
            TwoServerWindow twoServ = null; // TODO: Initialize to an appropriate value
            PlayerList target = new PlayerList(twoServ); // TODO: Initialize to an appropriate value
            int player = 0; // TODO: Initialize to an appropriate value
            target.SetPlayer(player);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetFufu
        ///</summary>
        [TestMethod()]
        public void SetFufuTest()
        {
            TwoServerWindow twoServ = null; // TODO: Initialize to an appropriate value
            PlayerList target = new PlayerList(twoServ); // TODO: Initialize to an appropriate value
            int playerToFufu = 0; // TODO: Initialize to an appropriate value
            target.SetFufu(playerToFufu);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ResetLightMaster
        ///</summary>
        [TestMethod()]
        public void ResetLightMasterTest()
        {
            TwoServerWindow twoServ = null; // TODO: Initialize to an appropriate value
            PlayerList target = new PlayerList(twoServ); // TODO: Initialize to an appropriate value
            target.ResetLightMaster();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for RemovePlayerCard
        ///</summary>
        [TestMethod()]
        public void RemovePlayerCardTest()
        {
            TwoServerWindow twoServ = null; // TODO: Initialize to an appropriate value
            PlayerList target = new PlayerList(twoServ); // TODO: Initialize to an appropriate value
            Player p = null; // TODO: Initialize to an appropriate value
            Card c = null; // TODO: Initialize to an appropriate value
            target.RemovePlayerCard(p, c);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for PlayerTurnedOnLight
        ///</summary>
        [TestMethod()]
        public void PlayerTurnedOnLightTest()
        {
            TwoServerWindow twoServ = null; // TODO: Initialize to an appropriate value
            PlayerList target = new PlayerList(twoServ); // TODO: Initialize to an appropriate value
            Player p = null; // TODO: Initialize to an appropriate value
            target.PlayerTurnedOnLight(p);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for PlayerLight
        ///</summary>
        [TestMethod()]
        public void PlayerLightTest()
        {
            TwoServerWindow twoServ = null; // TODO: Initialize to an appropriate value
            PlayerList target = new PlayerList(twoServ); // TODO: Initialize to an appropriate value
            Player p = null; // TODO: Initialize to an appropriate value
            target.PlayerLight(p);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for PlayerFailedLight
        ///</summary>
        [TestMethod()]
        public void PlayerFailedLightTest()
        {
            TwoServerWindow twoServ = null; // TODO: Initialize to an appropriate value
            PlayerList target = new PlayerList(twoServ); // TODO: Initialize to an appropriate value
            Player p = null; // TODO: Initialize to an appropriate value
            target.PlayerFailedLight(p);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for NextPlayer
        ///</summary>
        [TestMethod()]
        public void NextPlayerTest()
        {
            TwoServerWindow twoServ = null; // TODO: Initialize to an appropriate value
            PlayerList target = new PlayerList(twoServ); // TODO: Initialize to an appropriate value
            int noOfTurns = 0; // TODO: Initialize to an appropriate value
            target.NextPlayer(noOfTurns);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetRandomPlayer
        ///</summary>
        [TestMethod()]
        public void GetRandomPlayerTest()
        {
            TwoServerWindow twoServ = null; // TODO: Initialize to an appropriate value
            PlayerList target = new PlayerList(twoServ); // TODO: Initialize to an appropriate value
            Player expected = null; // TODO: Initialize to an appropriate value
            Player actual;
            actual = target.GetRandomPlayer();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetNextPlayer
        ///</summary>
        [TestMethod()]
        public void GetNextPlayerTest()
        {
            TwoServerWindow twoServ = null; // TODO: Initialize to an appropriate value
            PlayerList target = new PlayerList(twoServ); // TODO: Initialize to an appropriate value
            int noOfTurns = 0; // TODO: Initialize to an appropriate value
            Player expected = null; // TODO: Initialize to an appropriate value
            Player actual;
            actual = target.GetNextPlayer(noOfTurns);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FufuDrink
        ///</summary>
        [TestMethod()]
        public void FufuDrinkTest()
        {
            TwoServerWindow twoServ = null; // TODO: Initialize to an appropriate value
            PlayerList target = new PlayerList(twoServ); // TODO: Initialize to an appropriate value
            target.FufuDrink();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CheckFufu
        ///</summary>
        [TestMethod()]
        public void CheckFufuTest()
        {
            TwoServerWindow twoServ = null; // TODO: Initialize to an appropriate value
            PlayerList target = new PlayerList(twoServ); // TODO: Initialize to an appropriate value
            target.CheckFufu();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddPlayer
        ///</summary>
        [TestMethod()]
        public void AddPlayerTest()
        {
            TwoServerWindow twoServ = null; // TODO: Initialize to an appropriate value
            PlayerList target = new PlayerList(twoServ); // TODO: Initialize to an appropriate value
            EndPoint playerAddress = null; // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.AddPlayer(playerAddress, name);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PlayerList Constructor
        ///</summary>
        [TestMethod()]
        public void PlayerListConstructorTest()
        {
            TwoServerWindow twoServ = null; // TODO: Initialize to an appropriate value
            PlayerList target = new PlayerList(twoServ);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
