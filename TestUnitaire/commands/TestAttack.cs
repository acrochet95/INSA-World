using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using INSA_World;

namespace TestUnitaire.commands
{
    [TestClass]
    public class TestAttack
    {
        Battle battle;
        Attack attack;

        [TestInitialize]
        public void Initialize()
        {
            UnitFactory fu = new UnitFactory(Cerberus.INSTANCE);
            Unit unitAttacker = fu.createUnit();

            fu.Race = Centaur.INSTANCE;
            List<Unit> defenders = new List<Unit>();
            for (int i = 0; i < 2; i++)
                defenders.Add(fu.createUnit());

            battle = new Battle(unitAttacker, defenders, 2);

            attack = new Attack(battle);
        }

        [TestMethod]
        public void TestConstructeurBattle()
        {
            Assert.IsNotNull(attack);
            Assert.IsNotNull(attack.Battle);
        }

        [TestMethod]
        public void TestExecute()
        {
            attack.Execute();
            Assert.IsNotNull(attack.Battle.BattleConsequences);
        }
    }
}
