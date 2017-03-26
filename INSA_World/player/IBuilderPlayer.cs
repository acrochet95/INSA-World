using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSA_World
{
    public interface IBuilderPlayer
    {
        Player buildPlayer(string name, Race race, int nb_units);
    }
}