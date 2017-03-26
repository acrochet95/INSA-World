using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using INSA_World;

namespace TestUnitaire
{
    [TestClass]
    public class TestTilePlain
    {
        TilePlain plain;

        [TestInitialize]
        public void Initialize()
        {
            plain = new TilePlain();
        }

        [TestMethod]
        public void TestConstructeurTilePlain()
        {
            Assert.IsInstanceOfType(plain, typeof(TilePlain));
        }
    }
}
