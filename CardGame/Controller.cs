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

            // do
            // {
            //     turn++;
            //     if(turn > 5)
            //     {
            //         foreach(Player p in playerList)
            //             p.Mana = turn;
            //     }
            //     else
            //     {
            //         foreach(Player p in playerList)
            //             p.Mana = 5;
            //     }

            //     for(int i = 0; i < playerList.Count; i++)
            //     {
            //         view.Turn(playerList[i]);
            //     }
            // }
            // while(playerList[0].Health > 0 && playerList[1].Health > 0 && playerList[0].GetDeck().Count() > 0 && playerList[1].GetDeck().Count() > 0);
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
    }
}