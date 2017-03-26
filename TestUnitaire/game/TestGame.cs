using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using INSA_World;

namespace TestUnitaire
{
    [TestClass]
    public class TestGame
    {
        Game game;
        Player player1;
        Player player2;

        [TestInitialize]
        public void Initialize()
        {
            StandardGameBuilder builder = new StandardGameBuilder();
            game = builder.buildGame();

            PlayerBuilder pb = new PlayerBuilder();
            player1 = pb.buildPlayer("Elodie", Cerberus.INSTANCE, game.Nb_units);
            player2 = pb.buildPlayer("Antoine", Cyclop.INSTANCE, game.Nb_units);
            game.AddPlayers(player1, player2);
        }

        [TestMethod]
        public void TestConstructeurPosition()
        {
            Assert.IsNotNull(game);
            Assert.IsNotNull(game.Map);
            Assert.AreEqual(game.Turns, 30);
        }

        [TestMethod]
        public void TestGetterSetterMap()
        {
            Map map = new Map(10);
            game.Map = map;

            Assert.AreEqual(game.Map, map);
        }

        [TestMethod]
        public void TestGetterSetterTurns()
        {
            game.Turns = 10;

            Assert.AreEqual(game.Turns, 10);
        }

        [TestMethod]
        public void TestAddPlayers()
        {
            game.Player1 = null;
            game.Player2 = null;
            bool value = game.AddPlayers(player1, player2);

            Assert.IsTrue(value);
            Assert.IsNotNull(game.Player1);
            Assert.IsInstanceOfType(game.Player1, typeof(Player));
            Assert.AreEqual(game.Player1, player1);

            Assert.IsNotNull(game.Player2);
            Assert.IsInstanceOfType(game.Player2, typeof(Player));
            Assert.AreEqual(game.Player2, player2);

            // Test placement units
            Position pp1 = game.Player1.Units[0].Position;
            Position pp2 = game.Player2.Units[0].Position;

            Assert.IsFalse(pp1.X == pp2.X && pp1.Y == pp2.Y);


            PlayerBuilder pb = new PlayerBuilder();
            Player player3 = pb.buildPlayer("zfezthy", Cyclop.INSTANCE, game.Nb_units);
            Assert.IsFalse(game.AddPlayers(player2, player3));
        }

        [TestMethod]
        public void TestComputeVictoryPoints()
        {

        }
        /*
        [TestMethod]
        public void TestDeleteUnit()
        {
            Unit unit = new Unit(Cerberus.INSTANCE);
            game.Player1.AddUnit(unit);
            game.DeleteUnit(unit);
            
            Unit uFound = game.Player1.Units.Find(x => x == unit);

            Assert.IsNull(uFound);

            game.Player2.AddUnit(unit);
            game.DeleteUnit(unit);

            Unit uFound2 = game.Player1.Units.Find(x => x == unit);
            Assert.IsNull(uFound);
        }
        */
        [TestMethod]
        public void TestCheckVictory()
        {
            game.Turns = 0;
            game.Player1.Score = 20;
            game.Player2.Score = 30;
            Assert.AreEqual(game.CheckVictory(), game.Player2);

            game.Turns = 10;
            Assert.IsNull(game.CheckVictory());

            game.Player2.Units.Clear();
            Assert.AreEqual(game.CheckVictory(), game.Player1);
        }
    }
}
