using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace INSA_World
{
    public class Algo : IDisposable
    {
        bool disposed = false;
        IntPtr nativeAlgo;

        public Algo()
        {
            nativeAlgo = Algo_new();
        }

        ~Algo()
        {
            Dispose(false);
            Algo_delete(nativeAlgo);
        }

        public void FillMap(Map map, int size)
        {

            TileType[] tiles = new TileType[size * size];
            Algo_fillMap(nativeAlgo, tiles, size * size);

            for (int i = 0; i < size * size; i++)
            {
                Console.WriteLine((i / size) + " ; " + (i % size) + " " + tiles[i]);
                map.SetTileOnPosition(FactoryTile.Instance.GetTile(tiles[i]), new Position(i / size, i % size));
            }
            //var tiles = new TileType[nbTiles];
            //Algo_fillMap(nativeAlgo, tiles, nbTiles);
            
        }

        public void PositionUnits(Player p1, Player p2, int size)
        {

            int[] positions = new int[4];
            Algo_positionUnits(nativeAlgo, positions, size);

            p1.PlaceUnits(new Position(positions[0], positions[1]));
            p2.PlaceUnits(new Position(positions[2], positions[3]));

        }
        
        public void PossibleMoves(Unit unit, Map map)
        {
            TileType[] tiles = new TileType[map.Size*map.Size];

            int[] positions = Algo_possibleMoves(nativeAlgo, tiles, "Cerberus", 2,2,3.0, map.Size);

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                Algo_delete(nativeAlgo);
            }
            disposed = true;
        }

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void Algo_fillMap(IntPtr algo, TileType[] tiles, int nbTiles);

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void Algo_positionUnits(IntPtr algo, int[] positions, int size);

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int[] Algo_possibleMoves(IntPtr algo, TileType[] map, String race, int x, int y, double movept, int sizemap);

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr Algo_new();

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr Algo_delete(IntPtr algo);
    }
}
