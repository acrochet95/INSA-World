using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using INSA_World;

namespace TestUnitaire
{
    [TestClass]
    public class TestDemoGameBuilder
    {
        DemoGameBuilder dgb;

        [TestInitialize]
        public void Initialize()
        {
            dgb = new DemoGameBuilder();
        }

        [TestMethod]
        public void TestConstructeurDemoGameBuilder()
        {
            Assert.AreEqual(dgb.Nb_turns, 5);
            Assert.AreEqual(dgb.Nb_units, 4);
        }

        [TestMethod]
        public void TestBuildGame()
        {
            Game game = dgb.buildGame();
            Assert.IsNotNull(game);
            Assert.IsNotNull(game.Map);
        }
    }
}
