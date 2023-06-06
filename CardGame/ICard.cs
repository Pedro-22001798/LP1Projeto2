using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGame
{
    public interface ICard
    {
        /// <summary>
        /// Name property to view the card's name.
        /// </summary>
        string Name{get;}

        /// <summary>
        /// Cost property to view the card's cost.
        /// </summary>
        int Cost{get;}

        /// <summary>
        /// Attack property to view the card's attack.
        /// </summary>
        int Attack{get;}

        /// <summary>
        /// Defense property to view the card's defense.
        /// </summary>
        int Defense{get;}
        /// <summary>
        /// Extra Attack property to view the card's extra attack to be dealt
        /// </summary>
        int ExtraAttack {get;}

        /// <summary>
        /// Method responsible for dealing damage to the card
        /// </summary>
        /// <param name="damage">Dealt damage</param>
        void TakeDamage(int damage);
        /// <summary>
        /// Method responsible for setting the card's new extra attack
        /// </summary>
        /// <param name="attack">New Extra Attack</param>
        void SetExtraAttack(int attack);
    }
}