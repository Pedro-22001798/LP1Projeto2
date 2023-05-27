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
        public IEnumerable<ICard> Deck {get; private set;}
        public IEnumerable<ICard> Hand {get; private set;}
        public Player(string name)
        {
            this.Name = name;
            this.Health = 10;
            this.Mana = 0;
        }
        public void DefineDeck(IEnumerable<ICard> deck)
        {
            this.Deck = deck;
        }

        public void DefineHand(IEnumerable<ICard> hand)
        {
            this.Deck = this.Deck.Except(hand);
            this.Hand = hand;
        }
    }
}