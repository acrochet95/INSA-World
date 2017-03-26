using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using INSA_World;

namespace TestUnitaire
{
    [TestClass]
    public class TestTileDesert
    {
        TileDesert desert;

        [TestInitialize]
        public void Initialize()
        {
            desert = new TileDesert();
        }

        [TestMethod]
        public void TestConstructeurTileDesert()
        {
            Assert.IsInstanceOfType(desert, typeof(TileDesert));
        }
    }
}

