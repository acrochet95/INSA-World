using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using INSA_World;

namespace TestUnitaire
{
    [TestClass]
    public class TestFactoryUnit
    {
        UnitFactory uf;
        Race race;

        [TestInitialize]
        public void Initialize()
        {
            race = Cerberus.INSTANCE;
            uf = new UnitFactory(race);
        }

        [TestMethod]
        public void TestConstructeurFactoryUnit()
        {
            Assert.IsNotNull(uf);
            Assert.IsNotNull(race);
        }

        [TestMethod]
        public void TestGetter()
        {
            Assert.AreEqual(uf.Race, Cerberus.INSTANCE);
        }

        [TestMethod]
        public void TestSetter()
        {
            uf.Race = Cyclop.INSTANCE;
            Assert.AreEqual(uf.Race, Cyclop.INSTANCE);
        }

        [TestMethod]
        public void TestCreateUnit()
        {
            Unit unit = new Unit(this.race);
            Assert.IsNotNull(unit);
            Assert.IsNotNull(unit.Race);
        }
    }
}
