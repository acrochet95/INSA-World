using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSA_World
{
    public class PlayerBuilder : IBuilderPlayer
    {
        public PlayerBuilder()
        {

        }
    
        public Player buildPlayer(string name, Race race, int nb_units)
        {
            // Initialize the player
            Player player = new Player(name);

            // Create the unit factory with the Race = race
            UnitFactory uf = new UnitFactory(race);

            // Create all nb_units units and add units to the player
            for (int i = 0; i < nb_units; i++)
                player.AddUnit(uf.createUnit());

            // return the player
            return player;
        }
    }
}