// Name: Linus Sandberg. Date: 2020-09-20. Project: Black Jack Game Assignment 1
using LogicLayer.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.Entities
{
    /// <summary>
    /// Class for the card
    /// </summary>
    public class Card
    {
        public CardValue CardValue { get; set; }
        public SuitType CardSuite { get; set; }

        /// <summary>
        /// Constructor with a card value and suit
        /// </summary>
        /// <param name="value"></param>
        /// <param name="suit"></param>
        public Card(CardValue value, SuitType suit)
        {
            this.CardValue = value;
            this.CardSuite = suit;
        }

        /// <summary>
        /// Override ToString to print out the value and suit
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return CardValue + " " + CardSuite;
        }
    }
}
