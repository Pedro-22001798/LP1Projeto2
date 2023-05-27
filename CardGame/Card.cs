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
        
        /// <summary>
        /// Card constructor, called when creating a new card.
        /// </summary>
        /// <param name="name">Name of the card.</param>
        /// <param name="cost">Cost of the card.</param>
        /// <param name="attack">Attack of the card.</param>
        /// <param name="defense">Defense of the card.</param>
        public Card(string name, int cost, int attack, int defense)
        {
            this.Name = name;
            this.Cost = cost;
            this.Attack = attack;
            this.Defense = defense;
        }
    }
}