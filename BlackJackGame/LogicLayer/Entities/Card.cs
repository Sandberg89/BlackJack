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


        public Card(int value, SuitType suit)
        {
            this.CardValue = CardValue;
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
