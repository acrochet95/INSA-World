using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using INSA_World;

namespace TestUnitaire
{
    [TestClass]
    public class TestUnit
    {
        Unit unit;
        Race race;

        [TestInitialize]
        public void Initialize()
        {
            race = Cerberus.INSTANCE;
            UnitFactory uf = new UnitFactory(race);
            unit = uf.createUnit();
        }

        [TestMethod]
        public void TestConstructeurUnit()
        {
            Assert.IsNotNull(unit);
            Assert.IsNotNull(unit.Race);
        }

        [TestMethod]
        public void TestGetterAndSetterRace()
        {
            Assert.AreEqual(race, unit.Race);

            unit.Race = Cyclop.INSTANCE;
            Assert.AreEqual(unit.Race, Cyclop.INSTANCE);
        }

        [TestMethod]
        public void TestGetterAndSetterPosition()
        {
            Position pos = new Position(5, 5);
            unit.Position = pos;
            Assert.AreEqual(unit.Position.X, pos.X);
            Assert.AreEqual(unit.Position.Y, pos.Y);
        }

        [TestMethod]
        public void TestGetterAndSetterPassive()
        {
            unit.Passive = true;
            Assert.AreEqual(unit.Passive, true);
        }

        [TestMethod]
        public void TestMove()
        {
            unit.Move(2, 0, 2);
            Assert.AreEqual(unit.Position.X, 2);
            Assert.AreEqual(unit.Position.Y, 0);
            Assert.IsTrue(unit.CanPerformAction());

            unit.Move(1, 0, 1);
            Assert.IsFalse(unit.CanPerformAction());
        }

        [TestMethod]
        public void TestHeal()
        {
            int life = unit.Life;
            unit.Heal();
            Assert.AreEqual(life, unit.Life);

            // Test heal after beeing attacked
            unit.Attacked(5);
            unit.Heal();
            Assert.AreEqual(life-5+1, unit.Life);
        }

        [TestMethod]
        public void TestGetLife()
        {
            int life = unit.Life;
            Assert.AreEqual(life, unit.Race.GetLife_Points());
        }

        [TestMethod]
        public void TestRefreshMovePoints()
        {
            unit.Move(3, 0, 3);
            unit.RefreshMovePoints();
            Assert.IsTrue(unit.CanPerformAction());
        }

        [TestMethod]
        public void TestCanPerformAction()
        {
            Assert.IsTrue(unit.CanPerformAction());
        }

        [TestMethod]
        public void TestAttacked()
        {
            Assert.IsFalse(unit.Attacked(5));
            Assert.IsTrue(unit.Life == unit.Race.GetLife_Points()-5);

            Assert.IsTrue(unit.Attacked(15));
        }

        [TestMethod]
        public void TestGetAttackPoints()
        {
            unit.Attacked(2);
            Assert.IsTrue(unit.GetAttackPoints() < unit.Race.GetAttack_Points());
        }

        [TestMethod]
        public void TestGetDefencePoints()
        {
            unit.Attacked(2);
            Assert.IsTrue(unit.GetDefencePoints() < unit.Race.GetDef_Points());
        }
    }
}
