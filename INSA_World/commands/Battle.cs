using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSA_World
{
    [Serializable]
    public class Battle
    {
        private static Random rnd = new Random();
        public bool SeveralDefendersOnTile { get; set; }
        public int MovePointsCostForAttacker { get; set; }

        public Unit Attacker { get; set; }
        public Unit DefenderSelected { get; set; }
        public BattleConsequences BattleConsequences { get; set; }

        public Battle(Unit attacker, List<Unit> defenders, int movePointsCostForAttacker)
        {
            this.Attacker = attacker;
            this.MovePointsCostForAttacker = movePointsCostForAttacker;

            // Set the Passive value = false so the unit won't heal
            Attacker.Passive = false;

            // Choose the best defender
            SeveralDefendersOnTile = defenders.Count > 1;
            foreach (Unit defender in defenders)
            {
                if (DefenderSelected == null || defender.GetDefencePoints() > DefenderSelected.GetDefencePoints())
                    DefenderSelected = defender;
            }
        }

        public void Compute()
        {
            Unit winner = null;
            Unit loser = null;

            float attack_points_attacker = Attacker.GetAttackPoints();
            float defence_points_defender = DefenderSelected.GetDefencePoints();

            float proba_attacker_wins = 100 - (float)100 / (float)((attack_points_attacker / defence_points_defender) + 1);

            int value = rnd.Next(0, 101); // Random integer from 0 to 100

            if(value >= 0 && value <= proba_attacker_wins) // attacker wins
            {
                winner = Attacker;
                loser = DefenderSelected;
            }
            else // defender wins
            {
                winner = DefenderSelected;
                loser = Attacker;
            }

            int lost_lifePoints = rnd.Next(1, 9); // Random integer from 1 to 8
            bool moveAttacker = winner == Attacker && !SeveralDefendersOnTile;

            // consequences
            this.Consequences(winner, loser, lost_lifePoints, moveAttacker, MovePointsCostForAttacker);

        }

        private void Consequences(Unit winner, Unit loser, int lost_points, bool moveAttacker, int movePointsCostForAttacker)
        {
            BattleConsequences = new BattleConsequences(winner, loser, lost_points, moveAttacker, movePointsCostForAttacker);
            BattleConsequences.Execute();
        }
    }
}