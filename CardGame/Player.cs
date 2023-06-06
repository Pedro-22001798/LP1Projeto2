using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGame
{
    public class Player : IPlayer
    {
        /// <summary>
        /// Name property to view and set the player's name.
        /// </summary>
        public string Name{get; private set;}

        /// <summary>
        /// Health property to view and set the player's health.
        /// </summary>
        public int Health {get; private set;}

        /// <summary>
        /// Mana property to view and set the player's mana.
        /// </summary>
        public int Mana {get; private set;}

        /// <summary>
        /// Deck property to view and set the player's deck.
        /// </summary>
        public IEnumerable<ICard> Deck {get; private set;}

        /// <summary>
        /// Hand property to view and set the player's hand.
        /// </summary>
        public IEnumerable<ICard> Hand {get; private set;}

        /// <summary>
        /// PlayingHand property to view and set the player's playing hand.
        /// </summary>
        /// <value></value>
        public IEnumerable<ICard> PlayingHand {get; private set;}

        /// <summary>
        /// Player constructor, called everytime a new player is created.
        /// </summary>
        /// <param name="name">Player's name</param>
        public Player(string name)
        {
            this.Name = name;
            this.Health = 10;
            this.Mana = 0;
            Deck = new List<ICard>();
            Hand = new List<ICard>();
            PlayingHand = new List<ICard>();
        }

        /// <summary>
        /// Method responsible for defining a deck to the player.
        /// </summary>
        /// <param name="deck">List of ICards that are the deck</param>
        public void DefineDeck(IEnumerable<ICard> deck)
        {
            this.Deck = deck;
        }

        /// <summary>
        /// Method responsible for defining the player's hand, removing those cards from the deck.
        /// </summary>
        /// <param name="hand">List of ICards that are the current hand</param>
        public void DefineHand(IEnumerable<ICard> hand)
        {
            this.Deck = this.Deck.Except(hand);
            this.Hand = hand;
        }

        /// <summary>
        /// Method responsible for defining the player's playing hand
        /// </summary>
        /// <param name="playingHand">New playing hand</param>
        public void DefinePlayingHand(IEnumerable<ICard> playingHand)
        {
            this.PlayingHand = playingHand;
        }

        /// <summary>
        /// Method responsible for defining the player's mana
        /// </summary>
        /// <param name="mana">New current mana</param>
        public void DefineMana(int mana)
        {
            this.Mana = mana;
        }

        /// <summary>
        /// Method responsible for using player's mana
        /// </summary>
        /// <param name="mana">Mana used</param>
        public void UseMana(int mana)
        {
            if(this.Mana >= mana)
            {
                this.Mana = this.Mana - mana;
            }
        }

        /// <summary>
        /// Method responsible for receiving mana for the player
        /// </summary>
        /// <param name="mana">Mana added</param>
        public void GetMana(int mana)
        {
            this.Mana = this.Mana + mana;
        }

        /// <summary>
        /// Method responsible for removing a card from the player's deck
        /// </summary>
        /// <param name="card">Removed card</param>
        public void RemoveCardFromDeck(ICard card)
        {
            List<ICard> updatedDeck = new List<ICard>(Deck);
            if (updatedDeck.Contains(card))
            {
                updatedDeck.Remove(card);
                Deck = updatedDeck;
            }
        }

        /// <summary>
        /// Method responsible for removing a card from the player's hand
        /// </summary>
        /// <param name="card">Removed Card</param>
        public void RemoveCardFromHand(ICard card)
        {
            List<ICard> updatedHand = new List<ICard>(Hand);
            if (updatedHand.Contains(card))
            {
                updatedHand.Remove(card);
                Hand = updatedHand;
            }
        }

        /// <summary>
        /// Method responsible for adding a card to the player's hand
        /// </summary>
        /// <param name="card">Added Card</param>
        public void AddCardToHand(ICard card)
        {
            List<ICard> updatedHand = new List<ICard>(Hand);
            updatedHand.Add(card);
            Hand = updatedHand;         
        }

        /// <summary>
        /// Method responsible for dealing damage to the player
        /// </summary>
        /// <param name="damage">Dealt damage</param>
        public void TakeDamage(int damage)
        {
            Health -= damage;
            if(Health < 0)
                Health = 0;
        }

        /// <summary>
        /// Method responsible for getting the first card from the top of the player's deck
        /// </summary>
        /// <returns>Card from the top of the player's deck</returns>
        public ICard? GetCardFromTopOfDeck()
        {
            if (Deck.Count() == 0)
            {
                return null;
            }
            ICard card = Deck.First();
            RemoveCardFromDeck(card);

            return card;
        }
    }
}