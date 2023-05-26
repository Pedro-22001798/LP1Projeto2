using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGame
{
    public class Card : ICard
    {
        string name;
        int cost;
        int attack;
        int defense;
        public Card(string name, int cost, int attack, int defense)
        {
            this.name = name;
            this.cost = cost;
            this.attack = attack;
            this.defense = defense;
        }
    }
}