// Name: Linus Sandberg. Date: 2020-09-20. Project: Black Jack Game Assignment 1
using LogicLayer.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicLayer.Entities
{
    /// <summary>
    /// Class for creating the deck
    /// </summary>
    public class Deck
    {
        private List<Card> myDeck;

        /// <summary>
        /// Property for how many decks are used
        /// </summary>
        public int NumberOfDecks { get; set; }

        /// <summary>
        /// A list with all the cards
        /// </summary>
        public List<Card> MyDeck { get { return myDeck; } }

        /// <summary>
        /// Constructor for the deck
        /// </summary>
        /// <param name="decks"></param>
        public Deck(int decks)
        {
            this.myDeck = new List<Card>();
            this.NumberOfDecks = decks;
        }

        //This method will create a deck with 52 cards times numberOfDecks 
        public void InitializeDeck()
        {
            
            foreach (SuitType cardSuit in Enum.GetValues(typeof(SuitType)))
            {
                for (int i = 1; i <= NumberOfDecks; i++)
                {
                    for (int value = 1; value <= 13; value++)
                    {
                        CardValue cardVal= (CardValue)value;

                        Card card = new Card(cardVal, cardSuit);

                        myDeck.Add(card);
                    }
                }
            }
        }

        /// <summary>
        /// Check how many cards are left in the deck
        /// </summary>
        /// <returns></returns>
        public int CardsLeftInDeck()
        {
            return MyDeck.Count;
        }
        /// <summary>
        ///  Shuffle the card in the deck by using a random GUID
        /// </summary>
        public void Shuffle()
        {
            myDeck = myDeck.OrderBy(i => Guid.NewGuid()).ToList();
        }


        /// <summary>
        /// Draw the card on the top of the list. Since it's shuffled we will get a random card 
        /// </summary>
        /// <returns></returns>
        public Card DrawNextCard()
        {
            Card topCardInDeck = myDeck[0];
            myDeck.RemoveAt(0);
            return topCardInDeck;
        }

    }
}
