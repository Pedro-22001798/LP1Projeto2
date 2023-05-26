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
    }
}