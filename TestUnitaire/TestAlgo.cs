using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using INSA_World;

namespace TestUnitaire
{
    [TestClass]
    public class TestAlgo
    {
        Algo algo;

        [TestInitialize]
        public void Initialize()
        {
            algo = new Algo();
        }

        [TestMethod]
        public void TestConstructeurAlgo()
        {
            Assert.IsNotNull(algo);
        }

        [TestMethod]
        public void TestFillMap()
        {
            BuilderSmallMap bsm = new BuilderSmallMap();
            Map map = bsm.buildMap();

            algo.FillMap(map, map.Size);

            int nbTilesDiff = map.Size*map.Size / 4;
            int nbPlain = 0;
            int nbDesert = 0;
            int nbVolcano = 0;
            int nbSwamp = 0;
            for (int i = 0; i < map.Size; i++)
            {
                for (int j = 0; j < map.Size; j++)
                {
                    if (map.tiles[i, j] is TilePlain)
                        nbPlain++;
                    else if (map.tiles[i, j] is TileDesert)
                        nbDesert++;
                    else if (map.tiles[i, j] is TileVolcano)
                        nbVolcano++;
                    else
                        nbSwamp++;
                }
            }

            Assert.AreEqual(nbPlain, nbTilesDiff);
            Assert.AreEqual(nbDesert, nbTilesDiff);
            Assert.AreEqual(nbVolcano, nbTilesDiff);
            Assert.AreEqual(nbSwamp, nbTilesDiff);
        }

        [TestMethod]
        public void TestPositionUnits()
        {
            BuilderSmallMap bsm = new BuilderSmallMap();
            Map map = bsm.buildMap();

            PlayerBuilder pb = new PlayerBuilder();
            Player p1 = pb.buildPlayer("name1", Cerberus.INSTANCE, 6);
            Player p2 = pb.buildPlayer("name2", Centaur.INSTANCE, 6);

            algo.PositionUnits(p1, p2, 6);

            Assert.IsFalse(p1.Units[0].Position.X == p2.Units[0].Position.X && p1.Units[0].Position.Y == p2.Units[0].Position.Y);


        }
    }
}
