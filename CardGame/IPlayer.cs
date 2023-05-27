using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGame
{
    public interface IPlayer
    {
        string Name{get;}
        int Health{get;}
        int Mana{get;}
        IEnumerable<ICard> GetDeck();
        IEnumerable<ICard> GetHand();
        void DefineCurrentHand(IEnumerable<ICard> hand);
    }
}