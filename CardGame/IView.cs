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
        void ShowGamePhase(string phase);
        void ShowPlayingCards(IEnumerable<ICard> playingcards);
        void ShowPlayerStats(IPlayer player);
        int ShowSpellPhaseSelection();
        int ShowHand(IPlayer player);
        bool AskForSurrender(IPlayer player);
        int ShowPlayingCardsToRemove(IEnumerable<ICard> playingcards);
        void CantGetCardFromDeck(bool deck);
    }
}