using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Two_Server
{
    public class Player
    {
        public Boolean LightOn;
        public EndPoint Address;
        public List<Card> CardsInHand = new List<Card>();
        public Boolean StillIn = true;
        public int playerNumber;
        public string Name;
    }
}
