using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Two_Server
{
    /// <summary>
    /// Card class, base class is for basic number cards
    /// </summary>
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
        /// <summary>
        /// When card is played, this method should be called with the player being the player who used the card
        /// </summary>
        /// <param name="twoServer">For access to various class variables</param>
        /// <param name="player">Player who out down the card</param>
        /// <param name="cardArgs">Arguments for the card</param>
        /// <returns>If card plays successfully should be true</returns>
        public virtual Boolean Execute(TwoServerWindow twoServer, Player player, string[] cardArgs)
        {
            twoServer.DownDeck.Push(this);
            twoServer.PlayerList.RemovePlayerCard(player, this);
            twoServer.SendPlayerCards(player);
            int t = (int) ((SortValue*100)%10);
            if( twoServer.DrinkLevel == 2)
            {
                switch(t)
                {
                    case 1:
                        twoServer.SendDrinkForm(player,3, "One for me!");
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
                            if (p.PlayerNumber%2 == 1)
                                twoServer.SendDrinkForm(p, 3, "Odds Drink!");
                        }
                        twoServer.SendAnnounce(String.Format("{0}: Three is odd", player.Name));
                        break;
                    case 4:
                        foreach (Player p in twoServer.PlayerList.PlayerArray)
                        {
                            if (p.PlayerNumber % 2 == 0)
                                twoServer.SendDrinkForm(p, 3, "Evens Drink!");
                        }
                        twoServer.SendAnnounce(String.Format("{0}: Four is even", player.Name));
                        break;
                    case 5:
                        Player victim = twoServer.PlayerList.GetRandomPlayer();
                        twoServer.SendAnnounce("Random drinks for " + victim.Name);
                        twoServer.SendToAllPlayers("TIMEDFORM 6 " + victim.PlayerNumber + " Randomly punished by " + player.Name);
                        break;
                }
            }
            twoServer.PlayerList.NextPlayer(1);
            twoServer.SendToAllPlayers("TOPCARD " + SortValue);
            return true;
        }
        /// <summary>
        /// When the next player
        /// </summary>
        /// <param name="twoServer"></param>
        /// <param name="player">Player that picked up card</param>
        /// <param name="cardArgs">Additional arguments for the card</param>
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
    /// <summary>
    /// Card type for draw 2, draw 3 coloured cards
    /// </summary>
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
    /// <summary>
    /// Skip a player
    /// </summary>
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
    /// <summary>
    /// Play a card then get to play another card immediatly
    /// </summary>
    public class DoubleDownCard : Card
    {
        public override Boolean Execute(TwoServerWindow twoServer, Player player, string[] cardArgs)
        {
            twoServer.DownDeck.Push(this);
            twoServer.PlayerList.RemovePlayerCard(player, this);
            twoServer.SendPlayerCards(player);
            twoServer.PlayerList.SetPlayer(player.PlayerNumber);
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
    /// <summary>
    /// A card that requires a target from the player that used it
    /// </summary>
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
    /// <summary>
    /// Card that gives two drinks to a targetted person
    /// </summary>
    public class TwoForYouCard : Card
    {
        public override Boolean Execute(TwoServerWindow twoServer, Player player, string[] cardArgs)
        {
            twoServer.DownDeck.Push(this);
            twoServer.PlayerList.RemovePlayerCard(player, this);
            twoServer.SendPlayerCards(player);
            twoServer.SendToAllPlayers("TOPCARD " + SortValue);
            twoServer.WaitForPlayerTarget("Target a player to drink!");
            twoServer.WaitingCard = this;
            return true;
        }
        public override void TargetedAction(TwoServerWindow twoServer, string[] args)
        {
            twoServer.GameState = 1;
            twoServer.SendDrinkForm(twoServer.PlayerList.PlayerArray[int.Parse(args[1])], 4, "Two drinks for you!");

            twoServer.PlayerList.NextPlayer(1);
        }
    }
    /// <summary>
    /// A card that awards the lightmaster status to the player that used it, and resets lightmaster
    /// </summary>
    public class LightMasterCard : Card
    {
        public override Boolean Execute(TwoServerWindow twoServer, Player player, string[] cardArgs)
        {
            twoServer.DownDeck.Push(this); 
            twoServer.PlayerList.RemovePlayerCard(player, this);
            twoServer.SendPlayerCards(player);
            twoServer.PlayerList.NextPlayer(1);
            twoServer.SendToAllPlayers("TOPCARD " + SortValue);
            twoServer.PlayerList.LightMaster = player.PlayerNumber;
            twoServer.SendAnnounce(player.Name + " just became the lightmaster!");
            twoServer.PlayerList.LastLight = 0;
            return true;
        }
    }
    /// <summary>
    /// Targetted card that makes another player into Princess Fufu
    /// </summary>
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
    /// <summary>
    /// A card, that if there is a player afflicted by Princess Fufu, makes them drink
    /// </summary>
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
    /// <summary>
    /// Chuck Norris makes everyone drink. Everyone.
    /// </summary>
    public class BoomCard : Card
    {
        public override Boolean Execute(TwoServerWindow twoServer, Player player, string[] cardArgs)
        {
            foreach (Player p in twoServer.PlayerList.PlayerArray)
            {
                    twoServer.SendDrinkForm(p, 10, "KABLAM, BOOM, BANG!!111one");
            }
            twoServer.DownDeck.Push(this);
            twoServer.PlayerList.RemovePlayerCard(player, this);
            twoServer.SendPlayerCards(player);
            twoServer.PlayerList.NextPlayer(1);
            twoServer.SendToAllPlayers("TOPCARD " + SortValue);
            return true;
        }
    }
    public class MooseCard: Card
    {
        public override Boolean Execute( TwoServerWindow twoServer, Player player, string[] cardArgs)
        {

            base.Execute(twoServer, player, cardArgs);
            twoServer.GameState = 4;
            twoServer.SendToAllPlayers("MOOSE");
            return true;
        }
    }
}
