using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using INSA_World;

namespace TestUnitaire.commands
{
    [TestClass]
    public class TestMove
    {
        Move move;
        Unit unit;

        [TestInitialize]
        public void Initialize()
        {
            UnitFactory uf = new UnitFactory(Cerberus.INSTANCE);
            unit = uf.createUnit();
            unit.Position = new Position(2,2);

            move = new Move(unit, new Position(2, 3), 1);
        }

        [TestMethod]
        public void TestConstructeurMove()
        {
            Assert.IsNotNull(move);
        }

        [TestMethod]
        public void TestExecute()
        {
            move.Execute();
            Assert.AreEqual(unit.Position.X, 2);
            Assert.AreEqual(unit.Position.Y, 3);
            Assert.AreEqual(unit.Moves, 2);
        }
    }
}
