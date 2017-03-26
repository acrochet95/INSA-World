using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSA_World
{
    [Serializable]
    public class Cerberus : Race
    {
        // Initialize the INSTANCE
        public static Cerberus INSTANCE = new Cerberus();

        private Cerberus()
        {
            ATTACK_POINTS = 6;
            DEF_POINTS = 4;
            LIFE_POINTS = 10;
        }

        override public int VictoryPointsOn(ITile tile)
        {
            if(tile is TilePlain)
                return 0;
            if (tile is TileDesert)
                return 1;
            if (tile is TileVolcano)
                return 2;
            if (tile is TileSwamp)
                return 3;

            return 0;
        }
    }
}
