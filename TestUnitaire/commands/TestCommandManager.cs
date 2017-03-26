using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using INSA_World;
using System.IO;

namespace TestUnitaire.commands
{
    [TestClass]
    public class TestCommandManager
    {
        Game gameSaved;
        CommandManager cm;
        string fileName;

        [TestInitialize]
        public void Initialize()
        {
            cm = CommandManager.Instance;
            fileName = "save.bin";

            DemoGameBuilder demoGame = new DemoGameBuilder();
            gameSaved = demoGame.buildGame();

            string namePlayer1 = "Elodie";
            string namePlayer2 = "Antoine";

            PlayerBuilder pb = new PlayerBuilder();
            Player player1 = pb.buildPlayer(namePlayer1, Cerberus.INSTANCE, gameSaved.Nb_units);
            Player player2 = pb.buildPlayer(namePlayer2, Centaur.INSTANCE, gameSaved.Nb_units);

            gameSaved.AddPlayers(player1, player2);
        }

        [TestMethod]
        public void TestConstructeurCommandManager()
        {
            Assert.IsNotNull(cm);
            Assert.IsNotNull(cm.Commands);
        }

        [TestMethod]
        public void TestReplayAll()
        {

        }

        [TestMethod]
        public void TestSave()
        {
            cm.Save(gameSaved, fileName);
            Assert.IsTrue(File.Exists(fileName));
        }

        [TestMethod]
        public void TestLoad()
        {
            Assert.IsTrue(File.Exists(fileName));
            Assert.IsNotNull(gameSaved);

            Game game = cm.Load(fileName);
            Assert.IsNotNull(game);
            Assert.IsNotNull(game.Player1);
            Assert.IsNotNull(game.Player2);
            Assert.IsNotNull(game.Map);

            Assert.AreEqual(game.Player1.Name, gameSaved.Player1.Name);
            Assert.AreEqual(game.Player2.Name, gameSaved.Player2.Name);
            Assert.AreEqual(game.Map.Size, gameSaved.Map.Size);

            Assert.AreEqual(game.Player1.Units.Count, gameSaved.Player1.Units.Count);
            Assert.AreEqual(game.Player2.Units.Count, gameSaved.Player2.Units.Count);

            Assert.IsInstanceOfType(game.Player1.Units[0].Race, typeof(Cerberus));
            Assert.IsInstanceOfType(game.Player2.Units[0].Race, typeof(Centaur));

        }

        [TestMethod]
        public void TestStoreAndExecute()
        {
            UnitFactory fu = new UnitFactory(Cerberus.INSTANCE);
            Unit unitAttacker = fu.createUnit();

            fu.Race = Centaur.INSTANCE;
            List<Unit> defenders = new List<Unit>();
            for (int i = 0; i < 2; i++)
                defenders.Add(fu.createUnit());

            Battle battle = new Battle(unitAttacker, defenders, 2);
            Attack attack = new Attack(battle);

            cm.StoreAndExecute(attack);

            Assert.IsNotNull(battle.BattleConsequences);
            
            ICommand attackFound = cm.Commands.Find(x => x == attack);
            Assert.IsNotNull(attackFound);
            Assert.IsInstanceOfType(attackFound, typeof(Attack));
        }
    }
}
