using System;

namespace CardGame
{
    public class Program
    {
        private static void Main()
        {
            DeckCreator deckCreator = new DeckCreator();

            Controller controller = new Controller(deckCreator);

            IView view = new View(controller);

            controller.Run(view);
        }
    }
}