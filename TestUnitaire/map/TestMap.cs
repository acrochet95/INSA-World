using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using INSA_World;

namespace TestUnitaire.map
{
    [TestClass]
    public class TestMap
    {
        Map map;
        FactoryTile ft;

        [TestInitialize]
        public void Initialize()
        {
            ft = FactoryTile.Instance;

            BuilderStandardMap bsm = new BuilderStandardMap();
            map = bsm.buildMap();
        }

        [TestMethod]
        public void TestConstructeurPosition()
        {
            Assert.IsNotNull(map);
            Assert.AreEqual(map.GetSize(), 14);
        }

        [TestMethod]
        public void TestFillMap()
        {

        }

        [TestMethod]
        public void TestSetTileOnPosition()
        {
            ITile volcano = ft.GetTile(TileType.Volcano);
            Position pos = new Position(5, 5);
            map.SetTileOnPosition(volcano, pos);

            ITile tile = map.GetTile(pos);
            Assert.IsNotNull(tile);
            Assert.IsInstanceOfType(tile, typeof(TileVolcano));
            Assert.AreEqual(tile, volcano);
        }

        [TestMethod]
        public void TestGetTile()
        {
            ITile tile = ft.GetTile(TileType.Plain);
            Position pos = new Position(5, 5);
            map.SetTileOnPosition(tile, pos);

            Assert.IsNotNull(map.GetTile(pos));
            Assert.IsInstanceOfType(map.GetTile(pos), typeof(ITile));
            Assert.AreEqual(map.GetTile(pos), tile);

            Assert.IsNull(map.GetTile(new Position(20,20)));
        }

        [TestMethod]
        public void TestGetterWidthHeight()
        {
            Assert.AreEqual(map.GetSize(), 14);
        }
    }
}
