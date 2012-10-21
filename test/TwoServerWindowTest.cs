using Two_Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace test
{
    
    
    /// <summary>
    ///This is a test class for TwoServerWindowTest and is intended
    ///to contain all TwoServerWindowTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TwoServerWindowTest
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
        ///A test for updateButton_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Two Server.exe")]
        public void updateButton_ClickTest()
        {
            TwoServerWindow_Accessor target = new TwoServerWindow_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.updateButton_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for resetButton_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Two Server.exe")]
        public void resetButton_ClickTest()
        {
            TwoServerWindow_Accessor target = new TwoServerWindow_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.resetButton_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for button1_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Two Server.exe")]
        public void button1_ClickTest()
        {
            TwoServerWindow_Accessor target = new TwoServerWindow_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.button1_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for _resumeButton_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Two Server.exe")]
        public void _resumeButton_ClickTest()
        {
            TwoServerWindow_Accessor target = new TwoServerWindow_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target._resumeButton_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for _pauseButton_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Two Server.exe")]
        public void _pauseButton_ClickTest()
        {
            TwoServerWindow_Accessor target = new TwoServerWindow_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target._pauseButton_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for WaitForPlayerTarget
        ///</summary>
        [TestMethod()]
        public void WaitForPlayerTargetTest()
        {
            TwoServerWindow target = new TwoServerWindow(); // TODO: Initialize to an appropriate value
            string s = string.Empty; // TODO: Initialize to an appropriate value
            target.WaitForPlayerTarget(s);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for WaitForMoose
        ///</summary>
        [TestMethod()]
        public void WaitForMooseTest()
        {
            TwoServerWindow target = new TwoServerWindow(); // TODO: Initialize to an appropriate value
            target.WaitForMoose();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UdpMessageListener
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Two Server.exe")]
        public void UdpMessageListenerTest()
        {
            TwoServerWindow_Accessor target = new TwoServerWindow_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            TwoServerWindow.UdpEvent e = null; // TODO: Initialize to an appropriate value
            target.UdpMessageListener(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for StartGame
        ///</summary>
        [TestMethod()]
        public void StartGameTest()
        {
            TwoServerWindow target = new TwoServerWindow(); // TODO: Initialize to an appropriate value
            target.StartGame();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for StartButton_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Two Server.exe")]
        public void StartButton_ClickTest()
        {
            TwoServerWindow_Accessor target = new TwoServerWindow_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.StartButton_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ShuffleDeck
        ///</summary>
        [TestMethod()]
        public void ShuffleDeckTest()
        {
            TwoServerWindow target = new TwoServerWindow(); // TODO: Initialize to an appropriate value
            target.ShuffleDeck();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SendToPlayer
        ///</summary>
        [TestMethod()]
        public void SendToPlayerTest()
        {
            TwoServerWindow target = new TwoServerWindow(); // TODO: Initialize to an appropriate value
            Player p = null; // TODO: Initialize to an appropriate value
            string toSend = string.Empty; // TODO: Initialize to an appropriate value
            target.SendToPlayer(p, toSend);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SendToAllPlayers
        ///</summary>
        [TestMethod()]
        public void SendToAllPlayersTest()
        {
            TwoServerWindow target = new TwoServerWindow(); // TODO: Initialize to an appropriate value
            string toSend = string.Empty; // TODO: Initialize to an appropriate value
            target.SendToAllPlayers(toSend);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SendStatus
        ///</summary>
        [TestMethod()]
        public void SendStatusTest()
        {
            TwoServerWindow target = new TwoServerWindow(); // TODO: Initialize to an appropriate value
            target.SendStatus();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SendPlayerList
        ///</summary>
        [TestMethod()]
        public void SendPlayerListTest()
        {
            TwoServerWindow target = new TwoServerWindow(); // TODO: Initialize to an appropriate value
            target.SendPlayerList();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SendPlayerDrinks
        ///</summary>
        [TestMethod()]
        public void SendPlayerDrinksTest()
        {
            TwoServerWindow target = new TwoServerWindow(); // TODO: Initialize to an appropriate value
            Player p = null; // TODO: Initialize to an appropriate value
            int noOfDrinks = 0; // TODO: Initialize to an appropriate value
            target.SendPlayerDrinks(p, noOfDrinks);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SendPlayerCards
        ///</summary>
        [TestMethod()]
        public void SendPlayerCardsTest()
        {
            TwoServerWindow target = new TwoServerWindow(); // TODO: Initialize to an appropriate value
            Player p = null; // TODO: Initialize to an appropriate value
            target.SendPlayerCards(p);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SendDrinkForm
        ///</summary>
        [TestMethod()]
        public void SendDrinkFormTest()
        {
            TwoServerWindow target = new TwoServerWindow(); // TODO: Initialize to an appropriate value
            Player p = null; // TODO: Initialize to an appropriate value
            float drinkTime = 0F; // TODO: Initialize to an appropriate value
            string message = string.Empty; // TODO: Initialize to an appropriate value
            string messageToOthers = string.Empty; // TODO: Initialize to an appropriate value
            target.SendDrinkForm(p, drinkTime, message, messageToOthers);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SendDrinkForm
        ///</summary>
        [TestMethod()]
        public void SendDrinkFormTest1()
        {
            TwoServerWindow target = new TwoServerWindow(); // TODO: Initialize to an appropriate value
            Player p = null; // TODO: Initialize to an appropriate value
            float drinkTime = 0F; // TODO: Initialize to an appropriate value
            string message = string.Empty; // TODO: Initialize to an appropriate value
            target.SendDrinkForm(p, drinkTime, message);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SendAnnounce
        ///</summary>
        [TestMethod()]
        public void SendAnnounceTest()
        {
            TwoServerWindow target = new TwoServerWindow(); // TODO: Initialize to an appropriate value
            string toSend = string.Empty; // TODO: Initialize to an appropriate value
            target.SendAnnounce(toSend);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for RestartGame
        ///</summary>
        [TestMethod()]
        public void RestartGameTest()
        {
            TwoServerWindow target = new TwoServerWindow(); // TODO: Initialize to an appropriate value
            target.RestartGame();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for RecieveUdp
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Two Server.exe")]
        public void RecieveUdpTest()
        {
            TwoServerWindow_Accessor target = new TwoServerWindow_Accessor(); // TODO: Initialize to an appropriate value
            target.RecieveUdp();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ReShuffle
        ///</summary>
        [TestMethod()]
        public void ReShuffleTest()
        {
            TwoServerWindow target = new TwoServerWindow(); // TODO: Initialize to an appropriate value
            target.ReShuffle();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for RandomTaunt
        ///</summary>
        [TestMethod()]
        public void RandomTauntTest()
        {
            TwoServerWindow target = new TwoServerWindow(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.RandomTaunt();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PrintDeck
        ///</summary>
        [TestMethod()]
        public void PrintDeckTest()
        {
            TwoServerWindow target = new TwoServerWindow(); // TODO: Initialize to an appropriate value
            target.PrintDeck();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for PlayerPlayedCard
        ///</summary>
        [TestMethod()]
        public void PlayerPlayedCardTest()
        {
            TwoServerWindow target = new TwoServerWindow(); // TODO: Initialize to an appropriate value
            Player player = null; // TODO: Initialize to an appropriate value
            int card = 0; // TODO: Initialize to an appropriate value
            string[] cardArgs = null; // TODO: Initialize to an appropriate value
            target.PlayerPlayedCard(player, card, cardArgs);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for PlayerPickupCardQuiet
        ///</summary>
        [TestMethod()]
        public void PlayerPickupCardQuietTest()
        {
            TwoServerWindow target = new TwoServerWindow(); // TODO: Initialize to an appropriate value
            int noOfCards = 0; // TODO: Initialize to an appropriate value
            Player p = null; // TODO: Initialize to an appropriate value
            target.PlayerPickupCardQuiet(noOfCards, p);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for PlayerPickupCard
        ///</summary>
        [TestMethod()]
        public void PlayerPickupCardTest()
        {
            TwoServerWindow target = new TwoServerWindow(); // TODO: Initialize to an appropriate value
            int noOfCards = 0; // TODO: Initialize to an appropriate value
            Player p = null; // TODO: Initialize to an appropriate value
            string s = string.Empty; // TODO: Initialize to an appropriate value
            target.PlayerPickupCard(noOfCards, p, s);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for PlayerPickupCard
        ///</summary>
        [TestMethod()]
        public void PlayerPickupCardTest1()
        {
            TwoServerWindow target = new TwoServerWindow(); // TODO: Initialize to an appropriate value
            int noOfCards = 0; // TODO: Initialize to an appropriate value
            Player p = null; // TODO: Initialize to an appropriate value
            target.PlayerPickupCard(noOfCards, p);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OptionsButton_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Two Server.exe")]
        public void OptionsButton_ClickTest()
        {
            TwoServerWindow_Accessor target = new TwoServerWindow_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.OptionsButton_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Two Server.exe")]
        public void InitializeComponentTest()
        {
            TwoServerWindow_Accessor target = new TwoServerWindow_Accessor(); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetPrincessDrinkCards
        ///</summary>
        [TestMethod()]
        public void GetPrincessDrinkCardsTest()
        {
            TwoServerWindow target = new TwoServerWindow(); // TODO: Initialize to an appropriate value
            List<Card> expected = null; // TODO: Initialize to an appropriate value
            List<Card> actual;
            actual = target.GetPrincessDrinkCards();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetPrincessCard
        ///</summary>
        [TestMethod()]
        public void GetPrincessCardTest()
        {
            TwoServerWindow target = new TwoServerWindow(); // TODO: Initialize to an appropriate value
            List<Card> expected = null; // TODO: Initialize to an appropriate value
            List<Card> actual;
            actual = target.GetPrincessCard();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetPassCards
        ///</summary>
        [TestMethod()]
        public void GetPassCardsTest()
        {
            TwoServerWindow target = new TwoServerWindow(); // TODO: Initialize to an appropriate value
            List<Card> expected = null; // TODO: Initialize to an appropriate value
            List<Card> actual;
            actual = target.GetPassCards();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetNumberCards
        ///</summary>
        [TestMethod()]
        public void GetNumberCardsTest()
        {
            TwoServerWindow target = new TwoServerWindow(); // TODO: Initialize to an appropriate value
            List<Card> expected = null; // TODO: Initialize to an appropriate value
            List<Card> actual;
            actual = target.GetNumberCards();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetLightMasterCards
        ///</summary>
        [TestMethod()]
        public void GetLightMasterCardsTest()
        {
            TwoServerWindow target = new TwoServerWindow(); // TODO: Initialize to an appropriate value
            List<Card> expected = null; // TODO: Initialize to an appropriate value
            List<Card> actual;
            actual = target.GetLightMasterCards();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetGrayCard
        ///</summary>
        [TestMethod()]
        public void GetGrayCardTest()
        {
            TwoServerWindow target = new TwoServerWindow(); // TODO: Initialize to an appropriate value
            List<Card> expected = null; // TODO: Initialize to an appropriate value
            List<Card> actual;
            actual = target.GetGrayCard();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetDrawCards
        ///</summary>
        [TestMethod()]
        public void GetDrawCardsTest()
        {
            TwoServerWindow target = new TwoServerWindow(); // TODO: Initialize to an appropriate value
            List<Card> expected = null; // TODO: Initialize to an appropriate value
            List<Card> actual;
            actual = target.GetDrawCards();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetBoomCard
        ///</summary>
        [TestMethod()]
        public void GetBoomCardTest()
        {
            TwoServerWindow target = new TwoServerWindow(); // TODO: Initialize to an appropriate value
            List<Card> expected = null; // TODO: Initialize to an appropriate value
            List<Card> actual;
            actual = target.GetBoomCard();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Form1_Close
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Two Server.exe")]
        public void Form1_CloseTest()
        {
            TwoServerWindow_Accessor target = new TwoServerWindow_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            FormClosingEventArgs e = null; // TODO: Initialize to an appropriate value
            target.Form1_Close(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for FinishGame
        ///</summary>
        [TestMethod()]
        public void FinishGameTest()
        {
            TwoServerWindow target = new TwoServerWindow(); // TODO: Initialize to an appropriate value
            target.FinishGame();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DoMoose
        ///</summary>
        [TestMethod()]
        public void DoMooseTest()
        {
            TwoServerWindow target = new TwoServerWindow(); // TODO: Initialize to an appropriate value
            Player p = null; // TODO: Initialize to an appropriate value
            target.DoMoose(p);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Two Server.exe")]
        public void DisposeTest()
        {
            TwoServerWindow_Accessor target = new TwoServerWindow_Accessor(); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CreateDeck
        ///</summary>
        [TestMethod()]
        public void CreateDeckTest()
        {
            TwoServerWindow target = new TwoServerWindow(); // TODO: Initialize to an appropriate value
            target.CreateDeck();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CardList
        ///</summary>
        [TestMethod()]
        public void CardListTest()
        {
            TwoServerWindow target = new TwoServerWindow(); // TODO: Initialize to an appropriate value
            List<Card> expected = null; // TODO: Initialize to an appropriate value
            List<Card> actual;
            actual = target.CardList();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BroadcastServerThread
        ///</summary>
        [TestMethod()]
        public void BroadcastServerThreadTest()
        {
            TwoServerWindow target = new TwoServerWindow(); // TODO: Initialize to an appropriate value
            target.BroadcastServerThread();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddTextFromThread
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Two Server.exe")]
        public void AddTextFromThreadTest()
        {
            TwoServerWindow_Accessor target = new TwoServerWindow_Accessor(); // TODO: Initialize to an appropriate value
            string message = string.Empty; // TODO: Initialize to an appropriate value
            target.AddTextFromThread(message);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddText
        ///</summary>
        [TestMethod()]
        public void AddTextTest()
        {
            TwoServerWindow target = new TwoServerWindow(); // TODO: Initialize to an appropriate value
            string toAdd = string.Empty; // TODO: Initialize to an appropriate value
            target.AddText(toAdd);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for TwoServerWindow Constructor
        ///</summary>
        [TestMethod()]
        public void TwoServerWindowConstructorTest()
        {
            TwoServerWindow target = new TwoServerWindow();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
