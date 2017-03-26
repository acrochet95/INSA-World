using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSA_World
{
    public abstract class BuilderGame
    {
        protected Game game;
        public int Nb_turns { get; protected set; }
        public int Nb_units { get; protected set; }

        public Game buildGame()
        {
            throw new System.NotImplementedException();
        }
    }
}
