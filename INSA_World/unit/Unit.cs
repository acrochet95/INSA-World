using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSA_World
{
    [Serializable]
    public class Unit
    {
        private const int MOVE_POINTS = 3;

        public int Life { get; set; }
        public float Moves { get; set; }
        public Race Race { get; set; }
        public Position Position { get; set; }
        public bool Passive { get; set; }

        public Unit(Race race)
        {
            this.Race = race;
            this.Passive = true;
            this.Position = new Position(0, 0);
            Life = race.GetLife_Points();
            Moves = MOVE_POINTS;
        }

        // Move the unit and update move points
        public void Move(int vx, int vy, int movePointsCost)
        {
            // if the unit has enough move points to move
            if (this.Moves - movePointsCost >= 0)
            {
                this.Position.X += vx;
                this.Position.Y += vy;
                this.Moves -= movePointsCost;
            }
        }

        // Heal a unit
        public void Heal()
        {
            // heal the unit if it took damages
            if(this.Life + 1 <= Race.GetLife_Points())
                this.Life += 1;
        }

        // Refresh move points
        public void RefreshMovePoints()
        {
            this.Moves = MOVE_POINTS;
        }

        // Check if the unit can move or attack
        // Return true if yes
        public bool CanPerformAction()
        {
            return this.Moves > 0;
        }

        // If a unit took damges from an attack
        // Return true if the unit died
        public bool Attacked(int life_points_lost)
        {
            // Decrease the life points
            this.Life -= life_points_lost;
            if (this.Life < 0)
                this.Life = 0;

            return this.Life == 0;
        }

        // Return weighted attack points 
        public float GetAttackPoints()
        {
            return (Race.GetAttack_Points() * ((float)Life / (float)Race.GetLife_Points()));
        }

        // Return weighted defence points 
        public float GetDefencePoints()
        {
            return (Race.GetDef_Points() * ((float)Life / (float)Race.GetLife_Points()));
        }
    }
}