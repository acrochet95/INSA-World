using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using INSA_World;

namespace TestUnitaire
{
    [TestClass]
    public class TestPosition
    {
        Position position;

        [TestInitialize]
        public void Initialize()
        {
            position = new Position(2, 2);
        }

        [TestMethod]
        public void TestConstructeurPosition()
        {
            Assert.IsNotNull(position);
            Assert.AreEqual(position.X, 2);
            Assert.AreEqual(position.Y, 2);
        }

        [TestMethod]
        public void TestGetterSetterPosition()
        {
            position.X = 10;
            Assert.AreEqual(position.X, 10);

            position.Y = 1;
            Assert.AreEqual(position.Y, 1);
        }
    }
}
