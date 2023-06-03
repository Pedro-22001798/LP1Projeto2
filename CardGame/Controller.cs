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
        bool gameOver;

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

            gameOver = false;

            do
            {
                foreach(IPlayer p in playerList)
                {
                    if(p.Health == 0)
                    {
                        gameOver = true;
                    }
                    else if(p.Deck.Count() == 0)
                    {
                        gameOver = true;
                    }
                }

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
                    playerList[i].DefinePlayingHand(SpellPhaseGame(playerList[i]));
                }

                if(gameOver)
                    break;                

                view.ShowGamePhase("Attack");

                for(int i = 0; i < playerList.Count; i++)
                {
                    AttackGamePhase(playerList[i]);
                }

                foreach (IPlayer p in playerList)
                {
                    if (view.AskForQuit(p))
                    {
                        gameOver = true;
                        break;
                    }
                }
            }
            while(!gameOver);
            //while(playerList[0].Health > 0 && playerList[1].Health > 0 && playerList[0].Deck.Count() > 0 && playerList[1].Deck.Count() > 0);
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
            List<ICard> playingHand = new List<ICard>();
            player.DefinePlayingHand(playingHand);
            playerList.Add(player);
        }

        public List<ICard> SpellPhaseGame(IPlayer player)
        {
            int option = 0;
            List<ICard> playingHand = new List<ICard>();
            view.Turn(player);
            do
            {
                view.ShowPlayerStats(player);
                option = view.ShowSpellPhaseSelection();
                if(option != 4)
                {
                    playingHand = SpellPhaseOptionTreatment(option,playingHand,player);
                }
                else if(option == 4)
                {
                    gameOver = true;
                    break;
                }
            }
            while(option != 0 && option != 4);

            return playingHand;
        }

        public void AttackGamePhase(IPlayer player)
        {
            // Eventually ask for quit here aswell
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
                    int cardIndex = view.ShowHand(player);
                    if(cardIndex < player.Hand.Count()+1 && cardIndex > 0)
                    {
                        ICard card = player.Hand.ElementAt(cardIndex-1);
                        if(card != null)
                        {
                            hand.Add(card);
                            player.UseMana(card.Cost);
                            player.RemoveCardFromHand(card);
                        }
                    }
                    break;
                case 3:
                    int cardOption = view.ShowPlayingCardsToRemove(hand);
                    if(cardOption < hand.Count()+1 && cardOption > 0)
                    {
                        ICard card = hand.ElementAt(cardOption-1);
                        if(card != null)
                        {
                            hand.Remove(card);
                            player.GetMana(card.Cost);
                            player.AddCardToHand(card);
                        }
                    }
                    break;
            }

            return hand;
        }
    }
}