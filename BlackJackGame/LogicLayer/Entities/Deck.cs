using LogicLayer.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicLayer.Entities
{
    public class Deck
    {
        private List<Card> myDeck;

        public int NumberOfDecks { get; set; }

        public List<Card> MyDeck { get { return myDeck; } }

        public Deck(int decks)
        {
            this.myDeck = new List<Card>();
            this.NumberOfDecks = 1;
        }

        //This method will create a deck with 52 cards times numberOfDecks 
        public void InitializeDeck()
        {
            //Create the deck 
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

        // Shuffle the card in the deck by using a random GUID
        public void Shuffle()
        {
            myDeck = myDeck.OrderBy(i => Guid.NewGuid()).ToList();
        }

        //Draw the card on the top of the list. Since it's shuffled we will get a random card 
        public Card DrawNextCard()
        {
            Card topCardInDeck = myDeck[0];
            myDeck.RemoveAt(0);
            return topCardInDeck;
        }

    }
}
