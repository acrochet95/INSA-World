using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSA_World
{
    [Serializable]
    public class Move : ICommand
    {
        public Unit UnitToMove { get; set; }
        public Position Coord { get; set; }
        public int Mp_cost { get; set; }

        public Move(Unit unitToMove, Position newCoord, int moveP_cost)
        {
            this.UnitToMove = unitToMove;
            this.Coord = newCoord;
            this.Mp_cost = moveP_cost;
        }

        public void Execute()
        {
            Position unitPos = UnitToMove.Position;
            // Deplace l'unité vers la nouvelle pos
            UnitToMove.Move(Coord.X - unitPos.X, Coord.Y - unitPos.Y, Mp_cost);

            // Set the Passive value = false so the unit won't heal
            UnitToMove.Passive = false;
        }

        public void Replay()
        {
            this.Execute();
        }
    }
}