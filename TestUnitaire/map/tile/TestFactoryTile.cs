using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using INSA_World;

namespace TestUnitaire
{
    [TestClass]
    public class TestFactoryTile
    {
        FactoryTile ft;

        [TestInitialize]
        public void Initialize()
        {
            ft = FactoryTile.Instance;
        }

        [TestMethod]
        public void TestConstructeurTestFactoryTile()
        {
            Assert.IsNotNull(ft);
        }

        [TestMethod]
        public void TestGetTile()
        {
            Assert.IsInstanceOfType(ft.GetTile(TileType.Plain), typeof(TilePlain));
            Assert.IsInstanceOfType(ft.GetTile(TileType.Desert), typeof(TileDesert));
            Assert.IsInstanceOfType(ft.GetTile(TileType.Volcano), typeof(TileVolcano));
            Assert.IsInstanceOfType(ft.GetTile(TileType.Swamp), typeof(TileSwamp));
        }
    }
}
