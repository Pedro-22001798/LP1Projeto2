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
        int turn;
        public Controller(DeckCreator deckCreator)
        {
            this.deckCreator = deckCreator;
            playerList = new List<IPlayer>();
        }

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
                for(int i = 0; i < playerList.Count; i++)
                {
                    view.Turn(playerList[i]);
                }
            }
            while(playerList[0].Health > 0 && playerList[1].Health > 0 && playerList[0].GetDeck().Count() > 0 && playerList[1].GetDeck().Count() > 0);
        }

        public void CreatePlayer(string name)
        {
            IPlayer player1 = new Player(name,deckCreator.CreateRandomDeck());
            playerList.Add(player1);
            IPlayer player2 = new Player(name,deckCreator.CreateRandomDeck());
            playerList.Add(player2);
        }
    }
}