using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSA_World
{
    public abstract class Race
    {
        protected int LIFE_POINTS;
        protected int ATTACK_POINTS;
        protected int DEF_POINTS;
        protected int MOVE_POINTS;

        public Race(int attack, int defence, int life)
        {
            MOVE_POINTS = 3;
            ATTACK_POINTS = attack;
            DEF_POINTS = defence;
            LIFE_POINTS = life;
            throw new System.NotImplementedException();
        }
    }
}
