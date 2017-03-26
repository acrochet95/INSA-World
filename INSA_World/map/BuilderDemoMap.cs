using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSA_World
{
    public class BuilderDemoMap : BuilderMap
    {
        public BuilderDemoMap()
        {
            size = 6;
            // Initialize the map with the size size
            Map = new Map(size);
        }
    }
}
