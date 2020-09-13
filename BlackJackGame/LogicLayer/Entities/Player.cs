using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.Entities
{
    public class Player
    {

        public Hand PlayerHand { get; set; }

        public bool IsFinished { get; set; }


        public bool IsThick 
        { 
            get; 
            set; 
        }

    }
}
