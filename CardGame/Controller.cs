using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGame
{
    public class Controller
    {
        IView view;
        DeckCreator deckCreator;
        IList<IPlayer> playerList;
        int turn = 0;
        bool gameOver;

        /// <summary>
        /// Controller constructor, called everytime a controller is created.
        /// </summary>
        /// <param name="deckCreator">Current deck creator</param>
        public Controller(DeckCreator deckCreator)
        {
            this.deckCreator = deckCreator;
            playerList = new List<IPlayer>();
        }

        /// <summary>
        /// Method responsible for starting the game loop.
        /// </summary>
        /// <param name="view">Current view responsible for visual feedback of the game loop</param>
        public void Run(IView view)
        {
            this.view = view;
            view.BeginGame();
            IEnumerable<string> playersNames = view.ListPlayers();
            foreach(string s in playersNames)
            {
                CreatePlayer(s);
            }

            gameOver = false;

            do
            {
                foreach(IPlayer p in playerList)
                {
                    if(p.Health == 0)
                    {
                        gameOver = true;
                    }
                    else if(p.Deck.Count() == 0)
                    {
                        gameOver = true;
                    }
                }

                turn++;
                if(turn < 5)
                {
                    foreach(Player p in playerList)
                        p.DefineMana(turn);
                }
                else
                {
                    foreach(Player p in playerList)
                        p.DefineMana(5);
                }

                view.ShowGamePhase("Spells");

                for(int i = 0; i < playerList.Count; i++)
                {
                    playerList[i].DefinePlayingHand(SpellPhaseGame(playerList[i]));
                }

                if(gameOver)
                    break;                

                view.ShowGamePhase("Attack");

                AttackGamePhase();

                
            }
            while(!gameOver);
            //while(playerList[0].Health > 0 && playerList[1].Health > 0 && playerList[0].Deck.Count() > 0 && playerList[1].Deck.Count() > 0);
        }

        /// <summary>
        /// Method responsible for creating a new player and also his deck and initial hand.
        /// </summary>
        /// <param name="name">Player's name</param>
        public void CreatePlayer(string name)
        {
            IPlayer player = new Player(name);
            player.DefineDeck(deckCreator.CreateRandomDeck());
            player.DefineHand(deckCreator.GetInitialHand(player.Deck));
            List<ICard> playingHand = new List<ICard>();
            player.DefinePlayingHand(playingHand);
            playerList.Add(player);
        }

        public List<ICard> SpellPhaseGame(IPlayer player)
        {
            int option = 0;
            List<ICard> playingHand = new List<ICard>();
            view.Turn(player);
            do
            {
                view.ShowPlayerStats(player);
                option = view.ShowSpellPhaseSelection();
                if(option != 5)
                {
                    playingHand = SpellPhaseOptionTreatment(option,playingHand,player);
                }
                else if(option == 5)
                {
                    if (view.AskForSurrender(player))
                    {
                        gameOver = true;
                        break;
                    }
                    else
                    {
                        view.Turn(player);
                        int selectedOption = view.ShowSpellPhaseSelection();
                    }
                }
            }
            while(option != 0 && option != 5);

            return playingHand;
        }

        public void AttackGamePhase()
        {
            List<ICard> player1PlayingHand = playerList[0].PlayingHand.ToList();
            List<ICard> player2PlayingHand = playerList[1].PlayingHand.ToList();

            while (player1PlayingHand.Any() && player2PlayingHand.Any())
            {
                ICard player1Card = player1PlayingHand.First();
                ICard player2Card = player2PlayingHand.First();

                if(player1Card.ExtraAttack > 0)
                {
                    player2Card.TakeDamage(player1Card.ExtraAttack);   
                }
                else
                {
                    player2Card.TakeDamage(player1Card.Attack);
                }
                if(player2Card.ExtraAttack > 0)
                {
                    player1Card.TakeDamage(player2Card.ExtraAttack);
                }
                else
                {
                    player1Card.TakeDamage(player2Card.Attack);
                }

                if(player1Card.Defense <= 0)
                {
                    player1Card.SetExtraAttack(0);
                    if(player1Card.Defense < 0)
                    {
                        player2Card.SetExtraAttack(-player1Card.Defense);
                    }
                    player1PlayingHand.RemoveAt(0);
                }

                if(player2Card.Defense <= 0)
                {
                    player2Card.SetExtraAttack(0);
                    if(player2Card.Defense < 0)
                    {
                        player1Card.SetExtraAttack(-player2Card.Defense);
                    }
                    player2PlayingHand.RemoveAt(0);   
                }
            }

            if (player1PlayingHand.Any())
            {
                foreach(ICard c in player1PlayingHand.ToList())
                {
                    if(c.ExtraAttack > 0)
                    {
                        playerList[1].TakeDamage(c.ExtraAttack);
                        c.SetExtraAttack(0);
                    }
                    else
                    {
                        playerList[1].TakeDamage(c.Attack);
                        player1PlayingHand.RemoveAt(0);
                    }
                }
            }

            if (player2PlayingHand.Any())
            {
                foreach(ICard c in player2PlayingHand.ToList())
                {
                    if(c.ExtraAttack > 0)
                    {
                        playerList[0].TakeDamage(c.ExtraAttack);
                        c.SetExtraAttack(0);
                    }
                    else
                    {
                        playerList[0].TakeDamage(c.Attack);
                        player2PlayingHand.RemoveAt(0);
                    }
                }
            }            

            player1PlayingHand.Clear();
            player2PlayingHand.Clear();

            foreach (IPlayer p in playerList)
            {
                view.ShowPlayerStats(p);
            }
        }

        public List<ICard> SpellPhaseOptionTreatment(int option, List<ICard> playingHand, IPlayer player)
        {
            List<ICard> hand = playingHand;
            switch(option)
            {
                case 1:
                    view.ShowPlayingCards(hand);
                    break;
                case 2:
                    int cardIndex = view.ShowHand(player);
                    if(cardIndex < player.Hand.Count()+1 && cardIndex > 0)
                    {
                        ICard card = player.Hand.ElementAt(cardIndex-1);
                        if(card != null)
                        {
                            hand.Add(card);
                            player.UseMana(card.Cost);
                            player.RemoveCardFromHand(card);
                        }
                    }
                    break;
                case 3:
                    int cardOption = view.ShowPlayingCardsToRemove(hand);
                    if(cardOption < hand.Count()+1 && cardOption > 0)
                    {
                        ICard card = hand.ElementAt(cardOption-1);
                        if(card != null)
                        {
                            hand.Remove(card);
                            player.GetMana(card.Cost);
                            player.AddCardToHand(card);
                        }
                    }
                    break;
                case 4:
                    if(player.Hand.Count() + hand.Count() < 6 && player.Deck.Count() > 0)
                    {
                        ICard card = player.GetCardFromTopOfDeck();
                        if(card != null)
                        {
                            player.AddCardToHand(card);
                        }
                    }
                    else
                    {
                        if(player.Hand.Count() + hand.Count() == 6)
                            view.CantGetCardFromDeck(true);
                        if(player.Deck.Count() == 0)
                            view.CantGetCardFromDeck(false);
                    }
                    break;
            }

            return hand;
        }
    }
}