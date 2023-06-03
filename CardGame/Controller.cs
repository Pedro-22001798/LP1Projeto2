using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGame
{
    public class Controller
    {
        IView view;
        DeckCreator deckCreator;
        IList<IPlayer> playerList;
        int maxCard = 20;
        int initialCards = 6;
        int turn = 0;

        /// <summary>
        /// Controller constructor, called everytime a controller is created.
        /// </summary>
        /// <param name="deckCreator">Current deck creator</param>
        public Controller(DeckCreator deckCreator)
        {
            this.deckCreator = deckCreator;
            playerList = new List<IPlayer>();
        }

        /// <summary>
        /// Method responsible for starting the game loop.
        /// </summary>
        /// <param name="view">Current view responsible for visual feedback of the game loop</param>
        public void Run(IView view)
        {
            this.view = view;
            view.BeginGame();
            IEnumerable<string> playersNames = view.ListPlayers();
            foreach(string s in playersNames)
            {
                CreatePlayer(s);
            }

            do
            {
                turn++;
                if(turn < 5)
                {
                    foreach(Player p in playerList)
                        p.DefineMana(turn);
                }
                else
                {
                    foreach(Player p in playerList)
                        p.DefineMana(5);
                }

                view.ShowGamePhase("Spells");

                for(int i = 0; i < playerList.Count; i++)
                {
                    SpellPhaseGame(playerList[i]);
                }
            }
            while(playerList[0].Health > 0 && playerList[1].Health > 0 && playerList[0].Deck.Count() > 0 && playerList[1].Deck.Count() > 0);
        }

        /// <summary>
        /// Method responsible for creating a new player and also his deck and initial hand.
        /// </summary>
        /// <param name="name">Player's name</param>
        public void CreatePlayer(string name)
        {
            IPlayer player = new Player(name);
            player.DefineDeck(deckCreator.CreateRandomDeck());
            player.DefineHand(deckCreator.GetInitialHand(player.Deck));
            playerList.Add(player);
        }

        public void SpellPhaseGame(IPlayer player)
        {
            int option = 0;
            List<ICard> playingHand = new List<ICard>();
            view.Turn(player);
            do
            {
                view.ShowPlayerStats(player);
                option = view.ShowSpellPhaseSelection();
                playingHand = SpellPhaseOptionTreatment(option,playingHand,player);
            }
            while(option != 0);
        }

        public List<ICard> SpellPhaseOptionTreatment(int option, List<ICard> playingHand, IPlayer player)
        {
            List<ICard> hand = playingHand;
            switch(option)
            {
                case 1:
                    view.ShowPlayingCards(hand);
                    break;
                case 2:
                    ICard card = ChoosePlayingCards(player);
                    if(card != null)
                    {
                        hand.Add(card);
                        player.UseMana(card.Cost);
                        player.RemoveCardFromHand(card);
                    }
                    break;
            }

            return hand;
        }

        public ICard ChoosePlayingCards(IPlayer player)
        {
            int mana = player.Mana;
            ICard card = view.ShowHand(player);
            return card;
        }
    }
}