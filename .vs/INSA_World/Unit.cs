using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSA_World
{
    public class Unit
    {
        private int life;
        private int moves;

        public Unit()
        {
            throw new System.NotImplementedException();
        }

        public Race Race
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public bool Passive
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public Position Position
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void move(int vx, int vy)
        {
            throw new System.NotImplementedException();
        }

        public void heal()
        {
            throw new System.NotImplementedException();
        }

        public void refreshMovePoints()
        {
            throw new System.NotImplementedException();
        }

        public Boolean canPerformAction()
        {
            throw new System.NotImplementedException();
        }

        public bool attacked(int life_points_lost)
        {
            throw new System.NotImplementedException();
        }
    }
}