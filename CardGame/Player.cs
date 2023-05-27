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
        IEnumerable<ICard> deck;
        IEnumerable<ICard> currentHand;
        public Player(string name, IEnumerable<ICard> deck)
        {
            this.Name = name;
            this.Health = 10;
            this.Mana = 0;
            this.deck = deck;
        }

        public IEnumerable<ICard> GetDeck()
        {
            foreach(ICard c in deck)
                yield return c;
        }

        public IEnumerable<ICard> GetHand()
        {
            foreach(ICard c in currentHand)
                yield return c;
        }

        public void DefineCurrentHand(IEnumerable<ICard> currentHand)
        {
            this.currentHand = currentHand;
        }
    }
}