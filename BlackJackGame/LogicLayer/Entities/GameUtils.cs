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

        public void ReshuffleDeck()
        {
            deck.Shuffle();
        }
    }
}
