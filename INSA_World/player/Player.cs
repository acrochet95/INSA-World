using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSA_World
{
    [Serializable]
    public class Player
    {
        public String Name { get; set; }
        public List<Unit> Units { get; set; }
        public int Score { get; set; }

        public Player(string name)
        {
            // Initialize attributs
            this.Name = name;
            this.Score = 0;
            this.Units = new List<Unit>();
        }

        public Race GetRace()
        {
            // Get the race of the player if units exists, else return null
            if (this.Units.Count > 0)
                return this.Units[0].Race;

            return null;
        }

        public void AddUnit(Unit unit)
        {
            // Add unit to the list Units
            this.Units.Add(unit);
        }

        public List<Unit> GetAllUnitsOnPosition(Position position)
        {
            // Initialize the list of units
            List<Unit> all_units = new List<Unit>();
            foreach (Unit unit in Units)
            {
                // if the unit is on position position, add it to the list
                if (unit.Position.X == position.X && unit.Position.Y == position.Y && unit.Life > 0)
                    all_units.Add(unit);
            }

            // return the list
            return all_units;
        }

        public void PlaceUnits(Position position)
        {
            // for each units, set the position = position
            foreach (Unit unit in Units)
            {
                unit.Position = new Position(position.X, position.Y);
            }
        }
    }
}
