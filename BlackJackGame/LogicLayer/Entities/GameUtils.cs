using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.Entities
{
    /// <summary>
    /// Main focus of this class is to start the game off 
    /// </summary>
    public class GameUtils : EventArgs
    {
        List<Player> players = new List<Player>();
        Deck deck;
        Player dealer;
        int blackJackScore = 21;

        public List<Player> Players {
            get { return players; }
        }

        public Player Dealer
        {
            get { return dealer; }
        }

        /// <summary>
        /// Create a dealer that always have id of 0
        /// </summary>
        public GameUtils()
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
            foreach(Player player in players)
            {
                player.PlayerHand.AddCard(deck);
                player.PlayerHand.AddCard(deck);
            }

            dealer.PlayerHand.AddCard(deck);
        }

        public void ArePlayersThick()
        {
            foreach (var player in players)
            {
                if(player.PlayerHand.Score > blackJackScore)
                {
                    player.IsThick = true;
                    player.IsFinished = true;
                }
                else
                {
                    player.IsThick = false;
                }
            }

            if(dealer.PlayerHand.Score > blackJackScore)
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
            if(deck.MyDeck.Count > 1)
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
            foreach(var player in players)
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
            dealer.PlayerHand.AddCard(deck);
        }

        public string EvaluateWhoWon()
        {
            string winner = "";
            int countWinners = 0;
            foreach(var player in players)
            {
                if (!player.IsThick)
                {
                    if(player.PlayerHand.Score > dealer.PlayerHand.Score || dealer.IsThick)
                    {
                        winner += "Player " + player.PlayerId.ToString() + "\n";
                        countWinners += 1;
                    }
                }
            }

            if(countWinners == 0)
            {
                winner += "Dealer won!";
            }

            return winner;
        }

        }
    }

