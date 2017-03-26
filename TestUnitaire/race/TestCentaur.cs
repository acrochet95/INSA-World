using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using INSA_World;

namespace TestUnitaire
{
    [TestClass]
    public class TestCentaur
    {
        Centaur centaur;
        [TestInitialize]
        public void Initialize()
        {
            centaur = Centaur.INSTANCE;
        }

        [TestMethod]
        public void TestConstructeurCentaur()
        {
            Assert.IsNotNull(centaur);
        }

        [TestMethod]
        public void TestGetAttackPoints()
        {
            Assert.AreEqual(centaur.GetAttack_Points(), 8);
        }

        [TestMethod]
        public void TestGetDefPoints()
        {
            Assert.AreEqual(centaur.GetDef_Points(), 2);
        }

        [TestMethod]
        public void TestGetLifePoints()
        {
            Assert.AreEqual(centaur.GetLife_Points(), 10);
        }

        [TestMethod]
        public void TestVictoryPoints()
        {
            ITile tilePlain = FactoryTile.Instance.GetTile(TileType.Plain);
            ITile tileDesert = FactoryTile.Instance.GetTile(TileType.Desert);
            ITile tileVolcano = FactoryTile.Instance.GetTile(TileType.Volcano);
            ITile tileSwamp = FactoryTile.Instance.GetTile(TileType.Swamp);
            Assert.AreEqual(centaur.VictoryPointsOn(tilePlain), 3);
            Assert.AreEqual(centaur.VictoryPointsOn(tileDesert), 2);
            Assert.AreEqual(centaur.VictoryPointsOn(tileVolcano), 0);
            Assert.AreEqual(centaur.VictoryPointsOn(tileSwamp), 1);
        }
    }
}
