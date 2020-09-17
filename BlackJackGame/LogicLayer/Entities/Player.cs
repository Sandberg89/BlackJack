using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.Entities
{
    public class Player
    {
        private Hand hand;

        public Player()
        {
            this.hand = new Hand();
        }

        public Hand PlayerHand { get { return hand; } set { hand = value; } }

        public bool IsFinished { get; set; }


        public bool IsThick 
        {
            get; set;
        }
    }
}
