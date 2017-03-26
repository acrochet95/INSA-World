using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSA_World
{
    [Serializable]
    public abstract class Race
    {
        protected int LIFE_POINTS;
        protected int ATTACK_POINTS;
        protected int DEF_POINTS;

        public int GetLife_Points() { return LIFE_POINTS; }
        public int GetAttack_Points() { return ATTACK_POINTS; }
        public int GetDef_Points() { return DEF_POINTS; }

        // Return the victory points according to the tile
        abstract public int VictoryPointsOn(ITile tile);
    }
}
