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

            // TEMP TO REMOVE JUST TO TEST
            Console.WriteLine("Fase de feitiços!");
            Console.WriteLine($"{playerList[0].Name} é o teu turno. Que cartas queres jogar?");
            int index = 1;
            foreach(ICard c in playerList[0].Hand)
            {
                Console.WriteLine($"{index} = {c.Name}, Cost = {c.Cost}, Attack = {c.Attack}, Defense = {c.Defense}");
                index++;
            }
            int choice = Convert.ToInt32(Console.ReadLine());
            ICard p1Card = playerList[0].Hand.ElementAt(choice-1);
            

            Console.WriteLine($"{playerList[1].Name} é o teu turno. Que cartas queres jogar?");
            index = 1;
            foreach(ICard c in playerList[1].Hand)
            {
                Console.WriteLine($"{index} = {c.Name}, Cost = {c.Cost}, Attack = {c.Attack}, Defense = {c.Defense}");
                index++;
            }
            choice = Convert.ToInt32(Console.ReadLine());
            ICard p2Card = playerList[1].Hand.ElementAt(choice-1);
            

            if(p1Card.Attack > p2Card.Defense)
                Console.WriteLine($"{p1Card.Name} wins!");
            else
                Console.WriteLine($"{p2Card.Name} resists!");
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