using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.Entities
{
    /// <summary>
    /// Interface for player with properties for the player
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// property for playerId
        /// </summary>
        int PlayerId
        {
            get;
            set;
        }

        /// <summary>
        /// property for playerhand
        /// </summary>
        Hand PlayerHand
        {
            get;
            set;
        }

        /// <summary>
        /// Property for if the player is done
        /// </summary>
        bool IsFinished
        {
            get;
            set;
        }

        /// <summary>
        /// Property for if the player isThick
        /// </summary>
        bool IsThick
        {
            get;
            set;
        }
    }
}
