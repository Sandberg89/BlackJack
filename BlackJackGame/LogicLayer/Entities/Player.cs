using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.Entities
{
    public class Player
    {
        private bool isFinished = false;

        public bool IsFinished { get; set; }

        public List<Card> playerCards { get; set; }

        public bool IsThick 
        { 
            get; 
            set; 
        }

    }
}
