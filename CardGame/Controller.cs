using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGame
{
    public class Controller
    {
        IView view;
        IEnumerable<Player> playerList;
        int maxCard = 20;
        public Controller()
        {
            playerList = new List<Player>();
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
        }

        public void CreatePlayer(string name)
        {
            Player player1 = new Player(name,);
            playerList.Add(player1);
            Player player2 = new Player(name,);
            playerList.Add(player2);
        }

        public IEnumerable<Card> CreateRandomDeck()
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
        }
    }
}