using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSA_World
{
    public abstract class BuilderGame
    {
        private Game game;

        public Game buildGame()
        {
            throw new System.NotImplementedException();
        }

        void BuildMap();
        void BuildPlayer1();
        void BuildPlayer2();

        Game game { get; }
    }
}
