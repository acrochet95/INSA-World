using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSA_World
{
    public interface IStrategyMap
    {
        Map Map { get; set; }

        void buildMap();
    }
}