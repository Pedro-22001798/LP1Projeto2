using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGame
{
    public class View : IView
    {
        Controller controller;

        /// <summary>
        /// View constructor, called when creating a new view.
        /// </summary>
        /// <param name="controller">Game Engine</param>
        public View(Controller controller)
        {
            this.controller = controller;
        }

        /// <summary>
        /// Method responsible for greeting the player once starting the game.
        /// </summary>
        public void BeginGame()
        {
            Console.WriteLine("Hello! Welcome to Tragic: The Reckoning card game");
        }

        /// <summary>
        /// Method responsible for listing the players and their names.
        /// </summary>
        /// <returns>List of strings with the players names</returns>
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

        /// <summary>
        /// Method responsible for informing the players of a turn change.
        /// </summary>
        /// <param name="player">Player that is now playing</param>
        public void Turn(IPlayer player)
        {
            Console.WriteLine($"It's {player.Name}'s turn.");
        }

        public void ShowPlayerInformation(IPlayer player)
        {

        }

        public void ShowGamePhase(string phase)
        {
            switch(phase)
            {
                case "Attack":
                    Console.WriteLine("It's the attack stage!");
                    break;
                case "Spells":
                    Console.WriteLine("It's the spell stage!");
                    break;
            }
        }

        public void ShowPlayingCards(IEnumerable<ICard> playingcards)
        {
            Console.WriteLine("Playing Hand:");
            int index = 1;
            foreach(ICard c in playingcards)
            {
                Console.WriteLine($"{index} = {c.Name}, Cost = {c.Cost}, Attack {c.Attack}, Defense {c.Defense}.");
                index++;
            }
        }

        public ICard ShowHand(IPlayer player)
        {
            IEnumerable<ICard> hand = player.Hand;
            int index = 1;
            foreach(ICard c in hand)
            {
                Console.WriteLine($"{index} : {c.Name} - Attack = {c.Attack}, Defense = {c.Defense} and Cost = {c.Cost}.");
                index++;
            }
            Console.WriteLine("What card do you want to choose?");

            int option;
            bool isValidOption = false;
            do
            {
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid option. Please choose a valid index.");
                }
                else if (option < 0 || option > hand.Count())
                {
                    Console.WriteLine($"Invalid option. Please choose from 0 to {hand.Count()}.");
                }
                else if(hand.ElementAt(option-1).Cost > player.Mana)
                {
                    Console.WriteLine("Invalid option. You don't have enought mana.");
                }
                else
                {
                    isValidOption = true;
                }
            }
            while (!isValidOption);

            return hand.ElementAt(option-1);
        }

        public void ShowPlayerStats(IPlayer player)
        {
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine($"{player.Name} stats -> Health = {player.Health}, Mana = {player.Mana}");
            Console.WriteLine("----------------------------------------------------------------------------");
        }

        public int ShowSpellPhaseSelection()
        {
            Console.WriteLine("0 - End turn.");
            Console.WriteLine("1 - View current cards on table.");
            Console.WriteLine("2 - Choose more cards");

            int option;
            bool isValidOption = false;

            do
            {
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid option. Please choose a valid number.");
                }
                else if (option < 0 || option > 2)
                {
                    Console.WriteLine("Invalid option. Please choose from 0 to 2.");
                }
                else
                {
                    isValidOption = true;
                }
            }
            while (!isValidOption);

            return option;
        }
    }
}