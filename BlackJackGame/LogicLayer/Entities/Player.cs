using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.Entities
{
    public class Player : EventArgs
    {
        private Hand hand;

        public Player()
        {
        }

        public Player(int id)
        {
            this.hand = new Hand();
            this.PlayerId = id;
        }

        public int PlayerId { get; set; }

        public Hand PlayerHand { get { return hand; } set { hand = value; } }

        public bool IsFinished { get; set; }


        public bool IsThick 
        {
            get; set;
        }
    }
}
