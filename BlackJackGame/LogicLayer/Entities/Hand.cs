using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.Entities
{
    public class Hand
    {
        private List<Card> hand = new List<Card>();
        // Look into if there is a better way 
        private Card _card;

        public Hand()
        {
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
                    totalScore += (int)card.CardValue;
                }
                return totalScore;
            }
        }
        /// <summary>
        /// Draw a new card to your hand
        /// </summary>
        public void AddCard(Deck deck)
        {
            hand.Add(deck.DrawNextCard());
        }

        /// <summary>
        /// Empty your hand of cards 
        /// </summary>
        public void ClearHand()
        {
            hand.Clear();
        }

        public override string ToString()
        {
            if (hand.Count > 0)
            {
                string cardsOnHand = "";
                foreach (Card card in hand)
                {
                    cardsOnHand += card.ToString() + "\n";
                }

                return cardsOnHand;
            }

            return "No cards on hand";
            
        }
    }
}
