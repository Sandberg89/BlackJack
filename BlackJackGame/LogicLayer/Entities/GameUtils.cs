using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.Entities
{
    /// <summary>
    /// Main focus of this class is to start the game off 
    /// </summary>
    public class GameUtils
    {
        List<Player> players = new List<Player>();
        Deck deck;
        Player dealer;

        public List<Player> Players {
            get { return players; }
        }

        public Player Dealer
        {
            get { return dealer; }
        }

        public GameUtils()
        {
            dealer = new Player();
        }

        /// <summary>
        /// Add the amount of players that is wanted
        /// </summary>
        /// <param name="amountOfPlayers"></param>
        public void AddPlayers(int amountOfPlayers)
        {
            for (int i = 0; i < amountOfPlayers; i++)
            {
                players.Add(new Player());
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
            dealer.PlayerHand.AddCard(deck);
        }

        public void ArePlayersThick()
        {
            foreach (var player in players)
            {
                if(player.PlayerHand.Score > 21)
                {
                    player.IsThick = true;
                }
                else
                {
                    player.IsThick = false;
                }
            }

            if(dealer.PlayerHand.Score > 21)
            {
                dealer.IsThick = true;
            }
            else
            {
                dealer.IsThick = false;
            }
        }

        public void PlayerDrawCard(Player player)
        {
            player.PlayerHand.AddCard(deck);
        }
    }
}
