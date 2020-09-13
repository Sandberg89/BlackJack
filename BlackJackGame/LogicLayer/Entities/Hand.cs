using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.Entities
{
    public class Hand
    {
        private List<Card> hand = new List<Card>();
        // Look into if there is a better way 
        Deck newDeck = new Deck(1);

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

        public void AddCard()
        {
            Card cardToAdd = newDeck.Draw();
        }
    }
}
