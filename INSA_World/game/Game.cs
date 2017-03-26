using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSA_World
{
    [Serializable]
    public class Game
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public Map Map { get; set; }
        public int Turns { get; set; }
        public int Nb_units { get; set; }

        public Player currentPlayer { get; set; }

        public Game()
        {
            
        }

        // Check if a player wins
        // Return the player who wins if exists
        public Player CheckVictory()
        {
            // If all units of player2 died, player1 wins
            if (Player1.Units.Count > 0 && Player2.Units.Count == 0)
                return Player1;

            // If all units of player1 died, player2 wins
            if (Player2.Units.Count > 0 && Player1.Units.Count == 0)
                return Player2;

            // If the game is finished return the player with the biggest victory points
            if (Turns == 0)
            {
                if (Player1.Score > Player2.Score)
                    return Player1;
                else if (Player2.Score > Player1.Score)
                    return Player2;
                else
                    return Player1;
            }

            // if the game isn't finished, return null
            return null;
        }

        public void ComputeVictoryPoints()
        {
            int pointsP1 = 0;
            List<Position> positionsP1 = new List<Position>();

            // Player 1
            foreach (Unit unit in Player1.Units)
            {
                if (positionsP1.Find(x => (x.X == unit.Position.X && x.Y == unit.Position.Y)) == null)
                {
                    pointsP1 += Player1.GetRace().VictoryPointsOn(Map.GetTile(unit.Position));
                    positionsP1.Add(unit.Position);
                }
            }
            Player1.Score = pointsP1;

            int pointsP2 = 0;
            List<Position> positionsP2 = new List<Position>();

            // Player 2
            foreach (Unit unit in Player2.Units)
            {
                if (positionsP2.Find(x => (x.X == unit.Position.X && x.Y == unit.Position.Y)) == null)
                {
                    pointsP2 += Player2.GetRace().VictoryPointsOn(Map.GetTile(unit.Position));
                    positionsP2.Add(unit.Position);
                }
            }
            Player2.Score = pointsP2;
        }

        public bool AddPlayers(Player player1, Player player2)
        {
            if(player1.GetRace() != player2.GetRace())
            {
                Player1 = player1;
                Player2 = player2;

                // Place units
                Algo algo = new Algo();
                algo.PositionUnits(Player1,Player2, Map.Size);
                return true;
            }

            return false;
        }
    }
}
