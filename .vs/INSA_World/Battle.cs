using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSA_World
{
    public class Battle
    {
        private Unit attacker;
        private Unit defenderSelected;
        private boolean severalDefendersOnTile;

        public Battle(Unit attacker, List<Unit> defenders)
        {
            foreach (int units in defenders)
            {
                if (units.X ==  )
            }
            throw new System.NotImplementedException();
        }

        public BattleConsequences battleConsequences
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void compute()
        {
            
            throw new System.NotImplementedException();
        }

        public void consequences(Unit winner, Unit loser, int lost_points, bool attackerWon)
        {
            throw new System.NotImplementedException();
        }
    }
}