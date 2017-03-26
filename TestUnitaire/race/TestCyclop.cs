using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using INSA_World;

namespace TestUnitaire
{
    [TestClass]
    public class TestCyclop
    {
        Cyclop cyclop;
        [TestInitialize]
        public void Initialize()
        {
            cyclop = Cyclop.INSTANCE;
        }

        [TestMethod]
        public void TestConstructeurCentaur()
        {
            Assert.IsNotNull(cyclop);
        }

        [TestMethod]
        public void TestGetAttackPoints()
        {
            Assert.AreEqual(cyclop.GetAttack_Points(), 4);
        }

        [TestMethod]
        public void TestGetDefPoints()
        {
            Assert.AreEqual(cyclop.GetDef_Points(), 6);
        }

        [TestMethod]
        public void TestGetLifePoints()
        {
            Assert.AreEqual(cyclop.GetLife_Points(), 12);
        }

        [TestMethod]
        public void TestVictoryPoints()
        {
            ITile tilePlain = FactoryTile.Instance.GetTile(TileType.Plain);
            ITile tileDesert = FactoryTile.Instance.GetTile(TileType.Desert);
            ITile tileVolcano = FactoryTile.Instance.GetTile(TileType.Volcano);
            ITile tileSwamp = FactoryTile.Instance.GetTile(TileType.Swamp);
            Assert.AreEqual(cyclop.VictoryPointsOn(tilePlain), 2);
            Assert.AreEqual(cyclop.VictoryPointsOn(tileDesert), 3);
            Assert.AreEqual(cyclop.VictoryPointsOn(tileVolcano), 1);
            Assert.AreEqual(cyclop.VictoryPointsOn(tileSwamp), 0);
        }
    }
}
