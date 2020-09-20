using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.Entities
{
    /// <summary>
    /// Player class that implement the interface Iplayer
    /// </summary>
    public class Player : EventArgs, IPlayer 
    {
        private Hand hand;

        public Player()
        {
        }

        /// <summary>
        /// Constructor that set a hand for the player and expect an ID
        /// </summary>
        /// <param name="id"></param>
        public Player(int id)
        {
            this.hand = new Hand();
            this.PlayerId = id;
        }

        /// <summary>
        /// Identifier for the player
        /// </summary>
        public int PlayerId { get; set; }

        /// <summary>
        /// Hand that contain the player cards
        /// </summary>
        public Hand PlayerHand { get { return hand; } set { hand = value; } }

        /// <summary>
        /// Set to true if the player is finished 
        /// </summary>
        public bool IsFinished { get; set; }

        /// <summary>
        /// Set to true if the player is over the limit 
        /// </summary>
        public bool IsThick 
        {
            get; set;
        }
    }
}
