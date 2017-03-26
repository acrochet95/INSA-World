using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using INSA_World;

namespace TestUnitaire
{
    [TestClass]
    public class TestCerberus
    {
        Cerberus cerberus;
        [TestInitialize]
        public void Initialize()
        {
            cerberus = Cerberus.INSTANCE;
        }

        [TestMethod]
        public void TestConstructeurCentaur()
        {
            Assert.IsNotNull(cerberus);
        }

        [TestMethod]
        public void TestGetAttackPoints()
        {
            Assert.AreEqual(cerberus.GetAttack_Points(), 6);
        }

        [TestMethod]
        public void TestGetDefPoints()
        {
            Assert.AreEqual(cerberus.GetDef_Points(), 4);
        }

        [TestMethod]
        public void TestGetLifePoints()
        {
            Assert.AreEqual(cerberus.GetLife_Points(), 10);
        }


        [TestMethod]
        public void TestVictoryPoints()
        {
            ITile tilePlain = FactoryTile.Instance.GetTile(TileType.Plain);
            ITile tileDesert = FactoryTile.Instance.GetTile(TileType.Desert);
            ITile tileVolcano = FactoryTile.Instance.GetTile(TileType.Volcano);
            ITile tileSwamp = FactoryTile.Instance.GetTile(TileType.Swamp);
            Assert.AreEqual(cerberus.VictoryPointsOn(tilePlain), 0);
            Assert.AreEqual(cerberus.VictoryPointsOn(tileDesert), 1);
            Assert.AreEqual(cerberus.VictoryPointsOn(tileVolcano), 2);
            Assert.AreEqual(cerberus.VictoryPointsOn(tileSwamp), 3);
        }
    }
}
