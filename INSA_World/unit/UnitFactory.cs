using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSA_World
{
    public class UnitFactory : IUnitFactory
    {
        public Race Race { get; set; }

        public UnitFactory(Race race)
        {
            // Attribute the race to the unit factory
            this.Race = race;
        }

        public Unit createUnit()
        {
            // Initialize the unit with the race Race
            Unit unit = new Unit(this.Race);
            
            return unit;
        }
    }
}