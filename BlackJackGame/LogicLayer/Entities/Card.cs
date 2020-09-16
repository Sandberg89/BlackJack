using LogicLayer.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.Entities
{
    public class Card
    {
        public CardValue CardValue { get; set; }
        public SuitType CardSuite { get; set; }


        public Card(CardValue value, SuitType suit)
        {
            this.CardValue = value;
            this.CardSuite = suit;
        }

        public Card()
        {
        }

        public override string ToString()
        {
            return CardValue + " " + CardSuite;
        }
    }
}
