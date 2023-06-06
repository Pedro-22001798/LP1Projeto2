using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGame
{
    public class Card : ICard
    {
        /// <summary>
        /// Property responsible for holding and viewing the card's name
        /// </summary>
        public string Name{get;private set;}
        /// <summary>
        /// Property responsible for holding and viewing the card's cost
        /// </summary>
        public int Cost{get;private set;}
        /// <summary>
        /// Property responsible for holding and viewing the card's attack
        /// </summary>
        public int Attack{get;private set;}
        /// <summary>
        /// Property responsible for holding and viewing the card's defense
        /// </summary>
        public int Defense{get;private set;}
        /// <summary>
        /// Property responsible for holding and viewing the card's extra attack to be dealt
        /// </summary>
        public int ExtraAttack{get;private set;}
        
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
            this.ExtraAttack = 0;
        }

        /// <summary>
        /// Method responsible for dealing damage to the card
        /// </summary>
        /// <param name="damage">Dealt damage</param>
        public void TakeDamage(int damage)
        {
            Defense -= damage;
        }

        /// <summary>
        /// Method responsible for setting the card's new extra damage to be dealt
        /// </summary>
        /// <param name="attack">Card's new extra damage</param>
        public void SetExtraAttack(int attack)
        {
            this.ExtraAttack = attack;
        }
    }
}