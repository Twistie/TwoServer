using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Two_Server
{
    public class Card : IComparable
    {
        public string Name;
        public double SortValue;
        public List<string> Types = new List<string>();
        public List<string> ValidTypes = new List<string>();
        int IComparable.CompareTo(object obj)
        {
            Card c = (Card)obj;
            if (SortValue > c.SortValue)
               return 1;

            if (SortValue < c.SortValue)
               return -1;

            else
               return 0;
        }
        public virtual Boolean Execute(TwoServerWindow twoServer, Player player, string[] cardArgs)
        {
            twoServer.DownDeck.Push(this);
            twoServer.PlayerList.RemovePlayerCard(player, this);
            twoServer.SendPlayerCards(player);
            int t = (int) (SortValue*100)%10;
            if( twoServer.DrinkLevel == 2)
            {
                switch(t)
                {
                    case 1:
                        twoServer.SendPlayerDrinks(player,1);
                        twoServer.SendAnnounce(String.Format("{0}: One for me", player.Name));
                        break;
                    case 2:
                        foreach (Player p in twoServer.PlayerList.PlayerArray)
                        {
                            if( p != player)
                                twoServer.SendPlayerDrinks(p, 2);
                        }
                        twoServer.SendAnnounce(String.Format("{0}: Two for you!", player.Name));
                        break;
                    case 3:
                        foreach (Player p in twoServer.PlayerList.PlayerArray)
                        {
                            if (p.playerNumber%2 == 1)
                                twoServer.SendPlayerDrinks(p, 1);
                        }
                        twoServer.SendAnnounce(String.Format("{0}: Three is odd", player.Name));
                        break;
                    case 4:
                        foreach (Player p in twoServer.PlayerList.PlayerArray)
                        {
                            if (p.playerNumber % 2 == 0)
                                twoServer.SendPlayerDrinks(p, 1);
                        }
                        twoServer.SendAnnounce(String.Format("{0}: Four is even", player.Name));
                        break;
                    case 5:
                        Player victim = twoServer.PlayerList.GetRandomPlayer();
                        twoServer.SendAnnounce("Random drinks for " + victim.Name);
                        twoServer.SendToPlayer(victim, "TIMEDFORM 6 Randomly punished by " + player.Name);
                        break;
                }
            }
            twoServer.PlayerList.NextPlayer(1);
            twoServer.SendToAllPlayers("TOPCARD " + SortValue);
            return true;
        }
        public virtual void OnDraw(TwoServerWindow twoServer, Player player, string[] cardArgs)
        {
            twoServer.SendToAllPlayers(String.Format("ANNOUNCE {0} picked up a card!",player.Name));
            twoServer.PlayerPickupCard(1,player);
            twoServer.PlayerList.NextPlayer(1);
        }

        public virtual void TargetedAction(TwoServerWindow twoServer,string[] args)
        {
            return;
        }
    }
    
    public class ColorDraw : Card
    {
        public int CurrentDrawAmount = 0;
        public int DrawAmount = 0;
        public Boolean IsActive = true;
        public override Boolean Execute(TwoServerWindow twoServer, Player player, string[] cardArgs)
        {
            IsActive = true;
            CurrentDrawAmount = DrawAmount;
            if (twoServer.DownDeck.Peek().Types.Contains("DRAW " + CurrentDrawAmount))
            {
                ColorDraw temp = (ColorDraw)twoServer.DownDeck.Peek();
                if( temp.IsActive )
                    CurrentDrawAmount = temp.CurrentDrawAmount + DrawAmount;
            }
            
            twoServer.DownDeck.Push(this);
            twoServer.PlayerList.RemovePlayerCard(player, this);
            twoServer.SendPlayerCards(player);
            twoServer.PlayerList.NextPlayer(1);
            twoServer.SendToAllPlayers("TOPCARD " + SortValue);
            return true;
        }
        public override void OnDraw(TwoServerWindow twoServer, Player player, string[] cardArgs)
        {
            if (IsActive)
            {
                twoServer.PlayerPickupCard( CurrentDrawAmount, player );
                IsActive = false;
            }else
            {
                twoServer.PlayerPickupCard(1, player);
            }
            twoServer.SendToAllPlayers("TOPCARD " + SortValue + "1");
            twoServer.PlayerList.NextPlayer(1);
        }
    }
    public class SkipCard : Card
    {
        public override Boolean Execute(TwoServerWindow twoServer, Player player, string[] cardArgs)
        {
            twoServer.DownDeck.Push(this);
            twoServer.PlayerList.RemovePlayerCard(player, this);
            twoServer.SendPlayerCards(player);
            twoServer.SendPlayerDrinks(twoServer.PlayerList.GetNextPlayer(1),1);
            twoServer.PlayerList.NextPlayer(2);
            twoServer.SendToAllPlayers("TOPCARD " + SortValue);
            return true;
        }
        public override void OnDraw(TwoServerWindow twoServer, Player player, string[] cardArgs)
        {
            player.CardsInHand.Add(twoServer.DrawDeck.Pop());
            twoServer.SendPlayerCards(player);
            twoServer.PlayerList.NextPlayer(1);
        }
    }
    public class DoubleDownCard : Card
    {
        public override Boolean Execute(TwoServerWindow twoServer, Player player, string[] cardArgs)
        {
            twoServer.DownDeck.Push(this);
            twoServer.PlayerList.RemovePlayerCard(player, this);
            twoServer.SendPlayerCards(player);
            twoServer.PlayerList.SetPlayer(player.playerNumber);
            twoServer.SendToAllPlayers("TOPCARD " + SortValue);
            return true;
        }
        public override void OnDraw(TwoServerWindow twoServer, Player player, string[] cardArgs)
        {
            player.CardsInHand.Add(twoServer.DrawDeck.Pop());
            twoServer.SendPlayerCards(player);
            twoServer.PlayerList.NextPlayer(1);
        }
    }
    public class PlayerTargetedCard : Card
    {
        public int CurrentDrawAmount = 0;
        public int DrawAmount;
        public Boolean IsActive = true;
        public override Boolean Execute(TwoServerWindow twoServer, Player player, string[] cardArgs)
        {
            IsActive = true;
            CurrentDrawAmount = DrawAmount;
            if (twoServer.DownDeck.Peek().Types.Contains("DRAW " + CurrentDrawAmount) )
            {
                ColorDraw temp = (ColorDraw)twoServer.DownDeck.Peek();
                if (temp.IsActive)
                    CurrentDrawAmount = temp.CurrentDrawAmount + DrawAmount;
            }
            if( twoServer.DownDeck.Peek().Types.Contains("TARGET " + CurrentDrawAmount))
            {
                PlayerTargetedCard temp = (PlayerTargetedCard)twoServer.DownDeck.Peek();
                if (temp.IsActive)
                    CurrentDrawAmount = temp.CurrentDrawAmount + DrawAmount;
            }
            twoServer.DownDeck.Push(this); 
            twoServer.PlayerList.RemovePlayerCard(player, this);
            twoServer.SendPlayerCards(player);
            twoServer.SendToAllPlayers("TOPCARD " + SortValue);
            twoServer.WaitForPlayerTarget(String.Format("Draw {0}",CurrentDrawAmount.ToString()));
            twoServer.WaitingCard = this;
            return true;
        }
        public override void TargetedAction(TwoServerWindow twoServer, string[] args)
        {
            twoServer.PlayerList.SetPlayer(int.Parse(args[1]));
            twoServer.GameState = 1;
            return;
        }
        public override void OnDraw(TwoServerWindow twoServer, Player player, string[] cardArgs)
        {
            if (IsActive)
            {
                twoServer.PlayerPickupCard(CurrentDrawAmount, player);
                IsActive = false;
            }
            else
            {
                twoServer.PlayerPickupCard(1, player);
            }
            twoServer.SendToAllPlayers("TOPCARD " + SortValue + "1");
            twoServer.PlayerList.NextPlayer(1);
        }
    }
    public class LightMasterCard : Card
    {
        public override Boolean Execute(TwoServerWindow twoServer, Player player, string[] cardArgs)
        {
            twoServer.DownDeck.Push(this); 
            twoServer.PlayerList.RemovePlayerCard(player, this);
            twoServer.SendPlayerCards(player);
            twoServer.PlayerList.NextPlayer(1);
            twoServer.SendToAllPlayers("TOPCARD " + SortValue);
            twoServer.PlayerList.LightMaster = player.playerNumber;
            twoServer.SendAnnounce(player.Name + " just became the lightmaster!");
            return true;
        }
    }
    public class PrincessFufu : Card
    {
        public int DrawAmount = 0;
        public override Boolean Execute(TwoServerWindow twoServer, Player player, string[] cardArgs)
        {
            
            twoServer.DownDeck.Push(this);
            twoServer.PlayerList.RemovePlayerCard(player, this);
            twoServer.SendPlayerCards(player);
            twoServer.SendToAllPlayers("TOPCARD " + SortValue);
            twoServer.SendToPlayer(player, "TARGETPLAYER Princess Fufu!");
            twoServer.WaitingCard = this;
            twoServer.WaitForPlayerTarget("Who To Fufu?");
            return true;
        }
        public override void TargetedAction(TwoServerWindow twoServer, string[] args)
        {
            twoServer.SendAnnounce(twoServer.PlayerList.PlayerArray[int.Parse(args[1])].Name + " just became Princess FuFu!");
            twoServer.PlayerList.SetFufu(int.Parse(args[1]));
            twoServer.PlayerList.NextPlayer(1);
            twoServer.GameState = 1;
            return;
        }
    }
    public class PrincessDrink : Card
    {
        public override Boolean Execute(TwoServerWindow twoServer, Player player, string[] cardArgs)
        {
            twoServer.DownDeck.Push(this);
            twoServer.PlayerList.RemovePlayerCard(player, this);
            twoServer.SendPlayerCards(player);
            twoServer.PlayerList.FufuDrink();
            twoServer.PlayerList.NextPlayer(1);
            twoServer.SendToAllPlayers("TOPCARD " + SortValue);
            
            return true;
        }
    }
    public class BoomCard : Card
    {
        public override Boolean Execute(TwoServerWindow twoServer, Player player, string[] cardArgs)
        {
            foreach (Player p in twoServer.PlayerList.PlayerArray)
            {
                if( p.StillIn)
                {
                    twoServer.PlayerPickupCard(5,p, "BOOM courtesy of " + player.Name);
                }
            }
            twoServer.DownDeck.Push(this);
            twoServer.PlayerList.RemovePlayerCard(player, this);
            twoServer.SendPlayerCards(player);
            twoServer.PlayerList.NextPlayer(1);
            twoServer.SendToAllPlayers("TOPCARD " + SortValue);
            return true;
        }
    }
}
