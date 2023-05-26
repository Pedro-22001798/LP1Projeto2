using System;

namespace CardGame
{
    public class Program
    {
        private static void Main()
        {
            Controller controller = new Controller();

            IView view = new View(controller);

            controller.Run(view);
        }
    }
}