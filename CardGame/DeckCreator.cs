using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGame
{
    public class DeckCreator
    {
        /// <summary>
        /// Amount of initial cards to be chosen
        /// </summary>
        private int initialHand = 6;

        /// <summary>
        /// Method responsible for creating the deck with custom cards.
        /// </summary>
        /// <returns>List of cards created</returns>
        public IEnumerable<Card> CreateDeck()
        {
            for(int i = 0; i < 4; i++)
            {
                Card flyingWand = new Card("Flying Wand", 1, 1, 1);
                yield return flyingWand;
            }
            for(int i = 0; i < 4; i++)
            {
                Card severedMonkeyHead = new Card("Severed Monkey Head", 1, 2, 1);
                yield return severedMonkeyHead;
            }
            for(int i = 0; i < 2; i++)
            {
                Card mysticalRockWall = new Card("Mystical Rock Wall", 2, 0, 5);
                yield return mysticalRockWall;
            }
            for(int i = 0; i < 2; i++)
            {
                Card lobsterMcCrabs = new Card("Lobster McCrabs", 2, 1, 3);
                yield return lobsterMcCrabs;
            }
            for(int i = 0; i < 2; i++)
            {
                Card goblinTroll = new Card("Goblin Troll", 3, 3, 2);
                yield return goblinTroll;
            }
            for(int i = 0; i < 1; i++)
            {
                Card scorchingHeatwave = new Card("Scorching Heatwave", 4, 5, 3);
                yield return scorchingHeatwave;
            }
            for(int i = 0; i < 1; i++)
            {
                Card blindMinotaur = new Card("Blind Minotaur", 3, 1, 3);
                yield return blindMinotaur;
            }
            for(int i = 0; i < 1; i++)
            {
                Card timWizard = new Card("Tim, The Wizard", 5, 6, 4);
                yield return timWizard;
            }
            for(int i = 0; i < 1; i++)
            {
                Card sharplyDepressed = new Card("Sharply Depressed", 4, 3, 3);
                yield return sharplyDepressed;
            }
            for(int i = 0; i < 2; i++)
            {
                Card blueSteel = new Card("Blue Steel", 2, 2, 2);
                yield return blueSteel;
            }
        }

        /// <summary>
        /// Method responsible for making the created deck random.
        /// </summary>
        /// <returns>List of cards, now randomly placed</returns>
        public IEnumerable<ICard> CreateRandomDeck()
        {
            IEnumerable<ICard> deck = new List<Card>();
            deck = CreateDeck();
            Random rng = new Random();
            var shuffledCards = deck.OrderBy(a => rng.Next()).ToList();
            return shuffledCards;
        }

        /// <summary>
        /// Method responsible for dealing the initial hand of (default) 6 cards.
        /// </summary>
        /// <param name="deck">Deck where the cards will come from</param>
        /// <returns>List of cards for the initial hand</returns>
        public IEnumerable<ICard> GetInitialHand(IEnumerable<ICard> deck)
        {
            Random rnd = new Random();
            List<ICard> hand = deck.OrderBy(x => rnd.Next()).Take(initialHand).ToList();
            return hand;
        }   
    }
}