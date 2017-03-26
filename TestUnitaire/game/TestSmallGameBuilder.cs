using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using INSA_World;

namespace TestUnitaire
{
    [TestClass]
    public class TestSmallGameBuilder
    {
        SmallGameBuilder sgb;

        [TestInitialize]
        public void Initialize()
        {
            sgb = new SmallGameBuilder();
        }

        [TestMethod]
        public void TestConstructeurSmallGameBuilder()
        {
            Assert.AreEqual(sgb.Nb_turns, 20);
            Assert.AreEqual(sgb.Nb_units, 6);
        }

        [TestMethod]
        public void TestBuildGame()
        {
            Game game = sgb.buildGame();
            Assert.IsNotNull(game);
            Assert.IsNotNull(game.Map);
        }
    }
}
