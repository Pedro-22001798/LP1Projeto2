using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGame
{
    public class Player : IPlayer
    {
        string name;
        int health;
        int mana;
        List<Card> deck;

        public Player(string name, List<Card> deck)
        {
            this.name = name;
            this.health = 10;
            this.mana = 0;
            this.deck = deck;
        }
    }
}