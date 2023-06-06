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

            Console.Clear();
        }

        public int ShowHand(IPlayer player)
        {
            ShowPlayerStats(player);
            IEnumerable<ICard> hand = player.Hand;
            int index = 1;
            foreach(ICard c in hand)
            {
                Console.WriteLine($"{index} : {c.Name} - Attack = {c.Attack}, Defense = {c.Defense} and Cost = {c.Cost}.");
                index++;
            }
            Console.WriteLine($"{index} : Leave.");
            Console.WriteLine("What card do you want to choose?");

            int option;
            bool isValidOption = false;
            do
            {
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid option. Please choose a valid index.");
                }
                else if (option < 1 || option > hand.Count() + 1)
                {
                    Console.WriteLine($"Invalid option. Please choose from 1 to {hand.Count() + 1}.");
                }
                else if(option != index)
                {
                    if(hand.ElementAt(option-1).Cost > player.Mana)
                    {
                        Console.WriteLine("Invalid option. You don't have enought mana.");
                    }
                    else
                    {
                        isValidOption = true;
                    }
                }
                else
                {
                    isValidOption = true;
                }
            }
            while (!isValidOption);

            Console.Clear();

            return option;
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
            Console.WriteLine("3 - Remove cards from table");
            Console.WriteLine("4 - Get card from deck.");
            Console.WriteLine("5 - Surrender");

            int option;
            bool isValidOption = false;

            do
            {
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid option. Please choose a valid number.");
                }
                else if (option < 0 || option > 5)
                {
                    Console.WriteLine("Invalid option. Please choose from 0 to 4.");
                }
                else
                {
                    isValidOption = true;
                }
            }
            while (!isValidOption);

            Console.Clear();

            return option;
        }

        public bool AskForSurrender(IPlayer player)
        {
            string input;
            bool isValidInput = false;

            do
            {
                Console.WriteLine($"{player.Name}, are you sure you want to surrender? Yes/No");

                input = Console.ReadLine()?.Trim().ToLower();

                if (input == "yes")
                {
                    return true;
                }
                else if (input == "no")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid input! Please enter 'Yes' or 'No'.");
                }
            }
            while (!isValidInput);

            return false;
        }


        public int ShowPlayingCardsToRemove(IEnumerable<ICard> playingcards)
        {
            Console.WriteLine("Playing Hand:");
            int index = 1;
            foreach(ICard c in playingcards)
            {
                Console.WriteLine($"{index} = {c.Name}, Cost = {c.Cost}, Attack {c.Attack}, Defense {c.Defense}.");
                index++;
            }
            Console.WriteLine($"{index} = Leave.");
            Console.WriteLine("Which one do you want to remove?");

            int option;
            bool isValidOption = false;
            do
            {
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid option. Please choose a valid number.");
                }
                else if (option < 1 || option > playingcards.Count()+1)
                {
                    Console.WriteLine($"Invalid option. Please choose from 0 to {playingcards.Count()+1}.");
                }
                else
                {
                    isValidOption = true;
                }
            }
            while (!isValidOption);

            Console.Clear();

            return option;
        }

        public void CantGetCardFromDeck(bool deck)
        {
            if(!deck)
                Console.WriteLine("Can't get a card from your deck. Your deck has 0 cards.");
            else
                Console.WriteLine("Can't get any more cards from your deck. Your hand already has 6.");
        }
    }
}