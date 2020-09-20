using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.Entities
{
    public class Hand
    {
        private List<Card> hand = new List<Card>();

        /// <summary>
        /// Parameterless constructor for hand
        /// </summary>
        public Hand()
        {
        }

        //return the amount of cards the player have 
        public int NumberOfCards 
        { 
            get 
            {
                return hand.Count;
            } 
        }
        /// <summary>
        /// retrieve total score of hand 
        /// </summary>
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

        /// <summary>
        /// Method that prints the card hand and overrride ToString
        /// </summary>
        /// <returns></returns>
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
