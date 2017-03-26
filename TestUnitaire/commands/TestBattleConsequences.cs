using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using INSA_World;

namespace TestUnitaire.commands
{
    [TestClass]
    public class TestBattleConsequences
    {
        BattleConsequences bc;
        Unit winner;
        Unit loser;

        BattleConsequences bc2;
        Unit winner2;
        Unit loser2;

        [TestInitialize]
        public void Initialize()
        {
            UnitFactory fu = new UnitFactory(Cerberus.INSTANCE);
            winner = fu.createUnit();
            winner.Position = new Position(1, 1);

            fu.Race = Cyclop.INSTANCE;
            loser = fu.createUnit();
            winner.Position = new Position(1, 2);

            bc = new BattleConsequences(winner, loser, 15, true, 1);


            winner2 = fu.createUnit();
            winner2.Position = new Position(1, 1);

            fu.Race = Cerberus.INSTANCE;
            loser2 = fu.createUnit();
            winner2.Position = new Position(1, 2);

            bc2 = new BattleConsequences(winner2, loser2, 5, false, 1);
        }

        [TestMethod]
        public void TestConstructeurBattleConsequences()
        {
            Assert.IsNotNull(bc);
            Assert.IsNotNull(bc.Winner);
            Assert.IsNotNull(bc.Loser);

            Assert.IsNotNull(bc2);
            Assert.IsNotNull(bc2.Winner);
            Assert.IsNotNull(bc2.Loser);
        }

        [TestMethod]
        public void TestExecute()
        {
            Position posLoser = bc.Loser.Position;

            bc.Execute();
            //Assert.IsFalse(bc.Winner.Passive);
            //Assert.IsFalse(bc.Loser.Passive);

            
            Assert.AreEqual(bc.Loser.Life, 0);
            Assert.AreEqual(bc.Winner.Position.X, posLoser.X);
            Assert.AreEqual(bc.Winner.Position.Y, posLoser.Y);
            Assert.IsTrue(bc2.Winner.CanPerformAction());

            // Test 2
            Position pos = bc2.Winner.Position;

            bc2.Execute();
            //Assert.IsFalse(bc2.Winner.Passive);
            //Assert.IsFalse(bc2.Loser.Passive);


            Assert.AreNotEqual(bc2.Loser.Life, 0);
            Assert.AreEqual(bc2.Winner.Position.X, pos.X);
            Assert.AreEqual(bc2.Winner.Position.Y, pos.Y);
            Assert.IsTrue(bc2.Winner.CanPerformAction());
        }
    }
}
