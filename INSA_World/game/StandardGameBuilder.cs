using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSA_World
{
    public class StandardGameBuilder : BuilderGame
    {
        public StandardGameBuilder()
        {
            this.Nb_turns = 30;
            this.Nb_units = 8;
        }
    
        new public Game buildGame()
        {
            game = new Game();
            game.Turns = Nb_turns;
            game.Nb_units = Nb_units;

            // Build the game
            BuilderStandardMap builderMap = new BuilderStandardMap();
            game.Map = builderMap.buildMap();

            return game;
        }
    }
}