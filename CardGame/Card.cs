using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGame
{
    public class Card : ICard
    {
        public string Name{get;private set;}
        public int Cost{get;private set;}
        public int Attack{get;private set;}
        public int Defense{get;private set;}
        public Card(string name, int cost, int attack, int defense)
        {
            this.Name = name;
            this.Cost = cost;
            this.Attack = attack;
            this.Defense = defense;
        }
    }
}