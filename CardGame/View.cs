using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGame
{
    public class View : IView
    {
        Controller controller;
        public View(Controller controller)
        {
            this.controller = controller;
        }

        public void BeginGame()
        {
            Console.WriteLine("Hello! Welcome to Tragic: The Reckoning card game");
        }

        public IEnumerable<string> ListPlayers()
        {
            Console.WriteLine("What's the name of player 1?");
            string name1 = Console.ReadLine();
            yield return name1;
            Console.WriteLine("What's the name of player 2");
            string name2 = Console.ReadLine();
            yield return name2;
            yield break;
        }

        public void Turn(IPlayer player)
        {
            Console.WriteLine($"It's {player.Name}'s turn.");
        }

        public void ShowPlayerInformation(IPlayer player)
        {

        }
    }
}