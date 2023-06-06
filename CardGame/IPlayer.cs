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
        IEnumerable<ICard> Hand {get;}
        IEnumerable<ICard> Deck {get;}
        IEnumerable<ICard> PlayingHand {get;}
        void DefineDeck(IEnumerable<ICard> deck);
        void DefineHand(IEnumerable<ICard> hand);
        void DefinePlayingHand(IEnumerable<ICard> playingHand);
        void UseMana(int mana);
        void DefineMana(int mana);
        void RemoveCardFromDeck(ICard card);
        void RemoveCardFromHand(ICard card);
        void AddCardToHand(ICard card);
        void GetMana(int mana);
        void TakeDamage(int damage);
        ICard? GetCardFromTopOfDeck();
    }
}