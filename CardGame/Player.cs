using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGame
{
    public class Player : IPlayer
    {
        public string Name{get;}
        public int Health {get; set;}
        public int Mana {get; set;}
        IEnumerable<Card> deck;
        IEnumerable<Card> currentHand;
        public Player(string name, IEnumerable<Card> deck)
        {
            this.Name = name;
            this.Health = 10;
            this.Mana = 0;
            this.deck = deck;
        }

        public IEnumerable<Card> GetDeck()
        {
            foreach(Card c in deck)
                yield return c;
        }

        public void DefineCurrentHand(IEnumerable<Card> currentHand)
        {
            this.currentHand = currentHand;
        }
    }
}