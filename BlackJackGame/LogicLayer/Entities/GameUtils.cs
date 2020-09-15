using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.Entities
{
    /// <summary>
    /// Main focus of this class is to start the game off 
    /// </summary>
    public class GameUtils
    {
        List<Player> players = new List<Player>();

        public void AddPlayers(int amountOfPlayers)
        {
            for (int i = 0; i < amountOfPlayers; i++)
            {
                players.Add(new Player());
            }
        }

        public void StartHand()
        {

        }
    }
}
