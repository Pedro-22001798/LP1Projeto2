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
        IEnumerable<Card> GetDeck();
        IEnumerable<Card> GetHand();
        void DefineCurrentHand(IEnumerable<Card> hand);
    }
}