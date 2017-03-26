using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSA_World
{
    public class SmallGameBuilder : BuilderGame
    {
        public SmallGameBuilder()
        {
            this.Nb_turns = 20;
            this.Nb_units = 6;
        }
    
        new public Game buildGame()
        {
            game = new Game();
            game.Turns = Nb_turns;
            game.Nb_units = Nb_units;

            // Build the game
            BuilderSmallMap builderMap = new BuilderSmallMap();
            game.Map = builderMap.buildMap();

            return game;
        }
    }
}