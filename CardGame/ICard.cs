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

        void TakeDamage(int damage);
        void ReduceDamage(int damage);
        void SetDefense(int defense);
    }
}