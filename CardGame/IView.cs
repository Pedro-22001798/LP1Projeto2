using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGame
{
    public interface IView
    {
        void BeginGame();
        IEnumerable<string> ListPlayers();
        void Turn(IPlayer player);
    }
}