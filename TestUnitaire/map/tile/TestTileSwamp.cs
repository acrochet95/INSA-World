using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using INSA_World;

namespace TestUnitaire
{
    [TestClass]
    public class TestTileSwamp
    {
        TileSwamp swamp;

        [TestInitialize]
        public void Initialize()
        {
            swamp = new TileSwamp();
        }

        [TestMethod]
        public void TestConstructeurTileDesert()
        {
            Assert.IsInstanceOfType(swamp, typeof(TileSwamp));
        }
    }
}

