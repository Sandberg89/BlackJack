using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.Entities
{
    /// <summary>
    /// Interface for player with properties
    /// </summary>
    public interface IPlayer
    {
        int PlayerId
        {
            get;
            set;
        }

        Hand PlayerHand
        {
            get;
            set;
        }

        bool IsFinished
        {
            get;
            set;
        }

        bool IsThick
        {
            get;
            set;
        }
    }
}
