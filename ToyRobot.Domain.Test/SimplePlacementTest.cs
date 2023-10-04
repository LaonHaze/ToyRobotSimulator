using ToyRobot.Domain.Entities;
using ToyRobot.Domain.Enums;
using ToyRobot.Domain.Interfaces;
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

        [TestMethod]
        public void TestMoveForward()
        {
            int x = 0;
            int y = 0;
            CompassDirection cd = CompassDirection.North;

            SimplePlacement placement = new SimplePlacement(x, y, cd);
            SimplePlacement newPlacement = placement.MoveForward();

            Assert.AreEqual(0, newPlacement.X);
            Assert.AreEqual(1, newPlacement.Y);
            Assert.AreEqual(CompassDirection.North, newPlacement.CompassDirection);
        }

        [TestMethod]
        public void TestTurnRight()
        {
            int x = 0;
            int y = 0;
            CompassDirection cd = CompassDirection.North;

            SimplePlacement placement = new SimplePlacement(x, y, cd);
            SimplePlacement newPlacement = placement.TurnRight();

            Assert.AreEqual(0, newPlacement.X);
            Assert.AreEqual(0, newPlacement.Y);
            Assert.AreEqual(CompassDirection.East, newPlacement.CompassDirection);
        }

        [TestMethod]
        public void TestTurnLeft()
        {
            int x = 0;
            int y = 0;
            CompassDirection cd = CompassDirection.East;

            SimplePlacement placement = new SimplePlacement(x, y, cd);
            SimplePlacement newPlacement = placement.TurnLeft();

            Assert.AreEqual(0, newPlacement.X);
            Assert.AreEqual(0, newPlacement.Y);
            Assert.AreEqual(CompassDirection.North, newPlacement.CompassDirection);
        }

        [TestMethod]
        public void TestTurnLeftFromNorth()
        {
            int x = 0;
            int y = 0;
            CompassDirection cd = CompassDirection.North;

            SimplePlacement placement = new SimplePlacement(x, y, cd);
            SimplePlacement newPlacement = placement.TurnLeft();

            Assert.AreEqual(0, newPlacement.X);
            Assert.AreEqual(0, newPlacement.Y);
            Assert.AreEqual(CompassDirection.West, newPlacement.CompassDirection);
        }

        [TestMethod]
        public void TestTurnRightFromWest()
        {
            int x = 0;
            int y = 0;
            CompassDirection cd = CompassDirection.West;

            SimplePlacement placement = new SimplePlacement(x, y, cd);
            SimplePlacement newPlacement = placement.TurnRight();

            Assert.AreEqual(0, newPlacement.X);
            Assert.AreEqual(0, newPlacement.Y);
            Assert.AreEqual(CompassDirection.North, newPlacement.CompassDirection);
        }
    }
}