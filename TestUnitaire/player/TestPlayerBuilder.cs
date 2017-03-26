using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using INSA_World;

namespace TestUnitaire
{
    /// <summary>
    /// Description résumée pour TestPlayerBuilder
    /// </summary>
    [TestClass]
    public class TestPlayerBuilder
    {
        PlayerBuilder pb;

        [TestInitialize]
        public void Initialize()
        {
            pb = new PlayerBuilder();
        }

        [TestMethod]
        public void TestConstructeurPlayerBuilder()
        {
            Assert.IsNotNull(pb);
        }

        [TestMethod]
        public void TestBuildPlayer()
        {
            Player p = pb.buildPlayer("name", Cerberus.INSTANCE, 10);
            Assert.IsNotNull(p);
        }
    }
}
