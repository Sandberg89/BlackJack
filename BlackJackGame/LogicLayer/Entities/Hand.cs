using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.Entities
{
    public class Hand
    {
        private List<Card> hand = new List<Card>();
        // Look into if there is a better way 
        Deck newDeck;
        private Card _card;

        public Hand()
        {
            this.newDeck = new Deck(1);
            newDeck.InitializeDeck();
            newDeck.Shuffle();
            this._card = new Card();
        }

        //return the amount of cards the player have 
        public int NumberOfCards 
        { 
            get 
            {
                return hand.Count;
            } 
        }

        //retrieve total score of hand 
        public int Score
        {
            get
            {
                int totalScore = 0;
                foreach (Card card in hand)
                {
                    totalScore += card.CardValue;
                }
                return totalScore;
            }
        }
        /// <summary>
        /// Draw a new card to your hand
        /// </summary>
        public void AddCard()
        {
            hand.Add(newDeck.DrawNextCard());
        }

        /// <summary>
        /// Empty your hand of cards 
        /// </summary>
        public void ClearHand()
        {
            hand.Clear();
        }
    }
}
