using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSA_World
{
    public interface IBuilderMap
    {
        void buildPlainTiles();
        void buildDesertTiles();
        void buildVolcanoTiles();
        void buildSwampTiles();
        void buildMap();

        Map map { get; }
    }
}