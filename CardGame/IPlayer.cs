using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGame
{
    public interface IPlayer
    {
        /// <summary>
        /// Player's name property
        /// </summary>
        /// <value>Player's name</value>
        string Name{get;}
        /// <summary>
        /// Player's health property
        /// </summary>
        /// <value>Player's health</value>
        int Health{get;}
        /// <summary>
        /// Player's mana property
        /// </summary>
        /// <value>Player's mana</value>
        int Mana{get;}
        /// <summary>
        /// Player's Hand property
        /// </summary>
        /// <value>Player's hand</value>
        IEnumerable<ICard> Hand {get;}
        /// <summary>
        /// Player's Deck property
        /// </summary>
        /// <value>Player's deck</value>
        IEnumerable<ICard> Deck {get;}
        /// <summary>
        /// Player's Playing Hand property
        /// </summary>
        /// <value>Player's playing hand</value>
        IEnumerable<ICard> PlayingHand {get;}
        /// <summary>
        /// Method responsible for setting the player's new deck
        /// </summary>
        /// <param name="deck">Player's new deck</param>
        void DefineDeck(IEnumerable<ICard> deck);
        /// <summary>
        /// Method responsible for setting the player's new hand
        /// </summary>
        /// <param name="hand">Player's new hand</param>
        void DefineHand(IEnumerable<ICard> hand);
        /// <summary>
        /// Method responsible for setting the player's new playing hand
        /// </summary>
        /// <param name="playingHand">Player's new playing hand</param>
        void DefinePlayingHand(IEnumerable<ICard> playingHand);
        /// <summary>
        /// Method responsible for using player's mana
        /// </summary>
        /// <param name="mana">Used mana</param>
        void UseMana(int mana);
        /// <summary>
        /// Method responsible for setting new player's mana
        /// </summary>
        /// <param name="mana">Player's new mana</param>
        void DefineMana(int mana);
        /// <summary>
        /// Method responsible for removing a card from the player's deck
        /// </summary>
        /// <param name="card">Removed card</param>
        void RemoveCardFromDeck(ICard card);
        /// <summary>
        /// Method responsible for removing a card from the player's hand
        /// </summary>
        /// <param name="card">Removed card</param>
        void RemoveCardFromHand(ICard card);
        /// <summary>
        /// Method responsible for adding a card to the player's hand
        /// </summary>
        /// <param name="card">Added card</param>
        void AddCardToHand(ICard card);
        /// <summary>
        /// Method responsible for adding mana to the player
        /// </summary>
        /// <param name="mana">Added mana</param>
        void GetMana(int mana);
        /// <summary>
        /// Method responsible for dealing damage to the player's health
        /// </summary>
        /// <param name="damage">Dealt damage</param>
        void TakeDamage(int damage);
        /// <summary>
        /// Method responsible for getting the first card from the top of the player's deck
        /// </summary>
        /// <returns>Card from the top of deck</returns>
        ICard? GetCardFromTopOfDeck();
    }
}