using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSA_World
{
    public class Player
    {
        private String name;

        public Player(string name)
        {
            throw new System.NotImplementedException();
        }

        public List<Unit> Units
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public int Score
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public void addUnit(Unit unit)
        {
            throw new System.NotImplementedException();
        }

        public List<Unit> getAllUnitsOnPosition(Position position)
        {
            throw new System.NotImplementedException();
        }

        public Unit deleteUnit()
        {
            throw new System.NotImplementedException();
        }

        public void placeUnits(Position positionMax, List<Unit> units = null)
        {
            throw new System.NotImplementedException();
        }
    }
}
