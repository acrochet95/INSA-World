using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSA_World
{
    public class BuilderStandardMap : BuilderMap
    {

        public BuilderStandardMap()
        {
            size = 14;
            // Initialize the map with the size size
            Map = new Map(size);
        }
    }
}
