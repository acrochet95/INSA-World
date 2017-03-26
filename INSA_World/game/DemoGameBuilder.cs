using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSA_World
{
    public class DemoGameBuilder : BuilderGame
    {
        public DemoGameBuilder()
        {
            this.Nb_turns = 5;
            this.Nb_units = 4;
        }

        new public Game buildGame()
        {
            game = new Game();
            game.Turns = Nb_turns;
            game.Nb_units = Nb_units;

            // Build the game
            BuilderDemoMap builderMap = new BuilderDemoMap();
            game.Map = builderMap.buildMap();

            return game;
        }
    }
}