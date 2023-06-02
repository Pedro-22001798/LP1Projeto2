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
        int ShowHand(IEnumerable<ICard> hand, int mana);
        void ShowGamePhase(string phase);
        void ShowFirstOption();
        void ShowPlayingCards(IEnumerable<ICard> playingcards);
    }
}