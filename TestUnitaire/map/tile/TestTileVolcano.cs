using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using INSA_World;

namespace TestUnitaire
{
    [TestClass]
    public class TestTileVolcano
    {
        TileVolcano volcano;

        [TestInitialize]
        public void Initialize()
        {
            volcano = new TileVolcano();
        }

        [TestMethod]
        public void TestConstructeurTileDesert()
        {
            Assert.IsInstanceOfType(volcano, typeof(TileVolcano));
        }
    }
}
