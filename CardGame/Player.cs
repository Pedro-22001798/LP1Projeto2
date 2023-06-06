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

        public void DefinePlayingHand(IEnumerable<ICard> playingHand)
        {
            this.PlayingHand = playingHand;
        }

        public void DefineMana(int mana)
        {
            this.Mana = mana;
        }

        public void UseMana(int mana)
        {
            if(this.Mana >= mana)
            {
                this.Mana = this.Mana - mana;
            }
        }

        public void GetMana(int mana)
        {
            this.Mana = this.Mana + mana;
        }

        public void RemoveCardFromDeck(ICard card)
        {
            List<ICard> updatedDeck = new List<ICard>(Deck);
            if (updatedDeck.Contains(card))
            {
                updatedDeck.Remove(card);
                Deck = updatedDeck;
            }
        }

        public void RemoveCardFromHand(ICard card)
        {
            List<ICard> updatedHand = new List<ICard>(Hand);
            if (updatedHand.Contains(card))
            {
                updatedHand.Remove(card);
                Hand = updatedHand;
            }
        }

        public void AddCardToHand(ICard card)
        {
            List<ICard> updatedHand = new List<ICard>(Hand);
            updatedHand.Add(card);
            Hand = updatedHand;         
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if(Health < 0)
                Health = 0;
        }

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