using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using INSA_World;

namespace TestUnitaire.map
{
    [TestClass]
    public class TestBuilderSmallMap
    {
        BuilderSmallMap builder;

        [TestInitialize]
        public void Initialize()
        {
            builder = new BuilderSmallMap();
        }

        [TestMethod]
        public void TestConstructeurBuilderSmallMap()
        {
            Assert.IsNotNull(builder);
            Assert.IsNotNull(builder.Map);
        }

        [TestMethod]
        public void TestBuildMap()
        {
            Map map = builder.buildMap();
            for (int i = 0; i < builder.GetSize(); i++)
            {
                for (int j = 0; j < builder.GetSize(); j++)
                {
                    Position pos = new Position(i, j);
                    Assert.IsNotNull(map.GetTile(pos));
                    Assert.IsInstanceOfType(map.GetTile(pos), typeof(ITile));
                }
            }
        }
    }
}
