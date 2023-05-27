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

            foreach(IPlayer p in playerList)
            {
                Console.WriteLine($"{p.Name}'s deck has {p.Deck.Count()}");
                foreach(ICard c in p.Hand)
                {
                    Console.WriteLine($"CARD = {c.Name} with {c.Attack} attack and {c.Cost} cost and {c.Defense} defense.");
                }
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

        public void CreatePlayer(string name)
        {
            IPlayer player = new Player(name);
            player.DefineDeck(deckCreator.CreateRandomDeck());
            player.DefineHand(deckCreator.GetInitialHand(player.Deck));
            playerList.Add(player);
        }
    }
}