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

        public int ShowHand(IEnumerable<ICard> hand, int mana)
        {
            ShowFirstOption();
            int index = 1;
            int tempMana = mana;
            foreach(ICard c in hand)
            {
                Console.WriteLine($"{index} = {c.Name}, Cost = {c.Cost}, Attack {c.Attack}, Defense {c.Defense}");
                index++;
            }
            int option = Convert.ToInt32(Console.ReadLine());
            while(option > hand.Count() || option < 0 || hand.ElementAt(option).Cost > tempMana)
            {
                Console.WriteLine("Invalid option. Choose another one.");
                option = Convert.ToInt32(Console.ReadLine());    
            }
            tempMana = tempMana - hand.ElementAt(option).Cost;
            return option;
        }

        public void ShowFirstOption()
        {
            Console.WriteLine("0 = End Turn");
        }

        public void ShowPlayingCards(IEnumerable<ICard> playingcards)
        {
            Console.WriteLine("Playing Hand:");
            int index = 1;
            foreach(ICard c in playingcards)
            {
                Console.WriteLine($"{index} = {c.Name}, Cost = {c.Cost}, Attack {c.Attack}, Defense {c.Defense}");
                index++;
            }
        }
    }
}