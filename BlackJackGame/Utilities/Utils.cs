using LogicLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities
{
    public class Utils
    {
        private List<Player> players = new List<Player>();
        private Deck deck;
        private Player dealer;
        private int blackJackScore = 21;

        /// <summary>
        /// List of all the players that are playing
        /// </summary>
        public List<Player> Players
        {
            get { return players; }
        }


        public Deck Deck
        {
            get { return deck; }
        }

        /// <summary>
        /// Property for a dealer
        /// </summary>
        public Player Dealer
        {
            get { return dealer; }
        }

        /// <summary>
        /// Create a dealer that always have id of 0
        /// </summary>
        public Utils()
        {
            dealer = new Player(0);
        }

        /// <summary>
        /// Add the amount of players that is wanted
        /// </summary>
        /// <param name="amountOfPlayers"></param>
        public void AddPlayers(int amountOfPlayers)
        {
            for (int i = 0; i < amountOfPlayers; i++)
            {
                players.Add(new Player(i + 1));

            }
        }

        /// <summary>
        /// Create a new deck with the amount of decks needed
        /// </summary>
        /// <param name="decksToBeAdded"></param>
        public void CreateDeck(int decksToBeAdded)
        {
            deck = new Deck(decksToBeAdded);
            deck.InitializeDeck();
            deck.Shuffle();
        }

        /// <summary>
        /// Method for reshuffling the deck
        /// </summary>
        public void ReshuffleDeck()
        {
            deck.Shuffle();
        }

        /// <summary>
        /// Give all the players and the dealer a starting hand 
        /// </summary>
        public void PlayerStartHand()
        {
            foreach (Player player in players)
            {
                player.PlayerHand.AddCard(deck);
                player.PlayerHand.AddCard(deck);
            }

            dealer.PlayerHand.AddCard(deck);
        }

        /// <summary>
        /// Method that checks if the players are thick
        /// </summary>
        public void ArePlayersThick()
        {
            foreach (var player in players)
            {
                if (player.PlayerHand.Score > blackJackScore)
                {
                    player.IsThick = true;
                    player.IsFinished = true;
                }
                else
                {
                    player.IsThick = false;
                }
            }
        }

        /// <summary>
        /// Method that checks if the dealer is thick
        /// </summary>
        public void IsDealerThick()
        {
            if (dealer.PlayerHand.Score > blackJackScore)
            {
                dealer.IsThick = true;
                dealer.IsFinished = true;
            }
            else
            {
                dealer.IsThick = false;
            }
        }

        /// <summary>
        /// Draw a card for player
        /// </summary>
        /// <param name="player"></param>
        public void PlayerDrawCard(Player player)
        {
            if (deck.MyDeck.Count > 1)
            {
                player.PlayerHand.AddCard(deck);
            }
            else
            {
                deck.InitializeDeck();
            }
        }

        /// <summary>
        /// Checks and controls if all the players have stayed and assigne a second card to dealer 
        /// </summary>
        /// <returns></returns>
        public bool AllPlayersDone()
        {
            foreach (var player in players)
            {
                if (!player.IsFinished)
                {
                    return false;
                }
            }

            dealer.PlayerHand.AddCard(deck);
            return true;
        }

        /// <summary>
        /// Dealer draw a card
        /// </summary>
        public void DealerDrawCard()
        {
            PlayerDrawCard(dealer);
        }

        /// <summary>
        /// Check who have won this round
        /// </summary>
        /// <returns></returns>
        public string EvaluateWhoWon()
        {
            string winner = "";
            int countWinners = 0;
            foreach (var player in players)
            {
                if (!player.IsThick)
                {
                    if (player.PlayerHand.Score > dealer.PlayerHand.Score || dealer.IsThick)
                    {
                        winner += "Player " + player.PlayerId.ToString() + "\n";
                        countWinners += 1;
                    }
                }
            }

            if (countWinners == 0)
            {
                winner += "Dealer won!";
            }

            return winner;
        }

        /// <summary>
        /// Clear dealer and player hands 
        /// </summary>
        public void ResetRound()
        {
            dealer.PlayerHand.ClearHand();
            dealer.IsThick = false;
            dealer.IsFinished = false;
            foreach (var player in players)
            {
                player.PlayerHand.ClearHand();
                player.IsThick = false;
                player.IsFinished = false;
            }
        }

        /// <summary>
        /// Check how many cards are left
        /// </summary>
        /// <returns></returns>
        public bool DeckLessThanOneFourth()
        {
            int cardsleft = deck.CardsLeftInDeck();
            if (cardsleft < (52 * deck.NumberOfDecks / 4))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}