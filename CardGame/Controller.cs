using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGame
{
    public class Controller
    {
        IView view;
        public Controller()
        {
            
        }

        public void Run(IView view)
        {
            this.view = view;
        }
    }
}