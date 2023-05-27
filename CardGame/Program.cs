using System;

namespace CardGame
{
    public class Program
    {
        private static void Main()
        {
            /// <summary>
            /// Creation of a Deck Creator, responsible for creating and shuffling the deck.
            /// </summary>
            DeckCreator deckCreator = new DeckCreator();

            /// <summary>
            /// Creation of a controller that receives the Deck Creator. Responsible for the game engine.
            /// </summary>
            Controller controller = new Controller(deckCreator);

            /// <summary>
            /// Creation of the view that received the Controller. Responsible for any type of visual feedback from the controller.
            /// </summary>
            IView view = new View(controller);

            // Runs the game.
            controller.Run(view);
        }
    }
}