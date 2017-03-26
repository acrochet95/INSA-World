using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using INSA_World;

namespace TestUnitaire
{
    /// <summary>
    /// Description résumée pour TestPlayer
    /// </summary>
    [TestClass]
    public class TestPlayer
    {
        Player player;
        [TestInitialize]
        public void Initialize()
        {
            PlayerBuilder pb = new PlayerBuilder();
            player = pb.buildPlayer("name", Cerberus.INSTANCE, 4);
        }

        [TestMethod]
        public void TestConstructeurPlayer()
        {
            Assert.IsNotNull(player);
        }

        [TestMethod]
        public void TestGetRace()
        {
            Assert.AreEqual(player.GetRace(), Cerberus.INSTANCE);
        }
        
        [TestMethod]
        public void TestAddUnit()
        {
            Unit u = new Unit(Cerberus.INSTANCE);
            player.AddUnit(u);
            Unit uFound = player.Units.Find(x => x == u);
            Assert.AreEqual(u, uFound);
        }

        [TestMethod]
        public void TestGetAllUnitsOnPosition()
        {
            Position pos = new Position(2, 2);
            Unit u = new Unit(Cerberus.INSTANCE);
            u.Position = pos;
            player.AddUnit(u);

            Unit u2 = new Unit(Cerberus.INSTANCE);
            u2.Position = pos;
            player.AddUnit(u2);

            Assert.AreEqual(player.GetAllUnitsOnPosition(pos).Count, 2);
        }
        /*
        [TestMethod]
        public void TestDeleteUnit()
        {
            Unit u = new Unit(Cerberus.INSTANCE);
            player.AddUnit(u);

            Assert.IsTrue(player.DeleteUnit(u));

            Unit uFound = player.Units.Find(x => x == u);
            Assert.IsNull(uFound);
        }*/
    }
}
