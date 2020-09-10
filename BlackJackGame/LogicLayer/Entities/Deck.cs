using LogicLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicLayer.Entities
{
    public class Deck
    {
        private List<Card> myDeck = new List<Card>();

        public int NumberOfDecks { get; set; }

        public List<Card> MyDeck { get { return myDeck; } }

        public Deck(int decks)
        {
            this.NumberOfDecks = decks;
        }

        //This method will create a deck with 52 cards times numberOfDecks 
        public void Shuffle()
        {
            //Create the deck 
            foreach (SuitType cardSuit in Enum.GetValues(typeof(SuitType)))
            {
                for (int i = 1; i <= NumberOfDecks; i++)
                {
                    for (int value = 2; value <= 14; value++)
                    {
                        Card card = new Card(value, cardSuit);
                        myDeck.Add(card);
                    }
                }

            }
        }

        //Draw a random card from the deck
        public Card Draw()
        {
            Random randomCard = new Random();
            int index = randomCard.Next(myDeck.Count);
            return myDeck[index];
        }

    }
}
