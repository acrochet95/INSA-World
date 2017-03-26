using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSA_World
{
    public enum TileType
    {
        Plain = 0,
        Desert = 1,
        Volcano = 2,
        Swamp = 3
    }

    public class FactoryTile
    {
        private static FactoryTile instance;
        public Dictionary<TileType, ITile> ITiles { get; set; }

        private FactoryTile()
        {
            // Intialize the dictionary containing all tiles
            ITiles = new Dictionary<TileType, ITile>();
            ITiles.Add(TileType.Plain, new TilePlain());
            ITiles.Add(TileType.Desert, new TileDesert());
            ITiles.Add(TileType.Volcano, new TileVolcano());
            ITiles.Add(TileType.Swamp, new TileSwamp());
        }

        public static FactoryTile Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new FactoryTile();
                }
                
                return instance;
            }
        }

        // Get the tile
        public ITile GetTile(TileType keyTile)
        {
            ITile it = null;
            // Check if keyTile exists, if yes "it" contains the value, else return null
            if (!ITiles.TryGetValue(keyTile, out it))
            {
                return null;
            }

            return it;
        }
    }
}