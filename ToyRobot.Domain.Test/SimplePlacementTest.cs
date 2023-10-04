using ToyRobot.Domain.Entities;
using ToyRobot.Domain.Enums;
using Xunit.Sdk;

namespace ToyRobot.Domain.Test
{
    [TestClass]
    public class SimplePlacementTest
    {
        [TestMethod]
        public void TestValues()
        {
            int x = 0;
            int y = 0;
            CompassDirection cd = CompassDirection.North;

            SimplePlacement placement = new SimplePlacement(x, y, cd);

            Assert.AreEqual(x, placement.X);
            Assert.AreEqual(y, placement.Y);
            Assert.AreEqual(cd, placement.CompassDirection);
        }

        [TestMethod]
        public void TestToString()
        {
            int x = 0;
            int y = 0;
            CompassDirection cd = CompassDirection.North;

            SimplePlacement placement = new SimplePlacement(x, y, cd);

            Assert.AreEqual("0,0,NORTH", placement.ToString());
        }

        [TestMethod]
        public void TestStructEquality()
        {
            SimplePlacement placement1 = new SimplePlacement(0, 0, CompassDirection.North);
            SimplePlacement placement2 = new SimplePlacement(0, 0, CompassDirection.North);

            Assert.AreEqual(placement1, placement2);
        }
    }
}