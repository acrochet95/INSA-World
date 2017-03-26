using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSA_World
{
    public class Engine
    {
        public Game Game { get; set; }
        public static Random rnd = new Random();

        private bool turnOver;

        public Engine()
        {
            
        }

        public Engine(string fileName)
        {
            CommandManager cm = CommandManager.Instance;
            Game = cm.Load(fileName);
        }


        public void Initialize(string map, string namePlayer1, string race_p1, string namePlayer2, string race_p2)
        {
            // Initialize a game
            turnOver = false;

            if (map.Equals("demo"))
            {
                DemoGameBuilder demoGame = new DemoGameBuilder();
                Game = demoGame.buildGame();
            }
            else if (map.Equals("small"))
            {
                SmallGameBuilder demoGame = new SmallGameBuilder();
                Game = demoGame.buildGame();
            }
            else
            {
                StandardGameBuilder demoGame = new StandardGameBuilder();
                Game = demoGame.buildGame();
            }

            Race r1 = null;
            if (race_p1.Equals("Cyclope"))
                r1 = Cyclop.INSTANCE;
            else if (race_p1.Equals("Centaure"))
                r1 = Centaur.INSTANCE;
            else
                r1 = Cerberus.INSTANCE;

            Race r2 = null;
            if (race_p2.Equals("Cyclope"))
                r2 = Cyclop.INSTANCE;
            else if (race_p2.Equals("Centaure"))
                r2 = Centaur.INSTANCE;
            else
                r2 = Cerberus.INSTANCE;

            // Create players
            PlayerBuilder pb = new PlayerBuilder();
            Player player1 = pb.buildPlayer(namePlayer1, r1, Game.Nb_units);
            Player player2 = pb.buildPlayer(namePlayer2, r2, Game.Nb_units);

            // Add players to the game
            Game.AddPlayers(player1, player2);

            // Choose the player who 'll start first
            if (rnd.Next(0, 2) == 0)
                Game.currentPlayer = player1;
            else
                Game.currentPlayer = player2;
        }

        public Player EndTurn()
        {
            if (turnOver)
            {
                // Decrease turns when both players played 1 turn
                Game.Turns--;
                turnOver = false;
            }
            else
                turnOver = true;

            // Compute victory points for each players
            Game.ComputeVictoryPoints();

            foreach (Unit unit in Game.currentPlayer.Units)
            {
                // Heal the unit of the currentPlayer if passive
                if (unit.Passive)
                {
                    unit.Heal();
                }
                else
                    unit.Passive = true;

                // Refresh move points
                unit.RefreshMovePoints();
            }

            // Change the current player
            if (Game.currentPlayer == Game.Player1)
                Game.currentPlayer = Game.Player2;
            else
                Game.currentPlayer = Game.Player1;
            
            Player winner = Game.CheckVictory();
                if (winner != null)
                    return winner;

            return null;
        }
    }
}
