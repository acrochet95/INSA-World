using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSA_World
{
    [Serializable]
    public class Map
    {
        public ITile[,] tiles { get; set; }
        public int Size { get; set; }

        public Map(int size)
        {
            this.Size = size;
            // Initialize the 2D array containing all tiles
            tiles = new ITile[Size,Size];
        }

        public void FillMap(ITile[,] tiles)
        {
            // if the size of the 2D array = size of the param
            if (tiles.GetLength(0) == Size)
            {
                if (tiles.GetLength(1) == Size)
                {
                    this.tiles = tiles;
                }
            }
        }

        public void SetTileOnPosition(ITile tile, Position position)
        {
            // If the position exists in the 2D array
            if (position.X >= 0 && position.X < tiles.GetLength(0) && position.Y >= 0 && position.Y < tiles.GetLength(1))
                tiles[position.X, position.Y] = tile;
        }

        public ITile GetTile(Position position)
        {
            // If the position exists in the 2D array, return the tile, else return null
            if (position.X >= 0 && position.X < tiles.GetLength(0) && position.Y >= 0 && position.Y < tiles.GetLength(1))
                return tiles[position.X, position.Y];

            return null;
        }

        public int GetSize()
        {
            // return the size of the map
            return this.Size;
        }
    }
}