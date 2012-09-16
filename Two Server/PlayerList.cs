using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Two_Server
{
    public class PlayerList
    {
        public Dictionary<string,int> AddressLookup = new Dictionary<string,int>();

        public List<Player> PlayerArray = new List<Player>();

        public int NumberPlayers = 0;
        public int Turn = 0;
        public int LightMaster = -1;
        public int LightsOn = 0;
        public double LastLight = DateTime.Now.Ticks;
        public int PlayersRemaining = 0;
        private int _princessFufu = -1;
        private string _fufuName;
        private int _princessTurns = 0;
        readonly TwoServerWindow _twoServer;

        public PlayerList( TwoServerWindow twoServ)
        {
            _twoServer = twoServ;
        }
        public Boolean AddPlayer( EndPoint playerAddress, string name)
        {
            if (!AddressLookup.ContainsKey(playerAddress.ToString()))
            {
                AddressLookup.Add(playerAddress.ToString(), NumberPlayers);
                Player p = new Player();
                p.Address = playerAddress;
                p.playerNumber = NumberPlayers;
                p.Name = name;
                PlayerArray.Add( p);
                NumberPlayers++;
                PlayersRemaining = NumberPlayers;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void SwapPlayer(int p1, int p2)
        {
            string p1String = "";
            string p2String = "";
            
            foreach (KeyValuePair<string,int> kv in AddressLookup)
            {
                if (kv.Value == p1)
                    p1String = kv.Key;
            }
            foreach (KeyValuePair<string, int> kv in AddressLookup)
            {
                if (kv.Value == p2)
                    p2String = kv.Key;
                
            }
            AddressLookup[p1String] = p2;
            AddressLookup[p2String] = p1;

            Player holderPlayer = PlayerArray[p1];
            PlayerArray[p1] = PlayerArray[p2];
            PlayerArray[p2] = holderPlayer;

            PlayerArray[p1].playerNumber = p1;
            PlayerArray[p2].playerNumber = p2;

            _twoServer.SendToPlayer(PlayerArray[p1], string.Format("PLAYERNUMBER {0}", p1));
            _twoServer.SendToPlayer(PlayerArray[p2], string.Format("PLAYERNUMBER {0}", p2));
            _twoServer.SendPlayerList();
        }
        public Player GetNextPlayer(int noOfTurns)
        {
            CheckFufu();
            if (PlayersRemaining == 1)
            {
                _twoServer.FinishGame();
                return PlayerArray[Turn];
            }
            int tempTurn = Turn;
            for (int i = 0; i < noOfTurns; i++)
            {
                tempTurn++;
                if (tempTurn > NumberPlayers - 1)
                    tempTurn = 0;
                while (!PlayerArray[tempTurn].StillIn)
                {
                    tempTurn++;
                    if (tempTurn > NumberPlayers - 1)
                        tempTurn = 0;
                }

            }
            return PlayerArray[tempTurn];
        }
        public void NextPlayer(int noOfTurns)
        {
            CheckFufu();
            if( PlayersRemaining == 1)
            {
                _twoServer.FinishGame();
                return;
            }
            int tempTurn = Turn;
            for (int i = 0; i < noOfTurns; i++)
            {
                tempTurn++;
                if (tempTurn > NumberPlayers - 1)
                    tempTurn = 0;
                while (!PlayerArray[tempTurn].StillIn)
                {
                    tempTurn++;
                    if (tempTurn > NumberPlayers - 1)
                        tempTurn = 0;
                }
                
            }
            Turn = tempTurn;
            _twoServer.SendToAllPlayers("TURN " + Turn);
            _twoServer.SendToAllPlayers(String.Format("GAMEANNOUNCE {0}'s turn", PlayerArray[Turn].Name));
        }
        public Player GetRandomPlayer()
        {
            Random r = new Random();
            return PlayerArray[r.Next(0,NumberPlayers)];
        }
        public void SetPlayer( int player)
        {
            CheckFufu();
            int tempTurn = player;
            while (!PlayerArray[tempTurn].StillIn)
            {
                tempTurn++;
                if (tempTurn > NumberPlayers - 1)
                    tempTurn = 0;
            }
            Turn = tempTurn;
            _twoServer.SendToAllPlayers("TURN " + Turn);
            _twoServer.SendToAllPlayers(String.Format("GAMEANNOUNCE {0}'s turn", PlayerArray[Turn].Name));
        }
        public void PlayerLight( Player p )
        {
            if( LightsOn == 0 )
            {
                if( LightMaster == p.playerNumber)
                {
                    if (LastLight + 600000000 > DateTime.Now.Ticks)
                    {
                        
                        _twoServer.SendToPlayer(p,"ANNOUNCE Too soon!");
                        return;
                    }
                    PlayerTurnedOnLight(p);
                    LightMasterEvent lm = new LightMasterEvent(_twoServer, 30f);
                    lm.Start();
                    _twoServer.TimedEventList.Add(lm);
                    LightsOn++;
                    LastLight = DateTime.Now.Ticks;
                }
                else
                {
                    PlayerFailedLight( p );
                }
            }
            else if (LightsOn == NumberPlayers - 1)
            {
                ResetLightMaster();
                PlayerFailedLight( p);
            }
            else
            {
                LightsOn++;
                PlayerTurnedOnLight( p);
            }
        }
        public void CheckFufu()
        {
            _princessTurns++;
            if( _princessTurns > (PlayersRemaining-1) * 5+12)
                UnsetFufu();
        }
        public void ResetLightMaster()
        {
            foreach (Player player in PlayerArray)
            {
                player.LightOn = false;
                _twoServer.SendToAllPlayers("LIGHTOFF " + player.playerNumber);
            }
            LightsOn = 0;
            List<TimedEvent> toRemove = new List<TimedEvent>();
            foreach (TimedEvent t in _twoServer.TimedEventList)
            {
                if( t.Type == "LIGHTMASTER")
                {
                    t.IsRunning = false;
                    toRemove.Add(t);
                }
            }
            foreach(TimedEvent t in toRemove)
            {
                _twoServer.TimedEventList.Remove(t);
            }
        }
        public void PlayerTurnedOnLight(Player p)
        {
            p.LightOn = true;
            _twoServer.SendToAllPlayers("LIGHTON " + p.playerNumber);
        }
        public void PlayerFailedLight(Player p)
        {
            if( p.StillIn )
            {
                _twoServer.PlayerPickupCard(1,p);
                _twoServer.SendAnnounce(p.Name + " just failed at Lightmaster. +1 Card'n'drink");
            }
            else
            {
                _twoServer.SendAnnounce(String.Format("{0} failed hardcore at Lightmaster. Have a drink sunshine",p.Name));
            }
        }
        public void RemovePlayerCard(Player p, Card c )
        {
            p.CardsInHand.Remove(c);
            if (p.CardsInHand.Count == 0)
            {
                _twoServer.SendAnnounce(p.Name + " is out!");
                PlayersRemaining --;
                p.StillIn = false;
            }
        }
        public void SetFufu( int playerToFufu)
        {
            _princessTurns = 0;
            if( _princessFufu != -1)
                UnsetFufu();
            _fufuName = PlayerArray[playerToFufu].Name;
            _princessFufu = playerToFufu;
            _twoServer.SendToAllPlayers(String.Format("NAME {0} {1}",playerToFufu,"Princess Fufu"));
            _twoServer.SendToAllPlayers(string.Format("COLOUR {0} 1", PlayerArray[_princessFufu].playerNumber.ToString()));
        }
        public void UnsetFufu()
        {
            if (_princessFufu == -1)
                return;
            PlayerArray[_princessFufu].Name = _fufuName;
            _twoServer.SendToAllPlayers(String.Format("NAME {0} {1}",_princessFufu,_fufuName));
            _twoServer.SendToAllPlayers(string.Format("COLOUR {0} 0", PlayerArray[_princessFufu].playerNumber.ToString()));
            _princessFufu = -1;

        }
        public void FufuDrink()
        {
            if( _princessFufu != -1 )
           // _twoServer.PlayerPickupCard(2, PlayerArray[_princessFufu]);
                _twoServer.SendToPlayer(PlayerArray[_princessFufu], "TIMEDFORM 6 Time to drink, Princess!");
        }
    }
}
