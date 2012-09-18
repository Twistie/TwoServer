using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Two_Server
{
    /// <summary>
    /// Contains information about players as well as an array of the players, and methods for
    /// adding and accessing them
    /// </summary>
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
        /// <summary>
        /// Constructor requires a link back to the twoserver that initialized it
        /// </summary>
        /// <param name="twoServ"></param>
        public PlayerList( TwoServerWindow twoServ)
        {
            _twoServer = twoServ;
        }
        /// <summary>
        /// Ensures that a player isn't already in the game and adds them
        /// </summary>
        /// <param name="playerAddress">IP address of player</param>
        /// <param name="name">Name of player</param>
        /// <returns>Boolean if the add was successful</returns>
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
        /// <summary>
        /// Swaps two players positions
        /// </summary>
        /// <param name="p1">Player 1 to be swapped</param>
        /// <param name="p2">Player 2 to be swapped</param>
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
        /// <summary>
        /// Gets the next player in turn, skips players that are out. Also increments the princess timer.
        /// </summary>
        /// <param name="noOfTurns">Number of turns</param>
        /// <returns>The next players whos turn it is</returns>
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
        /// <summary>
        /// Actually changes the current turn
        /// </summary>
        /// <param name="noOfTurns"></param>
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
        /// <summary>
        /// Returns a random player (can be out of game already)
        /// </summary>
        /// <returns>A random player</returns>
        public Player GetRandomPlayer()
        {
            Random r = new Random();
            return PlayerArray[r.Next(0,NumberPlayers)];
        }
        /// <summary>
        /// Set the turn to a specific player by player number
        /// </summary>
        /// <param name="player">Player number to set to</param>
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

        /// <summary>
        /// Event for when a player turns on their light
        /// </summary>
        /// <param name="p">Player that turned on their light</param>
        public void PlayerLight( Player p )
        {
            if( LightsOn == 0 )
            {
                if( LightMaster == p.playerNumber)
                {
                    if (LastLight + 450000000 > DateTime.Now.Ticks)
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
        //Checks whether fufu has expired and if so, unsets it
        public void CheckFufu()
        {
            _princessTurns++;
            if( _princessTurns > (PlayersRemaining-1) * 5+12)
                UnsetFufu();
        }
        /// <summary>
        /// Once a lightmaster round has finished, this resets it back to default
        /// </summary>
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
        /// <summary>
        /// Sets a players light to on for all players
        /// </summary>
        /// <param name="p">Player that turned on light</param>
        public void PlayerTurnedOnLight(Player p)
        {
            p.LightOn = true;
            _twoServer.SendToAllPlayers("LIGHTON " + p.playerNumber);
        }
        /// <summary>
        /// Deals with consequences of a failed lightmaster round
        /// </summary>
        /// <param name="p">Player that failed</param>
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
        /// <summary>
        /// Removes a card from a players hand and removes them from the player pool if they're out of cards
        
        /// </summary>
        /// <param name="p">Player with the card to remove</param>
        /// <param name="c">Card to be removed</param>
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

        /// <summary>
        /// Sets a player to fufu
        /// </summary>
        /// <param name="playerToFufu">Player to be made fufu</param>
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
        /// <summary>
        /// removes the fufu condition from whichever player it is set to
        /// </summary>
        public void UnsetFufu()
        {
            if (_princessFufu == -1)
                return;
            PlayerArray[_princessFufu].Name = _fufuName;
            _twoServer.SendToAllPlayers(String.Format("NAME {0} {1}",_princessFufu,_fufuName));
            _twoServer.SendToAllPlayers(string.Format("COLOUR {0} 0", PlayerArray[_princessFufu].playerNumber.ToString()));
            _princessFufu = -1;

        }
        /// <summary>
        /// Makes fufu drink
        /// </summary>
        public void FufuDrink()
        {
            if( _princessFufu != -1 )
           // _twoServer.PlayerPickupCard(2, PlayerArray[_princessFufu]);
                _twoServer.SendToPlayer(PlayerArray[_princessFufu], "TIMEDFORM 6 Time to drink, Princess!");
        }
    }
}
