using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSA_World
{
    public class Centaur : Race
    {
        private Centaur INSTANCE;

        private Centaur() : base( 8, 2, 10)
        {
            throw new System.NotImplementedException();
        }
    }
}
