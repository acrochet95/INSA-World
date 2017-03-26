using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSA_World
{
    [Serializable]
    public class Cyclop : Race
    {
        // Initialize the INSTANCE
        public static Cyclop INSTANCE = new Cyclop();

        private Cyclop()
        {
            ATTACK_POINTS = 4;
            DEF_POINTS = 6;
            LIFE_POINTS = 12;
        }

        override public int VictoryPointsOn(ITile tile)
        {
            if (tile is TilePlain)
                return 2;
            if (tile is TileDesert)
                return 3;
            if (tile is TileVolcano)
                return 1;
            if (tile is TileSwamp)
                return 0;

            return 0;
        }
    }
}
