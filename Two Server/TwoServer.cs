﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Two_Server
{
    public partial class TwoServerWindow : Form
    {
        private readonly Thread _udpThread;
        private Thread _broadcastThread;

        readonly Socket _udpSocket;
        IPEndPoint _localEndPoint;

        private UsersConnected _usersConnected;

        public Card WaitingCard;
        public Stack<Card> DrawDeck;
        public Stack<Card> DownDeck;
        public Boolean IsRunning = true;
        public int GameState = 0;
        public List<TimedEvent> TimedEventList = new List<TimedEvent>(); 
        public PlayerList PlayerList;
        public GameOptions GameOption;
        private int _playerSwap = -1;
        public int DrinkLevel = 2;
        System.Text.UTF8Encoding _encoding = new System.Text.UTF8Encoding();

        public event UdpMessageHandler UdpMessageEvent;

        public delegate void UdpMessageHandler(object m, UdpEvent e);

        public TwoServerWindow()
        {
            InitializeComponent();
            PlayerList = new PlayerList(this);
            IPHostEntry localHostEntry;
            try
            {
                //Create a UDP socket.
                _udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                localHostEntry = Dns.GetHostEntry(Dns.GetHostName());
            }
            catch (Exception)
            {
                AddText("Local Host not found"); // fail
                return;
            }
            IPAddress localIp = null;
            foreach (IPAddress ip in localHostEntry.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    localIp = ip;
            }

            _localEndPoint = new IPEndPoint(localIp, 48484);
            _udpSocket.Bind(_localEndPoint);
            Show();
            GameOption = new GameOptions();
            GameOption.ShowDialog();
            
            _udpThread = new Thread(new ThreadStart(RecieveUdp));
            _udpThread.Start();
            _broadcastThread = new Thread(new ThreadStart(BroadcastServerThread));
            _broadcastThread.Start();
            UdpMessageEvent += new UdpMessageHandler(UdpMessageListener);
            DownDeck = new Stack<Card>();
            
        }

        public void BroadcastServerThread()
        {
            UdpClient udpClient = new UdpClient();
            IPEndPoint broadcastEp = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 48485);
            IPEndPoint broadcastEp2 = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 48486);
            IPEndPoint broadcastEp3 = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 48487);
            IPEndPoint broadcastEp4 = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 48488);
            Byte[] sendBytes = Encoding.ASCII.GetBytes("GAME");
            while (GameState == 0||GameState == -2)
            {
                System.Threading.Thread.Sleep(5000);
                udpClient.Send(sendBytes,sendBytes.Length,broadcastEp);
                udpClient.Send(sendBytes, sendBytes.Length, broadcastEp2);
                udpClient.Send(sendBytes, sendBytes.Length, broadcastEp3);
                udpClient.Send(sendBytes, sendBytes.Length, broadcastEp4);
            }
        }


        public void StartGame()
        {
            DrinkLevel = GameOption.Drink;

            SendPlayerList();
            DownDeck = new Stack<Card>();

            CreateDeck();
            ShuffleDeck();
            PrintDeck();
            
            if (GameState != 0)
                return;
            int i = 0;
            while (i < PlayerList.NumberPlayers)
            {
                PlayerPickupCardQuiet(7, PlayerList.PlayerArray[i]);
                i++;
            }
            GameState = 1;
            DownDeck.Push(DrawDeck.Pop());
            topCardLabel.Text = DownDeck.Peek().Name;
            PlayerList.Turn = 0;


            TimedEventList = new List<TimedEvent>();
            TimedEventList.Add(new StatusTick(this, 2.0f));
            TimedEventList[0].Start();
            
            SendToAllPlayers("STARTGAME");

            SendToAllPlayers("TURN 0");
            SendToAllPlayers("TOPCARD " + DownDeck.Peek().SortValue);
            foreach( Player p in PlayerList.PlayerArray)
            {
                SendToAllPlayers("ANIMATION CARDSTO "+p.playerNumber + " 7");
            }

        }
        public void SendPlayerList()
        {
            string playerString = "";
            foreach (Player p in PlayerList.PlayerArray)
            {
                playerString += p.Name.Replace(' ', '+') + " ";
            }
            playerString = "PLAYERLIST " + playerString;
            
            SendToAllPlayers(playerString);
        }
        public void RestartGame()
        {
            foreach (TimedEvent timedEvent in TimedEventList)
            {
                timedEvent.IsRunning = false;
            }
            CreateDeck();
            ShuffleDeck();
            PlayerList = new PlayerList(this);
            GameState = 0;
            _broadcastThread = new Thread(new ThreadStart(BroadcastServerThread));
            _broadcastThread.Start();
        }

        public List<Card> GetNumberCards()
        {
            List<Card> cardList = new List<Card>();
            for (int i = 0; i < 4; i++)
            {
                string colour = "";
                switch (i)
                {
                    case 0:
                        colour = "Red";
                        break;
                    case 1:
                        colour = "Blue";
                        break;
                    case 2:
                        colour = "Yellow";
                        break;
                    case 3:
                        colour = "Green";
                        break;
                }

                for (int n = 0; n < 9; n++)
                {
                    Card c = new Card();
                    c.Name = colour + " " + n;
                    c.SortValue = double.Parse(i + ".0" + n);
                    c.Types.Add(colour);
                    c.Types.Add(n.ToString());
                    cardList.Add(c);
                }
            }
            return cardList;
        }
        public List<Card> GetLightMasterCards()
        {
            List<Card> cardList = new List<Card>();
            for (int i = 0; i < 4; i++)
            {
                string colour = "";
                switch (i)
                {
                    case 0:
                        colour = "Red";
                        break;
                    case 1:
                        colour = "Blue";
                        break;
                    case 2:
                        colour = "Yellow";
                        break;
                    case 3:
                        colour = "Green";
                        break;
                }
                LightMasterCard lm = new LightMasterCard();
                lm.Name = colour + " LightMaster";
                lm.SortValue = i + .3;
                lm.Types.Add(colour);
                lm.Types.Add("LIGHTMASTER");
                lm.ValidTypes.Add(colour);
                lm.ValidTypes.Add("LIGHTMASTER");
                cardList.Add(lm);
            }
            return cardList;
        }

        public List<Card> GetPrincessDrinkCards()
        {
            List<Card> cardList = new List<Card>();
            for (int i = 0; i < 4; i++)
            {
                string colour = "";
                switch (i)
                {
                    case 0:
                        colour = "Red";
                        break;
                    case 1:
                        colour = "Blue";
                        break;
                    case 2:
                        colour = "Yellow";
                        break;
                    case 3:
                        colour = "Green";
                        break;
                }
                PrincessDrink pd = new PrincessDrink();
                pd.Name = String.Format("{0} Princess Drink", colour);
                pd.SortValue = double.Parse(i + ".09");
                pd.Types.Add(colour);
                pd.Types.Add("PRINCESSDRINK");
                cardList.Add(pd);
                
            }
            return cardList;
        }
        public List<Card> GetDrawCards()
        {
            List<Card> cardList = new List<Card>();
            for (int i = 0; i < 4; i++)
            {
                string colour = "";
                switch (i)
                {
                    case 0:
                        colour = "Red";
                        break;
                    case 1:
                        colour = "Blue";
                        break;
                    case 2:
                        colour = "Yellow";
                        break;
                    case 3:
                        colour = "Green";
                        break;
                }
                for (int n = 0; n < 2; n++)
                {
                    ColorDraw c = new ColorDraw();
                    int draw = n + 2;
                    c.Name = colour + " Draw " + draw;
                    c.SortValue = double.Parse(i + ".1" + draw);
                    c.Types.Add(colour);
                    c.Types.Add("DRAW " + draw);
                    c.DrawAmount = draw;
                    c.Types.Add(n.ToString());
                    cardList.Add(c);
                    if( n == 0)
                    {
                        c = new ColorDraw();
                        c.Name = colour + " Draw " + draw;
                        c.SortValue = double.Parse(i + ".1" + draw);
                        c.Types.Add(colour);
                        c.Types.Add("DRAW " + draw);
                        c.DrawAmount = draw;
                        c.Types.Add(n.ToString());
                        cardList.Add(c);
                    }
                }
                PlayerTargetedCard targ = new PlayerTargetedCard();
                targ.Name = "Targetted " + colour + " +2";
                targ.SortValue = i + .22;
                targ.Types.Add(colour);
                targ.Types.Add("TARGET 2");
                targ.ValidTypes.Add(colour);
                targ.ValidTypes.Add("TARGET 2");
                targ.DrawAmount = 2;
                cardList.Add(targ);
            }
            return cardList;
        }
        public List<Card> GetPassCards()
        {
            List<Card> cardList = new List<Card>();
            for (int i = 0; i < 4; i++)
            {
                string colour = "";
                switch (i)
                {
                    case 0:
                        colour = "Red";
                        break;
                    case 1:
                        colour = "Blue";
                        break;
                    case 2:
                        colour = "Yellow";
                        break;
                    case 3:
                        colour = "Green";
                        break;
                }
                SkipCard sc = new SkipCard();
                sc.Name = colour + " Skip";
                sc.SortValue = i + .4;
                sc.Types.Add(colour);
                sc.Types.Add("SKIP");
                sc.ValidTypes.Add(colour);
                sc.ValidTypes.Add("SKIP");
                cardList.Add(sc);

                sc = new SkipCard();
                sc.Name = colour + " Skip";
                sc.SortValue = i + .4;
                sc.Types.Add(colour);
                sc.Types.Add("SKIP");
                sc.ValidTypes.Add(colour);
                sc.ValidTypes.Add("SKIP");
                cardList.Add(sc);

                DoubleDownCard dd = new DoubleDownCard();
                dd.Name = colour + " Double Down";
                dd.SortValue = i + .5;
                dd.Types.Add(colour);
                dd.Types.Add("DOUBLEDOWN");
                dd.ValidTypes.Add(colour);
                dd.ValidTypes.Add("DOUBLEDOWN");
                cardList.Add(dd);
            }
            return cardList;
        }
        public List<Card> GetPrincessCard()
        {
            List<Card> cardList = new List<Card>();
            PrincessFufu pf = new PrincessFufu();
            pf.Name = "Princess Fufu";
            pf.SortValue = 5.01;
            pf.Types.Add("Red");
            pf.Types.Add("Blue");
            pf.Types.Add("Green");
            pf.Types.Add("Yellow");
            pf.ValidTypes.Add("Red");
            pf.ValidTypes.Add("Blue");
            pf.ValidTypes.Add("Green");
            pf.ValidTypes.Add("Yellow");
            cardList.Add(pf);
            return cardList;
        }
        public List<Card> GetBoomCard()
        {
            List<Card> cardList = new List<Card>();
            BoomCard bc = new BoomCard();
            bc.Name = "BoomCard";
            bc.SortValue = 5.02;
            bc.Types.Add("Red");
            bc.Types.Add("Blue");
            bc.Types.Add("Green");
            bc.Types.Add("Yellow");
            bc.ValidTypes.Add("Red");
            bc.ValidTypes.Add("Blue");
            bc.ValidTypes.Add("Green");
            bc.ValidTypes.Add("Yellow");
            cardList.Add(bc);
            return cardList;
        }
        public List<Card> GetGrayCard()
        {
            List<Card> cardList = new List<Card>();
            Card gc = new Card();
            gc.Name = "Gray";
            gc.SortValue = 5.03;
            gc.Types.Add("Red");
            gc.Types.Add("Blue");
            gc.Types.Add("Green");
            gc.Types.Add("Yellow");
            gc.ValidTypes.Add("Red");
            gc.ValidTypes.Add("Blue");
            gc.ValidTypes.Add("Green");
            gc.ValidTypes.Add("Yellow");
            cardList.Add(gc);
            return cardList;
        }
        public List<Card> CardList()
        {
            List<Card> cardList = new List<Card>();
            for (int i = 0; i < 4; i++)
            {
                string colour = "";
                switch (i)
                {
                    case 0:
                        colour = "Red";
                        break;
                    case 1:
                        colour = "Blue";
                        break;
                    case 2:
                        colour = "Yellow";
                        break;
                    case 3:
                        colour = "Green";
                        break;
                }
                
                for (int n = 0; n < 9; n++)
                {
                    Card c = new Card();
                    c.Name = colour + " " + n;
                    c.SortValue = double.Parse(i + ".0" + n);
                    c.Types.Add(colour);
                    c.Types.Add(n.ToString());
                    cardList.Add(c);
                }

                

                for (int n = 0; n < 2; n++)
                {
                    ColorDraw c = new ColorDraw();
                    int draw = n + 2;
                    c.Name = colour + " Draw " + draw;
                    c.SortValue = double.Parse(i + ".1" + draw);
                    c.Types.Add(colour);
                    c.Types.Add("DRAW " + draw);
                    c.DrawAmount = draw;
                    c.Types.Add(n.ToString());
                    cardList.Add(c);
                }
                PrincessDrink pd = new PrincessDrink();
                pd.Name = String.Format("{0} Princess Drink", colour);
                pd.SortValue = double.Parse(i + ".09");
                pd.Types.Add(colour);
                pd.Types.Add("PRINCESSDRINK");
                cardList.Add(pd);

                pd = new PrincessDrink();
                pd.Name = String.Format("{0} Princess Drink", colour);
                pd.SortValue = double.Parse(i + ".09");
                pd.Types.Add(colour);
                pd.Types.Add("PRINCESSDRINK");
                cardList.Add(pd);

                PlayerTargetedCard targ = new PlayerTargetedCard();
                targ.Name = "Targetted " + colour + " +2";
                targ.SortValue = i + .22;
                targ.Types.Add(colour);
                targ.Types.Add("TARGET 2");
                targ.ValidTypes.Add(colour);
                targ.ValidTypes.Add("TARGET 2");
                targ.DrawAmount = 2;
                cardList.Add(targ);

                LightMasterCard lm = new LightMasterCard();
                lm.Name = colour + " LightMaster";
                lm.SortValue = i + .3;
                lm.Types.Add(colour);
                lm.Types.Add("LIGHTMASTER");
                lm.ValidTypes.Add(colour);
                lm.ValidTypes.Add("LIGHTMASTER");
                cardList.Add(lm);

                SkipCard sc = new SkipCard();
                sc.Name = colour + " Skip";
                sc.SortValue = i + .4;
                sc.Types.Add(colour);
                sc.Types.Add("SKIP");
                sc.ValidTypes.Add(colour);
                sc.ValidTypes.Add("SKIP");
                cardList.Add(sc);

                sc = new SkipCard();
                sc.Name = colour + " Skip";
                sc.SortValue = i + .4;
                sc.Types.Add(colour);
                sc.Types.Add("SKIP");
                sc.ValidTypes.Add(colour);
                sc.ValidTypes.Add("SKIP");
                cardList.Add(sc);
                sc = new SkipCard();
                sc.Name = colour + " Skip";
                sc.SortValue = i + .4;
                sc.Types.Add(colour);
                sc.Types.Add("SKIP");
                sc.ValidTypes.Add(colour);
                sc.ValidTypes.Add("SKIP");
                cardList.Add(sc);

                sc = new SkipCard();
                sc.Name = colour + " Skip";
                sc.SortValue = i + .4;
                sc.Types.Add(colour);
                sc.Types.Add("SKIP");
                sc.ValidTypes.Add(colour);
                sc.ValidTypes.Add("SKIP");
                cardList.Add(sc);

                DoubleDownCard dd = new DoubleDownCard();
                dd.Name = colour + " Double Down";
                dd.SortValue = i + .5;
                dd.Types.Add(colour);
                dd.Types.Add("DOUBLEDOWN");
                dd.ValidTypes.Add(colour);
                dd.ValidTypes.Add("DOUBLEDOWN");
                cardList.Add(dd);

                dd = new DoubleDownCard();
                dd.Name = colour + " Double Down";
                dd.SortValue = i + .5;
                dd.Types.Add(colour);
                dd.Types.Add("DOUBLEDOWN");
                dd.ValidTypes.Add(colour);
                dd.ValidTypes.Add("DOUBLEDOWN");
                cardList.Add(dd);
                dd = new DoubleDownCard();
                dd.Name = colour + " Double Down";
                dd.SortValue = i + .5;
                dd.Types.Add(colour);
                dd.Types.Add("DOUBLEDOWN");
                dd.ValidTypes.Add(colour);
                dd.ValidTypes.Add("DOUBLEDOWN");
                cardList.Add(dd);

            }
            PrincessFufu pf = new PrincessFufu();
            pf.Name = "Princess Fufu";
            pf.SortValue = 5.01;
            pf.Types.Add("Red");
            pf.Types.Add("Blue");
            pf.Types.Add("Green");
            pf.Types.Add("Yellow");
            pf.ValidTypes.Add("Red");
            pf.ValidTypes.Add("Blue");
            pf.ValidTypes.Add("Green");
            pf.ValidTypes.Add("Yellow");
            cardList.Add(pf);

            pf = new PrincessFufu();
            pf.Name = "Princess Fufu";
            pf.SortValue = 5.01;
            pf.Types.Add("Red");
            pf.Types.Add("Blue");
            pf.Types.Add("Green");
            pf.Types.Add("Yellow");
            pf.ValidTypes.Add("Red");
            pf.ValidTypes.Add("Blue");
            pf.ValidTypes.Add("Green");
            pf.ValidTypes.Add("Yellow");
            cardList.Add(pf);

            pf = new PrincessFufu();
            pf.Name = "Princess Fufu";
            pf.SortValue = 5.01;
            pf.Types.Add("Red");
            pf.Types.Add("Blue");
            pf.Types.Add("Green");
            pf.Types.Add("Yellow");
            pf.ValidTypes.Add("Red");
            pf.ValidTypes.Add("Blue");
            pf.ValidTypes.Add("Green");
            pf.ValidTypes.Add("Yellow");
            cardList.Add(pf);

            pf = new PrincessFufu();
            pf.Name = "Princess Fufu";
            pf.SortValue = 5.01;
            pf.Types.Add("Red");
            pf.Types.Add("Blue");
            pf.Types.Add("Green");
            pf.Types.Add("Yellow");
            pf.ValidTypes.Add("Red");
            pf.ValidTypes.Add("Blue");
            pf.ValidTypes.Add("Green");
            pf.ValidTypes.Add("Yellow");
            cardList.Add(pf);

            BoomCard bc = new BoomCard();
            bc.Name = "BoomCard";
            bc.SortValue = 5.02;
            bc.Types.Add("Red");
            bc.Types.Add("Blue");
            bc.Types.Add("Green");
            bc.Types.Add("Yellow");
            bc.ValidTypes.Add("Red");
            bc.ValidTypes.Add("Blue");
            bc.ValidTypes.Add("Green");
            bc.ValidTypes.Add("Yellow");
            cardList.Add(bc);

            Card gc = new Card();
            gc.Name = "Gray";
            gc.SortValue = 5.03;
            gc.Types.Add("Red");
            gc.Types.Add("Blue");
            gc.Types.Add("Green");
            gc.Types.Add("Yellow");
            gc.ValidTypes.Add("Red");
            gc.ValidTypes.Add("Blue");
            gc.ValidTypes.Add("Green");
            gc.ValidTypes.Add("Yellow");
            cardList.Add(gc);
            

            gc = new Card();
            gc.Name = "Gray";
            gc.SortValue = 5.03;
            gc.Types.Add("Red");
            gc.Types.Add("Blue");
            gc.Types.Add("Green");
            gc.Types.Add("Yellow");
            gc.ValidTypes.Add("Red");
            gc.ValidTypes.Add("Blue");
            gc.ValidTypes.Add("Green");
            gc.ValidTypes.Add("Yellow");
            cardList.Add(gc);
            return cardList;


        }

        public void CreateDeck()
        {
            DrawDeck = new Stack<Card>();
            
            List<Card> inCards = CardList();
            for (int i = 0; i < GameOption.NumberCards; i++ )
                inCards.AddRange(GetNumberCards());

            for (int i = 0; i < GameOption.PrincessCards; i++)
                inCards.AddRange(GetPrincessCard());

            for (int i = 0; i < GameOption.PrincessDrinkCards; i++)
                inCards.AddRange(GetPrincessDrinkCards());

            for (int i = 0; i < GameOption.NumberCards; i++)
                inCards.AddRange(GetNumberCards());

            for (int i = 0; i < GameOption.DrawCards; i++)
                inCards.AddRange(GetDrawCards());

            for (int i = 0; i < GameOption.BoomCards; i++)
                inCards.AddRange(GetBoomCard());

            for (int i = 0; i < GameOption.PassCards; i++)
                inCards.AddRange(GetPassCards());

            for (int i = 0; i < GameOption.GrayCards; i++)
                inCards.AddRange(GetGrayCard());

            for (int i = 0; i < GameOption.LightMasterCards; i++)
                inCards.AddRange(GetLightMasterCards());


            while (inCards.Count > 0)
            {
                DrawDeck.Push(inCards[0]);
                inCards.RemoveAt(0);
            }
        }

        public void ShuffleDeck()
        {
            Random random = new Random();
            List<Card> tempDeck = new List<Card>();
            while (DrawDeck.Count > 0)
            {
                tempDeck.Add(DrawDeck.Pop());
            }
            while (tempDeck.Count > 0)
            {
                int i = random.Next(0, tempDeck.Count - 1);
                DrawDeck.Push(tempDeck[i]);
                tempDeck.RemoveAt(i);
            }
        }

        private void RecieveUdp()
        {
            IPHostEntry localHostEntry;
            try
            {


                localHostEntry = Dns.GetHostEntry(Dns.GetHostName());
            }
            catch (Exception)
            {
                AddText("Local Host not found"); // fail
                return;
            }
            IPAddress localIp = null;
            foreach (IPAddress ip in localHostEntry.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    localIp = ip;
            }
            _localEndPoint = new IPEndPoint(localIp, 48484);

            
            while (IsRunning)
            {
                try
                {
                    Byte[] received = new Byte[512];
                    IPEndPoint tmpIpEndPoint = new IPEndPoint(localIp, 48484);
                    EndPoint remoteEp = (tmpIpEndPoint);
                    int bytesReceived = _udpSocket.ReceiveFrom(received, ref remoteEp);
                    String dataReceived = System.Text.Encoding.UTF8.GetString(received);
                    if (UdpMessageEvent != null)
                    {
                        UdpEvent udpE = new UdpEvent();
                        udpE.Message = dataReceived.Replace("\0", "");
                        udpE.Address = remoteEp;
                        UdpMessageEvent(this, udpE);
                    }
                }catch(Exception e)
                {
                    AddTextFromThread("Message recieve exception: " +e.ToString());
                }
            }
        }

        public void AddText(string toAdd)
        {
            logBox.Text = toAdd +"\r\n" +logBox.Text;
        }

        public void PrintDeck()
        {
            foreach (Card c in DrawDeck)
            {
                AddText(c.Name);
            }
        }
        public void FinishGame()
        {
            Player loser = null;
            foreach (Player p in PlayerList.PlayerArray)
            {
                if( p.StillIn )
                {
                    loser = p;
                }
                SendToPlayer(loser, "TIMEDFORM 10 A loser is you. " + RandomTaunt() + ".");
            }
        }
        public void SendStatus()
        {
            switch (GameState)
            {
                case 1:
                    SendToAllPlayers(String.Format("TURN " + PlayerList.Turn));
                    SendPlayerCards(PlayerList.PlayerArray[PlayerList.Turn]);
                    break;
                case 3:

                    SendToPlayer(PlayerList.PlayerArray[PlayerList.Turn], String.Format("TARGETPLAYER"));
                    SendPlayerCards(PlayerList.PlayerArray[PlayerList.Turn]);
                    break;
            }
        }
        public void WaitForPlayerTarget(String s)
        {
            GameState = 3;
            SendToPlayer(PlayerList.PlayerArray[PlayerList.Turn], String.Format("TARGETPLAYER {0}", s));
        }
        private void UdpMessageListener(object sender, UdpEvent e)
        {
            AddTextFromThread("New message from: " + e.Address);
            AddTextFromThread("Contents: " + e.Message);
            Player p = null;
            if( PlayerList.AddressLookup.ContainsKey(e.Address.ToString()) )
            {
                p = PlayerList.PlayerArray[PlayerList.AddressLookup[e.Address.ToString()]];
            }

            String[] messageArray = e.Message.Split(' ');
            switch (messageArray[0]) {
                case "JOIN":
                    if (GameState == 0)
                    {
                        AddTextFromThread("Player added: " + PlayerList.AddPlayer(e.Address,e.Message.Remove(0,5)).ToString());
                        foreach( Player player in PlayerList.PlayerArray)
                        {
                            SendToPlayer(player, "PLAYERNUMBER " + player.playerNumber );
                        }
                        SendPlayerList();
                        SendToAllPlayers("LOBBY");
                    } else if( GameState == -2 )
                    {
                        AddTextFromThread("Player joined: " + PlayerList.AddPlayer(e.Address, e.Message.Remove(0, 5)).ToString());
                        foreach (Player player in PlayerList.PlayerArray)
                        {
                            SendToPlayer(player, "PLAYERNUMBER " + player.playerNumber);
                        }
                        SendPlayerList();
                        _usersConnected.PlayerJoined(PlayerList.AddressLookup[e.Address.ToString()]);
                        SendPlayerList();
                    }
                    break;
                case "CARD":
                    
                    PlayerPlayedCard( p, int.Parse( messageArray[1] ), messageArray);
                    SendToAllPlayers("ANIMATION CARDSFROM " + p.playerNumber + " 1");
                    break;
                case "DRAWCARD":
                    DownDeck.Peek().OnDraw(this, p, messageArray);
                    
                    break;
                case "CARDARGS":
                    if(GameState == 3)
                        WaitingCard.TargetedAction(this,messageArray);
                    else if(GameState == 0)
                    {
                        if (_playerSwap == -1)
                        {
                            _playerSwap = int.Parse(messageArray[1]);
                            SendToAllPlayers("LOBBY");
                        }
                        else
                        {
                            PlayerList.SwapPlayer(_playerSwap, int.Parse(messageArray[1]));
                            _playerSwap = -1;
                            SendToAllPlayers("LOBBY");
                        }
                    }
                    break;
                case "LIGHTON":
                    PlayerList.PlayerLight(p);
                    break;
                case "ANNOUNCE":
                    SendAnnounce(e.Message.Remove(0,8));
                    break;
                case "DRINKRESET":
                    SendToAllPlayers(String.Format("SETDRINK {0} 0",p.playerNumber.ToString()));
                    break;
                case "DRUNK":
                    SendPlayerDrinks(p, -1);
                    break;
            }
        }
        public void PlayerPlayedCard(Player player, int card, string[] cardArgs)
        {
            if (PlayerList.Turn == player.playerNumber)
            {
                player.CardsInHand[card].Execute(this, player, null);
            }
        }

        private void Form1_Close(object sender, FormClosingEventArgs e)
        {
            IsRunning = false;
            byte[] b = new byte[1];
            b[0] = 1;
            foreach (TimedEvent t in TimedEventList)
            {
                t.IsRunning = false;
            }
            _udpSocket.SendTo(b, _localEndPoint);
            GameState = -1;
            _udpThread.Abort();
        }

        public class UdpEvent : EventArgs
        {
            public string Message;
            public EndPoint Address;
        }

        private void AddTextFromThread(string message)
        {
            if (this.logBox.InvokeRequired)
                this.logBox.BeginInvoke(new MethodInvoker(delegate() { AddTextFromThread( message); }));
            else
               AddText( message);
        }

        public string RandomTaunt()
        {
            Random r = new Random();
            switch(r.Next(0, 7))
            {
                case 0:
                    return "You really suck at this";
                case 1:
                    return "Man that sucked. Better luck next time";
                case 2:
                    return "Oh wow, did you see that coming?";
                case 3:
                    return "AHAHHHHAHAHAHHAHAHAHHAHAHHHHAH";
                case 4:
                    return "POOTTTTATTTOOOEEE";
                case 5:
                    return "There once was a down-syndromed dyslexic blind crippled Amish hooker. They were better at this game than you.";
                case 6:
                    return "Even a ranga wouldn't suck this bad";

            }
            return "";

        }
        public void PlayerPickupCard(int noOfCards, Player p, string s)
        {
            
            SendToPlayer(p, "TIMEDFORM " + noOfCards + " " + s);
            for (int i = 0; i < noOfCards; i++)
            {
                if (DrawDeck.Count == 0)
                {
                    ReShuffle();
                }
                p.CardsInHand.Add(DrawDeck.Pop());
            }

            SendPlayerCards(p);
        }


        public void ReShuffle()
        {
            Card temp = DownDeck.Pop();
            DrawDeck = DownDeck;
            DownDeck = new Stack<Card>();
            DownDeck.Push(temp);
            ShuffleDeck();
            SendAnnounce("Deck shuffled! " + DrawDeck.Count + " cards remain.");
        }
        public void SendPlayerDrinks(Player p, int noOfDrinks)
        {
            SendToAllPlayers(string.Format("DRINK {0} {1}",p.playerNumber,noOfDrinks.ToString()));
        }
        public void PlayerPickupCard(int noOfCards, Player p)
        {
            SendPlayerDrinks(p, noOfCards);
            if( !p.StillIn)
            {
                return;
            }
            SendAnnounce(p.Name + " just got served " + noOfCards + " cards!");
           
            for (int i = 0; i < noOfCards; i++)
            {
                if(DrawDeck.Count == 0 )
                {
                    ReShuffle();
                }
                p.CardsInHand.Add(DrawDeck.Pop());
            }
            SendToAllPlayers("ANIMATION CARDSTO " + p.playerNumber + " " + noOfCards);
            SendPlayerCards(p);
        }
        public void PlayerPickupCardQuiet(int noOfCards, Player p)
        {
            for (int i = 0; i < noOfCards; i++)
            {
                if (DrawDeck.Count == 0)
                {
                    ReShuffle();
                }
                p.CardsInHand.Add(DrawDeck.Pop());
            }

            SendPlayerCards(p);
        }
        public void SendAnnounce(string toSend)
        {
            SendToAllPlayers("ANNOUNCE " + toSend);
        }
        public void SendPlayerCards(Player p)
        {
            p.CardsInHand.Sort();
            for (int i = 0; i <= PlayerList.NumberPlayers; i++)
            {
                if (p.playerNumber == i)
                {
                    string toSend = "CARDLIST " + p.CardsInHand.Count;
                    foreach (Card c in p.CardsInHand)
                    {
                        toSend = toSend + " " + c.SortValue;
                    }
                    toSend += " " + "END";
                    SendToPlayer(p, toSend);
                }
            }
            SendToAllPlayers("NUMBERCARDS " + p.playerNumber + " " + p.CardsInHand.Count());
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            foreach (Player p in PlayerList.PlayerArray)
            {
                SendToPlayer(p, "PLAYERNUMBER " + p.playerNumber);//HERHERHE
            }
            StartGame();
        }
        public void SendToAllPlayers(string toSend)
        {
            foreach (Player p in PlayerList.PlayerArray)
            {
                SendToPlayer( p, toSend);
            }
        }
        public void SendToPlayer(Player p, string toSend)
        {
            if (p == null)
            {
                return;
            }
            System.Text.UTF8Encoding  encoding=new System.Text.UTF8Encoding();
            _udpSocket.SendTo(encoding.GetBytes(toSend), p.Address );
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            topCardLabel.Text = DownDeck.Peek().Name;
        }

        private void _pauseButton_Click(object sender, EventArgs e)
        {
            TimedEventList[0].IsRunning = false;
            _pauseButton.Hide();
            _resumeButton.Show();
            _usersConnected = new UsersConnected(PlayerList);
            _usersConnected.Show();
            GameState = -2;
            _broadcastThread = new Thread(new ThreadStart(BroadcastServerThread));
            _broadcastThread.Start();
        }

        private void _resumeButton_Click(object sender, EventArgs e)
        {
            TimedEventList[0].Start();
            _resumeButton.Hide();
            _pauseButton.Show();
            _usersConnected.Hide();
            SendToAllPlayers("TOPCARD " + DownDeck.Peek().SortValue);
            GameState = 1;
            foreach (Player p in PlayerList.PlayerArray)
            {
                SendToPlayer(p, String.Format("PLAYERNUMBER {0}", p.playerNumber.ToString()));
                SendPlayerCards(p);
            }
            SendToAllPlayers(String.Format("TURN {0}",PlayerList.Turn.ToString()));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Player player in PlayerList.PlayerArray)
            {
                SendToPlayer(player, "PLAYERNUMBER " + player.playerNumber);
            }
            SendPlayerList();
        }

        private void OptionsButton_Click(object sender, EventArgs e)
        {
            GameOptions g = new GameOptions();
            g.Show();
        }
    }
}