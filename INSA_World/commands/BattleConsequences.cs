using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSA_World
{
    [Serializable]
    public class BattleConsequences
    {

        public bool MoveAttacker { get; set; }
        public int Lost_points { get; set; }
        public int MovePointsCostForAttacker { get; set; }

        public Unit Winner { get; set; }
        public Unit Loser { get; set; }

        public BattleConsequences(Unit winner, Unit loser, int lost_points, bool moveAttacker, int movePointsCostForAttacker)
        {
            this.Winner = winner;
            this.Loser = loser;
            this.Lost_points = lost_points;
            this.MoveAttacker = moveAttacker;
            this.MovePointsCostForAttacker = movePointsCostForAttacker;
        }

        public void Execute()
        {
            // if the defender died
            if (Loser.Attacked(Lost_points))
            {
                if (MoveAttacker)
                {
                    Move move = new Move(Winner, Loser.Position, MovePointsCostForAttacker);
                    CommandManager.Instance.StoreAndExecute(move);
                }

                //Game.DeleteUnit(Loser);
            }
            else
            {
                Winner.Move(0, 0, MovePointsCostForAttacker);
            }
        }
    }
}
