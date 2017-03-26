using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSA_World
{

    public abstract class BuilderMap : IBuilderMap
    {
        public Map Map { get; set; }
        protected int size;

        public int GetSize()
        {
            return size;
        }
    
        public Map buildMap()
        {
            // Fill the map with the algorithm from the dll libCPP.dll
            Algo algo = new Algo();
            algo.FillMap(Map, size);
            return Map;
        }
    }
}
