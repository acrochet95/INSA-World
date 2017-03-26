using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using INSA_World;

namespace TestUnitaire.commands
{
    [TestClass]
    public class TestBattle
    {
        Battle battle;
        Unit unitAttacker;
        List<Unit> defenders;

        [TestInitialize]
        public void Initialize()
        {
            UnitFactory fu = new UnitFactory(Cerberus.INSTANCE);
            unitAttacker = fu.createUnit();

            fu.Race = Centaur.INSTANCE;
            defenders = new List<Unit>();
            for(int i=0;i<2;i++)
                defenders.Add(fu.createUnit());

            battle = new Battle(unitAttacker, defenders, 2);
        }

        [TestMethod]
        public void TestConstructeurBattle()
        {
            Assert.IsNotNull(battle);
            Assert.IsNotNull(battle.Attacker);
            Assert.IsNotNull(battle.DefenderSelected);
        }

        [TestMethod]
        public void TestCompute()
        {
            int nb_attacker_won = 0;
            for (int i = 0; i < 1000; i++)
            {
                UnitFactory fu = new UnitFactory(Cerberus.INSTANCE);
                battle.Attacker = fu.createUnit();

                fu.Race = Centaur.INSTANCE;
                battle.DefenderSelected = fu.createUnit();

                battle.Compute();
                Assert.IsNotNull(battle.BattleConsequences);

                if (battle.BattleConsequences.Winner == battle.Attacker)
                    nb_attacker_won++;
            }

            // Verifie si proba que l'attaquant gagne = 75% à +/- 5% prêt
            Assert.IsTrue(nb_attacker_won >= 700 && nb_attacker_won <= 800);
        }

        [TestMethod]
        public void TestConsequences()
        {

        }
    }
}
