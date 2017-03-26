using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSA_World
{
    public class BuilderSmallMap : BuilderMap
    {

        public BuilderSmallMap()
        {
            size = 10;
            // Initialize the map with the size size
            Map = new Map(size);
        }
    }
}
