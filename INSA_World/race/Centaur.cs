using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSA_World
{
    [Serializable]
    public class Centaur : Race
    {
        // Initialize the INSTANCE
        public static Centaur INSTANCE = new Centaur();

        private Centaur()
        {
            ATTACK_POINTS = 8;
            DEF_POINTS = 2;
            LIFE_POINTS = 10;
        }

        override public int VictoryPointsOn(ITile tile)
        {
            if (tile is TilePlain)
                return 3;
            if (tile is TileDesert)
                return 2;
            if (tile is TileVolcano)
                return 0;
            if (tile is TileSwamp)
                return 1;

            return 0;
        }
    }
}
