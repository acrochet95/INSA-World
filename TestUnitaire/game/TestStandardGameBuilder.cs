using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using INSA_World;

namespace TestUnitaire
{
    [TestClass]
    public class TestStandardGameBuilder
    {
        StandardGameBuilder sgb;

        [TestInitialize]
        public void Initialize()
        {
            sgb = new StandardGameBuilder();
        }

        [TestMethod]
        public void TestConstructeurStandardGameBuilder()
        {
            Assert.AreEqual(sgb.Nb_turns, 30);
            Assert.AreEqual(sgb.Nb_units, 8);
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
