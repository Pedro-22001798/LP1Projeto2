using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGame
{
    public class DeckCreator
    {
        int initialHand = 6;
        public IEnumerable<ICard> CreateDeck()
        {
            for(int i = 0; i < 4; i++)
            {
                ICard flyingWand = new Card("Flying Wand", 1, 1, 1);
                yield return flyingWand;
            }
            for(int i = 0; i < 4; i++)
            {
                ICard severedMonkeyHead = new Card("Severed Monkey Head", 1, 2, 1);
                yield return severedMonkeyHead;
            }
            for(int i = 0; i < 2; i++)
            {
                ICard mysticalRockWall = new Card("Mystical Rock Wall", 2, 0, 5);
                yield return mysticalRockWall;
            }
            for(int i = 0; i < 2; i++)
            {
                ICard lobsterMcCrabs = new Card("Lobster McCrabs", 2, 1, 3);
                yield return lobsterMcCrabs;
            }
            for(int i = 0; i < 2; i++)
            {
                ICard goblinTroll = new Card("Goblin Troll", 3, 3, 2);
                yield return goblinTroll;
            }
            for(int i = 0; i < 1; i++)
            {
                ICard scorchingHeatwave = new Card("Scorching Heatwave", 4, 5, 3);
                yield return scorchingHeatwave;
            }
            for(int i = 0; i < 1; i++)
            {
                ICard blindMinotaur = new Card("Blind Minotaur", 3, 1, 3);
                yield return blindMinotaur;
            }
            for(int i = 0; i < 1; i++)
            {
                ICard timWizard = new Card("Tim, The Wizard", 5, 6, 4);
                yield return timWizard;
            }
            for(int i = 0; i < 1; i++)
            {
                ICard sharplyDepressed = new Card("Sharply Depressed", 4, 3, 3);
                yield return sharplyDepressed;
            }
            for(int i = 0; i < 2; i++)
            {
                ICard blueSteel = new Card("Blue Steel", 2, 2, 2);
                yield return blueSteel;
            }
        }

        public IEnumerable<ICard> CreateRandomDeck()
        {
            IEnumerable<ICard> deck = new List<Card>();
            deck = CreateDeck();
            Random rng = new Random();
            var shuffledCards = deck.OrderBy(a => rng.Next()).ToList();
            return shuffledCards;
        }

        public IEnumerable<ICard> GetInitialHand(IEnumerable<ICard> deck)
        {
            Random rnd = new Random();
            List<ICard> hand = deck.OrderBy(x => rnd.Next()).Take(initialHand).ToList();
            return hand;
        }   
    }
}